// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WizardNavigationElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Handles WHG/SIL navigation elements within device function Parameterization
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Handles WHG/SIL navigation elements within device function Parameterization
    /// </summary>
    public class WizardNavigationElements
    {
        #region Public Properties

        /// <summary>
        /// Gets the open envelope curve.
        /// </summary>
        /// <value>The open envelope curve.</value>
        public Button OpenEnvelopeCurve
        {
            get
            {
                try
                {
                    Button openEnvelopeCurve;
                    if (Host.Local.TryFindSingle(WizardNavigationPaths.OpenEnvelopeCurve, 60000, out openEnvelopeCurve))
                    {
                        return openEnvelopeCurve;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the open create documentation.
        /// </summary>
        /// <value>The open create documentation.</value>
        public Button OpenCreateDocumentation
        {
            get
            {
                try
                {
                    Button openCreateDocumentation;
                    if (Host.Local.TryFindSingle(WizardNavigationPaths.OpenCreateDocumentation, 60000, out openCreateDocumentation))
                    {
                        return openCreateDocumentation;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the open Save Restore.
        /// </summary>
        /// <value>The open save restore.</value>
        public Button OpenSaveRestore
        {
            get
            {
                try
                {
                    Button openSaveRestore;
                    if (Host.Local.TryFindSingle(WizardNavigationPaths.OpenSaveRestore, 60000, out openSaveRestore))
                    {
                        return openSaveRestore;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the additional settings.
        /// </summary>
        /// <value>The cancel.</value>
        public Button AdditionalSettings
        {
            get
            {
                try
                {
                    Button additionalSettings;
                    if (Host.Local.TryFindSingle(WizardNavigationPaths.AdditionalSettings, 60000, out additionalSettings))
                    {
                        return additionalSettings;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the cancel.
        /// </summary>
        /// <value>The cancel.</value>
        public Button Cancel
        {
            get
            {
                try
                {
                    Button cancel;
                    if (Host.Local.TryFindSingle(WizardNavigationPaths.Cancel, 60000, out cancel))
                    {
                        return cancel;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the confirm.
        /// </summary>
        /// <value>The confirm.</value>
        public Button Confirm
        {
            get
            {
                try
                {
                    Button confirm;
                    if (Host.Local.TryFindSingle(WizardNavigationPaths.Confirm, 60000, out confirm))
                    {
                        return confirm;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the End Of Sequence.
        /// </summary>
        /// <value>The cancel.</value>
        public Button EndOfSequence
        {
            get
            {
                try
                {
                    Button endOfSequence;
                    if (Host.Local.TryFindSingle(WizardNavigationPaths.EndOfSequence, 60000, out endOfSequence))
                    {
                        return endOfSequence;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the next.
        /// </summary>
        /// <value>The next.</value>
        public Button Next
        {
            get
            {
                try
                {
                    Button next;
                    if (Host.Local.TryFindSingle(WizardNavigationPaths.Next, 60000, out next))
                    {
                        return next;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the previous.
        /// </summary>
        /// <value>The previous.</value>
        public Button Previous
        {
            get
            {
                try
                {
                    Button previous;
                    if (Host.Local.TryFindSingle(WizardNavigationPaths.Previous, 60000, out previous))
                    {
                        return previous;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the  reset SIL sequence page logo.
        /// </summary>
        /// <value>The SIL sequence page logo.</value>
        public Element ResetSilSequencePageLogo
        {
            get
            {
                try
                {
                    Element logo;
                    if (Host.Local.TryFindSingle(WizardNavigationPaths.ResetSilSequencePageLogo, 60000, out logo))
                    {
                        return logo;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the SIL sequence page logo.
        /// </summary>
        /// <value>The SIL sequence page logo.</value>
        public Element SilSequencePageLogo
        {
            get
            {
                try
                {
                    Element logo;
                    if (Host.Local.TryFindSingle(WizardNavigationPaths.SilSequencePageLogo, 60000, out logo))
                    {
                        return logo;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}