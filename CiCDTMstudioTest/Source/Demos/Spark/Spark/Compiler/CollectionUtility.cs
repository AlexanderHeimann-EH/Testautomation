namespace Spark.Compiler
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public static class CollectionUtility
    {
        public static int Count(IEnumerable enumerable)
        {
            int num = 0;
            IEnumerator enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                num++;
            }
            return num;
        }

        public static int Count<T>(IEnumerable<T> enumerable)
        {
            return enumerable.Count<T>();
        }
    }
}

