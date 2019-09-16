// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base.Interfaces
// Author           : i02461501
// Created          : 04-17-2013
//
// Last Modified By : i02461501
// Last Modified On : 04-17-2013
// ***********************************************************************
// <copyright file="CommandIdLexicon.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EH.ImsOpcBridge
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Static class containing constants for command IDs.
    /// </summary>
    public static class CommandIdLexicon
    {
        #region Constants

        /// <summary>
        /// The id for "Add and Restore" command.
        /// </summary>
        public const string AddAndRestoreCommandId = @"AddAndRestore_68C17BB0-DCDB-4219-9150-7706D04067DE";

        /// <summary>
        /// The id for "Add Node" command.
        /// </summary>
        public const string AddNodeCommandId = @"AddNode_094D8A56-A997-44AC-9490-005208860469";

        /// <summary>
        /// The id for "Additional Functions" command.
        /// </summary>
        public const string AdditionalFunctionsCommandId = @"AdditionalFunctions_28934B57-B7A9-4495-A44C-9225118A431C";

        /// <summary>
        /// The id for "Cancel" command.
        /// </summary>
        public const string CancelCommandId = @"Cancel_2A0B651A-E02D-4050-99F2-977BEDFE0088";

        /// <summary>
        /// The id for "Compare" command.
        /// </summary>
        public const string CompareCommandId = @"Compare_B53C7805-6B64-432A-B32B-CE15388568FB";

        /// <summary>
        /// The id for "Download" command.
        /// </summary>
        public const string DownloadCommandId = @"Download_51D8A477-6A58-41FD-A3B1-E242A9B12F1E";

        /// <summary>
        /// The id for "DTM Functions" command.
        /// </summary>
        public const string DtmFunctionsCommandId = @"DtmFunctions_A85324C0-A7A4-4065-AA7B-E92055FD75B9";

        /// <summary>
        /// The id for the dtm functions separator.
        /// </summary>
        public const string DtmFunctionsSeparatorId = @"DtmFunctionsSeparator_3B0BFA3D-D193-4537-9C1F-709D2654ABD0";

        /// <summary>
        /// The frame functions command id.
        /// </summary>
        public const string FrameFunctionsCommandId = @"FrameFunctions_456BCAD1-BC34-4182-A8A4-113BE668428C";

        /// <summary>
        /// The id for "Open DTM" command.
        /// </summary>
        public const string OpenDtmCommandId = @"OpenDtm_707F70F9-9335-417A-ACBD-527241195960";

        /// <summary>
        /// The id for "Print" command.
        /// </summary>
        public const string PrintCommandId = @"Print_F824281F-71A4-4CBB-940A-139B1CB1D6EE";

        /// <summary>
        /// The id for "Print" sub command.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "SubCommand", Justification = @"OK here.")]
        public const string PrintSubCommandId = @"PrintSubCommand_5289C8BA-B3A9-4487-B3B5-56B69E8D0BF5";

        /// <summary>
        /// The id for "Upload Document" sub command.
        /// </summary>
        public const string UploadDocumentCommandId = @"UploadDocument_7F3AC8D0-FEC5-468C-8F34-6CB68C5C297E";

        /// <summary>
        /// The id for "Remove Node" command.
        /// </summary>
        public const string RemoveNodeCommandId = @"RemoveNode_5F576A3E-AF9C-42F7-98F5-1B0F6AC39414";

        /// <summary>
        /// The id for "Restore" command.
        /// </summary>
        public const string RestoreCommandId = @"Restore_AA6E90EA-F146-4A75-817E-E3C3D0E984BF";

        /// <summary>
        /// The id for "Restore Browse" command.
        /// </summary>
        public const string RestoreBrowseCommandId = @"RestoreBrowse_5ED677D1-3F6F-4620-B797-AA7FCA7F9B24";

        /// <summary>
        /// The id for "Save" command.
        /// </summary>
        public const string SaveCommandId = @"Save_1EB24620-A882-4459-BDFE-9A93639BB432";

        /// <summary>
        /// The id for "Scan" command.
        /// </summary>
        public const string ScanCommandId = @"Scan_826D26BC-4128-4748-9423-D240F3F73F05";

        /// <summary>
        /// The id for "Toggle Online" command.
        /// </summary>
        public const string ToggleOnlineCommandId = @"ToggleOnline_ToggleOnline_117CA86E-EBBD-46FD-B650-7869D146CE34";

        /// <summary>
        /// The id for "Upload" command.
        /// </summary>
        public const string UploadCommandId = @"Upload_4096141B-DEA7-472F-BC52-A06C391C3DF0";

        #endregion
    }
}
