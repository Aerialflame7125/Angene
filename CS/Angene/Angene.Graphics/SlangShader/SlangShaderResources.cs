using Angene.Common;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
using static Angene.Graphics.SlangShader.SlangShaderResources;

namespace Angene.Graphics.SlangShader
{
    public class SlangShaderResources
    {
        public enum ShaderType { Vertex, Pixel, Compute, }
        public enum ShaderOrigin { Dx11, Dx12, OpenGL, Vulkan }

        public abstract class BaseShader : IDisposable // Shader layout for future shaders
        {
            public string Name { get; }
            public bool IsDisposed { get; private set; }
            public bool VerboseLog { get; set; } = false;
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
            int id { get; }
            /// <summary>
            /// File extension (e.g: 'hlsl')
            /// </summary>
            string Extension { get; }
            string Name { get; }
            string EntryPoint { get; }
            bool VerboseLog { get; set; }
            string Code { get; }
            byte[] byteCode { get; }
            ShaderOrigin Origin { get; }
            ShaderType Type { get; }
            bool compileToFile { get; }
            bool IsDisposed { get; }
            void Bind();
            string OutputDebugInfo(bool log = true);
        }

    }
    public class Dx11Shader : BaseShader, IShader
    {
        private readonly object _nativeComShader;
        protected IntPtr _ID3D11DeviceContext;
        protected IntPtr _nativeShaderPtr;

        public int id { get; }
        public bool compileToFile { get; }
        public bool VerboseLog { get; set; } = false;
        public IntPtr NativeShader => _nativeShaderPtr;
        public static ShaderOrigin Origin => ShaderOrigin.Dx11;

        public string Code { get; }
        /// <summary>
        /// File extension (e.g: 'hlsl')
        /// </summary>
        public string Extension { get; }
        public string EntryPoint { get; }
        public byte[] byteCode { get; }

        public Dx11Shader(string name, ShaderType type, object slangReflectionData, object nativeComShader, 
            IntPtr deviceContext, IntPtr nativeShaderPtr, int id,
            byte[] byteCode = null, string code = null)
            : base(name, type, slangReflectionData)
        {
            this.byteCode = byteCode;
            Code = code;
            _nativeComShader = nativeComShader;
            _ID3D11DeviceContext = deviceContext;
            _nativeShaderPtr = nativeShaderPtr;
            this.id = id;
        }

        public override void Bind()
        {
            // dx11 context using _nativeComShader
        }

        protected override void DestroyNativeShader()
        {
            if (_nativeComShader != null && Marshal.IsComObject(_nativeComShader))
                Marshal.ReleaseComObject(_nativeComShader);

            if (_nativeShaderPtr != IntPtr.Zero)
            {
                Marshal.Release(_nativeShaderPtr);
                _nativeShaderPtr = IntPtr.Zero;
            }
        }
    }
    public class VkShader : BaseShader, IShader
    {
        protected IntPtr _nativeShaderModule;
        public int id { get; }
        public bool compileToFile { get; }
        public bool VerboseLog { get; set; } = false;
        public IntPtr NativeShaderModule => _nativeShaderModule;
        public static ShaderOrigin Origin => ShaderOrigin.Vulkan;

        public string Code { get; }
        public string Extension => "spv";
        public string EntryPoint { get; }
        public byte[] byteCode { get; }

        public VkShader(string name, ShaderType type, object slangReflectionData, IntPtr nativeShaderModule, int id,
            byte[] byteCode = null, string code = null)
            : base(name, type, slangReflectionData)
        {
            this.byteCode = byteCode;
            Code = code;
            _nativeShaderModule = nativeShaderModule;
            this.id = id;
        }

        public override void Bind() { /* handled via pipeline bind, not per-shader */ }

        protected override void DestroyNativeShader()
        {
            // needs the owning VkDevice handle to call vkDestroyShaderModule -
            // store it in the constructor if VkShader needs to self destruct,
            // or have the graphics context own destruction via its resource tracking dictionaries.
        }
    }
}
