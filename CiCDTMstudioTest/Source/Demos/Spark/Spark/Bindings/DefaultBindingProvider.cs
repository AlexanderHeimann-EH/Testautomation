namespace Spark.Bindings
{
    using System.Collections.Generic;
    using System.IO;

    public class DefaultBindingProvider : BindingProvider
    {
        public override IEnumerable<Binding> GetBindings(BindingRequest bindingRequest)
        {
            IEnumerable<Binding> enumerable;
            if (!bindingRequest.ViewFolder.HasView("bindings.xml"))
            {
                return new Binding[0];
            }
            using (Stream stream = bindingRequest.ViewFolder.GetViewSource("bindings.xml").OpenViewStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    enumerable = base.LoadStandardMarkup(reader);
                }
            }
            return enumerable;
        }
    }
}

