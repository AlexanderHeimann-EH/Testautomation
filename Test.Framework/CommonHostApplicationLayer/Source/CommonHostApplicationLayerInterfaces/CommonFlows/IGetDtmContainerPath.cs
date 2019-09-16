// -----------------------------------------------------------------------
// <copyright file="IGetDtmContainerPath.cs" company="Endress+Hauser Process Solutions AG">
// Endress + Hauser
// </copyright>
// -----------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Interface for "GetDtmContainerPath"
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public interface IGetDtmContainerPath
    {
        /// <summary>
        /// Provides the host application specific DTM container Ranorex path. 
        /// To work with the actual device functions in this framework, the path needs to include the container "ControlAXSourcingSite" for Device Care and the container "GuiTransparentProxy" for FieldCare.
        /// </summary>
        /// <returns>
        /// string: The DTM container path
        /// </returns>
        string Run();
    }
}
