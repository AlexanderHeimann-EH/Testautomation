// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFormat.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Defines constant strings for the Common Format.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service.Implementation.Documents
{
    /// <summary>
    /// Defines constant strings for the Common Format.
    /// </summary>
    internal class CommonFormat
    {
        #region Const

        /// <summary>
        /// The common file attribute
        /// </summary>
        public const string FisComElementName = "fisCom";

        /// <summary>
        /// The version attribute
        /// </summary>
        public const string VersionAttributeName = "ver";

        /// <summary>
        /// The version value
        /// </summary>
        public const string VersionValue = "1.0";

        /// <summary>
        /// The gateway attribute
        /// </summary>
        public const string GatewayElementName = "gtw";

        /// <summary>
        /// The model attribute
        /// </summary>
        public const string ModelAttributeName = "model";

        /// <summary>
        /// The identifier attribute
        /// </summary>
        public const string IdentifierAttributeName = "uid";

        /// <summary>
        /// The device attribute
        /// </summary>
        public const string DeviceElementName = "dev";

        /// <summary>
        /// The sensor attribute
        /// </summary>
        public const string SensorElementName = "sen";

        /// <summary>
        /// The measurement attribute
        /// </summary>
        public const string MeasurementElementName = "msm";

        /// <summary>
        /// The unit attribute
        /// </summary>
        public const string UnitAttributeName = "u";

        /// <summary>
        /// The data type attribute
        /// </summary>
        public const string DataTypeAttributeName = "d";

        /// <summary>
        /// The quality attribute
        /// </summary>
        public const string QualityAttributeName = "q";

        /// <summary>
        /// The timestamp attribute
        /// </summary>
        public const string TimestampAttributeName = "ts";

        /// <summary>
        /// The FIS first registration user
        /// </summary>
        public const string FisFirstRegistrationUser = "fis-m2m";

        /// <summary>
        /// The FIS first registration password
        /// </summary>
        public const string FisFirstRegistrationPassword = "m2m-fis";

        /// <summary>
        /// The FIS registration body
        /// </summary>
        public const string FisRegistrationBody = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><fisCom ver=\"1.0\"><gtw model=\"{0}\" uid=\"{1}\" /></fisCom>";

        /// <summary>
        /// The FIS registration URI
        /// </summary>
        public const string FisRegistrationUri = "/m2m/registration/common";

        /// <summary>
        /// The FIS data send URI
        /// </summary>
        public const string FisDataSendUri = "/m2m/data/common";

        /// <summary>
        /// The FIS registration method
        /// </summary>
        public const string FisRegistrationMethod = "POST";

        /// <summary>
        /// The FIS registration content type
        /// </summary>
        public const string FisRegistrationContentType = "application/xml";

        /// <summary>
        /// The FIS registration response model path
        /// </summary>
        public const string FisRegistrationResponseModelPath = "/fisCom/gtw/@model";

        /// <summary>
        /// The FIS registration response model serial number
        /// </summary>
        public const string FisRegistrationResponseModelUid = "/fisCom/gtw/@uid";

        /// <summary>
        /// The FIS registration response authentication user
        /// </summary>
        public const string FisRegistrationResponseAuthUser = "/fisCom/gtw/auth/user";

        /// <summary>
        /// The FIS registration response authentication password
        /// </summary>
        public const string FisRegistrationResponseAuthPassword = "/fisCom/gtw/auth/pw";

        /// <summary>
        /// The FIS registration timeout, in seconds.
        /// </summary>
        public const int FisRegistrationWebTimeout = 30;

        /// <summary>
        /// The maximum common data length. Almost everything but the values has this maximal length.
        /// </summary>
        public const int MaxCommonDataLength = 32;

        /// <summary>
        /// The maximum value data length. Only the values can reach this length.
        /// </summary>
        public const int MaxValueDataLength = 256;

        #endregion
    }
}
