// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurveType.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   The enumerations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 07.07.2015
 * Time: 12:59 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Enumerations
{
    /// <summary>
    ///     Curve Types for Set Cursor in Envelope Curve
    /// </summary>
    public enum CurveType
    {
        /// <summary>
        /// The free.
        /// </summary>
        Free = 1,

        /// <summary>
        /// The envelope curve.
        /// </summary>
        EnvelopeCurve,

        /// <summary>
        /// The weighting curve.
        /// </summary>
        WeightingCurve,

        /// <summary>
        /// The map.
        /// </summary>
        Map,

        /// <summary>
        /// The editable map.
        /// </summary>
        EditableMap,

        /// <summary>
        /// The threshold tank bottom.
        /// </summary>
        ThresholdTankBottom,

        /// <summary>
        /// The first echo curve.
        /// </summary>
        FirstEchoCurve,

        /// <summary>
        /// The ideal echo from file.
        /// </summary>
        IdealEchoFromFile,

        /// <summary>
        /// The ideal echo curve.
        /// </summary>
        IdealEchoCurve,

        /// <summary>
        /// The reference curve.
        /// </summary>
        ReferenceCurve,

        /// <summary>
        /// The threshold gpc.
        /// </summary>
        ThresholdGpc,

        /// <summary>
        /// The raw envelope curve.
        /// </summary>
        RawEnvelopeCurve,
    }
}
