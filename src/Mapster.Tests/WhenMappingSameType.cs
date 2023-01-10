using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace Mapster.Tests
{
    [TestClass]
    public class WhenMappingSameType
    {
        [TestMethod]
        public void Should_Return_Src_Instance()
        {
            TypeAdapterConfig<SimplePoco, SimplePoco>.NewConfig()
                .Compile();

            var poco = new SimplePoco
            {
                Id = Guid.NewGuid(),
                Name1 = "Name1",
            };

            var dto = poco.Adapt<SimplePoco, SimplePoco>();
            dto.ShouldBe(poco);
        }

        [TestMethod]
        public void Should_Return_Src_Instance_Inferred_Destination_Type()
        {
            TypeAdapterConfig<SimplePoco, SimplePoco>.NewConfig()
                .Compile();

            var poco = new SimplePoco
            {
                Id = Guid.NewGuid(),
                Name1 = "Name1",
            };

            var dto = poco.Adapt<SimplePoco>();
            dto.ShouldBe(poco);
        }

        #region test classes
        public class SimplePoco
        {
            public Guid Id { get; set; }
            public string Name1 { get; set; }
        }
        #endregion
    }
}
