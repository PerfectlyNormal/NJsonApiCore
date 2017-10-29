using NJsonApiCore.Serialization;
using NJsonApiCore.Test.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NJsonApiCore.Test.Builders
{
    internal class JsonApiTransformerBuilder
    {
        private IConfiguration config;
        private ILinkBuilder linkBuilder;

        public JsonApiTransformerBuilder()
        {
            this.linkBuilder = new FakeLinkBuilder();
        }

        public JsonApiTransformerBuilder With(IConfiguration config)
        {
            this.config = config;
            return this;
        }

        public JsonApiTransformer Build()
        {
            var serializer = JsonSerializerBuilder.Build();
            var transformationHelper = new TransformationHelper(config, linkBuilder);
            return new JsonApiTransformer(serializer, config, transformationHelper);
        }
    }
}
