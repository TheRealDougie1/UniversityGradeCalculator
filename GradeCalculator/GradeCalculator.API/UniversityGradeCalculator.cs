namespace GradeCalculator.Api
{

    /// <summary>
    /// Class used for calculating a final, end of course university grade.
    /// </summary>
    public class UniversityGradeCalculator
    {
        /// <summary>
        /// Calculates the Final University Grade.
        /// </summary>
        /// <returns></returns>
        public double CalculateFinalGrade(int secondYearGrade, int finalYearGrade)
        {
            return secondYearGrade * 0.3 + finalYearGrade * 0.7;
        }
    }
}
