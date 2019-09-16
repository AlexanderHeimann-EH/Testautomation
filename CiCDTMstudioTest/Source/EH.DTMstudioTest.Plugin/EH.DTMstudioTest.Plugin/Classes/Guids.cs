// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="Guids.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The guid list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System;

    /// <summary>
    /// The guid list.
    /// </summary>
    internal static class GuidList
    {
        #region Constants

        /// <summary>
        /// The guid dt mstudio test cmd set string.
        /// </summary>
        public const string guidDTMstudioTestCmdPackageSetString = "554d0b03-6af8-4359-ab62-7a92981f93ba";

        /// <summary>
        /// The guid dt mstudio test editor factory string.
        /// </summary>
        public const string guidDTMstudioTestEditorFactoryString = "05a6653e-73f2-431a-8f2f-2d8d37241585";

        /// <summary>
        /// The guid dt mstudio test pkg string.
        /// </summary>
        public const string guidDTMstudioTestPkgString = "69ed8e48-6154-4e34-b061-86290d427a55";

        /// <summary>
        /// The guid dt test project factory string.
        /// </summary>
        public const string guidDTTestProjectFactoryString = "80B2028F-E2C7-48E7-98ED-BCFC4B094216";

        /// <summary>
        /// The guid properties page dt project string.
        /// </summary>
        public const string guidPropertiesPageDTProjectString = "BE6A35EF-4D15-4F5A-898A-60FDF687EBDF";

        /// <summary>
        /// The guid properties page report string.
        /// </summary>
        public const string guidPropertiesPageReportString = "8944A093-E727-4F45-A1B5-E89649034355";

        /// <summary>
        /// The guid properties page infrastructure string.
        /// </summary>
        public const string guidPropertiesPageInfrastructureString = "86E3F49E-8AF3-43AE-9F03-35DEC834C2A0";

        /// <summary>
        /// The guid properties page infrastructure string.
        /// </summary>
        public const string GuidPropertiesPageTestEnvironmentString = "2E7A474E-4B20-4E9F-8894-7913B8345FC0";

        /// <summary>
        /// The guid tool window persistance string.
        /// </summary>
        public const string guidToolWindowPersistanceString = "8abfb1c2-bdee-4fec-b6fb-86b84303b398";

        #endregion

        #region Static Fields

        /// <summary>
        /// The guid output export window pane.
        /// </summary>
        public static readonly Guid GuidOutputExportWindowPane = new Guid("1A8AC148-81FB-4e54-BF7D-0AB655DB9A6F");

        /// <summary>
        /// The guid output window pane.
        /// </summary>
        public static readonly Guid GuidOutputWindowPane = new Guid("5E5677C0-CA8C-4E13-93AF-7D136B52F624");

        /// <summary>
        /// The guid dt mstudio test cmd set.
        /// </summary>
        public static readonly Guid guidDTMstudioTestCmdSet = new Guid(guidDTMstudioTestCmdPackageSetString);

        /// <summary>
        /// The guid dt mstudio test editor factory.
        /// </summary>
        public static readonly Guid guidDTMstudioTestEditorFactory = new Guid(guidDTMstudioTestEditorFactoryString);

        /// <summary>
        /// The guid dt test project factory.
        /// </summary>
        public static readonly Guid guidDTTestProjectFactory = new Guid(guidDTTestProjectFactoryString);

        #endregion
    };
}