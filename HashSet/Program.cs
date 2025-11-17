using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string>People = new Dictionary< string, string>();
            People.Add("President", "Aquino");
            People.Add("Vice President", "Robredo");
            People.Add("Senator", "De Lima");  
            string first = People[0];


            List<String> list = new List<string>()
            {
                "One",
                "Two",
                "Three",
                "One",
                "Two",
                "Three"
            };

            HashSet<string> hashSet = new HashSet<string>(list);
            foreach (string number in hashSet)
            {
                Console.WriteLine(number);
            }
        }
    }
}

/*metric 1: total hits per page 
how many total; TimeoutExceptions eas each page visited
    metric 2: unique visitors. howm nay unique ip adddresses visited the page?
    metric 3: busiest page. which page was visitedthe most? 
*/