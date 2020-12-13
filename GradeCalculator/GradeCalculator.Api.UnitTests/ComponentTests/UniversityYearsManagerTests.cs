namespace GradeCalculator.Api.UnitTests.ComponentTests
{
    using FluentAssertions;
    using GradeCalculator.Api.Components;
    using GradeCalculator.Api.Utils;
    using NUnit.Framework;

    public class UniversityYearsManagerTests
    {
        private UniversityYearsManager sut;

        [SetUp]
        public void SetUp()
        {
            sut = new UniversityYearsManager();
        }

        [TestCase(UniversityYearClassification.FinalYear)]
        [TestCase(UniversityYearClassification.PlacementYear)]
        [TestCase(UniversityYearClassification.SecondYearNoPlacement)]
        [TestCase(UniversityYearClassification.SecondYearWithPlacement)]
        public void YearAdded_YearAddedCorrectly(UniversityYearClassification yearType)
        {
            var yearToAdd = new UniversityYear(yearType);
            sut.AddYear(yearToAdd);
            switch (yearType)
            {
                case UniversityYearClassification.FinalYear:
                    sut.FinalYear.Should().Be(yearToAdd);
                    return;
                case UniversityYearClassification.PlacementYear:
                    sut.PlacementYear.Should().Be(yearToAdd);
                    return;
                case UniversityYearClassification.SecondYearNoPlacement:
                    sut.SecondYear.Should().Be(yearToAdd);
                    return;
                case UniversityYearClassification.SecondYearWithPlacement:
                    sut.SecondYear.Should().Be(yearToAdd);
                    return;
                default:
                    Assert.Fail();
                    return;
            }   
        }

        [Test]
        public void PlacementAddedAfterSecondYearNoPlacementAdded_PlacementYearSetAndSecondYearUpdated()
        {
            var secondYear = new UniversityYear(UniversityYearClassification.SecondYearNoPlacement);
            sut.AddYear(secondYear);
            sut.SecondYear.YearType.Should().Be(UniversityYearClassification.SecondYearNoPlacement);

            var placementYear = new UniversityYear(UniversityYearClassification.PlacementYear);
            sut.AddYear(placementYear);
            sut.PlacementYear.Should().Be(placementYear);
            sut.SecondYear.YearType.Should().Be(UniversityYearClassification.SecondYearWithPlacement);
        }

        [Test]
        public void SecondYearAddedAfterPlacement_PlacementYearSetAndSecondYearUpdated()
        {
            var placementYear = new UniversityYear(UniversityYearClassification.PlacementYear);
            sut.AddYear(placementYear);
            sut.PlacementYear.Should().Be(placementYear);

            var secondYear = new UniversityYear(UniversityYearClassification.SecondYearNoPlacement);
            sut.AddYear(secondYear);
            sut.SecondYear.YearType.Should().Be(UniversityYearClassification.SecondYearWithPlacement);
        }

        [Test]
        public void AddDuplicateYear_YearUpdated()
        {
            var secondYear = new UniversityYear(UniversityYearClassification.SecondYearNoPlacement);
            sut.AddYear(secondYear);
            sut.SecondYear.Should().BeSameAs(secondYear);

            var secondYearUpdated = new UniversityYear(UniversityYearClassification.SecondYearWithPlacement);
            sut.AddYear(secondYearUpdated);
            sut.SecondYear.Should().BeSameAs(secondYearUpdated);
        }
    }
}
