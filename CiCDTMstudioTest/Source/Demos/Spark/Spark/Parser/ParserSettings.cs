namespace Spark.Parser
{
    using System;
    using System.Runtime.CompilerServices;

    public class ParserSettings : IParserSettings
    {
        public const bool DefaultAutomaticEncoding = false;

        public ParserSettings()
        {
            this.AutomaticEncoding = false;
            this.StatementMarker = "#";
        }

        public bool AutomaticEncoding { get; set; }

        public static ParserSettings DefaultBehavior
        {
            get
            {
                return new ParserSettings();
            }
        }

        public static ParserSettings LegacyBehavior
        {
            get
            {
                return new ParserSettings { AutomaticEncoding = false, StatementMarker = "#" };
            }
        }

        public string StatementMarker { get; set; }
    }
}

