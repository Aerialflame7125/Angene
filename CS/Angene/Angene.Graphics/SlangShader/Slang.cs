using Angene.Windows.Slang;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Angene.Windows.Slang.LayoutRules;
using static Angene.Windows.Slang.Methods;
using static Angene.Windows.Slang.SlangBindingType;
using static Angene.Windows.Slang.SlangDeclKind;
using static Angene.Windows.Slang.SlangLayoutRules;
using static Angene.Windows.Slang.SlangModifierID;
using static Angene.Windows.Slang.SlangParameterCategory;
using static Angene.Windows.Slang.SlangParameterCategory;
using static Angene.Windows.Slang.SlangScalarType;
using static Angene.Windows.Slang.SlangTypeKind;
using static Angene.Windows.Slang.SpecializationArg.Kind;
using static Angene.Windows.Slang.TypeReflection.Kind;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Angene.Windows.Slang; // Slang "slang-2026.14.1"

public enum SlangSeverity
{
    SLANG_SEVERITY_DISABLED = 0,
    SLANG_SEVERITY_NOTE = 1,
    SLANG_SEVERITY_WARNING = 2,
    SLANG_SEVERITY_ERROR = 3,
    SLANG_SEVERITY_FATAL = 4,
    SLANG_SEVERITY_INTERNAL = 5,
}

public enum SlangBindableResourceType
{
    SLANG_NON_BINDABLE = 0,
    SLANG_TEXTURE = 1,
    SLANG_SAMPLER = 2,
    SLANG_UNIFORM_BUFFER = 3,
    SLANG_STORAGE_BUFFER = 4,
}

public enum SlangCompileTarget
{
    SLANG_TARGET_UNKNOWN = 0,
    SLANG_TARGET_NONE = 1,
    SLANG_GLSL = 2,
    SLANG_GLSL_VULKAN_DEPRECATED = 3,
    SLANG_GLSL_VULKAN_ONE_DESC_DEPRECATED = 4,
    SLANG_HLSL = 5,
    SLANG_SPIRV = 6,
    SLANG_SPIRV_ASM = 7,
    SLANG_DXBC = 8,
    SLANG_DXBC_ASM = 9,
    SLANG_DXIL = 10,
    SLANG_DXIL_ASM = 11,
    SLANG_C_SOURCE = 12,
    SLANG_CPP_SOURCE = 13,
    SLANG_HOST_EXECUTABLE = 14,
    SLANG_SHADER_SHARED_LIBRARY = 15,
    SLANG_SHADER_HOST_CALLABLE = 16,
    SLANG_CUDA_SOURCE = 17,
    SLANG_PTX = 18,
    SLANG_CUDA_OBJECT_CODE = 19,
    SLANG_OBJECT_CODE = 20,
    SLANG_HOST_CPP_SOURCE = 21,
    SLANG_HOST_HOST_CALLABLE = 22,
    SLANG_CPP_PYTORCH_BINDING = 23,
    SLANG_METAL = 24,
    SLANG_METAL_LIB = 25,
    SLANG_METAL_LIB_ASM = 26,
    SLANG_HOST_SHARED_LIBRARY = 27,
    SLANG_WGSL = 28,
    SLANG_WGSL_SPIRV_ASM = 29,
    SLANG_WGSL_SPIRV = 30,
    SLANG_HOST_VM = 31,
    SLANG_CPP_HEADER = 32,
    SLANG_CUDA_HEADER = 33,
    SLANG_HOST_OBJECT_CODE = 34,
    SLANG_HOST_LLVM_IR = 35,
    SLANG_SHADER_LLVM_IR = 36,
    SLANG_TARGET_COUNT_OF,
}

public enum SlangContainerFormat
{
    SLANG_CONTAINER_FORMAT_NONE = 0,
    SLANG_CONTAINER_FORMAT_SLANG_MODULE = 1,
}

public enum SlangPassThrough
{
    SLANG_PASS_THROUGH_NONE = 0,
    SLANG_PASS_THROUGH_FXC = 1,
    SLANG_PASS_THROUGH_DXC = 2,
    SLANG_PASS_THROUGH_GLSLANG = 3,
    SLANG_PASS_THROUGH_SPIRV_DIS = 4,
    SLANG_PASS_THROUGH_CLANG = 5,
    SLANG_PASS_THROUGH_VISUAL_STUDIO = 6,
    SLANG_PASS_THROUGH_GCC = 7,
    SLANG_PASS_THROUGH_GENERIC_C_CPP = 8,
    SLANG_PASS_THROUGH_NVRTC = 9,
    SLANG_PASS_THROUGH_LLVM = 10,
    SLANG_PASS_THROUGH_SPIRV_OPT = 11,
    SLANG_PASS_THROUGH_METAL = 12,
    SLANG_PASS_THROUGH_TINT = 13,
    SLANG_PASS_THROUGH_SPIRV_LINK = 14,
    SLANG_PASS_THROUGH_COUNT_OF,
}

public enum SlangArchiveType
{
    SLANG_ARCHIVE_TYPE_UNDEFINED = 0,
    SLANG_ARCHIVE_TYPE_ZIP = 1,
    SLANG_ARCHIVE_TYPE_RIFF = 2,
    SLANG_ARCHIVE_TYPE_RIFF_DEFLATE = 3,
    SLANG_ARCHIVE_TYPE_RIFF_LZ4 = 4,
    SLANG_ARCHIVE_TYPE_COUNT_OF,
}

public enum SlangFloatingPointMode : uint
{
    SLANG_FLOATING_POINT_MODE_DEFAULT = 0,
    SLANG_FLOATING_POINT_MODE_FAST = 1,
    SLANG_FLOATING_POINT_MODE_PRECISE = 2,
}

public enum SlangFpDenormalMode : uint
{
    SLANG_FP_DENORM_MODE_ANY = 0,
    SLANG_FP_DENORM_MODE_PRESERVE = 1,
    SLANG_FP_DENORM_MODE_FTZ = 2,
}

public enum SlangLineDirectiveMode : uint
{
    SLANG_LINE_DIRECTIVE_MODE_DEFAULT = 0,
    SLANG_LINE_DIRECTIVE_MODE_NONE = 1,
    SLANG_LINE_DIRECTIVE_MODE_STANDARD = 2,
    SLANG_LINE_DIRECTIVE_MODE_GLSL = 3,
    SLANG_LINE_DIRECTIVE_MODE_SOURCE_MAP = 4,
}

public enum SlangSourceLanguage
{
    SLANG_SOURCE_LANGUAGE_UNKNOWN = 0,
    SLANG_SOURCE_LANGUAGE_SLANG = 1,
    SLANG_SOURCE_LANGUAGE_HLSL = 2,
    SLANG_SOURCE_LANGUAGE_GLSL = 3,
    SLANG_SOURCE_LANGUAGE_C = 4,
    SLANG_SOURCE_LANGUAGE_CPP = 5,
    SLANG_SOURCE_LANGUAGE_CUDA = 6,
    SLANG_SOURCE_LANGUAGE_SPIRV = 7,
    SLANG_SOURCE_LANGUAGE_METAL = 8,
    SLANG_SOURCE_LANGUAGE_WGSL = 9,
    SLANG_SOURCE_LANGUAGE_LLVM = 10,
    SLANG_SOURCE_LANGUAGE_COUNT_OF,
}

public enum SlangProfileID : uint
{
    SLANG_PROFILE_UNKNOWN = 0,
}

public enum SlangCapabilityID
{
    SLANG_CAPABILITY_UNKNOWN = 0,
}

public enum SlangMatrixLayoutMode : uint
{
    SLANG_MATRIX_LAYOUT_MODE_UNKNOWN = 0,
    SLANG_MATRIX_LAYOUT_ROW_MAJOR = 1,
    SLANG_MATRIX_LAYOUT_COLUMN_MAJOR = 2,
}

public enum SlangStage : uint
{
    SLANG_STAGE_NONE = 0,
    SLANG_STAGE_VERTEX = 1,
    SLANG_STAGE_HULL = 2,
    SLANG_STAGE_DOMAIN = 3,
    SLANG_STAGE_GEOMETRY = 4,
    SLANG_STAGE_FRAGMENT = 5,
    SLANG_STAGE_COMPUTE = 6,
    SLANG_STAGE_RAY_GENERATION = 7,
    SLANG_STAGE_INTERSECTION = 8,
    SLANG_STAGE_ANY_HIT = 9,
    SLANG_STAGE_CLOSEST_HIT = 10,
    SLANG_STAGE_MISS = 11,
    SLANG_STAGE_CALLABLE = 12,
    SLANG_STAGE_MESH = 13,
    SLANG_STAGE_AMPLIFICATION = 14,
    SLANG_STAGE_DISPATCH = 15,
    SLANG_STAGE_COUNT,
    SLANG_STAGE_PIXEL = SLANG_STAGE_FRAGMENT,
}

public enum SlangScope : uint
{
    SLANG_SCOPE_NONE,
    SLANG_SCOPE_THREAD,
    SLANG_SCOPE_WAVE,
    SLANG_SCOPE_THREAD_GROUP,
}

public enum SlangCooperativeMatrixUse : uint
{
    SLANG_COOPERATIVE_MATRIX_USE_A = 0,
    SLANG_COOPERATIVE_MATRIX_USE_B = 1,
    SLANG_COOPERATIVE_MATRIX_USE_ACCUMULATOR = 2,
}

public enum SlangCooperativeVectorMatrixLayout : uint
{
    SLANG_COOPERATIVE_VECTOR_MATRIX_LAYOUT_ROW_MAJOR = 0,
    SLANG_COOPERATIVE_VECTOR_MATRIX_LAYOUT_COLUMN_MAJOR = 1,
    SLANG_COOPERATIVE_VECTOR_MATRIX_LAYOUT_INFERENCING_OPTIMAL = 2,
    SLANG_COOPERATIVE_VECTOR_MATRIX_LAYOUT_TRAINING_OPTIMAL = 3,
}

public enum SlangDebugInfoLevel : uint
{
    SLANG_DEBUG_INFO_LEVEL_NONE = 0,
    SLANG_DEBUG_INFO_LEVEL_MINIMAL = 1,
    SLANG_DEBUG_INFO_LEVEL_STANDARD = 2,
    SLANG_DEBUG_INFO_LEVEL_MAXIMAL = 3,
}

public enum SlangDebugInfoFormat : uint
{
    SLANG_DEBUG_INFO_FORMAT_DEFAULT = 0,
    SLANG_DEBUG_INFO_FORMAT_C7 = 1,
    SLANG_DEBUG_INFO_FORMAT_PDB = 2,
    SLANG_DEBUG_INFO_FORMAT_STABS = 3,
    SLANG_DEBUG_INFO_FORMAT_COFF = 4,
    SLANG_DEBUG_INFO_FORMAT_DWARF = 5,
    SLANG_DEBUG_INFO_FORMAT_COUNT_OF,
}

public enum SlangOptimizationLevel : uint
{
    SLANG_OPTIMIZATION_LEVEL_NONE = 0,
    SLANG_OPTIMIZATION_LEVEL_DEFAULT = 1,
    SLANG_OPTIMIZATION_LEVEL_HIGH = 2,
    SLANG_OPTIMIZATION_LEVEL_MAXIMAL = 3,
}

public enum SlangEmitSpirvMethod
{
    SLANG_EMIT_SPIRV_DEFAULT = 0,
    SLANG_EMIT_SPIRV_VIA_GLSL = 1,
    SLANG_EMIT_SPIRV_DIRECTLY = 2,
}

public enum SlangEmitCPUMethod
{
    SLANG_EMIT_CPU_DEFAULT = 0,
    SLANG_EMIT_CPU_VIA_CPP = 1,
    SLANG_EMIT_CPU_VIA_LLVM = 2,
}

public enum SlangDiagnosticColor
{
    SLANG_DIAGNOSTIC_COLOR_AUTO = 0,
    SLANG_DIAGNOSTIC_COLOR_ALWAYS = 1,
    SLANG_DIAGNOSTIC_COLOR_NEVER = 2,
}

public enum CompilerOptionName
{
    MacroDefine = 0,
    DepFile = 1,
    EntryPointName = 2,
    Specialize = 3,
    Help = 4,
    HelpStyle = 5,
    Include = 6,
    Language = 7,
    MatrixLayoutColumn = 8,
    MatrixLayoutRow = 9,
    ZeroInitialize = 10,
    IgnoreCapabilities = 11,
    RestrictiveCapabilityCheck = 12,
    ModuleName = 13,
    Output = 14,
    Profile = 15,
    Stage = 16,
    Target = 17,
    Version = 18,
    WarningsAsErrors = 19,
    DisableWarnings = 20,
    EnableWarning = 21,
    DisableWarning = 22,
    DumpWarningDiagnostics = 23,
    InputFilesRemain = 24,
    EmitIr = 25,
    ReportDownstreamTime = 26,
    ReportPerfBenchmark = 27,
    ReportCheckpointIntermediates = 28,
    SkipSPIRVValidation = 29,
    SourceEmbedStyle = 30,
    SourceEmbedName = 31,
    SourceEmbedLanguage = 32,
    DisableShortCircuit = 33,
    MinimumSlangOptimization = 34,
    DisableNonEssentialValidations = 35,
    DisableSourceMap = 36,
    UnscopedEnum = 37,
    PreserveParameters = 38,
    Capability = 39,
    DefaultImageFormatUnknown = 40,
    DisableDynamicDispatch = 41,
    DisableSpecialization = 42,
    FloatingPointMode = 43,
    DebugInformation = 44,
    LineDirectiveMode = 45,
    Optimization = 46,
    Obfuscate = 47,
    VulkanBindShift = 48,
    VulkanBindGlobals = 49,
    VulkanInvertY = 50,
    VulkanUseDxPositionW = 51,
    VulkanUseEntryPointName = 52,
    VulkanUseGLLayout = 53,
    VulkanEmitReflection = 54,
    GLSLForceScalarLayout = 55,
    EnableEffectAnnotations = 56,
    EmitSpirvViaGLSL = 57,
    EmitSpirvDirectly = 58,
    SPIRVCoreGrammarJSON = 59,
    IncompleteLibrary = 60,
    CompilerPath = 61,
    DefaultDownstreamCompiler = 62,
    DownstreamArgs = 63,
    PassThrough = 64,
    DumpRepro = 65,
    DumpReproOnError = 66,
    ExtractRepro = 67,
    LoadRepro = 68,
    LoadReproDirectory = 69,
    ReproFallbackDirectory = 70,
    DumpAst = 71,
    DumpIntermediatePrefix = 72,
    DumpIntermediates = 73,
    DumpIr = 74,
    DumpIrIds = 75,
    PreprocessorOutput = 76,
    OutputIncludes = 77,
    ReproFileSystem = 78,
    REMOVED_SerialIR = 79,
    SkipCodeGen = 80,
    ValidateIr = 81,
    VerbosePaths = 82,
    VerifyDebugSerialIr = 83,
    NoCodeGen = 84,
    FileSystem = 85,
    Heterogeneous = 86,
    NoMangle = 87,
    NoHLSLBinding = 88,
    NoHLSLPackConstantBufferElements = 89,
    ValidateUniformity = 90,
    AllowGLSL = 91,
    EnableExperimentalPasses = 92,
    BindlessSpaceIndex = 93,
    SPIRVResourceHeapStride = 94,
    SPIRVSamplerHeapStride = 95,
    ArchiveType = 96,
    CompileCoreModule = 97,
    Doc = 98,
    IrCompression = 99,
    LoadCoreModule = 100,
    ReferenceModule = 101,
    SaveCoreModule = 102,
    SaveCoreModuleBinSource = 103,
    TrackLiveness = 104,
    LoopInversion = 105,
    ParameterBlocksUseRegisterSpaces = 106,
    LanguageVersion = 107,
    TypeConformance = 108,
    EnableExperimentalDynamicDispatch = 109,
    EmitReflectionJSON = 110,
    CountOfParsableOptions = 111,
    DebugInformationFormat = 112,
    VulkanBindShiftAll = 113,
    GenerateWholeProgram = 114,
    UseUpToDateBinaryModule = 115,
    EmbedDownstreamIR = 116,
    ForceDXLayout = 117,
    EmitSpirvMethod = 118,
    SaveGLSLModuleBinSource = 119,
    SkipDownstreamLinking = 120,
    DumpModule = 121,
    GetModuleInfo = 122,
    GetSupportedModuleVersions = 123,
    EmitSeparateDebug = 124,
    DenormalModeFp16 = 125,
    DenormalModeFp32 = 126,
    DenormalModeFp64 = 127,
    UseMSVCStyleBitfieldPacking = 128,
    ForceCLayout = 129,
    ExperimentalFeature = 130,
    ReportDetailedPerfBenchmark = 131,
    ValidateIRDetailed = 132,
    DumpIRBefore = 133,
    DumpIRAfter = 134,
    EmitCPUMethod = 135,
    EmitCPUViaCPP = 136,
    EmitCPUViaLLVM = 137,
    LLVMTargetTriple = 138,
    LLVMCPU = 139,
    LLVMFeatures = 140,
    EnableRichDiagnostics = 141,
    ReportDynamicDispatchSites = 142,
    EnableMachineReadableDiagnostics = 143,
    DiagnosticColor = 144,
    TraceCoverage = 145,
    TraceCoverageBinding = 146,
    TraceCoverageReservedSpace = 147,
    TraceFunctionCoverage = 148,
    TraceBranchCoverage = 149,
    CoverageManifestOutput = 150,
    TraceCoverageCounterByteWidth = 151,
    TraceCoverageBoolean = 152,
    CountOf,
}

public enum CompilerOptionValueKind
{
    Int = 0,
    String = 1,
}

public unsafe partial struct CompilerOptionValue
{
    public CompilerOptionValueKind kind;

    public int intValue0;

    public int intValue1;

    public sbyte* stringValue0;

    public sbyte* stringValue1;
}

public partial struct CompilerOptionEntry
{
    public CompilerOptionName name;

    public CompilerOptionValue value;
}

public partial struct SlangUUID
{
    public uint data1;

    public ushort data2;

    public ushort data3;

    public _data4_e__FixedBuffer data4;

    [InlineArray(8)]
    public partial struct _data4_e__FixedBuffer
    {
        public byte e0;
    }
}

public unsafe partial struct ISlangUnknown
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangUnknown*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangUnknown*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangUnknown*, uint>)(lpVtbl[1]))((ISlangUnknown*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangUnknown*, uint>)(lpVtbl[2]))((ISlangUnknown*)Unsafe.AsPointer(ref this));
    }
}

public unsafe partial struct ISlangCastable
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangCastable*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangCastable*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangCastable*, uint>)(lpVtbl[1]))((ISlangCastable*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangCastable*, uint>)(lpVtbl[2]))((ISlangCastable*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangCastable*, SlangUUID*, void*>)(lpVtbl[3]))((ISlangCastable*)Unsafe.AsPointer(ref this), guid);
    }
}

public unsafe partial struct ISlangClonable
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangClonable*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangClonable*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangClonable*, uint>)(lpVtbl[1]))((ISlangClonable*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangClonable*, uint>)(lpVtbl[2]))((ISlangClonable*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangClonable*, SlangUUID*, void*>)(lpVtbl[3]))((ISlangClonable*)Unsafe.AsPointer(ref this), guid);
    }

    public void* clone(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangClonable*, SlangUUID*, void*>)(lpVtbl[4]))((ISlangClonable*)Unsafe.AsPointer(ref this), guid);
    }
}

public unsafe partial struct ISlangBlob
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangBlob*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangBlob*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangBlob*, uint>)(lpVtbl[1]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangBlob*, uint>)(lpVtbl[2]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    public void* getBufferPointer()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangBlob*, void*>)(lpVtbl[3]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    public nuint getBufferSize()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangBlob*, nuint>)(lpVtbl[4]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }
}

public unsafe partial struct SlangTerminatedChars
{
    public _chars_e__FixedBuffer chars;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xa7;
        res.data4[1] = 0x8b;
        res.data4[2] = 0xc4;
        res.data4[3] = 0x86;
        res.data4[4] = 0x84;
        res.data4[5] = 0x30;
        res.data4[6] = 0xdf;
        res.data4[7] = 0xbb;
        return res;
    }

    public readonly sbyte* ToSBytePointer()
    {
        return (sbyte*)Unsafe.AsPointer(ref Unsafe.AsRef(in chars.e0));
    }

    public partial struct _chars_e__FixedBuffer
    {
        public sbyte e0;

        public ref sbyte this[int index] { get { return ref Unsafe.Add(ref e0, index); } }

        public Span<sbyte> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
    }
}

public unsafe partial struct ISlangFileSystem
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystem*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangFileSystem*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystem*, uint>)(lpVtbl[1]))((ISlangFileSystem*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystem*, uint>)(lpVtbl[2]))((ISlangFileSystem*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystem*, SlangUUID*, void*>)(lpVtbl[3]))((ISlangFileSystem*)Unsafe.AsPointer(ref this), guid);
    }

    public int loadFile(sbyte* path, ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystem*, sbyte*, ISlangBlob**, int>)(lpVtbl[4]))((ISlangFileSystem*)Unsafe.AsPointer(ref this), path, outBlob);
    }
}

public unsafe partial struct ISlangSharedLibrary_Dep1
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, uint>)(lpVtbl[1]))((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, uint>)(lpVtbl[2]))((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this));
    }

    public void* findSymbolAddressByName(sbyte* name)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, sbyte*, void*>)(lpVtbl[3]))((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this), name);
    }
}

public unsafe partial struct ISlangSharedLibrary
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public delegate* unmanaged[Thiscall]<ISlangSharedLibrary*, void> findFuncByName(sbyte* name)
    {
        return (delegate* unmanaged[Thiscall]<ISlangSharedLibrary*, void>)(delegate* unmanaged[Thiscall]<void>)(findSymbolAddressByName(name));
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangSharedLibrary*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary*, uint>)(lpVtbl[1]))((ISlangSharedLibrary*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary*, uint>)(lpVtbl[2]))((ISlangSharedLibrary*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary*, SlangUUID*, void*>)(lpVtbl[3]))((ISlangSharedLibrary*)Unsafe.AsPointer(ref this), guid);
    }

    public void* findSymbolAddressByName(sbyte* name)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary*, sbyte*, void*>)(lpVtbl[4]))((ISlangSharedLibrary*)Unsafe.AsPointer(ref this), name);
    }
}

public unsafe partial struct ISlangSharedLibraryLoader
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangSharedLibraryLoader*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, uint>)(lpVtbl[1]))((ISlangSharedLibraryLoader*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, uint>)(lpVtbl[2]))((ISlangSharedLibraryLoader*)Unsafe.AsPointer(ref this));
    }

    public int loadSharedLibrary(sbyte* path, ISlangSharedLibrary** sharedLibraryOut)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, sbyte*, ISlangSharedLibrary**, int>)(lpVtbl[3]))((ISlangSharedLibraryLoader*)Unsafe.AsPointer(ref this), path, sharedLibraryOut);
    }
}

public enum SlangPathType : uint
{
    SLANG_PATH_TYPE_DIRECTORY = 0,
    SLANG_PATH_TYPE_FILE = 1,
}

public enum OSPathKind : byte
{
    None = 0,
    Direct = 1,
    OperatingSystem = 2,
}

public enum PathKind
{
    Simplified = 0,
    Canonical = 1,
    Display = 2,
    OperatingSystem = 3,
    CountOf,
}

public unsafe partial struct ISlangFileSystemExt
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, uint>)(lpVtbl[1]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, uint>)(lpVtbl[2]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, SlangUUID*, void*>)(lpVtbl[3]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), guid);
    }

    public int loadFile(sbyte* path, ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, sbyte*, ISlangBlob**, int>)(lpVtbl[4]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, outBlob);
    }

    public int getFileUniqueIdentity(sbyte* path, ISlangBlob** outUniqueIdentity)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, sbyte*, ISlangBlob**, int>)(lpVtbl[5]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, outUniqueIdentity);
    }

    public int calcCombinedPath(SlangPathType fromPathType, sbyte* fromPath, sbyte* path, ISlangBlob** pathOut)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, SlangPathType, sbyte*, sbyte*, ISlangBlob**, int>)(lpVtbl[6]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), fromPathType, fromPath, path, pathOut);
    }

    public int getPathType(sbyte* path, SlangPathType* pathTypeOut)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, sbyte*, SlangPathType*, int>)(lpVtbl[7]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, pathTypeOut);
    }

    public int getPath(PathKind kind, sbyte* path, ISlangBlob** outPath)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, PathKind, sbyte*, ISlangBlob**, int>)(lpVtbl[8]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), kind, path, outPath);
    }

    public void clearCache()
    {
        ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, void>)(lpVtbl[9]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }

    public int enumeratePathContents(sbyte* path, delegate* unmanaged[Thiscall]<SlangPathType, sbyte*, void*, void> callback, void* userData)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, sbyte*, delegate* unmanaged[Thiscall]<SlangPathType, sbyte*, void*, void>, void*, int>)(lpVtbl[10]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, callback, userData);
    }

    public OSPathKind getOSPathKind()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, OSPathKind>)(lpVtbl[11]))((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }
}

public unsafe partial struct ISlangMutableFileSystem
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, uint>)(lpVtbl[1]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, uint>)(lpVtbl[2]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, SlangUUID*, void*>)(lpVtbl[3]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), guid);
    }

    public int loadFile(sbyte* path, ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, ISlangBlob**, int>)(lpVtbl[4]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, outBlob);
    }

    public int getFileUniqueIdentity(sbyte* path, ISlangBlob** outUniqueIdentity)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, ISlangBlob**, int>)(lpVtbl[5]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, outUniqueIdentity);
    }

    public int calcCombinedPath(SlangPathType fromPathType, sbyte* fromPath, sbyte* path, ISlangBlob** pathOut)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, SlangPathType, sbyte*, sbyte*, ISlangBlob**, int>)(lpVtbl[6]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), fromPathType, fromPath, path, pathOut);
    }

    public int getPathType(sbyte* path, SlangPathType* pathTypeOut)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, SlangPathType*, int>)(lpVtbl[7]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, pathTypeOut);
    }

    public int getPath(PathKind kind, sbyte* path, ISlangBlob** outPath)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, PathKind, sbyte*, ISlangBlob**, int>)(lpVtbl[8]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), kind, path, outPath);
    }

    public void clearCache()
    {
        ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, void>)(lpVtbl[9]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    public int enumeratePathContents(sbyte* path, delegate* unmanaged[Thiscall]<SlangPathType, sbyte*, void*, void> callback, void* userData)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, delegate* unmanaged[Thiscall]<SlangPathType, sbyte*, void*, void>, void*, int>)(lpVtbl[10]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, callback, userData);
    }

    public OSPathKind getOSPathKind()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, OSPathKind>)(lpVtbl[11]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    public int saveFile(sbyte* path, void* data, nuint size)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, void*, nuint, int>)(lpVtbl[12]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, data, size);
    }

    public int saveFileBlob(sbyte* path, ISlangBlob* dataBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, ISlangBlob*, int>)(lpVtbl[13]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, dataBlob);
    }

    public int remove(sbyte* path)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, int>)(lpVtbl[14]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path);
    }

    public int createDirectory(sbyte* path)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, int>)(lpVtbl[15]))((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path);
    }
}

public enum SlangWriterChannel : uint
{
    SLANG_WRITER_CHANNEL_DIAGNOSTIC = 0,
    SLANG_WRITER_CHANNEL_STD_OUTPUT = 1,
    SLANG_WRITER_CHANNEL_STD_ERROR = 2,
    SLANG_WRITER_CHANNEL_COUNT_OF,
}

public enum SlangWriterMode : uint
{
    SLANG_WRITER_MODE_TEXT = 0,
    SLANG_WRITER_MODE_BINARY = 1,
}

public unsafe partial struct ISlangWriter
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangWriter*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangWriter*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangWriter*, uint>)(lpVtbl[1]))((ISlangWriter*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangWriter*, uint>)(lpVtbl[2]))((ISlangWriter*)Unsafe.AsPointer(ref this));
    }

    public sbyte* beginAppendBuffer(nuint maxNumChars)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangWriter*, nuint, sbyte*>)(lpVtbl[3]))((ISlangWriter*)Unsafe.AsPointer(ref this), maxNumChars);
    }

    public int endAppendBuffer(sbyte* buffer, nuint numChars)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangWriter*, sbyte*, nuint, int>)(lpVtbl[4]))((ISlangWriter*)Unsafe.AsPointer(ref this), buffer, numChars);
    }

    public int write(sbyte* chars, nuint numChars)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangWriter*, sbyte*, nuint, int>)(lpVtbl[5]))((ISlangWriter*)Unsafe.AsPointer(ref this), chars, numChars);
    }

    public void flush()
    {
        ((delegate* unmanaged[Stdcall]<ISlangWriter*, void>)(lpVtbl[6]))((ISlangWriter*)Unsafe.AsPointer(ref this));
    }

    public bool isConsole()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangWriter*, byte>)(lpVtbl[7]))((ISlangWriter*)Unsafe.AsPointer(ref this)) != 0;
    }

    public int setMode(SlangWriterMode mode)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangWriter*, SlangWriterMode, int>)(lpVtbl[8]))((ISlangWriter*)Unsafe.AsPointer(ref this), mode);
    }
}

public unsafe partial struct ISlangProfiler
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangProfiler*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangProfiler*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangProfiler*, uint>)(lpVtbl[1]))((ISlangProfiler*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangProfiler*, uint>)(lpVtbl[2]))((ISlangProfiler*)Unsafe.AsPointer(ref this));
    }

    public nuint getEntryCount()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangProfiler*, nuint>)(lpVtbl[3]))((ISlangProfiler*)Unsafe.AsPointer(ref this));
    }

    public sbyte* getEntryName(uint index)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangProfiler*, uint, sbyte*>)(lpVtbl[4]))((ISlangProfiler*)Unsafe.AsPointer(ref this), index);
    }

    public int getEntryTimeMS(uint index)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangProfiler*, uint, int>)(lpVtbl[5]))((ISlangProfiler*)Unsafe.AsPointer(ref this), index);
    }

    public uint getEntryInvocationTimes(uint index)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangProfiler*, uint, uint>)(lpVtbl[6]))((ISlangProfiler*)Unsafe.AsPointer(ref this), index);
    }
}

public partial struct SlangProgramLayout
{
}

public partial struct SlangEntryPoint
{
}

public partial struct SlangEntryPointLayout
{
}

public partial struct SlangReflectionDecl
{
}

public partial struct SlangReflectionModifier
{
}

public partial struct SlangReflectionType
{
}

public partial struct SlangReflectionTypeLayout
{
}

public partial struct SlangReflectionVariable
{
}

public partial struct SlangReflectionVariableLayout
{
}

public partial struct SlangReflectionTypeParameter
{
}

public partial struct SlangReflectionUserAttribute
{
}

public partial struct SlangReflectionFunction
{
}

public partial struct SlangReflectionGeneric
{
}

public unsafe partial struct SlangReflectionGenericArg
{
    public SlangReflectionType* typeVal;

    public long intVal;

    public byte boolVal;
}

public enum SlangReflectionGenericArgType
{
    SLANG_GENERIC_ARG_TYPE = 0,
    SLANG_GENERIC_ARG_INT = 1,
    SLANG_GENERIC_ARG_BOOL = 2,
}

public enum SlangTypeKind : uint
{
    SLANG_TYPE_KIND_NONE = 0,
    SLANG_TYPE_KIND_STRUCT = 1,
    SLANG_TYPE_KIND_ARRAY = 2,
    SLANG_TYPE_KIND_MATRIX = 3,
    SLANG_TYPE_KIND_VECTOR = 4,
    SLANG_TYPE_KIND_SCALAR = 5,
    SLANG_TYPE_KIND_CONSTANT_BUFFER = 6,
    SLANG_TYPE_KIND_RESOURCE = 7,
    SLANG_TYPE_KIND_SAMPLER_STATE = 8,
    SLANG_TYPE_KIND_TEXTURE_BUFFER = 9,
    SLANG_TYPE_KIND_SHADER_STORAGE_BUFFER = 10,
    SLANG_TYPE_KIND_PARAMETER_BLOCK = 11,
    SLANG_TYPE_KIND_GENERIC_TYPE_PARAMETER = 12,
    SLANG_TYPE_KIND_INTERFACE = 13,
    SLANG_TYPE_KIND_OUTPUT_STREAM = 14,
    SLANG_TYPE_KIND_MESH_OUTPUT = 15,
    SLANG_TYPE_KIND_SPECIALIZED = 16,
    SLANG_TYPE_KIND_FEEDBACK = 17,
    SLANG_TYPE_KIND_POINTER = 18,
    SLANG_TYPE_KIND_DYNAMIC_RESOURCE = 19,
    SLANG_TYPE_KIND_ENUM = 20,
    SLANG_TYPE_KIND_COUNT,
}

public enum SlangScalarType : uint
{
    SLANG_SCALAR_TYPE_NONE = 0,
    SLANG_SCALAR_TYPE_VOID = 1,
    SLANG_SCALAR_TYPE_BOOL = 2,
    SLANG_SCALAR_TYPE_INT32 = 3,
    SLANG_SCALAR_TYPE_UINT32 = 4,
    SLANG_SCALAR_TYPE_INT64 = 5,
    SLANG_SCALAR_TYPE_UINT64 = 6,
    SLANG_SCALAR_TYPE_FLOAT16 = 7,
    SLANG_SCALAR_TYPE_FLOAT32 = 8,
    SLANG_SCALAR_TYPE_FLOAT64 = 9,
    SLANG_SCALAR_TYPE_INT8 = 10,
    SLANG_SCALAR_TYPE_UINT8 = 11,
    SLANG_SCALAR_TYPE_INT16 = 12,
    SLANG_SCALAR_TYPE_UINT16 = 13,
    SLANG_SCALAR_TYPE_INTPTR = 14,
    SLANG_SCALAR_TYPE_UINTPTR = 15,
    SLANG_SCALAR_TYPE_BFLOAT16 = 16,
    SLANG_SCALAR_TYPE_FLOAT_E4M3 = 17,
    SLANG_SCALAR_TYPE_FLOAT_E5M2 = 18,
}

public enum SlangDeclKind : uint
{
    SLANG_DECL_KIND_UNSUPPORTED_FOR_REFLECTION = 0,
    SLANG_DECL_KIND_STRUCT = 1,
    SLANG_DECL_KIND_FUNC = 2,
    SLANG_DECL_KIND_MODULE = 3,
    SLANG_DECL_KIND_GENERIC = 4,
    SLANG_DECL_KIND_VARIABLE = 5,
    SLANG_DECL_KIND_NAMESPACE = 6,
    SLANG_DECL_KIND_ENUM = 7,
}

public enum SlangResourceShape : uint
{
    SLANG_RESOURCE_BASE_SHAPE_MASK = 0x0F,
    SLANG_RESOURCE_NONE = 0x00,
    SLANG_TEXTURE_1D = 0x01,
    SLANG_TEXTURE_2D = 0x02,
    SLANG_TEXTURE_3D = 0x03,
    SLANG_TEXTURE_CUBE = 0x04,
    SLANG_TEXTURE_BUFFER = 0x05,
    SLANG_STRUCTURED_BUFFER = 0x06,
    SLANG_BYTE_ADDRESS_BUFFER = 0x07,
    SLANG_RESOURCE_UNKNOWN = 0x08,
    SLANG_ACCELERATION_STRUCTURE = 0x09,
    SLANG_TEXTURE_SUBPASS = 0x0A,
    SLANG_RESOURCE_EXT_SHAPE_MASK = 0x1F0,
    SLANG_TEXTURE_FEEDBACK_FLAG = 0x10,
    SLANG_TEXTURE_SHADOW_FLAG = 0x20,
    SLANG_TEXTURE_ARRAY_FLAG = 0x40,
    SLANG_TEXTURE_MULTISAMPLE_FLAG = 0x80,
    SLANG_TEXTURE_COMBINED_FLAG = 0x100,
    SLANG_TEXTURE_1D_ARRAY = SLANG_TEXTURE_1D | SLANG_TEXTURE_ARRAY_FLAG,
    SLANG_TEXTURE_2D_ARRAY = SLANG_TEXTURE_2D | SLANG_TEXTURE_ARRAY_FLAG,
    SLANG_TEXTURE_CUBE_ARRAY = SLANG_TEXTURE_CUBE | SLANG_TEXTURE_ARRAY_FLAG,
    SLANG_TEXTURE_2D_MULTISAMPLE = SLANG_TEXTURE_2D | SLANG_TEXTURE_MULTISAMPLE_FLAG,
    SLANG_TEXTURE_2D_MULTISAMPLE_ARRAY = SLANG_TEXTURE_2D | SLANG_TEXTURE_MULTISAMPLE_FLAG | SLANG_TEXTURE_ARRAY_FLAG,
    SLANG_TEXTURE_SUBPASS_MULTISAMPLE = SLANG_TEXTURE_SUBPASS | SLANG_TEXTURE_MULTISAMPLE_FLAG,
}

public enum SlangResourceAccess : uint
{
    SLANG_RESOURCE_ACCESS_NONE = 0,
    SLANG_RESOURCE_ACCESS_READ = 1,
    SLANG_RESOURCE_ACCESS_READ_WRITE = 2,
    SLANG_RESOURCE_ACCESS_RASTER_ORDERED = 3,
    SLANG_RESOURCE_ACCESS_APPEND = 4,
    SLANG_RESOURCE_ACCESS_CONSUME = 5,
    SLANG_RESOURCE_ACCESS_WRITE = 6,
    SLANG_RESOURCE_ACCESS_FEEDBACK = 7,
    SLANG_RESOURCE_ACCESS_UNKNOWN = 0x7FFFFFFF,
}

public enum SlangParameterCategory : uint
{
    SLANG_PARAMETER_CATEGORY_NONE = 0,
    SLANG_PARAMETER_CATEGORY_MIXED = 1,
    SLANG_PARAMETER_CATEGORY_CONSTANT_BUFFER = 2,
    SLANG_PARAMETER_CATEGORY_SHADER_RESOURCE = 3,
    SLANG_PARAMETER_CATEGORY_UNORDERED_ACCESS = 4,
    SLANG_PARAMETER_CATEGORY_VARYING_INPUT = 5,
    SLANG_PARAMETER_CATEGORY_VARYING_OUTPUT = 6,
    SLANG_PARAMETER_CATEGORY_SAMPLER_STATE = 7,
    SLANG_PARAMETER_CATEGORY_UNIFORM = 8,
    SLANG_PARAMETER_CATEGORY_DESCRIPTOR_TABLE_SLOT = 9,
    SLANG_PARAMETER_CATEGORY_SPECIALIZATION_CONSTANT = 10,
    SLANG_PARAMETER_CATEGORY_PUSH_CONSTANT_BUFFER = 11,
    SLANG_PARAMETER_CATEGORY_REGISTER_SPACE = 12,
    SLANG_PARAMETER_CATEGORY_GENERIC = 13,
    SLANG_PARAMETER_CATEGORY_RAY_PAYLOAD = 14,
    SLANG_PARAMETER_CATEGORY_HIT_ATTRIBUTES = 15,
    SLANG_PARAMETER_CATEGORY_CALLABLE_PAYLOAD = 16,
    SLANG_PARAMETER_CATEGORY_SHADER_RECORD = 17,
    SLANG_PARAMETER_CATEGORY_EXISTENTIAL_TYPE_PARAM = 18,
    SLANG_PARAMETER_CATEGORY_EXISTENTIAL_OBJECT_PARAM = 19,
    SLANG_PARAMETER_CATEGORY_SUB_ELEMENT_REGISTER_SPACE = 20,
    SLANG_PARAMETER_CATEGORY_SUBPASS = 21,
    SLANG_PARAMETER_CATEGORY_METAL_ARGUMENT_BUFFER_ELEMENT = 22,
    SLANG_PARAMETER_CATEGORY_METAL_ATTRIBUTE = 23,
    SLANG_PARAMETER_CATEGORY_METAL_PAYLOAD = 24,
    SLANG_PARAMETER_CATEGORY_COUNT,
    SLANG_PARAMETER_CATEGORY_METAL_BUFFER = SLANG_PARAMETER_CATEGORY_CONSTANT_BUFFER,
    SLANG_PARAMETER_CATEGORY_METAL_TEXTURE = SLANG_PARAMETER_CATEGORY_SHADER_RESOURCE,
    SLANG_PARAMETER_CATEGORY_METAL_SAMPLER = SLANG_PARAMETER_CATEGORY_SAMPLER_STATE,
    SLANG_PARAMETER_CATEGORY_VERTEX_INPUT = SLANG_PARAMETER_CATEGORY_VARYING_INPUT,
    SLANG_PARAMETER_CATEGORY_FRAGMENT_OUTPUT = SLANG_PARAMETER_CATEGORY_VARYING_OUTPUT,
    SLANG_PARAMETER_CATEGORY_COUNT_V1 = SLANG_PARAMETER_CATEGORY_SUBPASS,
}

public enum SlangBindingType : uint
{
    SLANG_BINDING_TYPE_UNKNOWN = 0,
    SLANG_BINDING_TYPE_SAMPLER = 1,
    SLANG_BINDING_TYPE_TEXTURE = 2,
    SLANG_BINDING_TYPE_CONSTANT_BUFFER = 3,
    SLANG_BINDING_TYPE_PARAMETER_BLOCK = 4,
    SLANG_BINDING_TYPE_TYPED_BUFFER = 5,
    SLANG_BINDING_TYPE_RAW_BUFFER = 6,
    SLANG_BINDING_TYPE_COMBINED_TEXTURE_SAMPLER = 7,
    SLANG_BINDING_TYPE_INPUT_RENDER_TARGET = 8,
    SLANG_BINDING_TYPE_INLINE_UNIFORM_DATA = 9,
    SLANG_BINDING_TYPE_RAY_TRACING_ACCELERATION_STRUCTURE = 10,
    SLANG_BINDING_TYPE_VARYING_INPUT = 11,
    SLANG_BINDING_TYPE_VARYING_OUTPUT = 12,
    SLANG_BINDING_TYPE_EXISTENTIAL_VALUE = 13,
    SLANG_BINDING_TYPE_PUSH_CONSTANT = 14,
    SLANG_BINDING_TYPE_MUTABLE_FLAG = 0x100,
    SLANG_BINDING_TYPE_MUTABLE_TETURE = SLANG_BINDING_TYPE_TEXTURE | SLANG_BINDING_TYPE_MUTABLE_FLAG,
    SLANG_BINDING_TYPE_MUTABLE_TYPED_BUFFER = SLANG_BINDING_TYPE_TYPED_BUFFER | SLANG_BINDING_TYPE_MUTABLE_FLAG,
    SLANG_BINDING_TYPE_MUTABLE_RAW_BUFFER = SLANG_BINDING_TYPE_RAW_BUFFER | SLANG_BINDING_TYPE_MUTABLE_FLAG,
    SLANG_BINDING_TYPE_BASE_MASK = 0x00FF,
    SLANG_BINDING_TYPE_EXT_MASK = 0xFF00,
}

public enum SlangLayoutRules : uint
{
    SLANG_LAYOUT_RULES_DEFAULT = 0,
    SLANG_LAYOUT_RULES_METAL_ARGUMENT_BUFFER_TIER_2 = 1,
    SLANG_LAYOUT_RULES_DEFAULT_STRUCTURED_BUFFER = 2,
    SLANG_LAYOUT_RULES_DEFAULT_CONSTANT_BUFFER = 3,
}

public enum SlangModifierID : uint
{
    SLANG_MODIFIER_SHARED = 0,
    SLANG_MODIFIER_NO_DIFF = 1,
    SLANG_MODIFIER_STATIC = 2,
    SLANG_MODIFIER_CONST = 3,
    SLANG_MODIFIER_EXPORT = 4,
    SLANG_MODIFIER_EXTERN = 5,
    SLANG_MODIFIER_DIFFERENTIABLE = 6,
    SLANG_MODIFIER_MUTATING = 7,
    SLANG_MODIFIER_IN = 8,
    SLANG_MODIFIER_OUT = 9,
    SLANG_MODIFIER_INOUT = 10,
}

public enum SlangImageFormat : uint
{
    SLANG_IMAGE_FORMAT_unknown,
    SLANG_IMAGE_FORMAT_rgba32f,
    SLANG_IMAGE_FORMAT_rgba16f,
    SLANG_IMAGE_FORMAT_rg32f,
    SLANG_IMAGE_FORMAT_rg16f,
    SLANG_IMAGE_FORMAT_r11f_g11f_b10f,
    SLANG_IMAGE_FORMAT_r32f,
    SLANG_IMAGE_FORMAT_r16f,
    SLANG_IMAGE_FORMAT_rgba16,
    SLANG_IMAGE_FORMAT_rgb10_a2,
    SLANG_IMAGE_FORMAT_rgba8,
    SLANG_IMAGE_FORMAT_rg16,
    SLANG_IMAGE_FORMAT_rg8,
    SLANG_IMAGE_FORMAT_r16,
    SLANG_IMAGE_FORMAT_r8,
    SLANG_IMAGE_FORMAT_rgba16_snorm,
    SLANG_IMAGE_FORMAT_rgba8_snorm,
    SLANG_IMAGE_FORMAT_rg16_snorm,
    SLANG_IMAGE_FORMAT_rg8_snorm,
    SLANG_IMAGE_FORMAT_r16_snorm,
    SLANG_IMAGE_FORMAT_r8_snorm,
    SLANG_IMAGE_FORMAT_rgba32i,
    SLANG_IMAGE_FORMAT_rgba16i,
    SLANG_IMAGE_FORMAT_rgba8i,
    SLANG_IMAGE_FORMAT_rg32i,
    SLANG_IMAGE_FORMAT_rg16i,
    SLANG_IMAGE_FORMAT_rg8i,
    SLANG_IMAGE_FORMAT_r32i,
    SLANG_IMAGE_FORMAT_r16i,
    SLANG_IMAGE_FORMAT_r8i,
    SLANG_IMAGE_FORMAT_rgba32ui,
    SLANG_IMAGE_FORMAT_rgba16ui,
    SLANG_IMAGE_FORMAT_rgb10_a2ui,
    SLANG_IMAGE_FORMAT_rgba8ui,
    SLANG_IMAGE_FORMAT_rg32ui,
    SLANG_IMAGE_FORMAT_rg16ui,
    SLANG_IMAGE_FORMAT_rg8ui,
    SLANG_IMAGE_FORMAT_r32ui,
    SLANG_IMAGE_FORMAT_r16ui,
    SLANG_IMAGE_FORMAT_r8ui,
    SLANG_IMAGE_FORMAT_r64ui,
    SLANG_IMAGE_FORMAT_r64i,
    SLANG_IMAGE_FORMAT_bgra8,
}

public unsafe partial struct ICompileRequest
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangUUID*, void**, int>)(lpVtbl[0]))((ICompileRequest*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, uint>)(lpVtbl[1]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, uint>)(lpVtbl[2]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public void setFileSystem(ISlangFileSystem* fileSystem)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, ISlangFileSystem*, void>)(lpVtbl[3]))((ICompileRequest*)Unsafe.AsPointer(ref this), fileSystem);
    }

    public void setCompileFlags(uint flags)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, uint, void>)(lpVtbl[4]))((ICompileRequest*)Unsafe.AsPointer(ref this), flags);
    }

    public uint getCompileFlags()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, uint>)(lpVtbl[5]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public void setDumpIntermediates(int enable)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, void>)(lpVtbl[6]))((ICompileRequest*)Unsafe.AsPointer(ref this), enable);
    }

    public void setDumpIntermediatePrefix(sbyte* prefix)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, sbyte*, void>)(lpVtbl[7]))((ICompileRequest*)Unsafe.AsPointer(ref this), prefix);
    }

    public void setLineDirectiveMode(SlangLineDirectiveMode mode)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangLineDirectiveMode, void>)(lpVtbl[8]))((ICompileRequest*)Unsafe.AsPointer(ref this), mode);
    }

    public void setCodeGenTarget(SlangCompileTarget target)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangCompileTarget, void>)(lpVtbl[9]))((ICompileRequest*)Unsafe.AsPointer(ref this), target);
    }

    public int addCodeGenTarget(SlangCompileTarget target)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangCompileTarget, int>)(lpVtbl[10]))((ICompileRequest*)Unsafe.AsPointer(ref this), target);
    }

    public void setTargetProfile(int targetIndex, SlangProfileID profile)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, SlangProfileID, void>)(lpVtbl[11]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, profile);
    }

    public void setTargetFlags(int targetIndex, uint flags)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, uint, void>)(lpVtbl[12]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, flags);
    }

    public void setTargetFloatingPointMode(int targetIndex, SlangFloatingPointMode mode)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, SlangFloatingPointMode, void>)(lpVtbl[13]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, mode);
    }

    public void setTargetMatrixLayoutMode(int targetIndex, SlangMatrixLayoutMode mode)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, SlangMatrixLayoutMode, void>)(lpVtbl[14]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, mode);
    }

    public void setMatrixLayoutMode(SlangMatrixLayoutMode mode)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangMatrixLayoutMode, void>)(lpVtbl[15]))((ICompileRequest*)Unsafe.AsPointer(ref this), mode);
    }

    public void setDebugInfoLevel(SlangDebugInfoLevel level)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangDebugInfoLevel, void>)(lpVtbl[16]))((ICompileRequest*)Unsafe.AsPointer(ref this), level);
    }

    public void setOptimizationLevel(SlangOptimizationLevel level)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangOptimizationLevel, void>)(lpVtbl[17]))((ICompileRequest*)Unsafe.AsPointer(ref this), level);
    }

    public void setOutputContainerFormat(SlangContainerFormat format)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangContainerFormat, void>)(lpVtbl[18]))((ICompileRequest*)Unsafe.AsPointer(ref this), format);
    }

    public void setPassThrough(SlangPassThrough passThrough)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangPassThrough, void>)(lpVtbl[19]))((ICompileRequest*)Unsafe.AsPointer(ref this), passThrough);
    }

    public void setDiagnosticCallback(delegate* unmanaged[Thiscall]<sbyte*, void*, void> callback, void* userData)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, delegate* unmanaged[Thiscall]<sbyte*, void*, void>, void*, void>)(lpVtbl[20]))((ICompileRequest*)Unsafe.AsPointer(ref this), callback, userData);
    }

    public void setWriter(SlangWriterChannel channel, ISlangWriter* writer)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangWriterChannel, ISlangWriter*, void>)(lpVtbl[21]))((ICompileRequest*)Unsafe.AsPointer(ref this), channel, writer);
    }

    public ISlangWriter* getWriter(SlangWriterChannel channel)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangWriterChannel, ISlangWriter*>)(lpVtbl[22]))((ICompileRequest*)Unsafe.AsPointer(ref this), channel);
    }

    public void addSearchPath(sbyte* searchDir)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, sbyte*, void>)(lpVtbl[23]))((ICompileRequest*)Unsafe.AsPointer(ref this), searchDir);
    }

    public void addPreprocessorDefine(sbyte* key, sbyte* value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, sbyte*, sbyte*, void>)(lpVtbl[24]))((ICompileRequest*)Unsafe.AsPointer(ref this), key, value);
    }

    public int processCommandLineArguments(sbyte** args, int argCount)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, sbyte**, int, int>)(lpVtbl[25]))((ICompileRequest*)Unsafe.AsPointer(ref this), args, argCount);
    }

    public int addTranslationUnit(SlangSourceLanguage language, sbyte* name)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangSourceLanguage, sbyte*, int>)(lpVtbl[26]))((ICompileRequest*)Unsafe.AsPointer(ref this), language, name);
    }

    public void setDefaultModuleName(sbyte* defaultModuleName)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, sbyte*, void>)(lpVtbl[27]))((ICompileRequest*)Unsafe.AsPointer(ref this), defaultModuleName);
    }

    public void addTranslationUnitPreprocessorDefine(int translationUnitIndex, sbyte* key, sbyte* value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, sbyte*, sbyte*, void>)(lpVtbl[28]))((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, key, value);
    }

    public void addTranslationUnitSourceFile(int translationUnitIndex, sbyte* path)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, sbyte*, void>)(lpVtbl[29]))((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, path);
    }

    public void addTranslationUnitSourceString(int translationUnitIndex, sbyte* path, sbyte* source)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, sbyte*, sbyte*, void>)(lpVtbl[30]))((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, path, source);
    }

    public int addLibraryReference(sbyte* basePath, void* libData, nuint libDataSize)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, sbyte*, void*, nuint, int>)(lpVtbl[31]))((ICompileRequest*)Unsafe.AsPointer(ref this), basePath, libData, libDataSize);
    }

    public void addTranslationUnitSourceStringSpan(int translationUnitIndex, sbyte* path, sbyte* sourceBegin, sbyte* sourceEnd)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, sbyte*, sbyte*, sbyte*, void>)(lpVtbl[32]))((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, path, sourceBegin, sourceEnd);
    }

    public void addTranslationUnitSourceBlob(int translationUnitIndex, sbyte* path, ISlangBlob* sourceBlob)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, sbyte*, ISlangBlob*, void>)(lpVtbl[33]))((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, path, sourceBlob);
    }

    public int addEntryPoint(int translationUnitIndex, sbyte* name, SlangStage stage)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, sbyte*, SlangStage, int>)(lpVtbl[34]))((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, name, stage);
    }

    public int addEntryPointEx(int translationUnitIndex, sbyte* name, SlangStage stage, int genericArgCount, sbyte** genericArgs)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, sbyte*, SlangStage, int, sbyte**, int>)(lpVtbl[35]))((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, name, stage, genericArgCount, genericArgs);
    }

    public int setGlobalGenericArgs(int genericArgCount, sbyte** genericArgs)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, sbyte**, int>)(lpVtbl[36]))((ICompileRequest*)Unsafe.AsPointer(ref this), genericArgCount, genericArgs);
    }

    public int setTypeNameForGlobalExistentialTypeParam(int slotIndex, sbyte* typeName)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, sbyte*, int>)(lpVtbl[37]))((ICompileRequest*)Unsafe.AsPointer(ref this), slotIndex, typeName);
    }

    public int setTypeNameForEntryPointExistentialTypeParam(int entryPointIndex, int slotIndex, sbyte* typeName)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, int, sbyte*, int>)(lpVtbl[38]))((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, slotIndex, typeName);
    }

    public void setAllowGLSLInput(byte value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, byte, void>)(lpVtbl[39]))((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    public int compile()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int>)(lpVtbl[40]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public sbyte* getDiagnosticOutput()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, sbyte*>)(lpVtbl[41]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public int getDiagnosticOutputBlob(ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, ISlangBlob**, int>)(lpVtbl[42]))((ICompileRequest*)Unsafe.AsPointer(ref this), outBlob);
    }

    public int getDependencyFileCount()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int>)(lpVtbl[43]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public sbyte* getDependencyFilePath(int index)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, sbyte*>)(lpVtbl[44]))((ICompileRequest*)Unsafe.AsPointer(ref this), index);
    }

    public int getTranslationUnitCount()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int>)(lpVtbl[45]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public sbyte* getEntryPointSource(int entryPointIndex)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, sbyte*>)(lpVtbl[46]))((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex);
    }

    public void* getEntryPointCode(int entryPointIndex, nuint* outSize)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, nuint*, void*>)(lpVtbl[47]))((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, outSize);
    }

    public int getEntryPointCodeBlob(int entryPointIndex, int targetIndex, ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, int, ISlangBlob**, int>)(lpVtbl[48]))((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outBlob);
    }

    public int getEntryPointHostCallable(int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, int, ISlangSharedLibrary**, int>)(lpVtbl[49]))((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outSharedLibrary);
    }

    public int getTargetCodeBlob(int targetIndex, ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, ISlangBlob**, int>)(lpVtbl[50]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, outBlob);
    }

    public int getTargetHostCallable(int targetIndex, ISlangSharedLibrary** outSharedLibrary)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, ISlangSharedLibrary**, int>)(lpVtbl[51]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, outSharedLibrary);
    }

    public void* getCompileRequestCode(nuint* outSize)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, nuint*, void*>)(lpVtbl[52]))((ICompileRequest*)Unsafe.AsPointer(ref this), outSize);
    }

    public ISlangMutableFileSystem* getCompileRequestResultAsFileSystem()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, ISlangMutableFileSystem*>)(lpVtbl[53]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public int getContainerCode(ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, ISlangBlob**, int>)(lpVtbl[54]))((ICompileRequest*)Unsafe.AsPointer(ref this), outBlob);
    }

    public int loadRepro(ISlangFileSystem* fileSystem, void* data, nuint size)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, ISlangFileSystem*, void*, nuint, int>)(lpVtbl[55]))((ICompileRequest*)Unsafe.AsPointer(ref this), fileSystem, data, size);
    }

    public int saveRepro(ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, ISlangBlob**, int>)(lpVtbl[56]))((ICompileRequest*)Unsafe.AsPointer(ref this), outBlob);
    }

    public int enableReproCapture()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int>)(lpVtbl[57]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public int getProgram(IComponentType** outProgram)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, IComponentType**, int>)(lpVtbl[58]))((ICompileRequest*)Unsafe.AsPointer(ref this), outProgram);
    }

    public int getEntryPoint(long entryPointIndex, IComponentType** outEntryPoint)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, long, IComponentType**, int>)(lpVtbl[59]))((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, outEntryPoint);
    }

    public int getModule(long translationUnitIndex, IModule** outModule)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, long, IModule**, int>)(lpVtbl[60]))((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, outModule);
    }

    public int getSession(ISession** outSession)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, ISession**, int>)(lpVtbl[61]))((ICompileRequest*)Unsafe.AsPointer(ref this), outSession);
    }

    public SlangProgramLayout* getReflection()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangProgramLayout*>)(lpVtbl[62]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public void setCommandLineCompilerMode()
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, void>)(lpVtbl[63]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public int addTargetCapability(long targetIndex, SlangCapabilityID capability)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, long, SlangCapabilityID, int>)(lpVtbl[64]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, capability);
    }

    public int getProgramWithEntryPoints(IComponentType** outProgram)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, IComponentType**, int>)(lpVtbl[65]))((ICompileRequest*)Unsafe.AsPointer(ref this), outProgram);
    }

    public int isParameterLocationUsed(long entryPointIndex, long targetIndex, SlangParameterCategory category, ulong spaceIndex, ulong registerIndex, bool* outUsed)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, long, long, SlangParameterCategory, ulong, ulong, bool*, int>)(lpVtbl[66]))((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, category, spaceIndex, registerIndex, outUsed);
    }

    public void setTargetLineDirectiveMode(long targetIndex, SlangLineDirectiveMode mode)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, long, SlangLineDirectiveMode, void>)(lpVtbl[67]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, mode);
    }

    public void setTargetForceGLSLScalarBufferLayout(int targetIndex, byte forceScalarLayout)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, byte, void>)(lpVtbl[68]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, forceScalarLayout);
    }

    public void overrideDiagnosticSeverity(long messageID, SlangSeverity overrideSeverity)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, long, SlangSeverity, void>)(lpVtbl[69]))((ICompileRequest*)Unsafe.AsPointer(ref this), messageID, overrideSeverity);
    }

    public int getDiagnosticFlags()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, int>)(lpVtbl[70]))((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    public void setDiagnosticFlags(int flags)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, void>)(lpVtbl[71]))((ICompileRequest*)Unsafe.AsPointer(ref this), flags);
    }

    public void setDebugInfoFormat(SlangDebugInfoFormat debugFormat)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, SlangDebugInfoFormat, void>)(lpVtbl[72]))((ICompileRequest*)Unsafe.AsPointer(ref this), debugFormat);
    }

    public void setEnableEffectAnnotations(byte value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, byte, void>)(lpVtbl[73]))((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    public void setReportDownstreamTime(byte value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, byte, void>)(lpVtbl[74]))((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    public void setReportPerfBenchmark(byte value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, byte, void>)(lpVtbl[75]))((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    public void setSkipSPIRVValidation(byte value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, byte, void>)(lpVtbl[76]))((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    public void setTargetUseMinimumSlangOptimization(int targetIndex, byte value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, byte, void>)(lpVtbl[77]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, value);
    }

    public void setIgnoreCapabilityCheck(byte value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, byte, void>)(lpVtbl[78]))((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    public int getCompileTimeProfile(ISlangProfiler** compileTimeProfile, byte shouldClear)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileRequest*, ISlangProfiler**, byte, int>)(lpVtbl[79]))((ICompileRequest*)Unsafe.AsPointer(ref this), compileTimeProfile, shouldClear);
    }

    public void setTargetGenerateWholeProgram(int targetIndex, byte value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, byte, void>)(lpVtbl[80]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, value);
    }

    public void setTargetForceDXLayout(int targetIndex, byte value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, byte, void>)(lpVtbl[81]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, value);
    }

    public void setTargetEmbedDownstreamIR(int targetIndex, byte value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, byte, void>)(lpVtbl[82]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, value);
    }

    public void setTargetForceCLayout(int targetIndex, byte value)
    {
        ((delegate* unmanaged[Stdcall]<ICompileRequest*, int, byte, void>)(lpVtbl[83]))((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, value);
    }
}

public partial struct BufferReflection
{
}

public unsafe partial struct GenericArgReflection
{
    public TypeReflection* typeVal;

    public long intVal;

    public byte boolVal;
}

public unsafe partial struct Attribute
{
    public sbyte* getName()
    {
        return spReflectionUserAttribute_GetName((SlangReflectionUserAttribute*)Unsafe.AsPointer(ref this));
    }

    public uint getArgumentCount()
    {
        return (uint)(spReflectionUserAttribute_GetArgumentCount((SlangReflectionUserAttribute*)Unsafe.AsPointer(ref this)));
    }

    public TypeReflection* getArgumentType(uint index)
    {
        return (TypeReflection*)(spReflectionUserAttribute_GetArgumentType((SlangReflectionUserAttribute*)Unsafe.AsPointer(ref this), index));
    }

    public int getArgumentValueInt(uint index, int* value)
    {
        return spReflectionUserAttribute_GetArgumentValueInt(unchecked((SlangReflectionUserAttribute*)Unsafe.AsPointer(ref this)), index, value);
    }

    public int getArgumentValueFloat(uint index, float* value)
    {
        return spReflectionUserAttribute_GetArgumentValueFloat(unchecked((SlangReflectionUserAttribute*)Unsafe.AsPointer(ref this)), index, value);
    }

    public sbyte* getArgumentValueString(uint index, nuint* outSize)
    {
        return spReflectionUserAttribute_GetArgumentValueString((SlangReflectionUserAttribute*)Unsafe.AsPointer(ref this), index, outSize);
    }
}

public unsafe partial struct TypeReflection
{
    public TypeReflection.Kind getKind()
    {
        return (TypeReflection.Kind)(spReflectionType_GetKind(unchecked((SlangReflectionType*)Unsafe.AsPointer(ref this))));
    }

    public uint getFieldCount()
    {
        return spReflectionType_GetFieldCount((SlangReflectionType*)Unsafe.AsPointer(ref this));
    }

    public VariableReflection* getFieldByIndex(uint index)
    {
        return (VariableReflection*)(spReflectionType_GetFieldByIndex((SlangReflectionType*)Unsafe.AsPointer(ref this), index));
    }

    public bool isArray()
    {
        return getKind() == TypeReflection.Kind.Array;
    }

    public TypeReflection* unwrapArray()
    {
        TypeReflection* type = (TypeReflection*)Unsafe.AsPointer(ref this);

        while (type->isArray())
        {
            type = type->getElementType();
        }

        return type;
    }

    public nuint getElementCount(SlangProgramLayout* reflection = null)
    {
        return spReflectionType_GetSpecializedElementCount((SlangReflectionType*)Unsafe.AsPointer(ref this), reflection);
    }

    public nuint getTotalArrayElementCount()
    {
        if (!isArray())
        {
            return 0;
        }

        nuint result = 1;
        TypeReflection* type = (TypeReflection*)Unsafe.AsPointer(ref this);

        for (; ; )
        {
            if (!type->isArray())
            {
                return result;
            }

            nuint c = type->getElementCount();

            if (c == unchecked((~(nuint)(0)) - 1))
            {
                return ((~(nuint)(0)) - 1);
            }

            if (c == unchecked(~(nuint)(0)))
            {
                return (~(nuint)(0));
            }

            result *= c;
            type = type->getElementType();
        }
    }

    public TypeReflection* getElementType()
    {
        return (TypeReflection*)(spReflectionType_GetElementType((SlangReflectionType*)Unsafe.AsPointer(ref this)));
    }

    public uint getRowCount()
    {
        return spReflectionType_GetRowCount((SlangReflectionType*)Unsafe.AsPointer(ref this));
    }

    public uint getColumnCount()
    {
        return spReflectionType_GetColumnCount((SlangReflectionType*)Unsafe.AsPointer(ref this));
    }

    public TypeReflection.ScalarType getScalarType()
    {
        return (TypeReflection.ScalarType)(spReflectionType_GetScalarType(unchecked((SlangReflectionType*)Unsafe.AsPointer(ref this))));
    }

    public TypeReflection* getResourceResultType()
    {
        return (TypeReflection*)(spReflectionType_GetResourceResultType((SlangReflectionType*)Unsafe.AsPointer(ref this)));
    }

    public SlangResourceShape getResourceShape()
    {
        return spReflectionType_GetResourceShape(unchecked((SlangReflectionType*)Unsafe.AsPointer(ref this)));
    }

    public SlangResourceAccess getResourceAccess()
    {
        return spReflectionType_GetResourceAccess(unchecked((SlangReflectionType*)Unsafe.AsPointer(ref this)));
    }

    public sbyte* getName()
    {
        return spReflectionType_GetName((SlangReflectionType*)Unsafe.AsPointer(ref this));
    }

    public int getFullName(ISlangBlob** outNameBlob)
    {
        return spReflectionType_GetFullName(unchecked((SlangReflectionType*)Unsafe.AsPointer(ref this)), outNameBlob);
    }

    public uint getUserAttributeCount()
    {
        return spReflectionType_GetUserAttributeCount((SlangReflectionType*)Unsafe.AsPointer(ref this));
    }

    public Attribute* getUserAttributeByIndex(uint index)
    {
        return (Attribute*)(spReflectionType_GetUserAttribute((SlangReflectionType*)Unsafe.AsPointer(ref this), index));
    }

    public Attribute* findAttributeByName(sbyte* name)
    {
        return (Attribute*)(spReflectionType_FindUserAttributeByName((SlangReflectionType*)Unsafe.AsPointer(ref this), name));
    }

    public Attribute* findUserAttributeByName(sbyte* name)
    {
        return findAttributeByName(name);
    }

    public TypeReflection* applySpecializations(GenericReflection* generic)
    {
        return (TypeReflection*)(spReflectionType_applySpecializations((SlangReflectionType*)Unsafe.AsPointer(ref this), (SlangReflectionGeneric*)(generic)));
    }

    public GenericReflection* getGenericContainer()
    {
        return (GenericReflection*)(spReflectionType_GetGenericContainer((SlangReflectionType*)Unsafe.AsPointer(ref this)));
    }

    public enum Kind : uint
    {
        None = SLANG_TYPE_KIND_NONE,
        Struct = SLANG_TYPE_KIND_STRUCT,
        Array = SLANG_TYPE_KIND_ARRAY,
        Matrix = SLANG_TYPE_KIND_MATRIX,
        Vector = SLANG_TYPE_KIND_VECTOR,
        Scalar = SLANG_TYPE_KIND_SCALAR,
        ConstantBuffer = SLANG_TYPE_KIND_CONSTANT_BUFFER,
        Resource = SLANG_TYPE_KIND_RESOURCE,
        SamplerState = SLANG_TYPE_KIND_SAMPLER_STATE,
        TextureBuffer = SLANG_TYPE_KIND_TEXTURE_BUFFER,
        ShaderStorageBuffer = SLANG_TYPE_KIND_SHADER_STORAGE_BUFFER,
        ParameterBlock = SLANG_TYPE_KIND_PARAMETER_BLOCK,
        GenericTypeParameter = SLANG_TYPE_KIND_GENERIC_TYPE_PARAMETER,
        Interface = SLANG_TYPE_KIND_INTERFACE,
        OutputStream = SLANG_TYPE_KIND_OUTPUT_STREAM,
        Specialized = SLANG_TYPE_KIND_SPECIALIZED,
        Feedback = SLANG_TYPE_KIND_FEEDBACK,
        Pointer = SLANG_TYPE_KIND_POINTER,
        DynamicResource = SLANG_TYPE_KIND_DYNAMIC_RESOURCE,
        MeshOutput = SLANG_TYPE_KIND_MESH_OUTPUT,
        Enum = SLANG_TYPE_KIND_ENUM,
    }

    public enum ScalarType : uint
    {
        None = SLANG_SCALAR_TYPE_NONE,
        Void = SLANG_SCALAR_TYPE_VOID,
        Bool = SLANG_SCALAR_TYPE_BOOL,
        Int32 = SLANG_SCALAR_TYPE_INT32,
        UInt32 = SLANG_SCALAR_TYPE_UINT32,
        Int64 = SLANG_SCALAR_TYPE_INT64,
        UInt64 = SLANG_SCALAR_TYPE_UINT64,
        Float16 = SLANG_SCALAR_TYPE_FLOAT16,
        Float32 = SLANG_SCALAR_TYPE_FLOAT32,
        Float64 = SLANG_SCALAR_TYPE_FLOAT64,
        Int8 = SLANG_SCALAR_TYPE_INT8,
        UInt8 = SLANG_SCALAR_TYPE_UINT8,
        Int16 = SLANG_SCALAR_TYPE_INT16,
        UInt16 = SLANG_SCALAR_TYPE_UINT16,
        IntPtr = SLANG_SCALAR_TYPE_INTPTR,
        UIntPtr = SLANG_SCALAR_TYPE_UINTPTR,
        BFloat16 = SLANG_SCALAR_TYPE_BFLOAT16,
        FloatE4M3 = SLANG_SCALAR_TYPE_FLOAT_E4M3,
        FloatE5M2 = SLANG_SCALAR_TYPE_FLOAT_E5M2,
    }
}

public enum ParameterCategory : uint
{
    None = SLANG_PARAMETER_CATEGORY_NONE,
    Mixed = SLANG_PARAMETER_CATEGORY_MIXED,
    ConstantBuffer = SLANG_PARAMETER_CATEGORY_CONSTANT_BUFFER,
    ShaderResource = SLANG_PARAMETER_CATEGORY_SHADER_RESOURCE,
    UnorderedAccess = SLANG_PARAMETER_CATEGORY_UNORDERED_ACCESS,
    VaryingInput = SLANG_PARAMETER_CATEGORY_VARYING_INPUT,
    VaryingOutput = SLANG_PARAMETER_CATEGORY_VARYING_OUTPUT,
    SamplerState = SLANG_PARAMETER_CATEGORY_SAMPLER_STATE,
    Uniform = SLANG_PARAMETER_CATEGORY_UNIFORM,
    DescriptorTableSlot = SLANG_PARAMETER_CATEGORY_DESCRIPTOR_TABLE_SLOT,
    SpecializationConstant = SLANG_PARAMETER_CATEGORY_SPECIALIZATION_CONSTANT,
    PushConstantBuffer = SLANG_PARAMETER_CATEGORY_PUSH_CONSTANT_BUFFER,
    RegisterSpace = SLANG_PARAMETER_CATEGORY_REGISTER_SPACE,
    GenericResource = SLANG_PARAMETER_CATEGORY_GENERIC,
    RayPayload = SLANG_PARAMETER_CATEGORY_RAY_PAYLOAD,
    HitAttributes = SLANG_PARAMETER_CATEGORY_HIT_ATTRIBUTES,
    CallablePayload = SLANG_PARAMETER_CATEGORY_CALLABLE_PAYLOAD,
    ShaderRecord = SLANG_PARAMETER_CATEGORY_SHADER_RECORD,
    ExistentialTypeParam = SLANG_PARAMETER_CATEGORY_EXISTENTIAL_TYPE_PARAM,
    ExistentialObjectParam = SLANG_PARAMETER_CATEGORY_EXISTENTIAL_OBJECT_PARAM,
    SubElementRegisterSpace = SLANG_PARAMETER_CATEGORY_SUB_ELEMENT_REGISTER_SPACE,
    InputAttachmentIndex = SLANG_PARAMETER_CATEGORY_SUBPASS,
    MetalBuffer = SLANG_PARAMETER_CATEGORY_CONSTANT_BUFFER,
    MetalTexture = SLANG_PARAMETER_CATEGORY_METAL_TEXTURE,
    MetalArgumentBufferElement = SLANG_PARAMETER_CATEGORY_METAL_ARGUMENT_BUFFER_ELEMENT,
    MetalAttribute = SLANG_PARAMETER_CATEGORY_METAL_ATTRIBUTE,
    MetalPayload = SLANG_PARAMETER_CATEGORY_METAL_PAYLOAD,
    VertexInput = SLANG_PARAMETER_CATEGORY_VERTEX_INPUT,
    FragmentOutput = SLANG_PARAMETER_CATEGORY_FRAGMENT_OUTPUT,
}

public enum BindingType : uint
{
    Unknown = SLANG_BINDING_TYPE_UNKNOWN,
    Sampler = SLANG_BINDING_TYPE_SAMPLER,
    Texture = SLANG_BINDING_TYPE_TEXTURE,
    ConstantBuffer = SLANG_BINDING_TYPE_CONSTANT_BUFFER,
    ParameterBlock = SLANG_BINDING_TYPE_PARAMETER_BLOCK,
    TypedBuffer = SLANG_BINDING_TYPE_TYPED_BUFFER,
    RawBuffer = SLANG_BINDING_TYPE_RAW_BUFFER,
    CombinedTextureSampler = SLANG_BINDING_TYPE_COMBINED_TEXTURE_SAMPLER,
    InputRenderTarget = SLANG_BINDING_TYPE_INPUT_RENDER_TARGET,
    InlineUniformData = SLANG_BINDING_TYPE_INLINE_UNIFORM_DATA,
    RayTracingAccelerationStructure = SLANG_BINDING_TYPE_RAY_TRACING_ACCELERATION_STRUCTURE,
    VaryingInput = SLANG_BINDING_TYPE_VARYING_INPUT,
    VaryingOutput = SLANG_BINDING_TYPE_VARYING_OUTPUT,
    ExistentialValue = SLANG_BINDING_TYPE_EXISTENTIAL_VALUE,
    PushConstant = SLANG_BINDING_TYPE_PUSH_CONSTANT,
    MutableFlag = SLANG_BINDING_TYPE_MUTABLE_FLAG,
    MutableTexture = SLANG_BINDING_TYPE_MUTABLE_TETURE,
    MutableTypedBuffer = SLANG_BINDING_TYPE_MUTABLE_TYPED_BUFFER,
    MutableRawBuffer = SLANG_BINDING_TYPE_MUTABLE_RAW_BUFFER,
    BaseMask = SLANG_BINDING_TYPE_BASE_MASK,
    ExtMask = SLANG_BINDING_TYPE_EXT_MASK,
}

public unsafe partial struct TypeLayoutReflection
{
    public TypeReflection* getType()
    {
        return (TypeReflection*)(spReflectionTypeLayout_GetType((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)));
    }

    public TypeReflection.Kind getKind()
    {
        return (TypeReflection.Kind)(spReflectionTypeLayout_getKind(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this))));
    }

    public nuint getSize(SlangParameterCategory category)
    {
        return spReflectionTypeLayout_GetSize((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this), category);
    }

    public nuint getStride(SlangParameterCategory category)
    {
        return spReflectionTypeLayout_GetStride((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this), category);
    }

    public int getAlignment(SlangParameterCategory category)
    {
        return spReflectionTypeLayout_getAlignment(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), category);
    }

    public nuint getSize(ParameterCategory category = ParameterCategory.Uniform)
    {
        return spReflectionTypeLayout_GetSize((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this), unchecked((SlangParameterCategory)(category)));
    }

    public nuint getStride(ParameterCategory category = ParameterCategory.Uniform)
    {
        return spReflectionTypeLayout_GetStride((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this), unchecked((SlangParameterCategory)(category)));
    }

    public int getAlignment(ParameterCategory category = ParameterCategory.Uniform)
    {
        return spReflectionTypeLayout_getAlignment(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), (SlangParameterCategory)(category));
    }

    public uint getFieldCount()
    {
        return spReflectionTypeLayout_GetFieldCount((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this));
    }

    public VariableLayoutReflection* getFieldByIndex(uint index)
    {
        return (VariableLayoutReflection*)(spReflectionTypeLayout_GetFieldByIndex((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this), index));
    }

    public long findFieldIndexByName(sbyte* nameBegin, sbyte* nameEnd = null)
    {
        return spReflectionTypeLayout_findFieldIndexByName(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), nameBegin, nameEnd);
    }

    public VariableLayoutReflection* getExplicitCounter()
    {
        return (VariableLayoutReflection*)(spReflectionTypeLayout_GetExplicitCounter((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)));
    }

    public bool isArray()
    {
        return getType()->isArray();
    }

    public TypeLayoutReflection* unwrapArray()
    {
        TypeLayoutReflection* typeLayout = (TypeLayoutReflection*)Unsafe.AsPointer(ref this);

        while (typeLayout->isArray())
        {
            typeLayout = typeLayout->getElementTypeLayout();
        }

        return typeLayout;
    }

    public nuint getElementCount(ShaderReflection* reflection = null)
    {
        return getType()->getElementCount((SlangProgramLayout*)(reflection));
    }

    public nuint getTotalArrayElementCount()
    {
        return getType()->getTotalArrayElementCount();
    }

    public nuint getElementStride(SlangParameterCategory category)
    {
        return spReflectionTypeLayout_GetElementStride((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this), category);
    }

    public TypeLayoutReflection* getElementTypeLayout()
    {
        return (TypeLayoutReflection*)(spReflectionTypeLayout_GetElementTypeLayout((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)));
    }

    public VariableLayoutReflection* getElementVarLayout()
    {
        return (VariableLayoutReflection*)(spReflectionTypeLayout_GetElementVarLayout((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)));
    }

    public VariableLayoutReflection* getContainerVarLayout()
    {
        return (VariableLayoutReflection*)(spReflectionTypeLayout_getContainerVarLayout((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)));
    }

    public ParameterCategory getParameterCategory()
    {
        return (ParameterCategory)(spReflectionTypeLayout_GetParameterCategory(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this))));
    }

    public uint getCategoryCount()
    {
        return spReflectionTypeLayout_GetCategoryCount((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this));
    }

    public ParameterCategory getCategoryByIndex(uint index)
    {
        return (ParameterCategory)(spReflectionTypeLayout_GetCategoryByIndex(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), index));
    }

    public uint getRowCount()
    {
        return getType()->getRowCount();
    }

    public uint getColumnCount()
    {
        return getType()->getColumnCount();
    }

    public TypeReflection.ScalarType getScalarType()
    {
        return getType()->getScalarType();
    }

    public TypeReflection* getResourceResultType()
    {
        return getType()->getResourceResultType();
    }

    public SlangResourceShape getResourceShape()
    {
        return getType()->getResourceShape();
    }

    public SlangResourceAccess getResourceAccess()
    {
        return getType()->getResourceAccess();
    }

    public sbyte* getName()
    {
        return getType()->getName();
    }

    public SlangMatrixLayoutMode getMatrixLayoutMode()
    {
        return spReflectionTypeLayout_GetMatrixLayoutMode(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)));
    }

    public int getGenericParamIndex()
    {
        return spReflectionTypeLayout_getGenericParamIndex(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)));
    }

    public TypeLayoutReflection* getPendingDataTypeLayout()
    {
        return null;
    }

    public VariableLayoutReflection* getSpecializedTypePendingDataVarLayout()
    {
        return null;
    }

    public long getBindingRangeCount()
    {
        return spReflectionTypeLayout_getBindingRangeCount(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)));
    }

    public BindingType getBindingRangeType(long index)
    {
        return (BindingType)(spReflectionTypeLayout_getBindingRangeType(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), index));
    }

    public bool isBindingRangeSpecializable(int index)
    {
        return spReflectionTypeLayout_isBindingRangeSpecializable(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), index) != 0;
    }

    public long getBindingRangeBindingCount(long index)
    {
        return spReflectionTypeLayout_getBindingRangeBindingCount(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), index);
    }

    public long getFieldBindingRangeOffset(long fieldIndex)
    {
        return spReflectionTypeLayout_getFieldBindingRangeOffset(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), fieldIndex);
    }

    public long getExplicitCounterBindingRangeOffset()
    {
        return spReflectionTypeLayout_getExplicitCounterBindingRangeOffset(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)));
    }

    public TypeLayoutReflection* getBindingRangeLeafTypeLayout(long index)
    {
        return (TypeLayoutReflection*)(spReflectionTypeLayout_getBindingRangeLeafTypeLayout((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this), index));
    }

    public VariableReflection* getBindingRangeLeafVariable(long index)
    {
        return (VariableReflection*)(spReflectionTypeLayout_getBindingRangeLeafVariable((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this), index));
    }

    public SlangImageFormat getBindingRangeImageFormat(long index)
    {
        return spReflectionTypeLayout_getBindingRangeImageFormat(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), index);
    }

    public long getBindingRangeDescriptorSetIndex(long index)
    {
        return spReflectionTypeLayout_getBindingRangeDescriptorSetIndex(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), index);
    }

    public long getBindingRangeFirstDescriptorRangeIndex(long index)
    {
        return spReflectionTypeLayout_getBindingRangeFirstDescriptorRangeIndex(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), index);
    }

    public long getBindingRangeDescriptorRangeCount(long index)
    {
        return spReflectionTypeLayout_getBindingRangeDescriptorRangeCount(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), index);
    }

    public long getDescriptorSetCount()
    {
        return spReflectionTypeLayout_getDescriptorSetCount(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)));
    }

    public long getDescriptorSetSpaceOffset(long setIndex)
    {
        return spReflectionTypeLayout_getDescriptorSetSpaceOffset(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), setIndex);
    }

    public long getDescriptorSetDescriptorRangeCount(long setIndex)
    {
        return spReflectionTypeLayout_getDescriptorSetDescriptorRangeCount(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), setIndex);
    }

    public long getDescriptorSetDescriptorRangeIndexOffset(long setIndex, long rangeIndex)
    {
        return spReflectionTypeLayout_getDescriptorSetDescriptorRangeIndexOffset(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), setIndex, rangeIndex);
    }

    public long getDescriptorSetDescriptorRangeDescriptorCount(long setIndex, long rangeIndex)
    {
        return spReflectionTypeLayout_getDescriptorSetDescriptorRangeDescriptorCount(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), setIndex, rangeIndex);
    }

    public BindingType getDescriptorSetDescriptorRangeType(long setIndex, long rangeIndex)
    {
        return (BindingType)(spReflectionTypeLayout_getDescriptorSetDescriptorRangeType(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), setIndex, rangeIndex));
    }

    public ParameterCategory getDescriptorSetDescriptorRangeCategory(long setIndex, long rangeIndex)
    {
        return (ParameterCategory)(spReflectionTypeLayout_getDescriptorSetDescriptorRangeCategory(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), setIndex, rangeIndex));
    }

    public long getSubObjectRangeCount()
    {
        return spReflectionTypeLayout_getSubObjectRangeCount(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)));
    }

    public long getSubObjectRangeBindingRangeIndex(long subObjectRangeIndex)
    {
        return spReflectionTypeLayout_getSubObjectRangeBindingRangeIndex(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), subObjectRangeIndex);
    }

    public long getSubObjectRangeSpaceOffset(long subObjectRangeIndex)
    {
        return spReflectionTypeLayout_getSubObjectRangeSpaceOffset(unchecked((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this)), subObjectRangeIndex);
    }

    public VariableLayoutReflection* getSubObjectRangeOffset(long subObjectRangeIndex)
    {
        return (VariableLayoutReflection*)(spReflectionTypeLayout_getSubObjectRangeOffset((SlangReflectionTypeLayout*)Unsafe.AsPointer(ref this), subObjectRangeIndex));
    }
}

public partial struct Modifier
{

    public enum ID : uint
    {
        Shared = SLANG_MODIFIER_SHARED,
        NoDiff = SLANG_MODIFIER_NO_DIFF,
        Static = SLANG_MODIFIER_STATIC,
        Const = SLANG_MODIFIER_CONST,
        Export = SLANG_MODIFIER_EXPORT,
        Extern = SLANG_MODIFIER_EXTERN,
        Differentiable = SLANG_MODIFIER_DIFFERENTIABLE,
        Mutating = SLANG_MODIFIER_MUTATING,
        In = SLANG_MODIFIER_IN,
        Out = SLANG_MODIFIER_OUT,
        InOut = SLANG_MODIFIER_INOUT,
    }
}

public unsafe partial struct VariableReflection
{
    public sbyte* getName()
    {
        return spReflectionVariable_GetName((SlangReflectionVariable*)Unsafe.AsPointer(ref this));
    }

    public TypeReflection* getType()
    {
        return (TypeReflection*)(spReflectionVariable_GetType((SlangReflectionVariable*)Unsafe.AsPointer(ref this)));
    }

    public Modifier* findModifier(Modifier.ID id)
    {
        return (Modifier*)(spReflectionVariable_FindModifier((SlangReflectionVariable*)Unsafe.AsPointer(ref this), unchecked((SlangModifierID)(id))));
    }

    public uint getUserAttributeCount()
    {
        return spReflectionVariable_GetUserAttributeCount((SlangReflectionVariable*)Unsafe.AsPointer(ref this));
    }

    public Attribute* getUserAttributeByIndex(uint index)
    {
        return (Attribute*)(spReflectionVariable_GetUserAttribute((SlangReflectionVariable*)Unsafe.AsPointer(ref this), index));
    }

    public Attribute* findAttributeByName(IGlobalSession* globalSession, sbyte* name)
    {
        return (Attribute*)(spReflectionVariable_FindUserAttributeByName((SlangReflectionVariable*)Unsafe.AsPointer(ref this), globalSession, name));
    }

    public Attribute* findUserAttributeByName(IGlobalSession* globalSession, sbyte* name)
    {
        return findAttributeByName(globalSession, name);
    }

    public bool hasDefaultValue()
    {
        return spReflectionVariable_HasDefaultValue(unchecked((SlangReflectionVariable*)Unsafe.AsPointer(ref this))) != 0;
    }

    public int getDefaultValueInt(long* value)
    {
        return spReflectionVariable_GetDefaultValueInt(unchecked((SlangReflectionVariable*)Unsafe.AsPointer(ref this)), value);
    }

    public int getDefaultValueFloat(float* value)
    {
        return spReflectionVariable_GetDefaultValueFloat(unchecked((SlangReflectionVariable*)Unsafe.AsPointer(ref this)), value);
    }

    public GenericReflection* getGenericContainer()
    {
        return (GenericReflection*)(spReflectionVariable_GetGenericContainer((SlangReflectionVariable*)Unsafe.AsPointer(ref this)));
    }

    public VariableReflection* applySpecializations(GenericReflection* generic)
    {
        return (VariableReflection*)(spReflectionVariable_applySpecializations((SlangReflectionVariable*)Unsafe.AsPointer(ref this), (SlangReflectionGeneric*)(generic)));
    }
}

public unsafe partial struct VariableLayoutReflection
{
    public VariableReflection* getVariable()
    {
        return (VariableReflection*)(spReflectionVariableLayout_GetVariable((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this)));
    }

    public sbyte* getName()
    {
        VariableReflection* var = getVariable();
        if (var != null)
        {
            return var->getName();
        }

        return null;
    }

    public Modifier* findModifier(Modifier.ID id)
    {
        return getVariable()->findModifier(id);
    }

    public TypeLayoutReflection* getTypeLayout()
    {
        return (TypeLayoutReflection*)(spReflectionVariableLayout_GetTypeLayout((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this)));
    }

    public ParameterCategory getCategory()
    {
        return getTypeLayout()->getParameterCategory();
    }

    public uint getCategoryCount()
    {
        return getTypeLayout()->getCategoryCount();
    }

    public ParameterCategory getCategoryByIndex(uint index)
    {
        return getTypeLayout()->getCategoryByIndex(index);
    }

    public nuint getOffset(SlangParameterCategory category)
    {
        return spReflectionVariableLayout_GetOffset((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this), category);
    }

    public nuint getOffset(ParameterCategory category = ParameterCategory.Uniform)
    {
        return spReflectionVariableLayout_GetOffset((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this), unchecked((SlangParameterCategory)(category)));
    }

    public TypeReflection* getType()
    {
        return getVariable()->getType();
    }

    public uint getBindingIndex()
    {
        return spReflectionParameter_GetBindingIndex((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this));
    }

    public uint getBindingSpace()
    {
        return spReflectionParameter_GetBindingSpace((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this));
    }

    public nuint getBindingSpace(SlangParameterCategory category)
    {
        return spReflectionVariableLayout_GetSpace((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this), category);
    }

    public nuint getBindingSpace(ParameterCategory category)
    {
        return spReflectionVariableLayout_GetSpace((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this), unchecked((SlangParameterCategory)(category)));
    }

    public SlangImageFormat getImageFormat()
    {
        return spReflectionVariableLayout_GetImageFormat(unchecked((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this)));
    }

    public sbyte* getSemanticName()
    {
        return spReflectionVariableLayout_GetSemanticName((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this));
    }

    public nuint getSemanticIndex()
    {
        return spReflectionVariableLayout_GetSemanticIndex((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this));
    }

    public SlangStage getStage()
    {
        return spReflectionVariableLayout_getStage(unchecked((SlangReflectionVariableLayout*)Unsafe.AsPointer(ref this)));
    }

    public VariableLayoutReflection* getPendingDataLayout()
    {
        return null;
    }
}

public unsafe partial struct FunctionReflection
{
    public sbyte* getName()
    {
        return spReflectionFunction_GetName((SlangReflectionFunction*)Unsafe.AsPointer(ref this));
    }

    public TypeReflection* getReturnType()
    {
        return (TypeReflection*)(spReflectionFunction_GetResultType((SlangReflectionFunction*)Unsafe.AsPointer(ref this)));
    }

    public uint getParameterCount()
    {
        return spReflectionFunction_GetParameterCount((SlangReflectionFunction*)Unsafe.AsPointer(ref this));
    }

    public VariableReflection* getParameterByIndex(uint index)
    {
        return (VariableReflection*)(spReflectionFunction_GetParameter((SlangReflectionFunction*)Unsafe.AsPointer(ref this), index));
    }

    public uint getUserAttributeCount()
    {
        return spReflectionFunction_GetUserAttributeCount((SlangReflectionFunction*)Unsafe.AsPointer(ref this));
    }

    public Attribute* getUserAttributeByIndex(uint index)
    {
        return (Attribute*)(spReflectionFunction_GetUserAttribute((SlangReflectionFunction*)Unsafe.AsPointer(ref this), index));
    }

    public Attribute* findAttributeByName(IGlobalSession* globalSession, sbyte* name)
    {
        return (Attribute*)(spReflectionFunction_FindUserAttributeByName((SlangReflectionFunction*)Unsafe.AsPointer(ref this), globalSession, name));
    }

    public Attribute* findUserAttributeByName(IGlobalSession* globalSession, sbyte* name)
    {
        return findAttributeByName(globalSession, name);
    }

    public Modifier* findModifier(Modifier.ID id)
    {
        return (Modifier*)(spReflectionFunction_FindModifier((SlangReflectionFunction*)Unsafe.AsPointer(ref this), unchecked((SlangModifierID)(id))));
    }

    public GenericReflection* getGenericContainer()
    {
        return (GenericReflection*)(spReflectionFunction_GetGenericContainer((SlangReflectionFunction*)Unsafe.AsPointer(ref this)));
    }

    public FunctionReflection* applySpecializations(GenericReflection* generic)
    {
        return (FunctionReflection*)(spReflectionFunction_applySpecializations((SlangReflectionFunction*)Unsafe.AsPointer(ref this), (SlangReflectionGeneric*)(generic)));
    }

    public FunctionReflection* specializeWithArgTypes(uint argCount, TypeReflection** types)
    {
        return (FunctionReflection*)(spReflectionFunction_specializeWithArgTypes((SlangReflectionFunction*)Unsafe.AsPointer(ref this), argCount, (SlangReflectionType**)(types)));
    }

    public bool isOverloaded()
    {
        return spReflectionFunction_isOverloaded(unchecked((SlangReflectionFunction*)Unsafe.AsPointer(ref this))) != 0;
    }

    public uint getOverloadCount()
    {
        return spReflectionFunction_getOverloadCount((SlangReflectionFunction*)Unsafe.AsPointer(ref this));
    }

    public FunctionReflection* getOverload(uint index)
    {
        return (FunctionReflection*)(spReflectionFunction_getOverload((SlangReflectionFunction*)Unsafe.AsPointer(ref this), index));
    }
}

public unsafe partial struct GenericReflection
{
    public DeclReflection* asDecl()
    {
        return (DeclReflection*)(spReflectionGeneric_asDecl((SlangReflectionGeneric*)Unsafe.AsPointer(ref this)));
    }

    public sbyte* getName()
    {
        return spReflectionGeneric_GetName((SlangReflectionGeneric*)Unsafe.AsPointer(ref this));
    }

    public uint getTypeParameterCount()
    {
        return spReflectionGeneric_GetTypeParameterCount((SlangReflectionGeneric*)Unsafe.AsPointer(ref this));
    }

    public VariableReflection* getTypeParameter(uint index)
    {
        return (VariableReflection*)(spReflectionGeneric_GetTypeParameter((SlangReflectionGeneric*)Unsafe.AsPointer(ref this), index));
    }

    public uint getValueParameterCount()
    {
        return spReflectionGeneric_GetValueParameterCount((SlangReflectionGeneric*)Unsafe.AsPointer(ref this));
    }

    public VariableReflection* getValueParameter(uint index)
    {
        return (VariableReflection*)(spReflectionGeneric_GetValueParameter((SlangReflectionGeneric*)Unsafe.AsPointer(ref this), index));
    }

    public uint getTypeParameterConstraintCount(VariableReflection* typeParam)
    {
        return spReflectionGeneric_GetTypeParameterConstraintCount((SlangReflectionGeneric*)Unsafe.AsPointer(ref this), (SlangReflectionVariable*)(typeParam));
    }

    public TypeReflection* getTypeParameterConstraintType(VariableReflection* typeParam, uint index)
    {
        return (TypeReflection*)(spReflectionGeneric_GetTypeParameterConstraintType((SlangReflectionGeneric*)Unsafe.AsPointer(ref this), (SlangReflectionVariable*)(typeParam), index));
    }

    public DeclReflection* getInnerDecl()
    {
        return (DeclReflection*)(spReflectionGeneric_GetInnerDecl((SlangReflectionGeneric*)Unsafe.AsPointer(ref this)));
    }

    public SlangDeclKind getInnerKind()
    {
        return spReflectionGeneric_GetInnerKind(unchecked((SlangReflectionGeneric*)Unsafe.AsPointer(ref this)));
    }

    public GenericReflection* getOuterGenericContainer()
    {
        return (GenericReflection*)(spReflectionGeneric_GetOuterGenericContainer((SlangReflectionGeneric*)Unsafe.AsPointer(ref this)));
    }

    public TypeReflection* getConcreteType(VariableReflection* typeParam)
    {
        return (TypeReflection*)(spReflectionGeneric_GetConcreteType((SlangReflectionGeneric*)Unsafe.AsPointer(ref this), (SlangReflectionVariable*)(typeParam)));
    }

    public long getConcreteIntVal(VariableReflection* valueParam)
    {
        return spReflectionGeneric_GetConcreteIntVal(unchecked((SlangReflectionGeneric*)Unsafe.AsPointer(ref this)), unchecked((SlangReflectionVariable*)(valueParam)));
    }

    public GenericReflection* applySpecializations(GenericReflection* generic)
    {
        return (GenericReflection*)(spReflectionGeneric_applySpecializations((SlangReflectionGeneric*)Unsafe.AsPointer(ref this), (SlangReflectionGeneric*)(generic)));
    }
}

public unsafe partial struct EntryPointReflection
{
    public sbyte* getName()
    {
        return spReflectionEntryPoint_getName((SlangEntryPointLayout*)Unsafe.AsPointer(ref this));
    }

    public sbyte* getNameOverride()
    {
        return spReflectionEntryPoint_getNameOverride((SlangEntryPointLayout*)Unsafe.AsPointer(ref this));
    }

    public uint getParameterCount()
    {
        return spReflectionEntryPoint_getParameterCount((SlangEntryPointLayout*)Unsafe.AsPointer(ref this));
    }

    public FunctionReflection* getFunction()
    {
        return (FunctionReflection*)(spReflectionEntryPoint_getFunction((SlangEntryPointLayout*)Unsafe.AsPointer(ref this)));
    }

    public VariableLayoutReflection* getParameterByIndex(uint index)
    {
        return (VariableLayoutReflection*)(spReflectionEntryPoint_getParameterByIndex((SlangEntryPointLayout*)Unsafe.AsPointer(ref this), index));
    }

    public SlangStage getStage()
    {
        return spReflectionEntryPoint_getStage(unchecked((SlangEntryPointLayout*)Unsafe.AsPointer(ref this)));
    }

    public void getComputeThreadGroupSize(ulong axisCount, ulong* outSizeAlongAxis)
    {
        spReflectionEntryPoint_getComputeThreadGroupSize(unchecked((SlangEntryPointLayout*)Unsafe.AsPointer(ref this)), axisCount, outSizeAlongAxis);
    }

    public void getComputeWaveSize(ulong* outWaveSize)
    {
        spReflectionEntryPoint_getComputeWaveSize(unchecked((SlangEntryPointLayout*)Unsafe.AsPointer(ref this)), outWaveSize);
    }

    public bool usesAnySampleRateInput()
    {
        return 0 != spReflectionEntryPoint_usesAnySampleRateInput(unchecked((SlangEntryPointLayout*)Unsafe.AsPointer(ref this)));
    }

    public VariableLayoutReflection* getVarLayout()
    {
        return (VariableLayoutReflection*)(spReflectionEntryPoint_getVarLayout((SlangEntryPointLayout*)Unsafe.AsPointer(ref this)));
    }

    public TypeLayoutReflection* getTypeLayout()
    {
        return getVarLayout()->getTypeLayout();
    }

    public VariableLayoutReflection* getResultVarLayout()
    {
        return (VariableLayoutReflection*)(spReflectionEntryPoint_getResultVarLayout((SlangEntryPointLayout*)Unsafe.AsPointer(ref this)));
    }

    public bool hasDefaultConstantBuffer()
    {
        return spReflectionEntryPoint_hasDefaultConstantBuffer(unchecked((SlangEntryPointLayout*)Unsafe.AsPointer(ref this))) != 0;
    }
}

public unsafe partial struct TypeParameterReflection
{
    public sbyte* getName()
    {
        return spReflectionTypeParameter_GetName((SlangReflectionTypeParameter*)Unsafe.AsPointer(ref this));
    }

    public uint getIndex()
    {
        return spReflectionTypeParameter_GetIndex((SlangReflectionTypeParameter*)Unsafe.AsPointer(ref this));
    }

    public uint getConstraintCount()
    {
        return spReflectionTypeParameter_GetConstraintCount((SlangReflectionTypeParameter*)Unsafe.AsPointer(ref this));
    }

    public TypeReflection* getConstraintByIndex(uint index)
    {
        return (TypeReflection*)(spReflectionTypeParameter_GetConstraintByIndex((SlangReflectionTypeParameter*)Unsafe.AsPointer(ref this), index));
    }
}

public enum LayoutRules : uint
{
    Default = SLANG_LAYOUT_RULES_DEFAULT,
    MetalArgumentBufferTier2 = SLANG_LAYOUT_RULES_METAL_ARGUMENT_BUFFER_TIER_2,
    DefaultStructuredBuffer = SLANG_LAYOUT_RULES_DEFAULT_STRUCTURED_BUFFER,
    DefaultConstantBuffer = SLANG_LAYOUT_RULES_DEFAULT_CONSTANT_BUFFER,
}

public unsafe partial struct ShaderReflection
{
    public uint getParameterCount()
    {
        return spReflection_GetParameterCount((SlangProgramLayout*)Unsafe.AsPointer(ref this));
    }

    public uint getTypeParameterCount()
    {
        return spReflection_GetTypeParameterCount((SlangProgramLayout*)Unsafe.AsPointer(ref this));
    }

    public ISession* getSession()
    {
        return spReflection_GetSession((SlangProgramLayout*)Unsafe.AsPointer(ref this));
    }

    public TypeParameterReflection* getTypeParameterByIndex(uint index)
    {
        return (TypeParameterReflection*)(spReflection_GetTypeParameterByIndex((SlangProgramLayout*)Unsafe.AsPointer(ref this), index));
    }

    public TypeParameterReflection* findTypeParameter(sbyte* name)
    {
        return (TypeParameterReflection*)(spReflection_FindTypeParameter((SlangProgramLayout*)Unsafe.AsPointer(ref this), name));
    }

    public VariableLayoutReflection* getParameterByIndex(uint index)
    {
        return (VariableLayoutReflection*)(spReflection_GetParameterByIndex((SlangProgramLayout*)Unsafe.AsPointer(ref this), index));
    }

    public static ShaderReflection* get(ICompileRequest* request)
    {
        return (ShaderReflection*)(spGetReflection(request));
    }

    public ulong getEntryPointCount()
    {
        return spReflection_getEntryPointCount((SlangProgramLayout*)Unsafe.AsPointer(ref this));
    }

    public EntryPointReflection* getEntryPointByIndex(ulong index)
    {
        return (EntryPointReflection*)(spReflection_getEntryPointByIndex((SlangProgramLayout*)Unsafe.AsPointer(ref this), index));
    }

    public ulong getGlobalConstantBufferBinding()
    {
        return spReflection_getGlobalConstantBufferBinding((SlangProgramLayout*)Unsafe.AsPointer(ref this));
    }

    public nuint getGlobalConstantBufferSize()
    {
        return spReflection_getGlobalConstantBufferSize((SlangProgramLayout*)Unsafe.AsPointer(ref this));
    }

    public TypeReflection* findTypeByName(sbyte* name)
    {
        return (TypeReflection*)(spReflection_FindTypeByName((SlangProgramLayout*)Unsafe.AsPointer(ref this), name));
    }

    public FunctionReflection* findFunctionByName(sbyte* name)
    {
        return (FunctionReflection*)(spReflection_FindFunctionByName((SlangProgramLayout*)Unsafe.AsPointer(ref this), name));
    }

    public FunctionReflection* findFunctionByNameInType(TypeReflection* type, sbyte* name)
    {
        return (FunctionReflection*)(spReflection_FindFunctionByNameInType((SlangProgramLayout*)Unsafe.AsPointer(ref this), (SlangReflectionType*)(type), name));
    }

    public FunctionReflection* tryResolveOverloadedFunction(uint candidateCount, FunctionReflection** candidates)
    {
        return (FunctionReflection*)(spReflection_TryResolveOverloadedFunction((SlangProgramLayout*)Unsafe.AsPointer(ref this), candidateCount, (SlangReflectionFunction**)(candidates)));
    }

    public VariableReflection* findVarByNameInType(TypeReflection* type, sbyte* name)
    {
        return (VariableReflection*)(spReflection_FindVarByNameInType((SlangProgramLayout*)Unsafe.AsPointer(ref this), (SlangReflectionType*)(type), name));
    }

    public TypeLayoutReflection* getTypeLayout(TypeReflection* type, LayoutRules rules = Default)
    {
        return (TypeLayoutReflection*)(spReflection_GetTypeLayout((SlangProgramLayout*)Unsafe.AsPointer(ref this), (SlangReflectionType*)(type), unchecked((SlangLayoutRules)(rules))));
    }

    public EntryPointReflection* findEntryPointByName(sbyte* name)
    {
        return (EntryPointReflection*)(spReflection_findEntryPointByName((SlangProgramLayout*)Unsafe.AsPointer(ref this), name));
    }

    public TypeReflection* specializeType(TypeReflection* type, long specializationArgCount, TypeReflection** specializationArgs, ISlangBlob** outDiagnostics)
    {
        return (TypeReflection*)(spReflection_specializeType((SlangProgramLayout*)Unsafe.AsPointer(ref this), (SlangReflectionType*)(type), specializationArgCount, (SlangReflectionType**)(specializationArgs), outDiagnostics));
    }

    public GenericReflection* specializeGeneric(GenericReflection* generic, long specializationArgCount, SlangReflectionGenericArgType* specializationArgTypes, GenericArgReflection* specializationArgVals, ISlangBlob** outDiagnostics)
    {
        return (GenericReflection*)(spReflection_specializeGeneric((SlangProgramLayout*)Unsafe.AsPointer(ref this), (SlangReflectionGeneric*)(generic), specializationArgCount, (SlangReflectionGenericArgType*)(specializationArgTypes), (SlangReflectionGenericArg*)(specializationArgVals), outDiagnostics));
    }

    public bool isSubType(TypeReflection* subType, TypeReflection* superType)
    {
        return spReflection_isSubType(unchecked((SlangProgramLayout*)Unsafe.AsPointer(ref this)), unchecked((SlangReflectionType*)(subType)), unchecked((SlangReflectionType*)(superType))) != 0;
    }

    public readonly ulong getHashedStringCount()
    {
        return spReflection_getHashedStringCount((SlangProgramLayout*)Unsafe.AsPointer(ref Unsafe.AsRef(in this)));
    }

    public readonly sbyte* getHashedString(ulong index, nuint* outCount)
    {
        return spReflection_getHashedString((SlangProgramLayout*)Unsafe.AsPointer(ref Unsafe.AsRef(in this)), index, outCount);
    }

    public TypeLayoutReflection* getGlobalParamsTypeLayout()
    {
        return (TypeLayoutReflection*)(spReflection_getGlobalParamsTypeLayout((SlangProgramLayout*)Unsafe.AsPointer(ref this)));
    }

    public VariableLayoutReflection* getGlobalParamsVarLayout()
    {
        return (VariableLayoutReflection*)(spReflection_getGlobalParamsVarLayout((SlangProgramLayout*)Unsafe.AsPointer(ref this)));
    }

    public int toJson(ISlangBlob** outBlob)
    {
        return spReflection_ToJson(unchecked((SlangProgramLayout*)Unsafe.AsPointer(ref this)), null, outBlob);
    }

    public long getBindlessSpaceIndex()
    {
        return spReflection_getBindlessSpaceIndex(unchecked((SlangProgramLayout*)Unsafe.AsPointer(ref this)));
    }
}

public unsafe partial struct DeclReflection
{
    public sbyte* getName()
    {
        return spReflectionDecl_getName((SlangReflectionDecl*)Unsafe.AsPointer(ref this));
    }

    public DeclReflection.Kind getKind()
    {
        return (DeclReflection.Kind)(spReflectionDecl_getKind(unchecked((SlangReflectionDecl*)Unsafe.AsPointer(ref this))));
    }

    public uint getChildrenCount()
    {
        return spReflectionDecl_getChildrenCount((SlangReflectionDecl*)Unsafe.AsPointer(ref this));
    }

    public DeclReflection* getChild(uint index)
    {
        return (DeclReflection*)(spReflectionDecl_getChild((SlangReflectionDecl*)Unsafe.AsPointer(ref this), index));
    }

    public TypeReflection* getType()
    {
        return (TypeReflection*)(spReflection_getTypeFromDecl((SlangReflectionDecl*)Unsafe.AsPointer(ref this)));
    }

    public VariableReflection* asVariable()
    {
        return (VariableReflection*)(spReflectionDecl_castToVariable((SlangReflectionDecl*)Unsafe.AsPointer(ref this)));
    }

    public FunctionReflection* asFunction()
    {
        return (FunctionReflection*)(spReflectionDecl_castToFunction((SlangReflectionDecl*)Unsafe.AsPointer(ref this)));
    }

    public GenericReflection* asGeneric()
    {
        return (GenericReflection*)(spReflectionDecl_castToGeneric((SlangReflectionDecl*)Unsafe.AsPointer(ref this)));
    }

    public DeclReflection* getParent()
    {
        return (DeclReflection*)(spReflectionDecl_getParent((SlangReflectionDecl*)Unsafe.AsPointer(ref this)));
    }

    public Modifier* findModifier(Modifier.ID id)
    {
        return (Modifier*)(spReflectionDecl_findModifier((SlangReflectionDecl*)Unsafe.AsPointer(ref this), unchecked((SlangModifierID)(id))));
    }

    public DeclReflection.IteratedList getChildren()
    {
        return (DeclReflection.IteratedList)(new DeclReflection.IteratedList
        {
            count = getChildrenCount(),
            parent = unchecked((DeclReflection*)Unsafe.AsPointer(ref this)),
        });
    }

    public enum Kind : uint
    {
        Unsupported = SLANG_DECL_KIND_UNSUPPORTED_FOR_REFLECTION,
        Struct = SLANG_DECL_KIND_STRUCT,
        Func = SLANG_DECL_KIND_FUNC,
        Module = SLANG_DECL_KIND_MODULE,
        Generic = SLANG_DECL_KIND_GENERIC,
        Variable = SLANG_DECL_KIND_VARIABLE,
        Namespace = SLANG_DECL_KIND_NAMESPACE,
        Enum = SLANG_DECL_KIND_ENUM,
    }

    public unsafe partial struct IteratedList
    {
        public uint count;

        public DeclReflection* parent;

        public DeclReflection.IteratedList.Iterator begin()
        {
            return (DeclReflection.IteratedList.Iterator)(new DeclReflection.IteratedList.Iterator
            {
                parent = parent,
                count = count,
                index = 0,
            });
        }

        public DeclReflection.IteratedList.Iterator end()
        {
            return (DeclReflection.IteratedList.Iterator)(new DeclReflection.IteratedList.Iterator
            {
                parent = parent,
                count = count,
                index = count,
            });
        }

        public unsafe partial struct Iterator
        {
            public DeclReflection* parent;

            public uint count;

            public uint index;

            public DeclReflection* Multiply()
            {
                return parent->getChild(index);
            }

            public void Increment()
            {
                index++;
            }

            public bool NotEquals(DeclReflection.IteratedList.Iterator* other)
            {
                return index != other->index;
            }
        }
    }
}

public partial struct CompileCoreModuleFlag
{

    public enum Enum : uint
    {
        WriteDocumentation = 0x1,
    }
}

public enum BuiltinModuleName
{
    Core = 0,
    GLSL = 1,
}

public unsafe partial struct IGlobalSession
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangUUID*, void**, int>)(lpVtbl[0]))((IGlobalSession*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, uint>)(lpVtbl[1]))((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, uint>)(lpVtbl[2]))((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    public int createSession(SessionDesc* desc, ISession** outSession)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SessionDesc*, ISession**, int>)(lpVtbl[3]))((IGlobalSession*)Unsafe.AsPointer(ref this), desc, outSession);
    }

    public SlangProfileID findProfile(sbyte* name)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, SlangProfileID>)(lpVtbl[4]))((IGlobalSession*)Unsafe.AsPointer(ref this), name);
    }

    public void setDownstreamCompilerPath(SlangPassThrough passThrough, sbyte* path)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangPassThrough, sbyte*, void>)(lpVtbl[5]))((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough, path);
    }

    public void setDownstreamCompilerPrelude(SlangPassThrough passThrough, sbyte* preludeText)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangPassThrough, sbyte*, void>)(lpVtbl[6]))((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough, preludeText);
    }

    public void getDownstreamCompilerPrelude(SlangPassThrough passThrough, ISlangBlob** outPrelude)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangPassThrough, ISlangBlob**, void>)(lpVtbl[7]))((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough, outPrelude);
    }

    public sbyte* getBuildTagString()
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*>)(lpVtbl[8]))((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    public int setDefaultDownstreamCompiler(SlangSourceLanguage sourceLanguage, SlangPassThrough defaultCompiler)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangSourceLanguage, SlangPassThrough, int>)(lpVtbl[9]))((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage, defaultCompiler);
    }

    public SlangPassThrough getDefaultDownstreamCompiler(SlangSourceLanguage sourceLanguage)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangSourceLanguage, SlangPassThrough>)(lpVtbl[10]))((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage);
    }

    public void setLanguagePrelude(SlangSourceLanguage sourceLanguage, sbyte* preludeText)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangSourceLanguage, sbyte*, void>)(lpVtbl[11]))((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage, preludeText);
    }

    public void getLanguagePrelude(SlangSourceLanguage sourceLanguage, ISlangBlob** outPrelude)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangSourceLanguage, ISlangBlob**, void>)(lpVtbl[12]))((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage, outPrelude);
    }

    public int createCompileRequest(ICompileRequest** outCompileRequest)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, ICompileRequest**, int>)(lpVtbl[13]))((IGlobalSession*)Unsafe.AsPointer(ref this), outCompileRequest);
    }

    public void addBuiltins(sbyte* sourcePath, sbyte* sourceString)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, sbyte*, void>)(lpVtbl[14]))((IGlobalSession*)Unsafe.AsPointer(ref this), sourcePath, sourceString);
    }

    public void setSharedLibraryLoader(ISlangSharedLibraryLoader* loader)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, ISlangSharedLibraryLoader*, void>)(lpVtbl[15]))((IGlobalSession*)Unsafe.AsPointer(ref this), loader);
    }

    public ISlangSharedLibraryLoader* getSharedLibraryLoader()
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, ISlangSharedLibraryLoader*>)(lpVtbl[16]))((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    public int checkCompileTargetSupport(SlangCompileTarget target)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangCompileTarget, int>)(lpVtbl[17]))((IGlobalSession*)Unsafe.AsPointer(ref this), target);
    }

    public int checkPassThroughSupport(SlangPassThrough passThrough)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangPassThrough, int>)(lpVtbl[18]))((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough);
    }

    public int compileCoreModule(uint flags)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, uint, int>)(lpVtbl[19]))((IGlobalSession*)Unsafe.AsPointer(ref this), flags);
    }

    public int loadCoreModule(void* coreModule, nuint coreModuleSizeInBytes)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, void*, nuint, int>)(lpVtbl[20]))((IGlobalSession*)Unsafe.AsPointer(ref this), coreModule, coreModuleSizeInBytes);
    }

    public int saveCoreModule(SlangArchiveType archiveType, ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangArchiveType, ISlangBlob**, int>)(lpVtbl[21]))((IGlobalSession*)Unsafe.AsPointer(ref this), archiveType, outBlob);
    }

    public SlangCapabilityID findCapability(sbyte* name)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, SlangCapabilityID>)(lpVtbl[22]))((IGlobalSession*)Unsafe.AsPointer(ref this), name);
    }

    public void setDownstreamCompilerForTransition(SlangCompileTarget source, SlangCompileTarget target, SlangPassThrough compiler)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangCompileTarget, SlangCompileTarget, SlangPassThrough, void>)(lpVtbl[23]))((IGlobalSession*)Unsafe.AsPointer(ref this), source, target, compiler);
    }

    public SlangPassThrough getDownstreamCompilerForTransition(SlangCompileTarget source, SlangCompileTarget target)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangCompileTarget, SlangCompileTarget, SlangPassThrough>)(lpVtbl[24]))((IGlobalSession*)Unsafe.AsPointer(ref this), source, target);
    }

    public void getCompilerElapsedTime(double* outTotalTime, double* outDownstreamTime)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, double*, double*, void>)(lpVtbl[25]))((IGlobalSession*)Unsafe.AsPointer(ref this), outTotalTime, outDownstreamTime);
    }

    public int setSPIRVCoreGrammar(sbyte* jsonPath)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, int>)(lpVtbl[26]))((IGlobalSession*)Unsafe.AsPointer(ref this), jsonPath);
    }

    public int parseCommandLineArguments(int argc, sbyte** argv, SessionDesc* outSessionDesc, ISlangUnknown** outAuxAllocation)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, int, sbyte**, SessionDesc*, ISlangUnknown**, int>)(lpVtbl[27]))((IGlobalSession*)Unsafe.AsPointer(ref this), argc, argv, outSessionDesc, outAuxAllocation);
    }

    public int getSessionDescDigest(SessionDesc* sessionDesc, ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SessionDesc*, ISlangBlob**, int>)(lpVtbl[28]))((IGlobalSession*)Unsafe.AsPointer(ref this), sessionDesc, outBlob);
    }

    public int compileBuiltinModule(BuiltinModuleName module, uint flags)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, BuiltinModuleName, uint, int>)(lpVtbl[29]))((IGlobalSession*)Unsafe.AsPointer(ref this), module, flags);
    }

    public int loadBuiltinModule(BuiltinModuleName module, void* moduleData, nuint sizeInBytes)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, BuiltinModuleName, void*, nuint, int>)(lpVtbl[30]))((IGlobalSession*)Unsafe.AsPointer(ref this), module, moduleData, sizeInBytes);
    }

    public int saveBuiltinModule(BuiltinModuleName module, SlangArchiveType archiveType, ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, BuiltinModuleName, SlangArchiveType, ISlangBlob**, int>)(lpVtbl[31]))((IGlobalSession*)Unsafe.AsPointer(ref this), module, archiveType, outBlob);
    }
}

public unsafe partial struct TargetDesc
{
    public nuint structureSize;

    public SlangCompileTarget format;

    public SlangProfileID profile;

    public uint flags;

    public SlangFloatingPointMode floatingPointMode;

    public SlangLineDirectiveMode lineDirectiveMode;

    public byte forceGLSLScalarBufferLayout;

    public CompilerOptionEntry* compilerOptionEntries;

    public uint compilerOptionEntryCount;
}

public unsafe partial struct PreprocessorMacroDesc
{
    public sbyte* name;

    public sbyte* value;
}

public unsafe partial struct SessionDesc
{
    public nuint structureSize;

    public TargetDesc* targets;

    public long targetCount;

    public uint flags;

    public SlangMatrixLayoutMode defaultMatrixLayoutMode;

    public sbyte** searchPaths;

    public long searchPathCount;

    public PreprocessorMacroDesc* preprocessorMacros;

    public long preprocessorMacroCount;

    public ISlangFileSystem* fileSystem;

    public byte enableEffectAnnotations;

    public byte allowGLSLSyntax;

    public CompilerOptionEntry* compilerOptionEntries;

    public uint compilerOptionEntryCount;

    public byte skipSPIRVValidation;
}

public enum ContainerType
{
    None = 0,
    UnsizedArray = 1,
    StructuredBuffer = 2,
    ConstantBuffer = 3,
    ParameterBlock = 4,
}

public unsafe partial struct SourceLocation
{
    public sbyte* filePath;

    public long line;

    public long column;
}

public unsafe partial struct ISession
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISession*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, uint>)(lpVtbl[1]))((ISession*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, uint>)(lpVtbl[2]))((ISession*)Unsafe.AsPointer(ref this));
    }

    public IGlobalSession* getGlobalSession()
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, IGlobalSession*>)(lpVtbl[3]))((ISession*)Unsafe.AsPointer(ref this));
    }

    public IModule* loadModule(sbyte* moduleName, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, sbyte*, ISlangBlob**, IModule*>)(lpVtbl[4]))((ISession*)Unsafe.AsPointer(ref this), moduleName, outDiagnostics);
    }

    public IModule* loadModuleFromSource(sbyte* moduleName, sbyte* path, ISlangBlob* source, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, sbyte*, sbyte*, ISlangBlob*, ISlangBlob**, IModule*>)(lpVtbl[5]))((ISession*)Unsafe.AsPointer(ref this), moduleName, path, source, outDiagnostics);
    }

    public int createCompositeComponentType(IComponentType** componentTypes, long componentTypeCount, IComponentType** outCompositeComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, IComponentType**, long, IComponentType**, ISlangBlob**, int>)(lpVtbl[6]))((ISession*)Unsafe.AsPointer(ref this), componentTypes, componentTypeCount, outCompositeComponentType, outDiagnostics);
    }

    public TypeReflection* specializeType(TypeReflection* type, SpecializationArg* specializationArgs, long specializationArgCount, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, SpecializationArg*, long, ISlangBlob**, TypeReflection*>)(lpVtbl[7]))((ISession*)Unsafe.AsPointer(ref this), type, specializationArgs, specializationArgCount, outDiagnostics);
    }

    public TypeLayoutReflection* getTypeLayout(TypeReflection* type, long targetIndex = 0, LayoutRules rules = Default, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, long, LayoutRules, ISlangBlob**, TypeLayoutReflection*>)(lpVtbl[8]))((ISession*)Unsafe.AsPointer(ref this), type, targetIndex, rules, outDiagnostics);
    }

    public TypeReflection* getContainerType(TypeReflection* elementType, ContainerType containerType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, ContainerType, ISlangBlob**, TypeReflection*>)(lpVtbl[9]))((ISession*)Unsafe.AsPointer(ref this), elementType, containerType, outDiagnostics);
    }

    public TypeReflection* getDynamicType()
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, TypeReflection*>)(lpVtbl[10]))((ISession*)Unsafe.AsPointer(ref this));
    }

    public int getTypeRTTIMangledName(TypeReflection* type, ISlangBlob** outNameBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, ISlangBlob**, int>)(lpVtbl[11]))((ISession*)Unsafe.AsPointer(ref this), type, outNameBlob);
    }

    public int getTypeConformanceWitnessMangledName(TypeReflection* type, TypeReflection* interfaceType, ISlangBlob** outNameBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, TypeReflection*, ISlangBlob**, int>)(lpVtbl[12]))((ISession*)Unsafe.AsPointer(ref this), type, interfaceType, outNameBlob);
    }

    public int getTypeConformanceWitnessSequentialID(TypeReflection* type, TypeReflection* interfaceType, uint* outId)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, TypeReflection*, uint*, int>)(lpVtbl[13]))((ISession*)Unsafe.AsPointer(ref this), type, interfaceType, outId);
    }

    public int createCompileRequest(ICompileRequest** outCompileRequest)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, ICompileRequest**, int>)(lpVtbl[14]))((ISession*)Unsafe.AsPointer(ref this), outCompileRequest);
    }

    public int createTypeConformanceComponentType(TypeReflection* type, TypeReflection* interfaceType, ITypeConformance** outConformance, long conformanceIdOverride, ISlangBlob** outDiagnostics)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, TypeReflection*, ITypeConformance**, long, ISlangBlob**, int>)(lpVtbl[15]))((ISession*)Unsafe.AsPointer(ref this), type, interfaceType, outConformance, conformanceIdOverride, outDiagnostics);
    }

    public IModule* loadModuleFromIRBlob(sbyte* moduleName, sbyte* path, ISlangBlob* source, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, sbyte*, sbyte*, ISlangBlob*, ISlangBlob**, IModule*>)(lpVtbl[16]))((ISession*)Unsafe.AsPointer(ref this), moduleName, path, source, outDiagnostics);
    }

    public long getLoadedModuleCount()
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, long>)(lpVtbl[17]))((ISession*)Unsafe.AsPointer(ref this));
    }

    public IModule* getLoadedModule(long index)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, long, IModule*>)(lpVtbl[18]))((ISession*)Unsafe.AsPointer(ref this), index);
    }

    public bool isBinaryModuleUpToDate(sbyte* modulePath, ISlangBlob* binaryModuleBlob)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, sbyte*, ISlangBlob*, byte>)(lpVtbl[19]))((ISession*)Unsafe.AsPointer(ref this), modulePath, binaryModuleBlob) != 0;
    }

    public IModule* loadModuleFromSourceString(sbyte* moduleName, sbyte* path, sbyte* @string, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, sbyte*, sbyte*, sbyte*, ISlangBlob**, IModule*>)(lpVtbl[20]))((ISession*)Unsafe.AsPointer(ref this), moduleName, path, @string, outDiagnostics);
    }

    public int getDynamicObjectRTTIBytes(TypeReflection* type, TypeReflection* interfaceType, uint* outRTTIDataBuffer, uint bufferSizeInBytes)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, TypeReflection*, uint*, uint, int>)(lpVtbl[21]))((ISession*)Unsafe.AsPointer(ref this), type, interfaceType, outRTTIDataBuffer, bufferSizeInBytes);
    }

    public int loadModuleInfoFromIRBlob(ISlangBlob* source, long* outModuleVersion, sbyte** outModuleCompilerVersion, sbyte** outModuleName)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, ISlangBlob*, long*, sbyte**, sbyte**, int>)(lpVtbl[22]))((ISession*)Unsafe.AsPointer(ref this), source, outModuleVersion, outModuleCompilerVersion, outModuleName);
    }

    public int getDeclSourceLocation(DeclReflection* decl, SourceLocation* outLocation)
    {
        return ((delegate* unmanaged[Stdcall]<ISession*, DeclReflection*, SourceLocation*, int>)(lpVtbl[23]))((ISession*)Unsafe.AsPointer(ref this), decl, outLocation);
    }
}

public unsafe partial struct IMetadata
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IMetadata*, SlangUUID*, void**, int>)(lpVtbl[0]))((IMetadata*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IMetadata*, uint>)(lpVtbl[1]))((IMetadata*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IMetadata*, uint>)(lpVtbl[2]))((IMetadata*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<IMetadata*, SlangUUID*, void*>)(lpVtbl[3]))((IMetadata*)Unsafe.AsPointer(ref this), guid);
    }

    public int isParameterLocationUsed(SlangParameterCategory category, ulong spaceIndex, ulong registerIndex, bool* outUsed)
    {
        return ((delegate* unmanaged[Thiscall]<IMetadata*, SlangParameterCategory, ulong, ulong, bool*, int>)(lpVtbl[4]))((IMetadata*)Unsafe.AsPointer(ref this), category, spaceIndex, registerIndex, outUsed);
    }

    public sbyte* getDebugBuildIdentifier()
    {
        return ((delegate* unmanaged[Stdcall]<IMetadata*, sbyte*>)(lpVtbl[5]))((IMetadata*)Unsafe.AsPointer(ref this));
    }
}

public unsafe partial struct IBindlessResourceMetadata
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IBindlessResourceMetadata*, SlangUUID*, void**, int>)(lpVtbl[0]))((IBindlessResourceMetadata*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IBindlessResourceMetadata*, uint>)(lpVtbl[1]))((IBindlessResourceMetadata*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IBindlessResourceMetadata*, uint>)(lpVtbl[2]))((IBindlessResourceMetadata*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<IBindlessResourceMetadata*, SlangUUID*, void*>)(lpVtbl[3]))((IBindlessResourceMetadata*)Unsafe.AsPointer(ref this), guid);
    }

    public bool usesBindlessResourceHeap()
    {
        return ((delegate* unmanaged[Stdcall]<IBindlessResourceMetadata*, byte>)(lpVtbl[4]))((IBindlessResourceMetadata*)Unsafe.AsPointer(ref this)) != 0;
    }
}

public enum CoverageEntryKind : uint
{
    Unknown = 0,
    Line = 1,
    Branch = 2,
    Function = 3,
    Region = 4,
}

public enum CoverageCounterMode : uint
{
    Count = 0,
    Boolean = 1,
}

public enum CoverageBranchArmKind : uint
{
    Unknown = 0,
    TrueArm = 1,
    FalseArm = 2,
    CaseArm = 3,
    DefaultArm = 4,
}

public unsafe partial struct CoverageEntryInfo
{
    public nuint structSize;

    public sbyte* file;

    public uint line;

    public uint counterIndex;

    public CoverageEntryKind kind;

    public CoverageCounterMode counterMode;

    public uint startColumn;

    public uint endLine;

    public uint endColumn;

    public sbyte* functionName;

    public sbyte* functionMangledName;

    public uint branchSiteID;

    public uint branchArmID;

    public CoverageBranchArmKind branchArmKind;
}

public partial struct CoverageBufferInfo
{
    public nuint structSize;

    public int space;

    public int binding;

    public uint elementByteWidth;
}

public unsafe partial struct ICoverageTracingMetadata
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ICoverageTracingMetadata*, SlangUUID*, void**, int>)(lpVtbl[0]))((ICoverageTracingMetadata*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ICoverageTracingMetadata*, uint>)(lpVtbl[1]))((ICoverageTracingMetadata*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ICoverageTracingMetadata*, uint>)(lpVtbl[2]))((ICoverageTracingMetadata*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ICoverageTracingMetadata*, SlangUUID*, void*>)(lpVtbl[3]))((ICoverageTracingMetadata*)Unsafe.AsPointer(ref this), guid);
    }

    public uint getCounterCount()
    {
        return ((delegate* unmanaged[Stdcall]<ICoverageTracingMetadata*, uint>)(lpVtbl[4]))((ICoverageTracingMetadata*)Unsafe.AsPointer(ref this));
    }

    public int getEntryInfo(uint index, CoverageEntryInfo* outInfo)
    {
        return ((delegate* unmanaged[Stdcall]<ICoverageTracingMetadata*, uint, CoverageEntryInfo*, int>)(lpVtbl[5]))((ICoverageTracingMetadata*)Unsafe.AsPointer(ref this), index, outInfo);
    }

    public int getBufferInfo(CoverageBufferInfo* outInfo)
    {
        return ((delegate* unmanaged[Stdcall]<ICoverageTracingMetadata*, CoverageBufferInfo*, int>)(lpVtbl[6]))((ICoverageTracingMetadata*)Unsafe.AsPointer(ref this), outInfo);
    }

    public uint getEntryCount()
    {
        return ((delegate* unmanaged[Stdcall]<ICoverageTracingMetadata*, uint>)(lpVtbl[7]))((ICoverageTracingMetadata*)Unsafe.AsPointer(ref this));
    }
}

public enum SyntheticResourceScope : uint
{
    Global = 0,
    EntryPoint = 1,
}

public enum SyntheticResourceAccess : uint
{
    Read = 0,
    Write = 1,
    ReadWrite = 2,
}

public unsafe partial struct SyntheticResourceInfo
{
    public nuint structSize;

    public uint id;

    public BindingType bindingType;

    public uint arraySize;

    public SyntheticResourceScope scope;

    public SyntheticResourceAccess access;

    public int entryPointIndex;

    public int space;

    public int binding;

    public int uniformOffset;

    public int uniformStride;

    public sbyte* debugName;
}

public unsafe partial struct ISyntheticResourceMetadata
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISyntheticResourceMetadata*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISyntheticResourceMetadata*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISyntheticResourceMetadata*, uint>)(lpVtbl[1]))((ISyntheticResourceMetadata*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISyntheticResourceMetadata*, uint>)(lpVtbl[2]))((ISyntheticResourceMetadata*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ISyntheticResourceMetadata*, SlangUUID*, void*>)(lpVtbl[3]))((ISyntheticResourceMetadata*)Unsafe.AsPointer(ref this), guid);
    }

    public uint getResourceCount()
    {
        return ((delegate* unmanaged[Stdcall]<ISyntheticResourceMetadata*, uint>)(lpVtbl[4]))((ISyntheticResourceMetadata*)Unsafe.AsPointer(ref this));
    }

    public int getResourceInfo(uint index, SyntheticResourceInfo* outInfo)
    {
        return ((delegate* unmanaged[Stdcall]<ISyntheticResourceMetadata*, uint, SyntheticResourceInfo*, int>)(lpVtbl[5]))((ISyntheticResourceMetadata*)Unsafe.AsPointer(ref this), index, outInfo);
    }

    public int findResourceIndexByID(uint id, uint* outIndex)
    {
        return ((delegate* unmanaged[Stdcall]<ISyntheticResourceMetadata*, uint, uint*, int>)(lpVtbl[6]))((ISyntheticResourceMetadata*)Unsafe.AsPointer(ref this), id, outIndex);
    }
}

public partial struct CooperativeMatrixType
{
    public SlangScalarType componentType;

    public SlangScope scope;

    public uint rowCount;

    public uint columnCount;

    public SlangCooperativeMatrixUse use;
}

public partial struct CooperativeMatrixCombination
{
    public uint m;

    public uint n;

    public uint k;

    public SlangScalarType componentTypeA;

    public SlangScalarType componentTypeB;

    public SlangScalarType componentTypeC;

    public SlangScalarType componentTypeResult;

    public byte saturate;

    public SlangScope scope;
}

public partial struct CooperativeVectorTypeUsageInfo
{
    public SlangScalarType componentType;

    public uint maxSize;

    public byte usedForTrainingOp;
}

public partial struct CooperativeVectorCombination
{
    public SlangScalarType inputType;

    public SlangScalarType inputInterpretation;

    public uint inputPackingFactor;

    public SlangScalarType matrixInterpretation;

    public SlangScalarType biasInterpretation;

    public SlangScalarType resultType;

    public byte transpose;
}

public unsafe partial struct ICooperativeTypesMetadata
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, SlangUUID*, void**, int>)(lpVtbl[0]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, uint>)(lpVtbl[1]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, uint>)(lpVtbl[2]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, SlangUUID*, void*>)(lpVtbl[3]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this), guid);
    }

    public ulong getCooperativeMatrixTypeCount()
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, ulong>)(lpVtbl[4]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this));
    }

    public int getCooperativeMatrixTypeByIndex(ulong index, CooperativeMatrixType* outType)
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, ulong, CooperativeMatrixType*, int>)(lpVtbl[5]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this), index, outType);
    }

    public ulong getCooperativeMatrixCombinationCount()
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, ulong>)(lpVtbl[6]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this));
    }

    public int getCooperativeMatrixCombinationByIndex(ulong index, CooperativeMatrixCombination* outCombination)
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, ulong, CooperativeMatrixCombination*, int>)(lpVtbl[7]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this), index, outCombination);
    }

    public ulong getCooperativeVectorTypeCount()
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, ulong>)(lpVtbl[8]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this));
    }

    public int getCooperativeVectorTypeByIndex(ulong index, CooperativeVectorTypeUsageInfo* outType)
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, ulong, CooperativeVectorTypeUsageInfo*, int>)(lpVtbl[9]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this), index, outType);
    }

    public ulong getCooperativeVectorCombinationCount()
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, ulong>)(lpVtbl[10]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this));
    }

    public int getCooperativeVectorCombinationByIndex(ulong index, CooperativeVectorCombination* outCombination)
    {
        return ((delegate* unmanaged[Stdcall]<ICooperativeTypesMetadata*, ulong, CooperativeVectorCombination*, int>)(lpVtbl[11]))((ICooperativeTypesMetadata*)Unsafe.AsPointer(ref this), index, outCombination);
    }
}

public unsafe partial struct ICompileResult
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileResult*, SlangUUID*, void**, int>)(lpVtbl[0]))((ICompileResult*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileResult*, uint>)(lpVtbl[1]))((ICompileResult*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileResult*, uint>)(lpVtbl[2]))((ICompileResult*)Unsafe.AsPointer(ref this));
    }

    public void* castAs(SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileResult*, SlangUUID*, void*>)(lpVtbl[3]))((ICompileResult*)Unsafe.AsPointer(ref this), guid);
    }

    public uint getItemCount()
    {
        return ((delegate* unmanaged[Stdcall]<ICompileResult*, uint>)(lpVtbl[4]))((ICompileResult*)Unsafe.AsPointer(ref this));
    }

    public int getItemData(uint index, ISlangBlob** outblob)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileResult*, uint, ISlangBlob**, int>)(lpVtbl[5]))((ICompileResult*)Unsafe.AsPointer(ref this), index, outblob);
    }

    public int getMetadata(IMetadata** outMetadata)
    {
        return ((delegate* unmanaged[Stdcall]<ICompileResult*, IMetadata**, int>)(lpVtbl[6]))((ICompileResult*)Unsafe.AsPointer(ref this), outMetadata);
    }
}

public unsafe partial struct IComponentType
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, SlangUUID*, void**, int>)(lpVtbl[0]))((IComponentType*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, uint>)(lpVtbl[1]))((IComponentType*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, uint>)(lpVtbl[2]))((IComponentType*)Unsafe.AsPointer(ref this));
    }

    public ISession* getSession()
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, ISession*>)(lpVtbl[3]))((IComponentType*)Unsafe.AsPointer(ref this));
    }

    public ShaderReflection* getLayout(long targetIndex = 0, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, long, ISlangBlob**, ShaderReflection*>)(lpVtbl[4]))((IComponentType*)Unsafe.AsPointer(ref this), targetIndex, outDiagnostics);
    }

    public long getSpecializationParamCount()
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, long>)(lpVtbl[5]))((IComponentType*)Unsafe.AsPointer(ref this));
    }

    public int getEntryPointCode(long entryPointIndex, long targetIndex, ISlangBlob** outCode, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, long, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[6]))((IComponentType*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outCode, outDiagnostics);
    }

    public int getResultAsFileSystem(long entryPointIndex, long targetIndex, ISlangMutableFileSystem** outFileSystem)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, long, long, ISlangMutableFileSystem**, int>)(lpVtbl[7]))((IComponentType*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outFileSystem);
    }

    public void getEntryPointHash(long entryPointIndex, long targetIndex, ISlangBlob** outHash)
    {
        ((delegate* unmanaged[Stdcall]<IComponentType*, long, long, ISlangBlob**, void>)(lpVtbl[8]))((IComponentType*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outHash);
    }

    public int specialize(SpecializationArg* specializationArgs, long specializationArgCount, IComponentType** outSpecializedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, SpecializationArg*, long, IComponentType**, ISlangBlob**, int>)(lpVtbl[9]))((IComponentType*)Unsafe.AsPointer(ref this), specializationArgs, specializationArgCount, outSpecializedComponentType, outDiagnostics);
    }

    public int link(IComponentType** outLinkedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, IComponentType**, ISlangBlob**, int>)(lpVtbl[10]))((IComponentType*)Unsafe.AsPointer(ref this), outLinkedComponentType, outDiagnostics);
    }

    public int getEntryPointHostCallable(int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, int, int, ISlangSharedLibrary**, ISlangBlob**, int>)(lpVtbl[11]))((IComponentType*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outSharedLibrary, outDiagnostics);
    }

    public int renameEntryPoint(sbyte* newName, IComponentType** outEntryPoint)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, sbyte*, IComponentType**, int>)(lpVtbl[12]))((IComponentType*)Unsafe.AsPointer(ref this), newName, outEntryPoint);
    }

    public int linkWithOptions(IComponentType** outLinkedComponentType, uint compilerOptionEntryCount, CompilerOptionEntry* compilerOptionEntries, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, IComponentType**, uint, CompilerOptionEntry*, ISlangBlob**, int>)(lpVtbl[13]))((IComponentType*)Unsafe.AsPointer(ref this), outLinkedComponentType, compilerOptionEntryCount, compilerOptionEntries, outDiagnostics);
    }

    public int getTargetCode(long targetIndex, ISlangBlob** outCode, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[14]))((IComponentType*)Unsafe.AsPointer(ref this), targetIndex, outCode, outDiagnostics);
    }

    public int getTargetMetadata(long targetIndex, IMetadata** outMetadata, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[15]))((IComponentType*)Unsafe.AsPointer(ref this), targetIndex, outMetadata, outDiagnostics);
    }

    public int getEntryPointMetadata(long entryPointIndex, long targetIndex, IMetadata** outMetadata, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType*, long, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[16]))((IComponentType*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outMetadata, outDiagnostics);
    }
}

public unsafe partial struct IEntryPoint
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, SlangUUID*, void**, int>)(lpVtbl[0]))((IEntryPoint*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, uint>)(lpVtbl[1]))((IEntryPoint*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, uint>)(lpVtbl[2]))((IEntryPoint*)Unsafe.AsPointer(ref this));
    }

    public ISession* getSession()
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, ISession*>)(lpVtbl[3]))((IEntryPoint*)Unsafe.AsPointer(ref this));
    }

    public ShaderReflection* getLayout(long targetIndex = 0, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, long, ISlangBlob**, ShaderReflection*>)(lpVtbl[4]))((IEntryPoint*)Unsafe.AsPointer(ref this), targetIndex, outDiagnostics);
    }

    public long getSpecializationParamCount()
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, long>)(lpVtbl[5]))((IEntryPoint*)Unsafe.AsPointer(ref this));
    }

    public int getEntryPointCode(long entryPointIndex, long targetIndex, ISlangBlob** outCode, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, long, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[6]))((IEntryPoint*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outCode, outDiagnostics);
    }

    public int getResultAsFileSystem(long entryPointIndex, long targetIndex, ISlangMutableFileSystem** outFileSystem)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, long, long, ISlangMutableFileSystem**, int>)(lpVtbl[7]))((IEntryPoint*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outFileSystem);
    }

    public void getEntryPointHash(long entryPointIndex, long targetIndex, ISlangBlob** outHash)
    {
        ((delegate* unmanaged[Stdcall]<IEntryPoint*, long, long, ISlangBlob**, void>)(lpVtbl[8]))((IEntryPoint*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outHash);
    }

    public int specialize(SpecializationArg* specializationArgs, long specializationArgCount, IComponentType** outSpecializedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, SpecializationArg*, long, IComponentType**, ISlangBlob**, int>)(lpVtbl[9]))((IEntryPoint*)Unsafe.AsPointer(ref this), specializationArgs, specializationArgCount, outSpecializedComponentType, outDiagnostics);
    }

    public int link(IComponentType** outLinkedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, IComponentType**, ISlangBlob**, int>)(lpVtbl[10]))((IEntryPoint*)Unsafe.AsPointer(ref this), outLinkedComponentType, outDiagnostics);
    }

    public int getEntryPointHostCallable(int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, int, int, ISlangSharedLibrary**, ISlangBlob**, int>)(lpVtbl[11]))((IEntryPoint*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outSharedLibrary, outDiagnostics);
    }

    public int renameEntryPoint(sbyte* newName, IComponentType** outEntryPoint)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, sbyte*, IComponentType**, int>)(lpVtbl[12]))((IEntryPoint*)Unsafe.AsPointer(ref this), newName, outEntryPoint);
    }

    public int linkWithOptions(IComponentType** outLinkedComponentType, uint compilerOptionEntryCount, CompilerOptionEntry* compilerOptionEntries, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, IComponentType**, uint, CompilerOptionEntry*, ISlangBlob**, int>)(lpVtbl[13]))((IEntryPoint*)Unsafe.AsPointer(ref this), outLinkedComponentType, compilerOptionEntryCount, compilerOptionEntries, outDiagnostics);
    }

    public int getTargetCode(long targetIndex, ISlangBlob** outCode, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[14]))((IEntryPoint*)Unsafe.AsPointer(ref this), targetIndex, outCode, outDiagnostics);
    }

    public int getTargetMetadata(long targetIndex, IMetadata** outMetadata, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[15]))((IEntryPoint*)Unsafe.AsPointer(ref this), targetIndex, outMetadata, outDiagnostics);
    }

    public int getEntryPointMetadata(long entryPointIndex, long targetIndex, IMetadata** outMetadata, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, long, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[16]))((IEntryPoint*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outMetadata, outDiagnostics);
    }

    public FunctionReflection* getFunctionReflection()
    {
        return ((delegate* unmanaged[Stdcall]<IEntryPoint*, FunctionReflection*>)(lpVtbl[17]))((IEntryPoint*)Unsafe.AsPointer(ref this));
    }
}

public unsafe partial struct ITypeConformance
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, SlangUUID*, void**, int>)(lpVtbl[0]))((ITypeConformance*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, uint>)(lpVtbl[1]))((ITypeConformance*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, uint>)(lpVtbl[2]))((ITypeConformance*)Unsafe.AsPointer(ref this));
    }

    public ISession* getSession()
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, ISession*>)(lpVtbl[3]))((ITypeConformance*)Unsafe.AsPointer(ref this));
    }

    public ShaderReflection* getLayout(long targetIndex = 0, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, ISlangBlob**, ShaderReflection*>)(lpVtbl[4]))((ITypeConformance*)Unsafe.AsPointer(ref this), targetIndex, outDiagnostics);
    }

    public long getSpecializationParamCount()
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long>)(lpVtbl[5]))((ITypeConformance*)Unsafe.AsPointer(ref this));
    }

    public int getEntryPointCode(long entryPointIndex, long targetIndex, ISlangBlob** outCode, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[6]))((ITypeConformance*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outCode, outDiagnostics);
    }

    public int getResultAsFileSystem(long entryPointIndex, long targetIndex, ISlangMutableFileSystem** outFileSystem)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, ISlangMutableFileSystem**, int>)(lpVtbl[7]))((ITypeConformance*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outFileSystem);
    }

    public void getEntryPointHash(long entryPointIndex, long targetIndex, ISlangBlob** outHash)
    {
        ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, ISlangBlob**, void>)(lpVtbl[8]))((ITypeConformance*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outHash);
    }

    public int specialize(SpecializationArg* specializationArgs, long specializationArgCount, IComponentType** outSpecializedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, SpecializationArg*, long, IComponentType**, ISlangBlob**, int>)(lpVtbl[9]))((ITypeConformance*)Unsafe.AsPointer(ref this), specializationArgs, specializationArgCount, outSpecializedComponentType, outDiagnostics);
    }

    public int link(IComponentType** outLinkedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, IComponentType**, ISlangBlob**, int>)(lpVtbl[10]))((ITypeConformance*)Unsafe.AsPointer(ref this), outLinkedComponentType, outDiagnostics);
    }

    public int getEntryPointHostCallable(int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, int, int, ISlangSharedLibrary**, ISlangBlob**, int>)(lpVtbl[11]))((ITypeConformance*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outSharedLibrary, outDiagnostics);
    }

    public int renameEntryPoint(sbyte* newName, IComponentType** outEntryPoint)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, sbyte*, IComponentType**, int>)(lpVtbl[12]))((ITypeConformance*)Unsafe.AsPointer(ref this), newName, outEntryPoint);
    }

    public int linkWithOptions(IComponentType** outLinkedComponentType, uint compilerOptionEntryCount, CompilerOptionEntry* compilerOptionEntries, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, IComponentType**, uint, CompilerOptionEntry*, ISlangBlob**, int>)(lpVtbl[13]))((ITypeConformance*)Unsafe.AsPointer(ref this), outLinkedComponentType, compilerOptionEntryCount, compilerOptionEntries, outDiagnostics);
    }

    public int getTargetCode(long targetIndex, ISlangBlob** outCode, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[14]))((ITypeConformance*)Unsafe.AsPointer(ref this), targetIndex, outCode, outDiagnostics);
    }

    public int getTargetMetadata(long targetIndex, IMetadata** outMetadata, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[15]))((ITypeConformance*)Unsafe.AsPointer(ref this), targetIndex, outMetadata, outDiagnostics);
    }

    public int getEntryPointMetadata(long entryPointIndex, long targetIndex, IMetadata** outMetadata, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[16]))((ITypeConformance*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outMetadata, outDiagnostics);
    }
}

public unsafe partial struct IComponentType2
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType2*, SlangUUID*, void**, int>)(lpVtbl[0]))((IComponentType2*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType2*, uint>)(lpVtbl[1]))((IComponentType2*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType2*, uint>)(lpVtbl[2]))((IComponentType2*)Unsafe.AsPointer(ref this));
    }

    public int getTargetCompileResult(long targetIndex, ICompileResult** outCompileResult, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType2*, long, ICompileResult**, ISlangBlob**, int>)(lpVtbl[3]))((IComponentType2*)Unsafe.AsPointer(ref this), targetIndex, outCompileResult, outDiagnostics);
    }

    public int getEntryPointCompileResult(long entryPointIndex, long targetIndex, ICompileResult** outCompileResult, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType2*, long, long, ICompileResult**, ISlangBlob**, int>)(lpVtbl[4]))((IComponentType2*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outCompileResult, outDiagnostics);
    }

    public int getTargetHostCallable(int targetIndex, ISlangSharedLibrary** outSharedLibrary, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IComponentType2*, int, ISlangSharedLibrary**, ISlangBlob**, int>)(lpVtbl[5]))((IComponentType2*)Unsafe.AsPointer(ref this), targetIndex, outSharedLibrary, outDiagnostics);
    }
}

public unsafe partial struct IModule
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, SlangUUID*, void**, int>)(lpVtbl[0]))((IModule*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, uint>)(lpVtbl[1]))((IModule*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, uint>)(lpVtbl[2]))((IModule*)Unsafe.AsPointer(ref this));
    }

    public ISession* getSession()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, ISession*>)(lpVtbl[3]))((IModule*)Unsafe.AsPointer(ref this));
    }

    public ShaderReflection* getLayout(long targetIndex = 0, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, ISlangBlob**, ShaderReflection*>)(lpVtbl[4]))((IModule*)Unsafe.AsPointer(ref this), targetIndex, outDiagnostics);
    }

    public long getSpecializationParamCount()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long>)(lpVtbl[5]))((IModule*)Unsafe.AsPointer(ref this));
    }

    public int getEntryPointCode(long entryPointIndex, long targetIndex, ISlangBlob** outCode, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[6]))((IModule*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outCode, outDiagnostics);
    }

    public int getResultAsFileSystem(long entryPointIndex, long targetIndex, ISlangMutableFileSystem** outFileSystem)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, long, ISlangMutableFileSystem**, int>)(lpVtbl[7]))((IModule*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outFileSystem);
    }

    public void getEntryPointHash(long entryPointIndex, long targetIndex, ISlangBlob** outHash)
    {
        ((delegate* unmanaged[Stdcall]<IModule*, long, long, ISlangBlob**, void>)(lpVtbl[8]))((IModule*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outHash);
    }

    public int specialize(SpecializationArg* specializationArgs, long specializationArgCount, IComponentType** outSpecializedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, SpecializationArg*, long, IComponentType**, ISlangBlob**, int>)(lpVtbl[9]))((IModule*)Unsafe.AsPointer(ref this), specializationArgs, specializationArgCount, outSpecializedComponentType, outDiagnostics);
    }

    public int link(IComponentType** outLinkedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, IComponentType**, ISlangBlob**, int>)(lpVtbl[10]))((IModule*)Unsafe.AsPointer(ref this), outLinkedComponentType, outDiagnostics);
    }

    public int getEntryPointHostCallable(int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, int, int, ISlangSharedLibrary**, ISlangBlob**, int>)(lpVtbl[11]))((IModule*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outSharedLibrary, outDiagnostics);
    }

    public int renameEntryPoint(sbyte* newName, IComponentType** outEntryPoint)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*, IComponentType**, int>)(lpVtbl[12]))((IModule*)Unsafe.AsPointer(ref this), newName, outEntryPoint);
    }

    public int linkWithOptions(IComponentType** outLinkedComponentType, uint compilerOptionEntryCount, CompilerOptionEntry* compilerOptionEntries, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, IComponentType**, uint, CompilerOptionEntry*, ISlangBlob**, int>)(lpVtbl[13]))((IModule*)Unsafe.AsPointer(ref this), outLinkedComponentType, compilerOptionEntryCount, compilerOptionEntries, outDiagnostics);
    }

    public int getTargetCode(long targetIndex, ISlangBlob** outCode, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[14]))((IModule*)Unsafe.AsPointer(ref this), targetIndex, outCode, outDiagnostics);
    }

    public int getTargetMetadata(long targetIndex, IMetadata** outMetadata, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[15]))((IModule*)Unsafe.AsPointer(ref this), targetIndex, outMetadata, outDiagnostics);
    }

    public int getEntryPointMetadata(long entryPointIndex, long targetIndex, IMetadata** outMetadata, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[16]))((IModule*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outMetadata, outDiagnostics);
    }

    public int findEntryPointByName(sbyte* name, IEntryPoint** outEntryPoint)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*, IEntryPoint**, int>)(lpVtbl[17]))((IModule*)Unsafe.AsPointer(ref this), name, outEntryPoint);
    }

    public int getDefinedEntryPointCount()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, int>)(lpVtbl[18]))((IModule*)Unsafe.AsPointer(ref this));
    }

    public int getDefinedEntryPoint(int index, IEntryPoint** outEntryPoint)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, int, IEntryPoint**, int>)(lpVtbl[19]))((IModule*)Unsafe.AsPointer(ref this), index, outEntryPoint);
    }

    public int serialize(ISlangBlob** outSerializedBlob)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, ISlangBlob**, int>)(lpVtbl[20]))((IModule*)Unsafe.AsPointer(ref this), outSerializedBlob);
    }

    public int writeToFile(sbyte* fileName)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*, int>)(lpVtbl[21]))((IModule*)Unsafe.AsPointer(ref this), fileName);
    }

    public sbyte* getName()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*>)(lpVtbl[22]))((IModule*)Unsafe.AsPointer(ref this));
    }

    public sbyte* getFilePath()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*>)(lpVtbl[23]))((IModule*)Unsafe.AsPointer(ref this));
    }

    public sbyte* getUniqueIdentity()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*>)(lpVtbl[24]))((IModule*)Unsafe.AsPointer(ref this));
    }

    public int findAndCheckEntryPoint(sbyte* name, SlangStage stage, IEntryPoint** outEntryPoint, ISlangBlob** outDiagnostics)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*, SlangStage, IEntryPoint**, ISlangBlob**, int>)(lpVtbl[25]))((IModule*)Unsafe.AsPointer(ref this), name, stage, outEntryPoint, outDiagnostics);
    }

    public int getDependencyFileCount()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, int>)(lpVtbl[26]))((IModule*)Unsafe.AsPointer(ref this));
    }

    public sbyte* getDependencyFilePath(int index)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, int, sbyte*>)(lpVtbl[27]))((IModule*)Unsafe.AsPointer(ref this), index);
    }

    public DeclReflection* getModuleReflection()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, DeclReflection*>)(lpVtbl[28]))((IModule*)Unsafe.AsPointer(ref this));
    }

    public int disassemble(ISlangBlob** outDisassembledBlob)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, ISlangBlob**, int>)(lpVtbl[29]))((IModule*)Unsafe.AsPointer(ref this), outDisassembledBlob);
    }
}

public unsafe partial struct IModulePrecompileService_Experimental
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, SlangUUID*, void**, int>)(lpVtbl[0]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, uint>)(lpVtbl[1]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, uint>)(lpVtbl[2]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    public int precompileForTarget(SlangCompileTarget target, ISlangBlob** outDiagnostics)
    {
        return ((delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, SlangCompileTarget, ISlangBlob**, int>)(lpVtbl[3]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), target, outDiagnostics);
    }

    public int getPrecompiledTargetCode(SlangCompileTarget target, ISlangBlob** outCode, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, SlangCompileTarget, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[4]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), target, outCode, outDiagnostics);
    }

    public long getModuleDependencyCount()
    {
        return ((delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, long>)(lpVtbl[5]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    public int getModuleDependency(long dependencyIndex, IModule** outModule, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, long, IModule**, ISlangBlob**, int>)(lpVtbl[6]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), dependencyIndex, outModule, outDiagnostics);
    }
}

public unsafe partial struct SpecializationArg
{
    public SpecializationArg.Kind kind;

    public _Anonymous_e__Union Anonymous;

    public ref TypeReflection* type
    {
        get
        {
            return ref Anonymous.type;
        }
    }

    public ref sbyte* expr
    {
        get
        {
            return ref Anonymous.expr;
        }
    }

    public static SpecializationArg fromType(TypeReflection* inType)
    {
        SpecializationArg rs = new SpecializationArg();

        rs.kind = SpecializationArg.Kind.Type;
        rs.Anonymous.type = inType;
        return rs;
    }

    public static SpecializationArg fromExpr(sbyte* inExpr)
    {
        SpecializationArg rs = new SpecializationArg();

        rs.kind = Expr;
        rs.Anonymous.expr = inExpr;
        return rs;
    }

    public enum Kind
    {
        Unknown = 0,
        Type = 1,
        Expr = 2,
    }

    public unsafe partial struct _Anonymous_e__Union
    {
        public TypeReflection* type;

        public sbyte* expr;
    }
}

public enum SlangLanguageVersion
{
    SLANG_LANGUAGE_VERSION_UNKNOWN = 0,
    SLANG_LANGUAGE_VERSION_LEGACY = 2018,
    SLANG_LANGUAGE_VERSION_2025 = 2025,
    SLANG_LANGUAGE_VERSION_2026 = 2026,
    SLANG_LANGAUGE_VERSION_DEFAULT = SLANG_LANGUAGE_VERSION_LEGACY,
    SLANG_LANGUAGE_VERSION_DEFAULT = SLANG_LANGUAGE_VERSION_LEGACY,
    SLANG_LANGUAGE_VERSION_LATEST = SLANG_LANGUAGE_VERSION_2026,
}

public partial struct SlangGlobalSessionDesc
{
    public uint structureSize;

    public uint apiVersion;

    public uint minLanguageVersion;

    public byte enableGLSL;

    public _reserved_e__FixedBuffer reserved;

    public partial struct _reserved_e__FixedBuffer
    {
        public uint e0;
    }
}

public enum OperandDataType
{
    General = 0,
    Int32 = 1,
    Int64 = 2,
    Float32 = 3,
    Float64 = 4,
    String = 5,
}

public unsafe partial struct VMExecOperand
{
    public byte** section;

    public uint _bitfield;

    public uint type
    {
        readonly get
        {
            return _bitfield & 0xFFu;
        }

        set
        {
            _bitfield = (_bitfield & ~0xFFu) | (value & 0xFFu);
        }
    }

    public uint size
    {
        readonly get
        {
            return (_bitfield >> 8) & 0xFFFFFFu;
        }

        set
        {
            _bitfield = (_bitfield & ~(0xFFFFFFu << 8)) | ((value & 0xFFFFFFu) << 8);
        }
    }

    public uint offset;

    public readonly void* getPtr()
    {
        return *section + offset;
    }

    public readonly OperandDataType getType()
    {
        return (OperandDataType)(type);
    }
}

public unsafe partial struct VMExecInstHeader
{
    public delegate* unmanaged[Thiscall]<IByteCodeRunner*, VMExecInstHeader*, void*, void> functionPtr;

    public uint opcodeExtension;

    public uint operandCount;

    public VMExecInstHeader* getNextInst()
    {
        VMExecInstHeader* self = (VMExecInstHeader*)Unsafe.AsPointer(ref this);
        return (VMExecInstHeader*)((VMExecOperand*)(self + 1) + operandCount);
    }

    public readonly VMExecOperand* getOperand(long index)
    {
        VMExecInstHeader* self = (VMExecInstHeader*)Unsafe.AsPointer(ref Unsafe.AsRef(in this));
        return ((VMExecOperand*)(self + 1) + index);
    }
}

public partial struct ByteCodeFuncInfo
{
    public uint parameterCount;

    public uint returnValueSize;
}

public partial struct ByteCodeRunnerDesc
{
    public nuint structSize;
}

public unsafe partial struct IByteCodeRunner
{
    public void** lpVtbl;

    public static SlangUUID getTypeGuid()
    {
        var res = new SlangUUID
        {
            data1 = 0x00000000,
            data2 = 0x0000,
            data3 = 0x0000,
        };
        res.data4[0] = 0xC0;
        res.data4[1] = 0x00;
        res.data4[2] = 0x00;
        res.data4[3] = 0x00;
        res.data4[4] = 0x00;
        res.data4[5] = 0x00;
        res.data4[6] = 0x00;
        res.data4[7] = 0x46;
        return res;
    }

    public int QueryInterface(Guid* uuid, void** outObject)
    {
        return queryInterface(unchecked((SlangUUID*)(uuid)), outObject);
    }

    public uint AddRef()
    {
        return addRef();
    }

    public uint Release()
    {
        return release();
    }

    public int queryInterface(SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, SlangUUID*, void**, int>)(lpVtbl[0]))((IByteCodeRunner*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, uint>)(lpVtbl[1]))((IByteCodeRunner*)Unsafe.AsPointer(ref this));
    }

    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, uint>)(lpVtbl[2]))((IByteCodeRunner*)Unsafe.AsPointer(ref this));
    }

    public int loadModule(ISlangBlob* moduleBlob)
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, ISlangBlob*, int>)(lpVtbl[3]))((IByteCodeRunner*)Unsafe.AsPointer(ref this), moduleBlob);
    }

    public int selectFunctionByIndex(uint functionIndex)
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, uint, int>)(lpVtbl[4]))((IByteCodeRunner*)Unsafe.AsPointer(ref this), functionIndex);
    }

    public int findFunctionByName(sbyte* name)
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, sbyte*, int>)(lpVtbl[5]))((IByteCodeRunner*)Unsafe.AsPointer(ref this), name);
    }

    public int getFunctionInfo(uint index, ByteCodeFuncInfo* outInfo)
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, uint, ByteCodeFuncInfo*, int>)(lpVtbl[6]))((IByteCodeRunner*)Unsafe.AsPointer(ref this), index, outInfo);
    }

    public void* getCurrentWorkingSet()
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, void*>)(lpVtbl[7]))((IByteCodeRunner*)Unsafe.AsPointer(ref this));
    }

    public int execute(void* argumentData, nuint argumentSize)
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, void*, nuint, int>)(lpVtbl[8]))((IByteCodeRunner*)Unsafe.AsPointer(ref this), argumentData, argumentSize);
    }

    public void getErrorString(ISlangBlob** outBlob)
    {
        ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, ISlangBlob**, void>)(lpVtbl[9]))((IByteCodeRunner*)Unsafe.AsPointer(ref this), outBlob);
    }

    public void* getReturnValue(nuint* outValueSize)
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, nuint*, void*>)(lpVtbl[10]))((IByteCodeRunner*)Unsafe.AsPointer(ref this), outValueSize);
    }

    public void setExtInstHandlerUserData(void* userData)
    {
        ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, void*, void>)(lpVtbl[11]))((IByteCodeRunner*)Unsafe.AsPointer(ref this), userData);
    }

    public int registerExtCall(sbyte* name, delegate* unmanaged[Thiscall]<IByteCodeRunner*, VMExecInstHeader*, void*, void> functionPtr)
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, sbyte*, delegate* unmanaged[Thiscall]<IByteCodeRunner*, VMExecInstHeader*, void*, void>, int>)(lpVtbl[12]))((IByteCodeRunner*)Unsafe.AsPointer(ref this), name, functionPtr);
    }

    public int setPrintCallback(delegate* unmanaged[Thiscall]<sbyte*, void*, void> callback, void* userData)
    {
        return ((delegate* unmanaged[Stdcall]<IByteCodeRunner*, delegate* unmanaged[Thiscall]<sbyte*, void*, void>, void*, int>)(lpVtbl[13]))((IByteCodeRunner*)Unsafe.AsPointer(ref this), callback, userData);
    }
}

public static unsafe partial class Methods
{
    public const int SLANG_DIAGNOSTIC_FLAG_VERBOSE_PATHS = 0x01;
    public const int SLANG_DIAGNOSTIC_FLAG_TREAT_WARNINGS_AS_ERRORS = 0x02;

    public const int SLANG_COMPILE_FLAG_NO_MANGLING = 1 << 3;
    public const int SLANG_COMPILE_FLAG_NO_CODEGEN = 1 << 4;
    public const int SLANG_COMPILE_FLAG_OBFUSCATE = 1 << 5;
    public const int SLANG_COMPILE_FLAG_NO_CHECKING = 0;
    public const int SLANG_COMPILE_FLAG_SPLIT_MIXED_TYPES = 0;

    public const int SLANG_TARGET_FLAG_PARAMETER_BLOCKS_USE_REGISTER_SPACES = 1 << 4;
    public const int SLANG_TARGET_FLAG_GENERATE_WHOLE_PROGRAM = 1 << 8;
    public const int SLANG_TARGET_FLAG_DUMP_IR = 1 << 9;
    public const int SLANG_TARGET_FLAG_GENERATE_SPIRV_DIRECTLY = 1 << 10;

    public const uint kDefaultTargetFlags = (uint)(SLANG_TARGET_FLAG_GENERATE_SPIRV_DIRECTLY);

    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr spGetQueryResultBlob(IntPtr request);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spGetBuildTagString();
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern IGlobalSession* spCreateSession(sbyte* deprecated = null);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spDestroySession(IGlobalSession* session);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSessionSetSharedLibraryLoader(IGlobalSession* session, ISlangSharedLibraryLoader* loader);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern ISlangSharedLibraryLoader* spSessionGetSharedLibraryLoader(IGlobalSession* session);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spSessionCheckCompileTargetSupport(IGlobalSession* session, SlangCompileTarget target);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spSessionCheckPassThroughSupport(IGlobalSession* session, SlangPassThrough passThrough);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spAddBuiltins(IGlobalSession* session, sbyte* sourcePath, sbyte* sourceString);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern ICompileRequest* spCreateCompileRequest(IGlobalSession* session);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spDestroyCompileRequest(ICompileRequest* request);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetFileSystem(ICompileRequest* request, ISlangFileSystem* fileSystem);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetCompileFlags(ICompileRequest* request, uint flags);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spGetCompileFlags(ICompileRequest* request);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetDumpIntermediates(ICompileRequest* request, int enable);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetDumpIntermediatePrefix(ICompileRequest* request, sbyte* prefix);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetLineDirectiveMode(ICompileRequest* request, SlangLineDirectiveMode mode);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetTargetLineDirectiveMode(ICompileRequest* request, int targetIndex, SlangLineDirectiveMode mode);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetTargetForceGLSLScalarBufferLayout(ICompileRequest* request, int targetIndex, byte forceScalarLayout);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetTargetUseMinimumSlangOptimization(ICompileRequest* request, int targetIndex, byte val);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetIgnoreCapabilityCheck(ICompileRequest* request, byte val);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetCodeGenTarget(ICompileRequest* request, SlangCompileTarget target);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spAddCodeGenTarget(ICompileRequest* request, SlangCompileTarget target);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetTargetProfile(ICompileRequest* request, int targetIndex, SlangProfileID profile);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetTargetFlags(ICompileRequest* request, int targetIndex, uint flags);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetTargetFloatingPointMode(ICompileRequest* request, int targetIndex, SlangFloatingPointMode mode);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spAddTargetCapability(ICompileRequest* request, int targetIndex, SlangCapabilityID capability);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetTargetMatrixLayoutMode(ICompileRequest* request, int targetIndex, SlangMatrixLayoutMode mode);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetMatrixLayoutMode(ICompileRequest* request, SlangMatrixLayoutMode mode);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetDebugInfoLevel(ICompileRequest* request, SlangDebugInfoLevel level);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetDebugInfoFormat(ICompileRequest* request, SlangDebugInfoFormat format);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetOptimizationLevel(ICompileRequest* request, SlangOptimizationLevel level);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetOutputContainerFormat(ICompileRequest* request, SlangContainerFormat format);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetPassThrough(ICompileRequest* request, SlangPassThrough passThrough);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetDiagnosticCallback(ICompileRequest* request, delegate* unmanaged[Thiscall]<sbyte*, void*, void> callback, void* userData);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetWriter(ICompileRequest* request, SlangWriterChannel channel, ISlangWriter* writer);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern ISlangWriter* spGetWriter(ICompileRequest* request, SlangWriterChannel channel);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spAddSearchPath(ICompileRequest* request, sbyte* searchDir);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spAddPreprocessorDefine(ICompileRequest* request, sbyte* key, sbyte* value);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spProcessCommandLineArguments(ICompileRequest* request, sbyte** args, int argCount);
    public static int? spProcessCommandLineArguments(ICompileRequest* request, string[] args)
    {
        if (args == null) return null;

        int count = args.Length;

        // allocate unmanaged memory
        IntPtr* pointerArray = (IntPtr*)Marshal.AllocHGlobal(IntPtr.Size * count);

        try
        {
            // copy strings to memory
            for (int i = 0; i < count; i++)
            {
                pointerArray[i] = Marshal.StringToHGlobalAnsi(args[i]);
            }

            // cast intptr to sbyte
            sbyte** nativeStringsPtr = (sbyte**)pointerArray;

            return spProcessCommandLineArguments(request, nativeStringsPtr, count);
        }
        finally
        {
            // memory leak memory leak go away come again another day
            if (pointerArray != null)
            {
                for (int i = 0; i < count; i++)
                {
                    if (pointerArray[i] != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(pointerArray[i]);
                    }
                }
                Marshal.FreeHGlobal((IntPtr)pointerArray);
            }
        }
    }
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spAddTranslationUnit(ICompileRequest* request, SlangSourceLanguage language, sbyte* name);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetDefaultModuleName(ICompileRequest* request, sbyte* defaultModuleName);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spTranslationUnit_addPreprocessorDefine(ICompileRequest* request, int translationUnitIndex, sbyte* key, sbyte* value);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spAddTranslationUnitSourceFile(ICompileRequest* request, int translationUnitIndex, sbyte* path);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spAddTranslationUnitSourceString(ICompileRequest* request, int translationUnitIndex, sbyte* path, sbyte* source);
    public static void spAddTranslationUnitSourceString(ICompileRequest* request, int translationUnitIndex, string path, string source)
    {
        IntPtr Ptr0 = Marshal.StringToHGlobalAnsi(path);
        IntPtr Ptr1 = Marshal.StringToHGlobalAnsi(source);
        try
        {
            sbyte* Ptr0sbyte = (sbyte*)Ptr0.ToPointer();
            sbyte* Ptr1sbyte = (sbyte*)Ptr1.ToPointer();

            spAddTranslationUnitSourceString(request, translationUnitIndex, Ptr0sbyte, Ptr1sbyte);
        }
        finally
        {
            Marshal.FreeHGlobal(Ptr0);
            Marshal.FreeHGlobal(Ptr1);
        }
    }
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spAddLibraryReference(ICompileRequest* request, sbyte* basePath, void* libData, nuint libDataSize);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spAddTranslationUnitSourceStringSpan(ICompileRequest* request, int translationUnitIndex, sbyte* path, sbyte* sourceBegin, sbyte* sourceEnd);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spAddTranslationUnitSourceBlob(ICompileRequest* request, int translationUnitIndex, sbyte* path, ISlangBlob* sourceBlob);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangProfileID spFindProfile(IGlobalSession* session, sbyte* name);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangCapabilityID spFindCapability(IGlobalSession* session, sbyte* name);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spAddEntryPoint(ICompileRequest* request, int translationUnitIndex, sbyte* name, SlangStage stage);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spAddEntryPointEx(ICompileRequest* request, int translationUnitIndex, sbyte* name, SlangStage stage, int genericArgCount, sbyte** genericArgs);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spSetGlobalGenericArgs(ICompileRequest* request, int genericArgCount, sbyte** genericArgs);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spSetTypeNameForGlobalExistentialTypeParam(ICompileRequest* request, int slotIndex, sbyte* typeName);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spSetTypeNameForEntryPointExistentialTypeParam(ICompileRequest* request, int entryPointIndex, int slotIndex, sbyte* typeName);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spCompile(ICompileRequest* request);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spGetDiagnosticOutput(ICompileRequest* request);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spGetDiagnosticOutputBlob(ICompileRequest* request, ISlangBlob** outBlob);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spGetDependencyFileCount(ICompileRequest* request);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spGetDependencyFilePath(ICompileRequest* request, int index);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spGetTranslationUnitCount(ICompileRequest* request);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spGetEntryPointSource(ICompileRequest* request, int entryPointIndex);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void* spGetEntryPointCode(ICompileRequest* request, int entryPointIndex, nuint* outSize);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spGetEntryPointCodeBlob(ICompileRequest* request, int entryPointIndex, int targetIndex, ISlangBlob** outBlob);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spGetEntryPointHostCallable(ICompileRequest* request, int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spGetTargetCodeBlob(ICompileRequest* request, int targetIndex, ISlangBlob** outBlob);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spGetTargetHostCallable(ICompileRequest* request, int targetIndex, ISlangSharedLibrary** outSharedLibrary);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void* spGetCompileRequestCode(ICompileRequest* request, nuint* outSize);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spGetContainerCode(ICompileRequest* request, ISlangBlob** outBlob);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spLoadRepro(ICompileRequest* request, ISlangFileSystem* fileSystem, void* data, nuint size);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spSaveRepro(ICompileRequest* request, ISlangBlob** outBlob);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spEnableReproCapture(ICompileRequest* request);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spGetCompileTimeProfile(ICompileRequest* request, ISlangProfiler** compileTimeProfile, byte shouldClear);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spExtractRepro(IGlobalSession* session, void* reproData, nuint reproDataSize, ISlangMutableFileSystem* fileSystem);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spLoadReproAsFileSystem(IGlobalSession* session, void* reproData, nuint reproDataSize, ISlangFileSystem* replaceFileSystem, ISlangFileSystemExt** outFileSystem);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spOverrideDiagnosticSeverity(ICompileRequest* request, long messageID, SlangSeverity overrideSeverity);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spGetDiagnosticFlags(ICompileRequest* request);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spSetDiagnosticFlags(ICompileRequest* request, int flags);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangProgramLayout* spGetReflection(ICompileRequest* request);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflectionUserAttribute_GetName(SlangReflectionUserAttribute* attrib);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionUserAttribute_GetArgumentCount(SlangReflectionUserAttribute* attrib);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflectionUserAttribute_GetArgumentType(SlangReflectionUserAttribute* attrib, uint index);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spReflectionUserAttribute_GetArgumentValueInt(SlangReflectionUserAttribute* attrib, uint index, int* rs);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spReflectionUserAttribute_GetArgumentValueFloat(SlangReflectionUserAttribute* attrib, uint index, float* rs);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflectionUserAttribute_GetArgumentValueString(SlangReflectionUserAttribute* attrib, uint index, nuint* outSize);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangTypeKind spReflectionType_GetKind(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionType_GetUserAttributeCount(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionUserAttribute* spReflectionType_GetUserAttribute(SlangReflectionType* type, uint index);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionUserAttribute* spReflectionType_FindUserAttributeByName(SlangReflectionType* type, sbyte* name);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflectionType_applySpecializations(SlangReflectionType* type, SlangReflectionGeneric* generic);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionType_GetFieldCount(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariable* spReflectionType_GetFieldByIndex(SlangReflectionType* type, uint index);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint spReflectionType_GetElementCount(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint spReflectionType_GetSpecializedElementCount(SlangReflectionType* type, SlangProgramLayout* reflection);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflectionType_GetElementType(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionType_GetRowCount(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionType_GetColumnCount(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangScalarType spReflectionType_GetScalarType(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangResourceShape spReflectionType_GetResourceShape(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangResourceAccess spReflectionType_GetResourceAccess(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflectionType_GetResourceResultType(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflectionType_GetName(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spReflectionType_GetFullName(SlangReflectionType* type, ISlangBlob** outNameBlob);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionGeneric* spReflectionType_GetGenericContainer(SlangReflectionType* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflectionTypeLayout_GetType(SlangReflectionTypeLayout* type);
    
[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangTypeKind spReflectionTypeLayout_getKind(SlangReflectionTypeLayout* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint spReflectionTypeLayout_GetSize(SlangReflectionTypeLayout* type, SlangParameterCategory category);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint spReflectionTypeLayout_GetStride(SlangReflectionTypeLayout* type, SlangParameterCategory category);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spReflectionTypeLayout_getAlignment(SlangReflectionTypeLayout* type, SlangParameterCategory category);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionTypeLayout_GetFieldCount(SlangReflectionTypeLayout* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflectionTypeLayout_GetFieldByIndex(SlangReflectionTypeLayout* type, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_findFieldIndexByName(SlangReflectionTypeLayout* typeLayout, sbyte* nameBegin, sbyte* nameEnd);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflectionTypeLayout_GetExplicitCounter(SlangReflectionTypeLayout* typeLayout);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint spReflectionTypeLayout_GetElementStride(SlangReflectionTypeLayout* type, SlangParameterCategory category);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionTypeLayout* spReflectionTypeLayout_GetElementTypeLayout(SlangReflectionTypeLayout* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflectionTypeLayout_GetElementVarLayout(SlangReflectionTypeLayout* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflectionTypeLayout_getContainerVarLayout(SlangReflectionTypeLayout* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangParameterCategory spReflectionTypeLayout_GetParameterCategory(SlangReflectionTypeLayout* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionTypeLayout_GetCategoryCount(SlangReflectionTypeLayout* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangParameterCategory spReflectionTypeLayout_GetCategoryByIndex(SlangReflectionTypeLayout* type, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangMatrixLayoutMode spReflectionTypeLayout_GetMatrixLayoutMode(SlangReflectionTypeLayout* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spReflectionTypeLayout_getGenericParamIndex(SlangReflectionTypeLayout* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionTypeLayout* spReflectionTypeLayout_getPendingDataTypeLayout(SlangReflectionTypeLayout* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflectionTypeLayout_getSpecializedTypePendingDataVarLayout(SlangReflectionTypeLayout* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionType_getSpecializedTypeArgCount(SlangReflectionType* type);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflectionType_getSpecializedTypeArgType(SlangReflectionType* type, long index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getBindingRangeCount(SlangReflectionTypeLayout* typeLayout);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangBindingType spReflectionTypeLayout_getBindingRangeType(SlangReflectionTypeLayout* typeLayout, long index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spReflectionTypeLayout_isBindingRangeSpecializable(SlangReflectionTypeLayout* typeLayout, int index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getBindingRangeBindingCount(SlangReflectionTypeLayout* typeLayout, long index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionTypeLayout* spReflectionTypeLayout_getBindingRangeLeafTypeLayout(SlangReflectionTypeLayout* typeLayout, long index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariable* spReflectionTypeLayout_getBindingRangeLeafVariable(SlangReflectionTypeLayout* typeLayout, long index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangImageFormat spReflectionTypeLayout_getBindingRangeImageFormat(SlangReflectionTypeLayout* typeLayout, long index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getFieldBindingRangeOffset(SlangReflectionTypeLayout* typeLayout, long fieldIndex);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getExplicitCounterBindingRangeOffset(SlangReflectionTypeLayout* inTypeLayout);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getBindingRangeDescriptorSetIndex(SlangReflectionTypeLayout* typeLayout, long index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getBindingRangeFirstDescriptorRangeIndex(SlangReflectionTypeLayout* typeLayout, long index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getBindingRangeDescriptorRangeCount(SlangReflectionTypeLayout* typeLayout, long index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getDescriptorSetCount(SlangReflectionTypeLayout* typeLayout);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getDescriptorSetSpaceOffset(SlangReflectionTypeLayout* typeLayout, long setIndex);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getDescriptorSetDescriptorRangeCount(SlangReflectionTypeLayout* typeLayout, long setIndex);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getDescriptorSetDescriptorRangeIndexOffset(SlangReflectionTypeLayout* typeLayout, long setIndex, long rangeIndex);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getDescriptorSetDescriptorRangeDescriptorCount(SlangReflectionTypeLayout* typeLayout, long setIndex, long rangeIndex);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangBindingType spReflectionTypeLayout_getDescriptorSetDescriptorRangeType(SlangReflectionTypeLayout* typeLayout, long setIndex, long rangeIndex);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangParameterCategory spReflectionTypeLayout_getDescriptorSetDescriptorRangeCategory(SlangReflectionTypeLayout* typeLayout, long setIndex, long rangeIndex);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getSubObjectRangeCount(SlangReflectionTypeLayout* typeLayout);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getSubObjectRangeBindingRangeIndex(SlangReflectionTypeLayout* typeLayout, long subObjectRangeIndex);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionTypeLayout_getSubObjectRangeSpaceOffset(SlangReflectionTypeLayout* typeLayout, long subObjectRangeIndex);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflectionTypeLayout_getSubObjectRangeOffset(SlangReflectionTypeLayout* typeLayout, long subObjectRangeIndex);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflectionVariable_GetName(SlangReflectionVariable* var);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflectionVariable_GetType(SlangReflectionVariable* var);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionModifier* spReflectionVariable_FindModifier(SlangReflectionVariable* var, SlangModifierID modifierID);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionVariable_GetUserAttributeCount(SlangReflectionVariable* var);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionUserAttribute* spReflectionVariable_GetUserAttribute(SlangReflectionVariable* var, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionUserAttribute* spReflectionVariable_FindUserAttributeByName(SlangReflectionVariable* var, IGlobalSession* globalSession, sbyte* name);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte spReflectionVariable_HasDefaultValue(SlangReflectionVariable* inVar);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spReflectionVariable_GetDefaultValueInt(SlangReflectionVariable* inVar, long* rs);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spReflectionVariable_GetDefaultValueFloat(SlangReflectionVariable* inVar, float* rs);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionGeneric* spReflectionVariable_GetGenericContainer(SlangReflectionVariable* var);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariable* spReflectionVariable_applySpecializations(SlangReflectionVariable* var, SlangReflectionGeneric* generic);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariable* spReflectionVariableLayout_GetVariable(SlangReflectionVariableLayout* var);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionTypeLayout* spReflectionVariableLayout_GetTypeLayout(SlangReflectionVariableLayout* var);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint spReflectionVariableLayout_GetOffset(SlangReflectionVariableLayout* var, SlangParameterCategory category);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint spReflectionVariableLayout_GetSpace(SlangReflectionVariableLayout* var, SlangParameterCategory category);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangImageFormat spReflectionVariableLayout_GetImageFormat(SlangReflectionVariableLayout* var);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflectionVariableLayout_GetSemanticName(SlangReflectionVariableLayout* var);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint spReflectionVariableLayout_GetSemanticIndex(SlangReflectionVariableLayout* var);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionDecl* spReflectionFunction_asDecl(SlangReflectionFunction* func);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflectionFunction_GetName(SlangReflectionFunction* func);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionModifier* spReflectionFunction_FindModifier(SlangReflectionFunction* var, SlangModifierID modifierID);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionFunction_GetUserAttributeCount(SlangReflectionFunction* func);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionUserAttribute* spReflectionFunction_GetUserAttribute(SlangReflectionFunction* func, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionUserAttribute* spReflectionFunction_FindUserAttributeByName(SlangReflectionFunction* func, IGlobalSession* globalSession, sbyte* name);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionFunction_GetParameterCount(SlangReflectionFunction* func);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariable* spReflectionFunction_GetParameter(SlangReflectionFunction* func, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflectionFunction_GetResultType(SlangReflectionFunction* func);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionGeneric* spReflectionFunction_GetGenericContainer(SlangReflectionFunction* func);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionFunction* spReflectionFunction_applySpecializations(SlangReflectionFunction* func, SlangReflectionGeneric* generic);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionFunction* spReflectionFunction_specializeWithArgTypes(SlangReflectionFunction* func, long argTypeCount, SlangReflectionType** argTypes);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte spReflectionFunction_isOverloaded(SlangReflectionFunction* func);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionFunction_getOverloadCount(SlangReflectionFunction* func);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionFunction* spReflectionFunction_getOverload(SlangReflectionFunction* func, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionDecl_getChildrenCount(SlangReflectionDecl* parentDecl);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionDecl* spReflectionDecl_getChild(SlangReflectionDecl* parentDecl, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflectionDecl_getName(SlangReflectionDecl* decl);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangDeclKind spReflectionDecl_getKind(SlangReflectionDecl* decl);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionFunction* spReflectionDecl_castToFunction(SlangReflectionDecl* decl);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariable* spReflectionDecl_castToVariable(SlangReflectionDecl* decl);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionGeneric* spReflectionDecl_castToGeneric(SlangReflectionDecl* decl);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflection_getTypeFromDecl(SlangReflectionDecl* decl);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionDecl* spReflectionDecl_getParent(SlangReflectionDecl* decl);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionModifier* spReflectionDecl_findModifier(SlangReflectionDecl* decl, SlangModifierID modifierID);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionDecl* spReflectionGeneric_asDecl(SlangReflectionGeneric* generic);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflectionGeneric_GetName(SlangReflectionGeneric* generic);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionGeneric_GetTypeParameterCount(SlangReflectionGeneric* generic);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariable* spReflectionGeneric_GetTypeParameter(SlangReflectionGeneric* generic, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionGeneric_GetValueParameterCount(SlangReflectionGeneric* generic);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariable* spReflectionGeneric_GetValueParameter(SlangReflectionGeneric* generic, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionGeneric_GetTypeParameterConstraintCount(SlangReflectionGeneric* generic, SlangReflectionVariable* typeParam);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflectionGeneric_GetTypeParameterConstraintType(SlangReflectionGeneric* generic, SlangReflectionVariable* typeParam, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangDeclKind spReflectionGeneric_GetInnerKind(SlangReflectionGeneric* generic);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionDecl* spReflectionGeneric_GetInnerDecl(SlangReflectionGeneric* generic);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionGeneric* spReflectionGeneric_GetOuterGenericContainer(SlangReflectionGeneric* generic);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflectionGeneric_GetConcreteType(SlangReflectionGeneric* generic, SlangReflectionVariable* typeParam);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflectionGeneric_GetConcreteIntVal(SlangReflectionGeneric* generic, SlangReflectionVariable* valueParam);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionGeneric* spReflectionGeneric_applySpecializations(SlangReflectionGeneric* currGeneric, SlangReflectionGeneric* generic);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangStage spReflectionVariableLayout_getStage(SlangReflectionVariableLayout* var);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflectionVariableLayout_getPendingDataLayout(SlangReflectionVariableLayout* var);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionParameter_GetBindingIndex(SlangReflectionVariableLayout* parameter);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionParameter_GetBindingSpace(SlangReflectionVariableLayout* parameter);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spIsParameterLocationUsed(ICompileRequest* request, long entryPointIndex, long targetIndex, SlangParameterCategory category, ulong spaceIndex, ulong registerIndex, bool* outUsed);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflectionEntryPoint_getName(SlangEntryPointLayout* entryPoint);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflectionEntryPoint_getNameOverride(SlangEntryPointLayout* entryPoint);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionFunction* spReflectionEntryPoint_getFunction(SlangEntryPointLayout* entryPoint);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionEntryPoint_getParameterCount(SlangEntryPointLayout* entryPoint);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflectionEntryPoint_getParameterByIndex(SlangEntryPointLayout* entryPoint, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangStage spReflectionEntryPoint_getStage(SlangEntryPointLayout* entryPoint);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spReflectionEntryPoint_getComputeThreadGroupSize(SlangEntryPointLayout* entryPoint, ulong axisCount, ulong* outSizeAlongAxis);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void spReflectionEntryPoint_getComputeWaveSize(SlangEntryPointLayout* entryPoint, ulong* outWaveSize);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spReflectionEntryPoint_usesAnySampleRateInput(SlangEntryPointLayout* entryPoint);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflectionEntryPoint_getVarLayout(SlangEntryPointLayout* entryPoint);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflectionEntryPoint_getResultVarLayout(SlangEntryPointLayout* entryPoint);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spReflectionEntryPoint_hasDefaultConstantBuffer(SlangEntryPointLayout* entryPoint);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflectionTypeParameter_GetName(SlangReflectionTypeParameter* typeParam);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionTypeParameter_GetIndex(SlangReflectionTypeParameter* typeParam);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflectionTypeParameter_GetConstraintCount(SlangReflectionTypeParameter* typeParam);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflectionTypeParameter_GetConstraintByIndex(SlangReflectionTypeParameter* typeParam, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spReflection_ToJson(SlangProgramLayout* reflection, ICompileRequest* request, ISlangBlob** outBlob);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflection_GetParameterCount(SlangProgramLayout* reflection);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflection_GetParameterByIndex(SlangProgramLayout* reflection, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spReflection_GetTypeParameterCount(SlangProgramLayout* reflection);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionTypeParameter* spReflection_GetTypeParameterByIndex(SlangProgramLayout* reflection, uint index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionTypeParameter* spReflection_FindTypeParameter(SlangProgramLayout* reflection, sbyte* name);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflection_FindTypeByName(SlangProgramLayout* reflection, sbyte* name);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionTypeLayout* spReflection_GetTypeLayout(SlangProgramLayout* reflection, SlangReflectionType* reflectionType, SlangLayoutRules rules);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionFunction* spReflection_FindFunctionByName(SlangProgramLayout* reflection, sbyte* name);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionFunction* spReflection_FindFunctionByNameInType(SlangProgramLayout* reflection, SlangReflectionType* reflType, sbyte* name);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariable* spReflection_FindVarByNameInType(SlangProgramLayout* reflection, SlangReflectionType* reflType, sbyte* name);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionFunction* spReflection_TryResolveOverloadedFunction(SlangProgramLayout* reflection, uint candidateCount, SlangReflectionFunction** candidates);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong spReflection_getEntryPointCount(SlangProgramLayout* reflection);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangEntryPointLayout* spReflection_getEntryPointByIndex(SlangProgramLayout* reflection, ulong index);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangEntryPointLayout* spReflection_findEntryPointByName(SlangProgramLayout* reflection, sbyte* name);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong spReflection_getGlobalConstantBufferBinding(SlangProgramLayout* reflection);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern nuint spReflection_getGlobalConstantBufferSize(SlangProgramLayout* reflection);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionType* spReflection_specializeType(SlangProgramLayout* reflection, SlangReflectionType* type, long specializationArgCount, SlangReflectionType** specializationArgs, ISlangBlob** outDiagnostics);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionGeneric* spReflection_specializeGeneric(SlangProgramLayout* inProgramLayout, SlangReflectionGeneric* generic, long argCount, SlangReflectionGenericArgType* argTypes, SlangReflectionGenericArg* args, ISlangBlob** outDiagnostics);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte spReflection_isSubType(SlangProgramLayout* reflection, SlangReflectionType* subType, SlangReflectionType* superType);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong spReflection_getHashedStringCount(SlangProgramLayout* reflection);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spReflection_getHashedString(SlangProgramLayout* reflection, ulong index, nuint* outCount);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint spComputeStringHash(sbyte* chars, nuint count);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionTypeLayout* spReflection_getGlobalParamsTypeLayout(SlangProgramLayout* reflection);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern SlangReflectionVariableLayout* spReflection_getGlobalParamsVarLayout(SlangProgramLayout* reflection);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* spGetTranslationUnitSource(ICompileRequest* request, int translationUnitIndex);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern long spReflection_getBindlessSpaceIndex(SlangProgramLayout* reflection);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern ISession* spReflection_GetSession(SlangProgramLayout* reflection);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spCompileRequest_getProgram(ICompileRequest* request, IComponentType** outProgram);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spCompileRequest_getProgramWithEntryPoints(ICompileRequest* request, IComponentType** outProgram);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spCompileRequest_getEntryPoint(ICompileRequest* request, long entryPointIndex, IComponentType** outEntryPoint);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spCompileRequest_getModule(ICompileRequest* request, long translationUnitIndex, IModule** outModule);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int spCompileRequest_getSession(ICompileRequest* request, ISession** outSession);

    public const int kSessionFlags_None = 0;

    public const uint kInvalidCoverageCounterIndex = 0xffffffffU;

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern ISlangBlob* slang_createBlob(void* data, nuint size);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int slang_writeCoverageManifestJson(ICoverageTracingMetadata* metadata, ISlangBlob** outBlob);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern IModule* slang_loadModuleFromSource(ISession* session, sbyte* moduleName, sbyte* path, sbyte* source, nuint sourceSize, ISlangBlob** outDiagnostics = null);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern IModule* slang_loadModuleFromIRBlob(ISession* session, sbyte* moduleName, sbyte* path, void* source, nuint sourceSize, ISlangBlob** outDiagnostics = null);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int slang_loadModuleInfoFromIRBlob(ISession* session, void* source, nuint sourceSize, long* outModuleVersion, sbyte** outModuleCompilerVersion, sbyte** outModuleName);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int slang_createGlobalSession(long apiVersion, IGlobalSession** outGlobalSession);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int slang_createGlobalSession2(SlangGlobalSessionDesc* desc, IGlobalSession** outGlobalSession);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int slang_createGlobalSessionWithoutCoreModule(long apiVersion, IGlobalSession** outGlobalSession);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern ISlangBlob* slang_getEmbeddedCoreModule();

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void slang_shutdown();

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void slang_enableRecordLayer(byte enable);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte slang_isRecordLayerEnabled();

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void slang_setReplayDirectory(sbyte* path);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* slang_getReplayDirectory();

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* slang_getCurrentReplayPath();

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int slang_loadReplay(sbyte* folderPath);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int slang_loadLatestReplay();

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern void slang_replayMarker(sbyte* label);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern sbyte* slang_getLastInternalErrorMessage();

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int slang_createByteCodeRunner(ByteCodeRunnerDesc* desc, IByteCodeRunner** outByteCodeRunner);

[DllImport("slang", CallingConvention = CallingConvention.Cdecl)]
    public static extern int slang_disassembleByteCode(ISlangBlob* moduleBlob, ISlangBlob** outDisassemblyBlob);

    public static void shutdown()
    {
        slang_shutdown();
    }

    public static sbyte* getLastInternalErrorMessage()
    {
        return slang_getLastInternalErrorMessage();
    }

    public static bool Equals(SlangUUID* aIn, SlangUUID* bIn)
    {
        if (aIn->data1 != bIn->data1 || aIn->data2 != bIn->data2 || aIn->data3 != bIn->data3)
        {
            return false;
        }

        for (int i = 0; i < 8; i++)
        {
            if (aIn->data4[i] != bIn->data4[i])
            {
                return false;
            }
        }

        return true;
    }

    public static bool NotEquals(SlangUUID* a, SlangUUID* b)
    {
        return !(Equals(a, b));
    }
}