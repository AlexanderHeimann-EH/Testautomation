namespace Spark.Parser
{
    using System;

    public class Chain<TLeft, TDown>
    {
        private readonly TDown down;
        private readonly TLeft left;

        public Chain(TLeft left, TDown down)
        {
            this.left = left;
            this.down = down;
        }

        public TDown Down
        {
            get
            {
                return this.down;
            }
        }

        public TLeft Left
        {
            get
            {
                return this.left;
            }
        }
    }
}

