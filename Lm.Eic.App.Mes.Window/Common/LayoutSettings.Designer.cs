﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lm.Eic.App.Mes.Window.Common
{


    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class LayoutSettings : global::System.Configuration.ApplicationSettingsBase
    {

        private static LayoutSettings defaultInstance = ((LayoutSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new LayoutSettings())));

        public static LayoutSettings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LogicalLayout
        {
            get
            {
                return ((string)(this["LogicalLayout"]));
            }
            set
            {
                this["LogicalLayout"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ViewsLayout
        {
            get
            {
                return ((string)(this["ViewsLayout"]));
            }
            set
            {
                this["ViewsLayout"] = value;
            }
        }
    }
}
