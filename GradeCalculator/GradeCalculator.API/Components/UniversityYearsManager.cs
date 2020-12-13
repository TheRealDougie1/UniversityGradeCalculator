namespace GradeCalculator.Api.Components
{
    using GradeCalculator.Api.Interfaces;
    using GradeCalculator.Api.Utils;

    /// <summary>
    /// Class for managing <see cref="UniversityYear"/> objects.
    /// </summary>
    public class UniversityYearsManager
    {
        /// <summary>
        /// Gets the Final Year
        /// </summary>
        public IUniversityYear FinalYear { get; private set; }

        /// <summary>
        /// Gets the Final Year
        /// </summary>
        public IUniversityYear PlacementYear { get; private set; }

        /// <summary>
        /// Gets the Final Year
        /// </summary>
        public IUniversityYear SecondYear { get; private set; }

        /// <summary>
        /// Adds a university year.
        /// </summary>
        /// <param name="yearToAdd"> University year to add </param>
        public void AddYear(IUniversityYear yearToAdd)
        {
            switch (yearToAdd.YearType)
            {
                case UniversityYearClassification.FinalYear:
                    FinalYear = yearToAdd;
                    return;
                case UniversityYearClassification.PlacementYear:
                    PlacementYear = yearToAdd;
                    if (SecondYear != null)
                    {
                        SecondYear.SetYearType(UniversityYearClassification.SecondYearWithPlacement);
                    }

                    return;
                case UniversityYearClassification.SecondYearNoPlacement:
                    SecondYear = yearToAdd;
                    return;
                case UniversityYearClassification.SecondYearWithPlacement:
                    SecondYear = yearToAdd;
                    return;
            }
        }
    }
}
