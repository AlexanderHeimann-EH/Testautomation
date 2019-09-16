namespace Spark
{
    using Spark.Compiler.NodeVisitors;
    using Spark.Parser.Markup;

    public interface ISparkExtensionFactory
    {
        ISparkExtension CreateExtension(VisitorContext context, ElementNode node);
    }
}

