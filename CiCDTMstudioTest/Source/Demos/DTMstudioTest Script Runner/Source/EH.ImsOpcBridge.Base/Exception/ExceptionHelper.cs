// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The Exception Helper class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Exception
{
    using System;
    using System.Text;

    using EH.ImsOpcBridge.Properties;

    /// <summary>
    /// The Exception Helper class.
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Builds the exception message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The exception</param>
        /// <returns>The text showing information about the exception.</returns>
        public static string BuildExceptionMessage(string message, Exception ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException(@"ex");
            }
            
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(message);
            stringBuilder.AppendLine();

            var currentException = ex;

            while (currentException != null)
            {
                stringBuilder.Append(Resources.ExceptionInfo);
                stringBuilder.AppendLine(currentException.Message);
                currentException = currentException.InnerException;
            }

            stringBuilder.AppendLine(Resources.Stack);
            stringBuilder.AppendLine(ex.StackTrace);

            return stringBuilder.ToString();
        }
    }
}
