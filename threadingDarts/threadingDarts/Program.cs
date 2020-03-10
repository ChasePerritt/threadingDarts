using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threadingDarts
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int dartCount, threadCount;

            Console.WriteLine("How many darts should the user throw?");
            userInput = Console.ReadLine();
            dartCount = Convert.ToInt32(userInput);

            Console.WriteLine("How many threads should be run?");
            userInput = Console.ReadLine();
            threadCount = Convert.ToInt32(userInput);

            List<System.Threading.Thread> threadList = new List<System.Threading.Thread>(threadCount);  // Creates a list of threads
            List<FindPiThread> piThreadList = new List<FindPiThread>(threadCount);                      // Creates a list of classes for each thread to operate upon


        }
    }
}
