namespace DoFactory.GangOfFour.Flyweight.NETOptimized
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for .NET optimized
    ///     Flyweight Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Build a document with text
            string document = "AAZZBBZB";
            char[] chars = document.ToCharArray();

            var factory = new CharacterFactory();

            // extrinsic state
            int pointSize = 10;

            // For each character use a flyweight object
            foreach (char c in chars)
            {
                var character = factory[c];
                character.Display(++pointSize);
            }

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'FlyweightFactory' class
    /// </summary>
    class CharacterFactory
    {
        Dictionary<char, Character> characters = new Dictionary<char, Character>();

        // Character indexer
        public Character this[char key]
        {
            get {
                // Uses "lazy initialization" -- i.e. only create when needed.
                Character character = null;
                if (characters.ContainsKey(key))
                {
                    character = characters[key];
                }
                else
                {
                    // Instead of a case statement with 26 cases (characters).
                    // First, get qualified class name, then dynamically create instance 
                    string name = GetType().Namespace + "." + "Character" + key.ToString();
                    character = (Character) Activator.CreateInstance(Type.GetType(name));
                }

                return character;
            }
        }
    }

    /// <summary>
    ///     The 'Flyweight' class
    /// </summary>
    class Character
    {
        protected char symbol;
        protected int width;
        protected int height;
        protected int ascent;
        protected int descent;

        public void Display(int pointSize)
        {
            Console.WriteLine(symbol +
                              " (pointsize " + pointSize + ")");
        }
    }

    /// <summary>
    ///     A 'ConcreteFlyweight' class
    /// </summary>
    class CharacterA : Character
    {
        #region CONSTRUCTORS

        // Constructor
        public CharacterA()
        {
            symbol = 'A';
            height = 100;
            width = 120;
            ascent = 70;
            descent = 0;
        }

        #endregion
    }

    /// <summary>
    ///     A 'ConcreteFlyweight' class
    /// </summary>
    class CharacterB : Character
    {
        #region CONSTRUCTORS

        // Constructor
        public CharacterB()
        {
            symbol = 'B';
            height = 100;
            width = 140;
            ascent = 72;
            descent = 0;
        }

        #endregion
    }

    // ... C, D, E, etc.

    /// <summary>
    ///     A 'ConcreteFlyweight' class
    /// </summary>
    class CharacterZ : Character
    {
        #region CONSTRUCTORS

        // Constructor
        public CharacterZ()
        {
            symbol = 'Z';
            height = 100;
            width = 100;
            ascent = 68;
            descent = 0;
        }

        #endregion
    }
}