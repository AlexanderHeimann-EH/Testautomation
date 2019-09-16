// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateCommand.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   General ICommand implementation that accepts a delegate for the actual command to execute. The 'IsExecutable' property is linked to the commands 'CanExecute' event (and therefore defines the enabled state of the command) Note: The access to the 'CanExecuteChanged' event is dispatched. -&gt; Create this class in the ui thread!
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Input;

    using EH.ImsOpcBridge.UI.Wpf.Properties;

    using log4net;

    /// <summary>
    /// General ICommand implementation that accepts a delegate for the actual command to execute. The 'IsExecutable' property is linked to the commands 'CanExecute' event (and therefore defines the enabled state of the command) Note: The access to the 'CanExecuteChanged' event is dispatched. -&gt; Create this class in the ui thread!
    /// </summary>
    public class DelegateCommand : DependencyObject, ICommand
    {
        #region Static Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        /// <summary>
        /// The delegate, which can be called to get the check flag.
        /// </summary>
        private readonly GetCheckDelegateState checkDelegateState;

        /// <summary>
        /// The context
        /// </summary>
        private readonly object context;

        /// <summary>
        /// Action that is to be executed (without parameter)
        /// </summary>
        private readonly Action executeHandler;

        /// <summary>
        /// Action that is to be executed (with an object parameter)
        /// </summary>
        private readonly Action<object> executeHandlerWithParam;

        /// <summary>
        /// Value indicating the commands executable state.
        /// </summary>
        private bool canExecute;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeWithParam">
        /// The execute with param.
        /// </param>
        public DelegateCommand(Action<object> executeWithParam)
        {
            this.IsExecutable = true;
            this.executeHandlerWithParam = executeWithParam;
            this.executeHandler = null;

            if (executeWithParam == null)
            {
                if (Logger.IsWarnEnabled)
                {
                    Logger.Warn(Resources.CreatingDelegateCommandWithMissingDelegate);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeWithParam">
        /// The execute with param.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        public DelegateCommand(Action<object> executeWithParam, object context)
        {
            this.context = context;
            this.IsExecutable = true;
            this.executeHandlerWithParam = executeWithParam;
            this.executeHandler = null;

            if (executeWithParam == null)
            {
                if (Logger.IsWarnEnabled)
                {
                    Logger.Warn(Resources.CreatingDelegateCommandWithMissingDelegate);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="execute">
        /// The execute.
        /// </param>
        public DelegateCommand(Action execute)
        {
            this.IsExecutable = true;
            this.executeHandlerWithParam = null;
            this.executeHandler = execute;

            if (execute == null)
            {
                if (Logger.IsWarnEnabled)
                {
                    Logger.Warn(Resources.CreatingDelegateCommandWithMissingDelegate);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeWithParam">
        /// The execute with param.
        /// </param>
        /// <param name="checkDelegateState">
        /// The check state delegate.
        /// </param>
        public DelegateCommand(Action<object> executeWithParam, GetCheckDelegateState checkDelegateState)
        {
            this.IsExecutable = true;
            this.executeHandlerWithParam = executeWithParam;
            this.executeHandler = null;
            this.checkDelegateState = checkDelegateState;

            if (executeWithParam == null)
            {
                if (Logger.IsWarnEnabled)
                {
                    Logger.Warn(Resources.CreatingDelegateCommandWithMissingDelegate);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="execute">
        /// The execute.
        /// </param>
        /// <param name="checkDelegateState">
        /// The check state delegate.
        /// </param>
        public DelegateCommand(Action execute, GetCheckDelegateState checkDelegateState)
        {
            this.IsExecutable = true;
            this.executeHandlerWithParam = null;
            this.executeHandler = execute;
            this.checkDelegateState = checkDelegateState;

            if (execute == null)
            {
                if (Logger.IsWarnEnabled)
                {
                    Logger.Warn(Resources.CreatingDelegateCommandWithMissingDelegate);
                }
            }
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate, which can be called to get the check flag.
        /// </summary>
        /// <returns>The check flag.</returns>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:CodeAnalysisSuppressionMustHaveJustification", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public delegate bool? GetCheckDelegateState();

        #endregion

        #region Public Events

        /// <summary>
        /// Event signaling a change in the commands execution state.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        public object Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the command is executable.
        /// </summary>
        /// <value><c>true</c> if this instance is executable; otherwise, <c>false</c> .</value>
        public bool IsExecutable
        {
            get
            {
                return this.canExecute;
            }

            set
            {
                this.canExecute = value;
                this.OnCanExecuteChanged();
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Returns the actual command execution state.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// Returns the actual execution state.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return this.IsExecutable;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK here.")]
        public void Execute(object parameter)
        {
            try
            {
                if (this.executeHandler != null)
                {
                    bool? checkStateBefore = null;

                    if (this.checkDelegateState != null)
                    {
                        checkStateBefore = this.checkDelegateState();
                    }

                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.DelegateCommandExecuteExecuting_, this.executeHandler.Method.Name, checkStateBefore.HasValue ? checkStateBefore.Value.ToString(CultureInfo.InvariantCulture) : Resources.DelegateCommandExecuteUnknown);

                    Logger.Info(message);

                    if (parameter != null)
                    {
                        if (Logger.IsWarnEnabled)
                        {
                            Logger.Warn(Resources.ExecutionOfDelegateCommandPleasePassNonNullParameter);
                        }
                    }

                    this.executeHandler();
                }
                else if (this.executeHandlerWithParam != null)
                {
                    if (this.context != null)
                    {
                        this.executeHandlerWithParam(this.context);
                    }
                    else
                    {
                        this.executeHandlerWithParam(parameter);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Logger.IsErrorEnabled)
                {
                    Logger.Error(Resources.ExecutionOfDelegateCommandFailed, ex);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Fires CanExecuteChanged.
        /// </summary>
        protected void OnCanExecuteChanged()
        {
            var canExecuteChanged = this.CanExecuteChanged;

            if (canExecuteChanged != null)
            {
                if (this.Dispatcher.CheckAccess())
                {
                    canExecuteChanged(this, EventArgs.Empty);
                }
                else
                {
                    this.Dispatcher.BeginInvoke((Action)this.OnCanExecuteChanged);
                }
            }
        }

        #endregion
    }
}
