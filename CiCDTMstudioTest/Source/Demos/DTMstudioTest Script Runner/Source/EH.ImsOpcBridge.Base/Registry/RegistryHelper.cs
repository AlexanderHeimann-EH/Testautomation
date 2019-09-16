// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistryHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Registry
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text.RegularExpressions;

    using EH.ImsOpcBridge.Helpers;
    using EH.ImsOpcBridge.Properties;

    using log4net;

    using Microsoft.Win32;

    /// <summary>
    /// Contains helper methods to work on the windows registry.
    /// </summary>
    public static class RegistryHelper
    {
        #region Constants and Fields

        /// <summary>
        /// The Logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list containing ProgIds of all installed DTMs FDT 1.2.x.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK here.")]
        public static ReadOnlyCollection<string> InstalledDtmProgIds
        {
            get
            {
                var retValue = new List<string>();

                try
                {
                    var dtmComNet11Guids = GetClassesOfImplCategory(new[] { new Guid(@"14400d5b-d6dc-43f7-b141-64cc5c05a39f") });
                    var dtmNet20Guids = GetClassesOfImplCategory(new[] { new Guid(@"33e60e5f-da94-4e3d-a5f0-41e4af725c7c") });

                    var dtmGuidsList = new List<Guid>();

                    foreach (var guid in dtmComNet11Guids)
                    {
                        if (!dtmGuidsList.Contains(guid))
                        {
                            dtmGuidsList.Add(guid);
                        }
                    }

                    foreach (var guid in dtmNet20Guids)
                    {
                        if (!dtmGuidsList.Contains(guid))
                        {
                            dtmGuidsList.Add(guid);
                        }
                    }

                    var dtmGuids = dtmGuidsList.ToArray();

                    foreach (var dtmGuid in dtmGuids)
                    {
                        try
                        {
                            var progId = GetProgIdFromClassId(dtmGuid);

                            if (progId != null)
                            {
                                // Remove the version part of the prog id
                                progId = Regex.Replace(progId, @"^(.*)\.\d+$", @"$1");
                                retValue.Add(progId);
                            }
                            else
                            {
                                if (Logger.IsErrorEnabled)
                                {
                                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.DtmWithClassId_DoesNotHaveAnyProgIdDTMHasNotBeenInstalledUninstalledProperly, dtmGuid);
                                    Logger.Error(message);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (Logger.IsErrorEnabled)
                            {
                                var message = string.Format(CultureInfo.CurrentUICulture, Resources.DtmWithClassId_DoesNotHaveAnyProgIdDTMHasNotBeenInstalledUninstalledProperly, dtmGuid);
                                Logger.Error(message, ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (Logger.IsErrorEnabled)
                    {
                        Logger.Error(Resources.AnExceptionOccurredDuringDeterminationOfDtmProgIds, ex);
                    }
                }

                return new ReadOnlyCollection<string>(retValue);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Returns the Class Id of a COM class with the specified ProgId
        /// </summary>
        /// <param name="progId">ProgId of the COM class</param>
        /// <returns>ClassId of the COM class with the specified progId.</returns>
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "Ok here.")]
        public static Guid GetClassIdFromProgId(string progId)
        {
            Guid clsid;

            NativeMethods.CLSIDFromProgID(progId, out clsid);

            return clsid;
        }

        /// <summary>
        /// Returns the installation path of a COM class with specified ClassId
        /// </summary>
        /// <param name="clsid">ClassId of the COM class.</param>
        /// <returns>Installation path of COM component with specified class ID.</returns>
        public static string GetInstallationPath(Guid clsid)
        {
            // ReSharper disable LocalizableElement
            var installationPath = GetRegistryKeyValue(clsid, @"\InprocServer32", string.Empty);

            if (installationPath.Length > 0)
            {
                return installationPath;
            }

            installationPath = GetRegistryKeyValue(clsid, @"\LocalServer32", string.Empty);

            // ReSharper restore LocalizableElement
            return installationPath;
        }

        /// <summary>
        /// Returns the Class Id of a COM class with specified ProgId.
        /// </summary>
        /// <param name="classId">ClassId of the COM class.</param>
        /// <returns>ProgId of the COM class with the specified ClassId.</returns>
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "Ok here.")]
        public static string GetProgIdFromClassId(Guid classId)
        {
            string progId;

            NativeMethods.ProgIDFromCLSID(ref classId, out progId);

            return progId;
        }

        /// <summary>
        /// Gets the date and time when a COM class has been registered in the windows registry.
        /// </summary>
        /// <param name="progId">ProgId of the COM class, the registration date is asked for.</param>
        /// <returns>Date and time when a COM class has been registered</returns>
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "Ok here.")]
        public static DateTime? GetRegistrationDate(string progId)
        {
            var key = UIntPtr.Zero;
            var pointerClass = string.Empty;
            var lpcbClass = 0;
            var subKey = 0;
            var maxSubkeyLen = 0;
            var maxSubkeyClassLen = 0;
            var valueNames = 0;
            var maxValueNameLen = 0;
            var maxValueLen = 0;
            var lpcbSecurityDescriptor = 0;

            FILETIME lpftLastWriteTime;

            lpftLastWriteTime.dwHighDateTime = 0;
            lpftLastWriteTime.dwLowDateTime = 0;

            unchecked
            {
                NativeMethods.RegOpenKeyEx((UIntPtr)0x80000000, progId, 0, 0x0001, ref key);
            }

            if (key != UIntPtr.Zero)
            {
                try
                {
                    NativeMethods.RegQueryInfoKey(key, pointerClass, ref lpcbClass, IntPtr.Zero, ref subKey, ref maxSubkeyLen, ref maxSubkeyClassLen, ref valueNames, ref maxValueNameLen, ref maxValueLen, ref lpcbSecurityDescriptor, ref lpftLastWriteTime);
                }
                finally
                {
                    NativeMethods.RegCloseKey(key);
                }
            }

            if ((lpftLastWriteTime.dwHighDateTime == 0) && (lpftLastWriteTime.dwLowDateTime == 0))
            {
                return null;
            }

            var ft = (((long)lpftLastWriteTime.dwHighDateTime) << 32) + lpftLastWriteTime.dwLowDateTime;

            return DataSetHelper.ToSafeDbDateTime(DateTime.FromFileTimeUtc(ft));
        }

        /// <summary>
        /// Returns the installation path of a COM class with specified class Id
        /// </summary>
        /// <param name="clsid">ClassId of the COM class.</param>
        /// <param name="subPath">Sub path to read from "CLSID\[GUID]".</param>
        /// <param name="keyName">Name of the key to read, empty string for default value.</param>
        /// <returns>Value of the key.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Ok here.")]
        public static string GetRegistryKeyValue(Guid clsid, string subPath, string keyName)
        {
            var clsId = NativeMethods.StringFromCLSID(clsid);

            if (clsId.Length > 0)
            {
                var classesRoot = Registry.ClassesRoot;

                // ReSharper disable LocalizableElement
                var regKeyName = string.Format(CultureInfo.InvariantCulture, @"CLSID\{0}{1}", clsId, subPath);

                // ReSharper restore LocalizableElement
                var inprocServer32 = classesRoot.OpenSubKey(regKeyName, false);

                if (inprocServer32 != null)
                {
                    var value = inprocServer32.GetValue(keyName) as string;
                    return value ?? string.Empty;
                }
            }

            return string.Empty;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the classIds of the COM classes implementing the specified category ids.
        /// </summary>
        /// <param name="catIds">Category ids</param>
        /// <returns>Class Ids</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Ok here.")]
        internal static Guid[] GetClassesOfImplCategory(Guid[] catIds)
        {
            var retValue = new List<Guid>();

            try
            {
                var classesRoot = Registry.ClassesRoot;
                var clsidKey = classesRoot.OpenSubKey(@"CLSID", false);

                if (clsidKey == null)
                {
                    return retValue.ToArray();
                }

                var subKeyNames = clsidKey.GetSubKeyNames();

                foreach (var subKeyName in subKeyNames)
                {
                    try
                    {
                        // ReSharper disable LocalizableElement
                        var implCategoriesSubKey = clsidKey.OpenSubKey(string.Format(CultureInfo.InvariantCulture, @"{0}\Implemented Categories", subKeyName), false);

                        // ReSharper restore LocalizableElement
                        if (implCategoriesSubKey != null)
                        {
                            var implCatIds = implCategoriesSubKey.GetSubKeyNames();
                            var isOkToAdd = true;

                            foreach (var catId in catIds)
                            {
                                var found = false;
                                var catIdString = catId.ToString();

                                foreach (var implCatId in implCatIds)
                                {
                                    string implCatIdString;

                                    // ReSharper disable LocalizableElement
                                    if (implCatId.StartsWith(@"{", StringComparison.OrdinalIgnoreCase))
                                    {
                                        // ReSharper restore LocalizableElement
                                        implCatIdString = implCatId.Substring(1, implCatId.Length - 2);
                                    }
                                    else
                                    {
                                        implCatIdString = implCatId;
                                    }

                                    if (implCatIdString.Equals(catIdString, StringComparison.OrdinalIgnoreCase))
                                    {
                                        found = true;
                                        break;
                                    }
                                }

                                if (!found)
                                {
                                    isOkToAdd = false;
                                    break;
                                }
                            }

                            if (isOkToAdd)
                            {
                                retValue.Add(new Guid(subKeyName));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (Logger.IsErrorEnabled)
                        {
                            var message = string.Format(CultureInfo.InvariantCulture, Resources.ExceptionOccurredDuringDeterminationOfComClassesForComCategoryAt_, subKeyName);
                            Logger.Error(message, ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Logger.IsErrorEnabled)
                {
                    Logger.Error(Resources.ExceptionOccurredDuringDeterminationOfComClassesForComCategory, ex);
                }
            }

            return retValue.ToArray();
        }

        #endregion
    }
}
