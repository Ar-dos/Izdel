﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Izdel.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Izdel.Properties.Resources", typeof(Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WITH MainQuery As 
        ///(
        ///SELECT Id, Name, Price, IzdelUp, 
        ///CASE  
        ///  WHEN IzdelUp IS NULL THEN 1 
        ///  ELSE kol 
        ///END as kol, ROW_NUMBER() OVER(PARTITION BY IzdelUp ORDER BY Id) as n,
        ///Sum(Price) OVER(PARTITION BY IzdelUp ORDER BY Id) as t
        ///FROM Izdel LEFT JOIN Links ON Links.Izdel = Izdel.Id
        ///),
        ///RecursiveQuery AS
        ///(
        /// SELECT Id, Name, Price, kol, 1 as lvl, IzdelUp,
        /// CAST(0x AS VARBINARY(MAX)) + CAST(n AS BINARY(2)) AS sortpath
        /// FROM MainQuery
        /// WHERE IzdelUp IS NULL
        ///
        /// UNION ALL
        ///
        /// SELECT m.Id, m.Name, m [rest of string was truncated]&quot;;.
        /// </summary>
        public static string SQLQuery {
            get {
                return ResourceManager.GetString("SQLQuery", resourceCulture);
            }
        }
    }
}