using Microsoft.AspNetCore.Mvc;
using NJsonApiCore.Test.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NJsonApiCore.Test.TestControllers
{
    internal class ModelThatCausesInfiniteLoopController : Controller
    {
        [HttpGet]
        public ModelThatCausesInfiniteLoop Get(int id)
        {
            return new ModelThatCausesInfiniteLoop();
        }
    }
}
