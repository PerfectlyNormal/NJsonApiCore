using Microsoft.AspNetCore.Mvc;
using NJsonApiCore.Serialization.Representations;

namespace NJsonApiCore.Web.MVCCore.BadActionResultTransformers
{
    internal class TransformBadRequestResult : BaseTransformBadAction<BadRequestResult>
    {
        public override Error GetError(BadRequestResult result)
        {
            return new Error()
            {
                Title = $"There was a bad request.",
                Status = 400
            };
        }
    }
}
