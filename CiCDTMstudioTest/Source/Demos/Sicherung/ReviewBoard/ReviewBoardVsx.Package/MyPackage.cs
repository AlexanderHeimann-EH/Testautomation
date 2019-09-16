using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace ReviewBoardVsx.Package
{
    //[ComVisible(true)]
    public class MyPackage : Microsoft.VisualStudio.Shell.Package
    {
        /// <summary>
        /// Gets the item id.
        /// </summary>
        /// <param name="pvar">VARIANT holding an itemid.</param>
        /// <returns>Item Id of the concerned node</returns>
        public static uint GetItemId(object pvar)
        {
            if (pvar == null) return VSConstants.VSITEMID_NIL;
            if (pvar is int) return (uint)(int)pvar;
            if (pvar is uint) return (uint)pvar;
            if (pvar is short) return (uint)(short)pvar;
            if (pvar is ushort) return (uint)(ushort)pvar;
            if (pvar is long) return (uint)(long)pvar;
            return VSConstants.VSITEMID_NIL;
        }

        public static IVsMonitorSelection GetMonitorSelection()
        {
            return Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SVsShellMonitorSelection)) as IVsMonitorSelection;
        }

        public static IVsOutputWindow GetOutputWindow()
        {
            return Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
        }

        public static IVsOutputWindowPane GetOutputWindowPaneGeneral()
        {
            IVsOutputWindowPane outWindowGeneralPane = null;
            IVsOutputWindow outputWindow = GetOutputWindow();
            if (outputWindow != null)
            {
                Guid guidGeneral = VSConstants.GUID_OutWindowGeneralPane;
                outputWindow.GetPane(ref guidGeneral, out outWindowGeneralPane);
            }
            return outWindowGeneralPane;
        }

        /// <summary>
        /// Prints to debug ouput and on the generic pane of the VS output window.
        /// </summary>
        /// <param name="text">text to send to Output Window.</param>
        public static void OutputGeneral(string text)
        {
            Debug.WriteLine("OutputGeneral: " + text);

            // Build the string to write on the debugger and output window.
            StringBuilder outputText = new StringBuilder(text);
            outputText.AppendLine();

            IVsOutputWindowPane outputWindowPaneGeneral = GetOutputWindowPaneGeneral();
            if (outputWindowPaneGeneral == null)
            {
                Trace.WriteLine("Failed to get a reference to IVsOutputWindow");
                return;
            }

            if (ErrorHandler.Failed(outputWindowPaneGeneral.OutputString(outputText.ToString())))
            {
                Trace.WriteLine("Failed to write on the output window");
            }
        }

        public T GetService<T>() where T : class
        {
            return GetService<T>(typeof(T));
        }

        public T GetService<T>(Type type) where T : class
        {
            return GetService(type) as T;
        }

        public IVsSolution GetSolution()
        {
            return GetService<SVsSolution>() as IVsSolution;
        }

        public IVsLaunchPad GetLaunchPad()
        {
            return GetService<SVsLaunchPad>() as IVsLaunchPad;
        }

        public IVsWebBrowsingService GetWebBrowsingService()
        {
            return GetService<SVsWebBrowsingService>() as IVsWebBrowsingService;
        }

        public int VsBrowseUrl(Uri uri)
        {
            if (uri == null)
            {
                OutputGeneral("ERROR: url cannot be null");
                ErrorHandler.ThrowOnFailure(VSConstants.E_POINTER);
            }

            IVsWebBrowsingService browserService = GetWebBrowsingService();
            if (browserService == null)
            {
                OutputGeneral("ERROR: Cannot create browser service");
                ErrorHandler.ThrowOnFailure(VSConstants.E_UNEXPECTED);
            }

            Guid guidNull = Guid.Empty;
            IVsWindowFrame frame;
            IVsWebBrowser browser;
            uint flags = (uint)(__VSCREATEWEBBROWSER.VSCWB_AutoShow | __VSCREATEWEBBROWSER.VSCWB_StartCustom | __VSCREATEWEBBROWSER.VSCWB_ReuseExisting);
            return browserService.CreateWebBrowser(flags, ref guidNull, "", uri.AbsoluteUri, null, out browser, out frame);
        }

        /// <summary>
        /// Blocks until the command finishes executing
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="commandLine"></param>
        /// <param name="workingDirectory"></param>
        /// <returns></returns>
        public string VsExecCommand(string fileName, string arguments, string workingDirectory)
        {
            IVsLaunchPad lp = GetService(typeof(SVsLaunchPad)) as IVsLaunchPad;
            if (lp == null)
            {
                OutputGeneral("Failed to create launch pad");
                return null;
            }

            IVsOutputWindowPane owp = GetOutputWindowPaneGeneral();
            if (owp == null)
            {
                OutputGeneral("Failed to get output window general pane");
                return null;
            }

            string commandLine;
            if (String.IsNullOrEmpty(arguments))
            {
                commandLine = fileName;
            }
            else
            {
                StringBuilder sb = new StringBuilder(fileName);
                sb.Append(" ").Append(arguments);
                commandLine = sb.ToString();
            }

            uint exitCode = 0;
            string[] output = new string[1];
            int hr = lp.ExecCommand(fileName, commandLine, workingDirectory, (uint)_LAUNCHPAD_FLAGS.LPF_PipeStdoutToOutputWindow, owp, (uint)VSTASKCATEGORY.CAT_USER, 0, "", null, out exitCode, output);
            if (ErrorHandler.Failed(hr))
            {
                OutputGeneral(fileName + " failed to launch: hr=0x" + hr.ToString("X8"));
                return null;
            }

            OutputGeneral(fileName + " exited with exitCode " + exitCode);

            if (exitCode != 0)
            {
                return null;
            }

            return output[0];
        }
    }
}
