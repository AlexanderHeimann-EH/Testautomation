// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelaysAccessMethodsDeditec.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2013
// </copyright>
// <summary>
//   The enumerations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Simon Schwab
 * User: Simon Schwab
 * Date: 06.02.2015
 * Version: 1.0
 * 
 */

namespace EH.PCPS.TestAutomation.Common.Relay
{
    using System;
    using System.Globalization;

    using Ranorex;

    /// <summary>
    /// Contains methods to interact with a Deditec Ethernet Relay Card
    /// </summary>
    public static class RelayAccessMethodsDeditec
    {
        #region Public Methods and Operators

        /// <summary>
        /// Reads all channel values of a Relay card
        /// </summary>
        /// <param name="cardAddress">
        /// The address of the card
        /// </param>
        /// <param name="allNotSet">
        /// True if all Relay channels have the value 0
        /// </param>
        /// <returns>
        /// An int array containing all channel values. Index corresponds to the channel number
        /// </returns>
        public static int[] ReadAll(uint cardAddress, out bool allNotSet)
        {
            allNotSet = false;

            // open card and get card handle
            uint cardHandle = GetCardHandle(cardAddress);

            // readback all and store in array
            ulong channelValues = ReadbackAll(cardHandle);
            char[] binaryArray = SplitBinaryString(ToBinary(channelValues));

            // array size depends on how many Digital Output channels the card has
            uint cardDigitalOutputSize = GetCardDigitalOutputSize(cardHandle);

            int valueArraySize = SetArraySize(cardDigitalOutputSize, binaryArray.Length);
            int[] valueArray = new int[valueArraySize];

            int arrayIndex = binaryArray.Length - 1;

            // case: every channel has value 0
            string caseZeroString = ToBinary(channelValues);
            if (string.IsNullOrEmpty(caseZeroString))
            {
                allNotSet = true;
            }

            foreach (char single in binaryArray)
            {
                int singleInt = int.Parse(single.ToString(CultureInfo.InvariantCulture));
                valueArray.SetValue(singleInt, arrayIndex);
                arrayIndex = arrayIndex - 1;
            }

            // close module and return value array
            CloseModule(cardHandle);
            return valueArray;
        }

        /// <summary>
        /// Reads multiple Relay channels
        /// </summary>
        /// <param name="cardAddress">
        /// The address of the card
        /// </param>
        /// <param name="relay">
        /// The relay.
        /// </param>
        /// <param name="allNotSet">
        /// True if all Relay channels have value 0
        /// </param>
        /// <returns>
        /// An int array containing the channel values. Input and output arrays have the same index for the same channel
        /// </returns>
        public static int[] ReadMultiple(uint cardAddress, uint[] relay, out bool allNotSet)
        {
            allNotSet = false;

            // open card an get handle
            uint cardHandle = GetCardHandle(cardAddress);

            // readback all values and store them in a char array
            ulong channelValues = ReadbackAll(cardHandle);
            char[] binaryArray = SplitBinaryString(ToBinary(channelValues));
            int[] valueArray = new int[binaryArray.Length];

            int arrayIndex = binaryArray.Length - 1;

            // case: every channel has value 0
            string caseZeroString = ToBinary(channelValues);
            if (string.IsNullOrEmpty(caseZeroString))
            {
                allNotSet = true;
            }

            // iterate through Relay array and report all states
            foreach (uint singleRelay in relay)
            {
                foreach (char single in binaryArray)
                {
                    int singleInt = int.Parse(single.ToString(CultureInfo.InvariantCulture));
                    if (arrayIndex == (int)singleRelay)
                    {
                        Report.Info(string.Format("Relay channel {0} has the value {1}", arrayIndex, singleInt));
                        valueArray.SetValue(singleInt, arrayIndex);
                    }

                    arrayIndex = arrayIndex - 1;
                }

                arrayIndex = binaryArray.Length - 1;
            }

            // close module
            CloseModule(cardHandle);
            return valueArray;
        }

        /// <summary>
        /// Reads a single Relay channel value
        /// </summary>
        /// <param name="cardAddress">
        /// The address of the card
        /// </param>
        /// <param name="relay">
        /// The Relay to read
        /// </param>
        /// <param name="allNotSet">
        /// True if all Relay channels have the value 0
        /// </param>
        /// <returns>
        /// 0 or 1 if channel has a value, -1 if error occured
        /// </returns>
        public static int ReadSingle(uint cardAddress, uint relay, out bool allNotSet)
        {
            allNotSet = false;

            // open card and get handle
            uint cardHandle = GetCardHandle(cardAddress);

            // readback all values and store them in a char array
            ulong channelValues = ReadbackAll(cardHandle);
            char[] binaryArray = SplitBinaryString(ToBinary(channelValues));

            int arrayIndex = binaryArray.Length - 1;

            // case: every channel has value 0
            string caseZeroString = ToBinary(channelValues);
            if (string.IsNullOrEmpty(caseZeroString))
            {
                allNotSet = true;
            }

            // case: Relay to read is the 0 Relay
            if (relay == 0)
            {
                return int.Parse(binaryArray[0].ToString(CultureInfo.InvariantCulture));
            }

            // case: highest channel set is lower than the desired Relay
            if (relay > binaryArray.Length - 1)
            {
                return 0;
            }

            foreach (char single in binaryArray)
            {
                int singleInt = int.Parse(single.ToString(CultureInfo.InvariantCulture));
                if (arrayIndex == relay)
                {
                    Report.Info(string.Format("Relay channel {0} has the value {1}", arrayIndex, singleInt));
                    CloseModule(cardHandle);
                    return singleInt;
                }

                arrayIndex = arrayIndex - 1;
            }

            CloseModule(cardHandle);
            return -1;
        }

        /// <summary>
        /// Sets all Relay of a card to a specified state
        /// </summary>
        /// <param name="cardAddress">
        /// The address of the card
        /// </param>
        /// <param name="bitValue">
        /// The value to set (0 or 1)
        /// </param>
        /// <param name="result">
        /// Used for reporting: true if the action was successful (setting all Relay)
        /// </param>
        public static void SetAll(uint cardAddress, uint bitValue, out bool result)
        {
            // open card and get card handle
            uint cardHandle = GetCardHandle(cardAddress);

            // check for card size
            uint cardDigitalOutputSize = GetCardDigitalOutputSize(cardHandle);

            // choose DO set method according to DO size
            switch ((int)cardDigitalOutputSize)
            {
                case 8:
                    DigitalOutputSet8(cardHandle, bitValue);
                    break;
                case 16:
                    DigitalOutputSet16(cardHandle, bitValue);
                    break;
                case 32:
                    DigitalOutputSet32(cardHandle, bitValue);
                    break;
                case 64:
                    DOSet64(cardHandle, bitValue);
                    break;
            }

            // validate if channels are set
            if (ValidateRelayState(cardHandle, bitValue))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            CloseModule(cardHandle);
        }

        /// <summary>
        /// Sets multiple Relay to a specific value and validates them
        /// </summary>
        /// <param name="cardAddress">
        /// The address of the Relay card
        /// </param>
        /// <param name="bitValue">
        /// The value to set (0 or 1)
        /// </param>
        /// <param name="relay">
        /// A uint array containing all Relay to set
        /// </param>
        /// <param name="result">
        /// Used for reporting: true if the action was successful (setting multiple Relay)
        /// </param>
        public static void SetMultiple(uint cardAddress, uint bitValue, uint[] relay, out bool result)
        {
            result = false;
            bool finalResult = false;
            uint handle = GetCardHandle(cardAddress);

            // check amount DO channels
            uint digitalOutputSize = GetCardDigitalOutputSize(handle);
            try
            {
                foreach (uint single in relay)
                {
                    if (single > digitalOutputSize)
                    {
                        Report.Info("Input Relay channel value to set was greater than the actual amount of channels of the card. \r\n Method will abort");
                        throw new RanorexException();
                    }
                }

                foreach (uint singleRelay in relay)
                {
                    bool resultSet = SetValueToRelay(handle, singleRelay, bitValue);
                    if (resultSet)
                    {
                        if (finalResult)
                        {
                        }
                        else
                        {
                            finalResult = true;
                        }
                    }
                    else
                    {
                        if (finalResult == false)
                        {
                        }
                        else
                        {
                            finalResult = false;
                        }
                    }
                }

                if (finalResult)
                {
                    result = true;
                }
            }
            catch (RanorexException)
            {
                CloseModule(handle);
            }
            CloseModule(handle);
        }

        /// <summary>
        /// Sets a single Relay to a specific value
        /// </summary>
        /// <param name="cardAddress">
        /// The address of the card
        /// </param>
        /// <param name="relay">
        /// The Relay to set
        /// </param>
        /// <param name="bitValue">
        /// The value to set (0 or 1)
        /// </param>
        /// <param name="result">
        /// Used for reporting: true if the action was successful (setting a Relay)
        /// </param>
        public static void SetSingle(uint cardAddress, uint relay, uint bitValue, out bool result)
        {
            result = false;
            uint handle = GetCardHandle(cardAddress);

            // check amount DO channels
            uint digitalOutputSize = GetCardDigitalOutputSize(handle);
            try
            {
                if (relay > digitalOutputSize)
                {
                    Report.Info("Input Relay channel value to set was greater than the actual amount of channels of the card. \r\n Method will abort");
                    throw new RanorexException();
                }

                bool resultSet = SetValueToRelay(handle, relay, bitValue);
                if (resultSet)
                {
                    result = true;
                }
            }
            catch (RanorexException)
            {
                CloseModule(handle);
            }

            CloseModule(handle);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Closes a module
        /// </summary>
        /// <param name="handle">
        /// The handle of the opened card
        /// </param>
        private static void CloseModule(uint handle)
        {
            DeLibNET.DapiCloseModule(handle);
        }

        /* Used for completion of output array 
         * Readback of the card only lists entries until the last set Relay. All other zeros after the last set Relay are truncated
         * This method calculates the array size depending on the amount of DO channels of the opened card
         */

        /// <summary>
        /// The do set 16.
        /// </summary>
        /// <param name="cardHandle">
        /// The card handle.
        /// </param>
        /// <param name="bitValue">
        /// The bit value.
        /// </param>
        private static void DigitalOutputSet16(uint cardHandle, uint bitValue)
        {
            uint channel = 0;
            if (bitValue == 0)
            {
                channel = 0x0000;
            }
            else if (bitValue == 1)
            {
                channel = 0xffff;
            }

            uint fromFirst = 0;
            DeLibNET.DapiDOSet16(cardHandle, fromFirst, channel);
        }

        /// <summary>
        /// The do set 32.
        /// </summary>
        /// <param name="cardHandle">
        /// The card handle.
        /// </param>
        /// <param name="bitValue">
        /// The bit value.
        /// </param>
        private static void DigitalOutputSet32(uint cardHandle, uint bitValue)
        {
            uint channel = 0;
            if (bitValue == 0)
            {
                channel = 0x00000000;
            }
            else if (bitValue == 1)
            {
                channel = 0xffffffff;
            }

            uint fromFirst = 0;
            DeLibNET.DapiDOSet32(cardHandle, fromFirst, channel);
        }

        /// <summary>
        /// The do set 64.
        /// </summary>
        /// <param name="cardHandle">
        /// The card handle.
        /// </param>
        /// <param name="bitValue">
        /// The bit value.
        /// </param>
        private static void DOSet64(uint cardHandle, ulong bitValue)
        {
            ulong channel = 0;
            if (bitValue == 0)
            {
                channel = 0x0000000000000000;
            }
            else if (bitValue == 1)
            {
                channel = 0xffffffffffffffff;
            }

            uint fromFirst = 0;
            DeLibNET.DapiDOSet64(cardHandle, fromFirst, channel);
        }

        /// <summary>
        /// The do set 8.
        /// </summary>
        /// <param name="cardHandle">
        /// The card handle.
        /// </param>
        /// <param name="bitValue">
        /// The bit value.
        /// </param>
        private static void DigitalOutputSet8(uint cardHandle, uint bitValue)
        {
            uint channel = 0;
            if (bitValue == 0)
            {
                channel = 0x00;
            }
            else if (bitValue == 1)
            {
                channel = 0xff;
            }

            uint fromFirst = 0;
            DeLibNET.DapiDOSet8(cardHandle, fromFirst, channel);
        }

        /// <summary>
        /// Gets the size out the digital outputs from the card
        /// </summary>
        /// <param name="handle">
        /// The handle of the opened card
        /// </param>
        /// <returns>
        /// The digital output size of the card
        /// </returns>
        private static uint GetCardDigitalOutputSize(uint handle)
        {
            return DeLibNET.DapiSpecialCommand(handle, DeLibNET.DAPI_SPECIAL_CMD_GET_MODULE_CONFIG, DeLibNET.DAPI_SPECIAL_GET_MODULE_CONFIG_PAR_DO, 0, 0);
        }

        /// <summary>
        /// Gets the card handle from a RO_ETH module on a specific card address
        /// </summary>
        /// <param name="cardAddress">
        /// The address where the card is configured
        /// </param>
        /// <returns>
        /// The handle from the opened card
        /// </returns>
        private static uint GetCardHandle(uint cardAddress)
        {
            uint handle = (uint)DeLibNET.ModuleID.RO_ETH;
            handle = DeLibNET.DapiOpenModule(handle, cardAddress);

            // GetDigitalOutputSize(handle, cardAddress);
            return handle;
        }

        /// <summary>
        /// Reads all values from all Relay of a card up to a size of 64 DO channels
        /// </summary>
        /// <param name="cardHandle">
        /// The handle of the opened card
        /// </param>
        /// <returns>
        /// The values of all DO channels of a card
        /// </returns>
        private static ulong ReadbackAll(uint cardHandle)
        {
            // due to problems with the DOReadback64 method only the 32 bit variant of this method will be used
            // also the card size needs to be checked at first
            // card DO <= 32 -> only readback 32 channels once
            // card DO > 32 -> readback32 two times and combine the two uints to a ulong (by bitshifting the high value by 32 bits to the left)
            ulong result = 0;
            uint cardSize = GetCardDigitalOutputSize(cardHandle);

            if (cardSize <= 32)
            {
                uint readback = DeLibNET.DapiDOReadback32(cardHandle, 0x0);
                result = Convert.ToUInt64(readback);
            }
            else if (cardSize > 32)
            {
                uint high = DeLibNET.DapiDOReadback32(cardHandle, 0);
                uint low = DeLibNET.DapiDOReadback32(cardHandle, 32);

                result = (ulong)high << 32;
                result += low;
            }

            return result;
        }

        /// <summary>
        /// The set array size.
        /// </summary>
        /// <param name="cardDigitalOutputSize">
        /// The card do size.
        /// </param>
        /// <param name="binaryArrayLength">
        /// The binary array length.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int SetArraySize(uint cardDigitalOutputSize, int binaryArrayLength)
        {
            int outSize = -1;
            int cardSize = Convert.ToInt32(cardDigitalOutputSize);

            if (cardSize > binaryArrayLength)
            {
                int difference = cardSize - binaryArrayLength;
                outSize = binaryArrayLength + difference;
            }
            else if (cardSize == binaryArrayLength)
            {
                return cardSize;
            }

            return outSize;
        }

        /// <summary>
        /// Sets a value to a specific DO channel
        /// </summary>
        /// <param name="cardHandle">
        /// The handle of the opened card
        /// </param>
        /// <param name="relay">
        /// The Relay to set
        /// </param>
        /// <param name="bitValue">
        /// The value to set (0 or 1)
        /// </param>
        /// <returns>
        /// True if the Relay was correctly set
        /// </returns>
        private static bool SetValueToRelay(uint cardHandle, uint relay, uint bitValue)
        {
            DeLibNET.DapiDOSet1(cardHandle, Convert.ToUInt32(relay), bitValue);
            return ValidateRelayState(cardHandle, relay, bitValue);
        }

        /// <summary>
        /// Splits a string containing binary values to a char array
        /// </summary>
        /// <param name="binaryValues">
        /// A string containing binary values
        /// </param>
        /// <returns>
        /// A char array containing all binary values
        /// </returns>
        private static char[] SplitBinaryString(string binaryValues)
        {
            return binaryValues.ToCharArray();
        }

        /// <summary>
        /// The to binary.
        /// </summary>
        /// <param name="decimalNumber">
        /// The decimal.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string ToBinary(ulong decimalNumber)
        {
            string binaryResult = string.Empty;

            while (decimalNumber > 0)
            {
                ulong binaryHolder = decimalNumber % 2;
                binaryResult += binaryHolder;
                decimalNumber = decimalNumber / 2;
            }

            // The algoritm gives us the binary number in reverse order (mirrored)
            // We store it in an array so that we can reverse it back to normal
            char[] binaryArray = binaryResult.ToCharArray();
            Array.Reverse(binaryArray);
            binaryResult = new string(binaryArray);

            return binaryResult;
        }

        /// <summary>
        /// Validates a specific Relay for a specific value
        /// </summary>
        /// <param name="cardHandle">
        /// The handle of the opened card
        /// </param>
        /// <param name="relay">
        /// The Relay to validate
        /// </param>
        /// <param name="bitValue">
        /// The value to validate for (0 or 1)
        /// </param>
        /// <returns>
        /// True if the Relay has the correct value
        /// </returns>
        private static bool ValidateRelayState(uint cardHandle, uint relay, uint bitValue)
        {
            ulong values = ReadbackAll(cardHandle);
            string binaryValuesString = ToBinary(values);

            // case: every channel has value 0 and bitValue is 0
            if (string.IsNullOrEmpty(binaryValuesString) && bitValue == 0)
            {
                Report.Info("All card Relay have the value 0");
                return true;
            }

            char[] splittedBinaryArray = SplitBinaryString(binaryValuesString);
            int arrayIndex = splittedBinaryArray.Length - 1;

            // case: set Relay, which already has state 0, to 0 with correct output
            if ((uint)splittedBinaryArray.Length <= relay && bitValue == 0)
            {
                Report.Info(string.Format("Relay '{0}' has state 0", relay));
                return true;
            }

            foreach (char single in splittedBinaryArray)
            {
                int singleInt = int.Parse(single.ToString(CultureInfo.InvariantCulture));
                if (singleInt == bitValue && arrayIndex == relay)
                {
                    Report.Info(string.Format("Relay '{0}' has state {1}", relay, bitValue));
                    return true;
                }

                arrayIndex = arrayIndex - 1;
            }

            return false;
        }

        /// <summary>
        /// Validates all DO channels of a card
        /// </summary>
        /// <param name="cardHandle">
        /// The handle of the opened card
        /// </param>
        /// <param name="bitValue">
        /// The value to validate for (0 or 1)
        /// </param>
        /// <returns>
        /// True if all Relay have the correct value
        /// </returns>
        private static bool ValidateRelayState(uint cardHandle, uint bitValue)
        {
            ulong values = ReadbackAll(cardHandle);
            string binaryValuesString = ToBinary(values);

            // case: every channel has value 0 and bitValue is 0
            if (string.IsNullOrEmpty(binaryValuesString) && bitValue == 0)
            {
                Report.Info("All card Relay have the value 0");
                return true;
            }

            char[] splittedBinaryArray = SplitBinaryString(binaryValuesString);

            int failedComparison = 0;
            foreach (char single in splittedBinaryArray)
            {
                int singleInt = int.Parse(single.ToString(CultureInfo.InvariantCulture));
                if (singleInt != bitValue)
                {
                    failedComparison++;
                }
            }

            if (failedComparison >= 1)
            {
                Report.Failure(string.Format("Not all ({0} Relay) have the correct state", failedComparison));
                return false;
            }

            return true;
        }

        #endregion
    }
}