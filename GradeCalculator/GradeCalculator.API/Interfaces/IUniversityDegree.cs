namespace GradeCalculator.Api.Interfaces
{
    using GradeCalculator.Api.Utils;

    /// <summary>
    /// Interface for University Degree Classes.
    /// </summary>
    public interface IUniversityDegree
    {
        /// <summary>
        /// Gets the Degree Classification of this Degree.
        /// </summary>
        UniversityDegreeClassification DegreeClassification { get; }

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
