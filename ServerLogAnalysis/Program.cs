using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLogAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> pageVisits = new Dictionary<string, List<string>>();
            Console.WriteLine("Server Log Entries:");
            string[] logEntries = System.IO.File.ReadAllLines("server_log.txt");
       
            foreach (string logEntry in logEntries) {
                Console.WriteLine($"\t{logEntry}");
            }
            foreach (string entry in logEntries)
            {
                string[] parts = entry.Split(',');
                string ipAddress = parts[0];
                string page = parts[1];
                if (!pageVisits.ContainsKey(page))
                {
                    pageVisits[page] = new List<string>();
                }
                pageVisits[page].Add(ipAddress);
            }
            Console.WriteLine("\nTotal Hits Per Page:");
            foreach (var page in pageVisits)
            {
                Console.WriteLine($"\t{page.Key}: {page.Value.Count} hits");
            }
            Console.WriteLine("\nUnique Visitors Per Page:");
            foreach (var page in pageVisits)
            {
                HashSet<string> uniqueVisitors = new HashSet<string>(page.Value);
                Console.WriteLine($"\t{page.Key}: {uniqueVisitors.Count} unique visitors");
            }
            string busiestPage = pageVisits.OrderByDescending(p => p.Value.Count).First().Key;
            Console.WriteLine($"\nBusiest Page: {busiestPage} with {pageVisits[busiestPage].Count} hits");
            Console.WriteLine($"\t{"=====Breakdown====="}");
            foreach (var page in pageVisits)
            {
                Console.WriteLine($"\t{page.Key + ": " + page.Value.Count + " hits"}");
            
            }

        }
    }
}

/*  metric 1: total hits per page 
    how many total; TimeoutExceptions eas each page visited
    metric 2: unique visitors. howm nay unique ip adddresses visited the page?
    metric 3: busiest page. which page was visitedthe most? 

    Server log 
192.168.1.1,/home
10.0.0.5,/products
192.168.1.1,/products
172.16.0.4,/home
10.0.0.5,/cart
192.168.1.1,/home
10.0.0.5,/products
144.12.0.1,/home
192.168.1.1,/cart
10.0.0.5,/home
203.177.15.1,/login
8.8.8.8,/home
192.168.1.2,/products
10.0.0.8,/support
192.168.1.1,/products
210.5.112.1,/home
112.200.1.1,/cart
10.0.0.5,/checkout
192.168.1.1,/home
203.177.15.1,/products
192.168.1.1,/home
10.0.0.5,/products
192.168.1.1,/products
172.16.0.4,/home
10.0.0.5,/cart
192.168.1.1,/home
10.0.0.5,/products
144.12.0.1,/home
192.168.1.1,/cart
10.0.0.5,/home
203.177.15.1,/products
8.8.8.8,/home
192.168.1.2,/products
10.0.0.8,/support
192.168.1.1,/checkout
210.5.112.1,/home
112.200.1.1,/cart
10.0.0.5,/checkout
192.168.1.1,/home
203.177.15.1,/login
192.168.1.1,/home
10.0.0.5,/products
192.168.1.1,/products
172.16.0.4,/home
10.0.0.5,/cart
192.168.1.1,/home
10.0.0.5,/products
144.12.0.1,/home
192.168.1.1,/cart
10.0.0.5,/home
203.177.15.1,/login
8.8.8.8,/home
192.168.1.2,/products
10.0.0.8,/support
192.168.1.1,/products
210.5.112.1,/home
112.200.1.1,/cart
10.0.0.5,/checkout
192.168.1.1,/home
203.177.15.1,/products
192.168.1.1,/home
10.0.0.5,/products
192.168.1.1,/products
172.16.0.4,/home
10.0.0.5,/cart
192.168.1.1,/home
10.0.0.5,/products
144.12.0.1,/home
192.168.1.1,/cart
10.0.0.5,/home
203.177.15.1,/login
8.8.8.8,/home
192.168.1.2,/products
10.0.0.8,/support
192.168.1.1,/checkout
210.5.112.1,/home
112.200.1.1,/cart
10.0.0.5,/checkout
192.168.1.1,/home
203.177.15.1,/products
192.168.1.1,/home
10.0.0.5,/products
192.168.1.1,/products
172.16.0.4,/home
10.0.0.5,/cart
192.168.1.1,/home
10.0.0.5,/products
144.12.0.1,/home
192.168.1.1,/cart
10.0.0.5,/home
203.177.15.1,/login
8.8.8.8,/home
192.168.1.2,/products
10.0.0.8,/support
192.168.1.1,/checkout
210.5.112.1,/home
112.200.1.1,/cart
10.0.0.5,/checkout
192.168.1.1,/home
203.177.15.1,/products
*/