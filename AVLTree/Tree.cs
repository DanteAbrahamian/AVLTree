namespace AVLTree
{
    public class Tree<T> where T : IComparable<T>
    {
        int count = 0;
        public Node<T> root;
        public void Insert(T thingToInsert)
        {
            root = Insert(thingToInsert, root);

        }
        private Node<T> Insert(T thingToInsert, Node<T> curr)
        {
            if (curr is null)
            {
                count++;

                return InsertHelper(thingToInsert);
            }

            if (thingToInsert.CompareTo(curr.Value) < 0)
            {
                curr.Left = Insert(thingToInsert, curr.Left);
                curr.updateHeight();

                return Balance(curr);
            }
            else if (thingToInsert.CompareTo(curr.Value) > 0)
            {
                curr.Right = Insert(thingToInsert, curr.Right);
                curr.updateHeight();

                return Balance(curr);
            }
            curr.updateHeight();

            return Balance(curr);
        }
        private Node<T> InsertHelper(T thingToInsert)
        {
            return new Node<T>(thingToInsert);
        }
        public void Remove(T thingToRemove)
        {
            root = Remove(thingToRemove, root);
            root.updateHeight();
            Balance(root);
            root.updateHeight();
            count--;
        }
        public Node<T> Remove(T valueToRemove, Node<T> curr)
        {
            Node<T> temp = curr;
            if (valueToRemove.Equals(curr.Value))
            {
                // if the node has 2 children
                if (curr.Right is not null && curr.Left is not null)
                {
                    temp = curr.Left;
                    while (temp.Right.Right is not null)
                    {
                        temp = temp.Right;
                    }
                    curr.Value = temp.Right.Value;
                    temp.Right = null;
                    return Balance(curr);
                }
                // if the node had one right child
                else if (curr.Right is not null)
                {

                    if (temp.Left is not null)
                    {
                        temp = curr.Right;
                        while (temp.Left.Left is not null)
                        {
                            temp = temp.Left;
                        }
                    }
                    curr.Value = temp.Right.Value;
                    temp.Right = null;
                    return Balance(curr);
                }
                // if the node has one left child
                else if (curr.Left is not null)
                {

                    if (temp.Right is not null)
                    {
                        temp = curr.Left;
                        while (temp.Right.Right is not null)
                        {
                            temp = temp.Right;
                        }
                    }
                    curr.Value = temp.Left.Value;
                    temp.Left = null;
                    return Balance(curr);
                }
                // if the node has no children
                else if (temp.Right is null && temp.Left is null) return null;
            }
            else if (valueToRemove.CompareTo(curr.Value) < 0)
            {
                curr.Left = Remove(valueToRemove, curr.Left);
            }
            else if (valueToRemove.CompareTo(curr.Value) > 0)
            {
                curr.Right = Remove(valueToRemove, curr.Right);
            }
            return Balance(curr);
        }
        // Deletion Helper Function
        // Handles Edge casess of finding the proper node to replace the one that is being removed 
        Node<T> Helper(Node<T> curr)
        {
            if (curr.Right == null && curr.Right == null) return null;
            else if (curr.Right == null && curr.Left != null) return curr.Left;
            else if (curr.Left == null && curr.Right != null) return curr.Right;
            else
            {
                curr = curr.Left;
                while (curr.Right != null)
                {
                    curr = curr.Right;
                }
                return curr;
            }

        }
        public Node<T> RotateLeft(Node<T> thingToRotate)
        {
            Node<T> tempRight = thingToRotate.Right;
            Node<T> tempLeft = tempRight.Left;
            Node<T> tempRightRight = tempRight.Right;
            tempRight.Left = thingToRotate;
            tempRight.Right = tempLeft;
            thingToRotate.Right = tempLeft;
            tempRight.Right = tempRightRight;
            tempRight.updateHeight();
            if (tempLeft != null)
            {
                tempLeft.updateHeight();
            }
            if (tempRightRight != null)
            {
                tempRightRight.updateHeight();
            }
            thingToRotate.updateHeight();
            return tempRight;
        }
        public Node<T> RotateRight(Node<T> thingToRotate)
        {
            Node<T> tempLeft = thingToRotate.Left;
            Node<T> tempRight = tempLeft.Right;
            Node<T> tempLeftLeft = tempLeft.Left;
            tempLeft.Right = thingToRotate;
            tempLeft.Left = tempRight;
            thingToRotate.Left = tempRight;
            tempLeft.Left = tempLeftLeft;
            //tempLeft.updateHeight();
            if (tempLeftLeft != null)
            {
                tempLeftLeft.updateHeight();
            }
            thingToRotate.updateHeight();
            return tempLeft;
        }
        public Node<T> Balance(Node<T> thingToRotate)
        {
            if (thingToRotate.Balance < -1)
            {
                if (thingToRotate.Left.Balance > 0)
                {
                    thingToRotate.Left = RotateLeft(thingToRotate.Left);
                }
                return RotateRight(thingToRotate);
            }
            else if (thingToRotate.Balance > 1)
            {
                if (thingToRotate.Right.Balance < 0)
                {
                    thingToRotate.Right = RotateRight(thingToRotate.Right);
                }
                return RotateLeft(thingToRotate);
            }
            return thingToRotate;
        }
    }
}