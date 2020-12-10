namespace GradeCalculator.Api.UnitTests.ComponentTests
{
    using System;
    using FluentAssertions;
    using GradeCalculator.Api.Components;
    using GradeCalculator.Api.Interfaces;
    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the <see cref="UniversityDegree"/> class.
    /// </summary>
    public class UniversityDegreeTests
    {
        private IUniversityDegree sut;

        [SetUp]
        public void Setup()
        {
            sut = new UniversityDegree();
        }

        [Test]
        public void UniversityDegreeInitialized_ShouldHaveListOfYears()
        {
            sut = new UniversityDegree();
            sut.ListOfYears.Should().NotBeNull();
        }

        [Test]
        public void AddYearWithNoOtherYearsAdded_YearShouldBeAdded()
        {
            UniversityYear yearToAdd = new UniversityYear();
            yearToAdd.AddModule(new Module("Some Module", 120));

            Action addModuleAction = () => sut.AddYear(yearToAdd);
            addModuleAction.Should().NotThrow();
            sut.ListOfYears.Should().HaveCount(1);
        }

        [Test]
        public void AddYearWithMaximumYearsAlreadyAdded_ShouldThrowArgumentException()
        {
            UniversityYear secondYear = new UniversityYear();
            secondYear.AddModule(new Module("Second Year Module", 120));

            UniversityYear thirdYear = new UniversityYear();
            thirdYear.AddModule(new Module("Third Year Module", 120));

            UniversityYear placementYear = new UniversityYear();
            placementYear.AddModule(new Module("Placement year Module", 120));

            UniversityYear yearToBreak = new UniversityYear();
            yearToBreak.AddModule(new Module("Breaking year", 120));

            sut.AddYear(secondYear);
            sut.AddYear(thirdYear);
            sut.AddYear(placementYear);

            Action addYearAction = () => sut.AddYear(yearToBreak);
            addYearAction.Should().ThrowExactly<ArgumentException>();
            sut.ListOfYears.Should().HaveCount(3);
        }

        [Test]
        public void CalculateFinalGradeWithSecondAndThirdYear_FinalGradeCalculated()
        {
            UniversityYear secondYear = new UniversityYear();
            secondYear.AddModule(new Module("Second Year Module", 120, 70));
            UniversityYear thirdYear = new UniversityYear();
            thirdYear.AddModule(new Module("Third Year Module", 120, 70));

            sut.AddYear(secondYear);
            sut.AddYear(thirdYear);

            sut.CalculateDegreePercentage().Should().Be(70);
        }
    }
}
