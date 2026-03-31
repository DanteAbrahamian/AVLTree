namespace AVLTree
{
    public class Tree<T> where T : IComparable<T>
    {
        int count = 0;
        public Node<T> root;
        int a = 0;

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

        public void remove(T thingToRemove)
        {
            root = remove(thingToRemove, root);
            root.updateHeight();
            count--;
        }
        public Node<T> remove(T nodeToRemove, Node<T> curr)
        {
            if (nodeToRemove.CompareTo(curr.Value) < 0)
            {
                curr.Left = remove(nodeToRemove, curr.Left);
                curr.updateHeight();

                return Balance(curr);
            }
            else if (nodeToRemove.CompareTo(curr.Value) > 0)
            {
                curr.Right = remove(nodeToRemove, curr.Right);
                curr.updateHeight();

                return Balance(curr);
            }
            else
            {
                return Helper(curr);
            }
            //// Edge case: Entire Tree is Null
            ////If curr is null, (value doesn't exist in tree)
            ///////////////////////////////////
            //if (curr is null)
            //{
            //    return null;
            //}
            //// 1. Find the node that needs to be removed.
            //// 2. Replace with the left of that node and right all the way (if node is on the left side of the root)
            //// 3. Replace with the right of that node and all the way left (if the node is on the right side of the root))
            //if (curr.Right != null && curr.Left != null)
            //{
            //    // Left of node to remove
            //    Node<T> leftNode = null;
            //    // after left the far right of it;
            //    Node<T> farRight = null;
            //    // Not Recursive finding the node
            //    /*if (nodeToRemove.CompareTo(curr.Value) < 0)
            //    {
            //        leftNode = curr.Left;
            //        leftNode = leftNode.Right;
            //        farRight = leftNode;
            //        while (farRight.Right != null) farRight = farRight.Right;
            //        curr.Left = farRight;
            //    }
            //    for (int index = 0; index < curr.Height; index++)
            //    {
            //        if (curr.Right.Equals(nodeToRemove)) break;
            //        if (nodeToRemove.CompareTo(curr.Value) < 0) curr = curr.Left;
            //        else curr = curr.Right;
            //    }
            //    */
            //    if (nodeToRemove.CompareTo(curr.Value) > 0)
            //    {
            //        curr.Right = remove(nodeToRemove, curr.Right);
            //    }
            //    else
            //    {
            //        curr = curr.Left = remove(nodeToRemove, curr.Left);
            //    }
            //    leftNode = curr.Right;
            //    if (leftNode != null) leftNode = leftNode.Left;

            //    curr.Right = Helper(curr.Right);
            //    curr.Left = leftNode;
            //    //works after this point
            //    Balance(curr);
            //    // Previous replacement finding and replacing
            //    /*
            //    leftNode = curr.Right;
            //    leftNode = leftNode.Left;
            //    farRight = leftNode;
            //    while (farRight.Right != null) farRight = farRight.Right;
            //    curr.Right = farRight;
            //    farRight.Left = leftNode;
            //    Balance(curr);
            //    */
            //}

            //return Balance(curr);


            /*
            for (int index = 0; index < curr.Height; index++)
            {
                if (farRight.Right != null)
                {
                    farRight = farRight.Right;
                }
                if (farRight.Right != null)
                {
                    farRight = farRight.Right;
                }
            }
            curr.Value = farRight.Value;

            //farRight.Right = null;
        }
        if (curr.Value.Equals(thingToRemove))
        {
            if (curr.Right is null || curr.Left is null)
            {
                return null;
            }
            else
            {
                Node<T> temp = curr.Left;
                curr = curr.Right;
                curr.Left = temp;
                return Balance(curr);
            }
            //if doesn't have children return null
            //if has children, return the node it get's replaced with
        }
        else
        {
            if (thingToRemove.CompareTo(curr.Value) < 0)
            {
                curr.Left = remove(thingToRemove, curr.Left);

                return Balance(curr);
            }
            else if (thingToRemove.CompareTo(curr.Value) > 0)
            {
                curr.Right = remove(thingToRemove, curr.Right);

                return Balance(curr);
            }
        }


        return Balance(curr);

            */

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


        public Node<T> rotateLeft(Node<T> thingToRotate)
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
        public Node<T> rotateRight(Node<T> thingToRotate)
        {
            Node<T> tempLeft = thingToRotate.Left;
            Node<T> tempRight = tempLeft.Right;
            Node<T> tempLeftLeft = tempLeft.Left;
            tempLeft.Right = thingToRotate;
            tempLeft.Left = tempRight;
            thingToRotate.Left = tempRight;
            tempLeft.Left = tempLeftLeft;
            tempLeft.updateHeight();
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
                    thingToRotate.Left = rotateLeft(thingToRotate.Left);
                }
                return rotateRight(thingToRotate);
            }
            else if (thingToRotate.Balance > 1)
            {
                if (thingToRotate.Right.Balance < 0)
                {
                    thingToRotate.Right = rotateRight(thingToRotate.Right);
                }
                return rotateLeft(thingToRotate);
            }
            return thingToRotate;
        }

    }
}

