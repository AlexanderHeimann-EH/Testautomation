namespace Spark.Caching
{
    using Spark.Spool;
    using System;
    using System.Linq;

    public class SpoolWriterOriginator : TextWriterOriginator
    {
        private int _priorStringCount;
        private readonly SpoolWriter _writer;

        public SpoolWriterOriginator(SpoolWriter writer)
        {
            this._writer = writer;
        }

        public override void BeginMemento()
        {
            this._priorStringCount = this._writer.Count<string>();
        }

        public override TextWriterMemento CreateMemento()
        {
            return new TextWriterMemento { Written = this._writer.ToArray<string>() };
        }

        public override void DoMemento(TextWriterMemento memento)
        {
            foreach (string str in memento.Written)
            {
                this._writer.Write(str);
            }
        }

        public override TextWriterMemento EndMemento()
        {
            return new TextWriterMemento { Written = this._writer.Skip<string>(this._priorStringCount).ToArray<string>() };
        }
    }
}

