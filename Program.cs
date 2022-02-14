using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] doors = new bool[100];

            for (int d = 0; d < 100; d++) doors[d] = false;

            for (int p = 0; p < 100; p++)
            {
                for (int d = 0; d < 100; d++)
                {
                    if ((d + 1) % (p + 1) == 0)
                    {
                        doors[d] = !doors[d];
                    }
                }
            }

            Console.WriteLine("Passes Completed!!!  Here are the results: \r\n");
            for (int d = 0; d < 100; d++)
            {
                if (doors[d])
                {
                    Console.WriteLine(String.Format("Door #{0}: Open", d + 1));
                }
                else
                {
                    Console.WriteLine(String.Format("Door #{0}: Closed", d + 1));
                }
            }
            Console.ReadKey(true);
        }
    }
}
