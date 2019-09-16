/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 27.08.2015
 * Time: 15:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Linq;

using Ranorex;
using Ranorex.Core;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Settings
{
    using System.Diagnostics;

    /// <summary>
    /// Description of Page_Settings_Functions.
    /// </summary>
    public class Page_Settings_Functions
    {
        /// <summary>
        /// 
        /// </summary>
        public Page_Settings_Functions()
        {
            logContainsExactlyOneEvent = false;
            timeStamps = new List<string>();
            eventMessages = new List<string>();
        }

        #region Fields/Properties
        
        /// <summary>
        /// 
        /// </summary>
        List<string> timeStamps;

        /// <summary>
        /// 
        /// </summary>
        List<string> eventMessages;
        
        /// <summary>
        /// 
        /// </summary>
        private List<string> _EventLogMessages;

        /// <summary>
        /// 
        /// </summary>
        public List<string> EventLogMessages
        {
           get { return _EventLogMessages; }
           set { _EventLogMessages = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        bool logContainsExactlyOneEvent;

        /// <summary>
        /// 
        /// </summary>
        public bool LogContainsExactlyOneEvent {
            get { return logContainsExactlyOneEvent; }
            set { logContainsExactlyOneEvent = value; }
        }
        
        #endregion
        
        /// <summary>
        /// Opens the settings page out of the home screen
        /// </summary>
        public void OpenSettingsPage()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            repo.DeviceCare.MenuArea.Menu_Home.ButtonSettings.Click();
        }
        /// <summary>
        /// Validates if the settings page is visible
        /// </summary>
        /// <returns>True if settings page is visible</returns>
        public bool IsSettingsPageShown()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            
            if (repo.DeviceCare.ApplicationArea.Page_Settings.Self.Visible)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        #region DTM Catalog
        
        /// <summary>
        /// Triggers a manual catalog update and waits for the update to finish
        /// </summary>
        /// <returns>True if the update was successful</returns>
        public bool TriggerUpdate()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            
            var function = new EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows.GetMessageLog();
            List<string> log = new List<string>();
            //precondition: dtm catalog page is shown
            if (IsDTMCatalogShown())
           {
               //press f5
               Keyboard.Press(System.Windows.Forms.Keys.F5);

               try
               {
                   //repo.DeviceCare.ApplicationArea.Page_Settings.DTMCatalogUpdateProgressbarInfo.WaitForExists(10000);

                Stopwatch watch = new Stopwatch();
                watch.Start();
                while (watch.ElapsedMilliseconds < 10000)
                {
                    if (watch.ElapsedMilliseconds >= 10000)
                    {
                        //return false;
                    }

                    if (repo.DeviceCare.ApplicationArea.Page_Settings.DTMCatalogUpdateProgressbarInfo.Exists())
                    {
                        watch.Stop();
                        //return true;
                    }
                }

                bool visible = repo.DeviceCare.ApplicationArea.Page_Settings.DTMCatalogUpdateProgressbar.Visible;
                   while(!visible)
                   {
                       visible = repo.DeviceCare.ApplicationArea.Page_Settings.DTMCatalogUpdateProgressbar.Visible;
                   }
                   
                   //get progressbar value
                   ObserveDTMCatalogProgressbar();

                   //check message log if update was successful
                   
                   log = function.Run();
                   bool complete = false;
                   bool applied = false;
                   foreach(string msg in log)
                   {
                       if (msg.Contains(CommonInternal.DConst.EVENTLOG_MESSAGE_DTMCATALOGUPDATECOMPLETE))
                       {
                           complete = true;
                       }
                       if (msg.Contains(CommonInternal.DConst.EVENTLOG_MESSAGE_DTMCATALOGAPPLIED))
                       {
                           applied = true;
                       }
                   }
                   //check that progressbar is no longer visible
                   if (!repo.DeviceCare.ApplicationArea.Page_Settings.DTMCatalogUpdateProgressbar.Element.Visible)
                   {
                       if (complete & applied)
                       {
                           Report.Success("The DTM catalog update was successful and the new catalog has been applied");
                           return true;
                       }    
                   }
                   else
                   {
                       return false;
                   }
                   throw new RanorexException();
               }
               catch (Exception)
               {
                   return false;
               }
           }
           else
           {
               return false;
           }
        }
        
        /// <summary>
        /// Opens the DTM catalog out of the settings screen
        /// </summary>
        public void OpenDTMCatalog()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            
            repo.DeviceCare.MenuArea.Menu_Settings.ButtonDtmCatalog.Click();
        }
        /// <summary>
        /// Validates if the DTM catalog page is visible
        /// </summary>
        /// <returns>True if the DTM catalog is visible</returns>
        public bool IsDTMCatalogShown()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            
            if (repo.DeviceCare.ApplicationArea.Page_Settings.Table_DTMCatalog.Self.Visible)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Delays execution until DTM catalog update progress bar is completed and reports the progress periodically
        /// </summary>
        public void ObserveDTMCatalogProgressbar()
        {
            var repo = GUI.DeviceCareApplication.Instance;
            
            ProgressBar bar = repo.DeviceCare.ApplicationArea.Page_Settings.DTMCatalogUpdateProgressbar;
            double prevValue = 0;
            
           while(repo.DeviceCare.ApplicationArea.Page_Settings.DTMCatalogUpdateProgressbar.Element.Visible)
           {
               if (prevValue != bar.Value)
               {
                   Report.Log(ReportLevel.Info,string.Format("DTM catalog update progress: {0}", bar.Value));
                   prevValue = bar.Value;
               }
               if (bar.Value >= 95)
               {
                   break;
               }
           }
        }

        #endregion
        
        #region Eventlog
        
        /// <summary>
        /// "Constructs" the property 'EventLogMessage'
        /// </summary>
        public void ConstructEventLog()
        {
            
            string eventMsg = string.Empty;
            _EventLogMessages = new List<string>(timeStamps.Count);
           
           for (int i = 0;i <= timeStamps.Count -1;i++)
           {
               eventMsg = "Timestamp: "+timeStamps[i]+"\r\n Message: "+eventMessages[i];
               _EventLogMessages.Add(eventMsg);
           }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Element> GetChildrenList()
        {
           var repo = GUI.DeviceCareApplication.Instance;
           return repo.DeviceCare.ApplicationArea.Page_Settings.Table_EventLog.Self.Element.Children.ToList();
        }
        
        /// <summary>
        /// This function creates children of the eventlog table
        /// until the cells can be addressed. If the cells are fetched
        /// the desired data is stored in lists
        /// </summary>
        public void PopulateListsWithEventLogMessages()
        {
           var repo = GUI.DeviceCareApplication.Instance;
           
           //get children of eventlog table
           IList<Element> elements = repo.DeviceCare.ApplicationArea.Page_Settings.Table_EventLog.Self.Element.Children;
           
           List<Row> rows = new List<Row>();
           
           //add all 'Element' children from elements(list) and cast them to 'Row'
           foreach(Element element in elements)
           {
               rows.Add((Row)element);
           }
           
           List<Cell> cells = new List<Cell>();
           List<Element> dummyCast = new List<Element>();
           List<Unknown> dummy = new List<Unknown>();
           
           //gets the immediate children of all rows in the eventlog table
           foreach(Row row in rows)
           {
               dummy.AddRange(row.Children.ToList());
           }
           //casts all immediate children of allrows(type unknown) to type 'Element' and add them to a list
           foreach(Unknown unknown in dummy)
           {
               dummyCast.Add((Element)unknown);
           }
           //try to cast items from list dummyCast(type element) to type Cell
           //if cast is unsuccessful an exception will be thrown and catched -> skipped
           foreach(Element lmnt in dummyCast)
           {
               try
               {
                   cells.Add((Cell) lmnt);
               }
               catch
               {    
               }
           }
           //linq query, which selects all cells which childindex is 1 (the 'time' column of the eventlog table)
           var timeQuery = 
               from cell in cells
               where Convert.ToInt32(cell.Element.GetAttributeValue("ChildIndex")) == 1
               select cell;
           //linq query, which selects all cells which childindex is 2 (the 'event' column of the eventlog table)
           var eventQuery = 
               from cell in cells
               where Convert.ToInt32(cell.Element.GetAttributeValue("ChildIndex")) == 2
               select cell;

               //execute linq query 1 and add all matches to a list
               foreach(Cell cell in timeQuery)
               {
                   if (!Convert.ToBoolean(cell.Element.GetAttributeValue("IsHeader")))
                   {
                       timeStamps.Add(cell.Element.GetAttributeValueText("UIAutomationValueValue"));
                   }
               }
               //execute linq query 2 and add all matches to a list
               foreach(Cell cell2 in eventQuery)
               {
                   if (!Convert.ToBoolean(cell2.Element.GetAttributeValue("IsHeader")))
                   {
                       eventMessages.Add(cell2.Element.GetAttributeValueText("UIAutomationValueValue"));
                   }
               }
                //if existing: delete null object from timestamps list
//                if (timeStamps[0].GetType() == typeof(Object))
//                {
//                    timeStamps.RemoveAt(0);
//                }
        }

        #endregion
    }
}
