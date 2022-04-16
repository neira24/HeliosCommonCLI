using Xunit;
using System;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions.Extensions;

namespace HeliosCommonCLI.Services.Tests.ServicesTests
{
    public class GeneratorServiceTests
    {
        private readonly GeneratorService _generatorService;

        public GeneratorServiceTests()
        {
            _generatorService = new GeneratorService();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void GenerateRandomGuids_ValidInput_Success(int x)
        {
            _generatorService.GenerateRandomGuids(x);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GenerateRandomGuids_InputZeroOrMinus_ShouldThrow(int x)
        {
            Action action = () => _generatorService.GenerateRandomGuids(x);

            action.Should().Throw<ArgumentException>();
        }

        [Theory, AutoData]
        public void GenerateRandomGuids_InvalidInput_ShouldThrow([Range(int.MaxValue,int.MaxValue)] int x)
        {
            Action action = () => _generatorService.GenerateRandomGuids(x);

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GenerateRandomGuids_Performance_ShouldRunIn()
        {
            var sss = 1000000;
            _generatorService.ExecutionTimeOf(s => s.GenerateRandomGuids(sss)).Should().BeLessThanOrEqualTo(2000.Milliseconds());
          
        }
    }
}