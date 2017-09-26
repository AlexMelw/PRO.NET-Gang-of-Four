namespace DoFactory.GangOfFour.Builder.RealWorld
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for Real-World
    ///     Builder Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create shop with vehicle builders
            Shop shop = new Shop();

            // Construct and display vehicles
            VehicleBuilder builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Director' class
    /// </summary>
    class Shop
    {
        // Builder uses a complex series of steps
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    /// <summary>
    ///     The 'Builder' abstract class
    /// </summary>
    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        // Gets vehicle instance
        public Vehicle Vehicle => vehicle;

        // Abstract build methods
        public abstract void BuildFrame();

        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    /// <summary>
    ///     The 'ConcreteBuilder1' class
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder
    {
        #region CONSTRUCTORS

        public MotorCycleBuilder()
        {
            vehicle = new Vehicle("MotorCycle");
        }

        #endregion

        public override void BuildFrame()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "500 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }


    /// <summary>
    ///     The 'ConcreteBuilder2' class
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        #region CONSTRUCTORS

        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }

        #endregion

        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "2500 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }
    }

    /// <summary>
    ///     The 'ConcreteBuilder3' class
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        #region CONSTRUCTORS

        public ScooterBuilder()
        {
            vehicle = new Vehicle("Scooter");
        }

        #endregion

        public override void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "50 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }

    /// <summary>
    ///     The 'Product' class
    /// </summary>
    class Vehicle
    {
        string vehicleType;
        Dictionary<string, string> parts = new Dictionary<string, string>();

        // Indexer
        public string this[string key]
        {
            get => parts[key];
            set => parts[key] = value;
        }

        #region CONSTRUCTORS

        // Constructor
        public Vehicle(string vehicleType)
        {
            this.vehicleType = vehicleType;
        }

        #endregion

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine($"Vehicle Type: {vehicleType}");
            Console.WriteLine($" Frame  : {parts["frame"]}");
            Console.WriteLine($" Engine : {parts["engine"]}");
            Console.WriteLine($" #Wheels: {parts["wheels"]}");
            Console.WriteLine($" #Doors : {parts["doors"]}");
        }
    }
}