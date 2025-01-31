namespace DoFactory.GangOfFour.Observer.NETOptimized
{
    using System;

    /// <summary>
    ///     MainApp startup class for .NET optimized
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
            var ibm = new IBM(120.00);

            // Attach 'listeners', i.e. Investors
            ibm.Attach(new Investor { Name = "Sorros" });
            ibm.Attach(new Investor { Name = "Berkshire" });

            // Fluctuating prices will notify listening investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;

            // Wait for user
            Console.ReadKey();
        }
    }

    // Custom event arguments
    public class ChangeEventArgs : EventArgs
    {
        // Gets or sets symbol
        public string Symbol { get; set; }

        // Gets or sets price
        public double Price { get; set; }
    }

    /// <summary>
    ///     The 'Subject' abstract class
    /// </summary>
    abstract class Stock
    {
        protected string symbol;
        protected double price;

        // Gets or sets the price
        public double Price
        {
            get { return price; }
            set {
                if (price != value)
                {
                    price = value;
                    OnChange(new ChangeEventArgs { Symbol = symbol, Price = price });
                    Console.WriteLine("");
                }
            }
        }

        #region CONSTRUCTORS

        // Constructor
        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }

        #endregion

        // Event
        public event EventHandler<ChangeEventArgs> Change;

        // Invoke the Change event
        public virtual void OnChange(ChangeEventArgs e)
        {
            if (Change != null)
            {
                Change(this, e);
            }
        }

        public void Attach(IInvestor investor)
        {
            Change += investor.Update;
        }

        public void Detach(IInvestor investor)
        {
            Change -= investor.Update;
        }
    }

    /// <summary>
    ///     The 'ConcreteSubject' class
    /// </summary>
    class IBM : Stock
    {
        #region CONSTRUCTORS

        // Constructor - symbol for IBM is always same
        public IBM(double price)
            : base("IBM", price) { }

        #endregion
    }

    /// <summary>
    ///     The 'Observer' interface
    /// </summary>
    interface IInvestor
    {
        void Update(object sender, ChangeEventArgs e);
    }

    /// <summary>
    ///     The 'ConcreteObserver' class
    /// </summary>
    class Investor : IInvestor
    {
        // Gets or sets the investor name
        public string Name { get; set; }

        // Gets or sets the stock
        public Stock Stock { get; set; }

        public void Update(object sender, ChangeEventArgs e)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                              "change to {2:C}", Name, e.Symbol, e.Price);
        }
    }
}