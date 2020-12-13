namespace GradeCalculator.Api.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for University Degree Classes.
    /// </summary>
    public interface IUniversityDegree
    {
        /// <summary>
        /// Add a <see cref="IUniversityYear"/>  to <see cref="ListOfYears"/>
        /// </summary>
        /// <param name="universityYear"> University Year to Add </param>
        void AddYear(IUniversityYear universityYear);

        /// <summary>
        /// Calculates the overall grade of the <see cref="IUniversityDegree"/>
        /// </summary>
        /// <returns> The calculated degree percentage</returns>
        double CalculateDegreePercentage();
    }
}
