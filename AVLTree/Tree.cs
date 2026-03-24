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
            
        }
        public Node<T> remove(T thingToRemove, Node<T> curr)
        {
            if (curr is null)
            {
                return null;
            }
            //if curr is null, (value doesn't exist in tree)

            if (curr.Value.Equals(thingToRemove))
            {
                if (curr.Right is null)
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
            tempLeft.updateHeight();
            tempRightRight.updateHeight();
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
            
            tempLeftLeft.updateHeight();
            thingToRotate.updateHeight();
            return tempLeft;
        }
        public Node<T> Balance(Node<T> thingToRotate)
        {
            if (thingToRotate.Balance < -1)
            {
                return rotateRight(thingToRotate);
            }
            else if (thingToRotate.Balance > 1)
            {
                return rotateLeft(thingToRotate);
            }
            return thingToRotate;
        }

    }
}

