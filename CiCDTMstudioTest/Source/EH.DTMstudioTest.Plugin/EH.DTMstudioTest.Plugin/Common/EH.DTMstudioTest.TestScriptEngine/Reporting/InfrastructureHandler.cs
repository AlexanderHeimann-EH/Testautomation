// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfrastructureHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The infrastructure handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.TestScriptEngine.Reporting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using EH.DTMstudioTest.Common.Interfaces;
    using EH.DTMstudioTest.Common.TransportObjects.AssemblyData.Proxy;
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;
    using EH.DTMstudioTest.TestScriptEngine.DataTypes;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    /// The infrastructure handler.
    /// </summary>
    public class InfrastructureHandler
    {
        #region Constants

        /// <summary>
        /// The report variable data.
        /// </summary>
        public const string ReportVariableData = "\r\n" + 
            "fdtdevicetypename=\"$(FDTDeviceTypeName)\"" + "\r\n" + 
            "devicetypeprojectname=\"$(DeviceTypeProjectName)\"" + "\r\n" + 
            "devicetypetestprojectname=\"$(DeviceTypeTestProjectName)\"" + "\r\n" + 
            "firmware=\"$(FirmwareName)\"" + "\r\n" + 
            "firmwareversion=\"$(FirmwareVersion)\"" + "\r\n" + 
            "firewarebuildnumber=\"$(FirmwareBuildNumber)\"" + "\r\n" + 
            "codiaframework=\"$(CoDIAFrameworkVersion)\"" + "\r\n" + 
            "cwcomponents=\"$(CWComponentsVersion)\"" + "\r\n" + 
            "ehcomponents=\"$(EHComponentsVersion)\"" + "\r\n" + 
            "testlibrary=\"$(TestLibrary)\"" + "\r\n" + 
            "testframework=\"$(TestFramework)\"" + "\r\n" + 
            "resultoftest=\"$(ResultOfTest)\"" + "\r\n" + 
            "nameoftester=\"$(NameOfTester)\"" + "\r\n" + 
            "totaltestcasefailedcount=\"$(TotalTestCaseFailedCount)\"" + "\r\n" + 
            "totaltestcasesuccesscount=\"$(TotalTestCaseSuccessCount)\"";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy eh report default style.
        /// </summary>
        /// <param name="sourcePath">
        /// The source path.
        /// </param>
        /// <param name="targetPath">
        /// The target path.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        public static void CopyCustomizedReportDefaultStyle(string sourcePath, string targetPath, string fileName)
        {
            var source = Path.Combine(sourcePath, string.Format("{0}.css", fileName));
            var target = Path.Combine(targetPath, string.Format("{0}.css", fileName));
            if (File.Exists(source) && !File.Exists(target))
            {
                File.Copy(source, target, true);
                CheckForCopy(target);
            }

            source = Path.Combine(sourcePath, string.Format("{0}.png", fileName));
            target = Path.Combine(targetPath, string.Format("{0}.png", fileName));
            if (File.Exists(source) && !File.Exists(target))
            {
                File.Copy(source, target, true);
                CheckForCopy(target);
            }

            source = Path.Combine(sourcePath, string.Format("{0}.xsl", fileName));
            target = Path.Combine(targetPath, string.Format("{0}.xsl", fileName));
            if (File.Exists(source) && !File.Exists(target))
            {
                File.Copy(source, target, true);
                CheckForCopy(target);
            }
        }

        /// <summary>
        /// The delete ranorex style.
        /// </summary>
        /// <param name="reportFile">
        /// The report file.
        /// </param>
        public static void DeleteRanorexStyle(string reportFile)
        {
            try
            {
                var file = Path.Combine(reportFile, "RanorexReport.css");

                if (File.Exists(file))
                {
                    File.Delete(file);
                }

                file = Path.Combine(reportFile, "RanorexReport.xsl");

                if (File.Exists(file))
                {
                    File.Delete(file);
                }

                file = Path.Combine(reportFile, "RanorexReport.png");

                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            catch (Exception exception)
            {
                Report.Error("Critical Error: DeleteRanorexStyle: " + exception.Message);
                throw;
            }
        }

        /// <summary>
        /// The export test result.
        /// </summary>
        /// <param name="currentMainReportFolder">
        /// The current main report folder.
        /// </param>
        /// <param name="testName">
        /// The test name.
        /// </param>
        /// <param name="dtMstudioTestTempData">
        /// The dtm studio test temp data.
        /// </param>
        public static void ExportTestResult(string currentMainReportFolder, string testName, DTMstudioTestData dtMstudioTestTempData)
        {
            if (File.Exists(dtMstudioTestTempData.DeviceTypeTestProject.ExportTestResultAssembly))
            {
                try
                {
                    var assemblyLoader = new AppDomainAssemblyLoader();

                    assemblyLoader.ExportTestResult(new FileInfo(dtMstudioTestTempData.DeviceTypeTestProject.ExportTestResultAssembly), currentMainReportFolder, testName, dtMstudioTestTempData);
                    assemblyLoader.UnloadAppDomain();
                }
                catch (Exception exception)
                {
                    Report.Error("Critical Error: ExportTestResult: " + exception.Message);
                }
            }
        }

        /// <summary>
        /// The get firmware add info table body.
        /// </summary>
        /// <param name="addInformationItems">
        /// The add information items.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetFirmwareAddInfoTableBody(List<IFirmwareAddInformationItem> addInformationItems)
        {
            var htmlCode = string.Empty;

            foreach (var addInformationitem in addInformationItems)
            {
                htmlCode += "<tr>" + "\r\n" + "<td>" + "\r\n" + "<i class=\"field\">" + "\r\n" + addInformationitem.Key + "\r\n" + "</i>" + "\r\n" + "</td>" + "\r\n" + "<td>" + "\r\n" + "<font color=\"#009EE3\">" + "\r\n" + addInformationitem.Value + "</font>" + "</td>" + "\r\n" + "</tr>";
            }

            return htmlCode;
        }

        /// <summary>
        /// The get firmware add info table header.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetFirmwareAddInfoTableHeader()
        {
            return "<tr>" + "\r\n" + "<td  width=\"150\">" + "\r\n" + "<i class=\"field\">" + "\r\n" + "<p>Additional Information</p>" + "\r\n" + "</i>" + "\r\n" + "</td>" + "\r\n" + "<td>" + "\r\n" + "<i class=\"field\">" + "\r\n" + "<p></p>" + "\r\n" + "</i>" + "\r\n" + "</td>" + "\r\n" + "</tr>";
        }

        /// <summary>
        /// The get firmware html code.
        /// </summary>
        /// <param name="addInformationItems">
        /// The add information items.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetFirmwareHTMLCode(List<IFirmwareAddInformationItem> addInformationItems)
        {
            var htmlCode = string.Empty;

            htmlCode += GetFirmwareAddInfoTableHeader();
            htmlCode += GetFirmwareAddInfoTableBody(addInformationItems);

            return htmlCode;
        }

        /// <summary>
        /// The get table body.
        /// </summary>
        /// <param name="deviceFunctions">
        /// The device functions.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetModulTableBody(List<DeviceFunction> deviceFunctions)
        {
            var htmlCode = string.Empty;

            foreach (var deviceFunction in deviceFunctions)
            {
                if (deviceFunction.Active == true && deviceFunction.FrameworkMappingName != string.Empty)
                {
                    htmlCode += "<tr>" + "\r\n" + "<td>" + "\r\n" + "<i class=\"field\">" + "\r\n" + deviceFunction.FrameworkMappingName + "\r\n" + "</i>" + "\r\n" + "</td>" + "\r\n" + "<td>" + "\r\n" + "<font color=\"#009EE3\">" + "\r\n" + "YES" + "</font>" + "</td>" + "\r\n" + "</tr>";
                }
            }

            return htmlCode;
        }

        /// <summary>
        /// The get table header.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetModulTableHeader()
        {
            return "<tr>" + "\r\n" + "<td  width=\"150\">" + "\r\n" + "<i class=\"field\">" + "\r\n" + "<p>Modul</p>" + "\r\n" + "</i>" + "\r\n" + "</td>" + "\r\n" + "<td>" + "\r\n" + "<i class=\"field\">" + "\r\n" + "<p>Supported</p>" + "\r\n" + "</i>" + "\r\n" + "</td>" + "\r\n" + "</tr>";
        }

        /// <summary>
        /// The get html code.
        /// </summary>
        /// <param name="deviceFunctions">
        /// The device functions.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetModuleHTMLCode(List<DeviceFunction> deviceFunctions)
        {
            var htmlCode = string.Empty;

            htmlCode += GetModulTableHeader();
            htmlCode += GetModulTableBody(deviceFunctions);

            return htmlCode;
        }

        /// <summary>
        /// The insert modul version.
        /// </summary>
        /// <param name="fileName">
        /// The current main report folder.
        /// </param>
        /// <param name="deviceFunctions">
        /// The device functions.
        /// </param>
        /// <param name="additionalInformations">
        /// The additional Informations.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public static void InsertHTMLCodeToReport(string fileName, List<DeviceFunction> deviceFunctions, List<IFirmwareAddInformationItem> additionalInformations)
        {
            var htmlCode = string.Empty;

            if (deviceFunctions.Count > 0)
            {
                htmlCode = GetModuleHTMLCode(deviceFunctions);
            }

            ParseReportTransformation(fileName, htmlCode, "<!-- $(Modules) -->");

            htmlCode = string.Empty;

            if (additionalInformations.Count > 0)
            {
                htmlCode = GetFirmwareHTMLCode(additionalInformations);
            }

            ParseReportTransformation(fileName, htmlCode, "<!-- $(FirmwareAddInfos) -->");
        }

        /// <summary>
        /// The insert report data.
        /// </summary>
        /// <param name="reportFile">
        /// The report file.
        /// </param>
        /// <param name="dtmStudioTestData">
        /// The dtm studio test data.
        /// </param>
        public static void InsertReportData(string reportFile, DTMstudioTestData dtmStudioTestData)
        {
            var reportFileData = reportFile + ".data";
            if (File.Exists(reportFileData))
            {
                var reader = File.OpenText(reportFileData);
                var fileString = reader.ReadToEnd();
                reader.Close();

                var startIndex = fileString.IndexOf("<activity", StringComparison.Ordinal) + "<activity".Length;
                fileString = fileString.Insert(startIndex, ReportVariableData);

                fileString = ParseVariablen(fileString, dtmStudioTestData);

                var writer = new StreamWriter(reportFileData);
                writer.Write(fileString);
                writer.Close();
            }
        }

        /// <summary>
        /// The insert duration.
        /// </summary>
        /// <param name="reportFile">
        /// The report file.
        /// </param>
        /// <param name="duration">
        /// The duration.
        /// </param>
        public static void InsertDuration(string reportFile, TimeSpan duration)
        {
            var reportFileData = reportFile + ".data";
            if (File.Exists(reportFileData))
            {
                var reader = File.OpenText(reportFileData);
                var fileString = reader.ReadToEnd();
                reader.Close();

                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}", duration.Hours, duration.Minutes, duration.Seconds);
                fileString = fileString.Replace("duration=\"0ms\"", "duration=\"" + elapsedTime + " (HH:mm:ss)\"");

                var writer = new StreamWriter(reportFileData);
                writer.Write(fileString);
                writer.Close();
            }
        }
        

        /// <summary>
        /// The manipulate detail report layout.
        /// </summary>
        /// <param name="reportFile">
        /// The report file.
        /// </param>
        public static void ManipulateDetailReportLayout(string reportFile)
        {
            if (File.Exists(reportFile))
            {
                var reader = File.OpenText(reportFile);
                var fileString = reader.ReadToEnd();
                reader.Close();

                fileString = fileString.Replace("show: true,", "show: false,");

                var writer = new StreamWriter(reportFile);
                writer.Write(fileString);
                writer.Close();
            }
        }

        /// <summary>
        /// The manipulate overview report layout.
        /// </summary>
        /// <param name="executionObject">
        /// The execution Object.
        /// </param>
        public static void ManipulateOverviewReportLayout(ExecutionObject executionObject)
        {
            if (File.Exists(executionObject.ReportPathAndFileOverviewTemp))
            {
                var reader = File.OpenText(executionObject.ReportPathAndFileOverviewTemp);
                var fileString = reader.ReadToEnd();
                reader.Close();

                string totalFailedCountOld  = "var failed  = parseInt($(" + (char)34 + "#testCasesPie" + (char)34 + ").attr('totalfailedcount'));";
                string totalFailedCountNew  = "var failed  = parseInt($(" + (char)34 + "#testCasesPie" + (char)34 + ").attr('totaltestcasefailedcount'));";
                string totalSuccessCountOld = "var success = parseInt($(" + (char)34 + "#testCasesPie" + (char)34 + ").attr('totalsuccesscount'));";
                string totalSuccessCountNew = "var success = parseInt($(" + (char)34 + "#testCasesPie" + (char)34 + ").attr('totaltestcasesuccesscount'));";
                string totalIgnoredCountOld = "var ignored = parseInt($(" + (char)34 + "#testCasesPie" + (char)34 + ").attr('totalblockedcount'));";
                string totalIgnoredCountNew = "var ignored = parseInt($(" + (char)34 + "#testCasesPie" + (char)34 + ").attr('totalwarningcount'));";
                string blockedIgnoredOld = "line1.push([ignored + 'x Blocked', ignored]);";
                string blockedIgnoredNew = "line1.push([ignored + 'x Warning', ignored]);";
                
                fileString = fileString.Replace(totalFailedCountOld, totalFailedCountNew);
                fileString = fileString.Replace(totalSuccessCountOld, totalSuccessCountNew);

                fileString = fileString.Replace(totalIgnoredCountOld, totalIgnoredCountNew);
                fileString = fileString.Replace(blockedIgnoredOld, blockedIgnoredNew);

                var writer = new StreamWriter(executionObject.ReportPathAndFileOverviewTemp);
                writer.Write(fileString);
                writer.Close();
            }
        }

        /// <summary>
        /// The parse report transformation.
        /// </summary>
        /// <param name="reportFile">
        /// The report file.
        /// </param>
        /// <param name="htmlCode">
        /// The html code.
        /// </param>
        /// <param name="oldValue">
        /// The old value.
        /// </param>
        public static void ParseReportTransformation(string reportFile, string htmlCode, string oldValue)
        {
            if (File.Exists(reportFile))
            {
                var reader = File.OpenText(reportFile);
                var fileString = reader.ReadToEnd();
                reader.Close();

                fileString = fileString.Replace(oldValue, htmlCode);

                var writer = new StreamWriter(reportFile);
                writer.Write(fileString);
                writer.Close();
            }
        }

        /// <summary>
        /// The parse report.
        /// </summary>
        /// <param name="fileStream">
        /// The file stream.
        /// </param>
        /// <param name="dtmStudioTestTempData">
        /// The dtm studio test temp data.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ParseVariablen(string fileStream, DTMstudioTestData dtmStudioTestTempData)
        {
            fileStream = fileStream.Replace("$(DeviceTypeTestProjectName)", !string.IsNullOrEmpty(dtmStudioTestTempData.DeviceTypeTestProject.Name) ? dtmStudioTestTempData.DeviceTypeTestProject.Name : "-");
            fileStream = fileStream.Replace("$(DeviceTypeProjectName)", !string.IsNullOrEmpty(dtmStudioTestTempData.DeviceTypeTestProject.Name) ? dtmStudioTestTempData.DeviceTypeProject.Name : "-");

            fileStream = fileStream.Replace("$(FDTDeviceTypeName)", !string.IsNullOrEmpty(dtmStudioTestTempData.DeviceTypeProject.FDTDeviceTypeName) ? dtmStudioTestTempData.DeviceTypeProject.FDTDeviceTypeName : "-");

            fileStream = fileStream.Replace("$(FirmwareName)", !string.IsNullOrEmpty(dtmStudioTestTempData.ReportData.FirmwareInformation.Name) ? dtmStudioTestTempData.ReportData.FirmwareInformation.Name : "-");
            fileStream = fileStream.Replace("$(FirmwareVersion)", !string.IsNullOrEmpty(dtmStudioTestTempData.ReportData.FirmwareInformation.Version) ? dtmStudioTestTempData.ReportData.FirmwareInformation.Version : "-");
            fileStream = fileStream.Replace("$(FirmwareBuildNumber)", !string.IsNullOrEmpty(dtmStudioTestTempData.ReportData.FirmwareInformation.BuildNumber) ? dtmStudioTestTempData.ReportData.FirmwareInformation.BuildNumber : "-");

            fileStream = fileStream.Replace("$(TestLibrary)", !string.IsNullOrEmpty(dtmStudioTestTempData.TestLibrary.TestLibraryVersion) ? dtmStudioTestTempData.TestLibrary.TestLibraryVersion : "-");
            fileStream = fileStream.Replace("$(TestFramework)", !string.IsNullOrEmpty(dtmStudioTestTempData.TestLibrary.TestPackageVersion) ? dtmStudioTestTempData.TestLibrary.TestPackageVersion : "-");

            fileStream = fileStream.Replace("$(NameOfTester)", !string.IsNullOrEmpty(dtmStudioTestTempData.ReportData.NameOfTester) ? dtmStudioTestTempData.ReportData.NameOfTester : "-");
            fileStream = fileStream.Replace("$(ResultOfTest)", !string.IsNullOrEmpty(dtmStudioTestTempData.ReportData.ResultOfTest) ? dtmStudioTestTempData.ReportData.ResultOfTest : "-");

            fileStream = fileStream.Replace("$(TotalTestCaseFailedCount)", !string.IsNullOrEmpty(dtmStudioTestTempData.ReportData.TotalFailedCount.ToString()) ? dtmStudioTestTempData.ReportData.TotalFailedCount.ToString() : "0");
            fileStream = fileStream.Replace("$(TotalTestCaseSuccessCount)", !string.IsNullOrEmpty(dtmStudioTestTempData.ReportData.TotalSuccessCount.ToString()) ? dtmStudioTestTempData.ReportData.TotalSuccessCount.ToString() : "0");


            //string durationOld = "duration=" + (char)34 + "0ms" + (char)34;
            //string durationNew = "duration=" + (char)34 + executionObject.Duration + (char)34;

            var coDIAFramework = false;
            var cwComponents = false;
            var ehEHComponents = false;

            foreach (var components in dtmStudioTestTempData.DeviceTypeProject.DeviceTypeFramework.FrameworkComponents)
            {
                if (components.Name == "CoDIAFramework")
                {
                    fileStream = fileStream.Replace("$(CoDIAFrameworkVersion)", !string.IsNullOrEmpty(components.VersionString) ? components.VersionString : "-");
                    coDIAFramework = true;
                }

                if (components.Name == "CWComponents")
                {
                    fileStream = fileStream.Replace("$(CWComponentsVersion)", !string.IsNullOrEmpty(components.VersionString) ? components.VersionString : "-");
                    cwComponents = true;
                }

                if (components.Name == "EHComponents")
                {
                    fileStream = fileStream.Replace("$(EHComponentsVersion)", !string.IsNullOrEmpty(components.VersionString) ? components.VersionString : "-");
                    ehEHComponents = true;
                }
            }

            if (coDIAFramework == false)
            {
                fileStream = fileStream.Replace("$(CoDIAFrameworkVersion)", "-");
            }

            if (cwComponents == false)
            {
                fileStream = fileStream.Replace("$(CWComponentsVersion)", "-");
            }

            if (ehEHComponents == false)
            {
                fileStream = fileStream.Replace("$(EHComponentsVersion)", "-");
            }

            return fileStream;
        }

        /// <summary>
        /// The parse report style sheet.
        /// </summary>
        /// <param name="reportFile">
        /// The report file.
        /// </param>
        /// <param name="styleSheet">
        /// The style sheet.
        /// </param>
        public static void ReplaceReportStyleSheet(string reportFile, string styleSheet)
        {
            if (File.Exists(reportFile))
            {
                var reader = File.OpenText(reportFile);
                var fileString = reader.ReadToEnd();
                reader.Close();

                fileString = fileString.Replace("RanorexReport", styleSheet);

                var writer = new StreamWriter(reportFile);
                writer.Write(fileString);
                writer.Close();
            }
        }

        /// <summary>
        /// The get fimware information.
        /// </summary>
        /// <param name="fimwareAssembly">
        /// The assembly file.
        /// </param>
        /// <returns>
        /// The <see cref="FirmwareInformation"/>.
        /// </returns>
        public static IFirmwareInformation GetFimwareInformation(string fimwareAssembly)
        {
            IFirmwareInformation firmware = null;
            try
            {
                if (File.Exists(fimwareAssembly))
                {
                    var assembly = Assembly.LoadFrom(fimwareAssembly);
                    var instances = from t in assembly.GetTypes() where t.GetInterfaces().Contains(typeof(IFirmwareInformation)) && t.GetConstructor(Type.EmptyTypes) != null select Activator.CreateInstance(t) as IFirmwareInformation;

                    foreach (var instance in instances)
                    {
                        firmware = instance.GetFirmwareInformation();
                        break;
                    }
                }
            }
            catch (Exception)
            {
                return firmware;
            }

            return firmware;
        }

        /// <summary>
        /// The copy report and delete temp folder.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public static void CopyReportAndDeleteTempFolder(string path)
        {
            /* 2016-09-29 - EC: This is a WORKAROUND. After updating ranorex from 4.1.6 to 6.1.0 
               the report is generated afterwards after the execution is finished. To avoid the
               destruction of the adapted report for E+H style, the origin report is created in a 
               temp folder. The content will to be copied to the target folder and the temp will be
               deleted afterwards.*/
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                string source = file;
                string target = file.Replace(@"\Temp", string.Empty);
                File.Copy(source, target, true);
            }

            foreach (string file in files)
            {
                string source = file;
                File.Delete(source);
            }

            Directory.Delete(path);
        }

        #endregion

        /// <summary>
        /// The check for copy.
        /// </summary>
        /// <param name="target">
        /// The file.
        /// </param>
        private static void CheckForCopy(string target)
        {
            // Warte 10 Sekunden, auf das Ende des Kopiervorganges
            // Wenn Kopiervorgang innerhalb der Zeit abgeschlossen
            //   Dann mache weiter wie bisher
            // Andernfalls: 
            //   Gebe eine Fehlermeldung aus und werfe eine Exception
            var timeOut = new Stopwatch();
            const int TimeOutInMilliseconds = 10000;
            bool doesExist = File.Exists(target);
            bool withinTime = true;

            timeOut.Start();
            while (doesExist == false && withinTime)
            {
                Report.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Waiting for copied file [{0}]", target));
                doesExist = File.Exists(target);
                if (timeOut.ElapsedMilliseconds > TimeOutInMilliseconds && doesExist == false)
                {
                    withinTime = false;
                    Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("File [{0}] is not accessible.", target));
                }

                System.Threading.Thread.Sleep(1000);
            }
            
            timeOut.Stop();
        }
    }
}