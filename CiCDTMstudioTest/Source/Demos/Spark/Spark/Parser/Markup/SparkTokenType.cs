namespace Spark.Parser.Markup
{
    using System;

    public enum SparkTokenType
    {
        PlainText,
        HtmlTagDelimiter,
        HtmlOperator,
        HtmlElementName,
        HtmlAttributeName,
        HtmlAttributeValue,
        HtmlComment,
        HtmlEntity,
        HtmlServerSideScript,
        String,
        SparkDelimiter
    }
}

