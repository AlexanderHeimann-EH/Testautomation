// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtmMessages.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 10.11.2010
 * Time: 1:39 
 * Last: 25.11.2010
 * Reason: Code documentation
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.DtmMessages.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.DtmMessages.Execution;

    /// <summary>
    /// Class DtmMessages.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class DtmMessages : IDtmMessages
    {
        #region Public Properties

        /// <summary>
        /// Gets all dtm messages.
        /// </summary>
        /// <value>The get all user messages.</value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public List<string> GetAllDtmMessages
        {
            get
            {
                try
                {
                    var resultList = new List<string>();
                    var rowList = new DtmMessagesElements().RowMessages;
                    if (rowList == null)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There is no table available");
                        resultList.Add(string.Empty);
                    }
                    else if (rowList.Count > 0)
                    {
                        // int counter = 0;

// ReSharper disable LoopCanBeConvertedToQuery
                        foreach (var message in rowList)
// ReSharper restore LoopCanBeConvertedToQuery
                        {
                            // resultList.Add(rowList[counter].Cells[1].Text);
                            resultList.Add(message.Cells[1].Text);

                            // counter++;
                        }
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There are no messages available");
                        resultList.Add(string.Empty);
                    }

                    return resultList;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    var resultList = new List<string>();
                    resultList.Add(string.Empty);
                    return resultList;
                }
            }
        }

        /// <summary>
        /// Gets newest message at DTMMessages Area
        /// </summary>
        /// <value>The string get newest user message.</value>
        public string strGetNewestUserMessage
        {
            get
            {
                try
                {
                    if ((new DtmMessagesElements()).RowMessages != null)
                    {
                        int count = (new DtmMessagesElements()).RowMessages.Count;
                        if (count > 0)
                        {
                            return (new DtmMessagesElements()).RowMessages[count - 1].Cells[1].Text;
                            //return (new DtmMessagesElements()).RowMessages[0].Cells[1].Text;
                        }

                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There is no message available");
                        return string.Empty;
                    }

                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There is no table available");
                    return string.Empty;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return string.Empty;
                }
            }
        }

        #endregion
    }
}