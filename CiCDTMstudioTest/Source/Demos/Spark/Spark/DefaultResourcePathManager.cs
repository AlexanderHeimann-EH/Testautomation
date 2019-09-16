namespace Spark
{
    using System;

    public class DefaultResourcePathManager : IResourcePathManager
    {
        private readonly ISparkSettings _settings;

        public DefaultResourcePathManager(ISparkSettings settings)
        {
            this._settings = settings;
        }

        public string GetResourcePath(string siteRoot, string path)
        {
            string str = path;
            foreach (IResourceMapping mapping in this._settings.ResourceMappings)
            {
                if (mapping.IsMatch(str))
                {
                    str = mapping.Map(str);
                    if (mapping.Stop)
                    {
                        return str;
                    }
                }
            }
            if (str.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) || str.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
            {
                return str;
            }
            if (str.StartsWith("~/", StringComparison.InvariantCultureIgnoreCase))
            {
                str = str.Substring(1);
            }
            return this.PathConcat(siteRoot, str);
        }

        public string PathConcat(string siteRoot, string path)
        {
            bool flag = siteRoot.EndsWith("/");
            bool flag2 = path.StartsWith("/");
            if (flag2 && flag)
            {
                return (siteRoot + path.Substring(1));
            }
            if (!flag2 && !flag)
            {
                return (siteRoot + "/" + path);
            }
            return (siteRoot + path);
        }
    }
}

