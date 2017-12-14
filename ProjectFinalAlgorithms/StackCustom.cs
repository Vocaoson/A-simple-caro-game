using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalAlgorithms
{
    public class Node<T>
    {
        public T data;
        public Node<T> pNext;
    }
    public class TopStack<T>
    {
        public Node<T> pTop;
    }
    public class StackCustom<T>
    {
        private TopStack<T> top;

        public TopStack<T> Top
        {
            get
            {
                return top;
            }

            set
            {
                top = value;
            }
        }
        public StackCustom()
        {
            top = new TopStack<T>();
        }
        #region Method
        public void CreateStack()
        {
            top.pTop = null;
        }
        public void Push(T data)
        {
            Node<T> p = CreateNode(data);
            if(top.pTop == null)
            {
                top.pTop = p;
            }
            else
            {
                p.pNext = top.pTop;
                top.pTop = p;
            }
        }
        public T Pop()
        {
            T result;
            Node<T> node = top.pTop;
            result = top.pTop.data;
            top.pTop = top.pTop.pNext;
            node = null;
            return result;
        }
        public bool isEmpty()
        {
            if (top.pTop == null) return true;
            return false;
        }
        public Node<T> CreateNode(T data)
        {
            Node<T> p = new Node<T>();
            p.data = data;
            p.pNext = null;
            return p;
        }
        public void Clear()
        {
            top.pTop = null;
        }
        #endregion

    }
}
