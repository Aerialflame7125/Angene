using System.Runtime.InteropServices;

namespace Angene.Linux.Wayland
{
    public class xkbcommon
    {
        public enum xkb_rmlvo_builder_flags : uint
        {
            XKB_RMLVO_BUILDER_NO_FLAGS = 0,
        }

        public unsafe partial struct xkb_rule_names
        {
            public sbyte* rules;

            public sbyte* model;

            public sbyte* layout;

            public sbyte* variant;

            public sbyte* options;
        }

        public unsafe partial struct xkb_component_names
        {
            public sbyte* keycodes;

            public sbyte* compatibility;

            public sbyte* geometry;

            public sbyte* symbols;

            public sbyte* types;
        }

        public enum xkb_keysym_flags : uint
        {
            XKB_KEYSYM_NO_FLAGS = 0,
            XKB_KEYSYM_CASE_INSENSITIVE = (1 << 0),
        }

        public enum xkb_context_flags : uint
        {
            XKB_CONTEXT_NO_FLAGS = 0,
            XKB_CONTEXT_NO_DEFAULT_INCLUDES = (1 << 0),
            XKB_CONTEXT_NO_ENVIRONMENT_NAMES = (1 << 1),
            XKB_CONTEXT_NO_SECURE_GETENV = (1 << 2),
        }

        public enum xkb_log_level : uint
        {
            XKB_LOG_LEVEL_CRITICAL = 10,
            XKB_LOG_LEVEL_ERROR = 20,
            XKB_LOG_LEVEL_WARNING = 30,
            XKB_LOG_LEVEL_INFO = 40,
            XKB_LOG_LEVEL_DEBUG = 50,
        }

        public enum xkb_keymap_compile_flags : uint
        {
            XKB_KEYMAP_COMPILE_NO_FLAGS = 0,
        }

        public enum xkb_keymap_format : uint
        {
            XKB_KEYMAP_FORMAT_TEXT_V1 = 1,
            XKB_KEYMAP_FORMAT_TEXT_V2 = 2,
        }

        public enum xkb_keymap_serialize_flags : uint
        {
            XKB_KEYMAP_SERIALIZE_NO_FLAGS = 0,
            XKB_KEYMAP_SERIALIZE_PRETTY = (1 << 0),
            XKB_KEYMAP_SERIALIZE_KEEP_UNUSED = (1 << 1),
        }

        public enum xkb_key_direction : uint
        {
            XKB_KEY_UP,
            XKB_KEY_DOWN,
        }

        public enum xkb_state_component : uint
        {
            XKB_STATE_MODS_DEPRESSED = (1 << 0),
            XKB_STATE_MODS_LATCHED = (1 << 1),
            XKB_STATE_MODS_LOCKED = (1 << 2),
            XKB_STATE_MODS_EFFECTIVE = (1 << 3),
            XKB_STATE_LAYOUT_DEPRESSED = (1 << 4),
            XKB_STATE_LAYOUT_LATCHED = (1 << 5),
            XKB_STATE_LAYOUT_LOCKED = (1 << 6),
            XKB_STATE_LAYOUT_EFFECTIVE = (1 << 7),
            XKB_STATE_LEDS = (1 << 8),
        }

        public enum xkb_state_match : uint
        {
            XKB_STATE_MATCH_ANY = (1 << 0),
            XKB_STATE_MATCH_ALL = (1 << 1),
            XKB_STATE_MATCH_NON_EXCLUSIVE = (1 << 16),
        }

        public enum xkb_consumed_mode : uint
        {
            XKB_CONSUMED_MODE_XKB,
            XKB_CONSUMED_MODE_GTK,
        }

        public static unsafe partial class Methods
        {
            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_rmlvo_builder_new(IntPtr context, sbyte* rules, sbyte* model, xkb_rmlvo_builder_flags flags);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern byte xkb_rmlvo_builder_append_layout(IntPtr rmlvo, sbyte* layout, sbyte* variant, sbyte** options, nuint options_len);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern byte xkb_rmlvo_builder_append_option(IntPtr rmlvo, sbyte* option);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_rmlvo_builder_ref(IntPtr rmlvo);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void xkb_rmlvo_builder_unref(IntPtr rmlvo);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern byte xkb_components_names_from_rules(IntPtr context, xkb_rule_names* rmlvo_in, xkb_rule_names* rmlvo_out, xkb_component_names* components_out);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_keysym_get_name(uint keysym, sbyte* buffer, nuint size);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keysym_from_name(sbyte* name, xkb_keysym_flags flags);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_keysym_to_utf8(uint keysym, sbyte* buffer, nuint size);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keysym_to_utf32(uint keysym);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_utf32_to_keysym(uint ucs);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keysym_to_upper(uint ks);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keysym_to_lower(uint ks);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_context_new(xkb_context_flags flags);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_context_ref(IntPtr context);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void xkb_context_unref(IntPtr context);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void xkb_context_set_user_data(IntPtr context, void* user_data);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void* xkb_context_get_user_data(IntPtr context);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_context_include_path_append(IntPtr context, sbyte* path);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_context_include_path_append_default(IntPtr context);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_context_include_path_reset_defaults(IntPtr context);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void xkb_context_include_path_clear(IntPtr context);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_context_num_include_paths(IntPtr context);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* xkb_context_include_path_get(IntPtr context, uint index);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void xkb_context_set_log_level(IntPtr context, xkb_log_level level);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern xkb_log_level xkb_context_get_log_level(IntPtr context);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void xkb_context_set_log_verbosity(IntPtr context, int verbosity);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_context_get_log_verbosity(IntPtr context);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void xkb_context_set_log_fn(IntPtr context, delegate* unmanaged[Cdecl]<IntPtr, xkb_log_level, sbyte*, IntPtr, void> log_fn);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_keymap_new_from_rmlvo(IntPtr rmlvo, xkb_keymap_format format, xkb_keymap_compile_flags flags);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_keymap_new_from_names(IntPtr context, xkb_rule_names* names, xkb_keymap_compile_flags flags);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_keymap_new_from_names2(IntPtr context, xkb_rule_names* names, xkb_keymap_format format, xkb_keymap_compile_flags flags);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_keymap_new_from_file(IntPtr context, IntPtr file, xkb_keymap_format format, xkb_keymap_compile_flags flags);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_keymap_new_from_string(IntPtr context, sbyte* @string, xkb_keymap_format format, xkb_keymap_compile_flags flags);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_keymap_new_from_buffer(IntPtr context, sbyte* buffer, nuint length, xkb_keymap_format format, xkb_keymap_compile_flags flags);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_keymap_ref(IntPtr keymap);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void xkb_keymap_unref(IntPtr keymap);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* xkb_keymap_get_as_string(IntPtr keymap, xkb_keymap_format format);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* xkb_keymap_get_as_string2(IntPtr keymap, xkb_keymap_format format, xkb_keymap_serialize_flags flags);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_min_keycode(IntPtr keymap);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_max_keycode(IntPtr keymap);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void xkb_keymap_key_for_each(IntPtr keymap, delegate* unmanaged[Cdecl]<IntPtr, uint, void*, void> iter, void* data);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* xkb_keymap_key_get_name(IntPtr keymap, uint key);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_key_by_name(IntPtr keymap, sbyte* name);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_num_mods(IntPtr keymap);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* xkb_keymap_mod_get_name(IntPtr keymap, uint idx);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_mod_get_index(IntPtr keymap, sbyte* name);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_mod_get_mask(IntPtr keymap, sbyte* name);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_mod_get_mask2(IntPtr keymap, uint idx);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_num_layouts(IntPtr keymap);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* xkb_keymap_layout_get_name(IntPtr keymap, uint idx);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_layout_get_index(IntPtr keymap, sbyte* name);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_num_leds(IntPtr keymap);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* xkb_keymap_led_get_name(IntPtr keymap, uint idx);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_led_get_index(IntPtr keymap, sbyte* name);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_num_layouts_for_key(IntPtr keymap, uint key);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_keymap_num_levels_for_key(IntPtr keymap, uint key, uint layout);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint xkb_keymap_key_get_mods_for_level(IntPtr keymap, uint key, uint layout, uint level, uint* masks_out, nuint masks_size);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_keymap_key_get_syms_by_level(IntPtr keymap, uint key, uint layout, uint level, uint** syms_out);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_keymap_key_repeats(IntPtr keymap, uint key);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_state_new(IntPtr keymap);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_state_ref(IntPtr state);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void xkb_state_unref(IntPtr state);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr xkb_state_get_keymap(IntPtr state);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern xkb_state_component xkb_state_update_key(IntPtr state, uint key, xkb_key_direction direction);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern xkb_state_component xkb_state_update_latched_locked(IntPtr state, uint affect_latched_mods, uint latched_mods, byte affect_latched_layout, int latched_layout, uint affect_locked_mods, uint locked_mods, byte affect_locked_layout, int locked_layout);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern xkb_state_component xkb_state_update_mask(IntPtr state, uint depressed_mods, uint latched_mods, uint locked_mods, uint depressed_layout, uint latched_layout, uint locked_layout);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_key_get_syms(IntPtr state, uint key, uint** syms_out);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_key_get_utf8(IntPtr state, uint key, sbyte* buffer, nuint size);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_state_key_get_utf32(IntPtr state, uint key);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_state_key_get_one_sym(IntPtr state, uint key);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_state_key_get_layout(IntPtr state, uint key);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_state_key_get_level(IntPtr state, uint key, uint layout);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_state_serialize_mods(IntPtr state, xkb_state_component components);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_state_serialize_layout(IntPtr state, xkb_state_component components);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_mod_name_is_active(IntPtr state, sbyte* name, xkb_state_component type);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_mod_names_are_active(IntPtr state, xkb_state_component type, xkb_state_match match, __arglist);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_mod_index_is_active(IntPtr state, uint idx, xkb_state_component type);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_mod_indices_are_active(IntPtr state, xkb_state_component type, xkb_state_match match, __arglist);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_state_key_get_consumed_mods2(IntPtr state, uint key, xkb_consumed_mode mode);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_state_key_get_consumed_mods(IntPtr state, uint key);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_mod_index_is_consumed2(IntPtr state, uint key, uint idx, xkb_consumed_mode mode);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_mod_index_is_consumed(IntPtr state, uint key, uint idx);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint xkb_state_mod_mask_remove_consumed(IntPtr state, uint key, uint mask);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_layout_name_is_active(IntPtr state, sbyte* name, xkb_state_component type);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_layout_index_is_active(IntPtr state, uint idx, xkb_state_component type);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_led_name_is_active(IntPtr state, sbyte* name);

            [DllImport("libxkbcommon", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int xkb_state_led_index_is_active(IntPtr state, uint idx);
        }
    }
}
