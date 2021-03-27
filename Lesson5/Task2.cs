using System;


//Задание №2
//Реализовать метод расширения для поиска количество символов в строке
namespace Lesson5
{
    public class Task2
    {
        public void Main()
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();

            char ch;
            Console.WriteLine("Введите символ для поиска: ");
            while (!char.TryParse(Console.ReadLine(), out ch))
            {
                Console.WriteLine("Нужно ввести один символ: ");
            }

            Console.WriteLine($"Количество символов {ch} в строке = {str.CharsInString(ch)}");
            Console.ReadKey();
        }
    }
}