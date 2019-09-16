namespace Spark
{
    using System;

    public class CacheSignal : ICacheSignal
    {
        private EventHandler _changed;
        private bool _enabled;

        public event EventHandler Changed
        {
            add
            {
                lock (this)
                {
                    this._changed = (EventHandler) Delegate.Combine(this._changed, value);
                    if (!this._enabled)
                    {
                        this.Enable();
                        this._enabled = true;
                    }
                }
            }
            remove
            {
                lock (this)
                {
                    this._changed = (EventHandler) Delegate.Remove(this._changed, value);
                    if (this._enabled && this.ChangedIsEmpty())
                    {
                        this.Disable();
                        this._enabled = false;
                    }
                }
            }
        }

        private bool ChangedIsEmpty()
        {
            if (this._changed != null)
            {
                return (this._changed.GetInvocationList().Length == 0);
            }
            return true;
        }

        protected virtual void Disable()
        {
        }

        protected virtual void Enable()
        {
        }

        public void FireChanged()
        {
            if (this._changed != null)
            {
                this._changed(this, EventArgs.Empty);
            }
        }
    }
}

