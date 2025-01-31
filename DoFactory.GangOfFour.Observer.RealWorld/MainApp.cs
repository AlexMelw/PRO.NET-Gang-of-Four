namespace DoFactory.GangOfFour.Observer.RealWorld
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for Real-World
    ///     Observer Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create IBM stock and attach investors
            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));

            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Subject' abstract class
    /// </summary>
    abstract class Stock
    {
        string symbol;
        double price;
        List<IInvestor> investors = new List<IInvestor>();

        // Gets or sets the price
        public double Price
        {
            get { return price; }
            set {
                if (price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }

        // Gets the symbol
        public string Symbol
        {
            get { return symbol; }
        }

        #region CONSTRUCTORS

        // Constructor
        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }

        #endregion

        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (IInvestor investor in investors)
            {
                investor.Update(this);
            }

            Console.WriteLine("");
        }
    }

    /// <summary>
    ///     The 'ConcreteSubject' class
    /// </summary>
    class IBM : Stock
    {
        #region CONSTRUCTORS

        // Constructor
        public IBM(string symbol, double price)
            : base(symbol, price) { }

        #endregion
    }

    /// <summary>
    ///     The 'Observer' interface
    /// </summary>
    interface IInvestor
    {
        void Update(Stock stock);
    }

    /// <summary>
    ///     The 'ConcreteObserver' class
    /// </summary>
    class Investor : IInvestor
    {
        string name;
        Stock stock;

        // Gets or sets the stock
        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        #region CONSTRUCTORS

        // Constructor
        public Investor(string name)
        {
            this.name = name;
        }

        #endregion

        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                              "change to {2:C}", name, stock.Symbol, stock.Price);
        }
    }
}