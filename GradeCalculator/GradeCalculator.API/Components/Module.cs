namespace GradeCalculator.Api.Components
{
    using System;
    using System.Text.RegularExpressions;
    using GradeCalculator.Api.Interfaces;

    /// <summary>
    /// Module class, used to represent a Module within a <see cref="UniversityYear"/>
    /// </summary>
    public class Module : IModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Module"/> class.
        /// </summary>
        /// <param name="moduleName"> Name of the module </param>
        /// <param name="credits"> Credit value of the module </param>
        /// <param name="overallPercentage"> Percentage earned on the module. </param>
        public Module(string moduleName, int credits, double? overallPercentage = null)
        {
            Regex nameRX = new Regex(@"[A-Za-z]");

            if (!nameRX.IsMatch(moduleName)) 
            {
                throw new ArgumentException("Module Name does not satisfy Regex.");
            }

            if (credits < 0 || credits > 120)
            {
                throw new ArgumentException("Invalid Credits.");
            }

            ModuleName = moduleName;
            Credits = credits;

            if (overallPercentage == null)
            {
                return;
            }

            if (overallPercentage >= 0 && overallPercentage <= 100)
            {
                OverallPercentage = (double)overallPercentage;
                return;
            }

            throw new ArgumentException();
        }

        /// <inheritdoc/>
        public string ModuleName { get; private set; }

        /// <inheritdoc/>
        public int Credits { get; private set; }

        /// <inheritdoc/>
        public double OverallPercentage { get; private set; }
    }
}
