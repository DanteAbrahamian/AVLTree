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
            get
            {
                if (Right == null && Left == null)
                {
                    return 0;
                }
                if (Right == null)
                {
                    return -Left.Height;
                }
                if (Left == null)
                {
                    return Right.Height;
                }
                
                return  Right.Height - Left.Height;
            }

        }
        public Node(T value)
        {
            Value = value;
            Height = 1;
          
        }
        public void updateHeight()
        {
            if (Left == null && Right == null)
            {
                Height = 1;
            }
            else if (Left == null && Right !=null)
            {
                Height = Right.Height + 1;
            }
            else if (Right == null && Left != null)
            {
                Height = Left.Height + 1;
            }
            else
            {
                Height = Math.Max(Right.Height, Left.Height) + 1;
            }
        }
    }
}
