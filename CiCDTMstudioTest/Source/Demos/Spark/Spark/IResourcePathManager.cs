namespace Spark
{
    using System;

    public interface IResourcePathManager
    {
        string GetResourcePath(string siteRoot, string path);
    }
}

