namespace DoFactory.GangOfFour.Command.Structural
{
    using System;

    /// <summary>
    ///     MainApp startup class for Structural
    ///     Command Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create receiver, command, and invoker
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            // Set and execute command
            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Command' abstract class
    /// </summary>
    abstract class Command
    {
        protected Receiver receiver;

        #region CONSTRUCTORS

        // Constructor
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        #endregion

        public abstract void Execute();
    }

    /// <summary>
    ///     The 'ConcreteCommand' class
    /// </summary>
    class ConcreteCommand : Command
    {
        #region CONSTRUCTORS

        // Constructor
        public ConcreteCommand(Receiver receiver) :
            base(receiver) { }

        #endregion

        public override void Execute()
        {
            receiver.Action();
        }
    }

    /// <summary>
    ///     The 'Receiver' class
    /// </summary>
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    /// <summary>
    ///     The 'Invoker' class
    /// </summary>
    class Invoker
    {
        Command command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}