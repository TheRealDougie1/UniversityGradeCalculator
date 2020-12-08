namespace GradeCalculator.Api.UnitTests
{
    using NUnit.Framework;
    using GradeCalculator.Api;
    using FluentAssertions;

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

        [TestCase(70,70,70)]
        [TestCase(30, 95, 75.5)]
        [TestCase(95, 30, 49.5)]
        [TestCase(50, 60, 57)]
        public void CalculateGradeUsingSecondAndFinalYear_CorrectGradeReturned(int secondYear, int finalYear, double result)
        {
            sut.CalculateFinalGrade(secondYear, finalYear).Should().Be(result);
        }
    }
}