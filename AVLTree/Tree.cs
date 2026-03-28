using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

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

                return new Node<T>(thingToInsert);
            }
            else
            {
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
            }
            curr.updateHeight();

            return Balance(curr);
        }
        public void remove(T thingToRemove)
        {
            root = remove(thingToRemove, root);
            root.updateHeight();
            count--;
        }
        public Node<T> remove(T thingToRemove, Node<T> curr)
        {
            if (curr is null)
            {
                //nullRemove = false;
                return null;
            }
            //if curr is null, (value doesn't exist in tree)
            if (curr.Right != null && curr.Left != null)
            {
                Node<T> temp = curr.Left;
                Node<T> ttemp = temp;
                for (int index = 0; index < curr.Height; index++)
                {
                    if (temp.Right != null)
                    {
                        temp = temp.Right;
                    }
                    if (temp.Right != null)
                    {
                        ttemp = ttemp.Right;
                    }
                }
                
                curr.Value = temp.Value;
                ttemp.Right = null;
                
                
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

