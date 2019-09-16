// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultCodes.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implemets the result codes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Common.Data
{
    /// <summary>
    /// Class ResultCodes
    /// </summary>
    public class ResultCodes
    {
        #region Constants

        /// <summary>
        /// The success
        /// </summary>
        public const uint Success = 0;

        /// <summary>
        /// The missing argument
        /// </summary>
        public const uint MissingArgument = 1;

        /// <summary>
        /// The create app data folder error
        /// </summary>
        public const uint CreateAppDataFolderError = 2;

        /// <summary>
        /// The serialize error
        /// </summary>
        public const uint SerializeError = 3;

        /// <summary>
        /// The deserialize error
        /// </summary>
        public const uint DeserializeError = 4;

        /// <summary>
        /// The export denied
        /// </summary>
        public const uint ExportDenied = 5;

        /// <summary>
        /// The cannot connect opc server
        /// </summary>
        public const uint CannotConnectOpcServer = 6;

        /// <summary>
        /// The monitor already running
        /// </summary>
        public const uint MonitorAlreadyRunning = 7;

        /// <summary>
        /// The monitor not running
        /// </summary>
        public const uint MonitorNotRunning = 8;

        /// <summary>
        /// The cannot browse opc servers
        /// </summary>
        public const uint CannotBrowseOpcServers = 9;

        /// <summary>
        /// The browse address space error
        /// </summary>
        public const uint BrowseAddressSpaceError = 10;

        /// <summary>
        /// The cannot register FIS
        /// </summary>
        public const uint CannotRegisterFis = 11;

        /// <summary>
        /// The invalid gateway
        /// </summary>
        public const uint InvalidGateway = 12;

        #endregion
    }
}