﻿using NJsonApiCore.Infrastructure;
using NJsonApiCore.Serialization.Documents;
using NJsonApiCore.Serialization.Representations.Resources;
using NJsonApiCore.Test.Builders;
using NJsonApiCore.Test.TestControllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace NJsonApiCore.Test.Serialization.JsonApiTransformerTest
{
    public class TestMetadataWrapper
    {
        private readonly List<string> reservedKeys = new List<string> { "id", "type", "href", "links" };

        [Fact]
        public void Creates_CompondDocument_for_metadatawrapper_single_not_nested_class_and_propertly_map_resourceName()
        {
            // Arrange
            var context = CreateContext();
            MetaDataWrapper<SampleClass> objectToTransform = CreateObjectToTransform();
            var transfomer = new JsonApiTransformerBuilder()
                .With(CreateConfiguration())
                .Build();

            // Act
            CompoundDocument result = transfomer.Transform(objectToTransform, context);

            // Assert
            Assert.NotNull(result.Data);
            var transformedObject = result.Data as SingleResource;
            Assert.NotNull(transformedObject);
        }

        [Fact]
        public void Creates_CompondDocument_for_metadatawrapper_single_not_nested_class_and_propertly_map_id()
        {
            // Arrange
            var context = CreateContext();
            MetaDataWrapper<SampleClass> objectToTransform = CreateObjectToTransform();
            var transfomer = new JsonApiTransformerBuilder()
                .With(CreateConfiguration())
                .Build();

            // Act
            CompoundDocument result = transfomer.Transform(objectToTransform, context);

            // Assert
            var transformedObject = result.Data as SingleResource;
            Assert.Equal(transformedObject.Id, objectToTransform.Value.Id.ToString());
        }

        [Fact]
        public void Creates_CompondDocument_for_metadatawrapper_single_not_nested_class_and_propertly_map_properties()
        {
            // Arrange
            var context = CreateContext();
            MetaDataWrapper<SampleClass> objectToTransform = CreateObjectToTransform();
            var transfomer = new JsonApiTransformerBuilder()
                .With(CreateConfiguration())
                .Build();

            // Act
            CompoundDocument result = transfomer.Transform(objectToTransform, context);

            // Assert
            var transformedObject = result.Data as SingleResource;
            Assert.Equal(transformedObject.Attributes["someValue"], objectToTransform.Value.SomeValue);
            Assert.Equal(transformedObject.Attributes["date"], objectToTransform.Value.DateTime);
            Assert.Equal(transformedObject.Attributes.Count, 2);
        }

        [Fact]
        public void Creates_CompondDocument_for_metadatawrapper_single_not_nested_class_and_propertly_map_type()
        {
            // Arrange
            var context = CreateContext();
            MetaDataWrapper<SampleClass> objectToTransform = CreateObjectToTransform();
            var transfomer = new JsonApiTransformerBuilder()
                .With(CreateConfiguration())
                .Build();

            // Act
            CompoundDocument result = transfomer.Transform(objectToTransform, context);

            // Assert
            var transformedObject = result.Data as SingleResource;
            Assert.Equal(transformedObject.Type, "sampleClasses");
        }

        [Fact]
        public void Creates_CompondDocument_for_metadatawrapper_single_not_nested_class_and_propertly_map_metadata()
        {
            // Arrange
            const string pagingValue = "1";
            const string countValue = "2";

            var context = CreateContext();
            MetaDataWrapper<SampleClass> objectToTransform = CreateObjectToTransform();
            objectToTransform.MetaData.Add("Paging", pagingValue);
            objectToTransform.MetaData.Add("Count", countValue);
            var transfomer = new JsonApiTransformerBuilder()
                .With(CreateConfiguration())
                .Build();

            // Act
            CompoundDocument result = transfomer.Transform(objectToTransform, context);

            // Assert
            var transformedObjectMetadata = result.Meta;
            Assert.Equal(transformedObjectMetadata["Paging"], pagingValue);
            Assert.Equal(transformedObjectMetadata["Count"], countValue);
        }

        private static MetaDataWrapper<SampleClass> CreateObjectToTransform()
        {
            var objectToTransform = new SampleClass
            {
                Id = 1,
                SomeValue = "Somevalue text test string",
                DateTime = DateTime.UtcNow,
                NotMappedValue = "Should be not mapped"
            };
            return new MetaDataWrapper<SampleClass>(objectToTransform);
        }

        private Context CreateContext()
        {
            return new Context(new Uri("http://fakehost:1234/", UriKind.Absolute));
        }

        private IConfiguration CreateConfiguration()
        {
            var mapping = new ResourceMapping<SampleClass, DummyController>(c => c.Id);
            mapping.ResourceType = "sampleClasses";
            mapping.AddPropertyGetter("someValue", c => c.SomeValue);
            mapping.AddPropertyGetter("date", c => c.DateTime);

            var config = new NJsonApiCore.Configuration();
            config.AddMapping(mapping);
            return config;
        }

        private class SampleClass
        {
            public int Id { get; set; }
            public string SomeValue { get; set; }
            public DateTime DateTime { get; set; }
            public string NotMappedValue { get; set; }
        }
    }
}
