// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureCylindricalTankStanding.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ConfigureSphericalTank.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Linearization.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class ConfigureCylindricalTankStanding.
    /// </summary>
    public class ConfigureCylindricalTankStanding : IConfigureCylindricalTankStanding
    {
        /// <summary>
        /// Selects tank type 'cylindrical tank standing' and configures its parameter if needed. Use empty strings if you do not want to configure a parameter.
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
        /// <param name="ceilingType">
        /// The ceiling Type.
        /// </param>
        /// <param name="bottomType">
        /// The bottom Type.
        /// </param>
        /// <param name="wallThickness">
        /// The wall Thickness.
        /// </param>
        /// <param name="ceilingHeight">
        /// The ceiling Height.
        /// </param>
        /// <param name="ceilingWidth">
        /// The ceiling Width.
        /// </param>
        /// <param name="bottomHeight">
        /// The bottom Height.
        /// </param>
        /// <param name="bottomWidth">
        /// The bottom Width.
        /// </param>
        /// <returns>
        /// <c>true</c> if configuration was successful, <c>false</c> otherwise.
        /// </returns>
        public bool Run(string height, string diameter, string length, string ceilingType, string bottomType, string wallThickness, string ceilingHeight, string ceilingWidth, string bottomHeight, string bottomWidth)
        {
            bool result = Execution.SelectTab.Run(1);

            result &= Execution.SetTankType.Run("Cylindrical tank standing");
            if (this.IsValid(height))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankStandingHeight(height);                
                result &= AssertFunctions.AreEqual(height, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankStandingHeight(), "Checking whether the height has been set correctly.");
            }

            if (this.IsValid(diameter))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankStandingInternalDiameter(diameter);                
                result &= AssertFunctions.AreEqual(diameter, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankStandingInternalDiameter(), "Checking whether the diameter has been set correctly.");
            }

            if (this.IsValid(length))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankStandingLength(length);                
                result &= AssertFunctions.AreEqual(length, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankStandingLength(), "Checking whether the length has been set correctly.");
            }

            if (this.IsValid(ceilingType))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankStandingCeilingType(ceilingType);                
                result &= AssertFunctions.AreEqual(ceilingType, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankStandingCeilingType(), "Checking whether the ceilingType has been set correctly.");
            }

            if (this.IsValid(bottomType))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankStandingBottomType(bottomType);                
                result &= AssertFunctions.AreEqual(bottomType, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankStandingBottomType(), "Checking whether the bottomType has been set correctly.");
            }

            if (this.IsValid(wallThickness))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankStandingWallThickness(wallThickness);                
                result &= AssertFunctions.AreEqual(wallThickness, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankStandingWallThickness(), "Checking whether the wallThickness has been set correctly.");
            }

            if (this.IsValid(ceilingHeight))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankStandingCeilingHeight(ceilingHeight);                
                result &= AssertFunctions.AreEqual(ceilingHeight, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankStandingCeilingHeight(), "Checking whether the ceilingHeight has been set correctly.");
            }

            if (this.IsValid(ceilingWidth))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankStandingCeilingWidth(ceilingWidth);                
                result &= AssertFunctions.AreEqual(ceilingWidth, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankStandingCeilingWidth(), "Checking whether the ceilingWidth has been set correctly.");
            }

            if (this.IsValid(bottomHeight))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankStandingBottomHeight(bottomHeight);
                result &= AssertFunctions.AreEqual(bottomHeight, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankStandingBottomHeight(), "Checking whether the bottomHeight has been set correctly.");
            }

            if (this.IsValid(bottomWidth))
            {
                result &= Execution.ConfigureTankParameter.SetHorizontalCylindricalTankStandingBottomWidth(bottomWidth);                
                result &= AssertFunctions.AreEqual(bottomWidth, Execution.ConfigureTankParameter.GetHorizontalCylindricalTankStandingBottomWidth(), "Checking whether the bottomWidth has been set correctly.");
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