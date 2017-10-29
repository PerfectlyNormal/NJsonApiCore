using NJsonApiCore.Infrastructure;
using NJsonApiCore.Serialization.Documents;
using System;

namespace NJsonApiCore.Serialization
{
    public interface IJsonApiTransformer
    {
        CompoundDocument Transform(Exception e, int httpStatus);

        CompoundDocument Transform(object objectGraph, Context context);

        IDelta TransformBack(UpdateDocument updateDocument, Type type, Context context);
    }
}
