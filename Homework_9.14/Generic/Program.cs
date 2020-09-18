using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void Foreach(Action<T> action)
        {
            Node<T> n = this.head;
            while (n != null)
            {
                action(n.Data);
                n = n.Next;
            }
        }

        public void PrintLinkList()
        {
            this.Foreach(n => Console.Write(n.ToString() + " "));
            Console.Write("\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            GenericList<int> intlist = new GenericList<int>();

            for (int i = 0; i < 10; i++)
            {
                intlist.Add(i + 1);
            }

            int total = 0;
            int minData = int.MaxValue;
            int maxData = int.MinValue;
            Action<int> Method = new Action<int>(n => total += n);
            Method += (n => { if (n < minData) minData = n; });
            Method += (n => { if (n > maxData) maxData = n; });

            intlist.PrintLinkList();
            intlist.Foreach(Method);
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Min: {minData}");
            Console.WriteLine($"Max: {maxData}");


        }

    }
}
