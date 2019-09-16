namespace Spark
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public interface ISparkView
    {
        void RenderView(TextWriter writer);
        bool TryGetViewData(string name, out object value);

        Guid GeneratedViewId { get; }
    }
}

