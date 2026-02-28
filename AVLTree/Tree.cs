using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public class Tree<T> where T : IComparable<T>
    {
        int count = 0;
        Node<T> root;
        
       
        public void Insert(T thingToInsert)
        {
            Node<T> temp = root;
            if (root == null)
            {
                root = new Node<T>(thingToInsert);
                return;
            }
            else if (thingToInsert.CompareTo(temp.Value) < 0)
            {
                if (temp.Left != null)
                {
                    temp = temp.Left;
                    Insert(thingToInsert);
                }
                temp.Left = new Node<T>(thingToInsert);
            }
            else if (thingToInsert.CompareTo(temp.Value) > 0)
            {
                if (temp.Right != null)
                { 
                    temp = temp.Right;
                    Insert(thingToInsert);
                }
                temp.Right = new Node<T>(thingToInsert);
            }
        }
    }
    
}
