using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace AVLTree
{
    public class Tree<T> where T : IComparable<T>
    {
        int count = 0;
        Node<T> root;
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
                    return curr;
                }
                else if (thingToInsert.CompareTo(curr.Value) > 0)
                {
                    curr.Right = Insert(thingToInsert, curr.Right);
                    return curr;
                }
            }
            return curr;
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

                    return curr;
                }

                if (curr.Right != null && curr.Left != null)
                {

                }
                //if doesn't have children return null
                //if has children, return the node it get's replaced with
            }
            else
            {
                if (thingToRemove.CompareTo(curr.Value) < 0)
                {
                    curr.Left = remove(thingToInsert, curr.Left);
                    return curr;
                }
                else if (thingToInsert.CompareTo(curr.Value) > 0)
                {
                    curr.Right = remove(thingToInsert, curr.Right);
                    return curr;
                }
            }


            return curr;
        }
    }
}

