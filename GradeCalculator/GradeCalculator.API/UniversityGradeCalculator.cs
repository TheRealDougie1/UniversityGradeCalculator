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
        public double? CalculateFinalGrade(double secondYearGrade, double finalYearGrade, double? placementYearGrade = null)
        {
            if ( secondYearGrade < 0 || finalYearGrade < 0 || placementYearGrade < 0)
            {
                return null;
            }

            if (placementYearGrade == null)
            {
                return Math.Round(secondYearGrade * 0.3 + finalYearGrade * 0.7,2);
            }

            double actualPlacementYear = (double)placementYearGrade;

            return Math.Round(secondYearGrade * 0.2 + actualPlacementYear * 0.1 + finalYearGrade * 0.7,2);
        }
    }
}
