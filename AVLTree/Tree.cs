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

        public void remove(T thingToRemove)
        {
            root = remove(thingToRemove, root);
            root.updateHeight();
            Balance(root);
            root.updateHeight();
            count--;
        }
        public Node<T> remove(T nodeToRemove, Node<T> curr)
        {
            Node<T> temp = new Node<T>(curr.Value);
            Node<T> oppositeTemp = new Node<T>(curr.Value);
            // edge case for removing root node
            // actually does all the switching between nodes by comming here with recursion
            if (nodeToRemove.Equals(curr.Value))
            {
                temp = curr.Left;
                if (temp.Right != null)
                {
                    while (temp.Right.Right != null)
                    {

                        temp = temp.Right;
                    }
                }
                curr.Value = temp.Right.Value;
                oppositeTemp = temp.Right;
                oppositeTemp = oppositeTemp.Left;
                temp.Right = oppositeTemp;
                
            }
            // if nodeToRemove is less than the curr
            else if (nodeToRemove.CompareTo(curr.Value) < 0)
            {
                temp = curr.Left;
                if (!nodeToRemove.Equals(temp.Left.Value))
                {
                    remove(nodeToRemove, temp);
                }

            }
            // if the nodeToRemove is greater than the curr
            else if (nodeToRemove.CompareTo(curr.Value) > 0)
            {
                temp = curr.Right;
                if (!nodeToRemove.Equals(temp.Value))
                {
                    remove(nodeToRemove, temp);
                }
                // make it go back to the first if statement that actually swaps it.

            }
            return Balance(curr);



            /*
            if (curr.Left != null)
                {
                    // if curr is the node to remove
                    if (nodeToRemove.Equals(curr.Value))
                    {
                        temp = curr.Left;
                    }
                    // if curr is not the node to remove
                    else
                    { 
                        while (nodeToRemove.CompareTo(curr.Left.Value) < 0)
                        {
                            temp = curr.Left;
                        }
                        temp = curr.Left;
                    }
                    // if right is not null and the root is the node to remove
                    if (temp.Right != null && nodeToRemove.Equals(root.Value))
                    {
                        while (temp.Right.Right != null)
                        {
                            temp = temp.Right;
                        }
                        curr.Value = temp.Right.Value;
                        oppositeTemp = temp.Right;
                    }
                // otherwise 
                else
                {
                    temp = curr.Left;
                    if (temp.Right != null)
                    { 
                        while(temp.Right.Right != null)
                        {
                            temp = temp.Right;
                        }
                    }
                    oppositeTemp = temp.Right;
                    oppositeTemp = oppositeTemp.Left;
                    curr = curr.Left;
                    curr.Right = oppositeTemp;
                }
                temp.Right = oppositeTemp.Left;
                }

                else
                {
                    ;
                    if (nodeToRemove.Equals(curr.Value))
                    {
                        temp = curr.Right;
                    }
                    else
                    {
                        while (nodeToRemove.CompareTo(curr.Right.Value) > 0)
                        {
                            temp = curr.Right;
                        }
                    }
                    
                    if (temp.Left != null)
                    {
                        while (temp.Left.Left != null)
                        {
                            temp = temp.Left;
                        }
                    }
                    if (temp.Left != null)
                    {
                        curr.Value = temp.Left.Value;
                        oppositeTemp = temp.Left;
                    }

                    temp.Left = oppositeTemp.Right;
                }
                return Balance(curr);

                //if (root.Left is not null)
                //{ 
                //    temp = root.Left;
                //    if (temp.Right != null)
                //    {
                //        while (temp.Right.Right != null)
                //        { 
                //            temp = temp.Right;

                //        }

                //        root.Value = temp.Right.Value;
                //        temp.Right = null;
                //    }
                //    else
                //    {
                //        root.Left = root.Left.Left;
                //    }
                //    root.Value = temp.Value;

                //}
                //return root;
            
            //else if (nodeToRemove.CompareTo(curr.Value) < 0)
            //{
            //    curr.Left = remove(nodeToRemove, curr);
            //    curr.updateHeight();

            //    return Balance(curr);
            //}
            //else if (nodeToRemove.CompareTo(curr.Value) > 0)
            //{
            //    curr.Right = remove(nodeToRemove, curr);
            //    curr.updateHeight();

            //    return Balance(curr);
            //}
            //else
            {
                return Helper(curr);
            }
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

