//------------------------------------------------------------------------------
// <copyright file="AddRemoveProgramsPaths.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.OSSpecific
{
    /// <summary>
    ///     Provide paths for setup wizzard navigation
    /// </summary>
    public static class AddRemoveProgramsPaths
    {
        #region Declaration

        /// <summary>
        /// Help String
        /// </summary>
        private static readonly string GUIHelpString;

        /// <summary>
        ///     Application path
        /// </summary>
        public static readonly string ApplicationPath;

        /// <summary>
        ///     Provides path to listItems Installed Programs within OS Add Remove Programs Dialog
        /// </summary>
        public static string ListElement;

        /// <summary>
        ///     Provides path to text Support Information within OS Add Remove Programs Dialog
        /// </summary>
        public static string SupportInformation;

        /// <summary>
        ///     Provides path to form within OS Add Remove Programs Dialog
        /// </summary>
        public static string OpenForms;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static AddRemoveProgramsPaths()
        {
            #region Initializations

            if (SystemInformation.Is64Bit)
            {
                GUIHelpString = "/form";
                ApplicationPath = @"C:\Windows\System32\appwiz.cpl";
            }
            else
            {
                GUIHelpString = "/form";
                ApplicationPath = @"C:\Windows\System32\appwiz.cpl";
            }

            ListElement = @GUIHelpString + "/container/listitem";
            SupportInformation = @ListElement + "/text[@childindex='3']";
            OpenForms = @"/form";

            #endregion
        }
    }
}