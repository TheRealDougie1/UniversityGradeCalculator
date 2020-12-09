namespace GradeCalculator.Api
{
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
            TotalCredits = 120;
        }

        /// <inheritdoc/>
        public int TotalCredits { get; private set; }
    }
}
