//------------------------------------------------------------------------------
// <copyright file="CommonElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    ///     Provides access to common tab controls within module HISTOROM
    /// </summary>
    public class CommonElements
    {
        #region members

        /// <summary>
        /// The HISTOROM repository.
        /// </summary>
        private readonly Controls historom;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonElements"/> class. 
        ///     Constructor creates an instance of repository which will be used
        /// </summary>
        public CommonElements()
        {
            this.historom = Controls.Instance;
        }

        #endregion

        #region listItem

        /// <summary>
        ///     Gets tab "Settings"  -> combo box list items
        /// </summary>
        public IList<ListItem> ListItemsComboBox
        {
            get
            {
                try
                {
                    List list = this.historom.Settings.comboBoxList;
                    if (list != null && list.Items.Count > 0)
                    {
                        return list.Items;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Empty);
                    return null;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}