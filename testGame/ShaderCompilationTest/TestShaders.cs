using Angene.Common;
using Angene.Essentials.GraphicsContexts;
using Angene.Graphics;
using Angene.Graphics.SlangShader;
using System;
using System.IO;

namespace Game
{
    // Engine.Init() scans the calling assembly for any class marked [Precompile] that
    // implements SlangShaderResources.IShader, instantiates it with Activator.CreateInstance
    // (so it MUST have a public parameterless constructor), and feeds Path/EntryPoint/Type
    // into the Slang compiler during the shader-compilation splash screen.
    //
    // Once compiled, the resulting Dx11Shader ends up in Engine.Instance.ShaderCache
    // keyed by Name.

    [Attributes.Precompile]
    public class TestVertexShader : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 1;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }

    [Attributes.Precompile]
    public class TestPixelShader : SlangShaderResources.IShader
    {
        public string Name => "TestPS";
        public bool VerboseLog { get; set; } = true;
        public int id => 2;
        public string Extension => "hlsl";
        public string Path { get; set; } = System.IO.Path.Combine(AppContext.BaseDirectory, "Shaders", "PixelShader.hlsl");
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Pixel;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        public string Code => @"struct PSInput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

float4 main(PSInput input) : SV_TARGET
{
    return input.Color;
}
";

        public byte[] byteCode => null;

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public void Bind() { }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}','Path':'{Path}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }
    [Attributes.Precompile]
    public class TestVertexShader3 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 3;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader4 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 4;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader5 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 5;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader6 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 6;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader7 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 7;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader8 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 8;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader9 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 9;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader10 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 10;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader11 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 11;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader12 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 12;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader13 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 13;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader14 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 14;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader15 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 15;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader16 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 16;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader17 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 17;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader18 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 18;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader19 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 19;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader20 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 20;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader21 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 21;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader22 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 22;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader23 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 23;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader24 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 24;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader25 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 25;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader26 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 26;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader27 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 27;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader28 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 28;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader29 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 29;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader30 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 30;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader31 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 31;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader32 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 32;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader33 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 33;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader34 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 34;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader35 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 35;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader36 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 36;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader37 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 37;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader38 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 38;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader39 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 39;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader40 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 40;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader41 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 41;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader42 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 42;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader43 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 43;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader44 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 44;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader45 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 45;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader46 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 46;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader47 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 47;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader48 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 48;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader49 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 49;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader50 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 50;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader51 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 51;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader52 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 52;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader53 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 53;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader54 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 54;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader55 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 55;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader56 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 56;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader57 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 57;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader58 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 58;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader59 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 59;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader60 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 60;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader61 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 61;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader62 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 62;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader63 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 63;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader64 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 64;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader65 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 65;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader66 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 66;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader67 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 67;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader68 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 68;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader69 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 69;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader70 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 70;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader71 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 71;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader72 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 72;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader73 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 73;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader74 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 74;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader75 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 75;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader76 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 76;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader77 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 77;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader78 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 78;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader79 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 79;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader80 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 80;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader81 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 81;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader82 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 82;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader83 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 83;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader84 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 84;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader85 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 85;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader86 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 86;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader87 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 87;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader88 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 88;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader89 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 89;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader90 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 90;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader91 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 91;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader92 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 92;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader93 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 93;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader94 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 94;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader95 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 95;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader96 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 96;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader97 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 97;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader98 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 98;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader99 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 99;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }


    [Attributes.Precompile]
    public class TestVertexShader100 : SlangShaderResources.IShader
    {
        public string Name => "TestVS";
        public bool VerboseLog { get; set; } = false;

        public int id => 100;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
        public bool compileToFile { get; } = true;
        public bool IsDisposed { get; private set; }

        SlangShaderResources.ShaderOrigin SlangShaderResources.IShader.Origin => SlangShaderResources.ShaderOrigin.Dx11;

        public string Code => @"struct VSInput
{
    float3 Position : POSITION;
    float4 Color    : COLOR;
};

struct VSOutput
{
    float4 Position : SV_POSITION;
    float4 Color    : COLOR;
};

VSOutput main(VSInput input)
{
    VSOutput output;
    output.Position = float4(input.Position, 1.0f);
    output.Color = input.Color;
    return output;
}
";

        public byte[] byteCode => null;

        public void Bind() { /* binding is handled by IDX11GraphicsContext.SetShader */ }

        public string OutputDebugInfo(bool log = true)
        {
            string info = $"{{'Name':'{Name}','Type':'{Type}'}}";
            if (log) Logger.LogDebug(info, LoggingTarget.Graphics);
            return info;
        }

        public void Dispose() => IsDisposed = true;
    }
}
