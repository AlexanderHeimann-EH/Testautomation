//using System.Linq;

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;
    using Ranorex.Core;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Provides validations methods which validate whether the module is ready or not
    /// </summary>
    public class IsModuleReady : MarshalByRefObject, IIsModuleReady
    {
        /// <summary>
        ///     Checks if module (online) is ready
        /// </summary>
        /// <param name="button">Button to check</param>
        /// <returns>
        ///     <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOnlineReady(Button button)
        {
            if (button != null)
            {
                return button.Enabled;
            }
            return false;
        }

        /// <summary>
        ///     Checks if module (offline) is ready
        /// </summary>
        /// <param name="button">Button to check</param>
        /// <returns>
        ///     <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOfflineReady(Button button)
        {
            if (button != null)
            {
                return button.Visible;
            }
            return false;
        }

        /// <summary>
        ///     Checks if module (online) is ready
        /// </summary>
        /// <param name="element">Element to check</param>
        /// <returns>
        ///     <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOnlineReady(Element element)
        {
            // EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Entered");
            if (element != null)
            {
                return element.Enabled;
            }
            return false;
        }


        // 2013-06-28 EC - Added in addition to function above
        /// <summary>
        ///     Checks if module (online) is ready
        /// </summary>
        /// <param name="adapter">Element to check</param>
        /// <returns>
        ///     <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOnlineReady(Adapter adapter)
        {
            // EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Entered");
            if (adapter != null)
            {
                return adapter.Enabled;
            }
            return false;
        }

        /// <summary>
        ///     Checks if module (offline) is ready
        /// </summary>
        /// <param name="element">Element to check</param>
        /// <returns>
        ///     <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOfflineReady(Element element)
        {
            if (element != null)
            {
                return element.Visible;
            }
            return false;
        }
    }
}