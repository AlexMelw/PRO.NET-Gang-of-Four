namespace DoFactory.GangOfFour.Chain.NETOptimized
{
    using System;

    /// <summary>
    ///     MainApp startup class for .NET optimized
    ///     Chain of Responsibility Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Setup Chain of Responsibility
            Approver larry = new Director();
            Approver sam = new VicePresident();
            Approver tammy = new President();

            larry.Successor = sam;
            sam.Successor = tammy;

            // Generate and process purchase requests
            var purchase = new Purchase { Number = 2034, Amount = 350.00, Purpose = "Supplies" };
            larry.ProcessRequest(purchase);

            purchase = new Purchase { Number = 2035, Amount = 32590.10, Purpose = "Project X" };
            larry.ProcessRequest(purchase);

            purchase = new Purchase { Number = 2036, Amount = 122100.00, Purpose = "Project Y" };
            larry.ProcessRequest(purchase);

            // Wait for user
            Console.ReadKey();
        }
    }

    // Purchase event argument holds purchase info
    public class PurchaseEventArgs : EventArgs
    {
        internal Purchase Purchase { get; set; }
    }

    /// <summary>
    ///     The 'Handler' abstract class
    /// </summary>
    abstract class Approver
    {
        // Purchase event 
        public EventHandler<PurchaseEventArgs> Purchase;

        // Sets or gets the next approver
        public Approver Successor { get; set; }

        #region CONSTRUCTORS

        // Constructor
        public Approver()
        {
            Purchase += PurchaseHandler;
        }

        #endregion

        // Purchase event handler
        public abstract void PurchaseHandler(object sender, PurchaseEventArgs e);

        public void ProcessRequest(Purchase purchase)
        {
            OnPurchase(new PurchaseEventArgs { Purchase = purchase });
        }

        // Invoke the Purchase event
        public virtual void OnPurchase(PurchaseEventArgs e)
        {
            if (Purchase != null)
            {
                Purchase(this, e);
            }
        }
    }

    /// <summary>
    ///     The 'ConcreteHandler' class
    /// </summary>
    class Director : Approver
    {
        public override void PurchaseHandler(object sender, PurchaseEventArgs e)
        {
            if (e.Purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    GetType().Name, e.Purchase.Number);
            }
            else if (Successor != null)
            {
                Successor.PurchaseHandler(this, e);
            }
        }
    }

    /// <summary>
    ///     The 'ConcreteHandler' class
    /// </summary>
    class VicePresident : Approver
    {
        public override void PurchaseHandler(object sender, PurchaseEventArgs e)
        {
            if (e.Purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    GetType().Name, e.Purchase.Number);
            }
            else if (Successor != null)
            {
                Successor.PurchaseHandler(this, e);
            }
        }
    }

    /// <summary>
    ///     The 'ConcreteHandler' clas
    /// </summary>
    class President : Approver
    {
        public override void PurchaseHandler(object sender, PurchaseEventArgs e)
        {
            if (e.Purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    sender.GetType().Name, e.Purchase.Number);
            }
            else if (Successor != null)
            {
                Successor.PurchaseHandler(this, e);
            }
            else
            {
                Console.WriteLine(
                    "Request# {0} requires an executive meeting!",
                    e.Purchase.Number);
            }
        }
    }

    /// <summary>
    ///     Class that holds request details
    /// </summary>
    class Purchase
    {
        public double Amount { get; set; }
        public string Purpose { get; set; }
        public int Number { get; set; }
    }
}