using AutoMapper;
using AutoMapper.Configuration;
using System;
using Xunit;

namespace Automapper_Bug_Report_10_1_1
{
    public class ReproductionTests
    {
        /// <summary>
        ///  Automapper_Bug_Report_10_1_1.ReproductionTests.Reproduce_Successfull
        ///          Source: ReproductionTests.cs line 11
        ///  Duration: 96 ms
        ///  
        ///  Message: 
        ///  AutoMapper.AutoMapperMappingException : Error mapping types.
        ///  
        ///  Mapping types:
        ///  TestEntity -> TestDto
        ///  Automapper_Bug_Report_10_1_1.TestEntity -> Automapper_Bug_Report_10_1_1.TestDto
        ///  
        ///  Type Map configuration:
        ///  TestEntity -> TestDto
        ///  Automapper_Bug_Report_10_1_1.TestEntity -> Automapper_Bug_Report_10_1_1.TestDto
        ///  
        ///  Destination Member:
        ///  ShortSalutation
        ///  
        ///    ---- System.AccessViolationException : Automapper isn't supposed to run this method
        ///  Stack Trace: 
        ///  lambda_method(Closure, Object, TestDto, ResolutionContext)
        ///  ReproductionTests.Reproduce_Successfull() line 32
        ///      ----- Inner Stack Trace -----
        ///  TestEntity.GetShortSalutation() line 39
        ///  lambda_method(Closure, Object, TestDto, ResolutionContext)
        /// </summary>
        [Fact]
        public void Reproduce_Successfull()
        {
            var config = new MapperConfigurationExpression();
            config.CreateMap<TestEntity, TestDto>();

            var mapper = new Mapper(new MapperConfiguration(config));

            var testEntity = new TestEntity
            {
                FullTitle = "Master",
                AbbreviatedTitle = "Mr",
                Gender = "Test",
                GivenName = "Given name",
                FamilyNamePaternal = "Paternal name",
                CreatedAtUtc = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                FormalSalulation = "Master Given name Paternal name",
                ShortSalutation = "Given name",
            };

            var converted = mapper.Map<TestDto>(testEntity);

            Assert.NotNull(converted);
        }
    }
}
