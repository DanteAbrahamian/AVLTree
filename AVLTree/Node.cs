using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    internal class Node<T>
    {
        public Node<T> Right { get; internal set; }
        public Node<T> Left { get; internal set; }
        public T Value { get; internal set; }
        public int Height { get;  set; }
        public int Balance 
        { 
            get;
            set 
            {
                Balance = Right.Height - Left.Height;
            }
        }
        public Node(T value)
        {
            
        }
        void updateHeight()
        {

        }
            


    }
}
