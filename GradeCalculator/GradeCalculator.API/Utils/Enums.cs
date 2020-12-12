namespace GradeCalculator.Api.Utils
{
    /// <summary>
    /// Enum for the type of University Year
    /// </summary>
    public enum UniversityYearClassification
    {
        /// <summary>
        /// Third year identifier, with a value of 70.
        /// </summary>
        ThirdYear = 70,

        /// <summary>
        /// Second Year identifier, with a value of 30 as there is no placement year to account for.
        /// </summary>
        SecondYearNoPlacement = 30,

        /// <summary>
        /// Second Year identifier, with a value of 20 as there is a placement year to account for.
        /// </summary>
        SecondYearWithPlacement = 20,

        /// <summary>
        /// Placement year identifier, with a value of 10.
        /// </summary>
        PlacementYear = 10
    }
}
