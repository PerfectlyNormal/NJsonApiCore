using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NJsonApiCore;
using NJsonApiCore.Test.TestModel;
using NJsonApiCore.Test.TestControllers;

namespace NJsonApiCore.Test.Builders
{
    internal static class TestModelConfigurationBuilder
    {
        public static ConfigurationBuilder BuilderForEverything
        {
            get
            {
                var builder = new ConfigurationBuilder();
                builder
                    .Resource<Post, PostsController>()
                    .WithAllProperties();

                builder
                    .Resource<Author, AuthorsController>()
                    .WithAllProperties();

                builder
                    .Resource<Comment, CommentsController>()
                    .WithAllProperties();

                return builder;
            }
        }
    }
}
