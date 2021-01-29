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
            CurrentAverageScore = 0.00;
            SecuredScore = 0.00;
        }

        /// <inheritdoc/>
        public int TotalCredits { get; private set; }

        /// <inheritdoc/>
        public List<IModule> ListOfModules { get; private set; }

        /// <inheritdoc/>
        public double CurrentAverageScore { get; private set; }

        /// <inheritdoc/>
        public double SecuredScore { get; private set; }

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
            UpdateSecuredScore();
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

            CurrentAverageScore = Math.Round(cumultiveAverage, 2);
        }

        private void UpdateSecuredScore()
        {
            var securedTotal = 0.00;
            foreach (Module module in ListOfModules)
            {
                securedTotal += module.OverallPercentage / (double)module.Credits;
            }

            SecuredScore = securedTotal;
        }
    }
}
