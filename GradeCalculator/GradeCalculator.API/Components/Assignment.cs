namespace GradeCalculator.Api.Components
{
    using System;
    using System.Text.RegularExpressions;
    using GradeCalculator.Api.Interfaces;

    /// <summary>
    /// Assignment class, used to represent an assignment within a <see cref="Module"/>
    /// </summary>
    public class Assignment : IAssignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Assignment"/> class.
        /// </summary>
        /// <param name="assignmentName"> Name of the assignment </param>
        /// <param name="weighting"> Weighting of the module </param>
        /// <param name="overallMark"> Percentage earned on the assignment. </param>
        public Assignment(string assignmentName, int weighting, double? overallMark = null)
        {
            Regex nameRX = new Regex(@"[A-Za-z]");

            if (!nameRX.IsMatch(assignmentName))
            {
                throw new ArgumentException("Assignment Name does not satisfy Regex.");
            }

            if (weighting < 0 || weighting > 100)
            {
                throw new ArgumentException("Invalid Assignment weighting.");
            }

            AssignmentName = assignmentName;
            Weighting = weighting;

            if (overallMark == null)
            {
                return;
            }

            if (overallMark >= 0 && overallMark <= 100)
            {
                OverallMark = (double)overallMark;
                return;
            }

            throw new ArgumentException();
        }

        /// <inheritdoc/>
        public string AssignmentName { get; private set; }

        /// <inheritdoc/>
        public int Weighting { get; private set; }

        /// <inheritdoc/>
        public double OverallMark { get; private set; }
    }
}
