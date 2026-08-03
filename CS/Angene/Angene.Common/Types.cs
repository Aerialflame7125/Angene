namespace Angene.Common
{
    public class Types
    {
        public enum TShaderType : int
        {
            Vertex = 1,
            Hull = 2,
            Domain = 3,
            Geometry = 4,
            Pixel = 5
        }

        public class TShaderMetadata
        {
            public int Id;
            public string ShaderName;
            public TShaderType ShaderType;
            public string Source;
            public float ShaderRate; // Can be used for optimization
            public float Shade; // Black - White, 1.0f is Black.
            public bool CacheOnDevice;

            public TShaderMetadata(int id, string shaderName = "NewAngeneShader", TShaderType shaderType = TShaderType.Vertex, float shaderRate = 1.0f, float shade = 1.0f, string source = null, bool cacheOnDevice = true)
            {
                Id = id;
                ShaderName = shaderName;
                ShaderType = shaderType;
                ShaderRate = shaderRate;
                Shade = shade;
                Source = source;
                CacheOnDevice = cacheOnDevice;
            }
        }

        public class TShader
        {
            public TShader(TShaderMetadata metadata)
            {
                TShaderMetadata _metadata = metadata;

                // Placeholder.
            }
        }

        public class AppInfo
        {
            public string AppName;
            public float AppVersion;
            public string Author;
            public string Developer;

            public AppInfo(string appName, float appVersion, string author, string developer)
            {
                AppName = appName;
                AppVersion = appVersion;
                Author = author;
                Developer = developer;
            }
        }
    }
}
