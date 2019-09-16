namespace Spark
{
    using Spark.Caching;
    using Spark.Spool;
    using Spark.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public abstract class SparkViewBase : ISparkView
    {
        private CacheScopeImpl _currentCacheScope;
        private Spark.SparkViewContext _sparkViewContext;

        protected SparkViewBase()
        {
        }

        protected bool BeginCachedContent(string site, CacheExpires expires, params object[] key)
        {
            this._currentCacheScope = new CacheScopeImpl(this, CacheUtilities.ToIdentifier(site, key), expires);
            if (this._currentCacheScope.Begin())
            {
                return true;
            }
            this.EndCachedContent();
            return false;
        }

        protected void EndCachedContent()
        {
            this._currentCacheScope = this._currentCacheScope.End(null);
        }

        protected void EndCachedContent(ICacheSignal signal)
        {
            this._currentCacheScope = this._currentCacheScope.End(signal);
        }

        public IDisposable MarkdownOutputScope()
        {
            return new MarkdownOutputScopeImpl(this, new SpoolWriter());
        }

        public bool Once(object flag)
        {
            string key = Convert.ToString(flag);
            if (this.SparkViewContext.OnceTable.ContainsKey(key))
            {
                return false;
            }
            this.SparkViewContext.OnceTable.Add(key, null);
            return true;
        }

        public IDisposable OutputScope()
        {
            return new OutputScopeImpl(this, new SpoolWriter());
        }

        public IDisposable OutputScope(TextWriter writer)
        {
            return new OutputScopeImpl(this, writer);
        }

        public IDisposable OutputScope(string name)
        {
            TextWriter writer;
            if (!this.Content.TryGetValue(name, out writer))
            {
                writer = new SpoolWriter();
                this.Content.Add(name, writer);
            }
            return new OutputScopeImpl(this, writer);
        }

        public abstract void Render();
        public virtual void RenderView(TextWriter writer)
        {
            using (this.OutputScope(writer))
            {
                this.Render();
            }
        }

        public virtual bool TryGetViewData(string name, out object value)
        {
            value = null;
            return false;
        }

        public ICacheService CacheService { get; set; }

        public Dictionary<string, TextWriter> Content
        {
            get
            {
                return this.SparkViewContext.Content;
            }
            set
            {
                this.SparkViewContext.Content = value;
            }
        }

        public abstract Guid GeneratedViewId { get; }

        public Dictionary<string, object> Globals
        {
            get
            {
                return this.SparkViewContext.Globals;
            }
            set
            {
                this.SparkViewContext.Globals = value;
            }
        }

        public Dictionary<string, string> OnceTable
        {
            get
            {
                return this.SparkViewContext.OnceTable;
            }
            set
            {
                this.SparkViewContext.OnceTable = value;
            }
        }

        public TextWriter Output
        {
            get
            {
                return this.SparkViewContext.Output;
            }
            set
            {
                this.SparkViewContext.Output = value;
            }
        }

        public virtual Spark.SparkViewContext SparkViewContext
        {
            get
            {
                return (this._sparkViewContext ?? (Interlocked.CompareExchange<Spark.SparkViewContext>(ref this._sparkViewContext, new Spark.SparkViewContext(), null) ?? this._sparkViewContext));
            }
            set
            {
                this._sparkViewContext = value;
            }
        }

        private class CacheScopeImpl
        {
            private readonly ICacheService _cacheService;
            private readonly CacheExpires _expires;
            private readonly string _identifier;
            private static readonly ICacheService _nullCacheService = new NullCacheService();
            private readonly CacheOriginator _originator;
            private readonly SparkViewBase.CacheScopeImpl _previousCacheScope;
            private bool _recording;

            public CacheScopeImpl(SparkViewBase view, string identifier, CacheExpires expires)
            {
                this._identifier = identifier;
                this._expires = expires;
                this._previousCacheScope = view._currentCacheScope;
                this._cacheService = view.CacheService ?? _nullCacheService;
                this._originator = new CacheOriginator(view.SparkViewContext);
            }

            public bool Begin()
            {
                CacheMemento memento = this._cacheService.Get(this._identifier) as CacheMemento;
                if (memento == null)
                {
                    this._recording = true;
                    this._originator.BeginMemento();
                }
                else
                {
                    this._recording = false;
                    this._originator.DoMemento(memento);
                }
                return this._recording;
            }

            public SparkViewBase.CacheScopeImpl End(ICacheSignal signal)
            {
                if (this._recording)
                {
                    CacheMemento item = this._originator.EndMemento();
                    this._cacheService.Store(this._identifier, this._expires, signal, item);
                }
                return this._previousCacheScope;
            }

            private class NullCacheService : ICacheService
            {
                public object Get(string identifier)
                {
                    return null;
                }

                public void Store(string identifier, CacheExpires expires, ICacheSignal signal, object item)
                {
                }
            }
        }

        public class MarkdownOutputScopeImpl : IDisposable
        {
            private readonly TextWriter previous;
            private readonly SparkViewBase view;

            public MarkdownOutputScopeImpl(SparkViewBase view, TextWriter writer)
            {
                this.view = view;
                this.previous = view.Output;
                view.Output = writer;
            }

            public void Dispose()
            {
                string text = this.view.Output.ToString();
                this.view.Output = this.previous;
                Markdown markdown = new Markdown();
                this.view.Output.Write(markdown.Transform(text));
            }
        }

        public class OutputScopeImpl : IDisposable
        {
            private readonly TextWriter previous;
            private readonly SparkViewBase view;

            public OutputScopeImpl(SparkViewBase view, TextWriter writer)
            {
                this.view = view;
                this.previous = view.Output;
                view.Output = writer;
            }

            public void Dispose()
            {
                this.view.Output = this.previous;
            }
        }
    }
}

