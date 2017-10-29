using Newtonsoft.Json;
using NJsonApiCore.Serialization.Representations.Resources;
using System.Collections.Generic;

namespace NJsonApiCore.Serialization
{
    public class UpdateDocument
    {
        [JsonProperty(PropertyName = "data", Required = Required.Always)]
        public SingleResource Data { get; set; }
    }
}
