using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    class TestCollections
    {
        int count;
        List<Country> countries = new List<Country>();
        List<string> countriesS = new List<string>();
        Dictionary<Country, Republic> republics = new Dictionary<Country, Republic>();
        Dictionary<string, Republic> republicsS = new Dictionary<string, Republic>();

        public TestCollections()
        {
            List<Republic> list = new List<Republic>();

            countries = new List<Country>();
            countriesS = new List<string>();
            republics = new Dictionary<Country, Republic>();
            republicsS = new Dictionary<string, Republic>();

            list.Add(new Republic("Афганистан", 31500000, "Ашраф Гани"));
            list.Add(new Republic("Албания", 2876591, "Илир Мета"));
            list.Add(new Republic("Алжир", 38087012, "Абдельмаджид Теббун"));
            list.Add(new Republic("Аргентина", 43417000, "Альберто Фернандес"));
            list.Add(new Republic("Германия", 83019200, "Франк-Вальтер Штайнмайер"));

            for (int i = 0; i < list.Count; i++)
            {
                Republic republic = list[i];

                countries.Add(republic as Country);
                countriesS.Add((republic as Country).ToString());
                republics.Add(republic as Country, republic);
                republicsS.Add((republic as Country).ToString(), republic);
            }
        }

        public TestCollections(int count)
        {
            this.count = count;

            countries = new List<Country>();
            countriesS = new List<string>();
            republics = new Dictionary<Country, Republic>();
            republicsS = new Dictionary<string, Republic>();

            for (int i = 0; i < this.count; i++)
            {
                Republic republic = new Republic();
                republic.In();

                countries.Add(republic as Country);
                countriesS.Add((republic as Country).ToString());
                republics.Add(republic as Country, republic);
                republicsS.Add((republic as Country).ToString(), republic);
            }
        }

        public void Add(Republic republic)
        {
            countries.Add(republic as Country);
            countriesS.Add((republic as Country).ToString());
            republics.Add(republic as Country, republic);
            republicsS.Add((republic as Country).ToString(), republic);
        }

        public void Delete(Republic republic)
        {
            countries.Remove(republic);
            countriesS.Remove((republic as Country).ToString());
            republics.Remove(republic as Country);
            republicsS.Remove((republic as Country).ToString());
        }

        public void ContainTime1()
        {
            Console.WriteLine("[Ищем элементы в countries]");

            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();
            countries.Contains(new Republic("Афганистан", 31500000, "Ашраф Гани") as Country);
            stopWatch.Stop();
            Console.WriteLine("Для поиска первого элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            countries.Contains(new Republic("Алжир", 38087012, "Абдельмаджид Теббун") as Country);
            stopWatch.Stop();
            Console.WriteLine("Для поиска среднего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            countries.Contains(new Republic("Германия", 83019200, "Франк-Вальтер Штайнмайер") as Country);
            stopWatch.Stop();
            Console.WriteLine("Для поиска последнего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            countries.Contains(new Republic("Гер", 83019200, "Франк-Вальтер Штайнмайер") as Country);
            stopWatch.Stop();
            Console.WriteLine("Для поиска элемента, которого нет, понадобилось: " + stopWatch.Elapsed);

        }

        public void ContainTime2()
        {
            Console.WriteLine("[Ищем элементы в countriesS]");

            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();
            countriesS.Contains((new Republic("Афганистан", 31500000, "Ашраф Гани") as Country).ToString());
            stopWatch.Stop();
            Console.WriteLine("Для поиска первого элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            countriesS.Contains((new Republic("Алжир", 38087012, "Абдельмаджид Теббун") as Country).ToString());
            stopWatch.Stop();
            Console.WriteLine("Для поиска среднего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            countriesS.Contains((new Republic("Германия", 83019200, "Франк-Вальтер Штайнмайер") as Country).ToString());
            stopWatch.Stop();
            Console.WriteLine("Для поиска последнего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            countriesS.Contains((new Republic("Гер", 83019200, "Франк-Вальтер Штайнмайер") as Country).ToString());
            stopWatch.Stop();
            Console.WriteLine("Для поиска элемента, которого нет, понадобилось: " + stopWatch.Elapsed);

        }

        public void ContainTime3()
        {
            Console.WriteLine("[Ищем элементы в republics по ключу]");

            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();
            republics.ContainsKey(new Republic("Афганистан", 31500000, "Ашраф Гани") as Country);
            stopWatch.Stop();
            Console.WriteLine("Для поиска первого элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republics.ContainsKey(new Republic("Алжир", 38087012, "Абдельмаджид Теббун") as Country);
            stopWatch.Stop();
            Console.WriteLine("Для поиска среднего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republics.ContainsKey(new Republic("Германия", 83019200, "Франк-Вальтер Штайнмайер") as Country);
            stopWatch.Stop();
            Console.WriteLine("Для поиска последнего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republics.ContainsKey(new Republic("Гер", 83019200, "Франк-Вальтер Штайнмайер") as Country);
            stopWatch.Stop();
            Console.WriteLine("Для поиска элемента, которого нет, понадобилось: " + stopWatch.Elapsed);

        }

        public void ContainTime4()
        {
            Console.WriteLine("[Ищем элементы в republics по элементу]");

            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();
            republics.ContainsValue(new Republic("Афганистан", 31500000, "Ашраф Гани"));
            stopWatch.Stop();
            Console.WriteLine("Для поиска первого элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republics.ContainsValue(new Republic("Алжир", 38087012, "Абдельмаджид Теббун"));
            stopWatch.Stop();
            Console.WriteLine("Для поиска среднего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republics.ContainsValue(new Republic("Германия", 83019200, "Франк-Вальтер Штайнмайер"));
            stopWatch.Stop();
            Console.WriteLine("Для поиска последнего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republics.ContainsValue(new Republic("Гер", 83019200, "Франк-Вальтер Штайнмайер"));
            stopWatch.Stop();
            Console.WriteLine("Для поиска элемента, которого нет, понадобилось: " + stopWatch.Elapsed);

        }

        public void ContainTime5()
        {
            Console.WriteLine("[Ищем элементы в republicsS по ключу]");

            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();
            republicsS.ContainsKey((new Republic("Афганистан", 31500000, "Ашраф Гани") as Country).ToString());
            stopWatch.Stop();
            Console.WriteLine("Для поиска первого элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republicsS.ContainsKey((new Republic("Алжир", 38087012, "Абдельмаджид Теббун") as Country).ToString());
            stopWatch.Stop();
            Console.WriteLine("Для поиска среднего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republicsS.ContainsKey((new Republic("Германия", 83019200, "Франк-Вальтер Штайнмайер") as Country).ToString());
            stopWatch.Stop();
            Console.WriteLine("Для поиска последнего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republicsS.ContainsKey((new Republic("Гер", 83019200, "Франк-Вальтер Штайнмайер") as Country).ToString());
            stopWatch.Stop();
            Console.WriteLine("Для поиска элемента, которого нет, понадобилось: " + stopWatch.Elapsed);

        }

        public void ContainTime6()
        {
            Console.WriteLine("[Ищем элементы в republicsS по элементу]");

            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();
            republicsS.ContainsValue(new Republic("Афганистан", 31500000, "Ашраф Гани"));
            stopWatch.Stop();
            Console.WriteLine("Для поиска первого элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republicsS.ContainsValue(new Republic("Алжир", 38087012, "Абдельмаджид Теббун"));
            stopWatch.Stop();
            Console.WriteLine("Для поиска среднего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republicsS.ContainsValue(new Republic("Германия", 83019200, "Франк-Вальтер Штайнмайер"));
            stopWatch.Stop();
            Console.WriteLine("Для поиска последнего элемента понадобилось: " + stopWatch.Elapsed);

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            republicsS.ContainsValue(new Republic("Гер", 83019200, "Франк-Вальтер Штайнмайер"));
            stopWatch.Stop();
            Console.WriteLine("Для поиска элемента, которого нет, понадобилось: " + stopWatch.Elapsed);

        }
    }
}
