namespace GradeCalculator.Api.UnitTests.ComponentTests
{
    using System;
    using FluentAssertions;
    using GradeCalculator.Api.Components;
    using GradeCalculator.Api.Interfaces;
    using GradeCalculator.Api.Utils;
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
            sut = new UniversityYear(UniversityYearClassification.FinalYear);
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

        [Test]
        public void AddMultipleModulesWithScores_ScoresShouldBeUpdated()
        {
            Module moduleToAdd1 = new Module("Security", 10, 85);
            sut.AddModule(moduleToAdd1);
            Module moduleToAdd2 = new Module("Forensics", 10, 80);
            sut.AddModule(moduleToAdd2);

            sut.ListOfModules.Should().HaveCount(2);
            sut.AverageScore.Should().Be(82.5);
        }

        [TestCase(UniversityYearClassification.FinalYear, 70)]
        [TestCase(UniversityYearClassification.SecondYearNoPlacement, 30)]
        [TestCase(UniversityYearClassification.SecondYearWithPlacement, 20)]
        [TestCase(UniversityYearClassification.PlacementYear, 10)]
        public void InitYearWithUniversityYearClassification_ShouldHaveCorrectEnum(UniversityYearClassification yearIdentifier, int percentage)
        {
            sut = new UniversityYear(yearIdentifier);
            sut.YearType.Should().Be(yearIdentifier);
            sut.YearType.Should().Be(percentage);
        }
    }
}
