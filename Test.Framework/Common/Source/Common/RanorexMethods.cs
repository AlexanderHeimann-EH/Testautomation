//------------------------------------------------------------------------------
// <copyright file="RanorexMethods.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon, Guido
 * Date: ??.??.2011
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;
    using System.Threading;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;

    using DateTime = System.DateTime;

    /// <summary>
    ///     Contains Ranorext methods
    /// </summary>
    public class RanorexMethods
    {
        #region rxGetObject

        /// <summary>
        ///     Perform a safe Ranorex-Query to find a single Element
        /// </summary>
        /// <param name="xPath">Query RanoreXPath</param>
        /// <returns>The Element or Null</returns>
        public static Element rxGetObject(string xPath)
        {
            Element ret = rxGetObject(xPath, DefaultValues.iTimeoutShort, "");
            return ret;
        }

        /// <summary>
        ///     Perform a safe Ranorex-Query to find a single Element
        /// </summary>
        /// <param name="xPath">Query RanoreXPath</param>
        /// <param name="TimeOut">Timeout for the query</param>
        /// <returns>The Element or Null</returns>
        public static Element rxGetObject(string xPath, int TimeOut)
        {
            Element ret = rxGetObject(xPath, TimeOut, "");
            return ret;
        }

        /// <summary>
        ///     Perform a safe Ranorex-Query to find a single Element
        /// </summary>
        /// <param name="xPath">Query RanoreXPath</param>
        /// <param name="TimeOut">Timeout for the query</param>
        /// <param name="Comment">Some comment, which will be logged in the Ranorex-Log, if the Element fails.</param>
        /// <returns>The Element or Null</returns>
        public static Element rxGetObject(string xPath, int TimeOut, string Comment)
        {
            try
            {
                return Host.Local.FindSingle(xPath, new Duration(TimeOut));
            }
            catch (Exception excEeption)
            {
                //EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), excException.Message);
                if (Comment != "")
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Error in " + Comment);
                //Console.WriteLine("Error in " + Comment);
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Ranorex Object Recognition Error on path: " + xPath + "\r\nError: " + excEeption.Message);
                //Console.WriteLine("Ranorex Object Recognition Error on path: " + xPath + "\r\nError: " + excEeption.Message);
                return null;
            }
        }

        #endregion

        #region rxWaitForElement

        /// <summary>
        ///     Will wait for an object defined by the Xpath.
        /// </summary>
        /// <param name="xPath">Path definition for the object to find</param>
        /// <param name="singleTryTimeOut">inside wholeWaitTimeout there will be many tryfindsingle calls, using singleTryTimeOut as parameter. This ist useful, if the xpath contains attributes like enabled='true', which otherwise wont be updated</param>
        /// <param name="wholeWaitTimeout">The maximum wait time</param>
        /// <returns>True for found and false for not found</returns>
        public static bool rxWaitForElement(string xPath, int singleTryTimeOut, int wholeWaitTimeout)
        {
            DateTime start = DateTime.Now;
            Element element;
            bool isFound = false;
            while ((DateTime.Now - start).TotalMilliseconds < wholeWaitTimeout)
            {
                if (Host.Local.TryFindSingle(xPath, new Duration(singleTryTimeOut), out element))
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }

        /// <summary>
        ///     Will wait for an object defined by the Xpath.
        /// </summary>
        /// <param name="xPath">Path definition for the object to find</param>
        /// <param name="singleTryTimeOut">inside wholeWaitTimeout there will be many tryfindsingle calls, using singleTryTimeOut as parameter. This ist useful, if the xpath contains attributes like enabled='true', which otherwise wont be updated</param>
        /// <param name="wholeWaitTimeout">The maximum wait time</param>
        /// <param name="optional">if the waiting procedure is non-optional, it will raise an exception, if not found</param>
        /// <returns>True for found and false for not found</returns>
        public static bool rxWaitForElement(string xPath, int singleTryTimeOut, int wholeWaitTimeout, bool optional)
        {
            bool isFound = rxWaitForElement(xPath, singleTryTimeOut, wholeWaitTimeout);
            if (!isFound) RaiseNotFoundException(xPath);
            return isFound;
        }

        /// <summary>
        ///     Will wait for an object defined by the Xpath.
        /// </summary>
        /// <param name="xPath">Path definition for the object to find</param>
        /// <param name="singleTryTimeOut">inside wholeWaitTimeout there will be many tryfindsingle calls, using singleTryTimeOut as parameter. This ist useful, if the xpath contains attributes like enabled='true', which otherwise wont be updated</param>
        /// <param name="wholeWaitTimeout">The maximum wait time</param>
        /// <param name="foundElement">Out-Value for reusing the found element</param>
        /// <returns>True for found and false for not found</returns>
        public static bool rxWaitForElement(string xPath, int singleTryTimeOut, int wholeWaitTimeout,
                                            out Element foundElement)
        {
            DateTime start = DateTime.Now;
            bool isFound = false;
            foundElement = null;
            while ((DateTime.Now - start).TotalMilliseconds < wholeWaitTimeout)
            {
                if (Host.Local.TryFindSingle(xPath, new Duration(singleTryTimeOut), out foundElement))
                {
                    return true;
                }
            }
            return isFound;
        }

        /// <summary>
        ///     Will wait for an object defined by the Xpath.
        /// </summary>
        /// <param name="xPath">Path definition for the object to find</param>
        /// <param name="singleTryTimeOut">inside wholeWaitTimeout there will be many tryfindsingle calls, using singleTryTimeOut as parameter. This ist useful, if the xpath contains attributes like enabled='true', which otherwise wont be updated</param>
        /// <param name="wholeWaitTimeout">The maximum wait time</param>
        /// <param name="optional">if the waiting procedure is non-optional, it will raise an exception, if not found</param>
        /// <param name="foundElement">Out-Value for reusing the found element</param>
        /// <returns>True for found and false for not found</returns>
        public static bool rxWaitForElement(string xPath, int singleTryTimeOut, int wholeWaitTimeout, bool optional,
                                            out Element foundElement)
        {
            bool isFound = rxWaitForElement(xPath, singleTryTimeOut, wholeWaitTimeout, out foundElement);
            if (!isFound) RaiseNotFoundException(xPath);
            return isFound;
        }

        #endregion

        #region rxWaitUntilEnabled

        /// <summary>
        ///     The test will wait unitl the element in xPath is enabled.
        /// </summary>
        /// <param name="xPath">Path of the Element to find</param>
        /// <param name="maximumTimeout">the maximum waiting time</param>
        /// <param name="delay">a delay before the search begins, if fieldcare needs a few seconds to respond</param>
        /// <param name="optional">if the waiting procedure is non-optional, it will raise an exception, if not found</param>
        /// <returns>True if element found and enabled, false if not</returns>
        public static bool rxWaitUntilEnabled(string xPath, int maximumTimeout, int delay, bool optional)
        {
            Thread.Sleep(delay);
            return rxWaitUntilEnabled(xPath, maximumTimeout, optional);
        }

        /// <summary>
        ///     The test will wait unitl the element in xPath is enabled.
        /// </summary>
        /// <param name="xPath">Path of the Element to find</param>
        /// <param name="maximumTimeout">the maximum waiting time</param>
        /// <param name="optional">if the waiting procedure is non-optional, it will raise an exception, if not found</param>
        /// <returns>True if element found and enabled, false if not</returns>
        public static bool rxWaitUntilEnabled(string xPath, int maximumTimeout, bool optional)
        {
            DateTime start = DateTime.Now;

            do
            {
                Element el;
                if (Host.Local.TryFindSingle(xPath, new Duration(DefaultValues.iTimeoutLong), out el))
                {
                    if (el.Enabled) return true;
                }
            } while ((DateTime.Now - start).TotalMilliseconds <= maximumTimeout);

            if (!optional) RaiseNotFoundException(xPath);
            return false;
        }

        #endregion

        #region rxWaitUntilDisabled

        /// <summary>
        ///     The test will wait unitl the element in xPath is disabled.
        /// </summary>
        /// <param name="xPath">Path of the Element to find</param>
        /// <param name="maximumTimeout">the maximum waiting time</param>
        /// <param name="delay">a delay before the search begins, if fieldcare needs a few seconds to respond</param>
        /// <param name="optional">if the waiting procedure is non-optional, it will raise an exception, if not found</param>
        /// <returns>True if element found and disabled, false if not</returns>
        public static bool rxWaitUntilDisabled(string xPath, int maximumTimeout, int delay, bool optional)
        {
            Thread.Sleep(delay);
            return rxWaitUntilDisabled(xPath, maximumTimeout, optional);
        }

        /// <summary>
        ///     The test will wait unitl the element in xPath is disabled.
        /// </summary>
        /// <param name="xPath">Path of the Element to find</param>
        /// <param name="maximumTimeout">the maximum waiting time</param>
        /// <param name="optional">if the waiting procedure is non-optional, it will raise an exception, if not found</param>
        /// <returns>True if element found and disabled, false if not</returns>
        public static bool rxWaitUntilDisabled(string xPath, int maximumTimeout, bool optional)
        {
            DateTime start = DateTime.Now;

            do
            {
                Element el;
                if (Host.Local.TryFindSingle(xPath, new Duration(DefaultValues.iTimeoutLong), out el))
                {
                    if (!el.Enabled) return true;
                }
            } while ((DateTime.Now - start).TotalMilliseconds <= maximumTimeout);

            if (!optional) RaiseNotFoundException(xPath);
            return false;
        }

        #endregion

        #region rxWaitUntilVisible

        /// <summary>
        ///     The test will wait until the element in xPath is visible.
        /// </summary>
        /// <param name="xPath">Path of the Element to find</param>
        /// <param name="maximumTimeout">the maximum waiting time</param>
        /// <param name="delay">a delay before the search begins, if fieldcare needs a few seconds to respond</param>
        /// <param name="optional">if the waiting procedure is non-optional, it will raise an exception, if not found</param>
        /// <returns>True if element found and visible, false if not</returns>
        public static bool rxWaitUntilVisible(string xPath, int maximumTimeout, int delay, bool optional)
        {
            Thread.Sleep(delay);
            return rxWaitUntilVisible(xPath, maximumTimeout, optional);
        }

        /// <summary>
        ///     The test will wait until the element in xPath is visible.
        /// </summary>
        /// <param name="xPath">Path of the Element to find</param>
        /// <param name="maximumTimeout">the maximum waiting time</param>
        /// <param name="optional">if the waiting procedure is non-optional, it will raise an exception, if not found</param>
        /// <returns>True if element found and visible, false if not</returns>
        public static bool rxWaitUntilVisible(string xPath, int maximumTimeout, bool optional)
        {
            DateTime start = DateTime.Now;

            do
            {
                Element element = null;
                if (Host.Local.TryFindSingle(xPath, DefaultValues.iTimeoutLong, out element))
                {
                    if (element.Visible)
                    {
                        return true;
                    }
                }
            } while ((DateTime.Now - start).TotalMilliseconds <= maximumTimeout);

            if (!optional)
            {
                RaiseNotFoundException(xPath);
            }
            return false;
        }

        #endregion

        #region rxWaitUntilInvisible

        /// <summary>
        ///     The test will wait unitl the element in xPath is invisible.
        /// </summary>
        /// <param name="xPath">Path of the Element to find</param>
        /// <param name="maximumTimeout">the maximum waiting time</param>
        /// <param name="delay">a delay before the search begins, if fieldcare needs a few seconds to respond</param>
        /// <param name="optional">if the waiting procedure is non-optional, it will raise an exception, if not found</param>
        /// <returns>True if element found and invisible, false if not</returns>
        public static bool rxWaitUntilInvisible(string xPath, int maximumTimeout, int delay, bool optional)
        {
            Thread.Sleep(delay);
            return rxWaitUntilInvisible(xPath, maximumTimeout, optional);
        }

        /// <summary>
        ///     The test will wait unitl the element in xPath is invisible.
        /// </summary>
        /// <param name="xPath">Path of the Element to find</param>
        /// <param name="maximumTimeout">the maximum waiting time</param>
        /// <param name="optional">if the waiting procedure is non-optional, it will raise an exception, if not found</param>
        /// <returns>True if element found and invisible, false if not</returns>
        public static bool rxWaitUntilInvisible(string xPath, int maximumTimeout, bool optional)
        {
            DateTime start = DateTime.Now;

            do
            {
                Element element = null;
                if (Host.Local.TryFindSingle(xPath, new Duration(DefaultValues.iTimeoutLong), out element))
                {
                    if (!element.Visible)
                    {
                        return true;
                    }
                }
            } while ((DateTime.Now - start).TotalMilliseconds <= maximumTimeout);

            if (!optional)
            {
                RaiseNotFoundException(xPath);
            }
            return false;
        }

        #endregion

        #region WaitUntilElementNulls

        /// <summary>
        ///     Waits until an element is gone and cannot be found in xpath anymore
        /// </summary>
        /// <param name="xPath">The elements xpath</param>
        /// <param name="maximumTimeout">maximum waiting timeout</param>
        public static void waitUntilElementNulls(string xPath, int maximumTimeout)
        {
            DateTime start = DateTime.Now;

            do
            {
                Element el;
                if (!Host.Local.TryFindSingle(xPath, new Duration(DefaultValues.iTimeoutShort), out el))
                {
                    return;
                }
            } while ((DateTime.Now - start).TotalMilliseconds <= maximumTimeout);
            return;
        }

        #endregion

        #region RaiseNotFoundException

        /// <summary>
        ///     Private helper function to raise exceptions
        /// </summary>
        private static void RaiseNotFoundException()
        {
            throw new Exception("Non-Optional waiting for an Element failed");
        }

        /// <summary>
        ///     Private helper function to raise exceptions
        /// </summary>
        private static void RaiseNotFoundException(string xPath)
        {
            throw new Exception("Non-Optional waiting for an Element failed at path: " + xPath);
        }

        #endregion

        /// <summary>
        ///     Searchs an specific bitmap at all toolbar-elements.
        /// </summary>
        /// <param name="iconName">Name of icon to search for</param>
        /// <param name="pathToToolbarButtons">Path to icon</param>
        /// <returns>
        ///     <br>Button: If icon found</br>
        ///     <br>Null: If no icon found</br>
        /// </returns>
        public static Button SearchIcon(Bitmap iconName, string pathToToolbarButtons)
        {
            try
            {
                Imaging.FindOptions.Default.BestMatch = false;
                Imaging.FindOptions.Default.Similarity = 1.0;
                Imaging.FindOptions.Default.Preprocessing = Imaging.Preprocessings.None;

                IList<Element> buttons = new List<Element>();
                buttons = Host.Local.Find(pathToToolbarButtons, DefaultValues.GeneralTimeout);
                Button found = null;

                foreach (Button button in buttons)
                {
                    if (Imaging.Contains(button, iconName, Imaging.FindOptions.Default))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Icon is found.");
                        found = button;
                        found.MoveTo();
                        break;
                    }
                }
                return found;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        ///     Searchs an specific bitmap at a specific toolbar-element.
        /// </summary>
        /// <param name="iconName">Name of icon to search for</param>
        /// <param name="ranorexPath">Ranorex path for button to proof</param>
        /// <returns>
        ///     <br>Button: If button related icon found</br>
        ///     <br>Null: If no button related icon found</br>
        /// </returns>
        public static Button GetButtonWithIcon(Bitmap iconName, string ranorexPath)
        {
            Imaging.FindOptions.Default.BestMatch = false;
            Imaging.FindOptions.Default.Similarity = 1.0;
            Imaging.FindOptions.Default.Preprocessing = Imaging.Preprocessings.None;

            Button button = null;
            if (Host.Local.TryFindSingle(ranorexPath, DefaultValues.GeneralTimeout, out button))
            {
                if (!Imaging.Contains(button, iconName, Imaging.FindOptions.Default))
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Screenshot();
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Icon is not found.");
                    button = null;
                }
            }
            else
            {
                button = null;
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessable.");
            }
            return button;
        }
    }
}