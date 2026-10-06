using System;
using Angene.Common;
using Angene.Graphics.SlangShader;
using static Angene.Common.Attributes;
using static Angene.Essentials.GraphicsContexts.SlangShaderResources;   // Required for NativeSlangMemoryCompiler

namespace Game
{
    public class Shaders
    {
        [Precompile]
        public class VertexShader : IShader
        {
            public string Name => "VertexShader";
            public bool verboseLog { get; set; } = true;

            public int id => 5;
            public string Extension => "hlsl";
            public string EntryPoint { get; set; } = "vertexMain";
            public ShaderType Type => ShaderType.Vertex;
            public bool compileToFile { get; } = false;
            public bool IsDisposed { get; private set; }

            ShaderOrigin IShader.Origin => ShaderOrigin.Vulkan;
            public ShaderQueue Queue => ShaderQueue.Geometry;
            
            public string code => @"struct PushData
{
    row_major float4x4 view;
    row_major float4x4 proj;
};

[[vk::push_constant]] ConstantBuffer<PushData> pc;

struct VSInput
{
    float3 position : POSITION;
    float4 color : COLOR;
};
struct VSOutput
{
    float4 position : SV_Position;
    float4 color : COLOR;
};
VSOutput vertexMain(VSInput input)
{
    VSOutput output;
    float4 viewPos = mul(pc.view, float4(input.position, 1.0));
    output.position = mul(pc.proj, viewPos);
    output.color = input.color;
    return output;
}";
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

        [Precompile]
        public class FragmentShader : IShader
        {
            public string Name => "FragmentShader";
            public bool verboseLog { get; set; } = true;

            public int id => 2;
            public string Extension => "hlsl";
            public string EntryPoint { get; set; } = "fragmentMain";
            public ShaderType Type => ShaderType.Fragment;
            public bool compileToFile { get; } = false;
            public bool IsDisposed { get; private set; }

            ShaderOrigin IShader.Origin => ShaderOrigin.Vulkan;
            public ShaderQueue Queue => ShaderQueue.Geometry;
            public string code => @"struct VertexOutput {
    float4 position : SV_Position;
    float4 color : COLOR;
};
float4 fragmentMain(VertexOutput input) : SV_Target {
    return input.color;
}";
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
}
