// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateDTMCatalogue.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   This class describes dialog [Update DTM Catalog] in an abstract way.
//   Elements could be accessed for reading or using.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.Dialogs.UpdateDTMCatalogue.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.UpdateDTMCatalogue.Execution;

    using Ranorex;

    using DateTime = System.DateTime;

    /// <summary>
    ///     This class describes dialog [Update DTM Catalog] in an abstract way.
    ///     Elements could be accessed for reading or using.
    /// </summary>
    public class UpdateDtmCatalogue : MarshalByRefObject, IUpdateDTMCatalogue
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Cancel DTMs in Catalog after update
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Cancel()
        {
            try
            {
                (new UpdateDtmCatalogueElements()).Cancel.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Confirm DTMs in Catalog after Update
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Confirm()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Waiting for 30 seconds because the DTM catalog might be huge");
            Delay.Milliseconds(1000 * 30);

            try
            {
                (new UpdateDtmCatalogueElements()).Ok.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Open Help for DTM Catalog
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Help()
        {
            try
            {
                (new UpdateDtmCatalogueElements()).Help.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Move selected DTM from one side to another
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Move()
        {
            try
            {
                (new UpdateDtmCatalogueElements()).Move.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Select new on left side
        /// </summary>
        /// <param name="shouldFindNewDevice">
        /// if set to <c>true</c> [should find new device].
        /// </param>
        /// <param name="maxMinutesSinceDtmWasInstalled">
        /// The maximum minutes since DTM was installed.
        /// </param>
        /// <returns>
        /// <br>True: if element was found and clicked</br>
        /// <br>False: if an error occurred</br>
        /// </returns>
        public bool SelectNewOnLeft(bool shouldFindNewDevice, int maxMinutesSinceDtmWasInstalled)
        {
            try
            {
                bool status = false;

                IList<Row> newDeviceRowList = (new UpdateDtmCatalogueElements()).DevicesOnLeft;

                if (newDeviceRowList != null)
                {
                    if (newDeviceRowList.Count != 0)
                    {
                        var foundDevices = new StringBuilder();
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Selecting following devices:");
                        foreach (Row myCell in newDeviceRowList)
                        {
                            Cell statusCell = myCell.Children[0].Element;
                            Cell deviceTypCell = myCell.Children[1].Element;
                            Cell dateTime = myCell.Children[8].Element;
                            if (statusCell != null && deviceTypCell != null && dateTime != null)
                            {
                                if (statusCell.Text.Contains("New") || statusCell.Text.Contains("Changed"))
                                {
                                    status = true;
                                    myCell.MoveTo();
                                    myCell.Select();
                                    foundDevices.Append(deviceTypCell.Text);
                                }

                                if (statusCell.Text == string.Empty)
                                {
                                    DateTime installDate = DateTime.ParseExact(dateTime.Text, "dd.MM.yyyy HH:mm", null);
                                    DateTime now = DateTime.Now;

                                    var minutesSinceInstalled = (int)(now - installDate).TotalMinutes;

                                    // max. 120 minutes to be valid otherwise to old
                                    if (minutesSinceInstalled < maxMinutesSinceDtmWasInstalled)
                                    {
                                        status = true;
                                        myCell.MoveTo();
                                        myCell.Select();
                                        foundDevices.Append(dateTime.Text + deviceTypCell.Text);
                                    }
                                    else
                                    {
                                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device too old@(" + dateTime.Text + ": " + minutesSinceInstalled + " -> minutes since dtm was installed):" + deviceTypCell.Text);
                                    }
                                }

                                if (statusCell.Text == "Error")
                                {
                                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Error no device found@(" + dateTime.Text + "):" + deviceTypCell.Text);
                                }
                            }
                        }

                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), foundDevices.ToString());

                        return status;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Error: Can't find any new Device. List is empty.");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Error: New device table (left hand side) is null.");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Update DTM Catalog to scan for changes
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Update()
        {
            try
            {
                (new UpdateDtmCatalogueElements()).Update.Click(DefaultValues.locDefaultLocation);
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion
    }
}