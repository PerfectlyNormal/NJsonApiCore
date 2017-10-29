using System.Collections.Generic;
using Newtonsoft.Json;
using NJsonApiCore.Serialization.Representations.Resources;

namespace NJsonApiCore.Serialization.Representations.Relationships
{
    public class SingleResourceIdentifier : IResourceLinkage, IResourceIdentifier
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}
