namespace DoFactory.GangOfFour.Composite.NETOptimized
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for .NET optimized
    ///     Composite Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Build a tree of shapes
            var root = new TreeNode<Shape> { Node = new Shape("Picture") };

            root.Add(new Shape("Red Line"));
            root.Add(new Shape("Blue Circle"));
            root.Add(new Shape("Green Box"));

            var branch = root.Add(new Shape("Two Circles"));
            branch.Add(new Shape("Black Circle"));
            branch.Add(new Shape("White Circle"));

            // Add, remove, and add a shape
            var shape = new Shape("Yellow Line");
            root.Add(shape);
            root.Remove(shape);
            root.Add(shape);

            // Display tree using static method
            TreeNode<Shape>.Display(root, 1);

            Console.ReadKey();
        }
    }

    /// <summary>
    ///     Generic tree node class
    /// </summary>
    /// <typeparam name="T">Node type</typeparam>
    class TreeNode<T> where T : IComparable<T>
    {
        List<TreeNode<T>> children = new List<TreeNode<T>>();

        // Gets or sets the node
        public T Node { get; set; }

        // Gets treenode children
        public List<TreeNode<T>> Children
        {
            get { return children; }
        }

        // Add a child tree node
        public TreeNode<T> Add(T child)
        {
            var newNode = new TreeNode<T> { Node = child };
            children.Add(newNode);
            return newNode;
        }

        // Remove a child tree node
        public void Remove(T child)
        {
            foreach (var treeNode in children)
            {
                if (treeNode.Node.CompareTo(child) == 0)
                {
                    children.Remove(treeNode);
                    return;
                }
            }
        }

        // Recursively displays node and its children 
        public static void Display(TreeNode<T> node, int indentation)
        {
            string line = new string('-', indentation);
            Console.WriteLine(line + " " + node.Node);

            node.Children.ForEach(n => Display(n, indentation + 1));
        }
    }

    /// <summary>
    ///     Shape class
    ///     <remarks>
    ///         Implements generic IComparable interface
    ///     </remarks>
    /// </summary>
    class Shape : IComparable<Shape>
    {
        string name;

        #region CONSTRUCTORS

        // Constructor
        public Shape(string name)
        {
            this.name = name;
        }

        #endregion

        // IComparable<Shape> Member
        public int CompareTo(Shape other)
        {
            return this == other ? 0 : -1;
        }

        public override string ToString()
        {
            return name;
        }
    }
}