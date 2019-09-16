//------------------------------------------------------------------------------
// <copyright file="AddDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 05.11.2010
 * Time: 07:45 
 * Last: 10.03.2011
 * Reason: Code documentation
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common
{
    using System;

    using Ranorex;

    /// <summary>
    ///     This class contains default values for:
    ///     - Timeout
    ///     - Location within an control
    ///     - Duration for mouse-movememt
    /// </summary>
    public class DefaultValues
    {
        /// <summary>
        ///     Retries
        /// </summary>
        public const int SearchRetries = 5;

        /// <summary>
        ///     General timeout
        /// </summary>
        public const int GeneralTimeout = 300000;

        /// <summary>
        ///     DTM Setup timeout
        /// </summary>
        public const int DTMUploadTimeout = 600000;

        /// <summary>
        ///     DTM Upload Time Out
        /// </summary>
        public const int DTMDownloadTimeout = 600000;

        /// <summary>
        ///     DTM Setup timeout
        /// </summary>
        public const int DTMSetupTimeout = 600000;

        /// <summary>
        ///     Short default timeout to wait for access on controls. Time is in milliseconds.
        /// </summary>
        public const int iTimeoutShort = 5000;

        /// <summary>
        ///     Medium default timeout to wait for access on controls. Time is in milliseconds.
        /// </summary>
        public const int iTimeoutMedium = 10000;

        /// <summary>
        ///     Long default timeout to wait for access on controls. Time is in milliseconds.
        /// </summary>
        public const int iTimeoutLong = 20000;

        /// <summary>
        ///     Long default timeout to wait for access on controls. Time is in milliseconds.
        /// </summary>
        public const int iTimeoutDefault = 30000;

        /// <summary>
        ///     Long default timeout to wait for modules that are opened. Time is in milliseconds.
        /// </summary>
        public const int iTimeoutModules = 120000;

        /// <summary>
        ///     DTM Setup timeout
        /// </summary>
        public const int TimeoutPrintUpDownload = 900000;

        /// <summary>
        ///     Time (in seconds) to wait, before an exceptions continues.
        /// </summary>
        public const int iTimeToWait = 60;

        /// <summary>
        ///     Default position for mouse pointer on a control. Position is in pixel from left upper corner.
        /// </summary>
        public static Location locDefaultLocation = new Location(5, 5);

        /// <summary>
        ///     Default position for mouse pointer on a control. Position is in pixel from left upper corner.
        /// </summary>
        public static Location locUpperLeft = new Location(1, 1);

        /// <summary>
        ///     Short default duration for mouse moving time. Time is in milliseconds.
        /// </summary>
        public static Duration durDurationShort = new Duration(100);

        /// <summary>
        ///     Medium default duration for mouse moving time. Time is in milliseconds.
        /// </summary>
        public static Duration durDurationMedium = new Duration(500);

        /// <summary>
        ///     Long default duration for mouse moving time. Time is in milliseconds.
        /// </summary>
        public static Duration durDurationLong = new Duration(1000);

        /// <summary>
        ///     FieldCare default installation path
        /// </summary>
        //public static string strApplicationPath = @"C:\Program Files\Endress+Hauser\FieldCare\Frame\FMPFrame.exe";
        public static string strApplicationPath = Environment.GetEnvironmentVariable("ProgramFiles") +
                                                  @"\Endress+Hauser\FieldCare\Frame\FMPFrame.exe";

        /// <summary>
        ///     Application path for FieldCare on 64bit OS = @"C:\Program Files (x86)\Endress+Hauser\FieldCare\Frame\FMPFrame.exe";
        /// </summary>
        public static string strApplicationPath64Bit =
            Environment.GetEnvironmentVariable(@"Program Files (x86)") +
            @"\Endress+Hauser\FieldCare\Frame\FMPFrame.exe";
    }
}