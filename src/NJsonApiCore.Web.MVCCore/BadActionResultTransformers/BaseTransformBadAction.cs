using NJsonApiCore.Serialization.Documents;
using NJsonApiCore.Serialization.Representations;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace NJsonApiCore.Web.MVCCore.BadActionResultTransformers
{
    internal abstract class BaseTransformBadAction<T> : ICanTransformBadActions
        where T : class, IActionResult
    {
        public bool Accepts(IActionResult result)
        {
            return result is T;
        }

        public CompoundDocument Transform(IActionResult result)
        {
            return new CompoundDocument()
            {
                Errors = new List<Error>()
                    {
                        GetError(result as T)
                    }
            };
        }

        public abstract Error GetError(T result);
    }
}
