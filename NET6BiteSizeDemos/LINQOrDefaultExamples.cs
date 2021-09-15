namespace NET6BiteSizeDemos
{
    public class LINQOrDefaultExamples
    {
        public void Examples()
        {
            Console.WriteLine("----------------------LINQ 'OrDefault' Methods Examples----------------------");

            //Say we have the following collection of numbers
            List<int> numbers = new List<int> { 6, 8, 1, 5, 19, 5, 2, 11 };

            //Now say we want to select a single number that is greater than 20.
            //We can use SingleOrDefault for this.
            var singleNumber = numbers.SingleOrDefault(x => x > 20);

            //But the collection doesn't have *any* numbers > 20, so what gets returned?
            //The default value of the collection's type, e.g. the default value for int: zero.
            Console.WriteLine($"A number greater than 20: {singleNumber}"); //A number greater than 20: 0

            //But what if we wanted to return -1 instead of 0? .NET 5 and earlier provided no native way to do that.
            //In .NET 6, we can specify the value to return in any "OrDefault" LINQ method.
            Console.WriteLine($"A number greater than 20: {numbers.SingleOrDefault(x => x > 20, -1)}");

            //We can also do this with FirstOrDefault or LastOrDefault
            List<int> otherNumbers = new();
            Console.WriteLine($"The first number in the collection is {otherNumbers.FirstOrDefault(-1)}");
            Console.WriteLine($"The last number in the collection is {otherNumbers.LastOrDefault(-1)}");
            
        }
    }
}
