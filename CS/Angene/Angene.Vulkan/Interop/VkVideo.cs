using System.Runtime.CompilerServices;

namespace Angene.Vulkan.Interop;

public class VkVideo
{
    public enum StdVideoH264ChromaFormatIdc : uint
    {
        STD_VIDEO_H264_CHROMA_FORMAT_IDC_MONOCHROME = 0,
        STD_VIDEO_H264_CHROMA_FORMAT_IDC_420 = 1,
        STD_VIDEO_H264_CHROMA_FORMAT_IDC_422 = 2,
        STD_VIDEO_H264_CHROMA_FORMAT_IDC_444 = 3,
        STD_VIDEO_H264_CHROMA_FORMAT_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_CHROMA_FORMAT_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264ProfileIdc : uint
    {
        STD_VIDEO_H264_PROFILE_IDC_BASELINE = 66,
        STD_VIDEO_H264_PROFILE_IDC_MAIN = 77,
        STD_VIDEO_H264_PROFILE_IDC_HIGH = 100,
        STD_VIDEO_H264_PROFILE_IDC_HIGH_10 = 110,
        STD_VIDEO_H264_PROFILE_IDC_HIGH_422 = 122,
        STD_VIDEO_H264_PROFILE_IDC_HIGH_444_PREDICTIVE = 244,
        STD_VIDEO_H264_PROFILE_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_PROFILE_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264LevelIdc : uint
    {
        STD_VIDEO_H264_LEVEL_IDC_1_0 = 0,
        STD_VIDEO_H264_LEVEL_IDC_1_1 = 1,
        STD_VIDEO_H264_LEVEL_IDC_1_2 = 2,
        STD_VIDEO_H264_LEVEL_IDC_1_3 = 3,
        STD_VIDEO_H264_LEVEL_IDC_2_0 = 4,
        STD_VIDEO_H264_LEVEL_IDC_2_1 = 5,
        STD_VIDEO_H264_LEVEL_IDC_2_2 = 6,
        STD_VIDEO_H264_LEVEL_IDC_3_0 = 7,
        STD_VIDEO_H264_LEVEL_IDC_3_1 = 8,
        STD_VIDEO_H264_LEVEL_IDC_3_2 = 9,
        STD_VIDEO_H264_LEVEL_IDC_4_0 = 10,
        STD_VIDEO_H264_LEVEL_IDC_4_1 = 11,
        STD_VIDEO_H264_LEVEL_IDC_4_2 = 12,
        STD_VIDEO_H264_LEVEL_IDC_5_0 = 13,
        STD_VIDEO_H264_LEVEL_IDC_5_1 = 14,
        STD_VIDEO_H264_LEVEL_IDC_5_2 = 15,
        STD_VIDEO_H264_LEVEL_IDC_6_0 = 16,
        STD_VIDEO_H264_LEVEL_IDC_6_1 = 17,
        STD_VIDEO_H264_LEVEL_IDC_6_2 = 18,
        STD_VIDEO_H264_LEVEL_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_LEVEL_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264PocType : uint
    {
        STD_VIDEO_H264_POC_TYPE_0 = 0,
        STD_VIDEO_H264_POC_TYPE_1 = 1,
        STD_VIDEO_H264_POC_TYPE_2 = 2,
        STD_VIDEO_H264_POC_TYPE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_POC_TYPE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264AspectRatioIdc : uint
    {
        STD_VIDEO_H264_ASPECT_RATIO_IDC_UNSPECIFIED = 0,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_SQUARE = 1,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_12_11 = 2,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_10_11 = 3,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_16_11 = 4,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_40_33 = 5,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_24_11 = 6,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_20_11 = 7,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_32_11 = 8,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_80_33 = 9,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_18_11 = 10,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_15_11 = 11,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_64_33 = 12,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_160_99 = 13,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_4_3 = 14,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_3_2 = 15,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_2_1 = 16,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_EXTENDED_SAR = 255,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_ASPECT_RATIO_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264WeightedBipredIdc : uint
    {
        STD_VIDEO_H264_WEIGHTED_BIPRED_IDC_DEFAULT = 0,
        STD_VIDEO_H264_WEIGHTED_BIPRED_IDC_EXPLICIT = 1,
        STD_VIDEO_H264_WEIGHTED_BIPRED_IDC_IMPLICIT = 2,
        STD_VIDEO_H264_WEIGHTED_BIPRED_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_WEIGHTED_BIPRED_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264ModificationOfPicNumsIdc : uint
    {
        STD_VIDEO_H264_MODIFICATION_OF_PIC_NUMS_IDC_SHORT_TERM_SUBTRACT = 0,
        STD_VIDEO_H264_MODIFICATION_OF_PIC_NUMS_IDC_SHORT_TERM_ADD = 1,
        STD_VIDEO_H264_MODIFICATION_OF_PIC_NUMS_IDC_LONG_TERM = 2,
        STD_VIDEO_H264_MODIFICATION_OF_PIC_NUMS_IDC_END = 3,
        STD_VIDEO_H264_MODIFICATION_OF_PIC_NUMS_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_MODIFICATION_OF_PIC_NUMS_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264MemMgmtControlOp : uint
    {
        STD_VIDEO_H264_MEM_MGMT_CONTROL_OP_END = 0,
        STD_VIDEO_H264_MEM_MGMT_CONTROL_OP_UNMARK_SHORT_TERM = 1,
        STD_VIDEO_H264_MEM_MGMT_CONTROL_OP_UNMARK_LONG_TERM = 2,
        STD_VIDEO_H264_MEM_MGMT_CONTROL_OP_MARK_LONG_TERM = 3,
        STD_VIDEO_H264_MEM_MGMT_CONTROL_OP_SET_MAX_LONG_TERM_INDEX = 4,
        STD_VIDEO_H264_MEM_MGMT_CONTROL_OP_UNMARK_ALL = 5,
        STD_VIDEO_H264_MEM_MGMT_CONTROL_OP_MARK_CURRENT_AS_LONG_TERM = 6,
        STD_VIDEO_H264_MEM_MGMT_CONTROL_OP_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_MEM_MGMT_CONTROL_OP_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264CabacInitIdc : uint
    {
        STD_VIDEO_H264_CABAC_INIT_IDC_0 = 0,
        STD_VIDEO_H264_CABAC_INIT_IDC_1 = 1,
        STD_VIDEO_H264_CABAC_INIT_IDC_2 = 2,
        STD_VIDEO_H264_CABAC_INIT_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_CABAC_INIT_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264DisableDeblockingFilterIdc : uint
    {
        STD_VIDEO_H264_DISABLE_DEBLOCKING_FILTER_IDC_DISABLED = 0,
        STD_VIDEO_H264_DISABLE_DEBLOCKING_FILTER_IDC_ENABLED = 1,
        STD_VIDEO_H264_DISABLE_DEBLOCKING_FILTER_IDC_PARTIAL = 2,
        STD_VIDEO_H264_DISABLE_DEBLOCKING_FILTER_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_DISABLE_DEBLOCKING_FILTER_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264SliceType : uint
    {
        STD_VIDEO_H264_SLICE_TYPE_P = 0,
        STD_VIDEO_H264_SLICE_TYPE_B = 1,
        STD_VIDEO_H264_SLICE_TYPE_I = 2,
        STD_VIDEO_H264_SLICE_TYPE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_SLICE_TYPE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264PictureType : uint
    {
        STD_VIDEO_H264_PICTURE_TYPE_P = 0,
        STD_VIDEO_H264_PICTURE_TYPE_B = 1,
        STD_VIDEO_H264_PICTURE_TYPE_I = 2,
        STD_VIDEO_H264_PICTURE_TYPE_IDR = 5,
        STD_VIDEO_H264_PICTURE_TYPE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_PICTURE_TYPE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH264NonVclNaluType : uint
    {
        STD_VIDEO_H264_NON_VCL_NALU_TYPE_SPS = 0,
        STD_VIDEO_H264_NON_VCL_NALU_TYPE_PPS = 1,
        STD_VIDEO_H264_NON_VCL_NALU_TYPE_AUD = 2,
        STD_VIDEO_H264_NON_VCL_NALU_TYPE_PREFIX = 3,
        STD_VIDEO_H264_NON_VCL_NALU_TYPE_END_OF_SEQUENCE = 4,
        STD_VIDEO_H264_NON_VCL_NALU_TYPE_END_OF_STREAM = 5,
        STD_VIDEO_H264_NON_VCL_NALU_TYPE_PRECODED = 6,
        STD_VIDEO_H264_NON_VCL_NALU_TYPE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H264_NON_VCL_NALU_TYPE_MAX_ENUM = 0x7FFFFFFF,
    }

    public partial struct StdVideoH264SpsVuiFlags
    {
        public uint _bitfield;

            public uint aspect_ratio_info_present_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint overscan_info_present_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint overscan_appropriate_flag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint video_signal_type_present_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint video_full_range_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint color_description_present_flag
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint chroma_loc_info_present_flag
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint timing_info_present_flag
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

            public uint fixed_frame_rate_flag
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

            public uint bitstream_restriction_flag
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 9)) | ((value & 0x1u) << 9);
            }
        }

            public uint nal_hrd_parameters_present_flag
        {
            readonly get
            {
                return (_bitfield >> 10) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 10)) | ((value & 0x1u) << 10);
            }
        }

            public uint vcl_hrd_parameters_present_flag
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 11)) | ((value & 0x1u) << 11);
            }
        }
    }

    public partial struct StdVideoH264HrdParameters
    {
            public byte cpb_cnt_minus1;

            public byte bit_rate_scale;

            public byte cpb_size_scale;

            public byte reserved1;

            public _bit_rate_value_minus1_e__FixedBuffer bit_rate_value_minus1;

            public _cpb_size_value_minus1_e__FixedBuffer cpb_size_value_minus1;

            public _cbr_flag_e__FixedBuffer cbr_flag;

            public uint initial_cpb_removal_delay_length_minus1;

            public uint cpb_removal_delay_length_minus1;

            public uint dpb_output_delay_length_minus1;

            public uint time_offset_length;

        [InlineArray(32)]
        public partial struct _bit_rate_value_minus1_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(32)]
        public partial struct _cpb_size_value_minus1_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(32)]
        public partial struct _cbr_flag_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct StdVideoH264SequenceParameterSetVui
    {
        public StdVideoH264SpsVuiFlags flags;

        public StdVideoH264AspectRatioIdc aspect_ratio_idc;

            public ushort sar_width;

            public ushort sar_height;

            public byte video_format;

            public byte colour_primaries;

            public byte transfer_characteristics;

            public byte matrix_coefficients;

            public uint num_units_in_tick;

            public uint time_scale;

            public byte max_num_reorder_frames;

            public byte max_dec_frame_buffering;

            public byte chroma_sample_loc_type_top_field;

            public byte chroma_sample_loc_type_bottom_field;

            public uint reserved1;

            public StdVideoH264HrdParameters* pHrdParameters;
    }

    public partial struct StdVideoH264SpsFlags
    {
        public uint _bitfield;

            public uint constraint_set0_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint constraint_set1_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint constraint_set2_flag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint constraint_set3_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint constraint_set4_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint constraint_set5_flag
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint direct_8x8_inference_flag
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint mb_adaptive_frame_field_flag
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

            public uint frame_mbs_only_flag
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

            public uint delta_pic_order_always_zero_flag
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 9)) | ((value & 0x1u) << 9);
            }
        }

            public uint separate_colour_plane_flag
        {
            readonly get
            {
                return (_bitfield >> 10) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 10)) | ((value & 0x1u) << 10);
            }
        }

            public uint gaps_in_frame_num_value_allowed_flag
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 11)) | ((value & 0x1u) << 11);
            }
        }

            public uint qpprime_y_zero_transform_bypass_flag
        {
            readonly get
            {
                return (_bitfield >> 12) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 12)) | ((value & 0x1u) << 12);
            }
        }

            public uint frame_cropping_flag
        {
            readonly get
            {
                return (_bitfield >> 13) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 13)) | ((value & 0x1u) << 13);
            }
        }

            public uint seq_scaling_matrix_present_flag
        {
            readonly get
            {
                return (_bitfield >> 14) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 14)) | ((value & 0x1u) << 14);
            }
        }

            public uint vui_parameters_present_flag
        {
            readonly get
            {
                return (_bitfield >> 15) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 15)) | ((value & 0x1u) << 15);
            }
        }
    }

    public partial struct StdVideoH264ScalingLists
    {
            public ushort scaling_list_present_mask;

            public ushort use_default_scaling_matrix_mask;

            public _ScalingList4x4_e__FixedBuffer ScalingList4x4;

            public _ScalingList8x8_e__FixedBuffer ScalingList8x8;

        [InlineArray(6 * 16)]
        public partial struct _ScalingList4x4_e__FixedBuffer
        {
            public byte e0_0;
        }

        [InlineArray(6 * 64)]
        public partial struct _ScalingList8x8_e__FixedBuffer
        {
            public byte e0_0;
        }
    }

    public unsafe partial struct StdVideoH264SequenceParameterSet
    {
        public StdVideoH264SpsFlags flags;

        public StdVideoH264ProfileIdc profile_idc;

        public StdVideoH264LevelIdc level_idc;

        public StdVideoH264ChromaFormatIdc chroma_format_idc;

            public byte seq_parameter_set_id;

            public byte bit_depth_luma_minus8;

            public byte bit_depth_chroma_minus8;

            public byte log2_max_frame_num_minus4;

        public StdVideoH264PocType pic_order_cnt_type;

            public int offset_for_non_ref_pic;

            public int offset_for_top_to_bottom_field;

            public byte log2_max_pic_order_cnt_lsb_minus4;

            public byte num_ref_frames_in_pic_order_cnt_cycle;

            public byte max_num_ref_frames;

            public byte reserved1;

            public uint pic_width_in_mbs_minus1;

            public uint pic_height_in_map_units_minus1;

            public uint frame_crop_left_offset;

            public uint frame_crop_right_offset;

            public uint frame_crop_top_offset;

            public uint frame_crop_bottom_offset;

            public uint reserved2;

            public int* pOffsetForRefFrame;

            public StdVideoH264ScalingLists* pScalingLists;

            public StdVideoH264SequenceParameterSetVui* pSequenceParameterSetVui;
    }

    public partial struct StdVideoH264PpsFlags
    {
        public uint _bitfield;

            public uint transform_8x8_mode_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint redundant_pic_cnt_present_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint constrained_intra_pred_flag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint deblocking_filter_control_present_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint weighted_pred_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint bottom_field_pic_order_in_frame_present_flag
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint entropy_coding_mode_flag
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint pic_scaling_matrix_present_flag
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }
    }

    public unsafe partial struct StdVideoH264PictureParameterSet
    {
        public StdVideoH264PpsFlags flags;

            public byte seq_parameter_set_id;

            public byte pic_parameter_set_id;

            public byte num_ref_idx_l0_default_active_minus1;

            public byte num_ref_idx_l1_default_active_minus1;

        public StdVideoH264WeightedBipredIdc weighted_bipred_idc;

            public sbyte pic_init_qp_minus26;

            public sbyte pic_init_qs_minus26;

            public sbyte chroma_qp_index_offset;

            public sbyte second_chroma_qp_index_offset;

            public StdVideoH264ScalingLists* pScalingLists;
    }

    public enum StdVideoDecodeH264FieldOrderCount : uint
    {
        STD_VIDEO_DECODE_H264_FIELD_ORDER_COUNT_TOP = 0,
        STD_VIDEO_DECODE_H264_FIELD_ORDER_COUNT_BOTTOM = 1,
        STD_VIDEO_DECODE_H264_FIELD_ORDER_COUNT_INVALID = 0x7FFFFFFF,
        STD_VIDEO_DECODE_H264_FIELD_ORDER_COUNT_MAX_ENUM = 0x7FFFFFFF,
    }

    public partial struct StdVideoDecodeH264PictureInfoFlags
    {
        public uint _bitfield;

            public uint field_pic_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint is_intra
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint IdrPicFlag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint bottom_field_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint is_reference
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint complementary_field_pair
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }
    }

    public partial struct StdVideoDecodeH264PictureInfo
    {
        public StdVideoDecodeH264PictureInfoFlags flags;

            public byte seq_parameter_set_id;

            public byte pic_parameter_set_id;

            public byte reserved1;

            public byte reserved2;

            public ushort frame_num;

            public ushort idr_pic_id;

            public _PicOrderCnt_e__FixedBuffer PicOrderCnt;

        [InlineArray(2)]
        public partial struct _PicOrderCnt_e__FixedBuffer
        {
            public int e0;
        }
    }

    public partial struct StdVideoDecodeH264ReferenceInfoFlags
    {
        public uint _bitfield;

            public uint top_field_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint bottom_field_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint used_for_long_term_reference
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint is_non_existing
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }
    }

    public partial struct StdVideoDecodeH264ReferenceInfo
    {
        public StdVideoDecodeH264ReferenceInfoFlags flags;

            public ushort FrameNum;

            public ushort reserved;

            public _PicOrderCnt_e__FixedBuffer PicOrderCnt;

        [InlineArray(2)]
        public partial struct _PicOrderCnt_e__FixedBuffer
        {
            public int e0;
        }
    }

    public partial struct StdVideoEncodeH264WeightTableFlags
    {
            public uint luma_weight_l0_flag;

            public uint chroma_weight_l0_flag;

            public uint luma_weight_l1_flag;

            public uint chroma_weight_l1_flag;
    }

    public partial struct StdVideoEncodeH264WeightTable
    {
        public StdVideoEncodeH264WeightTableFlags flags;

            public byte luma_log2_weight_denom;

            public byte chroma_log2_weight_denom;

            public _luma_weight_l0_e__FixedBuffer luma_weight_l0;

            public _luma_offset_l0_e__FixedBuffer luma_offset_l0;

            public _chroma_weight_l0_e__FixedBuffer chroma_weight_l0;

            public _chroma_offset_l0_e__FixedBuffer chroma_offset_l0;

            public _luma_weight_l1_e__FixedBuffer luma_weight_l1;

            public _luma_offset_l1_e__FixedBuffer luma_offset_l1;

            public _chroma_weight_l1_e__FixedBuffer chroma_weight_l1;

            public _chroma_offset_l1_e__FixedBuffer chroma_offset_l1;

        [InlineArray(32)]
        public partial struct _luma_weight_l0_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(32)]
        public partial struct _luma_offset_l0_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(32 * 2)]
        public partial struct _chroma_weight_l0_e__FixedBuffer
        {
            public sbyte e0_0;
        }

        [InlineArray(32 * 2)]
        public partial struct _chroma_offset_l0_e__FixedBuffer
        {
            public sbyte e0_0;
        }

        [InlineArray(32)]
        public partial struct _luma_weight_l1_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(32)]
        public partial struct _luma_offset_l1_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(32 * 2)]
        public partial struct _chroma_weight_l1_e__FixedBuffer
        {
            public sbyte e0_0;
        }

        [InlineArray(32 * 2)]
        public partial struct _chroma_offset_l1_e__FixedBuffer
        {
            public sbyte e0_0;
        }
    }

    public partial struct StdVideoEncodeH264SliceHeaderFlags
    {
        public uint _bitfield;

            public uint direct_spatial_mv_pred_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint num_ref_idx_active_override_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }
    }

    public partial struct StdVideoEncodeH264PictureInfoFlags
    {
        public uint _bitfield;

            public uint IdrPicFlag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint is_reference
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint no_output_of_prior_pics_flag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint long_term_reference_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint adaptive_ref_pic_marking_mode_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x7FFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFu << 5)) | ((value & 0x7FFFFFFu) << 5);
            }
        }
    }

    public partial struct StdVideoEncodeH264ReferenceInfoFlags
    {
        public uint _bitfield;

            public uint used_for_long_term_reference
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }
    }

    public partial struct StdVideoEncodeH264ReferenceListsInfoFlags
    {
        public uint _bitfield;

            public uint ref_pic_list_modification_flag_l0
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint ref_pic_list_modification_flag_l1
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }
    }

    public partial struct StdVideoEncodeH264RefListModEntry
    {
        public StdVideoH264ModificationOfPicNumsIdc modification_of_pic_nums_idc;

            public ushort abs_diff_pic_num_minus1;

            public ushort long_term_pic_num;
    }

    public partial struct StdVideoEncodeH264RefPicMarkingEntry
    {
        public StdVideoH264MemMgmtControlOp memory_management_control_operation;

            public ushort difference_of_pic_nums_minus1;

            public ushort long_term_pic_num;

            public ushort long_term_frame_idx;

            public ushort max_long_term_frame_idx_plus1;
    }

    public unsafe partial struct StdVideoEncodeH264ReferenceListsInfo
    {
        public StdVideoEncodeH264ReferenceListsInfoFlags flags;

            public byte num_ref_idx_l0_active_minus1;

            public byte num_ref_idx_l1_active_minus1;

            public _RefPicList0_e__FixedBuffer RefPicList0;

            public _RefPicList1_e__FixedBuffer RefPicList1;

            public byte refList0ModOpCount;

            public byte refList1ModOpCount;

            public byte refPicMarkingOpCount;

            public _reserved1_e__FixedBuffer reserved1;

            public StdVideoEncodeH264RefListModEntry* pRefList0ModOperations;

            public StdVideoEncodeH264RefListModEntry* pRefList1ModOperations;

            public StdVideoEncodeH264RefPicMarkingEntry* pRefPicMarkingOperations;

        [InlineArray(32)]
        public partial struct _RefPicList0_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(32)]
        public partial struct _RefPicList1_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(7)]
        public partial struct _reserved1_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct StdVideoEncodeH264PictureInfo
    {
        public StdVideoEncodeH264PictureInfoFlags flags;

            public byte seq_parameter_set_id;

            public byte pic_parameter_set_id;

            public ushort idr_pic_id;

        public StdVideoH264PictureType primary_pic_type;

            public uint frame_num;

            public int PicOrderCnt;

            public byte temporal_id;

            public _reserved1_e__FixedBuffer reserved1;

            public StdVideoEncodeH264ReferenceListsInfo* pRefLists;

        [InlineArray(3)]
        public partial struct _reserved1_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct StdVideoEncodeH264ReferenceInfo
    {
        public StdVideoEncodeH264ReferenceInfoFlags flags;

        public StdVideoH264PictureType primary_pic_type;

            public uint FrameNum;

            public int PicOrderCnt;

            public ushort long_term_pic_num;

            public ushort long_term_frame_idx;

            public byte temporal_id;
    }

    public unsafe partial struct StdVideoEncodeH264SliceHeader
    {
        public StdVideoEncodeH264SliceHeaderFlags flags;

            public uint first_mb_in_slice;

        public StdVideoH264SliceType slice_type;

            public sbyte slice_alpha_c0_offset_div2;

            public sbyte slice_beta_offset_div2;

            public sbyte slice_qp_delta;

            public byte reserved1;

        public StdVideoH264CabacInitIdc cabac_init_idc;

        public StdVideoH264DisableDeblockingFilterIdc disable_deblocking_filter_idc;

            public StdVideoEncodeH264WeightTable* pWeightTable;
    }

    public enum StdVideoH265ChromaFormatIdc : uint
    {
        STD_VIDEO_H265_CHROMA_FORMAT_IDC_MONOCHROME = 0,
        STD_VIDEO_H265_CHROMA_FORMAT_IDC_420 = 1,
        STD_VIDEO_H265_CHROMA_FORMAT_IDC_422 = 2,
        STD_VIDEO_H265_CHROMA_FORMAT_IDC_444 = 3,
        STD_VIDEO_H265_CHROMA_FORMAT_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H265_CHROMA_FORMAT_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH265ProfileIdc : uint
    {
        STD_VIDEO_H265_PROFILE_IDC_MAIN = 1,
        STD_VIDEO_H265_PROFILE_IDC_MAIN_10 = 2,
        STD_VIDEO_H265_PROFILE_IDC_MAIN_STILL_PICTURE = 3,
        STD_VIDEO_H265_PROFILE_IDC_FORMAT_RANGE_EXTENSIONS = 4,
        STD_VIDEO_H265_PROFILE_IDC_SCC_EXTENSIONS = 9,
        STD_VIDEO_H265_PROFILE_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H265_PROFILE_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH265LevelIdc : uint
    {
        STD_VIDEO_H265_LEVEL_IDC_1_0 = 0,
        STD_VIDEO_H265_LEVEL_IDC_2_0 = 1,
        STD_VIDEO_H265_LEVEL_IDC_2_1 = 2,
        STD_VIDEO_H265_LEVEL_IDC_3_0 = 3,
        STD_VIDEO_H265_LEVEL_IDC_3_1 = 4,
        STD_VIDEO_H265_LEVEL_IDC_4_0 = 5,
        STD_VIDEO_H265_LEVEL_IDC_4_1 = 6,
        STD_VIDEO_H265_LEVEL_IDC_5_0 = 7,
        STD_VIDEO_H265_LEVEL_IDC_5_1 = 8,
        STD_VIDEO_H265_LEVEL_IDC_5_2 = 9,
        STD_VIDEO_H265_LEVEL_IDC_6_0 = 10,
        STD_VIDEO_H265_LEVEL_IDC_6_1 = 11,
        STD_VIDEO_H265_LEVEL_IDC_6_2 = 12,
        STD_VIDEO_H265_LEVEL_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H265_LEVEL_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH265SliceType : uint
    {
        STD_VIDEO_H265_SLICE_TYPE_B = 0,
        STD_VIDEO_H265_SLICE_TYPE_P = 1,
        STD_VIDEO_H265_SLICE_TYPE_I = 2,
        STD_VIDEO_H265_SLICE_TYPE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H265_SLICE_TYPE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH265PictureType : uint
    {
        STD_VIDEO_H265_PICTURE_TYPE_P = 0,
        STD_VIDEO_H265_PICTURE_TYPE_B = 1,
        STD_VIDEO_H265_PICTURE_TYPE_I = 2,
        STD_VIDEO_H265_PICTURE_TYPE_IDR = 3,
        STD_VIDEO_H265_PICTURE_TYPE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H265_PICTURE_TYPE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoH265AspectRatioIdc : uint
    {
        STD_VIDEO_H265_ASPECT_RATIO_IDC_UNSPECIFIED = 0,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_SQUARE = 1,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_12_11 = 2,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_10_11 = 3,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_16_11 = 4,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_40_33 = 5,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_24_11 = 6,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_20_11 = 7,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_32_11 = 8,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_80_33 = 9,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_18_11 = 10,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_15_11 = 11,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_64_33 = 12,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_160_99 = 13,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_4_3 = 14,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_3_2 = 15,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_2_1 = 16,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_EXTENDED_SAR = 255,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_INVALID = 0x7FFFFFFF,
        STD_VIDEO_H265_ASPECT_RATIO_IDC_MAX_ENUM = 0x7FFFFFFF,
    }

    public partial struct StdVideoH265DecPicBufMgr
    {
            public _max_latency_increase_plus1_e__FixedBuffer max_latency_increase_plus1;

            public _max_dec_pic_buffering_minus1_e__FixedBuffer max_dec_pic_buffering_minus1;

            public _max_num_reorder_pics_e__FixedBuffer max_num_reorder_pics;

        [InlineArray(7)]
        public partial struct _max_latency_increase_plus1_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(7)]
        public partial struct _max_dec_pic_buffering_minus1_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(7)]
        public partial struct _max_num_reorder_pics_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct StdVideoH265SubLayerHrdParameters
    {
            public _bit_rate_value_minus1_e__FixedBuffer bit_rate_value_minus1;

            public _cpb_size_value_minus1_e__FixedBuffer cpb_size_value_minus1;

            public _cpb_size_du_value_minus1_e__FixedBuffer cpb_size_du_value_minus1;

            public _bit_rate_du_value_minus1_e__FixedBuffer bit_rate_du_value_minus1;

            public uint cbr_flag;

        [InlineArray(32)]
        public partial struct _bit_rate_value_minus1_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(32)]
        public partial struct _cpb_size_value_minus1_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(32)]
        public partial struct _cpb_size_du_value_minus1_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(32)]
        public partial struct _bit_rate_du_value_minus1_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public partial struct StdVideoH265HrdFlags
    {
        public uint _bitfield;

            public uint nal_hrd_parameters_present_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint vcl_hrd_parameters_present_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint sub_pic_hrd_params_present_flag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint sub_pic_cpb_params_in_pic_timing_sei_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint fixed_pic_rate_general_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0xFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFu << 4)) | ((value & 0xFFu) << 4);
            }
        }

            public uint fixed_pic_rate_within_cvs_flag
        {
            readonly get
            {
                return (_bitfield >> 12) & 0xFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFu << 12)) | ((value & 0xFFu) << 12);
            }
        }

            public uint low_delay_hrd_flag
        {
            readonly get
            {
                return (_bitfield >> 20) & 0xFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFu << 20)) | ((value & 0xFFu) << 20);
            }
        }
    }

    public unsafe partial struct StdVideoH265HrdParameters
    {
        public StdVideoH265HrdFlags flags;

            public byte tick_divisor_minus2;

            public byte du_cpb_removal_delay_increment_length_minus1;

            public byte dpb_output_delay_du_length_minus1;

            public byte bit_rate_scale;

            public byte cpb_size_scale;

            public byte cpb_size_du_scale;

            public byte initial_cpb_removal_delay_length_minus1;

            public byte au_cpb_removal_delay_length_minus1;

            public byte dpb_output_delay_length_minus1;

            public _cpb_cnt_minus1_e__FixedBuffer cpb_cnt_minus1;

            public _elemental_duration_in_tc_minus1_e__FixedBuffer elemental_duration_in_tc_minus1;

            public _reserved_e__FixedBuffer reserved;

            public StdVideoH265SubLayerHrdParameters* pSubLayerHrdParametersNal;

            public StdVideoH265SubLayerHrdParameters* pSubLayerHrdParametersVcl;

        [InlineArray(7)]
        public partial struct _cpb_cnt_minus1_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(7)]
        public partial struct _elemental_duration_in_tc_minus1_e__FixedBuffer
        {
            public ushort e0;
        }

        [InlineArray(3)]
        public partial struct _reserved_e__FixedBuffer
        {
            public ushort e0;
        }
    }

    public partial struct StdVideoH265VpsFlags
    {
        public uint _bitfield;

            public uint vps_temporal_id_nesting_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint vps_sub_layer_ordering_info_present_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint vps_timing_info_present_flag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint vps_poc_proportional_to_timing_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }
    }

    public partial struct StdVideoH265ProfileTierLevelFlags
    {
        public uint _bitfield;

            public uint general_tier_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint general_progressive_source_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint general_interlaced_source_flag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint general_non_packed_constraint_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint general_frame_only_constraint_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }
    }

    public partial struct StdVideoH265ProfileTierLevel
    {
        public StdVideoH265ProfileTierLevelFlags flags;

        public StdVideoH265ProfileIdc general_profile_idc;

        public StdVideoH265LevelIdc general_level_idc;
    }

    public unsafe partial struct StdVideoH265VideoParameterSet
    {
        public StdVideoH265VpsFlags flags;

            public byte vps_video_parameter_set_id;

            public byte vps_max_sub_layers_minus1;

            public byte reserved1;

            public byte reserved2;

            public uint vps_num_units_in_tick;

            public uint vps_time_scale;

            public uint vps_num_ticks_poc_diff_one_minus1;

            public uint reserved3;

            public StdVideoH265DecPicBufMgr* pDecPicBufMgr;

            public StdVideoH265HrdParameters* pHrdParameters;

            public StdVideoH265ProfileTierLevel* pProfileTierLevel;
    }

    public partial struct StdVideoH265ScalingLists
    {
            public _ScalingList4x4_e__FixedBuffer ScalingList4x4;

            public _ScalingList8x8_e__FixedBuffer ScalingList8x8;

            public _ScalingList16x16_e__FixedBuffer ScalingList16x16;

            public _ScalingList32x32_e__FixedBuffer ScalingList32x32;

            public _ScalingListDCCoef16x16_e__FixedBuffer ScalingListDCCoef16x16;

            public _ScalingListDCCoef32x32_e__FixedBuffer ScalingListDCCoef32x32;

        [InlineArray(6 * 16)]
        public partial struct _ScalingList4x4_e__FixedBuffer
        {
            public byte e0_0;
        }

        [InlineArray(6 * 64)]
        public partial struct _ScalingList8x8_e__FixedBuffer
        {
            public byte e0_0;
        }

        [InlineArray(6 * 64)]
        public partial struct _ScalingList16x16_e__FixedBuffer
        {
            public byte e0_0;
        }

        [InlineArray(2 * 64)]
        public partial struct _ScalingList32x32_e__FixedBuffer
        {
            public byte e0_0;
        }

        [InlineArray(6)]
        public partial struct _ScalingListDCCoef16x16_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(2)]
        public partial struct _ScalingListDCCoef32x32_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct StdVideoH265SpsVuiFlags
    {
        public uint _bitfield;

            public uint aspect_ratio_info_present_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint overscan_info_present_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint overscan_appropriate_flag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint video_signal_type_present_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint video_full_range_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint colour_description_present_flag
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint chroma_loc_info_present_flag
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint neutral_chroma_indication_flag
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

            public uint field_seq_flag
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

            public uint frame_field_info_present_flag
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 9)) | ((value & 0x1u) << 9);
            }
        }

            public uint default_display_window_flag
        {
            readonly get
            {
                return (_bitfield >> 10) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 10)) | ((value & 0x1u) << 10);
            }
        }

            public uint vui_timing_info_present_flag
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 11)) | ((value & 0x1u) << 11);
            }
        }

            public uint vui_poc_proportional_to_timing_flag
        {
            readonly get
            {
                return (_bitfield >> 12) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 12)) | ((value & 0x1u) << 12);
            }
        }

            public uint vui_hrd_parameters_present_flag
        {
            readonly get
            {
                return (_bitfield >> 13) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 13)) | ((value & 0x1u) << 13);
            }
        }

            public uint bitstream_restriction_flag
        {
            readonly get
            {
                return (_bitfield >> 14) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 14)) | ((value & 0x1u) << 14);
            }
        }

            public uint tiles_fixed_structure_flag
        {
            readonly get
            {
                return (_bitfield >> 15) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 15)) | ((value & 0x1u) << 15);
            }
        }

            public uint motion_vectors_over_pic_boundaries_flag
        {
            readonly get
            {
                return (_bitfield >> 16) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 16)) | ((value & 0x1u) << 16);
            }
        }

            public uint restricted_ref_pic_lists_flag
        {
            readonly get
            {
                return (_bitfield >> 17) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 17)) | ((value & 0x1u) << 17);
            }
        }
    }

    public unsafe partial struct StdVideoH265SequenceParameterSetVui
    {
        public StdVideoH265SpsVuiFlags flags;

        public StdVideoH265AspectRatioIdc aspect_ratio_idc;

            public ushort sar_width;

            public ushort sar_height;

            public byte video_format;

            public byte colour_primaries;

            public byte transfer_characteristics;

            public byte matrix_coeffs;

            public byte chroma_sample_loc_type_top_field;

            public byte chroma_sample_loc_type_bottom_field;

            public byte reserved1;

            public byte reserved2;

            public ushort def_disp_win_left_offset;

            public ushort def_disp_win_right_offset;

            public ushort def_disp_win_top_offset;

            public ushort def_disp_win_bottom_offset;

            public uint vui_num_units_in_tick;

            public uint vui_time_scale;

            public uint vui_num_ticks_poc_diff_one_minus1;

            public ushort min_spatial_segmentation_idc;

            public ushort reserved3;

            public byte max_bytes_per_pic_denom;

            public byte max_bits_per_min_cu_denom;

            public byte log2_max_mv_length_horizontal;

            public byte log2_max_mv_length_vertical;

            public StdVideoH265HrdParameters* pHrdParameters;
    }

    public partial struct StdVideoH265PredictorPaletteEntries
    {
            public _PredictorPaletteEntries_e__FixedBuffer PredictorPaletteEntries;

        [InlineArray(3 * 128)]
        public partial struct _PredictorPaletteEntries_e__FixedBuffer
        {
            public ushort e0_0;
        }
    }

    public partial struct StdVideoH265SpsFlags
    {
        public uint _bitfield;

            public uint sps_temporal_id_nesting_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint separate_colour_plane_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint conformance_window_flag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint sps_sub_layer_ordering_info_present_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint scaling_list_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint sps_scaling_list_data_present_flag
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint amp_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint sample_adaptive_offset_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

            public uint pcm_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

            public uint pcm_loop_filter_disabled_flag
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 9)) | ((value & 0x1u) << 9);
            }
        }

            public uint long_term_ref_pics_present_flag
        {
            readonly get
            {
                return (_bitfield >> 10) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 10)) | ((value & 0x1u) << 10);
            }
        }

            public uint sps_temporal_mvp_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 11)) | ((value & 0x1u) << 11);
            }
        }

            public uint strong_intra_smoothing_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 12) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 12)) | ((value & 0x1u) << 12);
            }
        }

            public uint vui_parameters_present_flag
        {
            readonly get
            {
                return (_bitfield >> 13) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 13)) | ((value & 0x1u) << 13);
            }
        }

            public uint sps_extension_present_flag
        {
            readonly get
            {
                return (_bitfield >> 14) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 14)) | ((value & 0x1u) << 14);
            }
        }

            public uint sps_range_extension_flag
        {
            readonly get
            {
                return (_bitfield >> 15) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 15)) | ((value & 0x1u) << 15);
            }
        }

            public uint transform_skip_rotation_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 16) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 16)) | ((value & 0x1u) << 16);
            }
        }

            public uint transform_skip_context_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 17) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 17)) | ((value & 0x1u) << 17);
            }
        }

            public uint implicit_rdpcm_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 18) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 18)) | ((value & 0x1u) << 18);
            }
        }

            public uint explicit_rdpcm_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 19) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 19)) | ((value & 0x1u) << 19);
            }
        }

            public uint extended_precision_processing_flag
        {
            readonly get
            {
                return (_bitfield >> 20) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 20)) | ((value & 0x1u) << 20);
            }
        }

            public uint intra_smoothing_disabled_flag
        {
            readonly get
            {
                return (_bitfield >> 21) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 21)) | ((value & 0x1u) << 21);
            }
        }

            public uint high_precision_offsets_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 22) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 22)) | ((value & 0x1u) << 22);
            }
        }

            public uint persistent_rice_adaptation_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 23) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 23)) | ((value & 0x1u) << 23);
            }
        }

            public uint cabac_bypass_alignment_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 24) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 24)) | ((value & 0x1u) << 24);
            }
        }

            public uint sps_scc_extension_flag
        {
            readonly get
            {
                return (_bitfield >> 25) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 25)) | ((value & 0x1u) << 25);
            }
        }

            public uint sps_curr_pic_ref_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 26) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 26)) | ((value & 0x1u) << 26);
            }
        }

            public uint palette_mode_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 27) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 27)) | ((value & 0x1u) << 27);
            }
        }

            public uint sps_palette_predictor_initializers_present_flag
        {
            readonly get
            {
                return (_bitfield >> 28) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 28)) | ((value & 0x1u) << 28);
            }
        }

            public uint intra_boundary_filtering_disabled_flag
        {
            readonly get
            {
                return (_bitfield >> 29) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 29)) | ((value & 0x1u) << 29);
            }
        }
    }

    public partial struct StdVideoH265ShortTermRefPicSetFlags
    {
        public uint _bitfield;

            public uint inter_ref_pic_set_prediction_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint delta_rps_sign
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }
    }

    public partial struct StdVideoH265ShortTermRefPicSet
    {
        public StdVideoH265ShortTermRefPicSetFlags flags;

            public uint delta_idx_minus1;

            public ushort use_delta_flag;

            public ushort abs_delta_rps_minus1;

            public ushort used_by_curr_pic_flag;

            public ushort used_by_curr_pic_s0_flag;

            public ushort used_by_curr_pic_s1_flag;

            public ushort reserved1;

            public byte reserved2;

            public byte reserved3;

            public byte num_negative_pics;

            public byte num_positive_pics;

            public _delta_poc_s0_minus1_e__FixedBuffer delta_poc_s0_minus1;

            public _delta_poc_s1_minus1_e__FixedBuffer delta_poc_s1_minus1;

        [InlineArray(16)]
        public partial struct _delta_poc_s0_minus1_e__FixedBuffer
        {
            public ushort e0;
        }

        [InlineArray(16)]
        public partial struct _delta_poc_s1_minus1_e__FixedBuffer
        {
            public ushort e0;
        }
    }

    public partial struct StdVideoH265LongTermRefPicsSps
    {
            public uint used_by_curr_pic_lt_sps_flag;

            public _lt_ref_pic_poc_lsb_sps_e__FixedBuffer lt_ref_pic_poc_lsb_sps;

        [InlineArray(32)]
        public partial struct _lt_ref_pic_poc_lsb_sps_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public unsafe partial struct StdVideoH265SequenceParameterSet
    {
        public StdVideoH265SpsFlags flags;

        public StdVideoH265ChromaFormatIdc chroma_format_idc;

            public uint pic_width_in_luma_samples;

            public uint pic_height_in_luma_samples;

            public byte sps_video_parameter_set_id;

            public byte sps_max_sub_layers_minus1;

            public byte sps_seq_parameter_set_id;

            public byte bit_depth_luma_minus8;

            public byte bit_depth_chroma_minus8;

            public byte log2_max_pic_order_cnt_lsb_minus4;

            public byte log2_min_luma_coding_block_size_minus3;

            public byte log2_diff_max_min_luma_coding_block_size;

            public byte log2_min_luma_transform_block_size_minus2;

            public byte log2_diff_max_min_luma_transform_block_size;

            public byte max_transform_hierarchy_depth_inter;

            public byte max_transform_hierarchy_depth_intra;

            public byte num_short_term_ref_pic_sets;

            public byte num_long_term_ref_pics_sps;

            public byte pcm_sample_bit_depth_luma_minus1;

            public byte pcm_sample_bit_depth_chroma_minus1;

            public byte log2_min_pcm_luma_coding_block_size_minus3;

            public byte log2_diff_max_min_pcm_luma_coding_block_size;

            public byte reserved1;

            public byte reserved2;

            public byte palette_max_size;

            public byte delta_palette_max_predictor_size;

            public byte motion_vector_resolution_control_idc;

            public byte sps_num_palette_predictor_initializers_minus1;

            public uint conf_win_left_offset;

            public uint conf_win_right_offset;

            public uint conf_win_top_offset;

            public uint conf_win_bottom_offset;

            public StdVideoH265ProfileTierLevel* pProfileTierLevel;

            public StdVideoH265DecPicBufMgr* pDecPicBufMgr;

            public StdVideoH265ScalingLists* pScalingLists;

            public StdVideoH265ShortTermRefPicSet* pShortTermRefPicSet;

            public StdVideoH265LongTermRefPicsSps* pLongTermRefPicsSps;

            public StdVideoH265SequenceParameterSetVui* pSequenceParameterSetVui;

            public StdVideoH265PredictorPaletteEntries* pPredictorPaletteEntries;
    }

    public partial struct StdVideoH265PpsFlags
    {
        public uint _bitfield;

            public uint dependent_slice_segments_enabled_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint output_flag_present_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint sign_data_hiding_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint cabac_init_present_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint constrained_intra_pred_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint transform_skip_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint cu_qp_delta_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint pps_slice_chroma_qp_offsets_present_flag
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

            public uint weighted_pred_flag
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

            public uint weighted_bipred_flag
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 9)) | ((value & 0x1u) << 9);
            }
        }

            public uint transquant_bypass_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 10) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 10)) | ((value & 0x1u) << 10);
            }
        }

            public uint tiles_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 11)) | ((value & 0x1u) << 11);
            }
        }

            public uint entropy_coding_sync_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 12) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 12)) | ((value & 0x1u) << 12);
            }
        }

            public uint uniform_spacing_flag
        {
            readonly get
            {
                return (_bitfield >> 13) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 13)) | ((value & 0x1u) << 13);
            }
        }

            public uint loop_filter_across_tiles_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 14) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 14)) | ((value & 0x1u) << 14);
            }
        }

            public uint pps_loop_filter_across_slices_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 15) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 15)) | ((value & 0x1u) << 15);
            }
        }

            public uint deblocking_filter_control_present_flag
        {
            readonly get
            {
                return (_bitfield >> 16) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 16)) | ((value & 0x1u) << 16);
            }
        }

            public uint deblocking_filter_override_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 17) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 17)) | ((value & 0x1u) << 17);
            }
        }

            public uint pps_deblocking_filter_disabled_flag
        {
            readonly get
            {
                return (_bitfield >> 18) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 18)) | ((value & 0x1u) << 18);
            }
        }

            public uint pps_scaling_list_data_present_flag
        {
            readonly get
            {
                return (_bitfield >> 19) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 19)) | ((value & 0x1u) << 19);
            }
        }

            public uint lists_modification_present_flag
        {
            readonly get
            {
                return (_bitfield >> 20) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 20)) | ((value & 0x1u) << 20);
            }
        }

            public uint slice_segment_header_extension_present_flag
        {
            readonly get
            {
                return (_bitfield >> 21) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 21)) | ((value & 0x1u) << 21);
            }
        }

            public uint pps_extension_present_flag
        {
            readonly get
            {
                return (_bitfield >> 22) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 22)) | ((value & 0x1u) << 22);
            }
        }

            public uint cross_component_prediction_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 23) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 23)) | ((value & 0x1u) << 23);
            }
        }

            public uint chroma_qp_offset_list_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 24) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 24)) | ((value & 0x1u) << 24);
            }
        }

            public uint pps_curr_pic_ref_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 25) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 25)) | ((value & 0x1u) << 25);
            }
        }

            public uint residual_adaptive_colour_transform_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 26) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 26)) | ((value & 0x1u) << 26);
            }
        }

            public uint pps_slice_act_qp_offsets_present_flag
        {
            readonly get
            {
                return (_bitfield >> 27) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 27)) | ((value & 0x1u) << 27);
            }
        }

            public uint pps_palette_predictor_initializers_present_flag
        {
            readonly get
            {
                return (_bitfield >> 28) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 28)) | ((value & 0x1u) << 28);
            }
        }

            public uint monochrome_palette_flag
        {
            readonly get
            {
                return (_bitfield >> 29) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 29)) | ((value & 0x1u) << 29);
            }
        }

            public uint pps_range_extension_flag
        {
            readonly get
            {
                return (_bitfield >> 30) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 30)) | ((value & 0x1u) << 30);
            }
        }
    }

    public unsafe partial struct StdVideoH265PictureParameterSet
    {
        public StdVideoH265PpsFlags flags;

            public byte pps_pic_parameter_set_id;

            public byte pps_seq_parameter_set_id;

            public byte sps_video_parameter_set_id;

            public byte num_extra_slice_header_bits;

            public byte num_ref_idx_l0_default_active_minus1;

            public byte num_ref_idx_l1_default_active_minus1;

            public sbyte init_qp_minus26;

            public byte diff_cu_qp_delta_depth;

            public sbyte pps_cb_qp_offset;

            public sbyte pps_cr_qp_offset;

            public sbyte pps_beta_offset_div2;

            public sbyte pps_tc_offset_div2;

            public byte log2_parallel_merge_level_minus2;

            public byte log2_max_transform_skip_block_size_minus2;

            public byte diff_cu_chroma_qp_offset_depth;

            public byte chroma_qp_offset_list_len_minus1;

            public _cb_qp_offset_list_e__FixedBuffer cb_qp_offset_list;

            public _cr_qp_offset_list_e__FixedBuffer cr_qp_offset_list;

            public byte log2_sao_offset_scale_luma;

            public byte log2_sao_offset_scale_chroma;

            public sbyte pps_act_y_qp_offset_plus5;

            public sbyte pps_act_cb_qp_offset_plus5;

            public sbyte pps_act_cr_qp_offset_plus3;

            public byte pps_num_palette_predictor_initializers;

            public byte luma_bit_depth_entry_minus8;

            public byte chroma_bit_depth_entry_minus8;

            public byte num_tile_columns_minus1;

            public byte num_tile_rows_minus1;

            public byte reserved1;

            public byte reserved2;

            public _column_width_minus1_e__FixedBuffer column_width_minus1;

            public _row_height_minus1_e__FixedBuffer row_height_minus1;

            public uint reserved3;

            public StdVideoH265ScalingLists* pScalingLists;

            public StdVideoH265PredictorPaletteEntries* pPredictorPaletteEntries;

        [InlineArray(6)]
        public partial struct _cb_qp_offset_list_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(6)]
        public partial struct _cr_qp_offset_list_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(19)]
        public partial struct _column_width_minus1_e__FixedBuffer
        {
            public ushort e0;
        }

        [InlineArray(21)]
        public partial struct _row_height_minus1_e__FixedBuffer
        {
            public ushort e0;
        }
    }

    public partial struct StdVideoDecodeH265PictureInfoFlags
    {
        public uint _bitfield;

            public uint IrapPicFlag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint IdrPicFlag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint IsReference
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint short_term_ref_pic_set_sps_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }
    }

    public partial struct StdVideoDecodeH265PictureInfo
    {
        public StdVideoDecodeH265PictureInfoFlags flags;

            public byte sps_video_parameter_set_id;

            public byte pps_seq_parameter_set_id;

            public byte pps_pic_parameter_set_id;

            public byte NumDeltaPocsOfRefRpsIdx;

            public int PicOrderCntVal;

            public ushort NumBitsForSTRefPicSetInSlice;

            public ushort reserved;

            public _RefPicSetStCurrBefore_e__FixedBuffer RefPicSetStCurrBefore;

            public _RefPicSetStCurrAfter_e__FixedBuffer RefPicSetStCurrAfter;

            public _RefPicSetLtCurr_e__FixedBuffer RefPicSetLtCurr;

        [InlineArray(8)]
        public partial struct _RefPicSetStCurrBefore_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8)]
        public partial struct _RefPicSetStCurrAfter_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8)]
        public partial struct _RefPicSetLtCurr_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct StdVideoDecodeH265ReferenceInfoFlags
    {
        public uint _bitfield;

            public uint used_for_long_term_reference
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint unused_for_reference
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }
    }

    public partial struct StdVideoDecodeH265ReferenceInfo
    {
        public StdVideoDecodeH265ReferenceInfoFlags flags;

            public int PicOrderCntVal;
    }

    public partial struct StdVideoEncodeH265WeightTableFlags
    {
            public ushort luma_weight_l0_flag;

            public ushort chroma_weight_l0_flag;

            public ushort luma_weight_l1_flag;

            public ushort chroma_weight_l1_flag;
    }

    public partial struct StdVideoEncodeH265WeightTable
    {
        public StdVideoEncodeH265WeightTableFlags flags;

            public byte luma_log2_weight_denom;

            public sbyte delta_chroma_log2_weight_denom;

            public _delta_luma_weight_l0_e__FixedBuffer delta_luma_weight_l0;

            public _luma_offset_l0_e__FixedBuffer luma_offset_l0;

            public _delta_chroma_weight_l0_e__FixedBuffer delta_chroma_weight_l0;

            public _delta_chroma_offset_l0_e__FixedBuffer delta_chroma_offset_l0;

            public _delta_luma_weight_l1_e__FixedBuffer delta_luma_weight_l1;

            public _luma_offset_l1_e__FixedBuffer luma_offset_l1;

            public _delta_chroma_weight_l1_e__FixedBuffer delta_chroma_weight_l1;

            public _delta_chroma_offset_l1_e__FixedBuffer delta_chroma_offset_l1;

        [InlineArray(15)]
        public partial struct _delta_luma_weight_l0_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(15)]
        public partial struct _luma_offset_l0_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(15 * 2)]
        public partial struct _delta_chroma_weight_l0_e__FixedBuffer
        {
            public sbyte e0_0;
        }

        [InlineArray(15 * 2)]
        public partial struct _delta_chroma_offset_l0_e__FixedBuffer
        {
            public sbyte e0_0;
        }

        [InlineArray(15)]
        public partial struct _delta_luma_weight_l1_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(15)]
        public partial struct _luma_offset_l1_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(15 * 2)]
        public partial struct _delta_chroma_weight_l1_e__FixedBuffer
        {
            public sbyte e0_0;
        }

        [InlineArray(15 * 2)]
        public partial struct _delta_chroma_offset_l1_e__FixedBuffer
        {
            public sbyte e0_0;
        }
    }

    public partial struct StdVideoEncodeH265SliceSegmentHeaderFlags
    {
        public uint _bitfield;

            public uint first_slice_segment_in_pic_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint dependent_slice_segment_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint slice_sao_luma_flag
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint slice_sao_chroma_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint num_ref_idx_active_override_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint mvd_l1_zero_flag
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint cabac_init_flag
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint cu_chroma_qp_offset_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

            public uint deblocking_filter_override_flag
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

            public uint slice_deblocking_filter_disabled_flag
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 9)) | ((value & 0x1u) << 9);
            }
        }

            public uint collocated_from_l0_flag
        {
            readonly get
            {
                return (_bitfield >> 10) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 10)) | ((value & 0x1u) << 10);
            }
        }

            public uint slice_loop_filter_across_slices_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 11)) | ((value & 0x1u) << 11);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 12) & 0xFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFFFFu << 12)) | ((value & 0xFFFFFu) << 12);
            }
        }
    }

    public unsafe partial struct StdVideoEncodeH265SliceSegmentHeader
    {
        public StdVideoEncodeH265SliceSegmentHeaderFlags flags;

        public StdVideoH265SliceType slice_type;

            public uint slice_segment_address;

            public byte collocated_ref_idx;

            public byte MaxNumMergeCand;

            public sbyte slice_cb_qp_offset;

            public sbyte slice_cr_qp_offset;

            public sbyte slice_beta_offset_div2;

            public sbyte slice_tc_offset_div2;

            public sbyte slice_act_y_qp_offset;

            public sbyte slice_act_cb_qp_offset;

            public sbyte slice_act_cr_qp_offset;

            public sbyte slice_qp_delta;

            public ushort reserved1;

            public StdVideoEncodeH265WeightTable* pWeightTable;
    }

    public partial struct StdVideoEncodeH265ReferenceListsInfoFlags
    {
        public uint _bitfield;

            public uint ref_pic_list_modification_flag_l0
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint ref_pic_list_modification_flag_l1
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }
    }

    public partial struct StdVideoEncodeH265ReferenceListsInfo
    {
        public StdVideoEncodeH265ReferenceListsInfoFlags flags;

            public byte num_ref_idx_l0_active_minus1;

            public byte num_ref_idx_l1_active_minus1;

            public _RefPicList0_e__FixedBuffer RefPicList0;

            public _RefPicList1_e__FixedBuffer RefPicList1;

            public _list_entry_l0_e__FixedBuffer list_entry_l0;

            public _list_entry_l1_e__FixedBuffer list_entry_l1;

        [InlineArray(15)]
        public partial struct _RefPicList0_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(15)]
        public partial struct _RefPicList1_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(15)]
        public partial struct _list_entry_l0_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(15)]
        public partial struct _list_entry_l1_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct StdVideoEncodeH265PictureInfoFlags
    {
        public uint _bitfield;

            public uint is_reference
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint IrapPicFlag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint used_for_long_term_reference
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint discardable_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint cross_layer_bla_flag
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint pic_output_flag
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint no_output_of_prior_pics_flag
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint short_term_ref_pic_set_sps_flag
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

            public uint slice_temporal_mvp_enabled_flag
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x7FFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFu << 9)) | ((value & 0x7FFFFFu) << 9);
            }
        }
    }

    public partial struct StdVideoEncodeH265LongTermRefPics
    {
            public byte num_long_term_sps;

            public byte num_long_term_pics;

            public _lt_idx_sps_e__FixedBuffer lt_idx_sps;

            public _poc_lsb_lt_e__FixedBuffer poc_lsb_lt;

            public ushort used_by_curr_pic_lt_flag;

            public _delta_poc_msb_present_flag_e__FixedBuffer delta_poc_msb_present_flag;

            public _delta_poc_msb_cycle_lt_e__FixedBuffer delta_poc_msb_cycle_lt;

        [InlineArray(32)]
        public partial struct _lt_idx_sps_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(16)]
        public partial struct _poc_lsb_lt_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(48)]
        public partial struct _delta_poc_msb_present_flag_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(48)]
        public partial struct _delta_poc_msb_cycle_lt_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct StdVideoEncodeH265PictureInfo
    {
        public StdVideoEncodeH265PictureInfoFlags flags;

        public StdVideoH265PictureType pic_type;

            public byte sps_video_parameter_set_id;

            public byte pps_seq_parameter_set_id;

            public byte pps_pic_parameter_set_id;

            public byte short_term_ref_pic_set_idx;

            public int PicOrderCntVal;

            public byte TemporalId;

            public _reserved1_e__FixedBuffer reserved1;

            public StdVideoEncodeH265ReferenceListsInfo* pRefLists;

            public StdVideoH265ShortTermRefPicSet* pShortTermRefPicSet;

            public StdVideoEncodeH265LongTermRefPics* pLongTermRefPics;

        [InlineArray(7)]
        public partial struct _reserved1_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct StdVideoEncodeH265ReferenceInfoFlags
    {
        public uint _bitfield;

            public uint used_for_long_term_reference
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint unused_for_reference
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }
    }

    public partial struct StdVideoEncodeH265ReferenceInfo
    {
        public StdVideoEncodeH265ReferenceInfoFlags flags;

        public StdVideoH265PictureType pic_type;

            public int PicOrderCntVal;

            public byte TemporalId;
    }

    public enum StdVideoAV1Profile : uint
    {
        STD_VIDEO_AV1_PROFILE_MAIN = 0,
        STD_VIDEO_AV1_PROFILE_HIGH = 1,
        STD_VIDEO_AV1_PROFILE_PROFESSIONAL = 2,
        STD_VIDEO_AV1_PROFILE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_AV1_PROFILE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoAV1Level : uint
    {
        STD_VIDEO_AV1_LEVEL_2_0 = 0,
        STD_VIDEO_AV1_LEVEL_2_1 = 1,
        STD_VIDEO_AV1_LEVEL_2_2 = 2,
        STD_VIDEO_AV1_LEVEL_2_3 = 3,
        STD_VIDEO_AV1_LEVEL_3_0 = 4,
        STD_VIDEO_AV1_LEVEL_3_1 = 5,
        STD_VIDEO_AV1_LEVEL_3_2 = 6,
        STD_VIDEO_AV1_LEVEL_3_3 = 7,
        STD_VIDEO_AV1_LEVEL_4_0 = 8,
        STD_VIDEO_AV1_LEVEL_4_1 = 9,
        STD_VIDEO_AV1_LEVEL_4_2 = 10,
        STD_VIDEO_AV1_LEVEL_4_3 = 11,
        STD_VIDEO_AV1_LEVEL_5_0 = 12,
        STD_VIDEO_AV1_LEVEL_5_1 = 13,
        STD_VIDEO_AV1_LEVEL_5_2 = 14,
        STD_VIDEO_AV1_LEVEL_5_3 = 15,
        STD_VIDEO_AV1_LEVEL_6_0 = 16,
        STD_VIDEO_AV1_LEVEL_6_1 = 17,
        STD_VIDEO_AV1_LEVEL_6_2 = 18,
        STD_VIDEO_AV1_LEVEL_6_3 = 19,
        STD_VIDEO_AV1_LEVEL_7_0 = 20,
        STD_VIDEO_AV1_LEVEL_7_1 = 21,
        STD_VIDEO_AV1_LEVEL_7_2 = 22,
        STD_VIDEO_AV1_LEVEL_7_3 = 23,
        STD_VIDEO_AV1_LEVEL_INVALID = 0x7FFFFFFF,
        STD_VIDEO_AV1_LEVEL_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoAV1FrameType : uint
    {
        STD_VIDEO_AV1_FRAME_TYPE_KEY = 0,
        STD_VIDEO_AV1_FRAME_TYPE_INTER = 1,
        STD_VIDEO_AV1_FRAME_TYPE_INTRA_ONLY = 2,
        STD_VIDEO_AV1_FRAME_TYPE_SWITCH = 3,
        STD_VIDEO_AV1_FRAME_TYPE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_AV1_FRAME_TYPE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoAV1ReferenceName : uint
    {
        STD_VIDEO_AV1_REFERENCE_NAME_INTRA_FRAME = 0,
        STD_VIDEO_AV1_REFERENCE_NAME_LAST_FRAME = 1,
        STD_VIDEO_AV1_REFERENCE_NAME_LAST2_FRAME = 2,
        STD_VIDEO_AV1_REFERENCE_NAME_LAST3_FRAME = 3,
        STD_VIDEO_AV1_REFERENCE_NAME_GOLDEN_FRAME = 4,
        STD_VIDEO_AV1_REFERENCE_NAME_BWDREF_FRAME = 5,
        STD_VIDEO_AV1_REFERENCE_NAME_ALTREF2_FRAME = 6,
        STD_VIDEO_AV1_REFERENCE_NAME_ALTREF_FRAME = 7,
        STD_VIDEO_AV1_REFERENCE_NAME_INVALID = 0x7FFFFFFF,
        STD_VIDEO_AV1_REFERENCE_NAME_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoAV1InterpolationFilter : uint
    {
        STD_VIDEO_AV1_INTERPOLATION_FILTER_EIGHTTAP = 0,
        STD_VIDEO_AV1_INTERPOLATION_FILTER_EIGHTTAP_SMOOTH = 1,
        STD_VIDEO_AV1_INTERPOLATION_FILTER_EIGHTTAP_SHARP = 2,
        STD_VIDEO_AV1_INTERPOLATION_FILTER_BILINEAR = 3,
        STD_VIDEO_AV1_INTERPOLATION_FILTER_SWITCHABLE = 4,
        STD_VIDEO_AV1_INTERPOLATION_FILTER_INVALID = 0x7FFFFFFF,
        STD_VIDEO_AV1_INTERPOLATION_FILTER_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoAV1TxMode : uint
    {
        STD_VIDEO_AV1_TX_MODE_ONLY_4X4 = 0,
        STD_VIDEO_AV1_TX_MODE_LARGEST = 1,
        STD_VIDEO_AV1_TX_MODE_SELECT = 2,
        STD_VIDEO_AV1_TX_MODE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_AV1_TX_MODE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoAV1FrameRestorationType : uint
    {
        STD_VIDEO_AV1_FRAME_RESTORATION_TYPE_NONE = 0,
        STD_VIDEO_AV1_FRAME_RESTORATION_TYPE_WIENER = 1,
        STD_VIDEO_AV1_FRAME_RESTORATION_TYPE_SGRPROJ = 2,
        STD_VIDEO_AV1_FRAME_RESTORATION_TYPE_SWITCHABLE = 3,
        STD_VIDEO_AV1_FRAME_RESTORATION_TYPE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_AV1_FRAME_RESTORATION_TYPE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoAV1ColorPrimaries : uint
    {
        STD_VIDEO_AV1_COLOR_PRIMARIES_BT_709 = 1,
        STD_VIDEO_AV1_COLOR_PRIMARIES_UNSPECIFIED = 2,
        STD_VIDEO_AV1_COLOR_PRIMARIES_BT_470_M = 4,
        STD_VIDEO_AV1_COLOR_PRIMARIES_BT_470_B_G = 5,
        STD_VIDEO_AV1_COLOR_PRIMARIES_BT_601 = 6,
        STD_VIDEO_AV1_COLOR_PRIMARIES_SMPTE_240 = 7,
        STD_VIDEO_AV1_COLOR_PRIMARIES_GENERIC_FILM = 8,
        STD_VIDEO_AV1_COLOR_PRIMARIES_BT_2020 = 9,
        STD_VIDEO_AV1_COLOR_PRIMARIES_XYZ = 10,
        STD_VIDEO_AV1_COLOR_PRIMARIES_SMPTE_431 = 11,
        STD_VIDEO_AV1_COLOR_PRIMARIES_SMPTE_432 = 12,
        STD_VIDEO_AV1_COLOR_PRIMARIES_EBU_3213 = 22,
        STD_VIDEO_AV1_COLOR_PRIMARIES_INVALID = 0x7FFFFFFF,
        STD_VIDEO_AV1_COLOR_PRIMARIES_BT_UNSPECIFIED = STD_VIDEO_AV1_COLOR_PRIMARIES_UNSPECIFIED,
        STD_VIDEO_AV1_COLOR_PRIMARIES_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoAV1TransferCharacteristics : uint
    {
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_RESERVED_0 = 0,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_BT_709 = 1,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_UNSPECIFIED = 2,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_RESERVED_3 = 3,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_BT_470_M = 4,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_BT_470_B_G = 5,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_BT_601 = 6,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_SMPTE_240 = 7,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_LINEAR = 8,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_LOG_100 = 9,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_LOG_100_SQRT10 = 10,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_IEC_61966 = 11,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_BT_1361 = 12,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_SRGB = 13,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_BT_2020_10_BIT = 14,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_BT_2020_12_BIT = 15,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_SMPTE_2084 = 16,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_SMPTE_428 = 17,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_HLG = 18,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_INVALID = 0x7FFFFFFF,
        STD_VIDEO_AV1_TRANSFER_CHARACTERISTICS_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoAV1MatrixCoefficients : uint
    {
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_IDENTITY = 0,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_BT_709 = 1,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_UNSPECIFIED = 2,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_RESERVED_3 = 3,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_FCC = 4,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_BT_470_B_G = 5,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_BT_601 = 6,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_SMPTE_240 = 7,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_SMPTE_YCGCO = 8,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_BT_2020_NCL = 9,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_BT_2020_CL = 10,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_SMPTE_2085 = 11,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_CHROMAT_NCL = 12,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_CHROMAT_CL = 13,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_ICTCP = 14,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_INVALID = 0x7FFFFFFF,
        STD_VIDEO_AV1_MATRIX_COEFFICIENTS_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoAV1ChromaSamplePosition : uint
    {
        STD_VIDEO_AV1_CHROMA_SAMPLE_POSITION_UNKNOWN = 0,
        STD_VIDEO_AV1_CHROMA_SAMPLE_POSITION_VERTICAL = 1,
        STD_VIDEO_AV1_CHROMA_SAMPLE_POSITION_COLOCATED = 2,
        STD_VIDEO_AV1_CHROMA_SAMPLE_POSITION_RESERVED = 3,
        STD_VIDEO_AV1_CHROMA_SAMPLE_POSITION_INVALID = 0x7FFFFFFF,
        STD_VIDEO_AV1_CHROMA_SAMPLE_POSITION_MAX_ENUM = 0x7FFFFFFF,
    }

    public partial struct StdVideoAV1ColorConfigFlags
    {
        public uint _bitfield;

            public uint mono_chrome
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint color_range
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint separate_uv_delta_q
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint color_description_present_flag
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 4) & 0xFFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFFFFFFu << 4)) | ((value & 0xFFFFFFFu) << 4);
            }
        }
    }

    public partial struct StdVideoAV1ColorConfig
    {
        public StdVideoAV1ColorConfigFlags flags;

            public byte BitDepth;

            public byte subsampling_x;

            public byte subsampling_y;

            public byte reserved1;

        public StdVideoAV1ColorPrimaries color_primaries;

        public StdVideoAV1TransferCharacteristics transfer_characteristics;

        public StdVideoAV1MatrixCoefficients matrix_coefficients;

        public StdVideoAV1ChromaSamplePosition chroma_sample_position;
    }

    public partial struct StdVideoAV1TimingInfoFlags
    {
        public uint _bitfield;

            public uint equal_picture_interval
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }
    }

    public partial struct StdVideoAV1TimingInfo
    {
        public StdVideoAV1TimingInfoFlags flags;

            public uint num_units_in_display_tick;

            public uint time_scale;

            public uint num_ticks_per_picture_minus_1;
    }

    public partial struct StdVideoAV1LoopFilterFlags
    {
        public uint _bitfield;

            public uint loop_filter_delta_enabled
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint loop_filter_delta_update
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }
    }

    public partial struct StdVideoAV1LoopFilter
    {
        public StdVideoAV1LoopFilterFlags flags;

            public _loop_filter_level_e__FixedBuffer loop_filter_level;

            public byte loop_filter_sharpness;

            public byte update_ref_delta;

            public _loop_filter_ref_deltas_e__FixedBuffer loop_filter_ref_deltas;

            public byte update_mode_delta;

            public _loop_filter_mode_deltas_e__FixedBuffer loop_filter_mode_deltas;

        [InlineArray(4)]
        public partial struct _loop_filter_level_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8)]
        public partial struct _loop_filter_ref_deltas_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(2)]
        public partial struct _loop_filter_mode_deltas_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public partial struct StdVideoAV1QuantizationFlags
    {
        public uint _bitfield;

            public uint using_qmatrix
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint diff_uv_delta
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }
    }

    public partial struct StdVideoAV1Quantization
    {
        public StdVideoAV1QuantizationFlags flags;

            public byte base_q_idx;

            public sbyte DeltaQYDc;

            public sbyte DeltaQUDc;

            public sbyte DeltaQUAc;

            public sbyte DeltaQVDc;

            public sbyte DeltaQVAc;

            public byte qm_y;

            public byte qm_u;

            public byte qm_v;
    }

    public partial struct StdVideoAV1Segmentation
    {
            public _FeatureEnabled_e__FixedBuffer FeatureEnabled;

            public _FeatureData_e__FixedBuffer FeatureData;

        [InlineArray(8)]
        public partial struct _FeatureEnabled_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8 * 8)]
        public partial struct _FeatureData_e__FixedBuffer
        {
            public short e0_0;
        }
    }

    public partial struct StdVideoAV1TileInfoFlags
    {
        public uint _bitfield;

            public uint uniform_tile_spacing_flag
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }
    }

    public unsafe partial struct StdVideoAV1TileInfo
    {
        public StdVideoAV1TileInfoFlags flags;

            public byte TileCols;

            public byte TileRows;

            public ushort context_update_tile_id;

            public byte tile_size_bytes_minus_1;

            public _reserved1_e__FixedBuffer reserved1;

            public ushort* pMiColStarts;

            public ushort* pMiRowStarts;

            public ushort* pWidthInSbsMinus1;

            public ushort* pHeightInSbsMinus1;

        [InlineArray(7)]
        public partial struct _reserved1_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct StdVideoAV1CDEF
    {
            public byte cdef_damping_minus_3;

            public byte cdef_bits;

            public _cdef_y_pri_strength_e__FixedBuffer cdef_y_pri_strength;

            public _cdef_y_sec_strength_e__FixedBuffer cdef_y_sec_strength;

            public _cdef_uv_pri_strength_e__FixedBuffer cdef_uv_pri_strength;

            public _cdef_uv_sec_strength_e__FixedBuffer cdef_uv_sec_strength;

        [InlineArray(8)]
        public partial struct _cdef_y_pri_strength_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8)]
        public partial struct _cdef_y_sec_strength_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8)]
        public partial struct _cdef_uv_pri_strength_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8)]
        public partial struct _cdef_uv_sec_strength_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct StdVideoAV1LoopRestoration
    {
            public _FrameRestorationType_e__FixedBuffer FrameRestorationType;

            public _LoopRestorationSize_e__FixedBuffer LoopRestorationSize;

        [InlineArray(3)]
        public partial struct _FrameRestorationType_e__FixedBuffer
        {
            public StdVideoAV1FrameRestorationType e0;
        }

        [InlineArray(3)]
        public partial struct _LoopRestorationSize_e__FixedBuffer
        {
            public ushort e0;
        }
    }

    public partial struct StdVideoAV1GlobalMotion
    {
            public _GmType_e__FixedBuffer GmType;

            public _gm_params_e__FixedBuffer gm_params;

        [InlineArray(8)]
        public partial struct _GmType_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8 * 6)]
        public partial struct _gm_params_e__FixedBuffer
        {
            public int e0_0;
        }
    }

    public partial struct StdVideoAV1FilmGrainFlags
    {
        public uint _bitfield;

            public uint chroma_scaling_from_luma
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint overlap_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint clip_to_restricted_range
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint update_grain
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 4) & 0xFFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFFFFFFu << 4)) | ((value & 0xFFFFFFFu) << 4);
            }
        }
    }

    public partial struct StdVideoAV1FilmGrain
    {
        public StdVideoAV1FilmGrainFlags flags;

            public byte grain_scaling_minus_8;

            public byte ar_coeff_lag;

            public byte ar_coeff_shift_minus_6;

            public byte grain_scale_shift;

            public ushort grain_seed;

            public byte film_grain_params_ref_idx;

            public byte num_y_points;

            public _point_y_value_e__FixedBuffer point_y_value;

            public _point_y_scaling_e__FixedBuffer point_y_scaling;

            public byte num_cb_points;

            public _point_cb_value_e__FixedBuffer point_cb_value;

            public _point_cb_scaling_e__FixedBuffer point_cb_scaling;

            public byte num_cr_points;

            public _point_cr_value_e__FixedBuffer point_cr_value;

            public _point_cr_scaling_e__FixedBuffer point_cr_scaling;

            public _ar_coeffs_y_plus_128_e__FixedBuffer ar_coeffs_y_plus_128;

            public _ar_coeffs_cb_plus_128_e__FixedBuffer ar_coeffs_cb_plus_128;

            public _ar_coeffs_cr_plus_128_e__FixedBuffer ar_coeffs_cr_plus_128;

            public byte cb_mult;

            public byte cb_luma_mult;

            public ushort cb_offset;

            public byte cr_mult;

            public byte cr_luma_mult;

            public ushort cr_offset;

        [InlineArray(14)]
        public partial struct _point_y_value_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(14)]
        public partial struct _point_y_scaling_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(10)]
        public partial struct _point_cb_value_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(10)]
        public partial struct _point_cb_scaling_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(10)]
        public partial struct _point_cr_value_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(10)]
        public partial struct _point_cr_scaling_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(24)]
        public partial struct _ar_coeffs_y_plus_128_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(25)]
        public partial struct _ar_coeffs_cb_plus_128_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(25)]
        public partial struct _ar_coeffs_cr_plus_128_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public partial struct StdVideoAV1SequenceHeaderFlags
    {
        public uint _bitfield;

            public uint still_picture
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint reduced_still_picture_header
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint use_128x128_superblock
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint enable_filter_intra
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint enable_intra_edge_filter
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint enable_interintra_compound
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint enable_masked_compound
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint enable_warped_motion
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

            public uint enable_dual_filter
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

            public uint enable_order_hint
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 9)) | ((value & 0x1u) << 9);
            }
        }

            public uint enable_jnt_comp
        {
            readonly get
            {
                return (_bitfield >> 10) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 10)) | ((value & 0x1u) << 10);
            }
        }

            public uint enable_ref_frame_mvs
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 11)) | ((value & 0x1u) << 11);
            }
        }

            public uint frame_id_numbers_present_flag
        {
            readonly get
            {
                return (_bitfield >> 12) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 12)) | ((value & 0x1u) << 12);
            }
        }

            public uint enable_superres
        {
            readonly get
            {
                return (_bitfield >> 13) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 13)) | ((value & 0x1u) << 13);
            }
        }

            public uint enable_cdef
        {
            readonly get
            {
                return (_bitfield >> 14) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 14)) | ((value & 0x1u) << 14);
            }
        }

            public uint enable_restoration
        {
            readonly get
            {
                return (_bitfield >> 15) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 15)) | ((value & 0x1u) << 15);
            }
        }

            public uint film_grain_params_present
        {
            readonly get
            {
                return (_bitfield >> 16) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 16)) | ((value & 0x1u) << 16);
            }
        }

            public uint timing_info_present_flag
        {
            readonly get
            {
                return (_bitfield >> 17) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 17)) | ((value & 0x1u) << 17);
            }
        }

            public uint initial_display_delay_present_flag
        {
            readonly get
            {
                return (_bitfield >> 18) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 18)) | ((value & 0x1u) << 18);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 19) & 0x1FFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1FFFu << 19)) | ((value & 0x1FFFu) << 19);
            }
        }
    }

    public unsafe partial struct StdVideoAV1SequenceHeader
    {
        public StdVideoAV1SequenceHeaderFlags flags;

        public StdVideoAV1Profile seq_profile;

            public byte frame_width_bits_minus_1;

            public byte frame_height_bits_minus_1;

            public ushort max_frame_width_minus_1;

            public ushort max_frame_height_minus_1;

            public byte delta_frame_id_length_minus_2;

            public byte additional_frame_id_length_minus_1;

            public byte order_hint_bits_minus_1;

            public byte seq_force_integer_mv;

            public byte seq_force_screen_content_tools;

            public _reserved1_e__FixedBuffer reserved1;

            public StdVideoAV1ColorConfig* pColorConfig;

            public StdVideoAV1TimingInfo* pTimingInfo;

        [InlineArray(5)]
        public partial struct _reserved1_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct StdVideoDecodeAV1PictureInfoFlags
    {
        public uint _bitfield;

            public uint error_resilient_mode
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint disable_cdf_update
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint use_superres
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint render_and_frame_size_different
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint allow_screen_content_tools
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint is_filter_switchable
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint force_integer_mv
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint frame_size_override_flag
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

            public uint buffer_removal_time_present_flag
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

            public uint allow_intrabc
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 9)) | ((value & 0x1u) << 9);
            }
        }

            public uint frame_refs_short_signaling
        {
            readonly get
            {
                return (_bitfield >> 10) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 10)) | ((value & 0x1u) << 10);
            }
        }

            public uint allow_high_precision_mv
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 11)) | ((value & 0x1u) << 11);
            }
        }

            public uint is_motion_mode_switchable
        {
            readonly get
            {
                return (_bitfield >> 12) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 12)) | ((value & 0x1u) << 12);
            }
        }

            public uint use_ref_frame_mvs
        {
            readonly get
            {
                return (_bitfield >> 13) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 13)) | ((value & 0x1u) << 13);
            }
        }

            public uint disable_frame_end_update_cdf
        {
            readonly get
            {
                return (_bitfield >> 14) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 14)) | ((value & 0x1u) << 14);
            }
        }

            public uint allow_warped_motion
        {
            readonly get
            {
                return (_bitfield >> 15) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 15)) | ((value & 0x1u) << 15);
            }
        }

            public uint reduced_tx_set
        {
            readonly get
            {
                return (_bitfield >> 16) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 16)) | ((value & 0x1u) << 16);
            }
        }

            public uint reference_select
        {
            readonly get
            {
                return (_bitfield >> 17) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 17)) | ((value & 0x1u) << 17);
            }
        }

            public uint skip_mode_present
        {
            readonly get
            {
                return (_bitfield >> 18) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 18)) | ((value & 0x1u) << 18);
            }
        }

            public uint delta_q_present
        {
            readonly get
            {
                return (_bitfield >> 19) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 19)) | ((value & 0x1u) << 19);
            }
        }

            public uint delta_lf_present
        {
            readonly get
            {
                return (_bitfield >> 20) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 20)) | ((value & 0x1u) << 20);
            }
        }

            public uint delta_lf_multi
        {
            readonly get
            {
                return (_bitfield >> 21) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 21)) | ((value & 0x1u) << 21);
            }
        }

            public uint segmentation_enabled
        {
            readonly get
            {
                return (_bitfield >> 22) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 22)) | ((value & 0x1u) << 22);
            }
        }

            public uint segmentation_update_map
        {
            readonly get
            {
                return (_bitfield >> 23) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 23)) | ((value & 0x1u) << 23);
            }
        }

            public uint segmentation_temporal_update
        {
            readonly get
            {
                return (_bitfield >> 24) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 24)) | ((value & 0x1u) << 24);
            }
        }

            public uint segmentation_update_data
        {
            readonly get
            {
                return (_bitfield >> 25) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 25)) | ((value & 0x1u) << 25);
            }
        }

            public uint UsesLr
        {
            readonly get
            {
                return (_bitfield >> 26) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 26)) | ((value & 0x1u) << 26);
            }
        }

            public uint usesChromaLr
        {
            readonly get
            {
                return (_bitfield >> 27) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 27)) | ((value & 0x1u) << 27);
            }
        }

            public uint apply_grain
        {
            readonly get
            {
                return (_bitfield >> 28) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 28)) | ((value & 0x1u) << 28);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 29) & 0x7u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7u << 29)) | ((value & 0x7u) << 29);
            }
        }
    }

    public unsafe partial struct StdVideoDecodeAV1PictureInfo
    {
        public StdVideoDecodeAV1PictureInfoFlags flags;

        public StdVideoAV1FrameType frame_type;

            public uint current_frame_id;

            public byte OrderHint;

            public byte primary_ref_frame;

            public byte refresh_frame_flags;

            public byte reserved1;

        public StdVideoAV1InterpolationFilter interpolation_filter;

        public StdVideoAV1TxMode TxMode;

            public byte delta_q_res;

            public byte delta_lf_res;

            public _SkipModeFrame_e__FixedBuffer SkipModeFrame;

            public byte coded_denom;

            public _reserved2_e__FixedBuffer reserved2;

            public _OrderHints_e__FixedBuffer OrderHints;

            public _expectedFrameId_e__FixedBuffer expectedFrameId;

            public StdVideoAV1TileInfo* pTileInfo;

            public StdVideoAV1Quantization* pQuantization;

            public StdVideoAV1Segmentation* pSegmentation;

            public StdVideoAV1LoopFilter* pLoopFilter;

            public StdVideoAV1CDEF* pCDEF;

            public StdVideoAV1LoopRestoration* pLoopRestoration;

            public StdVideoAV1GlobalMotion* pGlobalMotion;

            public StdVideoAV1FilmGrain* pFilmGrain;

        [InlineArray(2)]
        public partial struct _SkipModeFrame_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(3)]
        public partial struct _reserved2_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8)]
        public partial struct _OrderHints_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8)]
        public partial struct _expectedFrameId_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public partial struct StdVideoDecodeAV1ReferenceInfoFlags
    {
        public uint _bitfield;

            public uint disable_frame_end_update_cdf
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint segmentation_enabled
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }
    }

    public partial struct StdVideoDecodeAV1ReferenceInfo
    {
        public StdVideoDecodeAV1ReferenceInfoFlags flags;

            public byte frame_type;

            public byte RefFrameSignBias;

            public byte OrderHint;

            public _SavedOrderHints_e__FixedBuffer SavedOrderHints;

        [InlineArray(8)]
        public partial struct _SavedOrderHints_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct StdVideoEncodeAV1DecoderModelInfo
    {
            public byte buffer_delay_length_minus_1;

            public byte buffer_removal_time_length_minus_1;

            public byte frame_presentation_time_length_minus_1;

            public byte reserved1;

            public uint num_units_in_decoding_tick;
    }

    public partial struct StdVideoEncodeAV1ExtensionHeader
    {
            public byte temporal_id;

            public byte spatial_id;
    }

    public partial struct StdVideoEncodeAV1OperatingPointInfoFlags
    {
        public uint _bitfield;

            public uint decoder_model_present_for_this_op
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint low_delay_mode_flag
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint initial_display_delay_present_for_this_op
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1FFFFFFFu << 3)) | ((value & 0x1FFFFFFFu) << 3);
            }
        }
    }

    public partial struct StdVideoEncodeAV1OperatingPointInfo
    {
        public StdVideoEncodeAV1OperatingPointInfoFlags flags;

            public ushort operating_point_idc;

            public byte seq_level_idx;

            public byte seq_tier;

            public uint decoder_buffer_delay;

            public uint encoder_buffer_delay;

            public byte initial_display_delay_minus_1;
    }

    public partial struct StdVideoEncodeAV1PictureInfoFlags
    {
        public uint _bitfield;

            public uint error_resilient_mode
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint disable_cdf_update
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint use_superres
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint render_and_frame_size_different
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint allow_screen_content_tools
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint is_filter_switchable
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint force_integer_mv
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint frame_size_override_flag
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

            public uint buffer_removal_time_present_flag
        {
            readonly get
            {
                return (_bitfield >> 8) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 8)) | ((value & 0x1u) << 8);
            }
        }

            public uint allow_intrabc
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 9)) | ((value & 0x1u) << 9);
            }
        }

            public uint frame_refs_short_signaling
        {
            readonly get
            {
                return (_bitfield >> 10) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 10)) | ((value & 0x1u) << 10);
            }
        }

            public uint allow_high_precision_mv
        {
            readonly get
            {
                return (_bitfield >> 11) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 11)) | ((value & 0x1u) << 11);
            }
        }

            public uint is_motion_mode_switchable
        {
            readonly get
            {
                return (_bitfield >> 12) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 12)) | ((value & 0x1u) << 12);
            }
        }

            public uint use_ref_frame_mvs
        {
            readonly get
            {
                return (_bitfield >> 13) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 13)) | ((value & 0x1u) << 13);
            }
        }

            public uint disable_frame_end_update_cdf
        {
            readonly get
            {
                return (_bitfield >> 14) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 14)) | ((value & 0x1u) << 14);
            }
        }

            public uint allow_warped_motion
        {
            readonly get
            {
                return (_bitfield >> 15) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 15)) | ((value & 0x1u) << 15);
            }
        }

            public uint reduced_tx_set
        {
            readonly get
            {
                return (_bitfield >> 16) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 16)) | ((value & 0x1u) << 16);
            }
        }

            public uint skip_mode_present
        {
            readonly get
            {
                return (_bitfield >> 17) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 17)) | ((value & 0x1u) << 17);
            }
        }

            public uint delta_q_present
        {
            readonly get
            {
                return (_bitfield >> 18) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 18)) | ((value & 0x1u) << 18);
            }
        }

            public uint delta_lf_present
        {
            readonly get
            {
                return (_bitfield >> 19) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 19)) | ((value & 0x1u) << 19);
            }
        }

            public uint delta_lf_multi
        {
            readonly get
            {
                return (_bitfield >> 20) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 20)) | ((value & 0x1u) << 20);
            }
        }

            public uint segmentation_enabled
        {
            readonly get
            {
                return (_bitfield >> 21) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 21)) | ((value & 0x1u) << 21);
            }
        }

            public uint segmentation_update_map
        {
            readonly get
            {
                return (_bitfield >> 22) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 22)) | ((value & 0x1u) << 22);
            }
        }

            public uint segmentation_temporal_update
        {
            readonly get
            {
                return (_bitfield >> 23) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 23)) | ((value & 0x1u) << 23);
            }
        }

            public uint segmentation_update_data
        {
            readonly get
            {
                return (_bitfield >> 24) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 24)) | ((value & 0x1u) << 24);
            }
        }

            public uint UsesLr
        {
            readonly get
            {
                return (_bitfield >> 25) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 25)) | ((value & 0x1u) << 25);
            }
        }

            public uint usesChromaLr
        {
            readonly get
            {
                return (_bitfield >> 26) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 26)) | ((value & 0x1u) << 26);
            }
        }

            public uint show_frame
        {
            readonly get
            {
                return (_bitfield >> 27) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 27)) | ((value & 0x1u) << 27);
            }
        }

            public uint showable_frame
        {
            readonly get
            {
                return (_bitfield >> 28) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 28)) | ((value & 0x1u) << 28);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 29) & 0x7u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7u << 29)) | ((value & 0x7u) << 29);
            }
        }
    }

    public unsafe partial struct StdVideoEncodeAV1PictureInfo
    {
        public StdVideoEncodeAV1PictureInfoFlags flags;

        public StdVideoAV1FrameType frame_type;

            public uint frame_presentation_time;

            public uint current_frame_id;

            public byte order_hint;

            public byte primary_ref_frame;

            public byte refresh_frame_flags;

            public byte coded_denom;

            public ushort render_width_minus_1;

            public ushort render_height_minus_1;

        public StdVideoAV1InterpolationFilter interpolation_filter;

        public StdVideoAV1TxMode TxMode;

            public byte delta_q_res;

            public byte delta_lf_res;

            public _ref_order_hint_e__FixedBuffer ref_order_hint;

            public _ref_frame_idx_e__FixedBuffer ref_frame_idx;

            public _reserved1_e__FixedBuffer reserved1;

            public _delta_frame_id_minus_1_e__FixedBuffer delta_frame_id_minus_1;

            public StdVideoAV1TileInfo* pTileInfo;

            public StdVideoAV1Quantization* pQuantization;

            public StdVideoAV1Segmentation* pSegmentation;

            public StdVideoAV1LoopFilter* pLoopFilter;

            public StdVideoAV1CDEF* pCDEF;

            public StdVideoAV1LoopRestoration* pLoopRestoration;

            public StdVideoAV1GlobalMotion* pGlobalMotion;

            public StdVideoEncodeAV1ExtensionHeader* pExtensionHeader;

            public uint* pBufferRemovalTimes;

        [InlineArray(8)]
        public partial struct _ref_order_hint_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(7)]
        public partial struct _ref_frame_idx_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(3)]
        public partial struct _reserved1_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(7)]
        public partial struct _delta_frame_id_minus_1_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public partial struct StdVideoEncodeAV1ReferenceInfoFlags
    {
        public uint _bitfield;

            public uint disable_frame_end_update_cdf
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint segmentation_enabled
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }
    }

    public unsafe partial struct StdVideoEncodeAV1ReferenceInfo
    {
        public StdVideoEncodeAV1ReferenceInfoFlags flags;

            public uint RefFrameId;

        public StdVideoAV1FrameType frame_type;

            public byte OrderHint;

            public _reserved1_e__FixedBuffer reserved1;

            public StdVideoEncodeAV1ExtensionHeader* pExtensionHeader;

        [InlineArray(3)]
        public partial struct _reserved1_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public enum StdVideoVP9Profile : uint
    {
        STD_VIDEO_VP9_PROFILE_0 = 0,
        STD_VIDEO_VP9_PROFILE_1 = 1,
        STD_VIDEO_VP9_PROFILE_2 = 2,
        STD_VIDEO_VP9_PROFILE_3 = 3,
        STD_VIDEO_VP9_PROFILE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_VP9_PROFILE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoVP9Level : uint
    {
        STD_VIDEO_VP9_LEVEL_1_0 = 0,
        STD_VIDEO_VP9_LEVEL_1_1 = 1,
        STD_VIDEO_VP9_LEVEL_2_0 = 2,
        STD_VIDEO_VP9_LEVEL_2_1 = 3,
        STD_VIDEO_VP9_LEVEL_3_0 = 4,
        STD_VIDEO_VP9_LEVEL_3_1 = 5,
        STD_VIDEO_VP9_LEVEL_4_0 = 6,
        STD_VIDEO_VP9_LEVEL_4_1 = 7,
        STD_VIDEO_VP9_LEVEL_5_0 = 8,
        STD_VIDEO_VP9_LEVEL_5_1 = 9,
        STD_VIDEO_VP9_LEVEL_5_2 = 10,
        STD_VIDEO_VP9_LEVEL_6_0 = 11,
        STD_VIDEO_VP9_LEVEL_6_1 = 12,
        STD_VIDEO_VP9_LEVEL_6_2 = 13,
        STD_VIDEO_VP9_LEVEL_INVALID = 0x7FFFFFFF,
        STD_VIDEO_VP9_LEVEL_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoVP9FrameType : uint
    {
        STD_VIDEO_VP9_FRAME_TYPE_KEY = 0,
        STD_VIDEO_VP9_FRAME_TYPE_NON_KEY = 1,
        STD_VIDEO_VP9_FRAME_TYPE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_VP9_FRAME_TYPE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoVP9ReferenceName : uint
    {
        STD_VIDEO_VP9_REFERENCE_NAME_INTRA_FRAME = 0,
        STD_VIDEO_VP9_REFERENCE_NAME_LAST_FRAME = 1,
        STD_VIDEO_VP9_REFERENCE_NAME_GOLDEN_FRAME = 2,
        STD_VIDEO_VP9_REFERENCE_NAME_ALTREF_FRAME = 3,
        STD_VIDEO_VP9_REFERENCE_NAME_INVALID = 0x7FFFFFFF,
        STD_VIDEO_VP9_REFERENCE_NAME_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoVP9InterpolationFilter : uint
    {
        STD_VIDEO_VP9_INTERPOLATION_FILTER_EIGHTTAP = 0,
        STD_VIDEO_VP9_INTERPOLATION_FILTER_EIGHTTAP_SMOOTH = 1,
        STD_VIDEO_VP9_INTERPOLATION_FILTER_EIGHTTAP_SHARP = 2,
        STD_VIDEO_VP9_INTERPOLATION_FILTER_BILINEAR = 3,
        STD_VIDEO_VP9_INTERPOLATION_FILTER_SWITCHABLE = 4,
        STD_VIDEO_VP9_INTERPOLATION_FILTER_INVALID = 0x7FFFFFFF,
        STD_VIDEO_VP9_INTERPOLATION_FILTER_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum StdVideoVP9ColorSpace : uint
    {
        STD_VIDEO_VP9_COLOR_SPACE_UNKNOWN = 0,
        STD_VIDEO_VP9_COLOR_SPACE_BT_601 = 1,
        STD_VIDEO_VP9_COLOR_SPACE_BT_709 = 2,
        STD_VIDEO_VP9_COLOR_SPACE_SMPTE_170 = 3,
        STD_VIDEO_VP9_COLOR_SPACE_SMPTE_240 = 4,
        STD_VIDEO_VP9_COLOR_SPACE_BT_2020 = 5,
        STD_VIDEO_VP9_COLOR_SPACE_RESERVED = 6,
        STD_VIDEO_VP9_COLOR_SPACE_RGB = 7,
        STD_VIDEO_VP9_COLOR_SPACE_INVALID = 0x7FFFFFFF,
        STD_VIDEO_VP9_COLOR_SPACE_MAX_ENUM = 0x7FFFFFFF,
    }

    public partial struct StdVideoVP9ColorConfigFlags
    {
        public uint _bitfield;

            public uint color_range
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x7FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7FFFFFFFu << 1)) | ((value & 0x7FFFFFFFu) << 1);
            }
        }
    }

    public partial struct StdVideoVP9ColorConfig
    {
        public StdVideoVP9ColorConfigFlags flags;

            public byte BitDepth;

            public byte subsampling_x;

            public byte subsampling_y;

            public byte reserved1;

        public StdVideoVP9ColorSpace color_space;
    }

    public partial struct StdVideoVP9LoopFilterFlags
    {
        public uint _bitfield;

            public uint loop_filter_delta_enabled
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint loop_filter_delta_update
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x3FFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3FFFFFFFu << 2)) | ((value & 0x3FFFFFFFu) << 2);
            }
        }
    }

    public partial struct StdVideoVP9LoopFilter
    {
        public StdVideoVP9LoopFilterFlags flags;

            public byte loop_filter_level;

            public byte loop_filter_sharpness;

            public byte update_ref_delta;

            public _loop_filter_ref_deltas_e__FixedBuffer loop_filter_ref_deltas;

            public byte update_mode_delta;

            public _loop_filter_mode_deltas_e__FixedBuffer loop_filter_mode_deltas;

        [InlineArray(4)]
        public partial struct _loop_filter_ref_deltas_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(2)]
        public partial struct _loop_filter_mode_deltas_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public partial struct StdVideoVP9SegmentationFlags
    {
        public uint _bitfield;

            public uint segmentation_update_map
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint segmentation_temporal_update
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint segmentation_update_data
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint segmentation_abs_or_delta_update
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 4) & 0xFFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFFFFFFu << 4)) | ((value & 0xFFFFFFFu) << 4);
            }
        }
    }

    public partial struct StdVideoVP9Segmentation
    {
        public StdVideoVP9SegmentationFlags flags;

            public _segmentation_tree_probs_e__FixedBuffer segmentation_tree_probs;

            public _segmentation_pred_prob_e__FixedBuffer segmentation_pred_prob;

            public _FeatureEnabled_e__FixedBuffer FeatureEnabled;

            public _FeatureData_e__FixedBuffer FeatureData;

        [InlineArray(7)]
        public partial struct _segmentation_tree_probs_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(3)]
        public partial struct _segmentation_pred_prob_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8)]
        public partial struct _FeatureEnabled_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8 * 4)]
        public partial struct _FeatureData_e__FixedBuffer
        {
            public short e0_0;
        }
    }

    public partial struct StdVideoDecodeVP9PictureInfoFlags
    {
        public uint _bitfield;

            public uint error_resilient_mode
        {
            readonly get
            {
                return _bitfield & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1u) | (value & 0x1u);
            }
        }

            public uint intra_only
        {
            readonly get
            {
                return (_bitfield >> 1) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 1)) | ((value & 0x1u) << 1);
            }
        }

            public uint allow_high_precision_mv
        {
            readonly get
            {
                return (_bitfield >> 2) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 2)) | ((value & 0x1u) << 2);
            }
        }

            public uint refresh_frame_context
        {
            readonly get
            {
                return (_bitfield >> 3) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 3)) | ((value & 0x1u) << 3);
            }
        }

            public uint frame_parallel_decoding_mode
        {
            readonly get
            {
                return (_bitfield >> 4) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 4)) | ((value & 0x1u) << 4);
            }
        }

            public uint segmentation_enabled
        {
            readonly get
            {
                return (_bitfield >> 5) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
            }
        }

            public uint show_frame
        {
            readonly get
            {
                return (_bitfield >> 6) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
            }
        }

            public uint UsePrevFrameMvs
        {
            readonly get
            {
                return (_bitfield >> 7) & 0x1u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
            }
        }

            public uint reserved
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
    }

    public unsafe partial struct StdVideoDecodeVP9PictureInfo
    {
        public StdVideoDecodeVP9PictureInfoFlags flags;

        public StdVideoVP9Profile profile;

        public StdVideoVP9FrameType frame_type;

            public byte frame_context_idx;

            public byte reset_frame_context;

            public byte refresh_frame_flags;

            public byte ref_frame_sign_bias_mask;

        public StdVideoVP9InterpolationFilter interpolation_filter;

            public byte base_q_idx;

            public sbyte delta_q_y_dc;

            public sbyte delta_q_uv_dc;

            public sbyte delta_q_uv_ac;

            public byte tile_cols_log2;

            public byte tile_rows_log2;

            public _reserved1_e__FixedBuffer reserved1;

            public StdVideoVP9ColorConfig* pColorConfig;

            public StdVideoVP9LoopFilter* pLoopFilter;

            public StdVideoVP9Segmentation* pSegmentation;

        [InlineArray(3)]
        public partial struct _reserved1_e__FixedBuffer
        {
            public ushort e0;
        }
    }
}
