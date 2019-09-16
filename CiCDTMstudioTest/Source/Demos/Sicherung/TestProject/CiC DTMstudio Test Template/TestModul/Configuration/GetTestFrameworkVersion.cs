// -----------------------------------------------------------------------
// <copyright file="GetTestFrameworkVersion.cs" company="Endress+Hauser Process Solutions AG">
// 
// </copyright>
// -----------------------------------------------------------------------

using System.Globalization;
using System.IO;
using System.Reflection;

namespace CiC_DTMstudio_Test_Template.TestModul.Configuration
{
    using System;

    /// <summary>
    /// Description of GetTestFrameworkVersion.
    /// </summary>
    public static class TestFrameworkVersion
    {
        public static void GetTestFrameworkVersion()
        {
            const string pathToDll = "DLL/";
            string[] fileList = Directory.GetFiles(pathToDll);
            foreach (string filePath in fileList)
            {
                Assembly assembly = Assembly.LoadFrom(filePath);

                string[] separator = { ", " };
                string[] nameParts = assembly.GetName().ToString().Split(separator, StringSplitOptions.None);

                foreach (string part in nameParts)
                {
                    Console.WriteLine(part);
                }
                Console.WriteLine(@"Last modiefied:" + @"	" + File.GetLastWriteTime(filePath).ToString(CultureInfo.InvariantCulture));
                Console.WriteLine(@"------------------------------");
            }
        }
    }
}
