namespace Spark.Spool
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class SpoolPage
    {
        private static readonly Allocator _allocator = new Allocator();
        private readonly string[] _buffer;
        private int _count;
        private SpoolPage _next;
        private bool _nonreusable;
        private bool _readonly;
        private bool _released;
        public const int BUFFER_SIZE = 250;

        public SpoolPage()
        {
            this._buffer = _allocator.Obtain();
        }

        private SpoolPage(SpoolPage original)
        {
            this._buffer = original._buffer;
            this._count = original._count;
            if (original._next != null)
            {
                this._next = new SpoolPage(original._next);
            }
            this._readonly = true;
            original._readonly = true;
            this._nonreusable = true;
            original._nonreusable = true;
        }

        public SpoolPage Append(SpoolPage pages)
        {
            this._readonly = true;
            this._next = new SpoolPage(pages);
            SpoolPage page = this._next;
            while (page._next != null)
            {
                page = page._next;
            }
            return page;
        }

        public SpoolPage Append(string value)
        {
            if (this._readonly)
            {
                if (this._next == null)
                {
                    this._next = new SpoolPage();
                }
                return this._next.Append(value);
            }
            this._buffer[this._count++] = value;
            if (this._count == 250)
            {
                this._readonly = true;
            }
            return this;
        }

        public void Release()
        {
            if (Monitor.TryEnter(_allocator._cache))
            {
                try
                {
                    for (SpoolPage page = this; (page != null) && (_allocator._cache.Count < 200); page = page._next)
                    {
                        if (!page._nonreusable && !page._released)
                        {
                            page._released = true;
                            Array.Clear(page._buffer, 0, page._count);
                            _allocator._cache.Push(page._buffer);
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(_allocator._cache);
                }
            }
        }

        public string[] Buffer
        {
            get
            {
                return this._buffer;
            }
        }

        public int Count
        {
            get
            {
                return this._count;
            }
        }

        public SpoolPage Next
        {
            get
            {
                return this._next;
            }
        }

        private class Allocator
        {
            internal readonly Stack<string[]> _cache = new Stack<string[]>();

            public string[] Obtain()
            {
                string[] strArray;
                if (!Monitor.TryEnter(this._cache))
                {
                    return new string[250];
                }
                try
                {
                    strArray = (this._cache.Count != 0) ? this._cache.Pop() : new string[250];
                }
                finally
                {
                    Monitor.Exit(this._cache);
                }
                return strArray;
            }
        }
    }
}

