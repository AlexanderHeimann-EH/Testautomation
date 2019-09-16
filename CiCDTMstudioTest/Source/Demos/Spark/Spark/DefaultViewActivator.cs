namespace Spark
{
    using System;

    public class DefaultViewActivator : IViewActivatorFactory, IViewActivator
    {
        public ISparkView Activate(Type type)
        {
            return (ISparkView) Activator.CreateInstance(type);
        }

        public IViewActivator Register(Type type)
        {
            return this;
        }

        public void Release(Type type, ISparkView view)
        {
        }

        public void Unregister(Type type, IViewActivator activator)
        {
        }
    }
}

