
namespace CiC_DTMstudio_Test_Template.TestModul.Frames
{
    /// <summary>
    /// Description of TM_FDTUpload.
    /// </summary>
    public class TM_FDTUpload
    {
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        public bool Run()
        {
            return Testlibrary.TestModules.Frame.TM_FDTUpload.Run();
        }
    }
}
