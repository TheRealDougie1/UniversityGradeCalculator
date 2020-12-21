namespace GradeCalculator.Api.UnitTests.ComponentTests
{
    using System;
    using FluentAssertions;
    using GradeCalculator.Api.Components;
    using GradeCalculator.Api.Interfaces;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="Assignment"/> class.
    /// </summary>
    public class AssignmentTests
    {
        private IAssignment sut;

        [TestCase("Exam", 70)]
        [TestCase("Coursework", 20)]
        public void AssignmentInitialized_ShouldHaveNameAndCredits(string assignmentName, int weighting)
        {
            sut = new Assignment(assignmentName, weighting);
            sut.AssignmentName.Should().Be(assignmentName);
            sut.Weighting.Should().Be(weighting);
        }

        [TestCase("Exam", 70, 69)]
        [TestCase("Coursework", 20, 50)]
        public void AssignmentInitializedWithOverallPercentage_ShouldHaveNameAndCreditsAndOverallPercentage(string assignmentName, int weighting, double overallMark)
        {
            sut = new Assignment(assignmentName, weighting, overallMark);
            sut.AssignmentName.Should().Be(assignmentName);
            sut.Weighting.Should().Be(weighting);
            sut.OverallMark.Should().Be(overallMark);
        }

        [TestCase("1234", 10, 70)]
        [TestCase("Coding stuff", 10, 700)]
        [TestCase("Some string here", -1, 70)]
        [TestCase("String here", 123, 101)]
        [TestCase("Some string here again", 20, -100)]
        [TestCase("These strings wont stop", 20, 101)]
        public void AssignmentInitializedWithInvalidParameters_ShouldThrowException(string assignmentName, int weighting, double overallMark)
        {
            Action actionOfInitModule = () => sut = new Assignment(assignmentName, weighting, overallMark);
            actionOfInitModule.Should().ThrowExactly<ArgumentException>();
        }
    }
}
