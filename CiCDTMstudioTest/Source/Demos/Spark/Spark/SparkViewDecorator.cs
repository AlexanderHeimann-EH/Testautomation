namespace Spark
{
    using Spark.Spool;
    using System;
    using System.IO;

    public abstract class SparkViewDecorator : SparkViewBase
    {
        private readonly SparkViewBase _decorated;

        protected SparkViewDecorator(SparkViewBase decorated)
        {
            this._decorated = decorated;
        }

        public override void RenderView(TextWriter writer)
        {
            if (this._decorated != null)
            {
                SpoolWriter writer2 = new SpoolWriter();
                this._decorated.RenderView(writer2);
                base.Content["view"] = writer2;
            }
            base.RenderView(writer);
        }

        public override Spark.SparkViewContext SparkViewContext
        {
            get
            {
                if (this._decorated == null)
                {
                    return base.SparkViewContext;
                }
                return this._decorated.SparkViewContext;
            }
            set
            {
                if (this._decorated != null)
                {
                    this._decorated.SparkViewContext = value;
                }
                else
                {
                    base.SparkViewContext = value;
                }
            }
        }
    }
}

