﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Main.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Main.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wick,John
        ///Springtein,Bruce
        ///Adams,Bryan
        ///.
        /// </summary>
        internal static string TeamCSVTest {
            get {
                return ResourceManager.GetString("TeamCSVTest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;Leagues&gt;
        ///    &lt;LeagueName1&gt;lk&lt;/LeagueName1&gt;
        ///    &lt;NumberToMakePlayoffs1&gt;5&lt;/NumberToMakePlayoffs1&gt;
        ///    &lt;Teams&gt;
        ///        &lt;Team1&gt;q1&lt;/Team1&gt;
        ///        &lt;Players&gt;
        ///            &lt;Team2Player1&gt;wick,john&lt;/Team2Player1&gt;
        ///            &lt;Team2Player2&gt;we,re&lt;/Team2Player2&gt;
        ///        &lt;/Players&gt;
        ///        &lt;Team2&gt;t78&lt;/Team2&gt;
        ///    &lt;/Teams&gt;
        ///    &lt;LeagueName2&gt;ut&lt;/LeagueName2&gt;
        ///    &lt;NumberToMakePlayoffs2&gt;5&lt;/NumberToMakePlayoffs2&gt;
        ///    &lt;Teams&gt;
        ///        &lt;Team1&gt;t1&lt;/Team1&gt;
        ///        &lt;Players&gt;
        ///    [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string test {
            get {
                return ResourceManager.GetString("test", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] TimeCard {
            get {
                object obj = ResourceManager.GetObject("TimeCard", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}
