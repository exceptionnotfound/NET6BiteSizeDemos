using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6BiteSizeDemos
{
    public class TimeOnlyExamples
    {
        public void Examples()
        {
            Console.WriteLine("----------------------TimeOnly Examples----------------------");

            //TimeOnly stores a time of day without a date
            TimeOnly nineThirtyPM = new TimeOnly(21, 30); //21:30, or 9:30 PM
            TimeOnly fourTwentyThreeAM = new(4, 23, 19); //04:23:19, or 4:23:19 AM

            //We can get TimeOnly instances from DateTime using TimeOnly.FromDateTime
            DateTime sevenFortyFiveDT = new DateTime(2011, 11, 11, 7, 45, 00);
            TimeOnly sevenFortyFive = TimeOnly.FromDateTime(sevenFortyFiveDT); //07:45 AM

            //Internally, TimeOnly stores its value as a long,
            //which is the number of ticks (1 tick = 100 nanoseconds) since midnight
            TimeOnly sixTen = new TimeOnly(6, 10);
            long ticks = sixTen.Ticks;
            TimeOnly sixTenAgain = new TimeOnly(ticks);

            //We can perform math operations on two TimeOnly instances,
            //which results in a TimeSpan instance
            var afternoon = new TimeOnly(15, 15); //3:15 PM
            var morning = new TimeOnly(9, 10); //9:10 AN
            TimeSpan difference = afternoon - morning; //6 hours 5 minutes

            //We can also check if a particular TimeOnly instance
            //occurs in a specific time range
            var now = TimeOnly.FromDateTime(DateTime.Now);
            var nineAM = new TimeOnly(9, 0);
            var fivePM = new TimeOnly(15, 0);

            if(now.IsBetween(nineAM, fivePM))
                Console.WriteLine("Work time!");
            else
                Console.WriteLine("Anything other than work time!");

            //We can check for ranges that go across midnight
            var tenPM = new TimeOnly(22, 0);
            var twoAM = new TimeOnly(2, 0);

            var midnight = new TimeOnly(0); //0 ticks == midnight

            if(midnight.IsBetween(tenPM, twoAM))
                Console.WriteLine("It's getting late...");

            //We can even use comparison operators (e.g. < and >) to compare TimeOnly instances
            TimeOnly noon = new(12, 0);
            if (now < noon)
                Console.WriteLine("Morning");
        }
    }
}
