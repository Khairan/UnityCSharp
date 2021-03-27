using System;
using System.Collections.Generic;
using System.Linq;


//Задание №3
//Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
//для целых чисел; *для обобщенной коллекции; **используя Linq
namespace Lesson5
{
    public class Task3
    {
        public void Main()
        {
            List<int> list = new List<int> { 20, 1, 4, 20, 9, 4 };
            list.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();

            var distinctList = list.Distinct();
            foreach (var item in distinctList)
            {
                int quantity = item.QyantityOfElement(list);
                Console.WriteLine($"Количество элемента {item} в коллекции = {quantity}");
            }
            Console.ReadKey();
        }
    }
}