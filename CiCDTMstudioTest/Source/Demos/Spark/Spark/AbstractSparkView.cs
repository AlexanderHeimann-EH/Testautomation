namespace Spark
{
    using System;

    public abstract class AbstractSparkView : SparkViewDecorator
    {
        protected AbstractSparkView() : this(null)
        {
        }

        protected AbstractSparkView(SparkViewBase decorated) : base(decorated)
        {
        }
    }
}

