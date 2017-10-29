using Microsoft.AspNetCore.Mvc;
using NJsonApiCore.Serialization.Representations;

namespace NJsonApiCore.Web.MVCCore.BadActionResultTransformers
{
    internal class TransformHttpUnauthorizedResult : BaseTransformBadAction<UnauthorizedResult>
    {
        public override Error GetError(UnauthorizedResult result)
        {
            return new Error()
            {
                Title = "You were not authorised.",
                Status = 403
            };
        }
    }
}
