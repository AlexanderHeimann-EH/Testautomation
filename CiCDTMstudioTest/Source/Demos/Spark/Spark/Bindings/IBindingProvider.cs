namespace Spark.Bindings
{
    using System.Collections.Generic;

    public interface IBindingProvider
    {
        IEnumerable<Binding> GetBindings(BindingRequest bindingRequest);
    }
}

