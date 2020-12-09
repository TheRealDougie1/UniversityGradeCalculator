namespace GradeCalculator.Api.UnitTests
{
    using System;
    using FluentAssertions;
    using GradeCalculator.Api;
    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the <see cref="UniversityYear"/> class.
    /// </summary>
    public class UniversityYearTests
    {
        private IUniversityYear sut;

        [SetUp]
        public void Setup()
        {
            sut = new UniversityYear();
        }

        [Test]
        public void UniversityYearInitialised_ShouldHaveListOfModules()
        {
            sut.ListOfModules.Should().NotBeNull();
        }

        [TestCase("Human Computer Interaction", 20, 76.5)]
        [TestCase("Forensics", 10, 80)]
        [TestCase("Placement Year Module", 120, 86.7)]
        public void AddModule_ModuleShouldBeAddedAndCreditsUpdated(string moduleName, int moduleCredits, double modulePercentage)
        {
            Module moduleToAdd = new Module(moduleName, moduleCredits, modulePercentage);
            Action addModuleAction = () => sut.AddModule(moduleToAdd);
            addModuleAction.Should().NotThrow();
            sut.ListOfModules.Should().HaveCount(1);
            sut.TotalCredits.Should().BeLessOrEqualTo(120);
        }

        [Test]
        public void AddModuleWithUniYearCreditsAt120_ShouldThrowException()
        {
            Module maxCreditModule = new Module("Placement Year Module", 120, 86.75);
            sut.AddModule(maxCreditModule);

            Module moduleToThrowException = new Module("A module that should not exist", 10, 90);

            Action addModuleAction = () => sut.AddModule(moduleToThrowException);
            addModuleAction.Should().Throw<ArgumentException>();
            sut.ListOfModules.Should().HaveCount(1);
            sut.TotalCredits.Should().Be(120);
        }

        [Test]
        public void AddMultipleModules_TotalCreditsShouldBeUpdated()
        {
            Module moduleToAdd1 = new Module("Security", 10, 85);
            sut.AddModule(moduleToAdd1);
            Module moduleToAdd2 = new Module("Forensics", 10, 80);
            sut.AddModule(moduleToAdd2);

            sut.ListOfModules.Should().HaveCount(2);
            sut.TotalCredits.Should().Be(20);
        }
    }
}
