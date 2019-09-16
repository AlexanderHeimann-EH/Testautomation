/*
 * Created by Ranorex
 * User: Anja Kellner
 * Date: 16/10/2012
 * Time: 09:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers
{
  /// <summary>
  /// This class contains methods to wait for an specific element
  /// </summary>
  public static class WaitForEvent
  {
    /// <summary>
    /// Waits for an element to be visible
    /// </summary>
    /// <param name="elementInfo">Repository Item Info of the element to check</param>
    /// <param name="timeout">How long I want to wait for the element to be visible</param>
    /// <returns>true if the element is visible</returns>
    public static bool WaitForElementVisible(RepoItemInfo elementInfo, Duration timeout)
    {
      bool visible = false;
      int checkPeriod = 500; // ms
      
      // if timeout is longer than a second then check periodically every checkPeriod ms
      if (timeout > 500)
      {
        int countMax = timeout.Milliseconds / checkPeriod;
        int count = 0;
        
        while (count < countMax && !visible)
        {
          visible = CheckItem.checkVisible(elementInfo, 0);
          Thread.Sleep(checkPeriod);
          count++;
        }
      }
      else
      {
        Thread.Sleep(timeout.Milliseconds);
        visible = CheckItem.checkVisible(elementInfo, 0);
      }
      return visible;
    }
    
    /// <summary>
    /// Waits for an element to be hidden
    /// </summary>
    /// <param name="elementInfo">Repository Item Info of the element to check</param>
    /// <param name="timeout">How long I want to wait for the element to be hidden</param>
    /// <returns>true if the element is not visible</returns>
    public static bool WaitForElementHidden(RepoItemInfo elementInfo, Duration timeout)
    {
      bool visible = true;
      int checkPeriod = 500; // ms
      
      // if timeout is longer than a second then check periodically every checkPeriod ms
      if (timeout > 1000)
      {
        int countMax = timeout.Milliseconds / checkPeriod;
        int count = 0;
        
        while (count < countMax && visible)
        {
          visible = CheckItem.checkVisible(elementInfo, 0);
          Thread.Sleep(checkPeriod);
          count++;
        }
      }
      else
      {
        Thread.Sleep(timeout.Milliseconds);
        visible = CheckItem.checkVisible(elementInfo, 0);
      }
      return !visible;
    }
    
    /// <summary>
    /// Waits for an element to be enabled
    /// </summary>
    /// <param name="elementInfo">Repository Item Info of the element to check</param>
    /// <param name="timeout">How long I want to wait for the element to be enabled</param>
    /// <returns>true if the element is enabled</returns>
    public static bool WaitForElementEnabled(RepoItemInfo elementInfo, Duration timeout)
    {
      bool enabled = false;
      int checkPeriod = 500; // ms
      
      // if timeout is longer than a second then check periodically every checkPeriod ms
      if (timeout > 1000)
      {
        int countMax = timeout.Milliseconds / checkPeriod;
        int count = 0;
        
        while (count < countMax && !enabled)
        {
          enabled = CheckItem.checkEnabled(elementInfo, 0);
          Thread.Sleep(checkPeriod);
          count++;
        }
      }
      else
      {
        Thread.Sleep(timeout.Milliseconds);
        enabled = CheckItem.checkEnabled(elementInfo, 0);
      }
      return enabled;
    }
    
    /// <summary>
    /// Waits for an element to be disabled
    /// </summary>
    /// <param name="elementInfo">Repository Item Info of the element to check</param>
    /// <param name="timeout">How long I want to wait for the element to be disabled</param>
    /// <returns>true if the element is disabled</returns>
    public static bool WaitForElementDisabled(RepoItemInfo elementInfo, Duration timeout)
    {
      bool enabled = true;
      int checkPeriod = 500; // ms
      
      // if timeout is longer than a second then check periodically every checkPeriod ms
      if (timeout > 1000)
      {
        int countMax = timeout.Milliseconds / checkPeriod;
        int count = 0;
        
        while (count < countMax && enabled)
        {
          enabled = CheckItem.checkEnabled(elementInfo, 0);
          Thread.Sleep(checkPeriod);
          count++;
        }
      }
      else
      {
        Thread.Sleep(timeout.Milliseconds);
        enabled = CheckItem.checkEnabled(elementInfo, 0);
      }
      return !enabled;
    }
  }
}
