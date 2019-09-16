namespace Spark.Utilities
{
    using System;

    public static class CacheUtilities
    {
        public static string ToIdentifier(string site, object[] key)
        {
            if (key.Length == 0)
            {
                return site;
            }
            if (key.Length == 1)
            {
                return (site + key[0]);
            }
            object[] objArray = new object[key.Length * 2];
            objArray[0] = site;
            objArray[1] = key[0];
            for (int i = 1; i != key.Length; i++)
            {
                objArray[i * 2] = "\x001f";
                objArray[(i * 2) + 1] = key[i];
            }
            return string.Concat(objArray);
        }
    }
}

