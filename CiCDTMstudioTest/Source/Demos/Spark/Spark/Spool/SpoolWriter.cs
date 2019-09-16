namespace Spark.Spool
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Web.Configuration;

    public class SpoolWriter : TextWriter, IEnumerable<string>, IEnumerable
    {
        private System.Text.Encoding _encoding;
        private readonly SpoolPage _first = new SpoolPage();
        private SpoolPage _last;

        public SpoolWriter()
        {
            this._last = this._first;
        }

        protected override void Dispose(bool disposing)
        {
            this._first.Release();
        }

        ~SpoolWriter()
        {
            this.Dispose(false);
        }

        internal void SendToSpoolWriter(SpoolWriter target)
        {
            target._last = target._last.Append(this._first);
        }

        internal void SendToTextWriter(TextWriter target)
        {
            for (SpoolPage page = this._first; page != null; page = page.Next)
            {
                string[] buffer = page.Buffer;
                int count = page.Count;
                for (int i = 0; i != count; i++)
                {
                    target.Write(buffer[i]);
                }
            }
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            for (SpoolPage iteratorVariable0 = this._first; iteratorVariable0 != null; iteratorVariable0 = iteratorVariable0.Next)
            {
                string[] buffer = iteratorVariable0.Buffer;
                int count = iteratorVariable0.Count;
                for (int i = 0; i != count; i++)
                {
                    yield return buffer[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<string>) this).GetEnumerator();
        }

        public override string ToString()
        {
            return string.Concat(this.ToArray<string>());
        }

        public override void Write(char value)
        {
            this.Write(new string(value, 1));
        }

        public override void Write(object value)
        {
            if (value is SpoolWriter)
            {
                ((SpoolWriter) value).SendToSpoolWriter(this);
            }
            else
            {
                base.Write(value);
            }
        }

        public override void Write(string value)
        {
            this._last = this._last.Append(value);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            this.Write(new string(buffer, index, count));
        }

        public override System.Text.Encoding Encoding
        {
            get
            {
                if (this._encoding == null)
                {
                    GlobalizationSection section = ConfigurationManager.GetSection("system.web/globalization") as GlobalizationSection;
                    this._encoding = (section != null) ? section.ResponseEncoding : System.Text.Encoding.UTF8;
                }
                return this._encoding;
            }
        }

    }
}

