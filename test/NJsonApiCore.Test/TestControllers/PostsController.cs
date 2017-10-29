using Microsoft.AspNetCore.Mvc;
using NJsonApiCore.Test.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NJsonApiCore.Test.TestControllers
{
    internal class PostsController : Controller
    {
        [HttpGet]
        public Post Get(int id)
        {
            return new Post();
        }
    }
}
