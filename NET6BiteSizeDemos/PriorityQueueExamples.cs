using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6BiteSizeDemos
{
    public class PriorityQueueExamples
    {
        public void Examples()
        {
            Console.WriteLine("--------------------PriorityQueue<T,N> Examples--------------------");

            //In .NET, a Queue<T> is a structure that implements first-in, first-out (FIFO) behavior.
            //Objects are removed from the queue in the order they were added to it.

            var myWords = new Queue<string>();

            myWords.Enqueue("First");
            myWords.Enqueue("Second");
            myWords.Enqueue("Third");

            Console.WriteLine(myWords.Dequeue()); //First
            Console.WriteLine(myWords.Dequeue()); //Second
            Console.WriteLine(myWords.Dequeue()); //Third

            //.NET 6 introduces a new class, PriorityQueue<T, N>, where the order of the elements is determined by a 
            //priority value which is given when an item is enqueued.
            PriorityQueue<string, int> priorityWords = new();
            priorityWords.Enqueue("Second", 2);
            priorityWords.Enqueue("Fourth", 4);
            priorityWords.Enqueue("Third", 3);
            priorityWords.Enqueue("First", 1);

            Console.WriteLine(priorityWords.Dequeue()); //First
            Console.WriteLine(priorityWords.Dequeue()); //Second
            Console.WriteLine(priorityWords.Dequeue()); //Third
            Console.WriteLine(priorityWords.Dequeue()); //Fourth

            //In a PriorityQueue, the priority value can be any primitive type.
            //For example, we could use the enum ShowRating (defined below) to rank some TV shows.

            var tvShows = new PriorityQueue<string, ShowRating>();

            tvShows.Enqueue("Modern Family", ShowRating.Good);
            tvShows.Enqueue("Ted Lasso", ShowRating.Amazing);
            tvShows.Enqueue("MasterChef", ShowRating.Good);
            tvShows.Enqueue("Breaking Bad", ShowRating.Transcendant);
            tvShows.Enqueue("Happy Endings", ShowRating.Amazing);
            tvShows.Enqueue("Game of Thrones (Seasons 1-6)", ShowRating.Amazing);
            tvShows.Enqueue("Game of Thrones (Seasons 7-8)", ShowRating.OK);
            tvShows.Enqueue("How to Get Away with Murder", ShowRating.Good);
            tvShows.Enqueue("Hell's Kitchen", ShowRating.OK);

            Console.WriteLine("What should we watch?");
            var currentShow = tvShows.Dequeue();

            //The shows will be dequeued in order of the ShowRating value
            Console.WriteLine($"Let's try {currentShow}!");

            while(tvShows.Count > 0)
            {
                Console.WriteLine($"If not, let's try {tvShows.Dequeue()}.");
            }

            //Output: 
        }
    }

    public enum ShowRating
    {
        Transcendant,
        Amazing,
        Good,
        OK
    }
}
