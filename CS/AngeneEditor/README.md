# Angene Editor

Angene Editor is the Windows-first visual authoring environment for the maintained
C# version of Angene. Its workflow is inspired by modern game editors while
remaining an original Angene interface and codebase.

## Highlights

- Five-region workspace: Project/Assets, Scene Hierarchy, Scene or Game view,
  Inspector, and Console.
- Searchable nested hierarchy with create, duplicate, rename, delete, reparent,
  reorder, and selection synchronization.
- Grid-based Scene view with pan, zoom, framing, move/rotate/scale gizmos, and
  optional snapping.
- Inspector editing for 3D transforms, scripts, and persistent component cards.
  Built-in presets include Sprite Renderer, Camera, Audio Source, Box Collider 2D,
  Rigidbody 2D, and Custom.
- Stable GUIDs for projects, scenes, entities, components, scripts, and imported
  assets.
- Bounded undo/redo command history, atomic saves, autosave recovery, recent
  project support, and persisted window/splitter layout.
- Build and Play workflow with a selectable or auto-detected .NET SDK. Play mode
  uses a separate runtime scene instance and supports pause, single-frame step,
  resume, and stop without leaking runtime changes into the edit document.

## Requirements

- Windows 10 or newer.
- .NET 8 SDK. If it is not on `PATH`, choose **Tools > Select .NET SDK**.
- The native Angene host only when using the optional external launch workflow.

## Build and test

From the repository root:

```powershell
dotnet restore CS/AngeneEditor.Tests/AngeneEditor.Tests.csproj
dotnet build CS/AngeneEditor/AngeneEditor.csproj --configuration Debug --no-restore
dotnet test CS/AngeneEditor.Tests/AngeneEditor.Tests.csproj --configuration Debug --no-restore
```

Launch the editor with:

```powershell
dotnet run --project CS/AngeneEditor/AngeneEditor.csproj
```

## Authoring workflow

1. Create a project or open an existing `.csproj`.
2. Create, duplicate, rename, parent, reorder, search, and delete scene entities
   in the Hierarchy.
3. Select entities in the Hierarchy or Scene view. Edit their transforms,
   enabled state, scripts, and components in the Inspector.
4. Pan and zoom the Scene view, frame the selection or all entities, and use
   **W**, **E**, and **R** for move, rotate, and scale tools. Enable snapping
   when precise increments are needed.
5. Save the project. The editor writes:
   - `.angene/project.json` for versioned project metadata.
   - `.angene/Scenes/Main.angscene` for the canonical, versioned scene document.
   - `Scenes/Init.cs` as generated compatibility code for the current runtime.
   - `.angene/Recovery/Main.autosave.angscene` only while an unsaved recovery
     snapshot is needed.
6. Press **Play** to build and load a separate runtime scene instance in Game View.
   Pause, step one frame, resume, and stop from the toolbar. Stopping discards
   runtime mutations and reloads the saved edit scene.

Project assets live under `Assets/`. Every discovered source asset receives a
sidecar `.meta` file containing a stable ID, importer classification, content
hash, and importer settings. Sidecars should be committed alongside their assets.

## Architecture

- `Documents/` - versioned scene model, validation, deep cloning, and atomic JSON
  persistence.
- `Commands/` - reversible editor commands and bounded undo/redo history.
- `Assets/` - stable asset identity, metadata, type classification, and change
  detection.
- `Project/` - project creation/open/save, legacy `Init.cs` migration, and runtime
  code generation.
- `Runtime/` - isolated play-scene hosting, lifecycle modes, frame stepping, and
  collectible assembly loading.
- `Panels/` - hierarchy, inspector, project/assets, viewport, and console UI.
- `Workspace/` - layout/settings persistence and autosave recovery scheduling.

Engine runtime assemblies remain independently buildable. Editor-only project and
scene metadata stays under `.angene/`.

## File safety

Scene and metadata writes use same-directory temporary files followed by replace
operations. Scene documents are validated for duplicate IDs, missing parents,
invalid components, unsupported schema versions, and hierarchy cycles before they
are saved.

## Known limitations

- The persisted workspace remembers window and splitter geometry; arbitrary
  detachable/custom dock tabs are not implemented.
- Inspector component fields use a schema-backed property bag rather than runtime
  reflection or custom per-type drawers.
- Asset metadata and search are implemented, but thumbnails, drag-to-assign
  object fields, and live filesystem watching are not.
- Runtime code generation currently materializes entities and scripts. Generic
  editor component cards remain authoring metadata until the matching engine
  runtime component adapter exists.
- The Scene view is an editor-native 2D projection of the 3D transform model;
  local/world axes, camera perspective controls, and GPU scene picking remain
  future work.
- External play requires `AngeneHost.exe`; in-editor Play works through the
  collectible managed scene host.
