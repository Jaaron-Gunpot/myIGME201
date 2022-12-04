using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 1, 2, 3 };
            MyStack myStack = new MyStack(ints);
            //while (true){}
        }
    }
    class MyStack 
    {
        public List<int> stack;
        public MyStack(int[] main)
        {
            this.stack = new List<int>(main);
        }
        public void Push(int n)
        {
            stack.Add(n);
        }
        public int Pop()
        {
            int top = stack.ElementAt(stack.Count - 1);
            stack.RemoveAt(stack.Count - 1);
            return top;
        }
        public int Peek()
        {
            int top = stack.ElementAt(stack.Count - 1);
            return top;
        }
    }
    class MyQueue
    {
        public List<int> queue;
        public MyQueue(int[] main)
        {
            this.queue = new List<int>(main);
        }
        public void EnQueue(int n)
        {
            queue.Reverse();
            queue.Add(n);
            queue.Reverse();
        }
        public int Peek()
        {
            return queue.ElementAt(queue.Count - 1);
        }
        public int DeQueue()
        {
            int front = queue.ElementAt(queue.Count - 1);
            queue.Remove(queue.ElementAt(queue.Count - 1));
            return front;
        }
    }
}
