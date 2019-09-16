

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V211.Functions.ApplicationArea.Execution
{
    using System;
    using System.Text.RegularExpressions;
    
    class SettingParser
    {
        public string Parse(string input)
        {
            //var pattern = new Regex(@"\W");

            return input.ToLower();//pattern.Replace(input, string.Empty).ToLower();
        }

        /// <summary>
        /// Checks, after parsing, if two strings are equal
        /// </summary>
        /// <param name="input1">The first string argument</param>
        /// <param name="input2">The second string argument</param>
        /// <returns>
        /// True, if both strings are equal
        /// </returns>
        public bool Compare(string input1, string input2)
        {
            if (this.Parse(input1) == this.Parse(input2))
            {
                return true;
            }
            return false;
        }
    }
}
