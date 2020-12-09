namespace GradeCalculator.Api.UnitTests
{
    using System;
    using FluentAssertions;
    using GradeCalculator.Api;
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
        public void AddYear_YearShouldBeAddedUpdated()
        {
            UniversityYear yearToAdd = new UniversityYear();
            yearToAdd.AddModule(new Module("Some Module", 120));

            Action addModuleAction = () => sut.AddYear(yearToAdd);
            addModuleAction.Should().NotThrow();
            sut.ListOfYears.Should().HaveCount(1);
        }

        [Test]
        public void AddYear_ShouldThrowException()
        {
            UniversityYear yearToAdd = new UniversityYear();
            yearToAdd.AddModule(new Module("Some Year1", 120));

            UniversityYear yearToAdd2 = new UniversityYear();
            yearToAdd2.AddModule(new Module("Some Year2", 120));

            UniversityYear yearToAdd3 = new UniversityYear();
            yearToAdd3.AddModule(new Module("Some Year3", 120));

            UniversityYear yearToAdd4 = new UniversityYear();
            yearToAdd4.AddModule(new Module("Some Year4", 120));

            UniversityYear yearToBreak = new UniversityYear();
            yearToBreak.AddModule(new Module("Breaking year", 120));

            sut.AddYear(yearToAdd);
            sut.AddYear(yearToAdd2);
            sut.AddYear(yearToAdd3);
            sut.AddYear(yearToAdd4);

            Action addYearAction = () => sut.AddYear(yearToBreak);
            addYearAction.Should().Throw<ArgumentException>();
            sut.ListOfYears.Should().HaveCount(4);
        }
    }
}
