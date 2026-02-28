namespace AVLTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<int> node = new Node<int>(5);
            Tree<int> tree = new Tree<int>();

            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(2);
            ;
        }

    }
}
