using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6BiteSizeDemos
{
    public class LINQSetByExamples
    {
        public void Examples()
        {
            Console.WriteLine("----------------------LINQ MaxBy/MinBy Examples----------------------");

            //Say we have the following collection of Users, created in the GetUserList method below.
            List<User> users = GetUserList();

            //We can use the MaxBy() method to select the maximum of values that match a specific selector function.
            //For example, we could get the youngest user in the set
            var youngestPerson = users.MaxBy(x => x.DateOfBirth.Year); //Hailee Escobar

            //Similarly, we can use Where and MaxBy to get the youngest person born before 1995.
            var youngestBornBefore1995 = users.Where(x=>x.DateOfBirth.Year < 1995).MaxBy(x => x.DateOfBirth.Year); //Terrance Johnson

            //We could also find the first person alphabetically by last name
            var firstPersonAlphaByLastName = users.MinBy(x => x.LastName); //Jackson Browne

            //The By methods also come in handy when dealing with sets. Let's get a second set of people
            //and combine it, it in different ways, with the first set.
            var users2 = GetUserList2();

            //UnionBy gets the union of two sets, where items in the union have distinct values for the specified selector
            //In this example, we get 6 users in the union
            //Two users (Jeremy and Toni) get excluded, because they have the same birth year as other users
            var unionBirthYear = users.UnionBy(users2, x => x.DateOfBirth.Year);

            //IntersectBy gets the people from each set that do not have a matching birth year in the opposite set
            //In this case, there will be four people who do not share a birth year with someone in the opposite set
            var intersectionBirthYear = users.IntersectBy(users2.Select(x => x.DateOfBirth.Year), x => x.DateOfBirth.Year);

            users.AddRange(users2);

            //DistinctBy returns all objects that have a distinct value for the specified key selector.
            //We can use DistinctBy to find the first person with each distinct birth date
            //Since Hailee Escobar and Toni Berkowitz have the same birth date, Toni will not be included in the result.
            var usersWithDistinctBirthDates = users.DistinctBy(x => x.DateOfBirth);

            //ExceptBy gets all matching objects except those which are specified in another collection of values.
            //For example, we can use ExceptBy to return all users who do not have any of a set of first names.
            var names = new List<string>() { "Hailee", "Jackson", "Jeremy" };
            var exceptByFirstName = users.ExceptBy(names, x => x.FirstName);

            var intersectionBirthYearReverse = users2.IntersectBy(users.Select(x => x.DateOfBirth.Year), x => x.DateOfBirth.Year);
        }

    private List<User> GetUserList()
    {
        return new List<User>()
        {
            new User()
            {
                ID = 1,
                FirstName = "Terrance",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1985, 12, 6)
            },
            new User()
            {
                ID = 2,
                FirstName = "Angelica",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1984, 8, 22)
            },
            new User()
            {
                ID = 3,
                FirstName = "Jackson",
                LastName = "Browne",
                DateOfBirth = new DateTime(2001, 7, 29)
            },
            new User()
            {
                ID = 4,
                FirstName = "Hailee",
                LastName = "Escobar",
                DateOfBirth = new DateTime(2004, 1, 16)
            }
        };
    }

    private List<User> GetUserList2()
    {
        return new List<User>()
        {
            new User()
            {
                ID = 1,
                FirstName = "Jeremy",
                LastName = "Yardling",
                DateOfBirth = new DateTime(2001, 6, 1)
            },
            new User()
            {
                ID = 2,
                FirstName = "Toni",
                LastName = "Berkowitz",
                DateOfBirth = new DateTime(2004, 1, 16)
            },
            new User()
            {
                ID = 3,
                FirstName = "Vanessa",
                LastName = "Warren",
                DateOfBirth = new DateTime(1975, 10, 11)
            },
            new User()
            {
                ID = 4,
                FirstName = "Lawrence",
                LastName = "Neilson",
                DateOfBirth = new DateTime(1966, 9, 30)
            }
        };
    }
    }

public class User
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}
}
