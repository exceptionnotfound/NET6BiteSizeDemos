using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6BiteSizeDemos
{
    public class LINQRangeParamsExamples
    {
        public void Examples()
        {
            Console.WriteLine("----------------------LINQ Range Parameters Examples----------------------");

            //Say we have the following collection of numbers
            List<int> numbers = new List<int> { 6, 8, 1, 5, 19, 5, 2, 11 };

            //We can get a range of results by using a new Take() overload
            var range = numbers.Take(new Range(1, 5)); //8, 1, 5, 19

            //For more intricate scenarios, we could skip the first few elements, the take a range of the remaining ones.
            var otherRange = numbers.Skip(2).Take(new Range(1, 5)); //5, 19, 5, 2 (skipped 6 and 8 and range does not include 1 or 11)

            //We can also use an overload of ElementAt() to take an Index, which
            //allows us to get elements at a position calculate from the *end* of the collection,
            //rather than the beginning.
            var number5 = numbers.ElementAt(new Index(3, fromEnd: true)); //3rd element from the end (value 5)
        }
    }
}
