// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WizardNavigationPaths.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains RanorexPaths to generic CreateDocumentation Objects
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView
{
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    /// <summary>
    ///     Contains RanorexPaths to generic CreateDocumentation Objects
    /// </summary>
    public static class WizardNavigationPaths
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

        /// <summary>
        /// The Additional Settings.
        /// </summary>
        public static string AdditionalSettings;

        /// <summary>
        /// The End Of Sequence.
        /// </summary>
        public static string EndOfSequence;

        /// <summary>
        /// The open save restore
        /// </summary>
        public static string OpenSaveRestore;

        /// <summary>
        /// The open envelope curve
        /// </summary>
        public static string OpenEnvelopeCurve;

        /// <summary>
        /// The open create documentation
        /// </summary>
        public static string OpenCreateDocumentation;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="WizardNavigationPaths"/> class.
        /// </summary>
        static WizardNavigationPaths()
        {
            HelpString = CommonFlows.GetDtmContainerPath.Run();
            
            // Navigation Buttons
            Previous            = @HelpString + @"/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/element[@controlname='_WizardButtonPrevious']/button";
            Next                = @HelpString + @"/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/element[@controlname='_WizardButtonNext']/button";
            AdditionalSettings  = @HelpString + @"/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/element[@controlname='_WizardButtonNext']/button";
            Confirm             = @HelpString + @"/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/element[@controlname='_WizardButtonNext']/button";
            Cancel              = @HelpString + @"/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/element[@controlname='_WizardButtonAbort']/button";
            EndOfSequence       = @HelpString + @"/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/element[@controlname='_WizardButtonAbort']/button";
            
            // Logos
            SilSequencePageLogo         = @HelpString + @"/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/element/container/container/container/container/container/container/element[@controlname~'SILSequencePage']";
            ResetSilSequencePageLogo    = @HelpString + @"/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/element/container/container/container/container/container/container/element[@controlname~'ResetSIL']";
            
            // Module Buttons
            // ALT -  @"/container/container[@controlname='DtmDisplayArea']/?/?/container/container[@controlname='EddMenuTabPage_MenuPanel']/?/?/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']//container[@controlname='EddMenuGroupBox_MenuPanel']/container[@controlname='EddMenuPanel_ScrollContainer']/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']//element/button[@accessiblename~'Envelope']";
            OpenEnvelopeCurve           = @HelpString + @"/container/container[@controlname='DtmDisplayArea']//element[@controlname~'Local_GoToEnvelope_']/button";
            
            // ALT -  @"/container/container[@controlname='DtmDisplayArea']/?/?/container/container[@controlname='EddMenuTabPage_MenuPanel']/?/?/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']//container[@controlname='EddMenuGroupBox_MenuPanel']/container[@controlname='EddMenuPanel_ScrollContainer']/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']//element/button[@accessiblename~'Save device settings']";
            OpenSaveRestore             = @HelpString + @"/container/container[@controlname='DtmDisplayArea']//element[@controlname~'Local_BackupToHDD_']/button";

            // ALT -  @HelpString + @"/container/container[@controlname='DtmDisplayArea']/?/?/container/container[@controlname='EddMenuTabPage_MenuPanel']/?/?/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']//container[@controlname='EddMenuGroupBox_MenuPanel']/container[@controlname='EddMenuPanel_ScrollContainer']/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']//element/button[@accessiblename='Create documentation']";
            OpenCreateDocumentation     = @HelpString + @"/container/container[@controlname='DtmDisplayArea']//element[@controlname~'Local_CreateDocu_']/button";
        }

        #endregion
    }
}