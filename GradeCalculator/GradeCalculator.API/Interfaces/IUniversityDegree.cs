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

        /// <summary>
        /// Calculates the remaining average score required to get the target grade
        /// </summary>
        /// <param name="targetGrade"> Target grade to get </param>
        /// <returns>The remaining average score required to the get the target grade</returns>
        double CalculateRemainingAverageScoreRequired(double targetGrade);
    }
}
