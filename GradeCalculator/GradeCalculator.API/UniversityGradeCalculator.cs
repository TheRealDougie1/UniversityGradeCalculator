namespace GradeCalculator.Api
{
    using System;

    /// <summary>
    /// Class used for calculating a final, end of course university grade.
    /// </summary>
    public class UniversityGradeCalculator
    {
        /// <summary>
        /// Calculates the Final University Grade.
        /// </summary>
        /// <param name="secondYearGrade">Overall grade achieved in second year</param>
        /// <param name="finalYearGrade">Overall grade achieved in final year</param>
        /// <param name="placementYearGrade">Overall grade achieved in placement year, if taken.</param>
        /// <returns>The overall final grade achieved</returns>
        public double CalculateFinalGrade(double secondYearGrade, double finalYearGrade, double placementYearGrade = -1)
        {
            if (placementYearGrade == -1)
            {
                return Math.Round(secondYearGrade * 0.3 + finalYearGrade * 0.7,2);
            }

            return Math.Round(secondYearGrade * 0.2 + placementYearGrade * 0.1 + finalYearGrade * 0.7,2);
        }
    }
}
