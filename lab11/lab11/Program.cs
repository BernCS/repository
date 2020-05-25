using System;
using System.Collections.Generic;
using System.Collections;

namespace lab11
{
    class Menu
    {
        public delegate void Request();

        private List<String> options = new List<string>();
        private List<Request> requests = new List<Request>();

        public Menu(List<string> options, List<Request> requests)
        {
            this.options = options;
            this.requests = requests;
        }

        public void Show()
        {
            int curOption = -1;
            while (curOption != 0)
            {
                Console.Clear();
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine((i + 1).ToString() + ") " + options[i]);
                }
                Console.WriteLine("0) Выход");

                curOption = Input.Int("Выберите опцию:", 0, requests.Count + 1);

                if (curOption == 0)
                    break;

                requests[curOption - 1]();

                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadKey();
            }
        }
    }

    class Program
    {
        public static Program program = new Program();

        #region task1Funcs

        public List<Country> countries = new List<Country>();

        public void PrintList()
        {
            int i = 0;

            Console.Clear();

            if (countries.Count == 0)
            {
                Console.WriteLine("List пуст.");
                return;
            }

            foreach (Country country in countries)
            {
                Console.Write(++i + ") ");
                country.Print();
            }
            
        }

        public void AddToList()
        {
            Console.Clear();
            Console.WriteLine("1) Королевство");
            Console.WriteLine("2) Монархия");
            Console.WriteLine("3) Республика");
            Console.WriteLine("4) Неизвестно");
            Console.WriteLine("0) Выход");

            int option = Input.Int("Выберите тип государства: ", 0, 5);

            switch (option)
            {
                case 1:
                    {
                        Kingdom kingdom = new Kingdom();
                        kingdom.In();
                        countries.Add(kingdom);
                        break;
                    }
                case 2:
                    {
                        Monarchy monarchy = new Monarchy();
                        monarchy.In();
                        countries.Add(monarchy);
                        break;
                    }
                case 3:
                    {
                        Republic republic = new Republic();
                        republic.In();
                        countries.Add(republic);
                        break;
                    }
                case 4:
                    {
                        Country country = new Country();
                        country.In();
                        countries.Add(country);
                        break;
                    }
                case 0:
                    {
                        return;
                    }
            }
        }

        public void DeleteFromList()
        {
            Console.Clear();

            if (countries.Count == 0)
            {
                Console.WriteLine("List пуст.");
                return;
            }

            int index = Input.Int($"Введите номер нужно элемента: (от 1 до { countries.Count})", 1, countries.Count);
            countries.RemoveAt(index - 1);
            
        }

        public void FindKings()
        {
            int i = 0;

            if (countries.Count == 0)
            {
                Console.WriteLine("List пуст.");
                return;
            }

            Console.Clear();
            foreach (Country country in countries)
            {
                if (country is Kingdom)
                {
                    Console.WriteLine(++i + $") {(country as Kingdom).GetKing()}");
                }
            }

            if (i == 0)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        public void FindNamesOfRepublics()
        {
            int i = 0;

            if (countries.Count == 0)
            {
                Console.WriteLine("List пуст.");
                return;
            }

            Console.Clear();
            foreach (Country country in countries)
            {
                if (country is Republic)
                {
                    Console.WriteLine(++i + $") {country.GetName()}");
                }
            }


            if (i == 0)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        public void FindPopulationElevenMillion()
        {
            int i = 0;

            if (countries.Count == 0)
            {
                Console.WriteLine("List пуст.");
                return;
            }

            Console.Clear();
            foreach (Country country in countries)
            {
                if (country.GetPopulation() > 11e6)
                {
                    i++;
                }
            }
            Console.WriteLine("Кол-во таких государств: " + i);
        }

        public void SortListByName()
        {
            if (countries.Count == 0)
            {
                Console.WriteLine("List пуст.");
                return;
            }

            for (int i = 0; i < countries.Count - 1; i++)
            {
                if (String.Compare(countries[i].GetName(), countries[i + 1].GetName()) == 1)
                {
                    string tmp = countries[i].GetName();
                    countries[i].SetName(countries[i + 1].GetName());
                    countries[i + 1].SetName(tmp);
                    i = (i > 1) ? i - 2 : i;
                }
            }

            PrintList();
        }

        public void FindInListByName()
        {
            Console.Clear();

            Console.WriteLine("Введите название государства: ");
            string nameToFind = Console.ReadLine();

            for (int i = 0; i < countries.Count; i++)
            {
                if (nameToFind == countries[i].GetName())
                {
                    Console.WriteLine("Номер страны в списке - " + (i + 1));
                    return;
                }
            }

            Console.WriteLine("Страна не найдена.");
        }

        #endregion

        #region task2Funcs

        public Dictionary<int, Country> countriesD = new Dictionary<int, Country>();

        public void PrintDictionary()
        {
            Console.Clear();

            if (countriesD.Count == 0)
            {
                Console.WriteLine("Dictionary пуст.");
                return;
            }

            foreach (int i in countriesD.Keys)
            {
                Console.Write($"К году { i } относится: ");
                countriesD[i].Print();
            }
        }

        public void AddToDictionary()
        {
            Console.Clear();
            Console.WriteLine("1) Королевство");
            Console.WriteLine("2) Монархия");
            Console.WriteLine("3) Республика");
            Console.WriteLine("4) Неизвестно");
            Console.WriteLine("0) Выход");

            int option = Input.Int("Выберите тип государства: ", 0, 5);

            switch (option)
            {
                case 1:
                    {
                        Kingdom kingdom = new Kingdom();
                        int dateIndex;

                        kingdom.In();
                        dateIndex = Input.Int("Введите год появления государства: ", 0, 2021);
                        if (!countriesD.TryAdd(dateIndex, kingdom))
                        {
                            Console.WriteLine("Ошибка добавления");
                        }
                        break;
                    }
                case 2:
                    {
                        Monarchy monarchy = new Monarchy();
                        monarchy.In();
                        int dateIndex = Input.Int("Введите год появления государства: ", 0, 2021);
                        if (!countriesD.TryAdd(dateIndex, monarchy))
                        {
                            Console.WriteLine("Ошибка добавления");
                        }
                        break;
                    }
                case 3:
                    {
                        Republic republic = new Republic();
                        republic.In();
                        int dateIndex = Input.Int("Введите год появления государства: ", 0, 2021);
                        if (!countriesD.TryAdd(dateIndex, republic))
                        {
                            Console.WriteLine("Ошибка добавления");
                        }
                        break;
                    }
                case 4:
                    {
                        Country country = new Country();
                        country.In();
                        int dateIndex = Input.Int("Введите год появления государства: ", 0, 2021);
                        if (!countriesD.TryAdd(dateIndex, country))
                        {
                            Console.WriteLine("Ошибка добавления");
                        }
                        break;
                    }
                case 0:
                    {
                        return;
                    }
            }
        }

        public void DeleteFromDictionary()
        {
            Console.Clear();

            if (countriesD.Count == 0)
            {
                Console.WriteLine("Dictionary пуст.");
                return;
            }

            int dataIndex = Input.Int($"Введите год появления государства:" );

            if (!countriesD.Remove(dataIndex))
            {
                Console.WriteLine("Государство не было найдено");
            }

        }

        public void FindCountriesInFirstThousand()
        {
            Console.Clear();

            if (countriesD.Count == 0)
            {
                Console.WriteLine("Dictionary пуст.");
                return;
            }

            foreach (int i in countriesD.Keys)
            {
                if (i < 1001 && i > 0)
                {
                    countriesD[i].Print();
                }
            }
        }

        public void FindCountriesInSecondThousand()
        {
            Console.Clear();

            if (countriesD.Count == 0)
            {
                Console.WriteLine("Dictionary пуст.");
                return;
            }

            foreach (int i in countriesD.Keys)
            {
                if (i < 2001 && i > 1000)
                {
                    countriesD[i].Print();
                }
            }
        }

        public void FindMonarchies()
        {
            Console.Clear();

            if (countriesD.Count == 0)
            {
                Console.WriteLine("Dictionary пуст.");
                return;
            }

            foreach (int i in countriesD.Keys)
            {
                if (countriesD[i] is Monarchy)
                {
                    countriesD[i].Print();
                }
            }
        }

        public void SortDictionaryByYear()
        {
            if (countriesD.Count == 0)
            {
                Console.WriteLine("Dictionary пуст.");
                return;
            }

            Dictionary<int, Country> helpDictionary = new Dictionary<int, Country>();

            for (int i = 0; i < 2021; i++)
            {
                if (countriesD.ContainsKey(i))
                {
                    helpDictionary.Add(i, countriesD[i]);
                }
            }

            countriesD = helpDictionary;
            PrintDictionary();
        }

        public void FindInDictionaryByName()
        {
            Console.Clear();

            Console.WriteLine("Введите название государства: ");
            string nameToFind = Console.ReadLine();

            foreach (int i in countriesD.Keys)
            {
                if (nameToFind == countriesD[i].GetName())
                {
                    countriesD[i].Print();
                    return;
                }
            }

            Console.WriteLine("Страна не найдена.");
        }

        #endregion

        #region task3Funcs

        public void StartCheckContain()
        {
            TestCollections testCollections = new TestCollections();
            testCollections.ContainTime1();
            testCollections.ContainTime2();
            testCollections.ContainTime3();
            testCollections.ContainTime4();
            testCollections.ContainTime5();
            testCollections.ContainTime6();
        }

        #endregion

        public static void Main(string[] args)
        {

            Menu task1 = new Menu(new List<string>(new string[] { "Вывести коллекцию", "Добавить страну в коллекцию", "Удалить страну из коллекции", "Вывести имена всех королей",
                                                                  "Вывести названия всех республик", "Вывести количество государств с населением больше 11000000 людей",
                                                                  "Отсортировать коллекцию по названию", "Найти элемент в коллекции по названию"}), 
                                                   new List<Menu.Request>() { program.PrintList, program.AddToList, program.DeleteFromList, program.FindKings, 
                                                                              program.FindNamesOfRepublics, program.FindPopulationElevenMillion,
                                                                              program.SortListByName, program.FindInListByName });

            Menu task2 = new Menu(new List<string>(new string[] { "Вывести обобщенную коллекцию", "Добавить страну в обобщенную коллекцию", "Удалить страну из обобщенной коллекции", 
                                                                   "Вывести государства, появившиеся в 1-ом тысячелетии", "Вывести государства, появивишиеся во 2-ом тысячелетии",
                                                                   "Вывести все монархии", "Отсортировать обобщенный список по имени", "Найти элемент в обобщенном списке по имени"}), 
                                                   new List<Menu.Request>() { program.PrintDictionary, program.AddToDictionary, program.DeleteFromDictionary,
                                                                              program.FindCountriesInFirstThousand, program.FindCountriesInSecondThousand, program.FindMonarchies,
                                                                              program.SortDictionaryByYear, program.FindInDictionaryByName});

            Menu task3 = new Menu(new List<string>(new string[] { "Старт" }), new List<Menu.Request>() { program.StartCheckContain });



            Menu mainMenu = new Menu(new List<string>(new string[] { "Задание 1", "Задание 2", "Задание 3"}), new List<Menu.Request>(new Menu.Request[] { task1.Show, task2.Show, task3.Show }));

            mainMenu.Show();
        }
    }
}
