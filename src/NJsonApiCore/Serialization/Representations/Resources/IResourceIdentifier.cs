namespace NJsonApiCore.Serialization.Representations.Resources
{
    internal interface IResourceIdentifier
    {
        string Type { get; set; }
        string Id { get; set; }
    }
}
