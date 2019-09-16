// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureHorizontalCylindricalTank.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ConfigureSphericalTank.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Linearization.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class ConfigureHorizontalCylindricalTank.
    /// </summary>
    public class ConfigureHorizontalCylindricalTank : IConfigureHorizontalCylindricalTank
    {
        /// <summary>
        /// Selects tank type 'Horizontal cylindrical tank' and configures its parameter if needed. Use empty strings if you do not want to configure a parameter.
        /// </summary>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <param name="diameter">
        /// The diameter.
        /// </param>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <param name="angle">
        /// The angle.
        /// </param>
        /// <param name="endTypeRight">
        /// The end Type Right.
        /// </param>
        /// <param name="endTypeLeft">
        /// The end Type Left.
        /// </param>
        /// <param name="wallThickness">
        /// The wall Thickness.
        /// </param>
        /// <param name="changePosition">
        /// The change Position.
        /// </param>
        /// <returns>
        /// <c>true</c> if configuration was successful, <c>false</c> otherwise.
        /// </returns>
        public bool Run(string height, string diameter, string length, string angle, string endTypeRight, string endTypeLeft, string wallThickness, string changePosition)
        {
            bool result = Execution.SelectTab.Run(1);

            result &= Execution.SetTankType.Run("Horizontal cylindrical tank");
            if (this.IsValid(height))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankHeight(height);                
                result &= AssertFunctions.AreEqual(height, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankHeight() , "Checking whether the height has been set correctly.");
            }

            if (this.IsValid(diameter))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankDiameter(diameter);                
                result &= AssertFunctions.AreEqual(diameter, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankDiameter(), "Checking whether the diameter has been set correctly.");
            }

            if (this.IsValid(length))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankLength(length);                
                result &= AssertFunctions.AreEqual(length, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankLength(), "Checking whether the length has been set correctly.");
            }

            if (this.IsValid(angle))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankAngle(angle);                
                result &= AssertFunctions.AreEqual(angle, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankAngle(), "Checking whether the angle has been set correctly.");
            }

            if (this.IsValid(endTypeRight))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankEndTypeRight(endTypeRight);               
                result &= AssertFunctions.AreEqual(endTypeRight, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankEndTypeRight(), "Checking whether the endTypeRight has been set correctly.");
            }

            if (this.IsValid(endTypeLeft))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankEndTypeLeft(endTypeLeft);                
                result &= AssertFunctions.AreEqual(endTypeLeft, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankEndTypeLeft(), "Checking whether the endTypeLeft has been set correctly.");
            }

            if (this.IsValid(wallThickness))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankWallThickness(wallThickness);                
                result &= AssertFunctions.AreEqual(wallThickness, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankWallThickness(), "Checking whether the wallThickness has been set correctly.");
            }

            if (this.IsValid(changePosition))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankChangePosition(changePosition);                
                result &= AssertFunctions.AreEqual(changePosition, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankChangePosition(), "Checking whether the changePosition has been set correctly.");
            }

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring finished successfully.");
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occurred during configuring.");
            }

            return result;
        }

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsValid(string value)
        {
            if (value.Length > 0 && !value.Equals(" "))
            {
                return true;
            }

            return false;
        }
    }
}