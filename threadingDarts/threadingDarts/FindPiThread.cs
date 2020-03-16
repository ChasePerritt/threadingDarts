using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threadingDarts
{
    class FindPiThread
    {
        private int numDarts;
        private Random throwGen;
        private int hitCount;

        public FindPiThread(int nDart)
        {
            throwGen = new Random();    // A new random number generator instance is created for each thread.
            numDarts = nDart;           // The number of darts to throw is fed into the constructor.
            hitCount = 0;               // Before any darts are thrown, the number that have hit the board equals "0."
        }

        public int GetHitCount()
        {
            return hitCount;
        }

        public void throwDarts()
        {
            for (int i = 0; i < numDarts; i++)
            {
                double x = throwGen.NextDouble(); // Generates a random double between 0.0 and 1.0 to represent the x-value of the dart's position
                double y = throwGen.NextDouble(); // Generates a random double between 0.0 and 1.0 to represent the y-value of the dart's position

                if ((x * x) + (y * y) <= 1) hitCount += 1;  // If the hypotenuse of the right triangle (with x and y being the length of the
                                                            // triangle's legs) is less than or equal to 1, the dart lands within the circle.
            }
        }
    }
}
