namespace Spark
{
    using System;

    public interface IResourceMapping
    {
        bool IsMatch(string path);
        string Map(string path);

        bool Stop { get; }
    }
}

