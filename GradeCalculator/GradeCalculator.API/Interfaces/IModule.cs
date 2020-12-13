namespace GradeCalculator.Api.Interfaces
{
    /// <summary>
    /// Interface for Modules within an <see cref="IUniversityYear"/>
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Gets the name of the module
        /// </summary>
        string ModuleName { get; }

        /// <summary>
        /// Gets the credits value of the module
        /// </summary>
        int Credits { get; }

        /// <summary>
        /// Gets the overall percentage earned from the value.
        /// </summary>
        double OverallPercentage { get; }
    }
}
