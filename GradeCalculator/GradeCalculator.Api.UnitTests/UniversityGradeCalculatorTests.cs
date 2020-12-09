namespace GradeCalculator.Api.UnitTests
{
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using GradeCalculator.Api;
    using NUnit.Framework;

    /// <summary>
    /// Unit Tests for the <see cref="UniversityGradeCalculator"/> class
    /// </summary>
    public class Tests
    {
        private UniversityGradeCalculator sut;

        [SetUp]
        public void Setup()
        {
            sut = new UniversityGradeCalculator();
        }

        [TestCase(70, 70, 70)]
        [TestCase(30, 95, 75.5)]
        [TestCase(95, 30, 49.5)]
        [TestCase(50, 60, 57)]
        [TestCase(70.2, 80.3, 77.27)]
        [TestCase(99.9, 99.3, 99.48)]
        public void CalculateGradeUsingSecondAndFinalYear_CorrectGradeReturned(double secondYear, double finalYear, double result)
        {
            sut.CalculateFinalGrade(secondYear, finalYear).Should().Be(result);
        }

        [TestCase(70, 70, 70, 70)]
        [TestCase(71, 86, 70, 71.8)]
        [TestCase(100, 100, 100, 100)]
        [TestCase(0, 0, 0, 0)]
        [TestCase(70, 0, 0, 14.0)]
        [TestCase(0, 70, 0, 7)]
        [TestCase(0, 0, 70, 49.0)]
        [TestCase(45.8, 69.1, 50.0, 51.07)]
        public void CalculateGradeUsingSecondPlacementAndFinalYear_CorrectGradeReturned(double secondYear, double placementYear, double finalYear, double result)
        {
            sut.CalculateFinalGrade(secondYear, finalYear, placementYear).Should().Be(result);
        }

        [TestCase(0, -1, 0, null)]
        [TestCase(10, null, 10, 9)]
        [TestCase(-10, -1, -30, null)]
        [TestCase(-99999, -99999, -99999, null)]
        [TestCase(-99.88, -1.23, 7.6, null)]
        [TestCase(70.9, -1.23, 7.6, null)]
        [TestCase(70.9, -0.1, 7.6, null)]
        public void CalculateGradeAndTestValidation_CorrectProceduresFollowed(double secondYear, double placementYear, double finalYear, double? result)
        {
            sut.CalculateFinalGrade(secondYear, finalYear, placementYear).Should().Be(result);
        }
    }
}