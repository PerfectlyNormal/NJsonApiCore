using NJsonApiCore.Web.MVC5.HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NJsonApiCore.Web.MVC5.HelloWorld.Controllers
{
    [RoutePrefix("comments")]
    public class CommentsController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return StaticPersistentStore.Comments;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(StaticPersistentStore.Comments.Single(w => w.Id == id));
        }
    }
}
