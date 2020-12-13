namespace GradeCalculator.Api.Components
{
    using GradeCalculator.Api.Calculator;
    using GradeCalculator.Api.Interfaces;

    /// <summary>
    /// University Degree class
    /// </summary>
    public class UniversityDegree : IUniversityDegree
    {
        /// <summary>
        /// Manager for the university years in this <see cref="UniversityDegree"/>
        /// </summary>
        private readonly UniversityYearsManager yearsManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityDegree"/> class.
        /// </summary>
        public UniversityDegree()
        {
            yearsManager = new UniversityYearsManager();
        }

        /// <inheritdoc/>
        public void AddYear(IUniversityYear yearToAdd)
        {
            yearsManager.AddYear(yearToAdd);
        }

        /// <inheritdoc/>
        public double CalculateDegreePercentage()
        {
            if (yearsManager.PlacementYear != null)
            {
                return (double)UniversityGradeCalculator.CalculateFinalGrade(yearsManager.SecondYear.AverageScore, yearsManager.FinalYear.AverageScore, yearsManager.PlacementYear.AverageScore);
            }

            return (double)UniversityGradeCalculator.CalculateFinalGrade(yearsManager.SecondYear.AverageScore, yearsManager.FinalYear.AverageScore);
        }
    }
}
