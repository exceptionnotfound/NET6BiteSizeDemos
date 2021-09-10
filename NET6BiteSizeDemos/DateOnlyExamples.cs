using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6BiteSizeDemos
{
    public class DateOnlyExamples
    {
        public void Examples()
        {
            Console.WriteLine("----------------------DateOnly Examples----------------------");

            //DateOnly is a struct that represents a date
            DateOnly sep10th = new DateOnly(2021, 9, 10);
            var dec31st = new DateOnly(1999, 12, 31);
            DateOnly aug3rd = new(1988, 8, 3);

            //We can create DateOnly instances from DateTime instances using DateOnly.FromDateTime
            //The time in the DateTime instance is not preserved.
            DateTime dateOnlyExample = new DateTime(2004, 5, 19, 4, 45, 30);
            DateOnly date3 = DateOnly.FromDateTime(dateOnlyExample); //May 19th, 2004

            //Outputting a DateOnly to the console shows the date using the current culture
            Console.WriteLine(dateOnlyExample); //American: 5/19/2004, European: 19/5/2004, Universal: 2004-05-19

            //Just like with DateTime, we can add days, months, and years to DateOnly instances
            dateOnlyExample = dateOnlyExample.AddYears(2).AddMonths(2).AddDays(5); //Jul 24th, 2006

            //TryParse also works with DateOnly
            if(DateOnly.TryParse("09/21/2013", out DateOnly result))
                Console.WriteLine(result); //American: 9/21/2013, European: 21/9/2013, Universal: 2013-09-21

            //Internally, DateOnly stores its value as an integer (DayNumber), where 0 is January 1 0001.
            //We can convert an integer to a DateOnly value
            DateOnly integerTest = new(2019, 7, 1); //July 1st 2019
            int dayNumber = integerTest.DayNumber;
            DateOnly integerResult = DateOnly.FromDayNumber(dayNumber); //July 1st 2019
        }
    }
}
