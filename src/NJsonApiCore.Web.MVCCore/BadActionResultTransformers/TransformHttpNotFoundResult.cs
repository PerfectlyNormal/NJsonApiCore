using Microsoft.AspNetCore.Mvc;
using NJsonApiCore.Serialization.Representations;

namespace NJsonApiCore.Web.MVCCore.BadActionResultTransformers
{
    internal class TransformHttpNotFoundResult : BaseTransformBadAction<NotFoundResult>
    {
        public override Error GetError(NotFoundResult result)
        {
            return new Error()
            {
                Title = "The result was not found",
                Status = 404
            };
        }
    }
}
