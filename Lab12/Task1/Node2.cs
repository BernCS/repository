using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Node2 : IDisposable
    {
        public Country Data;
        public Node2 Next;
        public Node2 Pred;

        public Node2()
        {
            Data = default(Country);
            Next = null;
            Pred = null;
        }

        public Node2(Country data)
        {
            Data = data;
            Next = null;
            Pred = null;
        }

        public void MakeNode(int size)
        {
            if (size == 0)
                return;

            Data = new Country();
            Next = new Node2();
            Next.Pred = this;
            Next.MakeNode(size - 1);
        }

        public void Print()
        {
            if (Next == null)
                return;
            Data.Print();
            Next.Print();

        }

        public void Add(Country dataToFind, Country afterData)
        {
            if (this.Next == null)
            {
                Console.WriteLine("Не найдено!");
                return;
            }
            if (this.Data.GetName() ==  dataToFind.GetName() && this.Data.GetPopulation() == dataToFind.GetPopulation())
            {
                Node2 node = new Node2(afterData);
                node.Next = this.Next;
                node.Pred = this;
                this.Next = node;
                return;
            }
            this.Next.Add(dataToFind, afterData);
        }

        public void Dispose() { }
    }
}
