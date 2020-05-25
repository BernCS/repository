using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    public class Input
    {
        public static int Int(string message = "Введите число: ", int min = int.MinValue, int max = int.MaxValue, string messageError = "Неверный ввод!")
        {
            int number;

            Console.WriteLine(message);

            while (!int.TryParse(Console.ReadLine(), out number) || number < min || number >= max)
            {
                Console.WriteLine(messageError);
            }

            return number;
        }
    }
}
