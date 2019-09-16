// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceFunctionMappingHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The device function mapping helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.DeviceFunctionMapping    
{
    using System;
    using System.IO;

    using EH.DTMstudioTest.Common.Utilities.Serialization;

    /// <summary>
    /// The device function mapping helper.
    /// </summary>
    public class DeviceFunctionMappingHelper
    {
        /// <summary>
        /// The deserialize device function mapping list.
        /// </summary>
        /// <param name="deviceFunctionMappingListFile">
        /// The device Function Mapping List File.
        /// </param>
        /// <returns>
        /// The <see cref="DeviceFunctionMappingList"/>.
        /// </returns>
        public static DeviceFunctionMappingList DeSerializeDeviceFunctionMappingList(string deviceFunctionMappingListFile)
        {
            var result = new DeviceFunctionMappingList();

            if (File.Exists(deviceFunctionMappingListFile))
            {
                Exception exception;

                result = (DeviceFunctionMappingList)XmlSerialization.XmlDeserializeObject(Path.Combine(deviceFunctionMappingListFile, deviceFunctionMappingListFile), typeof(DeviceFunctionMappingList), out exception, false);

                if (exception != null)
                {
                    throw exception;
                }
            }

            return result;
        }

        /// <summary>
        /// The de serialize device function mapping list.
        /// </summary>
        /// <param name="deviceFunctionMappingList">
        /// The device function mapping list.
        /// </param>
        /// <param name="deviceFunctionMappingListFile">
        /// The device Function Mapping List File.
        /// </param>
        public static void SerializeDeviceFunctionMappingList(DeviceFunctionMappingList deviceFunctionMappingList, string deviceFunctionMappingListFile) 
        {
            XmlSerialization.XmlSerializeObject(deviceFunctionMappingListFile, deviceFunctionMappingList);
        }
    }
}
