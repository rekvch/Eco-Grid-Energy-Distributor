/*
 * Prelim Activity 02: Advanced Object-Oriented Programming and Robustness
 * Scenario C: Eco-Grid Energy Distributor
 * By: Justine Marcella
 *
 * Description:
 * Demonstrates encapsulation, inheritance, polymorphism,
 * abstraction, and exception handling in a power distribution system.
 */

using System;

namespace Marcella_ScenarioC
{
    // ABSTRACT BASE CLASS (ABSTRACTION)
    abstract class PowerSource
    {
        // private fields for encapsulation
        private string sourceID;
        private double baseOutput;

        // public property with validation
        public string SourceID
        {
            get { return sourceID; }
            set { sourceID = value; }
        }

        // property with validation logic
        public double BaseOutput
        {
            get { return baseOutput; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Base output cannot be negative.");
                baseOutput = value;
            }
        }

        // constructor
        public PowerSource(string id, double output)
        {
            SourceID = id;
            BaseOutput = output;
        }

        // virtual method for polymorphism
        public virtual void GenerateReport()
        {
            Console.WriteLine($"Power Source [{SourceID}] Base Output: {BaseOutput} kW");
        }

        // OVERLOADED METHOD (compile-time polymorphism)
        public virtual void GenerateReport(bool detailed)
        {
            if (!detailed)
            {
                GenerateReport();
            }
            else
            {
                Console.WriteLine($"[DETAILED] Source: {SourceID} | Output: {BaseOutput} kW");
            }
        }
    }

    // SOLAR PANEL CLASS
    class SolarPanel : PowerSource
    {
        private double sunlightPercentage;

        public double SunlightPercentage
        {
            get { return sunlightPercentage; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Sunlight percentage cannot be negative.");
                sunlightPercentage = value;
            }
        }

        public SolarPanel(string id, double output, double sunlight)
            : base(id, output)
        {
            SunlightPercentage = sunlight;
        }

        // override method (runtime polymorphism)
        public override void GenerateReport()
        {
            if (SunlightPercentage < 0)
                throw new ArgumentException("Invalid sunlight value.");

            double finalOutput = BaseOutput * (SunlightPercentage / 100);

            Console.WriteLine("=== Solar Panel Report ===");
            Console.WriteLine($"ID: {SourceID}");
            Console.WriteLine($"Sunlight: {SunlightPercentage}%");
            Console.WriteLine($"Generated Power: {finalOutput:F2} kW");
        }

        public override void GenerateReport(bool detailed)
        {
            if (!detailed)
            {
                GenerateReport();
                return;
            }

            double finalOutput = BaseOutput * (SunlightPercentage / 100);

            Console.WriteLine("=== Solar Panel Detailed Report ===");
            Console.WriteLine($"Source ID: {SourceID}");
            Console.WriteLine($"Base Output: {BaseOutput} kW");
            Console.WriteLine($"Sunlight Modifier: {SunlightPercentage}%");
            Console.WriteLine($"Final Output: {finalOutput:F2} kW");
        }
    }

    // WIND TURBINE CLASS
    class WindTurbine : PowerSource
    {
        private double windSpeed;

        public double WindSpeed
        {
            get { return windSpeed; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Wind speed cannot be negative.");
                windSpeed = value;
            }
        }

        public WindTurbine(string id, double output, double wind)
            : base(id, output)
        {
            WindSpeed = wind;
        }

        // override method
        public override void GenerateReport()
        {
            double finalOutput = BaseOutput * (WindSpeed / 25);

            Console.WriteLine("=== Wind Turbine Report ===");
            Console.WriteLine($"ID: {SourceID}");
            Console.WriteLine($"Wind Speed: {WindSpeed} m/s");
            Console.WriteLine($"Generated Power: {finalOutput:F2} kW");
        }

        public override void GenerateReport(bool detailed)
        {
            if (!detailed)
            {
                GenerateReport();
                return;
            }

            double finalOutput = BaseOutput * (WindSpeed / 25);

            Console.WriteLine("=== Wind Turbine Detailed Report ===");
            Console.WriteLine($"Source ID: {SourceID}");
            Console.WriteLine($"Base Output: {BaseOutput} kW");
            Console.WriteLine($"Wind Speed Modifier: {WindSpeed} m/s");
            Console.WriteLine($"Final Output: {finalOutput:F2} kW");
        }
    }

    // MAIN PROGRAM (ROBUSTNESS)
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // POLYMORPHISM: base reference, different objects
                PowerSource solar = new SolarPanel("SOL-001", 500, 80);
                PowerSource wind = new WindTurbine("WND-001", 600, 20);

                Console.WriteLine("=== ECO-GRID ENERGY REPORT ===\n");

                solar.GenerateReport();
                Console.WriteLine();
                wind.GenerateReport();

                Console.WriteLine("\n=== DETAILED REPORTS ===\n");

                solar.GenerateReport(true);
                Console.WriteLine();
                wind.GenerateReport(true);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nSystem Shutdown");
            }
        }
    }
}
