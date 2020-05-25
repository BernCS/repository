using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Country
    {
        protected string name;
        protected int population;

        public Country()
        {
            Console.WriteLine("Введите название страны: ");
            this.name = Console.ReadLine();

            Console.WriteLine("Введите население страны: ");
            this.population = Input.Int(0, int.MaxValue);
        }

        public Country(string name, int population)
        {
            this.name = name;
            this.population = population;
        }

        public string GetName()
        {
            return name;
        }

        public int GetPopulation()
        {
            return population;
        }

        virtual public void Print()
        {
            Console.WriteLine($"Страна - {name}, численность населения - {population}.");
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;
            if (object.ReferenceEquals(this, other))
                return true;
            if (this.GetType() != other.GetType())
                return false;

            return this.Equals(other as Country);
        }

        public bool Equals(Country other)
        {
            if (other == null)
                return false;

            if (population == other.GetPopulation() && name == other.GetName())
                return true;
            else
                return false;
        }
    }


    class Kingdom : Country
    {
        protected string king;

        public Kingdom(string name, int population, string king) : base(name, population)
        {
            this.king = king;
        }

        public Kingdom() : base()
        {
            Console.WriteLine("Введите название королевства: ");
            this.name = Console.ReadLine();

            Console.WriteLine("Введите население королевства: ");
            this.population = Input.Int(0, int.MaxValue);

            Console.WriteLine("Введите имя короля: ");
            this.king = Console.ReadLine();
        }

        public string GetKing()
        {
            return king;
        }

        override public void Print()
        {
            Console.WriteLine($"Королевство - {name}, король - {king}, численность населения - {population}.");
        }
    }

    class Monarchy : Country
    {
        protected string imperor;

        public Monarchy() : base()
        {
            Console.WriteLine("Введите название монархии: ");
            this.name = Console.ReadLine();

            Console.WriteLine("Введите население монархии: ");
            this.population = Input.Int(0, int.MaxValue);

            Console.WriteLine("Введите имя императора: ");
            this.imperor = Console.ReadLine();
        }

        public Monarchy(string name, int population, string imperor) : base(name, population)
        {
            this.imperor = imperor;
        }

        public string GetImperor()
        {
            return imperor;
        }

        override public void Print()
        {
            Console.WriteLine($"Империя - {name}, император - {imperor}, численность населения - {population}.");
        }
    }

    class Republic : Country
    {
        protected string president;

        public Republic() : base()
        {
            Console.WriteLine("Введите название республики: ");
            this.name = Console.ReadLine();

            Console.WriteLine("Введите население республики: ");
            this.population = Input.Int(0, int.MaxValue);

            Console.WriteLine("Введите имя президента: ");
            this.president = Console.ReadLine();
        }

        public Republic(string name, int population, string president) : base(name, population)
        {
            this.president = president;
        }

        public string GetPresident()
        {
            return president;
        }

        override public void Print()
        {
            Console.WriteLine($"Республика - {name}, президент - {president}, численность населения - {population}.");
        }

    }

}
