using System.Collections.Generic;
using System.Linq;

namespace Lesson5
{
    public static class MyExtensions
    {
        public static int CharsInString(this string str, char ch)
        {
            int numberOfChars = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                {
                    numberOfChars++;
                }
            }
            return numberOfChars;
        }

        public static int QyantityOfElement<T>(this T self, List<T> col)
        {
            var selectedElements = from el in col
                                   where el.Equals(self)
                                   select el;
            
            int quantity = 0;
            foreach (var el in selectedElements)
            {
                quantity++;
            }
            return quantity;
        }
    }
}
