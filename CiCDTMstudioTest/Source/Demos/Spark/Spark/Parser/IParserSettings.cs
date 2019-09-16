namespace Spark.Parser
{
    using System;

    public interface IParserSettings
    {
        bool AutomaticEncoding { get; }

        string StatementMarker { get; }
    }
}

