//------------------------------------------------------------------------------
// <copyright file="AddRemoveProgramsElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.OSSpecific
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    ///     Description of AddRemoveProgramsElements.
    /// </summary>
    public static class AddRemoveProgramsElements
    {
        /// <summary>
        /// Gets text SupportInformation
        /// </summary>
        /// <returns>
        ///     <br>Text: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static Text TxtSupportInformation
        {
            get
            {
                try
                {
                    Text text;
                    Host.Local.TryFindSingle(
                        AddRemoveProgramsPaths.SupportInformation,
                        DefaultValues.iTimeoutShort,
                        out text);
                    return text;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets button Print
        /// </summary>
        /// <param name="program">
        /// The program.
        /// </param>
        /// <returns>
        /// <br>list Item: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ListItem LiItem(string program)
        {
            try
            {
                bool entryFound = false;
                int counter = 0;
                ListItem listItem = null;

                IList<ListItem> programList = Host.Local.Find<ListItem>(AddRemoveProgramsPaths.ListElement, DefaultValues.iTimeoutShort);
                while (!entryFound)
                {
                    string programName = programList[counter].Text;
                    if (counter >= programList.Count)
                    {
                        break;
                    }

// ReSharper disable StringCompareToIsCultureSpecific
                    if (program.CompareTo(programName) == 0)
// ReSharper restore StringCompareToIsCultureSpecific
                    {
                        Debug.Print("Element found: " + programName);
                        listItem = programList[counter];
                        entryFound = true;
                    }
                    else
                    {
                        Keyboard.Press(Keys.Down);
                    }

                    Debug.Print(programName);
                    counter++;
                }

                return listItem;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}