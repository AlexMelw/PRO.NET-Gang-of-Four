namespace DoFactory.GangOfFour.Visitor.NETOptimized
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for .NET optimized
    ///     Visitor Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Setup employee collection
            var employee = new Employees();
            employee.Attach(new Clerk());
            employee.Attach(new Director());
            employee.Attach(new President());

            // Employees are 'visited'
            employee.Accept(new IncomeVisitor());
            employee.Accept(new VacationVisitor());

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Visitor' abstract class
    /// </summary>
    public abstract class Visitor
    {
        // Use reflection to see if the Visitor has a method 
        // named Visit with the appropriate parameter type 
        // (i.e. a specific Employee). If so, invoke it.
        public void ReflectiveVisit(IElement element)
        {
            var types = new Type[] { element.GetType() };
            var mi = GetType().GetMethod("Visit", types);

            if (mi != null)
            {
                mi.Invoke(this, new object[] { element });
            }
        }
    }

    /// <summary>
    ///     A 'ConcreteVisitor' class
    /// </summary>
    class IncomeVisitor : Visitor
    {
        // Visit clerk
        public void Visit(Clerk clerk)
        {
            DoVisit(clerk);
        }

        // Visit director
        public void Visit(Director director)
        {
            DoVisit(director);
        }

        private void DoVisit(IElement element)
        {
            var employee = element as Employee;

            // Provide 10% pay raise
            employee.Income *= 1.10;
            Console.WriteLine("{0} {1}'s new income: {2:C}",
                employee.GetType().Name, employee.Name,
                employee.Income);
        }
    }

    /// <summary>
    ///     A 'ConcreteVisitor' class
    /// </summary>
    class VacationVisitor : Visitor
    {
        // Visit director
        public void Visit(Director director)
        {
            DoVisit(director);
        }

        private void DoVisit(IElement element)
        {
            var employee = element as Employee;

            // Provide 3 extra vacation days
            employee.VacationDays += 3;
            Console.WriteLine("{0} {1}'s new vacation days: {2}",
                employee.GetType().Name, employee.Name,
                employee.VacationDays);
        }
    }

    /// <summary>
    ///     The 'Element' interface
    /// </summary>
    public interface IElement
    {
        void Accept(Visitor visitor);
    }

    /// <summary>
    ///     The 'ConcreteElement' class
    /// </summary>
    class Employee : IElement
    {
        // Gets or sets name
        public string Name { get; set; }

        // Gets or set income
        public double Income { get; set; }

        // Gets or sets vacation days
        public int VacationDays { get; set; }

        #region CONSTRUCTORS

        // Constructor
        public Employee(string name, double income,
            int vacationDays)
        {
            Name = name;
            Income = income;
            VacationDays = vacationDays;
        }

        #endregion

        public virtual void Accept(Visitor visitor)
        {
            visitor.ReflectiveVisit(this);
        }
    }

    /// <summary>
    ///     The 'ObjectStructure' class
    /// </summary>
    class Employees : List<Employee>
    {
        public void Attach(Employee employee)
        {
            Add(employee);
        }

        public void Detach(Employee employee)
        {
            Remove(employee);
        }

        public void Accept(Visitor visitor)
        {
            // Iterate over all employees and accept visitor
            ForEach(employee => employee.Accept(visitor));

            Console.WriteLine();
        }
    }

    // Three employee types

    class Clerk : Employee
    {
        #region CONSTRUCTORS

        // Constructor
        public Clerk()
            : base("Hank", 25000.0, 14) { }

        #endregion
    }

    class Director : Employee
    {
        #region CONSTRUCTORS

        // Constructor
        public Director()
            : base("Elly", 35000.0, 16) { }

        #endregion
    }

    class President : Employee
    {
        #region CONSTRUCTORS

        // Constructor
        public President()
            : base("Dick", 45000.0, 21) { }

        #endregion
    }
}