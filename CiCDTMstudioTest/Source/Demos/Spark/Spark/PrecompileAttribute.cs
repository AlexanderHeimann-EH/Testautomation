namespace Spark
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable, AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
    public class PrecompileAttribute : Attribute
    {
        public PrecompileAttribute()
        {
        }

        public PrecompileAttribute(string include)
        {
            this.Include = include;
        }

        public PrecompileAttribute(string include, string layout)
        {
            this.Include = include;
            this.Layout = layout;
        }

        public string Exclude { get; set; }

        public string Include { get; set; }

        public string Layout { get; set; }
    }
}

