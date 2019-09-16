/*
 * Created by Ranorex
 * User: testadmin
 * Date: 26.03.2012
 * Time: 8:26 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace CiC_DTMstudio_Test_Template.TestModul.Frames
{
    /// <summary>
    /// Description of TM_ProjectClose.
    /// </summary>
    public class TM_ProjectCloseWithoutSaving 
    {
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        public bool Run()
        {
        	return Testlibrary.TestModules.Frame.TM_ProjectClose.Run("", false);
        }
    }
}
