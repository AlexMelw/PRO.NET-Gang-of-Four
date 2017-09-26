namespace DoFactory.GangOfFour.Decorator.NETOptimized
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for .NET optimized
    ///     Decorator Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create book
            var book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            // Create video
            var video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("\nMaking video borrowable:");

            var borrow = new Borrowable<Video>(video);
            borrow.BorrowItem("Customer #1");
            borrow.BorrowItem("Customer #2");

            borrow.Display();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Component' abstract class
    /// </summary>
    abstract class LibraryItem<T>
    {
        // Each T has its own NumCopies
        public static int NumCopies { get; set; }

        public abstract void Display();
    }

    /// <summary>
    ///     The 'ConcreteComponent' class
    /// </summary>
    class Book : LibraryItem<Book>
    {
        string author;
        string title;

        #region CONSTRUCTORS

        // Constructor
        public Book(string author, string title, int numCopies)
        {
            this.author = author;
            this.title = title;
            NumCopies = numCopies;
        }

        #endregion

        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", author);
            Console.WriteLine(" Title: {0}", title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }

    /// <summary>
    ///     The 'ConcreteComponent' class
    /// </summary>
    class Video : LibraryItem<Video>
    {
        string director;
        string title;
        int playTime;

        #region CONSTRUCTORS

        // Constructor
        public Video(string director, string title,
            int numCopies, int playTime)
        {
            this.director = director;
            this.title = title;
            NumCopies = numCopies;
            this.playTime = playTime;
        }

        #endregion

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", director);
            Console.WriteLine(" Title: {0}", title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", playTime);
        }
    }

    /// <summary>
    ///     The 'Decorator' abstract class
    /// </summary>
    abstract class Decorator<T> : LibraryItem<T>
    {
        LibraryItem<T> libraryItem;

        #region CONSTRUCTORS

        // Constructor
        public Decorator(LibraryItem<T> libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        #endregion

        public override void Display()
        {
            libraryItem.Display();
        }
    }

    /// <summary>
    ///     The 'ConcreteDecorator' class
    /// </summary>
    class Borrowable<T> : Decorator<T>
    {
        List<string> borrowers = new List<string>();

        #region CONSTRUCTORS

        // Constructor
        public Borrowable(LibraryItem<T> libraryItem)
            : base(libraryItem) { }

        #endregion

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            NumCopies++;
        }

        public override void Display()
        {
            base.Display();
            borrowers.ForEach(b => Console.WriteLine(" borrower: " + b));
        }
    }
}