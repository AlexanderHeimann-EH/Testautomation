namespace Spark
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class SparkViewDescriptor
    {
        public SparkViewDescriptor()
        {
            this.Language = LanguageType.Default;
            this.Templates = new List<string>();
            this.Accessors = new List<Accessor>();
        }

        public SparkViewDescriptor AddAccessor(string property, string getValue)
        {
            Accessor item = new Accessor {
                Property = property,
                GetValue = getValue
            };
            this.Accessors.Add(item);
            return this;
        }

        public SparkViewDescriptor AddTemplate(string template)
        {
            this.Templates.Add(template);
            return this;
        }

        public override bool Equals(object obj)
        {
            SparkViewDescriptor descriptor = obj as SparkViewDescriptor;
            if ((descriptor == null) || (base.GetType() != descriptor.GetType()))
            {
                return false;
            }
            if ((!string.Equals(this.TargetNamespace ?? "", descriptor.TargetNamespace ?? "") || (this.Language != descriptor.Language)) || (this.Templates.Count != descriptor.Templates.Count))
            {
                return false;
            }
            for (int i = 0; i != this.Templates.Count; i++)
            {
                if (!string.Equals(this.Templates[i], descriptor.Templates[i], StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int num = 0;
            num ^= this.Language.GetHashCode() ^ (this.TargetNamespace ?? "").GetHashCode();
            foreach (string str in this.Templates)
            {
                num ^= str.ToLowerInvariant().GetHashCode();
            }
            return num;
        }

        public SparkViewDescriptor SetLanguage(LanguageType language)
        {
            this.Language = language;
            return this;
        }

        public SparkViewDescriptor SetTargetNamespace(string targetNamespace)
        {
            this.TargetNamespace = targetNamespace;
            return this;
        }

        public IList<Accessor> Accessors { get; set; }

        public LanguageType Language { get; set; }

        public string TargetNamespace { get; set; }

        public IList<string> Templates { get; set; }

        public class Accessor
        {
            public string GetValue { get; set; }

            public string Property { get; set; }
        }
    }
}

