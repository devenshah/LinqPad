<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var locker = new Object();
    int count = 0;
    var maxDegree = Environment.ProcessorCount * 10; //limits number of threads that can spawn at any given point in time
    maxDegree.Log();
    Parallel.For
        (0
         , 1000
         , new ParallelOptions { MaxDegreeOfParallelism = maxDegree }
         , (i) =>
               {
                   Interlocked.Increment(ref count);
                   lock (locker)
                   {
                       Console.WriteLine("Number of active threads:" + count);
                       Thread.Sleep(10);
                   }
                   Interlocked.Decrement(ref count);
               }
        );
}

// Define other methods and classes here
