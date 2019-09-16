// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TableFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class TableFunctions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.EventList.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EventList.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.EventList.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    /// Class TableFunctions.
    /// </summary>
    public class TableFunctions : ITableFunctions
    {
        #region Constants

        /// <summary>
        /// The date.
        /// </summary>
        private const int Date = 1;

        /// <summary>
        /// The description.
        /// </summary>
        private const int Description = 4;

        /// <summary>
        /// The hours.
        /// </summary>
        private const int Hours = 2;

        /// <summary>
        /// The id.
        /// </summary>
        private const int Id = 0;

        /// <summary>
        /// The name.
        /// </summary>
        private const int Name = 3;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Returns event from earlier generated list according to event number given by user
        /// </summary>
        /// <param name="eventNumber">
        /// Event number given by the user
        /// </param>
        /// <param name="eventList">
        /// List containing entire event list
        /// </param>
        /// <returns>
        /// <br>String result: if call worked fine</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public string GetEvent(int eventNumber, IList<IEvent> eventList)
        {
            try
            {
                if (eventList != null)
                {
                    int index = eventNumber - 1;
                    if (index < 0 || index >= eventList.Count)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Event " + eventNumber + " is not available");
                        return null;
                    }

                    IEvent actualEvent = eventList[index];
                    string result = actualEvent.ToString();
                    return result;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "IList eventList is null");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        ///     Reads the entire event list and creates a list with the events
        /// </summary>
        /// <returns>
        ///     <br>IList: if event list was created successfully</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public IList<IEvent> ReadEvents()
        {
            try
            {
                IList<IEvent> listEvent = new List<IEvent>();
                IList<TreeItem> treeItemsEventList = new ResultElements().Entries();
                if (treeItemsEventList != null && treeItemsEventList.Count != 0)
                {
                    Button cachedLineDownButton;

                    /*check if scrollDown button is available
                    exception thrown if it isn't, reading list without scrolling down
                     */
                    try
                    {
                        cachedLineDownButton = new ResultElements().ButtonLineDown;
                    }
                    catch (Exception)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Scroll down button not found, no problem if event list is not scrollable (only a few entries)");
                        cachedLineDownButton = null;
                    }

                    // make sure first event is visible
                    this.ScrollToTop();

                    int index;
                    for (index = 0; index < treeItemsEventList.Count; index++)
                    {
                        TreeItem treeItemEvent = treeItemsEventList[index];
                        IList<Unknown> listCells = treeItemEvent.Children;

                        /*Checks if first cell of actual tree item has no text
                        This is the case if the description of an event needs more than one row
                        */
                        if (listCells[Id].As<Cell>().Text.Equals(string.Empty))
                        {
                            // check if list is empty if it is, cell of first row (event) is empty -> failure
                            if (listEvent.Count == 0)
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "List empty ?,First cell of first row is empty");
                            }
                            else
                            {
                                // cell "row" is empty, list is not empty ->add description to previous event:
                                int lastEventIndex = listEvent.Count - 1;
                                this.CreateEventDescription(listCells, listEvent[lastEventIndex]);
                            }
                        }
                        else
                        {
                            // normal event, add to list :
                            listEvent.Add(this.CreateEvent(listCells));
                        }

                        // if null,  no scroll needed
                        if (cachedLineDownButton != null)
                        {
                            this.ScrollDown(cachedLineDownButton);
                        }
                    }

                    return listEvent;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "List is empty!");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets the number of events.
        /// </summary>
        /// <returns>The number of events.</returns>
        public int GetNumberOfEvents()
        {
            return this.ReadEvents().Count;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Creates an event
        /// </summary>
        /// <param name="listCells">
        /// cell list containing cells "date", "event number" , "operation hours" etc.
        /// </param>
        /// <returns>
        /// <br>Event: if Event was created successfully</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        private Event CreateEvent(IList<Unknown> listCells)
        {
            try
            {
                if (listCells != null)
                {
                    var result = new Event { EventNumber = listCells[Id].As<Cell>().Text, Date = listCells[Date].As<Cell>().Text, OperationHours = listCells[Hours].As<Cell>().Text, EventName = listCells[Name].As<Cell>().Text, Description = listCells[Description].As<Cell>().Text };

                    return result;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "IList listCells is null");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Creates description for an event
        ///     This method is only used if the description needs more than one row (service id, please wait .... etc.)
        /// </summary>
        /// <param name="listCells">
        /// cell list containing cells "date", "event number" , "operation hours" etc.
        /// </param>
        /// <param name="actualEvent">
        /// actual event for which description has to be created
        /// </param>
        private void CreateEventDescription(IList<Unknown> listCells, IEvent actualEvent)
        {
            try
            {
                if (listCells != null)
                {
                    actualEvent.Description += " " + "||" + " " + listCells[Description].As<Cell>().Text;
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "IList listCells is null!");
                }
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        /// <summary>
        /// Scrolls down via line down button
        /// </summary>
        /// <param name="cachedLineDownButton">
        /// The cached Line Down Button.
        /// </param>
        private void ScrollDown(Button cachedLineDownButton)
        {
            try
            {
                cachedLineDownButton.Click();
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        /// <summary>
        ///     Scrolls to top via page up button of event list so that first event is visible
        /// </summary>
        private void ScrollToTop()
        {
            try
            {
                Button button = new ResultElements().ButtonPageUp;
                while (button.Visible)
                {
                    button.Click();
                }
            }
            catch (Exception)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Page Up button not found, no problem if event list is not scrollable (only a few entries)");
            }
        }

        #endregion
    }
}