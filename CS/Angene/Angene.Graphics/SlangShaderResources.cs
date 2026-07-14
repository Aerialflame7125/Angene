using Angene.Common;
using System.Runtime.InteropServices;

namespace Angene.Graphics
{
    public class SlangShaderResources
    {
        public enum ShaderType { Vertex, Pixel, Compute, }
        public enum ShaderOrigin { Dx11, Dx12, OpenGL }

        public abstract class BaseShader : IDisposable // Shader layout for future shaders
        {
            public string Name { get; }
            public bool IsDisposed { get; private set; }
            public ShaderType Type { get; }

            public ShaderOrigin Origin { get; }
            protected object SlangReflectionData { get; }

            protected BaseShader(string name, ShaderType type, object slangReflectionData)
            {
                Name = name;
                Type = type;
                SlangReflectionData = slangReflectionData;
            }

            public string OutputDebugInfo(bool log = true)
            {
                if (log)
                    Logger.LogDebug($"ShaderInfo: Name = {Name}, Type = {Type}, IsDisposed = {IsDisposed}", LoggingTarget.Graphics);
                return $"{{'Name':'{Name}','Type':'{Type}','IsDisposed':'{IsDisposed}'}}";
            }

            public abstract void Bind();

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected abstract void DestroyNativeShader();

            protected virtual void Dispose(bool disposing)
            {
                if (!IsDisposed)
                {
                    if (disposing)
                    {
                        // clean managed reflection data
                    }

                    DestroyNativeShader();

                    IsDisposed = true;
                }
            }

            ~BaseShader() => Dispose(false);
        }

        public interface IShader : IDisposable
        {
            string Name { get; }
            ShaderType Type { get; }
            bool IsDisposed { get; }
            void Bind();
            string OutputDebugInfo(bool log = true);
        }
    
    
        public abstract class Dx11Shader : BaseShader
        {
            private readonly object _nativeComShader;
            protected IntPtr _ID3D11DeviceContext;
            protected IntPtr _ID3D11VertexShader;
            protected IntPtr _ID3D11PixelShader;

            public ShaderOrigin Origin => ShaderOrigin.Dx11;
            
            public Dx11Shader(string name, ShaderType type, object slangReflectionData, object nativeComShader, IntPtr DeviceContext, IntPtr VertexShader, IntPtr PixelShader) : base(name, type, slangReflectionData)
            {
                _nativeComShader = nativeComShader;
                _ID3D11DeviceContext = DeviceContext;
                _ID3D11PixelShader = PixelShader;
                _ID3D11VertexShader = VertexShader;
            }

            public override void Bind()
            {
                // dx11 context using _nativeComShader
                
            }

            protected override void DestroyNativeShader()
            {
                if (_nativeComShader != null && System.Runtime.InteropServices.Marshal.IsComObject(_nativeComShader))
                {
                    Marshal.ReleaseComObject(_nativeComShader);
                }
            }
        }
    }
}
