namespace GradeCalculator.Api.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GradeCalculator.Api.Interfaces;

    /// <summary>
    /// University Year class, used for holding information related to a particular University Year.
    /// </summary>
    public class UniversityYear : IUniversityYear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityYear"/> class.
        /// </summary>
        public UniversityYear()
        {
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
        public void AddModule(IModule module)
        {
            if (TotalCredits + module.Credits > 120)
            {
                throw new ArgumentException();
            }

            TotalCredits += module.Credits;
            ListOfModules.Add(module);

            var listOfModuleScores = new List<double>();
            foreach (IModule addedModule in ListOfModules) 
            {
                listOfModuleScores.Add(addedModule.OverallPercentage);
            }

            AverageScore = listOfModuleScores.Average();
        }
    }
}
