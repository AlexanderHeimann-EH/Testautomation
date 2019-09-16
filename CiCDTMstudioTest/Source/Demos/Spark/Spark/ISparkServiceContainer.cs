namespace Spark
{
    using System;

    public interface ISparkServiceContainer : IServiceProvider
    {
        T GetService<T>();
        void SetService<TServiceInterface>(TServiceInterface service);
        void SetServiceBuilder<TServiceInterface>(Func<ISparkServiceContainer, object> serviceBuilder);
    }
}

