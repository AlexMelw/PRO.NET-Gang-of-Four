namespace DoFactory.GangOfFour.Builder.NETOptimized
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for .NET optimized
    ///     Builder Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create shop
            var shop = new Shop();

            // Construct and display vehicles
            shop.Construct(new ScooterBuilder());
            shop.ShowVehicle();

            shop.Construct(new CarBuilder());
            shop.ShowVehicle();

            shop.Construct(new MotorCycleBuilder());
            shop.ShowVehicle();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Director' class
    /// </summary>
    internal class Shop
    {
        private VehicleBuilder vehicleBuilder;

        // Builder uses a complex series of steps
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            this.vehicleBuilder = vehicleBuilder;

            this.vehicleBuilder.BuildFrame();
            this.vehicleBuilder.BuildEngine();
            this.vehicleBuilder.BuildWheels();
            this.vehicleBuilder.BuildDoors();
        }

        public void ShowVehicle()
        {
            vehicleBuilder.Vehicle.Show();
        }
    }

    /// <summary>
    ///     The 'Builder' abstract class
    /// </summary>
    internal abstract class VehicleBuilder
    {
        public Vehicle Vehicle { get; }

        #region CONSTRUCTORS

        // Constructor
        protected VehicleBuilder(VehicleType vehicleType)
        {
            Vehicle = new Vehicle(vehicleType);
        }

        #endregion

        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    /// <summary>
    ///     The 'ConcreteBuilder1' class
    /// </summary>
    internal class MotorCycleBuilder : VehicleBuilder
    {
        #region CONSTRUCTORS

        // Invoke base class constructor
        public MotorCycleBuilder()
            : base(VehicleType.MotorCycle) { }

        #endregion

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "500 cc";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "2";
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "0";
        }
    }

    /// <summary>
    ///     The 'ConcreteBuilder2' class
    /// </summary>
    internal class CarBuilder : VehicleBuilder
    {
        #region CONSTRUCTORS

        // Invoke base class constructor
        public CarBuilder()
            : base(VehicleType.Car) { }

        #endregion

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "Car Frame";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "2500 cc";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "4";
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "4";
        }
    }

    /// <summary>
    ///     The 'ConcreteBuilder3' class
    /// </summary>
    internal class ScooterBuilder : VehicleBuilder
    {
        #region CONSTRUCTORS

        // Invoke base class constructor
        public ScooterBuilder() : base(VehicleType.Scooter) { }

        #endregion

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "50 cc";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "2";
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "0";
        }
    }

    /// <summary>
    ///     The 'Product' class
    /// </summary>
    internal class Vehicle
    {
        private readonly Dictionary<PartType, string> parts = new Dictionary<PartType, string>();
        private readonly VehicleType vehicleType;

        public string this[PartType key]
        {
            get => parts[key];
            set => parts[key] = value;
        }

        #region CONSTRUCTORS

        // Constructor
        public Vehicle(VehicleType vehicleType)
        {
            this.vehicleType = vehicleType;
        }

        #endregion

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", vehicleType);
            Console.WriteLine($" Frame  : {this[PartType.Frame]}");
            Console.WriteLine($" Engine : {this[PartType.Engine]}");
            Console.WriteLine($" #Wheels: {this[PartType.Wheel]}");
            Console.WriteLine($" #Doors : {this[PartType.Door]}");
        }
    }

    /// <summary>
    ///     Part type enumeration
    /// </summary>
    public enum PartType
    {
        Frame,
        Engine,
        Wheel,
        Door
    }

    /// <summary>
    ///     Vehicle type enumeration
    /// </summary>
    public enum VehicleType
    {
        Car,
        Scooter,
        MotorCycle
    }
}