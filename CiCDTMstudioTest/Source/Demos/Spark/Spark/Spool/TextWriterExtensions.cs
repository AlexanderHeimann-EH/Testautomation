namespace Spark.Spool
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;

    public static class TextWriterExtensions
    {
        public static void WriteTo(this TextWriter source, TextWriter target)
        {
            if (source is SpoolWriter)
            {
                if (target is SpoolWriter)
                {
                    ((SpoolWriter) source).SendToSpoolWriter((SpoolWriter) target);
                }
                else
                {
                    ((SpoolWriter) source).SendToTextWriter(target);
                }
            }
            else
            {
                target.Write(source);
            }
        }
    }
}

