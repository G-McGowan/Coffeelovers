﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeLovers.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CoffeeLovers.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Comment cannot be blank..
        /// </summary>
        internal static string BlankComment {
            get {
                return ResourceManager.GetString("BlankComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Comment is too long, please keep comments under 200 characters in length..
        /// </summary>
        internal static string CommentTooLong {
            get {
                return ResourceManager.GetString("CommentTooLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ConnectionString:CoffeeLoversConn.
        /// </summary>
        internal static string ConnStr {
            get {
                return ResourceManager.GetString("ConnStr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error saving coffee..
        /// </summary>
        internal static string ErrorSavingCoffeeTitle {
            get {
                return ResourceManager.GetString("ErrorSavingCoffeeTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred trying to save a new comment..
        /// </summary>
        internal static string ErrorSavingComment {
            get {
                return ResourceManager.GetString("ErrorSavingComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error ssaving comment..
        /// </summary>
        internal static string ErrorSavingCommentTitle {
            get {
                return ResourceManager.GetString("ErrorSavingCommentTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred trying to save a new coffee..
        /// </summary>
        internal static string ErrorSavingNewCoffee {
            get {
                return ResourceManager.GetString("ErrorSavingNewCoffee", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Coffee does not yet exist in the database. Index out of range..
        /// </summary>
        internal static string NoCoffeeFound {
            get {
                return ResourceManager.GetString("NoCoffeeFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find a rating in the database to update with the details supplied..
        /// </summary>
        internal static string NoRatingFoundInDB {
            get {
                return ResourceManager.GetString("NoRatingFoundInDB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rating must be between 1 &amp; 5..
        /// </summary>
        internal static string RatingOutOfRange {
            get {
                return ResourceManager.GetString("RatingOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rating update error.
        /// </summary>
        internal static string RatingUpdateError {
            get {
                return ResourceManager.GetString("RatingUpdateError", resourceCulture);
            }
        }
    }
}