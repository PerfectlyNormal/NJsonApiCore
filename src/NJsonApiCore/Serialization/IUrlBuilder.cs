using System;

namespace NJsonApiCore.Serialization
{
    internal interface IUrlBuilder
    {
        string GetFullyQualifiedUrl(Context context, string urlTemplate);
    }
}
