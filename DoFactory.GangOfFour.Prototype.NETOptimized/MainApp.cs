namespace DoFactory.GangOfFour.Prototype.NETOptimized
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    ///     MainApp startup class for .NET optimized
    ///     Prototype Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        static void Main()
        {
            var colormanager = new ColorManager();

            // Initialize with standard colors
            colormanager[ColorType.Red] = new Color { Red = 255, Blue = 0, Green = 0 };
            colormanager[ColorType.Green] = new Color { Red = 0, Blue = 255, Green = 0 };
            colormanager[ColorType.Blue] = new Color { Red = 0, Blue = 0, Green = 255 };

            // User adds personalized colors
            colormanager[ColorType.Angry] = new Color { Red = 255, Blue = 54, Green = 0 };
            colormanager[ColorType.Peace] = new Color { Red = 128, Blue = 211, Green = 128 };
            colormanager[ColorType.Flame] = new Color { Red = 211, Blue = 34, Green = 20 };

            // User uses selected colors
            var color1 = colormanager[ColorType.Red].Clone() as Color;
            var color2 = colormanager[ColorType.Peace].Clone() as Color;

            // Creates a "deep copy"
            var color3 = colormanager[ColorType.Flame].Clone(false) as Color;

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'ConcretePrototype' class
    /// </summary>
    [Serializable]
    class Color : ICloneable
    {
        // Gets or sets red value
        public byte Red { get; set; }

        // Gets or sets green value
        public byte Green { get; set; }

        // Gets or sets blue channel
        public byte Blue { get; set; }

        // Creates a shallow copy
        public object Clone()
        {
            Console.WriteLine($"Shallow copy of color RGB: {Red,3},{Green,3},{Blue,3}");

            return MemberwiseClone();
        }

        // Returns shallow or deep copy
        public object Clone(bool shallow)
        {
            return shallow ? Clone() : DeepCopy();
        }

        // Creates a deep copy
        public object DeepCopy()
        {
            object copy = null;

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);

                copy = formatter.Deserialize(stream);
            }

            Color color = (Color) copy;
            Console.WriteLine(
                $"*Deep* copy of color RGB: " +
                $"{color.Red,3}," +
                $"{color.Green,3}," +
                $"{color.Blue,3}");

            return copy;
        }
    }

    /// <summary>
    ///     Type-safe prototype manager
    /// </summary>
    class ColorManager
    {
        Dictionary<ColorType, Color> colors = new Dictionary<ColorType, Color>();

        // Gets or sets color
        public Color this[ColorType type]
        {
            get { return colors[type]; }
            set { colors.Add(type, value); }
        }
    }

    /// <summary>
    ///     Color type enumerations
    /// </summary>
    enum ColorType
    {
        Red,
        Green,
        Blue,

        Angry,
        Peace,
        Flame
    }
}