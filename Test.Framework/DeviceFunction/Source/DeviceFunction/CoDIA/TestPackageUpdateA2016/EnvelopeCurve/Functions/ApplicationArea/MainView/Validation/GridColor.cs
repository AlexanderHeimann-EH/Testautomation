//------------------------------------------------------------------------------
// <copyright file="GridColor.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 10/23/2013
 * Time: 1:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.EnvelopeCurve.GUI.ApplicationArea.MainView;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Validation methods for Grid Colors
    /// </summary>
    public class GridColor : MarshalByRefObject, IGridColor
    {
        /// <summary>
        ///     Visually compared the background color of the curve area, to tell if it is green
        /// </summary>
        /// <returns>
        ///     <br>True: if grid is green</br>
        ///     <br>False: if grid is not green</br>
        /// </returns>
        public bool IsGridGreen()
        {
            Imaging.FindOptions.Default.BestMatch = false;
            Imaging.FindOptions.Default.Similarity = 1.0;
            Imaging.FindOptions.Default.Preprocessing = Imaging.Preprocessings.None;

            Container area = (new DiagramElements()).CurveArea;

            bool returnValue = Imaging.Contains(area, (new DiagramElements()).GridGreen, Imaging.FindOptions.Default);
            // TODO: to be deleted
            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), returnValue.ToString());

            return returnValue;
        }

        /// <summary>
        ///     Visually compared the background color of the curve area, to tell if it is yellow
        /// </summary>
        /// <returns>
        ///     <br>True: if grid is yellow</br>
        ///     <br>False: if grid is not yellow</br>
        /// </returns>
        public bool IsGridYellow()
        {
            Imaging.FindOptions.Default.BestMatch = false;
            Imaging.FindOptions.Default.Similarity = 1.0;
            Imaging.FindOptions.Default.Preprocessing = Imaging.Preprocessings.None;

            Container area = (new DiagramElements()).CurveArea;
            bool returnValue = Imaging.Contains(area, (new DiagramElements()).GridYellow, Imaging.FindOptions.Default);

            return returnValue;
        }
    }
}