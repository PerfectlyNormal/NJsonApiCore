using NJsonApiCore.Serialization.Representations.Resources;
using System.Collections.Generic;

namespace NJsonApiCore.Serialization.Representations
{
    internal class ResourceCollection : List<SingleResource>, IResourceRepresentation
    {
        public ResourceCollection()
        {
        }

        public ResourceCollection(IEnumerable<SingleResource> list) : base(list)
        {
        }
    }
}
