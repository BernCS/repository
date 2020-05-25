using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class MyCollection<T> : ICloneable, IDisposable, IEnumerator<T>, IEnumerable<T>
    {
        public T Data;
        public MyCollection<T> Next;
        public MyCollection<T> Previous;
        public int Count;

        private int position = -1;
        private MyCollection<T> current;

        public MyCollection(T data = default(T))
        {
            Count = 1;
            current = this;
            Data = data;
            Next = null;
            Previous = null;
        }

        public MyCollection(int capacity)
        {
            Count = capacity;
            current = this;
            if (capacity == 0)
            {
                return;
            }

            Data = default(T);
            Next = new MyCollection<T>(capacity - 1);
            Next.Previous = this;
        }

        public MyCollection(MyCollection<T> myCollection)
        {
            Count = myCollection.Count;
            current = this;
            if (myCollection == null)
            {
                return;
            }

            Data = myCollection.Data;
            Next = new MyCollection<T>(myCollection.Next);
            Next.Previous = this;
        }

        public void Add(T data)
        {
            if (Count == 1)
            {
                Next = new MyCollection<T>();
                Next.Data = data;
                Next.Previous = this;
                Count++;
                return;
            }
            Count++;
            Next.Add(data);
        }

        public void Add(MyCollection<T> myCollection)
        {
            if (Count == 1)
            {
                Next = myCollection;
                Count += myCollection.Count;
                return;
            }
            Count += myCollection.Count;
            Next.Add(myCollection);
        }

        public static bool Remove(ref MyCollection<T> myCollection, T data)
        {
            if (myCollection.Data.Equals(data))
            {
                if (myCollection.Previous == null)
                {
                    myCollection = myCollection.Next;
                    if (myCollection != null)
                        myCollection.Previous = null;
                    return true;
                }
                if (myCollection.Next == null)
                {
                    myCollection.Previous.Next = null;
                    return true;
                }
                //MyCollection<T> temp = myCollection.Previous;
                myCollection.Next.Previous = myCollection.Previous;
                myCollection.Previous.Next = myCollection.Next;
                return true;
            }
            if (myCollection.Count == 1)
            {
                return false;
            }

            if (MyCollection<T>.Remove(ref myCollection.Next, data))
            {
                myCollection.Count--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static MyCollection<T> Remove(MyCollection<T> myCollection, MyCollection<T> toDelete)
        {
            while(toDelete != null)
            {
                MyCollection<T>.Remove(ref myCollection, toDelete.Data);
                toDelete = toDelete.Next;
            }
            return myCollection;
        }

        /*private MyCollection<T> Get(int index)
        {
            if (index == 0)
                return this;
            if (Next == null)
                return null;
            return Next.Get(index - 1);
        }*/

        public int Contains(T data, int index = 0)
        {
            if (data.Equals(Data))
            {
                return index;
            }
            if (Count == 1)
            {
                return -1;
            }
            return Next.Contains(data, index + 1);
        }

        public void Print()
        {
            Console.WriteLine(Data);
            if (Count == 1)
            {
                return;
            }
            Next.Print();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Dispose() { }

        public T Current
        {
            get
            {
                return current.Data;
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Reset()
        {
            current = this;
            position = -1;
        }

        public bool MoveNext()
        {
            if (current.Next == null)
            {
                Reset();
                return false;
            }
            else
            {
                if (position > -1)
                {
                    current = current.Next;
                }
                position++;
                return true;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}
