
namespace CiC_DTMstudio_Test_Template.TestModul.Frames
{
    /// <summary>
    /// Description of TM_ExitFrame.
    /// </summary>
    public class TM_ExitFrame
    {
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        public bool Run()
        {
        	return Testlibrary.TestModules.Frame.TM_ExitFrame.Run();
        }
    }
}
