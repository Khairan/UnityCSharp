using System;
using System.Collections.Generic;
using System.Linq;


//Задание №4
//*Дан фрагмент программы:
//Свернуть обращение к OrderBy с использованием лямбда-выражения =>
namespace Lesson5
{
    public class Task4
    {
        public static void Main()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
            };

            var d = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            Console.ReadKey();
        }
    }
}
