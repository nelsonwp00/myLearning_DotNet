using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Concurrency
{
    internal class DictDemo
    {
        private ConcurrentDictionary<int, int> cd;

        public DictDemo() 
        {
            // We know how many items we want to insert into the ConcurrentDictionary.
            // So set the initial capacity to some prime number above that, to ensure that
            // the ConcurrentDictionary does not need to be resized while initializing it.
            int NUMITEMS = 64;
            int initialCapacity = 101; // next prime of 64 = 101

            // The higher the concurrencyLevel, the higher the theoretical number of operations
            // that could be performed concurrently on the ConcurrentDictionary.  However, global
            // operations like resizing the dictionary take longer as the concurrencyLevel rises.
            // For the purposes of this example, we'll compromise at numCores * 2.
            int numProcs = Environment.ProcessorCount;
            int concurrencyLevel = numProcs * 2;

            // Construct the dictionary with the desired concurrencyLevel and initialCapacity
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity);

            // Initialize the dictionary
            for (int i = 0; i < NUMITEMS; i++)
                cd.TryAdd(1, 1); // return true if key exists

            cd.TryGetValue(1, out int num); // return true if key exists
            cd.TryUpdate(1, 3, 2); // if V of K == 2, update V = 3. basically CAS

            // Enumeration is thread-safe in ConcurrentDictionary.
            foreach (var node in cd)
            {
                Console.WriteLine(node.Key + "-" + node.Value);
            }
        }
    }
}
