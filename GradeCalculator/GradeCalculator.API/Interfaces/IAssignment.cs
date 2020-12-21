namespace GradeCalculator.Api.Interfaces
{
    /// <summary>
    /// Assignment Interface, for assignments within a <see cref="IModule"/>
    /// </summary>
    public interface IAssignment
    {
        /// <summary>
        /// Gets the name of the assignment
        /// </summary>
        string AssignmentName { get; }

        /// <summary>
        /// Gets the weight of the assignment
        /// </summary>
        int Weighting { get; }

        /// <summary>
        /// Gets the overall mark of the assignment.
        /// </summary>
        double OverallMark { get; }
    }
}
