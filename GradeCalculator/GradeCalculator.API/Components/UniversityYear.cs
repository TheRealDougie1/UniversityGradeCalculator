namespace GradeCalculator.Api.Components
{
    using System;
    using System.Collections.Generic;
    using GradeCalculator.Api.Interfaces;
    using GradeCalculator.Api.Utils;

    /// <summary>
    /// University Year class, used for holding information related to a particular University Year.
    /// </summary>
    public class UniversityYear : IUniversityYear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityYear"/> class.
        /// </summary>
        /// <param name="yearType"> Year Type</param>
        public UniversityYear(UniversityYearClassification yearType)
        {
            YearType = yearType;
            TotalCredits = 0;
            ListOfModules = new List<IModule>();
            AverageScore = 0.00;
        }

        /// <inheritdoc/>
        public int TotalCredits { get; private set; }

        /// <inheritdoc/>
        public List<IModule> ListOfModules { get; private set; }

        /// <inheritdoc/>
        public double AverageScore { get; private set; }

        /// <inheritdoc/>
        public UniversityYearClassification YearType { get; private set; }

        /// <inheritdoc/>
        public void AddModule(IModule module)
        {
            if (TotalCredits + module.Credits > 120)
            {
                throw new ArgumentException();
            }

            TotalCredits += module.Credits;
            ListOfModules.Add(module);
            UpdateAverageScore();
        }

        /// <inheritdoc/>
        public void SetYearType(UniversityYearClassification newYearType)
        {
            YearType = newYearType;
        }

        private void UpdateAverageScore()
        {
            var cumultiveAverage = 0.00;
            foreach (Module module in ListOfModules)
            {
                cumultiveAverage += module.OverallPercentage * (double)module.Credits / (double)TotalCredits;
            }

            AverageScore = Math.Round(cumultiveAverage, 2);
        }
    }
}
