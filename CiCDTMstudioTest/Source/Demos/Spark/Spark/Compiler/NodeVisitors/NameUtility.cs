namespace Spark.Compiler.NodeVisitors
{
    using System;

    internal static class NameUtility
    {
        public static string GetName(string name)
        {
            int index = name.IndexOf(':');
            if (index < 0)
            {
                return name;
            }
            return name.Substring(index + 1);
        }

        public static string GetPrefix(string name)
        {
            int index = name.IndexOf(':');
            if (index > 0)
            {
                return name.Substring(0, index);
            }
            return "";
        }

        public static bool IsMatch(string matchName, NamespacesType type, string name, string ns)
        {
            if (type == NamespacesType.Unqualified)
            {
                return (name == matchName);
            }
            if (ns != "http://sparkviewengine.com/")
            {
                return false;
            }
            return (GetName(name) == matchName);
        }

        public static bool IsMatch(string nameA, string namespaceA, string nameB, string namespaceB, NamespacesType type)
        {
            if (type == NamespacesType.Unqualified)
            {
                return (nameA == nameB);
            }
            return ((namespaceA == namespaceB) && (GetName(nameA) == GetName(nameB)));
        }
    }
}

