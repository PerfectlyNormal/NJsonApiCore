using Microsoft.AspNetCore.Mvc;
using NJsonApiCore.Serialization.Representations;

namespace NJsonApiCore.Web.MVCCore.BadActionResultTransformers
{
    internal class TransformHttpNotFoundObjectResult : BaseTransformBadAction<NotFoundObjectResult>
    {
        public override Error GetError(NotFoundObjectResult result)
        {
            return new Error()
            {
                Title = $"The result with id {result.Value} was not found",
                Status = result.StatusCode.Value
            };
        }
    }
}
