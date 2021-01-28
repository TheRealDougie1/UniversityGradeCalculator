namespace GradeCalculator.Api.UnitTests.ComponentTests
{
    using System;
    using FluentAssertions;
    using GradeCalculator.Api.Components;
    using GradeCalculator.Api.Interfaces;
    using GradeCalculator.Api.Utils;
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
        public void AddYearWithNoOtherYearsAdded_YearShouldBeAdded()
        {
            UniversityYear yearToAdd = new UniversityYear(UniversityYearClassification.SecondYearNoPlacement);
            yearToAdd.AddModule(new Module("Some Module", 120));

            Action addModuleAction = () => sut.AddYear(yearToAdd);
            addModuleAction.Should().NotThrow();
        }

        [Test]
        public void CalculateFinalGradeWithSecondAndThirdYear_FinalGradeCalculated()
        {
            UniversityYear secondYear = new UniversityYear(UniversityYearClassification.SecondYearNoPlacement);
            secondYear.AddModule(new Module("Second Year Module", 120, 80));
            UniversityYear thirdYear = new UniversityYear(UniversityYearClassification.FinalYear);
            thirdYear.AddModule(new Module("Third Year Module", 120, 60));

            sut.AddYear(secondYear);
            sut.AddYear(thirdYear);

            sut.CalculateDegreePercentage().Should().Be(66.0);
            sut.DegreeClassification.Should().Be(UniversityDegreeClassification.UpperSecondClassHonour);
        }

        [Test]
        public void CalculateFinalGradeWithSecondThirdAndPlacementYear_FinalGradeCalculated()
        {
            UniversityYear secondYear = new UniversityYear(UniversityYearClassification.SecondYearWithPlacement);
            secondYear.AddModule(new Module("Second Year Module", 120, 71.2));
            UniversityYear placementYear = new UniversityYear(UniversityYearClassification.PlacementYear);
            placementYear.AddModule(new Module("Placement Year Module", 120, 86.6));
            UniversityYear finalYear = new UniversityYear(UniversityYearClassification.FinalYear);
            finalYear.AddModule(new Module("Final Year Module", 120, 65));

            sut.AddYear(secondYear);
            sut.AddYear(placementYear);
            sut.AddYear(finalYear);

            sut.CalculateDegreePercentage().Should().Be(68.4);
            sut.DegreeClassification.Should().Be(UniversityDegreeClassification.UpperSecondClassHonour);
        }

        [Test]
        public void CalculateFinalGradeWithYearsAddedInIncorrectOrder_CorrectFinalGradeCalculated()
        {
            UniversityYear secondYear = new UniversityYear(UniversityYearClassification.SecondYearWithPlacement);
            secondYear.AddModule(new Module("Second Year Module", 120, 71.2));
            UniversityYear placementYear = new UniversityYear(UniversityYearClassification.PlacementYear);
            placementYear.AddModule(new Module("Placement Year Module", 120, 86.6));
            UniversityYear finalYear = new UniversityYear(UniversityYearClassification.FinalYear);
            finalYear.AddModule(new Module("Final Year Module", 120, 65));

            sut.AddYear(secondYear);
            sut.AddYear(finalYear);
            sut.AddYear(placementYear);
            
            sut.CalculateDegreePercentage().Should().Be(68.4);
            sut.DegreeClassification.Should().Be(UniversityDegreeClassification.UpperSecondClassHonour);
        }

        [Test]
        public void CalculateDegreePercentageBelowPass_GradeClassificationShouldBeFail()
        {
            UniversityYear secondYear = new UniversityYear(UniversityYearClassification.SecondYearWithPlacement);
            secondYear.AddModule(new Module("Second Year Module", 120, 30));
            UniversityYear placementYear = new UniversityYear(UniversityYearClassification.PlacementYear);
            placementYear.AddModule(new Module("Placement Year Module", 120, 12));
            UniversityYear finalYear = new UniversityYear(UniversityYearClassification.FinalYear);
            finalYear.AddModule(new Module("Final Year Module", 120, 10));

            sut.AddYear(secondYear);
            sut.AddYear(finalYear);
            sut.AddYear(placementYear);

            sut.CalculateDegreePercentage().Should().Be(14.2);
            sut.DegreeClassification.Should().Be(UniversityDegreeClassification.Fail);
        }

        [Test]
        public void CalculateRemainingAverageScoreRequired_CorrectRemainderCalculated()
        {
            UniversityYear secondYear = new UniversityYear(UniversityYearClassification.SecondYearWithPlacement);
            secondYear.AddModule(new Module("Second Year Module", 120, 71.2));
            UniversityYear placementYear = new UniversityYear(UniversityYearClassification.PlacementYear);
            placementYear.AddModule(new Module("Placement Year Module", 120, 86.6));
            UniversityYear finalYear = new UniversityYear(UniversityYearClassification.FinalYear);
            finalYear.AddModule(new Module("Final Year Module", 60, 50));

            sut.AddYear(secondYear);
            sut.AddYear(finalYear);
            sut.AddYear(placementYear);

            sut.CalculateRemainingAverageScoreRequired(70);
        }
    }
}
