namespace Spark.Caching
{
    using Spark.Spool;
    using System;
    using System.IO;

    public abstract class TextWriterOriginator
    {
        protected TextWriterOriginator()
        {
        }

        public abstract void BeginMemento();
        public static TextWriterOriginator Create(TextWriter writer)
        {
            if (writer is SpoolWriter)
            {
                return new SpoolWriterOriginator((SpoolWriter) writer);
            }
            if (!(writer is StringWriter))
            {
                throw new InvalidCastException("writer is unknown type " + writer.GetType().FullName);
            }
            return new StringWriterOriginator((StringWriter) writer);
        }

        public abstract TextWriterMemento CreateMemento();
        public abstract void DoMemento(TextWriterMemento memento);
        public abstract TextWriterMemento EndMemento();
    }
}

