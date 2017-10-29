using Microsoft.AspNetCore.Mvc;
using NJsonApiCore.Serialization.Representations;

namespace NJsonApiCore.Web.MVCCore.BadActionResultTransformers
{
    internal class TransformBadRequestObjectResult : BaseTransformBadAction<BadRequestObjectResult>
    {
        public override Error GetError(BadRequestObjectResult result)
        {
            return new Error()
            {
                Title = $"There was a bad request for {result.Value}",
                Status = result.StatusCode.Value
            };
        }
    }
}
