using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public static class Input
    {
        public static int Int(int min, int max, string messageError = "Неверный ввод!")
        {
            int num = 0;
            while (!int.TryParse(Console.ReadLine(), out num) || num < min || num >= max)
            {
                Console.WriteLine(messageError);
            }
            return num;
        }
    }
}
