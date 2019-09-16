// -----------------------------------------------------------------------
// <copyright file="GetConfigurationData.cs" company="Endress+Hauser Process Solutions AG">
// 
// </copyright>
// -----------------------------------------------------------------------

namespace CiC_DTMstudio_Test_Template.TestModul.Configuration
{
    /// <summary>
    /// Description of GetConfigurationData.
    /// </summary>
    public static class ConfigurationData
    {
        public static void GetConfigurationData()
        {
            Common.Configuration.SystemConfiguration.GetConfig(@"SystemConfig.xml");
        }
    }
}
