using System;
using Angene.Common;
using Angene.Graphics.SlangShader;
using static Angene.Common.Attributes;
using static Angene.Graphics.SlangShader.SlangShaderResources;   // Required for NativeSlangMemoryCompiler

namespace Game
{
    public class Shaders
    {
        // Use the custom attribute to specify Vulkan as the target environment
        [Precompile]
        public class VertexShader : IShader
        {
            public string Name => "VertexShader";
            public bool VerboseLog { get; set; } = false;

            public int id => 1;
            public string Extension => "hlsl";
            public string EntryPoint { get; set; } = "vertexMain";
            public ShaderType Type => ShaderType.Vertex;
            public bool compileToFile { get; } = true;
            public bool IsDisposed { get; private set; }

            ShaderOrigin IShader.Origin => ShaderOrigin.Vulkan;

            public string Code => @"
            struct VertexOutput {
                float4 position : SV_Position;
                float3 color : COLOR;
            };

            VertexOutput vertexMain(uint vertexId : SV_VertexID) {
                VertexOutput output;
                float2 positions[3] = { 
                    float2(0.0, -0.5), 
                    float2(0.5, 0.5), 
                    float2(-0.5, 0.5) 
                };
                float3 colors[3] = { 
                    float3(1.0, 0.0, 0.0), 
                    float3(0.0, 1.0, 0.0), 
                    float3(0.0, 0.0, 1.0) 
                };

                output.position = float4(positions[vertexId], 0.0, 1.0);
                output.color = colors[vertexId];
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

        [Precompile]
        public class FragmentShader : IShader
        {
            public string Name => "FragmentShader";
            public bool VerboseLog { get; set; } = false;

            public int id => 2;
            public string Extension => "hlsl";
            public string EntryPoint { get; set; } = "fragmentMain";
            public ShaderType Type => ShaderType.Fragment;
            public bool compileToFile { get; } = true;
            public bool IsDisposed { get; private set; }

            ShaderOrigin IShader.Origin => ShaderOrigin.Vulkan;

            public string Code => @"
            struct VertexOutput {
                float4 position : SV_Position;
                float3 color : COLOR;
            };

            float4 fragmentMain(VertexOutput input) : SV_Target {
                return float4(input.color, 1.0);
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
}