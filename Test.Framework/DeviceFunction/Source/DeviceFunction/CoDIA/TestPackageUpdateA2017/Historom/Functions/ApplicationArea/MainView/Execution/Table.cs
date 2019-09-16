// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Table.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides methods for taking a screenshot of the diagram within tab "Table"
    ///     Provides methods for event list entries within module HISTOROM , tab table
    /// </summary>
    public class Table : ITable
    {
        #region Constants

        /// <summary>
        /// The channel 1.
        /// </summary>
        private const int Channel1 = 5;

        /// <summary>
        /// The channel 2.
        /// </summary>
        private const int Channel2 = 6;

        /// <summary>
        /// The channel 3.
        /// </summary>
        private const int Channel3 = 7;

        /// <summary>
        /// The channel 4.
        /// </summary>
        private const int Channel4 = 8;

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
        /// Gets the number of events.
        /// </summary>
        /// <returns>The number of events.</returns>
        public int GetNumberOfEvents()
        {
            return this.CountEvents();
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
                IList<TreeItem> treeItemsEventList = new TableElements().GetHistoRomEventList();
                if (treeItemsEventList != null && treeItemsEventList.Count != 0)
                {
                    // make sure first event is visible
                    this.ScrollToTop(treeItemsEventList);

                    int index;
                    for (index = 0; index < treeItemsEventList.Count; index++)
                    {
                        TreeItem treeItemEvent = treeItemsEventList[index];
                        IList<Unknown> listCells = treeItemEvent.Children;
                        if (listCells == null || listCells.Count == 0)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No children cells available");
                        }
                        else
                        {
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

                            // if last element in list is visible,  no scroll needed
                            if (treeItemsEventList[treeItemsEventList.Count - 1].Visible == false)
                            {
                                this.ScrollDown();
                            }
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

        #endregion

        #region Methods

        /// <summary>
        /// Counts the events.
        /// </summary>
        /// <returns>Number of the events.</returns>
        private int CountEvents()
        {
            int result = 0;
            IList<TreeItem> treeItemsEventList = new TableElements().GetHistoRomEventList();
            if (treeItemsEventList == null || treeItemsEventList.Count == 0)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "EventList does not exist");
            }
            else
            {
                this.ScrollToLastEvent(treeItemsEventList);
                Cell eventNumber = treeItemsEventList[treeItemsEventList.Count - 1].FindChild<Cell>();
                result = Convert.ToInt32(eventNumber.Text);
            }

            return result;
        }

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
        private IEvent CreateEvent(IList<Unknown> listCells)
        {
            try
            {
                IEvent result = new Event();

                if (listCells == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "IList listCells is null");
                }
                else if (listCells.Count != 9)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tree item has not enough child cells. Creating event failed.");
                    result.EventNumber = listCells[Id].As<Cell>().Text;
                }
                else
                {
                    result.EventNumber = listCells[Id].As<Cell>().Text;
                    result.Date = listCells[Date].As<Cell>().Text;
                    result.OperationHours = listCells[Hours].As<Cell>().Text;
                    result.EventName = listCells[Name].As<Cell>().Text;
                    result.Description = listCells[Description].As<Cell>().Text;
                    result.Channel1 = listCells[Channel1].As<Cell>().Text;
                    result.Channel2 = listCells[Channel2].As<Cell>().Text;
                    result.Channel3 = listCells[Channel3].As<Cell>().Text;
                    result.Channel4 = listCells[Channel4].As<Cell>().Text;
                }

                return result;
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
                    if (listCells.Count == 9)
                    {
                        actualEvent.Description += " " + "||" + " " + listCells[Description].As<Cell>().Text;
                    }
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
        /// Scrolls down via keyboard down button.
        /// </summary>
        private void ScrollDown()
        {
            try
            {
                Keyboard.Press(Keys.Down);
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        /// <summary>
        /// Scrolls to last event.
        /// </summary>
        /// <param name="treeItemsEventList">
        /// The tree items of the event list.
        /// </param>
        private void ScrollToLastEvent(IList<TreeItem> treeItemsEventList)
        {
            try
            {
                Element tree = new TableElements().EventListTree;
                Mouse.Click(tree, Location.Center);
                while (treeItemsEventList[treeItemsEventList.Count - 1].Visible == false)
                {
                    Keyboard.Press(Keys.Down);
                }
            }
            catch (Exception exception)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        /// <summary>
        /// Scrolls to top of event list so that first event is visible (via keyboard up).
        /// </summary>
        /// <param name="treeItemsEventList">
        /// The tree Items Event List.
        /// </param>
        private void ScrollToTop(IList<TreeItem> treeItemsEventList)
        {
            try
            {
                Element tree = new TableElements().EventListTree;
                Mouse.Click(tree, Location.Center);
                while (treeItemsEventList[0].Visible == false)
                {
                    Keyboard.Press(Keys.Up);
                }
            }
            catch (Exception exception)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
            }
        }

        #endregion
    }
}