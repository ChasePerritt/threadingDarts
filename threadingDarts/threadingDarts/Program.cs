using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

            List<Thread> threadList = new List<Thread>(threadCount);                // Creates a list of threads
            List<FindPiThread> piThreadList = new List<FindPiThread>(threadCount);  // Creates a list of classes for each thread to operate upon

            // Both lists have a capacity equal to the user-specified threadCount integer

            for (int i = 0; i < threadCount; i++)
            {
                FindPiThread fpt = new FindPiThread(dartCount);
                piThreadList.Add(fpt);
                Thread thr = new Thread(new ThreadStart(piThreadList[i].throwDarts));
                threadList.Add(thr);

                thr.Start();

                Thread.Sleep(16);
            }

            for (int i = 0; i < threadCount; i++)
            {
                threadList[i].Join(); // This tells Main() to wait until every thread is done before continuing
            }

            int totalHitCount = 0;

            for (int i = 0; i < threadCount; i++)
            {
                totalHitCount += piThreadList[i].GetHitCount();
            }

            Console.Write("For " + (dartCount * threadCount) + " darts, pi is evaluated as: ");
            Console.WriteLine( 4 * ( totalHitCount / ( dartCount * threadCount )));

            Console.ReadKey();
        }
    }
}
