namespace Spark.Caching
{
    using Spark;
    using Spark.Spool;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class CacheOriginator
    {
        private readonly Dictionary<string, TextWriterOriginator> _priorContent = new Dictionary<string, TextWriterOriginator>();
        private Dictionary<string, string> _priorOnceTable;
        private TextWriter _priorOutput;
        private SpoolWriter _spoolOutput;
        private readonly SparkViewContext _state;

        public CacheOriginator(SparkViewContext state)
        {
            this._state = state;
        }

        public void BeginMemento()
        {
            foreach (KeyValuePair<string, TextWriter> pair in this._state.Content)
            {
                TextWriterOriginator originator = TextWriterOriginator.Create(pair.Value);
                this._priorContent.Add(pair.Key, originator);
                originator.BeginMemento();
            }
            this._priorOnceTable = this._state.OnceTable.ToDictionary<KeyValuePair<string, string>, string, string>(kv => kv.Key, kv => kv.Value);
            if (!this._state.Content.Any<KeyValuePair<string, TextWriter>>(kv => object.ReferenceEquals(kv.Value, this._state.Output)))
            {
                this._priorOutput = this._state.Output;
                this._spoolOutput = new SpoolWriter();
                this._state.Output = this._spoolOutput;
            }
        }

        public void DoMemento(CacheMemento memento)
        {
            memento.SpoolOutput.WriteTo(this._state.Output);
            foreach (KeyValuePair<string, TextWriterMemento> pair in memento.Content)
            {
                TextWriter writer;
                if (!this._state.Content.TryGetValue(pair.Key, out writer))
                {
                    writer = new SpoolWriter();
                    this._state.Content.Add(pair.Key, writer);
                }
                TextWriterOriginator.Create(writer).DoMemento(pair.Value);
            }
            foreach (KeyValuePair<string, string> pair2 in from once in memento.OnceTable
                where !this._state.OnceTable.ContainsKey(once.Key)
                select once)
            {
                this._state.OnceTable.Add(pair2.Key, pair2.Value);
            }
        }

        public CacheMemento EndMemento()
        {
            CacheMemento memento = new CacheMemento();
            if (this._priorOutput != null)
            {
                this._spoolOutput.WriteTo(this._priorOutput);
                this._state.Output = this._priorOutput;
                memento.SpoolOutput = this._spoolOutput;
            }
            foreach (KeyValuePair<string, TextWriterOriginator> pair in this._priorContent)
            {
                TextWriterMemento memento2 = pair.Value.EndMemento();
                if (memento2.Written.Any<string>(part => !string.IsNullOrEmpty(part)))
                {
                    memento.Content.Add(pair.Key, memento2);
                }
            }
            foreach (KeyValuePair<string, TextWriter> pair2 in from kv in this._state.Content
                where !this._priorContent.ContainsKey(kv.Key)
                select kv)
            {
                TextWriterOriginator originator = TextWriterOriginator.Create(pair2.Value);
                memento.Content.Add(pair2.Key, originator.CreateMemento());
            }
            IEnumerable<KeyValuePair<string, string>> source = from once in this._state.OnceTable
                where !this._priorOnceTable.ContainsKey(once.Key)
                select once;
            memento.OnceTable = source.ToDictionary<KeyValuePair<string, string>, string, string>(once => once.Key, once => once.Value);
            return memento;
        }
    }
}

