namespace GradeCalculator.Api
{
    using System.Collections.Generic;

    /// <summary>
    /// University Degree class
    /// </summary>
    public class UniversityDegree : IUniversityDegree
    {
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
            ListOfYears.Add(yearToAdd);
        }
    }
}
