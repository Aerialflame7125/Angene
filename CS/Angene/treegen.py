import os
import re
import argparse
from pathlib import Path
from collections import defaultdict

# Regex patterns for extracting C# structures
NAMESPACE_RE = re.compile(r'namespace\s+([A-Za-z0-9_.]+)')
CLASS_RE = re.compile(r'public\s+(?:abstract\s+|sealed\s+|static\s+|partial\s+)*(class|interface|struct|enum|record)\s+([A-Za-z0-9_<>]+)')
MEMBER_RE = re.compile(r'^\s*public\s+(?:static\s+|virtual\s+|override\s+|abstract\s+|sealed\s+|readonly\s+|const\s+)*([A-Za-z0-9_<>\[\]?,]+)\s+([A-Za-z0-9_]+)\s*(\(|{|=>|;|=)')

def parse_cs_file(filepath):
    """Reads a .cs file and extracts public API elements."""
    api_elements = []
    current_namespace = "Global"
    current_class = None

    try:
        with open(filepath, 'r', encoding='utf-8-sig') as f:
            lines = f.readlines()
    except Exception as e:
        print(f"Failed to read {filepath}: {e}")
        return []

    for line in lines:
        line_stripped = line.strip()
        
        # Skip single-line comments
        if line_stripped.startswith("//"):
            continue

        # Find Namespace
        ns_match = NAMESPACE_RE.search(line)
        if ns_match:
            current_namespace = ns_match.group(1)
            continue

        # Find Class/Interface/Struct
        cls_match = CLASS_RE.search(line)
        if cls_match:
            obj_type, obj_name = cls_match.groups()
            current_class = f"{obj_type} {obj_name}"
            api_elements.append({
                'namespace': current_namespace,
                'class': current_class,
                'member': None
            })
            continue

        # Find Members (Methods, Properties, Fields)
        if current_class:
            member_match = MEMBER_RE.search(line)
            if member_match:
                ret_type, name, ending = member_match.groups()
                
                # Format based on what it looks like
                if ending == '(':
                    member_str = f"{ret_type} {name}()"
                elif ending in ('{', '=>'):
                    member_str = f"{ret_type} {name} {{ get; set; }}"
                else:
                    member_str = f"{ret_type} {name}"
                    
                api_elements.append({
                    'namespace': current_namespace,
                    'class': current_class,
                    'member': member_str
                })

    return api_elements

def discover_cs_files(root_dir):
    """Finds all .csproj files and assumes all .cs files in their directory tree belong to them."""
    root_path = Path(root_dir)
    cs_files = []
    
    for cs_file in root_path.rglob("*.cs"):
        if "obj" not in cs_file.parts and "bin" not in cs_file.parts:
            cs_files.append(cs_file)
            
    return cs_files

def generate_markdown(api_data, use_gfm=False):
    """Generates the markdown tree."""
    tree = defaultdict(lambda: defaultdict(list))
    
    # Build tree structure
    for item in api_data:
        ns = item['namespace']
        cls = item['class']
        mem = item['member']
        
        if mem:
            if mem not in tree[ns][cls]:
                tree[ns][cls].append(mem)
        else:
            if cls not in tree[ns]:
                tree[ns][cls] = []

    lines = []
    lines.append("# Public API Tree\n")
    lines.append("> Generated automatically. Read-only output.\n\n")

    for ns in sorted(tree.keys()):
        if use_gfm:
            # Proper spacing so Markdown doesn't choke on the HTML
            lines.append(f"<details><summary><b>{ns}</b></summary>\n\n")
        else:
            lines.append(f"## {ns}\n\n")
            
        for cls in sorted(tree[ns].keys()):
            if use_gfm:
                lines.append(f"* **{cls}**\n")
                for mem in tree[ns][cls]:
                    lines.append(f"  * `{mem}`\n")
            else:
                lines.append(f"* {cls}\n")
                for mem in tree[ns][cls]:
                    lines.append(f"  * {mem}\n")
        
        if use_gfm:
            lines.append("\n</details>\n")
        lines.append("\n")

    return "".join(lines)

def main():
    parser = argparse.ArgumentParser(description="Crawl C# projects and generate markdown API trees.")
    # nargs='+' lets you pass in as many directories as you want separated by spaces
    parser.add_argument("directories", nargs='+', help="One or more root directories to crawl for .cs files.")
    parser.add_argument("--outdir", default=".", help="Directory to save the generated .md files (defaults to current directory).")
    parser.add_argument("--gfm", action="store_true", help="Output using GitHub-Flavored Markdown (collapsible details).")
    args = parser.parse_args()

    out_path = Path(args.outdir)
    out_path.mkdir(parents=True, exist_ok=True)

    for d in args.directories:
        target_dir = Path(d)
        if not target_dir.exists() or not target_dir.is_dir():
            print(f"Skipping '{d}': Not a valid directory.")
            continue

        # Extract the base folder name to use as the file name
        folder_name = target_dir.name
        if not folder_name:
            folder_name = "Api_Output" # Fallback if you somehow pass a root drive like C:\
        
        output_file = out_path / f"{folder_name}.md"

        print(f"\nCrawling directory: {target_dir}")
        cs_files = discover_cs_files(target_dir)
        
        if not cs_files:
            print(f"No C# files found in {target_dir}. Moving on.")
            continue

        print(f"Found {len(cs_files)} C# files. Parsing now...")

        all_api_elements = []
        for f in cs_files:
            all_api_elements.extend(parse_cs_file(f))

        print(f"Extracted {len(all_api_elements)} public API elements. Generating markdown...")
        md_content = generate_markdown(all_api_elements, args.gfm)

        try:
            with open(output_file, 'w', encoding='utf-8') as out_f:
                out_f.write(md_content)
            print(f"Success. Tree written to {output_file}")
        except Exception as e:
            print(f"Failed to write {output_file}: {e}")

if __name__ == "__main__":
    main()