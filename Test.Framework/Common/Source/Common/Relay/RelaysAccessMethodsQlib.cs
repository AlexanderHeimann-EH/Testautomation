// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelaysAccessMethodsQlib.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2013
// </copyright>
// <summary>
//   The enumerations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: ?
 * Date: ?
 * Version: 1.0
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Relay
{
    using Ranorex;

    /// <summary>
    /// Use the Relay card Quancom USB Relay 8.
    /// Note: Driver and hardware must be installed.
    /// </summary>
    public static class RelaysAccessMethodsQlib
    {
        #region Public Methods and Operators

        /// <summary>
        /// Clears all Relay settings to default 0.
        /// </summary>
        /// <param name="cardAddress">
        /// The card address defined via dip switches.
        /// </param>
        public static void ClearAll(uint cardAddress)
        {
            uint handle = qlib32.QAPIExtOpenCard(qlib32.USBREL8, cardAddress);
            if (handle != 0)
            {
                qlib32.QAPIExtWriteDO8(handle, 0, 0, 0);
                qlib32.QAPIExtCloseCard(handle);
                Report.Info("All Channel are Clear");
            }
            else
            {
                Report.Failure("USB RelayCard not found at Address " + cardAddress);
            }
        }

        /// <summary>
        /// Clear a single bit.
        /// </summary>
        /// <param name="cardAddress">
        /// The card address defined via dip switches.
        /// </param>
        /// <param name="unsetBit">
        /// The Relay to clear.
        /// </param>
        public static void ClearChannel(uint cardAddress, uint unsetBit)
        {
            uint[] test = Uint8ToBinArray(GetValue(cardAddress));
            uint cardValue = GetValue(cardAddress);
            if (unsetBit >= 7)
            {
                if (test[unsetBit] == 1)
                {
                    uint handle = qlib32.QAPIExtOpenCard(qlib32.USBREL8, cardAddress);
                    if (handle != 0)
                    {
                        qlib32.QAPIExtWriteDO8(handle, 0, cardValue - Binpow(unsetBit), 0);
                        qlib32.QAPIExtCloseCard(handle);
                        Report.Info("Channel " + unsetBit + " Is cleared at Card address " + cardAddress);
                    }
                    else
                    {
                        Report.Failure("USB RelayCard not found at Address " + cardAddress);
                    }
                }
                else
                {
                    Report.Info("Bit is not set");
                }
            }
            else
            {
                Report.Info("Channel" + unsetBit + " is not in the range of 0 to 7");
            }
        }

        /// <summary>
        /// Gets the value currently set to Relay.
        /// </summary>
        /// <param name="cardAddress">
        /// The card Address.
        /// </param>
        /// <returns>
        /// The <see cref="uint"/>.
        /// </returns>
        public static uint GetValue(uint cardAddress)
        {
            uint setValues;
            uint handle = qlib32.QAPIExtOpenCard(qlib32.USBREL8, cardAddress);
            if (handle != 0)
            {
                setValues = qlib32.QAPIExtSpecial(handle, qlib32.JOB_READ_BACK_RELAYS, 0, 0);
                qlib32.QAPIExtCloseCard(handle);
                return setValues;
            }

            Report.Failure("USB RelayCard not found at Address " + cardAddress);
            return 0;
        }

        /// <summary>
        /// The set all.
        /// </summary>
        /// <param name="cardAddress">
        /// The card address.
        /// </param>
        public static void SetAll(uint cardAddress)
        {
            uint handle = qlib32.QAPIExtOpenCard(qlib32.USBREL8, cardAddress);
            if (handle != 0)
            {
                qlib32.QAPIExtWriteDO8(handle, 0, 255, 0);
                qlib32.QAPIExtCloseCard(handle);
                Report.Info("All Channel are Set");
            }
            else
            {
                Report.Failure("USB RelayCard not found at Address " + cardAddress);
            }
        }

        /// <summary>
        /// Set a single Relay.
        /// </summary>
        /// <param name="cardAddress">
        /// The card Address.
        /// </param>
        /// <param name="setBit">
        /// The set Bit.
        /// </param>
        public static void SetChannel(uint cardAddress, uint setBit)
        {
            if (setBit > 7)
            {
                Report.Info("Channel " + setBit + " is not in the range of 0 to 7");
            }
            else
            {
                uint[] test = Uint8ToBinArray(GetValue(cardAddress));
                uint cardvalue = GetValue(cardAddress);
                if (test[setBit] == 1)
                {
                    Report.Info("Channel " + setBit + " Is alrady set");
                }
                else
                {
                    uint handle = qlib32.QAPIExtOpenCard(qlib32.USBREL8, cardAddress);
                    if (handle != 0)
                    {
                        qlib32.QAPIExtWriteDO8(handle, 0, cardvalue + Binpow(setBit), 0);
                        qlib32.QAPIExtCloseCard(handle);
                        Report.Info("Channel " + setBit + " is Set at USB card address " + cardAddress);
                    }
                    else
                    {
                        Report.Failure("USB RelayCard not found at Address " + cardAddress);
                    }
                }
            }
        }

        /// <summary>
        /// Set new value to Relay.
        /// </summary>
        /// <param name="cardAddress">
        /// The card address defined via dip switches.
        /// </param>
        /// <param name="setBits">
        /// The Relay (bits) to set.
        /// </param>
        public static void SetValue(uint cardAddress, uint setBits)
        {
            uint handle = qlib32.QAPIExtOpenCard(qlib32.USBREL8, cardAddress);
            if (handle != 0)
            {
                qlib32.QAPIExtWriteDO8(handle, 0, setBits, 0);
                qlib32.QAPIExtCloseCard(handle);
                Report.Info("Relay value " + setBits + " set to USB card " + cardAddress);
            }
            else
            {
                Report.Failure("USB RelayCard not found at Address " + cardAddress);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// uint8s to bin array.
        /// </summary>
        /// <param name="unsignedInt">
        /// The uint.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>uint[]</cref>
        ///     </see>
        ///     .
        /// </returns>
        private static uint[] Uint8ToBinArray(uint unsignedInt)
        {
            uint i = 8;
            uint[] temparray = new uint[8];
            do
            {
                if (unsignedInt >= Binpow(i - 1))
                {
                    unsignedInt = unsignedInt - Binpow(i - 1);
                    temparray[i - 1] = 1;
                    i--;
                }
                else
                {
                    i--;
                }
            }
            while (i != 0);
            return temparray;
        }

        /// <summary>
        /// Binpows the specified exponent.
        /// </summary>
        /// <param name="exponent">
        /// The exponent.
        /// </param>
        /// <returns>
        /// The <see cref="uint"/>.
        /// </returns>
        private static uint Binpow(uint exponent)
        {
            int i = 2;
            uint pow = 2;
            if (exponent == 0)
            {
                return 1;
            }

            if (exponent == 1)
            {
                return 2;
            }

            do
            {
                pow = pow * 2;
                i++;
            }
            while (i != exponent + 1);
            return pow;
        }

        #endregion
    }
}