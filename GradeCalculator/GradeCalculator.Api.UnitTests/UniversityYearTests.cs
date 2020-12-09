namespace GradeCalculator.Api.UnitTests
{
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
        public void UniversityYearInitialised_ShouldHave120Credits()
        {
            sut.TotalCredits.Should().Be(120);
        }
    }
}
