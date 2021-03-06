﻿namespace GradeCalculator.Api.Components
{
    using GradeCalculator.Api.Calculator;
    using GradeCalculator.Api.Interfaces;
    using GradeCalculator.Api.Utils;

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
            DegreeClassification = UniversityDegreeClassification.Fail;
        }

        /// <inheritdoc/>
        public UniversityDegreeClassification DegreeClassification { get; private set; }

        /// <inheritdoc/>
        public void AddYear(IUniversityYear yearToAdd)
        {
            yearsManager.AddYear(yearToAdd);
        }

        /// <inheritdoc/>
        public double CalculateDegreePercentage()
        {
            double calculatedPercentage;

            if (yearsManager.PlacementYear != null)
            {
                calculatedPercentage = (double)UniversityGradeCalculator.CalculateFinalGrade(yearsManager.SecondYear.AverageScore, yearsManager.FinalYear.AverageScore, yearsManager.PlacementYear.AverageScore);
            }
            else
            {
                calculatedPercentage = (double)UniversityGradeCalculator.CalculateFinalGrade(yearsManager.SecondYear.AverageScore, yearsManager.FinalYear.AverageScore);
            }

            UpdateDegreeClassification(calculatedPercentage);

            return calculatedPercentage;
        }

        /// <summary>
        /// Updates the degree classification.
        /// </summary>
        /// <param name="calculatedPercentage"> The percentage to base the classification on.</param>
        private void UpdateDegreeClassification(double calculatedPercentage)
        {
            if (calculatedPercentage >= 70)
            {
                DegreeClassification = UniversityDegreeClassification.FirstClassHonour;
                return;
            }

            if (calculatedPercentage >= 60)
            {
                DegreeClassification = UniversityDegreeClassification.UpperSecondClassHonour;
                return;
            }

            if (calculatedPercentage >= 50)
            {
                DegreeClassification = UniversityDegreeClassification.LowerSecondClassHonour;
                return;
            }

            if (calculatedPercentage >= 40)
            {
                DegreeClassification = UniversityDegreeClassification.ThirdClassHonour;
                return;
            }

            if (calculatedPercentage < 40)
            {
                DegreeClassification = UniversityDegreeClassification.Fail;
                return;
            }
        }
    }
}
