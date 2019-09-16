namespace Spark.FileSystem
{
    using System;

    public interface ITemplateLocator
    {
        LocateResult LocateMasterFile(IViewFolder viewFolder, string masterName);
    }
}

