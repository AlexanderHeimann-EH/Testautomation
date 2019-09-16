// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Defines the Logger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    using EH.DTMstudioTest.Common.Utilities.Logging;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// The logger.
    /// </summary>
    internal class Logger
    {
        #region Constants

        /// <summary>
        /// The output newline.
        /// </summary>
        private const string OutputNewline = "\n";

        /// <summary>
        /// The output pane title.
        /// </summary>
        private const string OutputPaneTitle = "DTMstudio Test";

        /// <summary>
        /// The task category.
        /// </summary>
        private const string TaskCategory = "DTMstudio Test";

        #endregion

        #region Properties

        /// <summary>
        /// Gets the output pane.
        /// </summary>
        private static IVsOutputWindowPane OutputPane
        {
            get
            {
                IVsOutputWindowPane pane = null;
                var guidOutputWindowPane = GuidList.GuidOutputWindowPane;
                var globalService = (IVsOutputWindow)Package.GetGlobalService(typeof(SVsOutputWindow));
                if (globalService != null)
                {
                    globalService.GetPane(ref guidOutputWindowPane, out pane);
                    if (pane == null)
                    {
                        ErrorHandler.ThrowOnFailure(globalService.CreatePane(ref guidOutputWindowPane, TaskCategory, Convert.ToInt32(true), Convert.ToInt32(false)));
                        ErrorHandler.ThrowOnFailure(globalService.GetPane(ref guidOutputWindowPane, out pane));
                    }

                    ErrorHandler.ThrowOnFailure(pane.Activate());
                }

                return pane;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The clear.
        /// </summary>
        public static void Clear()
        {
            var outputPane = OutputPane;
            if (outputPane != null)
            {
                outputPane.Clear();
            }
        }

        /// <summary>
        /// The enter.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="projectFile">
        /// The project file.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        public static void Enter(object sender, string projectFile, string method)
        {
            Log.Enter(sender, method);

            // OutputInformationTask(projectFile, method);
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="projectFile">
        /// The project name.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Error(object sender, string projectFile, string message)
        {
            Log.Error(sender, message);

            OutputErrorTask(projectFile, message);
        }

        /// <summary>
        /// The error ex.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="projectFile">
        /// The project file.
        /// </param>
        /// <param name="ex">
        /// The ex.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void ErrorEx(object sender, string projectFile, Exception ex, string message)
        {
            Log.ErrorEx(sender, ex, message);

            OutputErrorTask(projectFile, message);
        }

        /// <summary>
        /// The get output pane.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="paneGuid">
        /// The pane GUID.
        /// </param>
        /// <returns>
        /// The <see cref="IVsOutputWindowPane"/>.
        /// </returns>
        public static IVsOutputWindowPane GetOutputPane(string title, Guid paneGuid)
        {
            IVsOutputWindowPane pane = null;
            var globalService = (IVsOutputWindow)Package.GetGlobalService(typeof(SVsOutputWindow));
            if (globalService != null)
            {
                globalService.GetPane(ref paneGuid, out pane);
                if (pane == null)
                {
                    ErrorHandler.ThrowOnFailure(globalService.CreatePane(ref paneGuid, title, Convert.ToInt32(true), Convert.ToInt32(false)));
                    ErrorHandler.ThrowOnFailure(globalService.GetPane(ref paneGuid, out pane));
                }

                ErrorHandler.ThrowOnFailure(pane.Activate());
            }

            return pane;
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="loggerConfigurationPath">
        /// The logger configuration path.
        /// </param>
        public static void Initialize(string loggerConfigurationPath)
        {
            Log.Initialize(loggerConfigurationPath);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The append new line.
        /// </summary>
        /// <param name="inText">
        /// The in text.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string AppendNewLine(string inText)
        {
            string str = inText;
            if (string.IsNullOrEmpty(str))
            {
                return " \n";
            }

            if (!str.EndsWith("\n"))
            {
                str = str + "\n";
            }

            return str;
        }

        /// <summary>
        /// The output error task.
        /// </summary>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        private static void OutputErrorTask(string projectName, string message)
        {
            TraceTaskEvent(TraceEventType.Error, projectName, TaskCategory, message, string.Empty, 1, message);
        }

        /// <summary>
        /// The output error task.
        /// </summary>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="filename">
        /// The filename.
        /// </param>
        private static void OutputErrorTask(string projectName, string message, string filename)
        {
            TraceTaskEvent(TraceEventType.Error, projectName, TaskCategory, message, filename, 1, message);
        }

        /// <summary>
        /// The output error task.
        /// </summary>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="taskMessage">
        /// The task message.
        /// </param>
        /// <param name="outputMessage">
        /// The output message.
        /// </param>
        /// <param name="filename">
        /// The filename.
        /// </param>
        private static void OutputErrorTask(string projectName, string taskMessage, string outputMessage, string filename)
        {
            TraceTaskEvent(TraceEventType.Error, projectName, TaskCategory, taskMessage, filename, 1, outputMessage);
        }

        /// <summary>
        /// The output information task.
        /// </summary>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        private static void OutputInformationTask(string projectName, string message)
        {
            TraceTaskEvent(TraceEventType.Information, projectName, TaskCategory, message, string.Empty, 1, message);
        }

        /// <summary>
        /// The output information task.
        /// </summary>
        /// <param name="projectName">
        /// The project Name.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="filename">
        /// The filename.
        /// </param>
        private static void OutputInformationTask(string projectName, string message, string filename)
        {
            TraceTaskEvent(TraceEventType.Information, projectName, TaskCategory, message, filename, 1, message);
        }

        /// <summary>
        /// The output information task.
        /// </summary>
        /// <param name="projectName">
        /// The project Name.
        /// </param>
        /// <param name="taskMessage">
        /// The task message.
        /// </param>
        /// <param name="outputMessage">
        /// The output message.
        /// </param>
        /// <param name="filename">
        /// The filename.
        /// </param>
        private static void OutputInformationTask(string projectName, string taskMessage, string outputMessage, string filename)
        {
            TraceTaskEvent(TraceEventType.Information, projectName, TaskCategory, taskMessage, filename, 1, outputMessage);
        }

        /// <summary>
        /// The output string.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        private static void OutputString(TraceEventType type, string text)
        {
            IVsOutputWindowPane outputPane = OutputPane;
            if (outputPane != null)
            {
                ErrorHandler.ThrowOnFailure(outputPane.OutputStringThreadSafe(text));
                ErrorHandler.ThrowOnFailure(outputPane.FlushToTaskList());
                Application.DoEvents();
            }
        }

        /// <summary>
        /// The output string line.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        private static void OutputStringLine(TraceEventType type, string text)
        {
            IVsOutputWindowPane outputPane = OutputPane;
            if (outputPane != null)
            {
                ErrorHandler.ThrowOnFailure(outputPane.OutputStringThreadSafe(text + "\n"));
                ErrorHandler.ThrowOnFailure(outputPane.FlushToTaskList());
                Application.DoEvents();
            }
        }

        /// <summary>
        /// The output warning task.
        /// </summary>
        /// <param name="projectName">
        /// The project Name.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        private static void OutputWarningTask(string projectName, string message)
        {
            TraceTaskEvent(TraceEventType.Warning, projectName, TaskCategory, message, string.Empty, 1, message);
        }

        /// <summary>
        /// The output warning task.
        /// </summary>
        /// <param name="projectName">
        /// The project Name.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="filename">
        /// The filename.
        /// </param>
        private static void OutputWarningTask(string projectName, string message, string filename)
        {
            TraceTaskEvent(TraceEventType.Warning, projectName, TaskCategory, message, filename, 1, message);
        }

        /// <summary>
        /// The output warning task.
        /// </summary>
        /// <param name="projectName">
        /// The project Name.
        /// </param>
        /// <param name="taskMessage">
        /// The task message.
        /// </param>
        /// <param name="outputMessage">
        /// The output message.
        /// </param>
        /// <param name="filename">
        /// The filename.
        /// </param>
        private static void OutputWarningTask(string projectName, string taskMessage, string outputMessage, string filename)
        {
            TraceTaskEvent(TraceEventType.Warning, projectName, TaskCategory, taskMessage, filename, 1, outputMessage);
        }

        /// <summary>
        /// The trace task event.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <param name="taskMessage">
        /// The task message.
        /// </param>
        /// <param name="file">
        /// The file.
        /// </param>
        /// <param name="line">
        /// The line.
        /// </param>
        /// <param name="outputMessage">
        /// The output message.
        /// </param>
        private static void TraceTaskEvent(TraceEventType type, string projectName, string category, string taskMessage, string file, uint line, string outputMessage)
        {
            outputMessage = AppendNewLine(outputMessage);
            IVsOutputWindowPane outputPane = OutputPane;
            if (outputPane != null)
            {
                switch (type)
                {
                    case TraceEventType.Error:
                        ErrorHandler.ThrowOnFailure(outputPane.OutputTaskItemString(string.IsNullOrEmpty(outputMessage) ? " " : outputMessage, VSTASKPRIORITY.TP_HIGH, VSTASKCATEGORY.CAT_BUILDCOMPILE, projectName + (string.IsNullOrEmpty(category) ? string.Empty : (":" + category)), 1, string.IsNullOrEmpty(file) ? string.Empty : file, line, taskMessage));
                        break;

                    case TraceEventType.Warning:
                        ErrorHandler.ThrowOnFailure(outputPane.OutputTaskItemString(string.IsNullOrEmpty(outputMessage) ? " " : outputMessage, VSTASKPRIORITY.TP_NORMAL, VSTASKCATEGORY.CAT_BUILDCOMPILE, projectName + (string.IsNullOrEmpty(category) ? string.Empty : (":" + category)), 2, string.IsNullOrEmpty(file) ? string.Empty : file, line, taskMessage));
                        break;

                    case TraceEventType.Information:
                        ErrorHandler.ThrowOnFailure(outputPane.OutputTaskItemString(string.IsNullOrEmpty(outputMessage) ? " " : outputMessage, VSTASKPRIORITY.TP_LOW, VSTASKCATEGORY.CAT_USER, projectName + (string.IsNullOrEmpty(category) ? string.Empty : (":" + category)), 3, string.IsNullOrEmpty(file) ? string.Empty : file, line, taskMessage));
                        break;

                    case TraceEventType.Verbose:
                        OutputString(TraceEventType.Verbose, outputMessage);
                        break;

                    default:
                        OutputString(TraceEventType.Information, outputMessage);
                        break;
                }

                ErrorHandler.ThrowOnFailure(outputPane.FlushToTaskList());
                Application.DoEvents();
            }
        }

        #endregion
    }
}