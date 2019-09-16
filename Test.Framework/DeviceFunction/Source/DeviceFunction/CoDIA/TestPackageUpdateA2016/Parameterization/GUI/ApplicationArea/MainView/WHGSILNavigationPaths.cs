// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WHGSILNavigationPaths.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains RanorexPaths to generic CreateDocumentation Objects
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView
{
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    /// <summary>
    ///     Contains RanorexPaths to generic CreateDocumentation Objects
    /// </summary>
    public static class WHGSILNavigationPaths
    {
        #region Static Fields

        /// <summary>
        /// The cancel.
        /// </summary>
        public static string Cancel;

        /// <summary>
        /// The confirm.
        /// </summary>
        public static string Confirm;

        /// <summary>
        /// The help string.
        /// </summary>
        public static string HelpString;

        /// <summary>
        /// The next.
        /// </summary>
        public static string Next;

        /// <summary>
        /// SilSequencePageLogo
        /// </summary>
        public static string SilSequencePageLogo;

        /// <summary>
        /// ResetSilSequencePageLogo
        /// </summary>
        public static string ResetSilSequencePageLogo;

        /// <summary>
        /// The previous.
        /// </summary>
        public static string Previous;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="WHGSILNavigationPaths"/> class.
        /// </summary>
        static WHGSILNavigationPaths()
        {
            HelpString = CommonFlows.GetDtmContainerPath.Run();

            Previous = @HelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/element[@controlname='_WizardButtonPrevious']/button[@accessiblename='Previous']";
            Next = @HelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/element[@controlname='_WizardButtonNext']/button[@accessiblename='Next']";
            Confirm = @HelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/element[@controlname='_WizardButtonNext']/button[@accessiblename='Confirm']";
            Cancel = @HelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/element[@controlname='_WizardButtonAbort']/button[@accessiblename='Cancel']";
            SilSequencePageLogo = @HelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/element/container/container/container/container/container/container/element[@controlname~'SILSequencePage']";
            ResetSilSequencePageLogo = @HelpString + "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/element/container/container/container/container/container/container/element[@controlname~'ResetSIL']";
        }

        #endregion
    }
}