/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 24.08.2015
 * Time: 10:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers.InterfaceHelpers
{
    using System.Diagnostics;
    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Description of OnlineConnectFunctions.
    /// </summary>
    public class OnlineConnectFunctions
    {

        /// <summary>
        /// 
        /// </summary>
        public OnlineConnectFunctions()
        {
        }

        //TODO: + check if visible, + timeout
        // ab ins common
        // rename to IsRepoItemVisible
        
        //TODO: WaitForItemVisible(RepoItemInfo item);
        
        /// <summary>
        /// Checks and waits if a page exists
        /// </summary>
        /// <param name="item">The item to validate and wait for</param>
        /// <returns>True if the page exists</returns>
        public bool WaitForItemVisible(RepoItemInfo item)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                while (watch.ElapsedMilliseconds < 10000)
                {
                    if (watch.ElapsedMilliseconds >= 10000)
                    {
                        return false;
                    }

                    if (item.Exists())
                    {
                        watch.Stop();
                        return true;
                    }
                }

                //check if item is visible
            }
            catch (RanorexException)
            {
                Report.Failure("Page was not shown after ten seconds. ");
                return false;
            }

            return true;
        }
    }
}
