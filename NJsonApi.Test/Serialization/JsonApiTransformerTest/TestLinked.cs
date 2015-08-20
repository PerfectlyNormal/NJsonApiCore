﻿using FakeItEasy;
using FakeItEasy.ExtensionSyntax.Full;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using NJsonApi.Serialization;
using NJsonApi.Serialization.Representations.Resources;
using SoftwareApproach.TestingExtensions;
using System.Collections.Generic;
using System.Linq;

namespace NJsonApi.Test.Serialization.JsonApiTransformerTest
{
    [TestClass]
    public class TestLinked
    {
        private const string appUrl = @"http://localhost/";

        private JsonApiTransformer transformer;
        private readonly TransformationHelper transformationHelper = new TransformationHelper();

        [TestInitialize]
        public void Initialize()
        {
            transformer = new JsonApiTransformer(){TransformationHelper = transformationHelper};
        }

        [TestMethod]
        public void Creates_one_to_one_relation_links()
        {
            // Arrange
            var context = CreateContext();
            var objectToTransform = CreateObject();
           

            // Act
            var result = transformer.Transform(objectToTransform, context);

            // Assert
            result.Links.ShouldHaveCountOf(1);
            var resultData = result.Data as Dictionary<string, object>;
            resultData.Keys.ShouldContain("links");

            // TODO-DD: Asserts
        }

        [TestMethod]
        public void Creates_one_to_many_relation_links()
        {
            // Arrange
            var configuration = CreateOneToManyConfigurationContext();
            var objectToTransform = CreateOneToManyObject();

            // Act
            var result = transformer.Transform(objectToTransform, configuration);

            // Assert
            var resultData = result.Data as SingleResource;
            var linkedDict = resultData.Links.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void Creates_one_to_many_relation_links_without_duplication()
        {
            // Arrange
            var configuration = CreateOneToManyConfigurationContext();
            var objectToTransform = CreateOneToManyObject();

            // Act
            var result = transformer.Transform(objectToTransform, configuration);

            // Assert
            result.Included.ShouldHaveCountOf(2);
        }

        private object CreateOneToManyObject()
        {
            var duplicated = new NestedClass()
            {
                Id = 1000,
                SomeNestedValue = "Nested text value"
            };

            var sampleClass = new SampleClass()
            {
                Id = 1,
                SomeValue = "Some string value",
                NestedClassId = 1000,
                NestedValue = 
                
                NestedClasses = new List<NestedClass>()
                {
                    
                    new NestedClass()
                    {
                        Id = 1000,
                        SomeNestedValue = "Nested text value"
                    },
                    new NestedClass()
                    {
                        Id = 1001,
                        SomeNestedValue = "Nested text value"
                    }
                }
            };
            return sampleClass;
        }

        private SampleClass CreateObject()
        {
            var sampleClass = new SampleClass()
            {
                Id = 1,
                SomeValue = "Some string value",
                NestedClassId = 1000,
                NestedValue = new NestedClass()
                {
                    Id = 1000,
                    SomeNestedValue = "Nested text value"
                }
            };

            return sampleClass;
        }

        private Context CreateContext()
        {
            var conf = new Configuration();
            var sampleClassMapping = new ResourceMapping<SampleClass>(c => c.Id, "http://sampleClass/{id}");
            sampleClassMapping.ResourceType = "sampleClasses";
            sampleClassMapping.AddPropertyGetter("someValue", c => c.SomeValue);
            sampleClassMapping.AddPropertyGetter("nestedValue", c => c.NestedValue);


            var nestedClassMapping = new ResourceMapping<NestedClass>(c => c.Id, "nested/{id}");
            nestedClassMapping.ResourceType = "nestedClasses";
            nestedClassMapping.AddPropertyGetter("someNestedValue", c => c.SomeNestedValue);

            var linkMapping = new LinkMapping<SampleClass, NestedClass>()
            {
                RelationshipName = "nestedValues",
                ResourceGetter = c => c.NestedValue,
                ResourceMapping = nestedClassMapping,
                ResourceIdGetter = c => c.NestedClassId,
            };

            sampleClassMapping.Relationships.Add(linkMapping);

            conf.AddMapping(sampleClassMapping);
            conf.AddMapping(nestedClassMapping);

            return new Context
            {
                Configuration = conf,
                RoutePrefix = appUrl
            };

        }

        private Context CreateOneToManyConfigurationContext()
        {
            var conf = new Configuration();
            var sampleClassMapping = new ResourceMapping<SampleClass>(c => c.Id, "http://sampleClass/{id}");
            sampleClassMapping.ResourceType = "sampleClasses";
            sampleClassMapping.AddPropertyGetter("someValue", c => c.SomeValue);

            var nestedClassMapping = new ResourceMapping<NestedClass>(c => c.Id, "http://nested/{id}");
            nestedClassMapping.ResourceType = "nestedClasses";
            nestedClassMapping.AddPropertyGetter("someNestedValue", c => c.SomeNestedValue);

            var linkMapping = new LinkMapping<SampleClass, NestedClass>()
            {
                RelatedBaseResourceType = "nestedClasses",
                RelationshipName = "nestedValues",
                ResourceGetter = c => c.NestedClasses,
                ResourceMapping = nestedClassMapping,
                IsCollection = true,      
            };

            sampleClassMapping.Relationships.Add(linkMapping);

            conf.AddMapping(sampleClassMapping);
            conf.AddMapping(nestedClassMapping);

            return new Context
            {
                Configuration = conf,
                RoutePrefix = appUrl
            };

        }

        class SampleClass
        {
            public int Id { get; set; }
            public string SomeValue { get; set; }
            public NestedClass NestedValue { get; set; }
            public IEnumerable<NestedClass> NestedClasses { get; set; }
            public int NestedClassId { get; set; }
        }

        class NestedClass
        {
            public int Id { get; set; }
            public string SomeNestedValue { get; set; }
        }
    }


}