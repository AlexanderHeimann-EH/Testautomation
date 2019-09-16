namespace Spark.Caching
{
    using System;
    using System.IO;

    public class StringWriterOriginator : TextWriterOriginator
    {
        private int _priorLength;
        private readonly StringWriter _writer;

        public StringWriterOriginator(StringWriter writer)
        {
            this._writer = writer;
        }

        public override void BeginMemento()
        {
            this._priorLength = this._writer.GetStringBuilder().Length;
        }

        public override TextWriterMemento CreateMemento()
        {
            return new TextWriterMemento { Written = new string[] { this._writer.ToString() } };
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
            int length = this._writer.GetStringBuilder().Length;
            string str = this._writer.GetStringBuilder().ToString(this._priorLength, length - this._priorLength);
            return new TextWriterMemento { Written = new string[] { str } };
        }
    }
}

