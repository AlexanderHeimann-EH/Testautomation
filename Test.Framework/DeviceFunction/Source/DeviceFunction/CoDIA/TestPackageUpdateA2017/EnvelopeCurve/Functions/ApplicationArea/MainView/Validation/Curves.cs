//------------------------------------------------------------------------------
// <copyright file="Curves.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.GUI.MenuArea.Menubar;

    using Ranorex;

    /// <summary>
    /// Validation methods for all curve related actions
    /// </summary>
    public class Curves : ICurves
    {
        /// <summary>
        /// Checks if specified curve is selectable
        /// </summary>
        /// <param name="cursorId">Cursor ID (1 or 2)</param>
        /// <param name="curveType">Ranorex path to menu entry</param>
        /// <returns>
        ///     <br>True: if curve is selectable</br>
        ///     <br>False: if curve is not selectable</br>
        /// </returns>
        public bool IsCurveSelectable(int cursorId, string curveType)
        {
            bool isSelectable = false;
            switch (cursorId)
            {
                case 1:
                    if ((new RunCursor1()).ViaMenu() != null)
                    {
                        isSelectable = this.CheckCurve(curveType);
                    }

                    break;
                case 2:
                    if ((new RunCursor2()).ViaMenu() != null)
                    {
                        isSelectable = this.CheckCurve(curveType);
                    }

                    break;
                default:
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Invalid cursor ID. ID must be 1 or 2.");
                    break;
            }

            return isSelectable;
        }

        /// <summary>
        /// Checks if specified curves are selectable
        /// </summary>
        /// <param name="cursorId">Cursor ID (1 or 2)</param>
        /// <param name="curveType">Array of ranorex paths to menu entries</param>
        /// <returns>
        ///     <br>True: if curve is selectable</br>
        ///     <br>False: if curve is not selectable</br>
        /// </returns>
        public bool IsCurveSelectable(int cursorId, string[] curveType)
        {
            bool areSelectable = false;
            switch (cursorId)
            {
                case 1:
                    if ((new RunCursor1()).ViaMenu() != null)
                    {
                        areSelectable = this.CheckCurves(curveType);
                    }

                    break;
                case 2:
                    if ((new RunCursor2()).ViaMenu() != null)
                    {
                        areSelectable = this.CheckCurves(curveType);
                    }

                    break;
                default:
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Invalid cursor ID. ID must be 1 or 2.");
                    break;
            }
            return areSelectable;
        }

        /// <summary>
        /// Checks if specified curves are selectable
        /// </summary>
        /// <param name="cursorId">Cursor ID (1 or 2)</param>
        /// <param name="curveType">List with CurveType Enumeration</param>
        /// <returns>
        ///     <br>True: if curve is selectable</br>
        ///     <br>False: if curve is not selectable</br>
        /// </returns>
        public bool IsCurveSelectable(int cursorId, List<CurveType> curveType)
        {
            bool areSelectable = false;
            switch (cursorId)
            {
                case 1:
                    if ((new RunCursor1()).ViaMenu() != null)
                    {
                        areSelectable = this.CheckCurves(curveType);
                    }

                    break;
                case 2:
                    if ((new RunCursor2()).ViaMenu() != null)
                    {
                        areSelectable = this.CheckCurves(curveType);
                    }

                    break;
                default:
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Invalid cursor ID. ID must be 1 or 2.");
                    break;
            }

            return areSelectable;
        }

        /// <summary>
        ///     Checks if specified curve is selectable
        /// </summary>
        /// <param name="cursorId">Cursor ID (1 or 2)</param>
        /// <param name="curveType">Ranorex path to menu entry</param>
        /// <returns>
        ///     <br>True: if curve is selectable</br>
        ///     <br>False: if curve is not selectable</br>
        /// </returns>
        public bool IsCurveSelectable(int cursorId, CurveType curveType)
        {
            bool isSelectable = false;
            switch (cursorId)
            {
                case 1:
                    if ((new RunCursor1()).ViaMenu() != null)
                    {
                        isSelectable = this.CheckCurve(curveType);
                    }

                    break;
                case 2:
                    if ((new RunCursor2()).ViaMenu() != null)
                    {
                        isSelectable = this.CheckCurve(curveType);
                    }

                    break;
                default:
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Invalid cursor ID. ID must be 1 or 2.");
                    break;
            }

            return isSelectable;
        }

        /// <summary>
        /// Check if menu entries for curves are selectable
        /// </summary>
        /// <param name="curveType">Array of Ranorex paths to menu entries</param>
        /// <returns>
        ///     <br>True: if curve menu entry are selectable</br>
        ///     <br>False: if curve menu entry are not selectable</br>
        /// </returns>
        private bool CheckCurves(string[] curveType)
        {
            bool result = true;
            foreach (string curve in curveType)
            {
                result &= this.CheckCurve(curve);
            }

            return result;
        }

        /// <summary>
        /// Check if menu entries for curves are selectable
        /// </summary>
        /// <param name="curveType">Array of Ranorex paths to menu entries</param>
        /// <returns>
        ///     <br>True: if curve menu entry are selectable</br>
        ///     <br>False: if curve menu entry are not selectable</br>
        /// </returns>
        private bool CheckCurves(List<CurveType> curveType)
        {
            bool result = true;
            foreach (CurveType curve in curveType)
            {
                result &= this.CheckCurve(curve);
            }

            return result;
        }

        /// <summary>
        /// Check if menu entry for curve is selectable
        /// </summary>
        /// <param name="curveType">Ranorex path to menu entry</param>
        /// <returns>
        ///     <br>True: if curve menu entry is selectable</br>
        ///     <br>False: if curve menu entry is not selectable</br>
        /// </returns>
        private bool CheckCurve(string curveType)
        {
            try
            {
                Button button;
                if (Host.Local.TryFindSingle(curveType, DefaultValues.iTimeoutShort, out button))
                {
                    if (button.Enabled)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curveType + "] could be selected.");
                        button.MoveTo();
                        return true;
                    }

                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curveType + "] not selectable.");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Check if menu entry for curve is selectable
        /// </summary>
        /// <param name="curve">Enumeration for curve</param>
        /// <returns>
        ///     <br>True: if curve menu entry is selectable</br>
        ///     <br>False: if curve menu entry is not selectable</br>
        /// </returns>
        private bool CheckCurve(CurveType curve)
        {
            switch (curve)
            {
                    #region Editable Map

                case CurveType.EditableMap:
                    {
                        Button button = new Elements().EntryEditableMAP;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                    #region Envelope Curve

                case CurveType.EnvelopeCurve:
                    {
                        Button button = new Elements().EntryEnvelopeCurve;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                    #region First Echo Curve

                case CurveType.FirstEchoCurve:
                    {
                        Button button = new Elements().EntryFirstEchoCurve;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                    #region Free

                case CurveType.Free:
                    {
                        Button button = new Elements().EntryFree;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                    #region Ideal Echo Curve

                case CurveType.IdealEchoCurve:
                    {
                        Button button = new Elements().EntryIdealEcho;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                    #region Ideal Echo from File        	

                case CurveType.IdealEchoFromFile:
                    {
                        Button button = new Elements().EntryIdealEchoFromFile;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                    #region Map

                case CurveType.Map:
                    {
                        Button button = new Elements().EntryMAP;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                    #region Raw Envelope Curve

                case CurveType.RawEnvelopeCurve:
                    {
                        Button button = new Elements().EntryRawEnvelopeCurve;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                    #region Reference Curve	

                case CurveType.ReferenceCurve:
                    {
                        Button button = new Elements().EntryReferenceCurve;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                    #region Threshold GPC

                case CurveType.ThresholdGpc:
                    {
                        Button button = new Elements().EntryThresholdGasPhaseCompensation;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                    #region Threshold Tank Bottom

                case CurveType.ThresholdTankBottom:
                    {
                        Button button = new Elements().EntryThresholdTankBottom;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                    #region Weighting Curve	

                case CurveType.WeightingCurve:
                    {
                        Button button = new Elements().EntryWeightingCurve;
                        if (button.Enabled)
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "CurveType [" + curve.ToString() + "] could be selected.");
                            button.MoveTo();
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                        return false;
                    }

                    #endregion

                default:
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry does not exist");
                        return false;
                    }
            }
        }
    }
}