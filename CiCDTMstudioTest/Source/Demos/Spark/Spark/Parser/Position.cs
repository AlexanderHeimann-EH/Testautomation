namespace Spark.Parser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Position
    {
        private readonly int column;
        private readonly int line;
        private readonly int offset;
        private readonly Spark.Parser.PaintLink paintLink;
        private int sourceContentLength;
        private readonly Spark.Parser.SourceContext sourceContext;
        private static readonly char[] special = new char[] { '\r', '\n', '\t' };

        public Position(Position position) : this(position.SourceContext, position.sourceContentLength, position.Offset, position.Line, position.Column, position.PaintLink)
        {
        }

        public Position(Spark.Parser.SourceContext sourceContext) : this(sourceContext, sourceContext.Content.Length, 0, 1, 1, null)
        {
        }

        public Position(Spark.Parser.SourceContext sourceContext, int sourceContextLength, int offset, int line, int column, Spark.Parser.PaintLink paintLink)
        {
            this.sourceContext = sourceContext;
            this.sourceContentLength = sourceContextLength;
            this.offset = offset;
            this.line = line;
            this.column = column;
            this.paintLink = paintLink;
        }

        public Position Advance(int count)
        {
            string content = this.SourceContext.Content;
            int offset = this.Offset;
            int column = this.Column;
            int line = this.Line;
            int num4 = count;
            while (num4 != 0)
            {
                int num5 = content.IndexOfAny(special, offset, num4) - offset;
                if (num5 < 0)
                {
                    return new Position(this.SourceContext, this.sourceContentLength, offset + num4, line, column + num4, this.PaintLink);
                }
                switch (content[offset + num5])
                {
                    case '\t':
                    {
                        num4 -= num5 + 1;
                        offset += num5 + 1;
                        column += num5;
                        column += 4 - ((column - 1) % 4);
                        continue;
                    }
                    case '\n':
                    {
                        num4 -= num5 + 1;
                        offset += num5 + 1;
                        column = 1;
                        line++;
                        continue;
                    }
                    case '\r':
                    {
                        num4 -= num5 + 1;
                        offset += num5 + 1;
                        column += num5;
                        continue;
                    }
                }
                throw new Exception(string.Format("Unexpected character {0}", (int) content[offset + num5]));
            }
            return new Position(this.SourceContext, this.sourceContentLength, offset, line, column, this.PaintLink);
        }

        public Position Constrain(Position end)
        {
            return new Position(this) { sourceContentLength = end.Offset };
        }

        public IEnumerable<Spark.Parser.Paint> GetPaint()
        {
            Spark.Parser.PaintLink paintLink = this.PaintLink;
            while (true)
            {
                if (paintLink == null)
                {
                    yield break;
                }
                yield return paintLink.Paint;
                paintLink = paintLink.Next;
            }
        }

        public Position Paint<T>(Position begin, T value)
        {
            Paint<T> paint = new Paint<T> {
                Begin = begin,
                End = this,
                Value = value
            };
            Spark.Parser.PaintLink paintLink = new Spark.Parser.PaintLink {
                Next = this.PaintLink,
                Paint = paint
            };
            return new Position(this.sourceContext, this.sourceContentLength, this.offset, this.line, this.column, paintLink);
        }

        public char Peek()
        {
            if (this.Offset == this.sourceContentLength)
            {
                return '\0';
            }
            return this.SourceContext.Content[this.Offset];
        }

        public string Peek(int count)
        {
            return this.SourceContext.Content.Substring(this.Offset, count);
        }

        public bool PeekTest(string match)
        {
            if ((this.sourceContentLength - this.Offset) < match.Length)
            {
                return false;
            }
            return (string.CompareOrdinal(this.SourceContext.Content, this.Offset, match, 0, match.Length) == 0);
        }

        public int PotentialLength()
        {
            return (this.sourceContentLength - this.Offset);
        }

        public int PotentialLength(params char[] stopChars)
        {
            if (stopChars == null)
            {
                return this.PotentialLength();
            }
            int count = this.sourceContentLength - this.Offset;
            int num2 = this.SourceContext.Content.IndexOfAny(stopChars, this.Offset, count) - this.Offset;
            if (num2 >= 0)
            {
                return num2;
            }
            return count;
        }

        public int Column
        {
            get
            {
                return this.column;
            }
        }

        public int Line
        {
            get
            {
                return this.line;
            }
        }

        public int Offset
        {
            get
            {
                return this.offset;
            }
        }

        public Spark.Parser.PaintLink PaintLink
        {
            get
            {
                return this.paintLink;
            }
        }

        public Spark.Parser.SourceContext SourceContext
        {
            get
            {
                return this.sourceContext;
            }
        }

    }
}

