namespace GradeCalculator.Api.Components
{
    using System;
    using System.Collections.Generic;
    using GradeCalculator.Api.Calculator;
    using GradeCalculator.Api.Interfaces;

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
            if (ListOfYears.Count == 2)
            {
                return (double)UniversityGradeCalculator.CalculateFinalGrade(ListOfYears[0].AverageScore, ListOfYears[1].AverageScore);
            }

            return 0;
        }
    }
}
