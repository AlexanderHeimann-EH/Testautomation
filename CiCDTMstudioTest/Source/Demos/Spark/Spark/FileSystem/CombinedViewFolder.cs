namespace Spark.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CombinedViewFolder : IViewFolder
    {
        private readonly IViewFolder _first;
        private readonly IViewFolder _second;

        public CombinedViewFolder(IViewFolder first, IViewFolder second)
        {
            this._first = first;
            this._second = second;
        }

        public IViewFile GetViewSource(string path)
        {
            if (!this.First.HasView(path))
            {
                return this.Second.GetViewSource(path);
            }
            return this.First.GetViewSource(path);
        }

        public bool HasView(string path)
        {
            if (!this.First.HasView(path))
            {
                return this.Second.HasView(path);
            }
            return true;
        }

        public IList<string> ListViews(string path)
        {
            return this.First.ListViews(path).Union<string>(this.Second.ListViews(path)).Distinct<string>().ToArray<string>();
        }

        public IViewFolder First
        {
            get
            {
                return this._first;
            }
        }

        public IViewFolder Second
        {
            get
            {
                return this._second;
            }
        }
    }
}

