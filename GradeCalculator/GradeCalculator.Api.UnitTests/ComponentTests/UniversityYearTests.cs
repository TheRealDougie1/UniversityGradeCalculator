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
            sut.CurrentAverageScore.Should().Be(82.5);
            sut.SecuredScore.Should().Be(16.5);
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

        [TestCase(UniversityYearClassification.SecondYearNoPlacement, 30, UniversityYearClassification.SecondYearWithPlacement)]
        [TestCase(UniversityYearClassification.SecondYearWithPlacement, 20, UniversityYearClassification.SecondYearNoPlacement)]
        public void SetNewYearType_UniversityYearClassificationUpdated(
            UniversityYearClassification yearIdentifier,
            int percentage,
            UniversityYearClassification updatedYearIdentifier)
        {
            sut = new UniversityYear(yearIdentifier);
            sut.YearType.Should().Be(yearIdentifier);
            sut.YearType.Should().Be(percentage);

            sut.SetYearType(updatedYearIdentifier);
            sut.YearType.Should().Be(updatedYearIdentifier);
        }
        
        [Test]
        public void Add120CreditsWorthOfModules_AverageGradeIsCorrect()
        {
            Module moduleToAdd1 = new Module("OOADS", 20, 76);
            Module moduleToAdd2 = new Module("Comm Networks", 20, 62);
            Module moduleToAdd3 = new Module("Group Project", 20, 72);
            Module moduleToAdd4 = new Module("Enterprise Architecture", 10, 86);
            Module moduleToAdd5 = new Module("Systems Modelling", 10, 71);
            Module moduleToAdd6 = new Module("Employability", 10, 71);
            Module moduleToAdd7 = new Module("Data Vis", 10, 60);
            Module moduleToAdd8 = new Module("DB systems", 10, 71);
            Module moduleToAdd9 = new Module("HCI", 10, 73);

            sut.AddModule(moduleToAdd1);
            sut.AddModule(moduleToAdd2);
            sut.AddModule(moduleToAdd3);
            sut.AddModule(moduleToAdd4);
            sut.AddModule(moduleToAdd5);
            sut.AddModule(moduleToAdd6);
            sut.AddModule(moduleToAdd7);
            sut.AddModule(moduleToAdd8);
            sut.AddModule(moduleToAdd9);

            sut.CurrentAverageScore.Should().Be(71);
        }
    }
}
