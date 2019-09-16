// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DragAndDropParameterIntoHeader.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class DragAndDropParameterIntoHeader.
    /// </summary>
    public class DragAndDropParameterIntoHeader : IDragAndDropParameterIntoHeader
    {
        #region Public Methods and Operators

        /// <summary>
        /// Runs the specified item identifier.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns><c>true</c> if executed, <c>false</c> otherwise.</returns>
        public bool Run(string itemId, string source, string destination)
        {
            bool result = false;

            if (AppComController.Controller != null)
            {
                //var eventHandler = new DisplayContentEventHandler(AppComController.Controller);
                var oldDisplayContent = AppComController.GetDisplayContent();
                AppComController.Controller.DragAndDrop(itemId, source, destination);

                //if (eventHandler.WaitForNewDisplayContent(15000).Result)
                if(DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation.WaitForDisplayContentChanged.Run(oldDisplayContent, 15000))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Recognized display content update. Drag and drop successful.");
                    result = true;
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No display content update. Drag and drop not successful.");                    
                }
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Remote host not connected! Please establish a connection first.");                
            }

            return result;
        }

        #endregion
    }
}