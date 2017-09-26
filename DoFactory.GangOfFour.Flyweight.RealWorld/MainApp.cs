namespace DoFactory.GangOfFour.Flyweight.RealWorld
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for Real-World
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

            CharacterFactory factory = new CharacterFactory();

            // extrinsic state
            int pointSize = 10;

            // For each character use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                Character character = factory.GetCharacter(c);
                character.Display(pointSize);
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
        private Dictionary<char, Character> characters = new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            // Uses "lazy initialization"
            Character character = null;
            if (characters.ContainsKey(key))
            {
                character = characters[key];
            }
            else
            {
                switch (key)
                {
                    case 'A':
                        character = new CharacterA();
                        break;
                    case 'B':
                        character = new CharacterB();
                        break;
                    //...
                    case 'Z':
                        character = new CharacterZ();
                        break;
                }
                characters.Add(key, character);
            }
            return character;
        }
    }

    /// <summary>
    ///     The 'Flyweight' abstract class
    /// </summary>
    abstract class Character
    {
        protected char symbol;
        protected int width;
        protected int height;
        protected int ascent;
        protected int descent;
        protected int pointSize;

        public abstract void Display(int pointSize);
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

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine(symbol +
                              " (pointsize " + this.pointSize + ")");
        }
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

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine(symbol +
                              " (pointsize " + this.pointSize + ")");
        }
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

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine(symbol +
                              " (pointsize " + this.pointSize + ")");
        }
    }
}