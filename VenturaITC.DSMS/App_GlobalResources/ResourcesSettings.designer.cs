//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ResourcesSettings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourcesSettings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.ResourcesSettings", global::System.Reflection.Assembly.Load("App_GlobalResources"));
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
        ///   Looks up a localized string similar to SIGEC.
        /// </summary>
        internal static string AppAbbreviation {
            get {
                return ResourceManager.GetString("AppAbbreviation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sistema de Gestão de Escola de Condução.
        /// </summary>
        internal static string AppTitle {
            get {
                return ResourceManager.GetString("AppTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Escola de Condução Malengane.
        /// </summary>
        internal static string Company {
            get {
                return ResourceManager.GetString("Company", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pagamentos.
        /// </summary>
        internal static string ModulePayments {
            get {
                return ResourceManager.GetString("ModulePayments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Módulo de gestão de pagamentos.
        ///                    A modalidade de pagamento pode ser total ou em prestações..
        /// </summary>
        internal static string ModulePaymentsDesc {
            get {
                return ResourceManager.GetString("ModulePaymentsDesc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Inscrições.
        /// </summary>
        internal static string ModuleRegistration {
            get {
                return ResourceManager.GetString("ModuleRegistration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Módulo de inscrições e gestão de alunos, quer internos assim como externos..
        /// </summary>
        internal static string ModuleRegistrationDesc {
            get {
                return ResourceManager.GetString("ModuleRegistrationDesc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Testes.
        /// </summary>
        internal static string ModuleTests {
            get {
                return ResourceManager.GetString("ModuleTests", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Módulo de carregamento de exercícios, realização e gestão de testes..
        /// </summary>
        internal static string ModuleTestsDesc {
            get {
                return ResourceManager.GetString("ModuleTestsDesc", resourceCulture);
            }
        }
    }
}
