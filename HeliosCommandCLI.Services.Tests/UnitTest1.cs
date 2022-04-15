using Xunit;
using HeliosCommonCLI.Services;
using NUnit.Framework;
using System;
using FluentAssertions;

namespace HeliosCommandCLI.Services.Tests
{
    public class Tests
    {
        private readonly GeneratorService generatorService;

        [Fact]
        public void GenerateRandomGuids_ValidInput_Success([Range(1, 100)] int x)
        {
            generatorService.GenerateRandomGuids(x);
        }

        [Fact]
        public void GenerateRandomGuids_InputZeroOrMinus_ShouldThrow([Range(-1, 0)] int x)
        {
            Action action = () => generatorService.GenerateRandomGuids(x);

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GenerateRandomGuids_InvalidInput_ShouldThrow([Range(long.MaxValue, long.MaxValue)] int x)
        {
            Action action = () => generatorService.GenerateRandomGuids(x);

            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}