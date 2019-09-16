namespace Spark.FileSystem
{
    using Spark;
    using System;
    using System.Runtime.CompilerServices;

    public static class IViewFolderExtensions
    {
        public static IViewFolder AddLayoutsPath(this IViewFolder viewFolder, string virtualPath)
        {
            SubViewFolder additional = new SubViewFolder(new VirtualPathProviderViewFolder(virtualPath), "Layouts");
            return viewFolder.Append(additional);
        }

        public static IViewFolder AddSharedPath(this IViewFolder viewFolder, string virtualPath)
        {
            SubViewFolder additional = new SubViewFolder(new VirtualPathProviderViewFolder(virtualPath), "Shared");
            return viewFolder.Append(additional);
        }

        public static IViewFolder Append(this IViewFolder viewFolder, IViewFolder additional)
        {
            return new CombinedViewFolder(viewFolder, additional);
        }

        public static IViewFolder ApplySettings(this IViewFolder viewFolder, ISparkSettings settings)
        {
            return viewFolder;
        }
    }
}

