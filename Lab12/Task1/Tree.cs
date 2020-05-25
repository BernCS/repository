using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{ 
    class Tree : IDisposable
    {
        public Country Data;
        public Tree Left;
        public Tree Right;

        public Tree(Country data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public Tree()
        {
            Data = default(Country);
            Left = null;
            Right = null;
        }

        public void Add(Country data)
        {
            if (data.GetPopulation() < Data.GetPopulation())
            {
                if (Left == null)
                {
                    Left = new Tree(data);
                    return;
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new Tree(data);
                    return;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

        public void MakeTree(int size)
        {
            if (this.Data == null)
            {
                Data = new Country();
                size--;
            }
            for (int i = 0; i < size; i++)
            {
                Add(new Country());
            }
        }

        public void Print()
        {
            Data.Print();
            if (Left != null)
            {
                Left.Print();
            }
            if (Right != null)
            {
                Right.Print();
            }
        }

        private void TreeToMassive(ref List<Country> countries)
        {
            countries.Add(this.Data);
            if (Left != null)
            {
                Left.TreeToMassive(ref countries);
            }
            if (Right != null)
            {
                Right.TreeToMassive(ref countries);
            }
        }

        private bool AddToLevel(Country country, int level)
        {
            if (level == 1)
            {
                if (Left == null)
                {
                    Left = new Tree(country);
                    return true;
                }
                if (Right == null)
                {
                    Right = new Tree(country);
                    return true;
                }
                return false;
            }
            if (Left.AddToLevel(country, level - 1))
            {
                return true;
            }
            else if (Right.AddToLevel(country, level - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Tree IdealTreeFromDefault(Tree tree)
        {
            List<Country> listedTree = new List<Country>();
            tree.TreeToMassive(ref listedTree);
            Tree newTree = new Tree();
            newTree.Data = listedTree[0];
            for (int i = 2; i <= listedTree.Count; i++)
            {
                newTree.AddToLevel(listedTree[i - 1], (int)Math.Log2(i));
            }
            return newTree;
        }

        public static Tree DefaultTreeFromIdeal(Tree tree)
        {
            List<Country> listedTree = new List<Country>();
            tree.TreeToMassive(ref listedTree);
            Tree newTree = new Tree();
            newTree.Data = listedTree[0];
            for (int i = 1; i < listedTree.Count; i++)
            {
                newTree.Add(listedTree[i]);
            }
            return newTree;
        }

        public int LeafsCount()
        {
            if (Left == null && Right == null)
            {
                return 1;
            }
            if (Left == null)
                return Right.LeafsCount();
            if (Right == null)
                return Left.LeafsCount();
            return Left.LeafsCount() + Right.LeafsCount();
        }

        public void Dispose() { }
    }
}
