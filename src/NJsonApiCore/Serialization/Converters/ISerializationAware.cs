using Newtonsoft.Json;

namespace NJsonApiCore.Serialization.Converters
{
    internal interface ISerializationAware
    {
        void Serialize(JsonWriter writer);
    }
}
