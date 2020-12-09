namespace GradeCalculator.Api
{
    /// <summary>
    /// Interface for University Years.
    /// </summary>
    public interface IUniversityYear
    {
        /// <summary>
        /// Gets Total credits assigned to each year (Value should always be 120)
        /// </summary>
        int TotalCredits
        {
            get;
        }
    }
}
