// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetTableValues.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class SetTableValues.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Viscosity.Functions.ApplicationArea.MainView.Execution
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Viscosity.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    /// Class SetTableValues.
    /// </summary>
    public class SetTableValues : ISetTableValues
    {
        #region Public Methods and Operators

        /// <summary>
        /// Sets all table values provided from a list.
        /// </summary>
        /// <param name="inputValues">
        /// The input values.
        /// </param>
        /// <returns>
        /// <c>true</c> if values have been set, <c>false</c> otherwise.
        /// </returns>
        public bool SetValues(List<string> inputValues)
        {
            if (inputValues != null)
            {
                if (inputValues.Count > 0)
                {
                    if (inputValues.Count % 2 != 0)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Your list has an odd number of values. Please use an even number of values.");
                        return false;
                    }

                    // Cell firstCell = new FluidPropertiesElements().TableCell(0, 0);
                    Ranorex.Core.Element firstCell = new FluidPropertiesElements().TableCell(0, 0);

                    if (firstCell != null)
                    {
                        Mouse.MoveTo(firstCell, new Location(20, 5), 500);
                        Mouse.DoubleClick();

                        for (int counter = 0; counter < inputValues.Count / 2; counter++)
                        {
                            Keyboard.Press(inputValues[counter * 2]);
                            Keyboard.Press(Keys.Down);
                            Thread.Sleep(500);
                        }

                        Keyboard.Press(Keys.Right);

                        for (int i = 0; i < inputValues.Count / 2; i++)
                        {
                            Keyboard.Press(Keys.Up);
                            Thread.Sleep(500);
                        }

                        for (int counter = 0; counter < inputValues.Count / 2; counter++)
                        {
                            Keyboard.Press(inputValues[(counter * 2) + 1]);
                            Keyboard.Press(Keys.Down);
                            Thread.Sleep(500);
                        }

                        Keyboard.Press(Keys.Up);
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Table not found");
                    return false;
                    }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Number of input values is 0");
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No input values available");
            return false;
        }

        #endregion

        ////public bool SetValues(List<string> inputValues)
        ////{
        ////    if (inputValues.Count % 2 != 0)
        ////    {
        ////        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Your list has an odd number of values. Please use an even number of values.");
        ////        return false;
        ////    }

        ////    Cell firstCell = new FluidPropertiesElements().TableCell(0, 0);
        ////    firstCell.Click(500);

        ////    for (int counter = 0; counter < inputValues.Count / 2; counter++)
        ////    {
        ////        Keyboard.Press(inputValues[(counter * 2)]);
        ////        Keyboard.Press(Keys.Down);
        ////    }

        ////    Cell secondCell = new FluidPropertiesElements().TableCell(0, 1);
        ////    secondCell.Click(500);

        ////    for (int counter = 0; counter < inputValues.Count / 2; counter++)
        ////    {
        ////        Keyboard.Press(inputValues[(counter * 2) + 1]);
        ////        Keyboard.Press(Keys.Down);
        ////    }

        ////    Keyboard.Press(Keys.Up);

        ////    return true;
        ////}
    }
}