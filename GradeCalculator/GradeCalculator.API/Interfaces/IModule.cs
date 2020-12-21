namespace GradeCalculator.Api.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for Modules within an <see cref="IUniversityYear"/>
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Gets the name of the module
        /// </summary>
        string ModuleName { get; }

        /// <summary>
        /// Gets the credits value of the module
        /// </summary>
        int Credits { get; }

        /// <summary>
        /// Gets the overall percentage earned from the value.
        /// </summary>
        double OverallPercentage { get; }

        /// <summary>
        /// Gets the List of Assignments for this <see cref="IModule"/>
        /// </summary>
        List<IAssignment> ListOfAssignments { get; }

        /// <summary>
        /// Adds assignment to this module
        /// </summary>
        /// <param name="assignment">Assignment to add</param>
        void AddAssignment(IAssignment assignment);
    }
}
