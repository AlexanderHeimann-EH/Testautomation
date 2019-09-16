namespace Spark
{
    using Spark.FileSystem;
    using System;
    using System.IO;

    public class DefaultTemplateLocator : ITemplateLocator
    {
        public LocateResult LocateMasterFile(IViewFolder viewFolder, string masterName)
        {
            string str = masterName + Constants.DotSpark;
            string path = Path.Combine(Constants.Layouts, str);
            if (viewFolder.HasView(path))
            {
                return Result(viewFolder, path);
            }
            string str3 = Path.Combine(Constants.Shared, str);
            if (viewFolder.HasView(str3))
            {
                return Result(viewFolder, str3);
            }
            return new LocateResult { SearchedLocations = new string[] { path, str3 } };
        }

        private static LocateResult Result(IViewFolder viewFolder, string path)
        {
            return new LocateResult { Path = path, ViewFile = viewFolder.GetViewSource(path) };
        }
    }
}

