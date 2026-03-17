using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public class Node<T>
    {
        public Node<T> Right { get; set; }
        public Node<T> Left { get; set; }
        public T Value { get; set; }
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
            Value = value;
            Height = 1;
        }
        public void updateHeight()
        {
            
            if (Left == null)
            {
                Height = Right.Height + 1;
            }
            else if (Right == null)
            {
                Height = Left.Height + 1;
            }
            else
            {
                Height = Math.Max(Right.Height, Left.Height);
                Balance = Right.Height - Left.Height;
            }
        }
        
            


    }
}
