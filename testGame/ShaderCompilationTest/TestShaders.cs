using Angene.Common;
using Angene.Graphics;
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
        public int id => 1;
        public string Extension => "hlsl";
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Vertex;
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
        public int id => 2;
        public string Extension => "hlsl";
        public string Path { get; set; } = System.IO.Path.Combine(AppContext.BaseDirectory, "Shaders", "PixelShader.hlsl");
        public string EntryPoint { get; set; } = "main";
        public SlangShaderResources.ShaderType Type => SlangShaderResources.ShaderType.Pixel;
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
}
