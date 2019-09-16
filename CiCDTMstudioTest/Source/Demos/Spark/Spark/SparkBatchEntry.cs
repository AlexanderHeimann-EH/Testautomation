namespace Spark
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class SparkBatchEntry
    {
        public SparkBatchEntry()
        {
            this.LayoutNames = new List<IList<string>>();
            this.IncludeViews = new List<string>();
            this.ExcludeViews = new List<string>();
        }

        public Type ControllerType { get; set; }

        public IList<string> ExcludeViews { get; set; }

        public IList<string> IncludeViews { get; set; }

        public IList<IList<string>> LayoutNames { get; set; }
    }
}

