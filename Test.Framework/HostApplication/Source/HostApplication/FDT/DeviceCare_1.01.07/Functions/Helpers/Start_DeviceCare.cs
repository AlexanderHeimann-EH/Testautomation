/*
 * Created by Ranorex
 * User: Anja Kellner
 * Date: 16/05/2012
 * Time: 12:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers
{
    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
  /// Description of Start_DeviceCare.
  /// </summary>
  [TestModule("2EEABFED-683F-4B33-8184-CDE25959C709", ModuleType.UserCode, 1)]
  public class Start_DeviceCare : ITestModule
  {
    /// <summary>
    /// Constructs a new instance.
    /// </summary>
    public Start_DeviceCare()
    {
      // Do not delete - a parameterless constructor is required!
    }
    
    /// <summary>
    /// This contains an instance of the device care repository
    /// </summary>
    
    string installationPath = @"";
    /// <summary>
    /// 
    /// </summary>
    [TestVariable("C45AC5FE-F536-4625-BAB3-B946538E0FF0")]
    public string InstallationPath
    {
      get { return installationPath; }
      set { installationPath = value; }
    }
    
    string nameOfExe = @"";
    /// <summary>
    /// 
    /// </summary>
    [TestVariable("70EBD7AE-9006-49A2-B831-D032EFDA3EA7")]
    public string NameOfExe
    {
      get { return nameOfExe; }
      set { nameOfExe = value; }
    }

    EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication.Instance;

    /// <summary>
    /// Performs the playback of actions in this module.
    /// </summary>
    /// <remarks>You should not call this method directly, instead pass the module
    /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
    /// that will in turn invoke this method.</remarks>
    void ITestModule.Run()
    {
      Mouse.DefaultMoveTime = 300;
      Keyboard.DefaultKeyPressTime = 100;
      Delay.SpeedFactor = 1.0;

      string correctFilePath = this.installationPath + NameOfExe;

      //Start DeviceCare
      Report.Log(ReportLevel.Info, "Application", "Start DeviceCare\r\nRun application with file name " + correctFilePath + " with arguments '' in normal mode.");
      Host.Local.RunApplication(correctFilePath);

      if (CheckStarted())
      {
         Report.Success("The Application was started successfully .");
      }
      else
      {
         Report.Failure("The Application was not started successfully ");
      }

    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool CheckStarted()
    {
       // Check started
       bool exist = repo.DeviceCare.MenuArea.Menu_Home.SelfInfo.Exists();
       // Check visible
       bool visible = repo.DeviceCare.MenuArea.Menu_Home.Self.Visible;
       
       return exist & visible;
    }
    
  }
}
