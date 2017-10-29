using Newtonsoft.Json;
using NJsonApiCore.Serialization.Converters;
using System;

namespace NJsonApiCore.Serialization.Representations
{
    [JsonConverter(typeof(SerializationAwareConverter))]
    public class SimpleLink : ILink, ISerializationAware
    {
        public SimpleLink()
        {
        }

        public SimpleLink(Uri href)
        {
            this.Href = href.AbsoluteUri;
        }

        public string Href { get; set; }

        public void Serialize(JsonWriter writer) => writer.WriteValue(Href);

        public override string ToString() => Href;
    }
}
