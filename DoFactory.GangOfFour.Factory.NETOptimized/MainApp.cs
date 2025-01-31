namespace DoFactory.GangOfFour.Factory.NETOptimized
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for .NET optimized
    ///     Factory Method Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Document constructors call Factory Method
            var documents = new List<Document>
            {
                new Resume(),
                new Report()
            };

            // Display document pages
            foreach (var document in documents)
            {
                Console.WriteLine(document + "--");
                foreach (var page in document.Pages)
                {
                    Console.WriteLine(" " + page);
                }
                Console.WriteLine();
            }

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Product' abstract class
    /// </summary>
    abstract class Page
    {
        // Override. Display class name
        public override string ToString()
        {
            return GetType().Name;
        }
    }

    /// <summary>
    ///     A 'ConcreteProduct' class
    /// </summary>
    class SkillsPage : Page { }

    /// <summary>
    ///     A 'ConcreteProduct' class
    /// </summary>
    class EducationPage : Page { }

    /// <summary>
    ///     A 'ConcreteProduct' class
    /// </summary>
    class ExperiencePage : Page { }

    /// <summary>
    ///     A 'ConcreteProduct' class
    /// </summary>
    class IntroductionPage : Page { }

    /// <summary>
    ///     A 'ConcreteProduct' class
    /// </summary>
    class ResultsPage : Page { }

    /// <summary>
    ///     A 'ConcreteProduct' class
    /// </summary>
    class ConclusionPage : Page { }

    /// <summary>
    ///     A 'ConcreteProduct' class
    /// </summary>
    class SummaryPage : Page { }

    /// <summary>
    ///     A 'ConcreteProduct' class
    /// </summary>
    class BibliographyPage : Page { }

    /// <summary>
    ///     The 'Creator' abstract class
    /// </summary>
    abstract class Document
    {
        // Gets list of document pages
        public List<Page> Pages { get; protected set; }

        #region CONSTRUCTORS

        // Constructor invokes Factory Method
        protected Document()
        {
            CreatePages();
        }

        #endregion

        // Factory Method
        public abstract void CreatePages();

        // Override
        public override string ToString()
        {
            return GetType().Name;
        }
    }

    /// <summary>
    ///     A 'ConcreteCreator' class
    /// </summary>
    class Resume : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages = new List<Page>
            {
                new SkillsPage(),
                new EducationPage(),
                new ExperiencePage()
            };
        }
    }

    /// <summary>
    ///     A 'ConcreteCreator' class
    /// </summary>
    class Report : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages = new List<Page>
            {
                new IntroductionPage(),
                new ResultsPage(),
                new ConclusionPage(),
                new SummaryPage(),
                new BibliographyPage()
            };
        }
    }
}