// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The native methods for the access to the registry.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Registry
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    using Microsoft.Win32.SafeHandles;

    using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

    /// <summary>
    /// The native methods for the access to the registry.
    /// </summary>
    public static class NativeMethods
    {
        /// <summary>
        /// Opens the specified registry key.
        /// </summary>
        /// <param name="hKey">A handle to an open registry key.</param>
        /// <param name="lpSubKey">The name of the registry sub key to be opened.</param>
        /// <param name="ulOptions">This parameter is reserved and must be zero.</param>
        /// <param name="samDesired">A mask that specifies the desired access rights to the key.</param>
        /// <param name="phkResult">Pointer to a variable that receives a handle to the opened key. When you no longer need the returned handle, call the RegCloseKey function to close it..</param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "OK here.")]
        [DllImport("advapi32.dll", EntryPoint = "RegOpenKeyEx")]
        internal static extern int RegOpenKeyEx(UIntPtr hKey, string lpSubKey, int ulOptions, int samDesired, ref UIntPtr phkResult);

        /// <summary>
        /// Retrieves information about the specified registry key.
        /// </summary>
        /// <param name="hKey">Retrieves information about the specified registry key.</param>
        /// <param name="lpClass">A pointer to a buffer that receives the key class. This parameter can be NULL.</param>
        /// <param name="lpcbClass">A pointer to a variable that specifies the size of the buffer pointed to by the lpClass parameter, in characters.</param>
        /// <param name="lpReserved">This parameter is reserved and must be NULL.</param>
        /// <param name="lpcSubKeys">A pointer to a variable that receives the number of sub keys that are contained by the specified key. This parameter can be NULL.</param>
        /// <param name="lpcbMaxSubKeyLen">A pointer to a variable that receives the size of the key's sub key with the longest name, in Unicode characters, not including the terminating null character. This parameter can be NULL.</param>
        /// <param name="lpcbMaxClassLen">A pointer to a variable that receives the size of the longest string that specifies a sub key class, in Unicode characters.</param>
        /// <param name="lpcValues">A pointer to a variable that receives the number of values that are associated with the key. This parameter can be NULL.</param>
        /// <param name="lpcbMaxValueNameLen">A pointer to a variable that receives the size of the key's longest value name, in Unicode characters. The size does not include the terminating null character. This parameter can be NULL.</param>
        /// <param name="lpcbMaxValueLen">A pointer to a variable that receives the size of the longest data component among the key's values, in bytes. This parameter can be NULL.</param>
        /// <param name="lpcbSecurityDescriptor">A pointer to a variable that receives the size of the key's security descriptor, in bytes. This parameter can be NULL.</param>
        /// <param name="lpftLastWriteTime">A pointer to a FILETIME structure that receives the last write time. This parameter can be NULL.</param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1625:ElementDocumentationMustNotBeCopiedAndPasted", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "OK here.")]
        [DllImport("advapi32.dll", EntryPoint = "RegQueryInfoKey")]
        internal static extern int RegQueryInfoKey(UIntPtr hKey, string lpClass, ref int lpcbClass, IntPtr lpReserved, ref int lpcSubKeys, ref int lpcbMaxSubKeyLen, ref int lpcbMaxClassLen, ref int lpcValues, ref int lpcbMaxValueNameLen, ref int lpcbMaxValueLen, ref int lpcbSecurityDescriptor, ref FILETIME lpftLastWriteTime);

        /// <summary>
        /// Closes a handle to the specified registry key.
        /// </summary>
        /// <param name="hKey">A handle to the open key to be closed. The handle must have been opened by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, RegOpenKeyTransacted, or RegConnectRegistry function.</param>
        /// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "OK here.")]
        [DllImport("advapi32.dll", EntryPoint = "RegCloseKey")]
        internal static extern int RegCloseKey(UIntPtr hKey);

        /// <summary>
        /// Looks up a CLSID in the registry, given a ProgID.
        /// </summary>
        /// <param name="progId">[in] Pointer to the ProgID whose CLSID is requested.</param>
        /// <param name="guid">[out] Pointer to the retrieved CLSID on return.</param>
        /// <returns>S_OK if CLSID was retrieved successfully. CO_E_CLASSSTRING if the registered CLSID for the ProgID is invalid. REGDB_E_WRITEREGDB if an error occurred writing the CLSID to the registry.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "OK here.")]
        [DllImport("ole32.dll")]
        internal static extern int CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] string progId, out Guid guid);

        /// <summary>
        /// Converts a CLSID into a string of printable characters. Different CLSIDs always convert to different strings.
        /// </summary>
        /// <param name="clsid">[in] CLSID to be converted.</param>
        /// <returns>[out] Address of LPOLESTR pointer variable that receives a pointer to the resulting string.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "OK here.")]
        [DllImport("ole32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        internal static extern string StringFromCLSID([MarshalAs(UnmanagedType.LPStruct)] Guid clsid);

        /// <summary>
        /// Retrieves the ProgID for a given CLSID.
        /// </summary>
        /// <param name="clsid">[in] Specifies the CLSID for which the ProgID is requested.</param>
        /// <param name="lplpszProgId">[out] Address of LPOLESTR pointer variable that receives a pointer to the ProgID string.</param>
        /// <returns>S_OK if the ProgID was returned successfully. REGDB_E_CLASSNOTREG if class not registered in the registry. REGDB_E_READREGDB if error reading registry.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "OK here.")]
        [DllImport("ole32.dll")]
        internal static extern int ProgIDFromCLSID([In] ref Guid clsid, [MarshalAs(UnmanagedType.LPWStr)] out string lplpszProgId);

        /// <summary>
        /// The reg notify change key value.
        /// </summary>
        /// <param name="hKey">The h key.</param>
        /// <param name="bWatchSubtree">The b watch subtree.</param>
        /// <param name="dwNotifyFilter">The dw notify filter.</param>
        /// <param name="hEvent">The h event.</param>
        /// <param name="fAsynchronous">The f asynchronous.</param>
        /// <returns>The registry notify change key value.</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "OK here.")]
        [SuppressMessage("Microsoft.Interoperability", "CA1414:MarkBooleanPInvokeArgumentsWithMarshalAs", Justification = "OK here.")]
        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern int RegNotifyChangeKeyValue(UIntPtr hKey, bool bWatchSubtree, RegChangeNotifyFilter dwNotifyFilter, SafeWaitHandle hEvent, bool fAsynchronous);
    }
}
