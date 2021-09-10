using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6BiteSizeDemos
{
    public class LINQChunkExamples
    {
        public void Examples()
        {
            Console.WriteLine("----------------------LINQ Chunk() Examples----------------------");

            //Say we have a big list of numbers
            List<int> numbers = new();

            int counter = 0;
            Random rand = new(DateTime.Now.Millisecond);
            while(counter < 100)
            {
                numbers.Add(rand.Next(1, 1000));
                counter++;
            }

            //We might want to subdivide that list into smaller collections, and then perform statistics
            //(e.g. means and medians) on each smaller collection.

            //In previous versions of .NET, if we wanted to split a List<T> into smaller sublists,
            //we were limited to methods like Take() and Skip().
            var sublist1 = numbers.Take(10);
            var sublist2 = numbers.Skip(10).Take(10);
            var sublist3 = numbers.Skip(20).Take(10);
            var sublist4 = numbers.Skip(30).Take(10);
            //... and so on

            //.NET 6 provides us a way to automatically create a bunch of sublists from a larger list, using the method Chunk()
            //The method returns an IEnumerable<int[]>, or a collection of collections.
            IEnumerable<int[]> sublists = numbers.Chunk(10);

            //Now, if we want to, say, get the average of the 6th collection, it's really easy to do so.
            Console.WriteLine("The average of the sixth collection is " + sublists.ElementAt(6).Average() + ". This number will be different every time you run the app.");
        }
    }
}
