namespace Spark
{
    using System;

    public interface IViewActivatorFactory
    {
        IViewActivator Register(Type type);
        void Unregister(Type type, IViewActivator activator);
    }
}

