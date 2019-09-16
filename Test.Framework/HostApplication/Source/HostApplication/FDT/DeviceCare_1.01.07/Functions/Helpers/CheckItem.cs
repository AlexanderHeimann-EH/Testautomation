/*
 * Created by Ranorex
 * User: Anja Kellner
 * Date: 22/06/2012
 * Time: 10:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers
{
    /// <summary>
    /// This class could be used for checking items.
    /// </summary>
    public static class CheckItem
  {
        /// <summary>
        /// 
        /// </summary>
        public static Element element;
    
        /// <summary>
        /// Checks if an item is visible
        /// </summary>
        /// <param name="elementInfo">RepoItemInfo of element to check</param>
        /// <param name="timeout">Time to search fot the element in ms;
        /// if null then the default timeout 1000 is used</param>
        /// <returns>true if the element is visible; false in all other cases</returns>
        public static bool checkVisible(RepoItemInfo elementInfo, Duration timeout)
        {
          if (timeout == null)
          {
            timeout = 1000;
          }
      
          bool exists = Ranorex.Host.Local.TryFindSingle(elementInfo.AbsolutePath, timeout, out element);
          if( exists )
          {
             Report.Debug("The element " + elementInfo.ToString() + " seems to be visible: " + element.Visible.ToString());
            return element.Visible;
          }
          else
          {
            Report.Debug("The element " + elementInfo.ToString() + " does not seem to exist.");
            return false;
          }
        }
    
        /// <summary>
        /// Checks if an item is enabled
        /// </summary>
        /// <param name="elementInfo">RepoItemInfo Path of element to check</param>
        /// <param name="timeout">Time to search fot the element in ms;
        /// if null then the default timeout 1000 is used</param>
        /// <returns>true if the element is enabled; false in all other cases</returns>
        public static bool checkEnabled(RepoItemInfo elementInfo, Duration timeout)
        {
          if (timeout == null)
          {
            timeout = 1000;
          }
          if (checkVisible(elementInfo, timeout))
          {
            Report.Debug("The element " + elementInfo.ToString() + " seems to be enabled: " + element.Enabled.ToString());
            return element.Enabled;
          }
          else
          {
            Report.Debug("The element " + elementInfo.ToString() + " does not seem to be visible.");
            return false;
          }
        }
  }
}
