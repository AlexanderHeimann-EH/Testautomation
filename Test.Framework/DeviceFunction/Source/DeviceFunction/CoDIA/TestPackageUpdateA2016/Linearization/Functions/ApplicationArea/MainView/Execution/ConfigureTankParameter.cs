// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureTankParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ConfigureTankParameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Class ConfigureTankParameter.
    /// </summary>
    public class ConfigureTankParameter : IConfigureTankParameter
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the horizontal cylindrical tank angle.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankAngle()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldAngle;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldAngle is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank change position.
        /// </summary>
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankChangePosition()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldChangePosition;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldChangePosition is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank diameter.
        /// </summary>       
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankDiameter()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldDiameter;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldDiameter is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank empty.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankEmpty()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldEmpty;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldEmpty is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank end type left.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankEndTypeLeft()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardComboBoxEndTypeLeft;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardComboBoxEndTypeLeft is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank end type right.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankEndTypeRight()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardComboBoxEndTypeRight;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardComboBoxEndTypeRight is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank full.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankFull()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldFull;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldFull is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the height of the horizontal cylindrical tank.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankHeight()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldHeight;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldHeight is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the length of the horizontal cylindrical tank.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankLength()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldLength;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldLength is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the height of the horizontal cylindrical tank standing bottom.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingBottomHeight()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldBottomHeight;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldBottomHeight is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the type of the horizontal cylindrical tank standing bottom.
        /// </summary>
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingBottomType()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingComboBoxBottomType;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingComboBoxBottomType is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the width of the horizontal cylindrical tank standing bottom.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingBottomWidth()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldBottomWidth;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldBottomWidth is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the height of the horizontal cylindrical tank standing ceiling.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingCeilingHeight()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldCeilingHeight;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldCeilingHeight is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the type of the horizontal cylindrical tank standing ceiling.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingCeilingType()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingComboBoxCeilingType;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingComboBoxCeilingType is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the width of the horizontal cylindrical tank standing ceiling.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingCeilingWidth()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldCeilingWidth;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldCeilingWidth is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standing empty.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingEmpty()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldEmpty;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldEmpty is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standing full.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingFull()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldFull;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldFull is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the height of the horizontal cylindrical tank standing.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingHeight()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldHeight;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingHeight is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standing internal diameter.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingInternalDiameter()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldInternalDiameter;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldInternalDiameter is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the length of the horizontal cylindrical tank standing.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingLength()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldLength;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldLength is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standing wall thickness.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankStandingWallThickness()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldWallThickness;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldWallThickness is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the horizontal cylindrical tank standard wall thickness.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetHorizontalCylindricalTankWallThickness()
        {
            string result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldWallThickness;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldWallThickness is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the modular tank circular empty.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetModularTankCircularEmpty()
        {
            string result;
            Element element = new TankTabElements().ModularTankCircularEditFieldEmpty;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankCircularEditFieldEmpty is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the modular tank circular full.
        /// </summary>
        /// <returns>Text value.</returns>
        public string GetModularTankCircularFull()
        {
            string result;
            Element element = new TankTabElements().ModularTankCircularEditFieldFull;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankCircularEditFieldFull is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the height of the modular tank circular.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetModularTankCircularHeight()
        {
            string result;
            Element element = new TankTabElements().ModularTankCircularEditFieldHeight;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankCircularEditFieldHeight is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the modular tank empty.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetModularTankEmpty()
        {
            string result;
            Element element = new TankTabElements().ModularTankStandardEditFieldEmpty;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankStandardEditFieldEmpty is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the modular tank full.
        /// </summary>        
        /// <returns>Text value</returns>
        public string GetModularTankFull()
        {
            string result;
            Element element = new TankTabElements().ModularTankStandardEditFieldFull;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankStandardEditFieldFull is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the height of the modular tank.
        /// </summary>
        /// <returns>Text value.</returns>
        public string GetModularTankHeight()
        {
            string result;
            Element element = new TankTabElements().ModularTankStandardEditFieldHeight;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankStandardEditFieldHeight is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the modular tank view.
        /// </summary>
        /// <returns>Text value.</returns>
        public string GetModularTankView()
        {
            string result;
            Element element = new TankTabElements().ModularTankStandardComboBoxView;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankStandardComboBoxView is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the spherical tank diameter.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetSphericalTankDiameter()
        {
            string result;
            Element element = new TankTabElements().SphericalTankStandardEditFieldDiameter;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SphericalTankStandardEditFieldDiameter is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the spherical tank empty.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetSphericalTankEmpty()
        {
            string result;
            Element element = new TankTabElements().SphericalTankStandardEditFieldEmpty;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SphericalTankStandardEditFieldEmpty is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the spherical tank full.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetSphericalTankFull()
        {
            string result;
            Element element = new TankTabElements().SphericalTankStandardEditFieldFull;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SphericalTankStandardEditFieldFull is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Gets the height of the spherical tank.
        /// </summary>        
        /// <returns>Text value.</returns>
        public string GetSphericalTankHeight()
        {
            string result;
            Element element = new TankTabElements().SphericalTankStandardEditFieldHeight;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SphericalTankStandardEditFieldHeight is null");
            }
            else
            {
                result = new EditParameter().GetParameterValue(element);
            }

            return result;
        }

        /// <summary>
        /// Sets the horizontal cylindrical tank angle.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankAngle(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldAngle;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldAngle is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankAngle will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the horizontal cylindrical tank change position.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankChangePosition(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldChangePosition;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldChangePosition is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankChangePosition will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the horizontal cylindrical tank diameter.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankDiameter(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldDiameter;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldDiameter is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankDiameter will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the horizontal cylindrical tank end type left.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankEndTypeLeft(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardComboBoxEndTypeLeft;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardComboBoxEndTypeLeft is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankTypeLeft will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the horizontal cylindrical tank end type right.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankEndTypeRight(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardComboBoxEndTypeRight;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardComboBoxEndTypeRight is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankEndTypeRight will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the height of the horizontal cylindrical tank.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankHeight(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldHeight;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldDiameter is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankHeight will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the height of the horizontal cylindrical tank.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankLength(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldLength;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldLength is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankLength will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the height of the horizontal cylindrical tank standing bottom.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankStandingBottomHeight(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldBottomHeight;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldBottomHeight is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingBottomHeight will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the type of the horizontal cylindrical tank standing bottom.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankStandingBottomType(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingComboBoxBottomType;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingComboBoxBottomType is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingBottomType will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the width of the horizontal cylindrical tank standing bottom.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankStandingBottomWidth(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldBottomWidth;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldBottomWidth is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingBottomWidth will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the height of the horizontal cylindrical tank standing ceiling.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankStandingCeilingHeight(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldCeilingHeight;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldCeilingHeight is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingCeilingHeight will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the type of the horizontal cylindrical tank standing ceiling.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankStandingCeilingType(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingComboBoxCeilingType;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingComboBoxCeilingType is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingCeilingType will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the Width of the horizontal cylindrical tank standing ceiling.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankStandingCeilingWidth(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldCeilingWidth;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldCeilingWidth is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingCeilingWidth will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the height of the horizontal cylindrical tank standing.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankStandingHeight(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldHeight;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldHeight is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingHeight will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the horizontal cylindrical tank standing internal diameter.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankStandingInternalDiameter(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldInternalDiameter;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldInternalDiameter is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingInternalDiameter will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the horizontal cylindrical tank standing internal diameter.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankStandingLength(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldLength;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldLength is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingLength will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the horizontal cylindrical tank standing wall thickness.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankStandingWallThickness(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandingEditFieldWallThickness;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingEditFieldWallThickness is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandingWallThickness will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the height of the horizontal cylindrical tank.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetHorizontalCylindricalTankWallThickness(string value)
        {
            bool result;
            Element element = new TankTabElements().HorizontalCylindricalTankStandardEditFieldWallThickness;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardEditFieldWallThickness is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HorizontalCylindricalTankStandardWallThickness will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the height of the modular tank circular.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetModularTankCircularHeight(string value)
        {
            bool result;
            Element element = new TankTabElements().ModularTankCircularEditFieldHeight;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankCircularEditFieldHeight is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankCircularHeight will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the height of the modular tank.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetModularTankHeight(string value)
        {
            bool result;
            Element element = new TankTabElements().ModularTankStandardEditFieldHeight;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankStandardEditFieldHeight is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankHeight will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the modular tank view.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetModularTankView(string value)
        {
            bool result;
            Element element = new TankTabElements().ModularTankStandardComboBoxView;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankStandardComboBoxView is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ModularTankView will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the spherical tank diameter.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetSphericalTankDiameter(string value)
        {
            bool result;
            Element element = new TankTabElements().SphericalTankStandardEditFieldDiameter;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SphericalTankStandardEditFieldDiameter is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SphericalTankDiameter will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        /// <summary>
        /// Sets the height of the spherical tank.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> if set, <c>false</c> otherwise.
        /// </returns>
        public bool SetSphericalTankHeight(string value)
        {
            bool result;
            Element element = new TankTabElements().SphericalTankStandardEditFieldHeight;
            if (element == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SphericalTankStandardEditFieldHeight is null");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SphericalTankHeight will be set to: " + value);
                result = new EditParameter().SetParameterValue(element, value);
            }

            return result;
        }

        #endregion

        // TODO : Hydrostatic Spherical Tank + all Interfaces and Loader
    }
}