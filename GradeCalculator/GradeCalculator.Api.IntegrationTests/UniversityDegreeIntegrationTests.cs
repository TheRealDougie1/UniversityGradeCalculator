namespace GradeCalculator.Api.IntegrationTests
{
    using FluentAssertions;
    using GradeCalculator.Api.Components;
    using GradeCalculator.Api.Interfaces;
    using GradeCalculator.Api.Utils;
    using NUnit.Framework;

    public class UniversityDegreeIntegrationTests
    {
        private IUniversityDegree sut;
        [SetUp]
        public void Setup()
        {
            sut = new UniversityDegree();
        }

        [Test]
        public void CalculateDegreePercentageNoPlacement_ReturnsCorrectResults()
        {
            // Set up second year
            UniversityYear secondYear = new UniversityYear(UniversityYearClassification.SecondYearNoPlacement);
            secondYear.AddModule(new Module("OOADS", 20, 76));
            secondYear.AddModule(new Module("Comm Networks", 20, 62));
            secondYear.AddModule(new Module("Group Project", 20, 72));
            secondYear.AddModule(new Module("Enterprise Architecture", 10, 86));
            secondYear.AddModule(new Module("Systems Modelling", 10, 71));
            secondYear.AddModule(new Module("Employability", 10, 71));
            secondYear.AddModule(new Module("Data Vis", 10, 60));
            secondYear.AddModule(new Module("DB systems", 10, 71));
            secondYear.AddModule(new Module("HCI", 10, 73));

            // Set up final year
            UniversityYear finalYear = new UniversityYear(UniversityYearClassification.FinalYear);
            finalYear.AddModule(new Module("Security", 10, 81.8));
            finalYear.AddModule(new Module("Forensics", 10, 95.3));
            finalYear.AddModule(new Module("Knowledge Management", 20, 72));
            finalYear.AddModule(new Module("LSD", 20, 69));
            finalYear.AddModule(new Module("Emerging Tech", 20, 75));
            finalYear.AddModule(new Module("Individual Project", 40, 68));

            sut.AddYear(secondYear);
            sut.AddYear(finalYear);

            sut.CalculateDegreePercentage().Should().Be(72.69);
            sut.DegreeClassification.Should().Be(UniversityDegreeClassification.FirstClassHonour);
        }

        [Test]
        public void CalculateDegreePercentageWithPlacement_ReturnsCorrectResults()
        {
            // Set up second year
            UniversityYear secondYear = new UniversityYear(UniversityYearClassification.SecondYearNoPlacement);
            secondYear.AddModule(new Module("OOADS", 20, 76));
            secondYear.AddModule(new Module("Comm Networks", 20, 62));
            secondYear.AddModule(new Module("Group Project", 20, 72));
            secondYear.AddModule(new Module("Enterprise Architecture", 10, 86));
            secondYear.AddModule(new Module("Systems Modelling", 10, 71));
            secondYear.AddModule(new Module("Employability", 10, 71));
            secondYear.AddModule(new Module("Data Vis", 10, 60));
            secondYear.AddModule(new Module("DB systems", 10, 71));
            secondYear.AddModule(new Module("HCI", 10, 73));

            // Set up placement year
            UniversityYear placementYear = new UniversityYear(UniversityYearClassification.PlacementYear);
            placementYear.AddModule(new Module("Placement module", 120, 86));

            // Set up final year
            UniversityYear finalYear = new UniversityYear(UniversityYearClassification.FinalYear);
            finalYear.AddModule(new Module("Security", 10, 81.8));
            finalYear.AddModule(new Module("Forensics", 10, 95.3));
            finalYear.AddModule(new Module("Knowledge Management", 20, 72));
            finalYear.AddModule(new Module("LSD", 20, 69));
            finalYear.AddModule(new Module("Emerging Tech", 20, 75));
            finalYear.AddModule(new Module("Individual Project", 40, 68));

            sut.AddYear(secondYear);
            sut.AddYear(placementYear);
            sut.AddYear(finalYear);

            sut.CalculateDegreePercentage().Should().Be(74.19);
            sut.DegreeClassification.Should().Be(UniversityDegreeClassification.FirstClassHonour);
        }

        [Test]
        public void CalculateDegreePercentageWithPlacementButNoYear_ReturnsCorrectResults()
        {
            // Set up second year
            UniversityYear secondYear = new UniversityYear(UniversityYearClassification.SecondYearWithPlacement);
            secondYear.AddModule(new Module("OOADS", 20, 76));
            secondYear.AddModule(new Module("Comm Networks", 20, 62));
            secondYear.AddModule(new Module("Group Project", 20, 72));
            secondYear.AddModule(new Module("Enterprise Architecture", 10, 86));
            secondYear.AddModule(new Module("Systems Modelling", 10, 71));
            secondYear.AddModule(new Module("Employability", 10, 71));
            secondYear.AddModule(new Module("Data Vis", 10, 60));
            secondYear.AddModule(new Module("DB systems", 10, 71));
            secondYear.AddModule(new Module("HCI", 10, 73));

            // Set up final year
            UniversityYear finalYear = new UniversityYear(UniversityYearClassification.FinalYear);
            finalYear.AddModule(new Module("Security", 10, 81.8));
            finalYear.AddModule(new Module("Forensics", 10, 95.3));
            finalYear.AddModule(new Module("Knowledge Management", 20, 72));
            finalYear.AddModule(new Module("LSD", 20, 69));
            finalYear.AddModule(new Module("Emerging Tech", 20, 75));
            finalYear.AddModule(new Module("Individual Project", 40, 68));

            sut.AddYear(secondYear);
            sut.AddYear(finalYear);

            sut.CalculateDegreePercentage().Should().Be(72.69);
            sut.DegreeClassification.Should().Be(UniversityDegreeClassification.FirstClassHonour);
        }

        [Test]
        public void CalculateDegreePercentageWithAssignments_ReturnsCorrectResults()
        {
            // Set up second year
            UniversityYear secondYear = new UniversityYear(UniversityYearClassification.SecondYearWithPlacement);

            Module ooads = new Module("OOADS", 20);
            ooads.AddAssignment(new Assignment("Exam 1", 100, 76));

            Module commNetworks = new Module("Comm Networks", 20);
            commNetworks.AddAssignment(new Assignment("Exam 1", 100, 62));

            Module groupProject = new Module("Group Project", 20);
            groupProject.AddAssignment(new Assignment("Group Project Report", 100, 72));

            Module enterpriseArchitecture = new Module("Enterprise Architecture", 10);
            enterpriseArchitecture.AddAssignment(new Assignment("Exam 1", 100, 86));

            Module systemsModelling = new Module("Systems Modelling", 10);
            systemsModelling.AddAssignment(new Assignment("Coursework 1", 100, 71));

            Module employability = new Module("Enhancing Your Employability", 10);
            employability.AddAssignment(new Assignment("Exam 1", 100, 71));

            Module dataVisualisation = new Module("Data Visualation", 10);
            dataVisualisation.AddAssignment(new Assignment("Exam 1", 100, 60));

            Module databaseSystems = new Module("Database Systems", 10);
            databaseSystems.AddAssignment(new Assignment("Exam 1", 100, 71));

            Module humanComputerInteraction = new Module("Human Computer Interaction", 10);
            humanComputerInteraction.AddAssignment(new Assignment("Exam 1", 100, 73));

            secondYear.AddModule(ooads);
            secondYear.AddModule(commNetworks);
            secondYear.AddModule(groupProject);
            secondYear.AddModule(enterpriseArchitecture);
            secondYear.AddModule(systemsModelling);
            secondYear.AddModule(employability);
            secondYear.AddModule(dataVisualisation);
            secondYear.AddModule(databaseSystems);
            secondYear.AddModule(humanComputerInteraction);

            // Set up final year
            UniversityYear finalYear = new UniversityYear(UniversityYearClassification.FinalYear);
            finalYear.AddModule(new Module("Security", 10, 81.8));
            finalYear.AddModule(new Module("Forensics", 10, 95.3));
            finalYear.AddModule(new Module("Knowledge Management", 20, 72));
            finalYear.AddModule(new Module("LSD", 20, 69));
            finalYear.AddModule(new Module("Emerging Tech", 20, 75));
            finalYear.AddModule(new Module("Individual Project", 40, 68));

            sut.AddYear(secondYear);
            sut.AddYear(finalYear);

            sut.CalculateDegreePercentage().Should().Be(72.69);
            sut.DegreeClassification.Should().Be(UniversityDegreeClassification.FirstClassHonour);
        }
    }
}