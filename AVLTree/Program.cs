namespace AVLTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            // New test case to  fix insert and remove
            int[] nums = [5, 10, 15, 20, 17, 11, 3, 4];
            for (int i = 0; i < nums.Length; i++)
            {
                tree.Insert(nums[i]);
                
            }
            ;
            // should make root 11
            tree.remove(15);
            // works until this point
            tree.remove(10);
            }

    }
}
