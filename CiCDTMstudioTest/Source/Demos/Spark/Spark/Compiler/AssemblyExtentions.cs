namespace Spark.Compiler
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.CompilerServices;

    public static class AssemblyExtentions
    {
        private static bool HasNoLocation(this Assembly assembly)
        {
            bool flag;
            try
            {
                flag = string.IsNullOrEmpty(assembly.Location);
            }
            catch (NotSupportedException)
            {
                return true;
            }
            return flag;
        }

        public static bool IsDynamic(this Assembly assembly)
        {
            if (!(assembly is AssemblyBuilder) && !(assembly.ManifestModule.GetType().Namespace == "System.Reflection.Emit"))
            {
                return assembly.HasNoLocation();
            }
            return true;
        }
    }
}

