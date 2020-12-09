namespace GradeCalculator.Api
{
    using System;
    using System.Collections.Generic;

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
        }

        /// <inheritdoc/>
        public int TotalCredits { get; private set; }

        /// <inheritdoc/>
        public List<IModule> ListOfModules { get; private set; }

        /// <inheritdoc/>
        public void AddModule(IModule module)
        {
            if (TotalCredits + module.Credits > 120)
            {
                throw new ArgumentException();
            }

            TotalCredits += module.Credits;
            ListOfModules.Add(module);
        }
    }
}
