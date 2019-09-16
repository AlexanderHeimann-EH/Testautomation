// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VSMacroRecorder.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The last macro.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.Template
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    using tom;

    // Last command type sent to the macro recorder. Note that there are more commands
    // recorded than is implied by this list. Commands in this list (other than
    // LastMacroNone) are coalesced when multiples of the same command are received
    // consecutively.

    // This enum should be extended or replaced with your own command identifiers to enable
    // Coalescing of commands.
    /// <summary>
    /// The last macro.
    /// </summary>
    public enum LastMacro
    {
        /// <summary>
        /// The none.
        /// </summary>
        None, 

        /// <summary>
        /// The text.
        /// </summary>
        Text, 

        /// <summary>
        /// The down arrow line.
        /// </summary>
        DownArrowLine, 

        /// <summary>
        /// The down arrow line selection.
        /// </summary>
        DownArrowLineSelection, 

        /// <summary>
        /// The down arrow para.
        /// </summary>
        DownArrowPara, 

        /// <summary>
        /// The down arrow para selection.
        /// </summary>
        DownArrowParaSelection, 

        /// <summary>
        /// The up arrow line.
        /// </summary>
        UpArrowLine, 

        /// <summary>
        /// The up arrow line selection.
        /// </summary>
        UpArrowLineSelection, 

        /// <summary>
        /// The up arrow para.
        /// </summary>
        UpArrowPara, 

        /// <summary>
        /// The up arrow para selection.
        /// </summary>
        UpArrowParaSelection, 

        /// <summary>
        /// The left arrow char.
        /// </summary>
        LeftArrowChar, 

        /// <summary>
        /// The left arrow char selection.
        /// </summary>
        LeftArrowCharSelection, 

        /// <summary>
        /// The left arrow word.
        /// </summary>
        LeftArrowWord, 

        /// <summary>
        /// The left arrow word selection.
        /// </summary>
        LeftArrowWordSelection, 

        /// <summary>
        /// The right arrow char.
        /// </summary>
        RightArrowChar, 

        /// <summary>
        /// The right arrow char selection.
        /// </summary>
        RightArrowCharSelection, 

        /// <summary>
        /// The right arrow word.
        /// </summary>
        RightArrowWord, 

        /// <summary>
        /// The right arrow word selection.
        /// </summary>
        RightArrowWordSelection, 

        /// <summary>
        /// The delete char.
        /// </summary>
        DeleteChar, 

        /// <summary>
        /// The delete word.
        /// </summary>
        DeleteWord, 

        /// <summary>
        /// The backspace char.
        /// </summary>
        BackspaceChar, 

        /// <summary>
        /// The backspace word.
        /// </summary>
        BackspaceWord
    }

    /// <summary>
    /// The move scope.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags")]
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    public enum MoveScope
    {
        /// <summary>
        /// The character.
        /// </summary>
        Character = tomConstants.tomCharacter, 

        /// <summary>
        /// The word.
        /// </summary>
        Word = tomConstants.tomWord, 

        /// <summary>
        /// The line.
        /// </summary>
        Line = tomConstants.tomLine, 

        /// <summary>
        /// The paragraph.
        /// </summary>
        Paragraph = tomConstants.tomParagraph
    }

    /// <summary>
    /// The VSMacroRecorder class implementation and the IVsMacroRecorder Interface definition
    /// were included here in this seperate class because they were not included in the 
    /// interop assemblies shipped with Visual Studio 2005.
    /// 
    /// When implementing a macro recorder this class should be copied into your own name space
    /// and not shared between different 3rd party packages.
    /// </summary>
    public class VSMacroRecorder
    {
        #region Fields

        /// <summary>
        /// The m_ guid emitter.
        /// </summary>
        private Guid m_GuidEmitter;

        /// <summary>
        /// The m_ last macro recorded.
        /// </summary>
        private LastMacro m_LastMacroRecorded;

        /// <summary>
        /// The m_ times previously recorded.
        /// </summary>
        private uint m_TimesPreviouslyRecorded;

        /// <summary>
        /// The m_ vs macro recorder.
        /// </summary>
        private IVsMacroRecorder m_VsMacroRecorder;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VSMacroRecorder"/> class.
        /// </summary>
        /// <param name="emitter">
        /// The emitter.
        /// </param>
        public VSMacroRecorder(Guid emitter)
        {
            this.m_LastMacroRecorded = LastMacro.None;

            this.m_GuidEmitter = emitter;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get times previously recorded.
        /// </summary>
        /// <param name="macro">
        /// The macro.
        /// </param>
        /// <returns>
        /// The <see cref="uint"/>.
        /// </returns>
        public uint GetTimesPreviouslyRecorded(LastMacro macro)
        {
            return this.IsLastRecordedMacro(macro) ? this.m_TimesPreviouslyRecorded : 0;
        }

        // Compiler generated destructor is fine

        /// <summary>
        /// The is last recorded macro.
        /// </summary>
        /// <param name="macro">
        /// The macro.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsLastRecordedMacro(LastMacro macro)
        {
            return (macro == this.m_LastMacroRecorded && this.ObjectIsLastMacroEmitter()) ? true : false;
        }

        /// <summary>
        /// The is recording.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsRecording()
        {
            // If the property can not be retreived it is assumeed no macro is being recorded.
            VSRECORDSTATE recordState = VSRECORDSTATE.VSRECORDSTATE_OFF;

            // Retrieve the macro recording state.
            IVsShell vsShell = (IVsShell)Package.GetGlobalService(typeof(SVsShell));
            if (vsShell != null)
            {
                object var;
                if (ErrorHandler.Succeeded(vsShell.GetProperty((int)__VSSPROPID.VSSPROPID_RecordState, out var)) && null != var)
                {
                    recordState = (VSRECORDSTATE)var;
                }
            }

            // If there is a change in the record state to OFF or ON we must either obtain
            // or release the macro recorder. 
            if (recordState == VSRECORDSTATE.VSRECORDSTATE_ON && this.m_VsMacroRecorder == null)
            {
                // If this QueryService fails we no macro recording
                this.m_VsMacroRecorder = (IVsMacroRecorder)Package.GetGlobalService(typeof(IVsMacroRecorder));
            }
            else if (recordState == VSRECORDSTATE.VSRECORDSTATE_OFF && this.m_VsMacroRecorder != null)
            {
                // If the macro recording state has been switched off then we can release
                // the service. Note that if the state has become paused we take no action.
                this.Stop();
            }

            return this.m_VsMacroRecorder != null;
        }

        /// <summary>
        /// The record batched line.
        /// </summary>
        /// <param name="macroRecorded">
        /// The macro recorded.
        /// </param>
        /// <param name="line">
        /// The line.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool RecordBatchedLine(LastMacro macroRecorded, string line)
        {
            if (null == line)
            {
                line = string.Empty;
            }

            return this.RecordBatchedLine(macroRecorded, line, 0);
        }

        /// <summary>
        /// The record batched line.
        /// </summary>
        /// <param name="macroRecorded">
        /// The macro recorded.
        /// </param>
        /// <param name="line">
        /// The line.
        /// </param>
        /// <param name="maxLineLength">
        /// The max line length.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool RecordBatchedLine(LastMacro macroRecorded, string line, int maxLineLength)
        {
            if (null == line)
            {
                line = string.Empty;
            }

            if (maxLineLength > 0 && line.Length >= maxLineLength)
            {
                // Reset the state after recording the line, so it will not be appended to further
                this.RecordLine(line);

                // Notify the caller that the this line will not be appended to further
                return true;
            }

            if (this.IsLastRecordedMacro(macroRecorded))
            {
                this.m_VsMacroRecorder.ReplaceLine(line, ref this.m_GuidEmitter);

                // m_LastMacroRecorded can stay the same
                ++this.m_TimesPreviouslyRecorded;
            }
            else
            {
                this.m_VsMacroRecorder.RecordLine(line, ref this.m_GuidEmitter);
                this.m_LastMacroRecorded = macroRecorded;
                this.m_TimesPreviouslyRecorded = 1;
            }

            return false;
        }

        /// <summary>
        /// The record line.
        /// </summary>
        /// <param name="line">
        /// The line.
        /// </param>
        public void RecordLine(string line)
        {
            this.m_VsMacroRecorder.RecordLine(line, ref this.m_GuidEmitter);
            this.Reset();
        }

        /// <summary>
        /// The reset.
        /// </summary>
        public void Reset()
        {
            this.m_LastMacroRecorded = LastMacro.None;
            this.m_TimesPreviouslyRecorded = 0;
        }

        /// <summary>
        /// The stop.
        /// </summary>
        public void Stop()
        {
            this.Reset();
            this.m_VsMacroRecorder = null;
        }

        #endregion

        // This function determines if the last line sent to the macro recorder was
        // sent from this emitter. Note it is not valid to call this function if
        // macro recording is switched off.
        #region Methods

        /// <summary>
        /// The object is last macro emitter.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ObjectIsLastMacroEmitter()
        {
            Guid guid;
            this.m_VsMacroRecorder.GetLastEmitterId(out guid);
            return guid.Equals(this.m_GuidEmitter);
        }

        #endregion
    }

    #region "IVsMacro Interfaces"

    /// <summary>
    /// The _ vspropsheetpage.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [ComConversionLoss]
    internal struct _VSPROPSHEETPAGE
    {
        /// <summary>
        /// The dw size.
        /// </summary>
        public uint dwSize;

        /// <summary>
        /// The dw flags.
        /// </summary>
        public uint dwFlags;

        /// <summary>
        /// The h instance.
        /// </summary>
        [ComAliasName("vbapkg.ULONG_PTR")]
        public uint hInstance;

        /// <summary>
        /// The w template id.
        /// </summary>
        public ushort wTemplateId;

        /// <summary>
        /// The dw template size.
        /// </summary>
        public uint dwTemplateSize;

        /// <summary>
        /// The p template.
        /// </summary>
        [ComConversionLoss]
        public IntPtr pTemplate;

        /// <summary>
        /// The pfn dlg proc.
        /// </summary>
        [ComAliasName("vbapkg.ULONG_PTR")]
        public uint pfnDlgProc;

        /// <summary>
        /// The l param.
        /// </summary>
        [ComAliasName("vbapkg.LONG_PTR")]
        public int lParam;

        /// <summary>
        /// The pfn callback.
        /// </summary>
        [ComAliasName("vbapkg.ULONG_PTR")]
        public uint pfnCallback;

        /// <summary>
        /// The pc ref parent.
        /// </summary>
        [ComConversionLoss]
        public IntPtr pcRefParent;

        /// <summary>
        /// The dw reserved.
        /// </summary>
        public uint dwReserved;

        /// <summary>
        /// The hwnd dlg.
        /// </summary>
        [ComConversionLoss]
        [ComAliasName("vbapkg.wireHWND")]
        public IntPtr hwndDlg;
    }

    /// <summary>
    /// The _ vsrecordmode.
    /// </summary>
    internal enum _VSRECORDMODE
    {
        // Fields
        /// <summary>
        /// The vsrecordmod e_ absolute.
        /// </summary>
        VSRECORDMODE_ABSOLUTE = 1, 

        /// <summary>
        /// The vsrecordmod e_ relative.
        /// </summary>
        VSRECORDMODE_RELATIVE = 2
    }

    /// <summary>
    /// The VsMacros interface.
    /// </summary>
    [ComImport]
    [ComConversionLoss]
    [InterfaceType(1)]
    [Guid("55ED27C1-4CE7-11D2-890F-0060083196C6")]
    internal interface IVsMacros
    {
        /// <summary>
        /// The get macro commands.
        /// </summary>
        /// <param name="ppsaMacroCanonicalNames">
        /// The ppsa macro canonical names.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMacroCommands([Out] IntPtr ppsaMacroCanonicalNames);
    }

    /// <summary>
    /// The VsMacroRecorder interface.
    /// </summary>
    [ComImport]
    [InterfaceType(1)]
    [Guid("04BBF6A5-4697-11D2-890E-0060083196C6")]
    internal interface IVsMacroRecorder
    {
        /// <summary>
        /// The record start.
        /// </summary>
        /// <param name="pszReserved">
        /// The psz reserved.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RecordStart([In] [MarshalAs(UnmanagedType.LPWStr)] string pszReserved);

        /// <summary>
        /// The record end.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RecordEnd();

        /// <summary>
        /// The record line.
        /// </summary>
        /// <param name="pszLine">
        /// The psz line.
        /// </param>
        /// <param name="rguidEmitter">
        /// The rguid emitter.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RecordLine([In] [MarshalAs(UnmanagedType.LPWStr)] string pszLine, [In] ref Guid rguidEmitter);

        /// <summary>
        /// The get last emitter id.
        /// </summary>
        /// <param name="pguidEmitter">
        /// The pguid emitter.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetLastEmitterId([Out] out Guid pguidEmitter);

        /// <summary>
        /// The replace line.
        /// </summary>
        /// <param name="pszLine">
        /// The psz line.
        /// </param>
        /// <param name="rguidEmitter">
        /// The rguid emitter.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ReplaceLine([In] [MarshalAs(UnmanagedType.LPWStr)] string pszLine, [In] ref Guid rguidEmitter);

        /// <summary>
        /// The record cancel.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RecordCancel();

        /// <summary>
        /// The record pause.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RecordPause();

        /// <summary>
        /// The record resume.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RecordResume();

        /// <summary>
        /// The set code emitted flag.
        /// </summary>
        /// <param name="fFlag">
        /// The f flag.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetCodeEmittedFlag([In] int fFlag);

        /// <summary>
        /// The get code emitted flag.
        /// </summary>
        /// <param name="pfFlag">
        /// The pf flag.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCodeEmittedFlag([Out] out int pfFlag);

        /// <summary>
        /// The get key word.
        /// </summary>
        /// <param name="uiKeyWordId">
        /// The ui key word id.
        /// </param>
        /// <param name="pbstrKeyWord">
        /// The pbstr key word.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetKeyWord([In] uint uiKeyWordId, [Out] [MarshalAs(UnmanagedType.BStr)] out string pbstrKeyWord);

        /// <summary>
        /// The is valid identifier.
        /// </summary>
        /// <param name="pszIdentifier">
        /// The psz identifier.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsValidIdentifier([In] [MarshalAs(UnmanagedType.LPWStr)] string pszIdentifier);

        /// <summary>
        /// The get record mode.
        /// </summary>
        /// <param name="peRecordMode">
        /// The pe record mode.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetRecordMode([Out] out _VSRECORDMODE peRecordMode);

        /// <summary>
        /// The set record mode.
        /// </summary>
        /// <param name="eRecordMode">
        /// The e record mode.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetRecordMode([In] _VSRECORDMODE eRecordMode);

        /// <summary>
        /// The get string literal expression.
        /// </summary>
        /// <param name="pszStringValue">
        /// The psz string value.
        /// </param>
        /// <param name="pbstrLiteralExpression">
        /// The pbstr literal expression.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetStringLiteralExpression([In] [MarshalAs(UnmanagedType.LPWStr)] string pszStringValue, [Out] [MarshalAs(UnmanagedType.BStr)] out string pbstrLiteralExpression);

        /// <summary>
        /// The execute line.
        /// </summary>
        /// <param name="pszLine">
        /// The psz line.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ExecuteLine([In] [MarshalAs(UnmanagedType.LPWStr)] string pszLine);

        /// <summary>
        /// The add type lib ref.
        /// </summary>
        /// <param name="guidTypeLib">
        /// The guid type lib.
        /// </param>
        /// <param name="uVerMaj">
        /// The u ver maj.
        /// </param>
        /// <param name="uVerMin">
        /// The u ver min.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void AddTypeLibRef([In] ref Guid guidTypeLib, [In] uint uVerMaj, [In] uint uVerMin);
    }

    #endregion
}