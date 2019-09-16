namespace Spark
{
    using System;

    public interface ICacheSignal
    {
        event EventHandler Changed;
    }
}

