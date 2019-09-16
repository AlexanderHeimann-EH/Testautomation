namespace Spark
{
    using System;

    public interface IViewActivator
    {
        ISparkView Activate(Type type);
        void Release(Type type, ISparkView view);
    }
}

