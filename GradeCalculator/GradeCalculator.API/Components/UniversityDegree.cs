namespace GradeCalculator.Api.Components
{
    using System;
    using System.Collections.Generic;
    using GradeCalculator.Api.Calculator;
    using GradeCalculator.Api.Interfaces;
    using GradeCalculator.Api.Utils;

    /// <summary>
    /// University Degree class
    /// </summary>
    public class UniversityDegree : IUniversityDegree
    {
        /// <summary>
        /// Total credits of the degree
        /// </summary>
        private int totalCredits = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityDegree"/> class.
        /// </summary>
        public UniversityDegree()
        {
            ListOfYears = new List<IUniversityYear>();
        }

        /// <inheritdoc/>
        public List<IUniversityYear> ListOfYears { get; private set; }

        /// <inheritdoc/>
        public void AddYear(IUniversityYear yearToAdd)
        {
            if (ListOfYears.Count == 4 || totalCredits == 360)
            {
                throw new ArgumentException();
            }

            ListOfYears.Add(yearToAdd);
            totalCredits += yearToAdd.TotalCredits;
        }

        /// <inheritdoc/>
        public double CalculateDegreePercentage()
        {
            UniversityYear secondYear = null;
            UniversityYear finalYear = null;
            UniversityYear placementYear = null;

            foreach (UniversityYear universityYear in ListOfYears)
            {
                switch (universityYear.YearType)
                {
                    case UniversityYearClassification.FinalYear:
                        finalYear = universityYear;
                        break;
                    case UniversityYearClassification.PlacementYear:
                        placementYear = universityYear;
                        break;
                    case UniversityYearClassification.SecondYearWithPlacement:
                        secondYear = universityYear;
                        break;
                    case UniversityYearClassification.SecondYearNoPlacement:
                        secondYear = universityYear;
                        break;
                }
            }

            if (placementYear != null)
            {
                return (double)UniversityGradeCalculator.CalculateFinalGrade(secondYear.AverageScore, finalYear.AverageScore, placementYear.AverageScore);
            }

            return (double)UniversityGradeCalculator.CalculateFinalGrade(secondYear.AverageScore, finalYear.AverageScore);
        }
    }
}
