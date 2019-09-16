// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceFunctionMappingList.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The device function mapping list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.DeviceFunctionMapping
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The device function mapping list.
    /// </summary>
    [Serializable]
    public class DeviceFunctionMappingList
    {
        /// <summary>
        /// Gets or sets the device function list.
        /// </summary>
        public List<DeviceFunctionMapping> DeviceFunctionList { get; set; }

        /// <summary>
        /// The device function list demo.
        /// </summary>
        /// <returns>
        /// The <see cref="DeviceFunctionMapping"/>.
        /// </returns>
        public List<DeviceFunctionMapping> DeviceFunctionListDemo()
        {
            return new List<DeviceFunctionMapping>
                       {
                           new DeviceFunctionMapping
                               {
                                   CoDIADeviceFunctionName = "CoDIATest",
                                   TestFrameworkDeviceFunctionName =
                                       "TestFrameworkTest"
                               },
                           new DeviceFunctionMapping
                               {
                                   CoDIADeviceFunctionName = "CoDIATest",
                                   TestFrameworkDeviceFunctionName =
                                       "TestFrameworkTest"
                               },
                           new DeviceFunctionMapping
                               {
                                   CoDIADeviceFunctionName = "CoDIATest",
                                   TestFrameworkDeviceFunctionName =
                                       "TestFrameworkTest"
                               },
                           new DeviceFunctionMapping
                               {
                                   CoDIADeviceFunctionName = "CoDIATest",
                                   TestFrameworkDeviceFunctionName =
                                       "TestFrameworkTest"
                               },
                           new DeviceFunctionMapping
                               {
                                   CoDIADeviceFunctionName = "CoDIATest",
                                   TestFrameworkDeviceFunctionName =
                                       "TestFrameworkTest"
                               },
                           new DeviceFunctionMapping
                               {
                                   CoDIADeviceFunctionName = "CoDIATest",
                                   TestFrameworkDeviceFunctionName =
                                       "TestFrameworkTest"
                               }
                       };
        }
    }
}
