namespace Spark
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class SparkViewAttribute : Attribute
    {
        public SparkViewDescriptor BuildDescriptor()
        {
            return new SparkViewDescriptor { TargetNamespace = this.TargetNamespace, Templates = (from t in this.Templates select ConvertFromAttributeFormat(t)).ToList<string>() };
        }

        public static string ConvertFromAttributeFormat(string template)
        {
            if (Path.DirectorySeparatorChar == '\\')
            {
                return template;
            }
            return template.Replace('\\', Path.DirectorySeparatorChar);
        }

        public static string ConvertToAttributeFormat(string template)
        {
            return template.Replace(Path.DirectorySeparatorChar, '\\').Replace(@"\", @"\\");
        }

        public string TargetNamespace { get; set; }

        public string[] Templates { get; set; }
    }
}

