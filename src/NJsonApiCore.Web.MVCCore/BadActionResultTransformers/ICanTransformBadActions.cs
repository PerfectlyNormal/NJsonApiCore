using Microsoft.AspNetCore.Mvc;
using NJsonApiCore.Serialization.Documents;

namespace NJsonApiCore.Web.MVCCore.BadActionResultTransformers
{
    internal interface ICanTransformBadActions
    {
        bool Accepts(IActionResult result);

        CompoundDocument Transform(IActionResult result);
    }
}
