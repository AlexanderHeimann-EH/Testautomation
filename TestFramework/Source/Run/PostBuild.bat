set LogOutput=c:\tmp\postBuildLog.txt
echo ##################### TestFramework ############################
set SolutionDir=%3
echo SolutionDir: %SolutionDir%
set Configuration=%4
echo Configuration: %Configuration%
set TargetDir=%SolutionDir%..\ReleaseBin\%Configuration%\
echo TargetDir: %TargetDir%
set OutDir=%2
echo OutDir: %OutDir%
echo .

REM Templates
REM ############################################
REM Communication<protocol><project>Source
REM Communication<protocol>Target
REM HostApplication<category><project>Source
REM HostApplication<category>Target
REM DeviceFunctions<category><project>Source
REM DeviceFunctions<category>Target
REM OperatingSystem<bitversion><project>Source
REM OperatingSystem<bitversion>Source
REM ############################################

echo ##################### Set constants ############################
echo .

echo ##################### Configuration specific ############################
set SourceDeviceFunctionMappingListFile=P:\EH.PCSW.Testautomation.TestFramework\Source\Run\ConfigData\
echo SourceDeviceFunctionMappingListFile: %SourceDeviceFunctionMappingListFile%
echo .

echo ##################### Common specific ############################
set SourceCommon=P:\EH.PCSW.Testautomation.TestFramework.Common\ReleaseBin\%Configuration%
echo SourceCommon: %SourceCommon%
echo .

echo ##################### Communication specific ############################
set SourceCommunication=P:\EH.PCSW.Testautomation.TestFramework.Communication\ReleaseBin\%Configuration%
echo SourceCommunication: %SourceCommunication%
echo .

echo ##################### HostApplicaton specific ############################
set SourceHostApplication=P:\EH.PCSW.Testautomation.TestFramework.HostApplication\ReleaseBin\%Configuration%
echo SourceHostApplication: %SourceHostApplication%
echo .

echo ##################### CommonHostApplicationLayer specific ############################
set SourceCommonHostApplicationLayer=P:\EH.PCSW.Testautomation.TestFramework.CommonHostApplicationLayer\ReleaseBin\%Configuration%
echo SourceCommonHostApplicationLayer: %SourceCommonHostApplicationLayer%
echo .

echo ##################### CommonCommunicationLayer specific ############################
set SourceCommonCommunicationLayer=P:\EH.PCSW.Testautomation.TestFramework.CommonCommunicationLayer\ReleaseBin\%Configuration%
echo SourceCommonCommunicationLayer: %SourceCommonCommunicationLayer%
echo .

echo ##################### CommonDeviceFunctionLayer specific ############################
set SourceCommonDeviceFunctionLayer=P:\EH.PCSW.Testautomation.TestFramework.CommonDeviceFunctionLayer\ReleaseBin\%Configuration%
echo SourceCommonDeviceFunctionLayer: %SourceCommonDeviceFunctionLayer%
echo .

echo ##################### DeviceFunction specific ############################
set SourceDeviceFunction=P:\EH.PCSW.Testautomation.TestFramework.DeviceFunction\ReleaseBin\%Configuration%
echo SourceDeviceFunction: %SourceDeviceFunction%
echo .

echo ##################### OperatingSystem specific ############################
set SourceOperatingSystem=P:\EH.PCSW.Testautomation.TestFramework.OperatingSystem\ReleaseBin\%Configuration%
echo SourceOperatingSystem: %SourceOperatingSystem%
echo .

echo ##################### TestLibrary specific ############################
set SourceTestLibrary=P:\EH.PCSW.Testautomation.TestLibrary\ReleaseBin\%Configuration%
echo SourceTestLibrary: %SourceTestLibrary%
echo .

echo ##################### Copy %Configuration% data ############################

echo Copy Common Specific...
XCOPY %SourceCommon% %TargetDir% /Y /E /S || goto :ERROR

echo Copy Communication Specific...
XCOPY %SourceCommunication% %TargetDir% /Y /E /S || goto :ERROR

echo Copy HostApplication Specific...
XCOPY %SourceHostApplication% %TargetDir% /Y /E /S || goto :ERROR

echo Copy CommonHostApplicationLayer Specific...
XCOPY %SourceCommonHostApplicationLayer% %TargetDir% /Y /E /S || goto :ERROR

echo Copy CommonHostCommunicationLayer Specific...
XCOPY %SourceCommonCommunicationLayer% %TargetDir% /Y /E /S || goto :ERROR

echo Copy CommonDeviceFunctionsLayer Specific...
XCOPY %SourceCommonDeviceFunctionLayer% %TargetDir% /Y /E /S || goto :ERROR

echo Copy DeviceFunction Specific...
XCOPY %SourceDeviceFunction% %TargetDir% /Y /E /S || goto :ERROR

echo Copy OperatingSystem Specific...
XCOPY %SourceOperatingSystem% %TargetDir% /Y /E /S || goto :ERROR

echo Copy TestLibrary...
XCOPY %SourceTestLibrary% %TargetDir% /Y /E /S || goto :ERROR

echo Copy %SourceDeviceFunctionMappingListFile%DeviceFunctionMappingListFile.xml ...
XCOPY %SourceDeviceFunctionMappingListFile%DeviceFunctionMappingListFile.xml %TargetDir% /Y /E /S || goto :ERROR
echo .

echo ##########################
echo used command: 
echo %SolutionDir%Source\PostBuild.bat
echo SolutionDir: %SolutionDir%
echo Configuration: %Configuration%
echo TargetDir: %TargetDir%
echo OutDir: %OutDir%

echo ##################### ErrorMessage ############################
goto :EOF

REM #### IN CASE OF ERROR
:ERROR
echo !#### %0: aborted %ERRORLEVEL% ####!
1>&2