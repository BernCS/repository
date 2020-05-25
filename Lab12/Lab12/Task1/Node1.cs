using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Node1 : IDisposable
{
        public Country Data;
        public Node1 Next;

        public Node1()
        {
            Data = default(Country);
            Next = null;
        }

        public Node1(Country data)
        {
            Data = data;
            Next = null;
        }

        static Node1 MakeNode(Country data)
        {
            Node1 node = new Node1(data);
            return node;
        }

        public static Node1 MakeList(int size)
        {
            Country data = new Country();

            Node1 first = MakeNode(data);

            for (int i = 1; i < size; i++)
            {
                data = new Country();
                Node1 node = MakeNode(data);
                node.Next = first;
                first = node;
            }
            return first;
        }

        public Node1 Delete(Node1 node)
        {
            if (node.Next == null)
                return node;

            Node1 newNode = new Node1();
            if (node.Next.Data.GetPopulation() % 2 == 0)
            {
                newNode.Next = Delete(node.Next.Next);
            }
            else
            {
                newNode.Next = Delete(node.Next);
            }
            if (node.Data.GetPopulation() % 2 == 0)
                newNode = newNode.Next;
            else
                newNode.Data = node.Data;
            return newNode;
        }

        public void Print()
        {
            Node1 curNode = this; 
            while (curNode != null)
            {
                curNode.Data.Print();
                curNode = curNode.Next;
            }

        }

        public void Dispose() { }

    }
}
