// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetTableValues.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class SetTableValues.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.ApplicationArea.MainView.Execution
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    /// Class SetTableValues.
    /// </summary>
    public class SetTableValues : ISetTableValues
    {
        ///// <summary>
        ///// Sets all table values provided from a list.
        ///// </summary>
        ///// <param name="inputValues">
        ///// The input values.
        ///// </param>
        ///// <returns>
        ///// <c>true</c> if values have been set, <c>false</c> otherwise.
        ///// </returns>
        ////public bool SetValues(List<string> inputValues)
        ////{
        ////    if (inputValues.Count % 3 != 0)
        ////    {
        ////        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Your list has an odd number of values. Please use an even number of values.");
        ////        return false;
        ////    }

        ////    Cell firstCell = new LiquidPropertiesElements().TableCell(0, 0);
        ////    firstCell.Click(500);
        ////    int firstX = Mouse.Position.X;
        ////    int firstY = Mouse.Position.Y;

        ////    Cell secondCell = new LiquidPropertiesElements().TableCell(0, 1);
        ////    secondCell.Click(500);
        ////    int secondX = Mouse.Position.X;
        ////    int secondY = Mouse.Position.Y;

        ////    Cell thirdCell = new LiquidPropertiesElements().TableCell(0, 2);
        ////    thirdCell.Click(500);
        ////    int thirdX = Mouse.Position.X;
        ////    int thirdY = Mouse.Position.Y;

        ////    Mouse.MoveTo(firstX, firstY, 500);
        ////    Mouse.Click();

        ////    for (int counter = 0; counter < inputValues.Count / 3; counter++)
        ////    {
        ////        Keyboard.Press(inputValues[(counter * 3)]);
        ////        Keyboard.Press(Keys.Down);
        ////        if (counter > 7)
        ////        {
        ////            Keyboard.Press(Keys.Down);
        ////        }
        ////    }

        ////    Mouse.MoveTo(secondX, secondY, 500);
        ////    Mouse.Click();

        ////    for (int counter = 0; counter < inputValues.Count / 3; counter++)
        ////    {
        ////        Keyboard.Press(inputValues[(counter * 3) + 1]);
        ////        Keyboard.Press(Keys.Down);
        ////    }

        ////    Mouse.MoveTo(thirdX, thirdY, 500);
        ////    Mouse.Click();

        ////    for (int counter = 0; counter < inputValues.Count / 3; counter++)
        ////    {
        ////        Keyboard.Press(inputValues[(counter * 3) + 2]);
        ////        Keyboard.Press(Keys.Down);
        ////    }

        ////    Keyboard.Press(Keys.Up);

        ////    return true;
        ////}
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
                    if (inputValues.Count % 3 != 0)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Your list has an odd number of values. Please use an even number of values.");
                        return false;
                    }

                    Ranorex.Core.Element firstCell = new LiquidPropertiesElements().TableCell(0, 0);

                    if (firstCell != null)
                    {
                        Mouse.MoveTo(firstCell, new Location(20, 5), 500);
                        Mouse.DoubleClick();

                        for (int counter = 0; counter < inputValues.Count / 3; counter++)
                        {
                            Keyboard.Press(inputValues[counter * 3]);

                            // 2017-09-27 - EC: Workaround um das Tabellenhandlich zu kompensieren. 
                            Keyboard.Press(Keys.Down);
                            Thread.Sleep(500);
                        }

                        Keyboard.Press(Keys.Right);

                        for (int i = 0; i < inputValues.Count / 3; i++)
                        {
                            Keyboard.Press(Keys.Up);
                            Thread.Sleep(200);
                        }

                        for (int counter = 0; counter < inputValues.Count / 3; counter++)
                        {
                            Keyboard.Press(inputValues[(counter * 3) + 1]);
                            Keyboard.Press(Keys.Down);
                            Thread.Sleep(200);
                        }

                        Keyboard.Press(Keys.Right);

                        for (int i = 0; i < inputValues.Count / 3; i++)
                        {
                            Keyboard.Press(Keys.Up);
                            Thread.Sleep(200);
                        }

                        for (int counter = 0; counter < inputValues.Count / 3; counter++)
                        {
                            Keyboard.Press(inputValues[(counter * 3) + 2]);
                            Keyboard.Press(Keys.Down);
                            Thread.Sleep(200);
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
    }
}