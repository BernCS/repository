using System;

namespace Task1
{
    class Program
    {
        static Node1 node1;
        static Node2 node2;
        static Tree tree;
        static MyCollection<Country> myCollection;

        static void Menu1()
        {
            int option = -1;
            while (option != 0)
            {
                Console.Clear();
                Console.WriteLine("1) Создать список.");
                Console.WriteLine("2) Вывести список.");
                Console.WriteLine("3) Удалить из списка первый элемент с четным информационным полем.");
                Console.WriteLine("4) Удалить список из памяти.");
                Console.WriteLine("0) Выход.");
                Console.WriteLine("Выберите опцию: ");
                option = Input.Int(0, 5);
                switch (option)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.WriteLine("Введите размер списка: ");
                        node1 = Node1.MakeList(Input.Int(1, 100000));
                        Console.WriteLine("Список создан.");
                        break;
                    case 2:
                        if (node1 == null)
                        {
                            Console.WriteLine("Объект пуст.");
                        }
                        else
                        {
                            node1.Print();
                        }
                        break;
                    case 3:
                        node1 = node1.Delete(node1);
                        break;
                    case 4:
                        node1.Dispose();
                        node1 = null;
                        Console.WriteLine("Список удален из памяти");
                        break;
                }
                Console.ReadKey();
            }
        }
        static void Menu2()
        {
            int option = -1;
            while (option != 0)
            {
                Console.Clear();
                Console.WriteLine("1) Создать список.");
                Console.WriteLine("2) Вывести список.");
                Console.WriteLine("3) Добавить в список элемент после элемента с заданным информационным ");
                Console.WriteLine("4) Удалить список из памяти.");
                Console.WriteLine("0) Выход.");
                Console.WriteLine("Выберите опцию: ");
                option = Input.Int(0, 5);
                switch (option)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.WriteLine("Введите размер списка: ");
                        node2 = new Node2();
                        node2.MakeNode(Input.Int(1, 100000)); ;
                        Console.WriteLine("Список создан.");
                        break;
                    case 2:
                        if (node2 == null)
                        {
                            Console.WriteLine("Объект пуст.");
                        }
                        else
                        {
                            node2.Print();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Введите элемент для поиска: ");
                        Country a = new Country();
                        Console.WriteLine("Введите элемент для добавления: ");
                        node2.Add(a, new Country());
                        break;
                    case 4:
                        node2.Dispose();
                        node2 = null;
                        Console.WriteLine("Список удален из памяти");
                        break;
                }
                Console.ReadKey();
            }
        }
        static void Menu3()
        {
            int option = -1;
            while (option != 0)
            {
                Console.Clear();
                Console.WriteLine("1) Создать идеальное дерево.");
                Console.WriteLine("2) Вывести дерево.");
                Console.WriteLine("3) Найти количество листьев в дереве.");
                Console.WriteLine("4) Удалить список из памяти.");
                Console.WriteLine("5) Перевести идеальное дерево в дерево поиска.");
                Console.WriteLine("0) Выход.");
                Console.WriteLine("Выберите опцию: ");
                option = Input.Int(0, 6);
                switch (option)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.WriteLine("Введите размер дерева: ");
                        tree = new Tree();
                        tree.MakeTree(Input.Int(0, 1000000));
                        tree = Tree.IdealTreeFromDefault(tree);
                        Console.WriteLine("Дерево создано.");
                        break;
                    case 2:
                        if (tree == null)
                        {
                            Console.WriteLine("Объект пуст.");
                        }
                        else
                        {
                            tree.Print();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Кол-во листьев " + tree.LeafsCount());
                        break;
                    case 4:
                        tree.Dispose();
                        tree = null;
                        Console.WriteLine("Список удален из памяти");
                        break;
                    case 5:
                        tree = Tree.DefaultTreeFromIdeal(tree);
                        Console.WriteLine("Дерево переведено.");
                        break;
                }
                Console.ReadKey();
            }
        }
        static void Menu4()
        {
            int option = -1;
            while (option != 0)
            {
                Console.Clear();
                Console.WriteLine("1) Создать коллекцию.");
                Console.WriteLine("2) Вывести коллекцию.");
                Console.WriteLine("3) Удалить элемент.");
                Console.WriteLine("4) Добавить элемент.");
                Console.WriteLine("5) Вывести кол-во элементов.");
                Console.WriteLine("6) Найти элемент.");
                Console.WriteLine("7) Удалить коллекцию из памяти.");
                Console.WriteLine("0) Выход.");
                Console.WriteLine("Выберите опцию: ");
                option = Input.Int(0, 8);
                switch (option)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Console.WriteLine("Введите размер коллекции: ");
                        int n = Input.Int(0, 10000000);
                        for (int i = 0; i < n; i++)
                        {
                            if (i == 0)
                                myCollection = new MyCollection<Country>(new Country());
                            else
                                myCollection.Add(new Country());
                        }
                        Console.WriteLine("Коллекция создана.");
                        break;
                    case 2:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Объект пуст.");
                        }
                        else
                        {
                            foreach (Country country in myCollection)
                            {
                                country.Print();
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Введите элемент для удаления: ");
                        if (!MyCollection<Country>.Remove(ref myCollection, new Country()))
                        {
                            Console.WriteLine("Объект не найден");
                        }
                        else
                        {
                            Console.WriteLine("Объект удален");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Введите элемент для добавления: ");
                        myCollection.Add(new Country());
                        break;
                    case 5:
                        Console.WriteLine("Кол-во элементов: " + myCollection.Count);
                        break;
                    case 6:
                        Console.WriteLine("Введите элемент для поиска: ");
                        if (myCollection.Contains(new Country()) == -1)
                        {
                            Console.WriteLine("Элемент не найден");
                        }
                        else
                        {
                            Console.WriteLine("Элемент найден");
                        }
                        break;
                    case 7:
                        myCollection.Dispose();
                        myCollection = null;
                        Console.WriteLine("Список удален из памяти");
                        break;
                }
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            int option = -1;
            while (option != 0)
            {
                Console.Clear();
                Console.WriteLine("1) Однонаправленные списки.");
                Console.WriteLine("2) Двунаправленные списки.");
                Console.WriteLine("3) Дерево.");
                Console.WriteLine("4) Коллекция(двунаправленный список).");
                Console.WriteLine("0) Выход.");
                Console.WriteLine("Выберите опцию: ");
                option = Input.Int(0, 5);
                switch (option)
                {
                    case 0:
                        return;
                        break;
                    case 1:
                        Menu1();
                        break;
                    case 2:
                        Menu2();
                        break;
                    case 3:
                        Menu3();
                        break;
                    case 4:
                        Menu4();
                        break;
                }
            }

            MyCollection<int> myCol = new MyCollection<int>();
            myCol.Add(20);
            myCol.Add(10);
            myCol.Add(220);
            myCol.Add(250);
            myCol.Add(240);

            foreach(int i in myCol)
            {
                Console.WriteLine(i);
            }

            /*MyCollection<int> mycol = new MyCollection<int>();
            mycol.Add(10);
            mycol.Add(132312);
            foreach (int i in mycol)
                Console.WriteLine(i);*/
        }
    }
}
