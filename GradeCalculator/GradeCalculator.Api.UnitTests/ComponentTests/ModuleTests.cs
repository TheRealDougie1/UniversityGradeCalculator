namespace GradeCalculator.Api.UnitTests.ComponentTests
{
    using System;
    using FluentAssertions;
    using GradeCalculator.Api.Components;
    using GradeCalculator.Api.Interfaces;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="Module"/> class.
    /// </summary>
    public class ModuleTests
    {
        private IModule sut;

        [TestCase("Artificial Intelligence", 10)]
        [TestCase("Some String", 20)]
        public void ModuleInitialized_ShouldHaveNameAndCredits(string moduleName, int credits)
        {
            sut = new Module(moduleName, credits);
            sut.ModuleName.Should().Be(moduleName);
            sut.Credits.Should().Be(credits);
        }

        [TestCase("Artificial Intelligence", 10, 70)]
        [TestCase("Some String", 20, 0)]
        public void ModuleInitializedWithOverallPercentage_ShouldHaveNameAndCreditsAndOverallPercentage(string moduleName, int credits, double overallPercentage)
        {
            sut = new Module(moduleName, credits, overallPercentage);
            sut.ModuleName.Should().Be(moduleName);
            sut.Credits.Should().Be(credits);
            sut.OverallPercentage.Should().Be(overallPercentage);
        }

        [TestCase("1234", 10, 70)]
        [TestCase("Coding stuff", 10, 700)]
        [TestCase("Some string here", -1, 70)]
        [TestCase("String here", 123, 101)]
        [TestCase("Some string here again", 20, -100)]
        [TestCase("These strings wont stop", 20, 101)]
        public void ModuleInitializedWithInvalidParameters_ShouldThrowException(string moduleName, int credits, double overallPercentage)
        {
            Action actionOfInitModule = () => sut = new Module(moduleName, credits, overallPercentage);
            actionOfInitModule.Should().ThrowExactly<ArgumentException>();
        }

        [Test]
        public void AddAssignment_AssignmentAdded()
        {
            sut = new Module("Generic Module", 10);
            Assignment assignmentToAdd = new Assignment("Exam 1", 50, 70);
            sut.AddAssignment(assignmentToAdd);
            sut.ListOfAssignments.Should().HaveCount(1);
        }

        [TestCase("Generic Module With Overall Percentage", 10, 70)]
        [TestCase("Generic Module Without Overall Percentage", 10)]
        public void AddAssignment_ModuleOverallPercentageChanged(string moduleName, int credits, double? overallPercentage = null)
        {
            sut = new Module(moduleName, credits, overallPercentage);
            Assignment assignmentToAdd = new Assignment("Exam 1", 100, 30);
            sut.AddAssignment(assignmentToAdd);
            sut.OverallPercentage.Should().Be(30);
        }

        [Test]
        public void AddMultipleAssignments_ModuleOverallPercentageCalculated()
        {
            sut = new Module("Generic Module", 10);
            Assignment assignmentToAdd1 = new Assignment("Exam 1", 33, 69.7);
            Assignment assignmentToAdd2 = new Assignment("Exam 2", 33, 93.9);
            Assignment assignmentToAdd3 = new Assignment("Exam 3", 34, 70);

            sut.AddAssignment(assignmentToAdd1);
            sut.AddAssignment(assignmentToAdd2);
            sut.AddAssignment(assignmentToAdd3);

            sut.OverallPercentage.Should().Be(77.79);
        }
    }
}
