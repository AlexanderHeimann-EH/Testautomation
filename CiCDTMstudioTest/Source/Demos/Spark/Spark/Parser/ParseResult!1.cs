namespace Spark.Parser
{
    using System;

    public class ParseResult<TValue>
    {
        private readonly Position rest;
        private readonly TValue value;

        public ParseResult(Position rest, TValue value)
        {
            this.rest = rest;
            this.value = value;
        }

        public Position Rest
        {
            get
            {
                return this.rest;
            }
        }

        public TValue Value
        {
            get
            {
                return this.value;
            }
        }
    }
}

