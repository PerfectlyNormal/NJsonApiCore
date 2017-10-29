using System;
using System.Collections.Generic;

namespace NJsonApiCore.Infrastructure
{
    public interface IMetaDataWrapper
    {
        Dictionary<string, object> MetaData { get; }
        object GetValue();
    }
}
