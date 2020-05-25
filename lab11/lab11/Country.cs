using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    class Country
    {
        protected string name;
        protected int population;

        public Country(string name, int population)
        {
            this.name = name;
            this.population = population;
        }

        public Country()
        {
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetPopulation()
        {
            return population;
        }

        virtual public void In()
        {
            Console.WriteLine("Введите название государства: ");
            name = Console.ReadLine();

            population = Input.Int("Введите кол-во жителей: ");
        }

        virtual public void Print()
        {
            Console.WriteLine($"Страна - {name}, численность населения - {population}.");
        }

        public override string ToString()
        {
            return name + population;
        }
    }


    class Kingdom : Country
    {
        protected string king;

        public Kingdom(string name, int population, string king) : base(name, population)
        {
            this.king = king;
        }

        public Kingdom()
        {
        }

        public Country BaseCountry
        {
            get
            {
                return new Country(name, population);
            }
        }

        public string GetKing()
        {
            return king;
        }

        override public void In()
        {
            Console.WriteLine("Введите название королевства: ");
            name = Console.ReadLine();

            population = Input.Int("Введите кол-во жителей: ");

            Console.WriteLine("Введите короля: ");
            king = Console.ReadLine();
        }

        override public void Print()
        {
            Console.WriteLine($"Королевство - {name}, король - {king}, численность населения - {population}.");
        }
    }

    class Monarchy : Country
    {
        protected string imperor;

        public Monarchy(string name, int population, string imperor) : base(name, population)
        {
            this.imperor = imperor;
        }

        public Monarchy()
        {
        }

        public Country BaseCountry
        {
            get
            {
                return new Country(name, population);
            }
        }

        public string GetImperor()
        {
            return imperor;
        }

        override public void In()
        {
            Console.WriteLine("Введите название монархии: ");
            name = Console.ReadLine();

            population = Input.Int("Введите кол-во жителей: ");

            Console.WriteLine("Введите императора: ");
            imperor = Console.ReadLine();
        }

        override public void Print()
        {
            Console.WriteLine($"Монархия - {name}, император - {imperor}, численность населения - {population}.");
        }
    }

    class Republic : Country
    {
        protected string president;

        public Republic(string name, int population, string president) : base(name, population)
        {
            this.president = president;
        }

        public Republic()
        {
        }

        public Country BaseCountry
        {
            get
            {
                return new Country(name, population);
            }
        }

        public string GetPresident()
        {
            return president;
        }

        override public void In()
        {
            Console.WriteLine("Введите название республики: ");
            name = Console.ReadLine();

            population = Input.Int("Введите кол-во жителей: ");

            Console.WriteLine("Введите президента: ");
            president = Console.ReadLine();
        }

        override public void Print()
        {
            Console.WriteLine($"Республика - {name}, президент - {president}, численность населения - {population}.");
        }

        public override string ToString() 
        {
            return name + population + president;
        }
    }

}
