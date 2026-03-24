namespace AVLTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);
            tree.remove(1);
            ;
        }

    }
}
