using System;

namespace NJsonApiCore.Exceptions
{
    internal class MissingMappingException : Exception
    {
        public MissingMappingException(Type type)
        {
            MissingMappingType = type;
        }

        public Type MissingMappingType { get; set; }
    }
}
