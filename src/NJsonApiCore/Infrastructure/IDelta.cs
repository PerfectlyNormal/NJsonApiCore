using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NJsonApiCore.Infrastructure
{
    public interface IDelta<T> : IDelta
    {
        void FilterOut<TProperty>(params Expression<Func<T, TProperty>>[] filter);

        void ApplySimpleProperties(T inputObject);
    }

    public interface IDelta
    {
        Dictionary<string, object> ObjectPropertyValues { get; set; }
        Dictionary<string, ICollectionDelta> CollectionDeltas { get; set; }
    }
}
