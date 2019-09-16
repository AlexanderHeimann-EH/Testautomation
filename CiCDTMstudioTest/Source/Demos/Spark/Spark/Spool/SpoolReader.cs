namespace Spark.Spool
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class SpoolReader : TextReader
    {
        private string _cursorData;
        private int _cursorIndex;
        private readonly IEnumerator<string> _enumerator;

        public SpoolReader(IEnumerable<string> source)
        {
            this._enumerator = source.GetEnumerator();
        }

        private bool AdvanceCursor()
        {
            this._cursorIndex = 0;
            bool flag = this._enumerator.MoveNext();
            this._cursorData = flag ? this._enumerator.Current : null;
            return flag;
        }

        private bool EnsureCursor()
        {
            while ((this._cursorData == null) || (this._cursorIndex == this._cursorData.Length))
            {
                if (!this.AdvanceCursor())
                {
                    return false;
                }
            }
            return true;
        }

        public override int Peek()
        {
            if (!this.EnsureCursor())
            {
                return -1;
            }
            return this._cursorData[this._cursorIndex];
        }

        public override int Read()
        {
            int num = this.Peek();
            if (num != -1)
            {
                this._cursorIndex++;
            }
            return num;
        }

        public override string ReadToEnd()
        {
            int num;
            StringBuilder builder = new StringBuilder();
            while ((num = this.Read()) != -1)
            {
                builder.Append((char) num);
            }
            return builder.ToString();
        }
    }
}

