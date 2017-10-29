using Microsoft.AspNetCore.Mvc;
using NJsonApiCore.Test.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NJsonApiCore.Test.TestControllers
{
    internal class ControllerWithMoreThanOneGetForAResource : Controller
    {
        [HttpGet]
        public Post First(int id)
        {
            return new Post();
        }

        [HttpGet]
        public Post Second(int id)
        {
            return new Post();
        }
    }
}
