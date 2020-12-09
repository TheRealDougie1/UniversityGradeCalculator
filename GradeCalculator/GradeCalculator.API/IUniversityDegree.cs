namespace GradeCalculator.Api
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for University Degree Classes.
    /// </summary>
    public interface IUniversityDegree
    {
        /// <summary>
        /// Gets a list of <see cref="IUniversityYear"/>s
        /// </summary>
        List<IUniversityYear> ListOfYears { get; }

        /// <summary>
        /// Add a <see cref="IUniversityYear"/>  to <see cref="ListOfYears"/>
        /// </summary>
        /// <param name="universityYear"> University Year to Add </param>
        void AddYear(IUniversityYear universityYear);
    }
}
