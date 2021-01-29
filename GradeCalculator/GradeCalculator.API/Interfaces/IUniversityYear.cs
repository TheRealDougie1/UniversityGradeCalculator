namespace GradeCalculator.Api.Interfaces
{
    using System.Collections.Generic;
    using GradeCalculator.Api.Utils;

    /// <summary>
    /// Interface for University Years.
    /// </summary>
    public interface IUniversityYear
    {
        /// <summary>
        /// Gets total credits assigned to each year (Value should always be 120)
        /// </summary>
        int TotalCredits { get; }

        /// <summary>
        /// Gets a list of <see cref="IModule"/>s taken that year.
        /// </summary>
        List<IModule> ListOfModules { get; }

        /// <summary>
        /// Gets the total score of the year; the score is calculated out of 120, not whatever the amount of modules is.
        /// </summary>
        double SecuredScore { get; }

        /// <summary>
        /// Gets the current average score of the year. This is the sum of all modules which have been taken thus far, which may not add up to 120 credits.
        /// </summary>
        double CurrentAverageScore { get; }

        /// <summary>
        /// Gets the year type of the <see cref="IUniversityYear"/>
        /// </summary>
        UniversityYearClassification YearType { get; }

        /// <summary>
        /// Adds a Module to this <see cref="IUniversityYear"/>.
        /// </summary>
        /// <param name="module"> Module to add to the list</param>
        void AddModule(IModule module);

        /// <summary>
        /// Sets a new Year Classification
        /// </summary>
        /// <param name="newYearType"> New year identifier.</param>
        void SetYearType(UniversityYearClassification newYearType);
    }
}
