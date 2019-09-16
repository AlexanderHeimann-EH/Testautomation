// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    ///     Provides access to common controls within module concentration
    /// </summary>
    public class CommonElements
    {
        #region Fields

        /// <summary>
        /// The concentration.
        /// </summary>
        private readonly Controls concentration;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonElements"/> class.
        /// </summary>
        public CommonElements()
        {
            this.concentration = Controls.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list items combo box.
        /// </summary>
        public IList<ListItem> ListItemsComboBox
        {
            get
            {
                try
                {
                    List list;
                    Host.Local.TryFindSingle(this.concentration.comboBoxListInfo.AbsolutePath, out list);
                    return list.Items;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the scroll bar.
        /// Last edit by EC on 2017-09-29:
        /// </summary>
        public ScrollBar ScrollBar
        {
            get
            {
                try
                {
                    ScrollBar scrollBar;
                    Host.Local.TryFindSingle(this.concentration.scrollbarInfo.AbsolutePath, out scrollBar);
                    return scrollBar;
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