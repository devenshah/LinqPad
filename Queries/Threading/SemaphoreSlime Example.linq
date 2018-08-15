<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var range = Enumerable.Range(1, 30);

    var ss = new SemaphoreSlim(1,3);
    var r = new Random();

    Parallel.ForEach(range, async (i) => {
        var milliseconds = Convert.ToInt32(r.NextDouble() * 5000);
        await ss.WaitAsync();
        try
        {	        
            "Entered thread...".Log();
            Task.Delay(milliseconds).Wait();
            $"Task {i} waited for {milliseconds} ms".Log();
        }
        finally
        {
            ss.Release();
            "Exit thread...".Log();
        }                
    });
}

// Define other methods and classes here
