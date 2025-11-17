using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetServerLogAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server Log Entries:");
            string[] logEntries = System.IO.File.ReadAllLines("server_log.txt");
            foreach (string logEntry in logEntries)
            {
                Console.WriteLine($"\t{logEntry}");
            }
            Dictionary<string, List<string>> pageVisits = new Dictionary<string, List<string>>();
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

            
        }
    }
}
