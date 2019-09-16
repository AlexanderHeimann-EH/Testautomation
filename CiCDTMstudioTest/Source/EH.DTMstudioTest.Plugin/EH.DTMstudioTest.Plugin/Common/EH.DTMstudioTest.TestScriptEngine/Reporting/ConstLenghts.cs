// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstLenghts.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.TestScriptEngine.Reporting
{
    /// <summary>
    /// The const lenghts.
    /// </summary>
    public class ConstLenghts
    {
        /// <summary>
        /// The max path length by operating system.
        /// </summary>
        public const int MaxPathLengthByOperatingSystem = 256;

        /// <summary>
        /// The ranorex temporary postfix data.
        /// </summary>
        public const int RanorexTemporaryPostfixData = 5;

        /// <summary>
        /// The max path length for temparary postfix.
        /// </summary>
        public const int MaxPathLengthForTempararyPostfix = MaxPathLengthByOperatingSystem - RanorexTemporaryPostfixData;

        /// <summary>
        /// The ranorex postfix rxlog.
        /// </summary>
        public const int RanorexPostfixRxlog = 6;

        /// <summary>
        /// The timestamp.
        /// </summary>
        public const int Timestamp = 18;

        /// <summary>
        /// The max file length by ranorex.
        /// </summary>
        public const int MaxFileLengthByRanorex = 92;
    }
}
