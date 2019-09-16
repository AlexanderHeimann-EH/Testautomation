// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WHGSILNavigationElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Handles WHG/SIL navigation elements within device function Parameterization
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Handles WHG/SIL navigation elements within device function Parameterization
    /// </summary>
    public class WHGSILNavigationElements
    {
        #region Public Properties

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
                    if (Host.Local.TryFindSingle(WHGSILNavigationPaths.Cancel, DefaultValues.iTimeoutDefault, out cancel))
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
                    if (Host.Local.TryFindSingle(WHGSILNavigationPaths.Confirm, DefaultValues.iTimeoutDefault, out confirm))
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
                    if (Host.Local.TryFindSingle(WHGSILNavigationPaths.Next, DefaultValues.iTimeoutDefault, out next))
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
                    if (Host.Local.TryFindSingle(WHGSILNavigationPaths.Previous, DefaultValues.iTimeoutDefault, out previous))
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
                    if (Host.Local.TryFindSingle(WHGSILNavigationPaths.SilSequencePageLogo, DefaultValues.iTimeoutDefault, out logo))
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
                    if (Host.Local.TryFindSingle(WHGSILNavigationPaths.ResetSilSequencePageLogo, DefaultValues.iTimeoutDefault, out logo))
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