namespace GradeCalculator.Api.UnitTests.ComponentTests
{
    using System;
    using FluentAssertions;
    using GradeCalculator.Api.Components;
    using GradeCalculator.Api.Interfaces;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="Module"/> class.
    /// </summary>
    public class ModuleTests
    {
        private IModule sut;

        [TestCase("Artificial Intelligence", 10)]
        [TestCase("Some String", 20)]
        public void ModuleInitialized_ShouldHaveNameAndCredits(string moduleName, int credits)
        {
            sut = new Module(moduleName, credits);
            sut.ModuleName.Should().Be(moduleName);
            sut.Credits.Should().Be(credits);
        }

        [TestCase("Artificial Intelligence", 10, 70)]
        [TestCase("Some String", 20, 0)]
        public void ModuleInitializedWithOverallPercentage_ShouldHaveNameAndCreditsAndOverallPercentage(string moduleName, int credits, double overallPercentage)
        {
            sut = new Module(moduleName, credits, overallPercentage);
            sut.ModuleName.Should().Be(moduleName);
            sut.Credits.Should().Be(credits);
            sut.OverallPercentage.Should().Be(overallPercentage);
        }

        [TestCase("1234", 10, 70)]
        [TestCase("Coding stuff", 10, 700)]
        [TestCase("Some string here", -1, 70)]
        [TestCase("String here", 123, 101)]
        [TestCase("Some string here again", 20, -100)]
        [TestCase("These strings wont stop", 20, 101)]
        public void ModuleInitializedWithInvalidParameters_ShouldThrowException(string moduleName, int credits, double overallPercentage)
        {
            Action actionOfInitModule = () => sut = new Module(moduleName, credits, overallPercentage);
            actionOfInitModule.Should().ThrowExactly<ArgumentException>();
        }
    }
}
