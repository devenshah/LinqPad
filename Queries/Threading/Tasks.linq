<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    Task.Run(() =>
    {
        var tasks = new List<Task> {
            new Task(() => Task1()),
            new Task(() => Task2())
        };
        "Starting  tasks".Log();
        tasks.ForEach(t => t.Start());
        Task.WaitAll(tasks.ToArray());
    }).Wait();
    "end".Log();
}


async Task Task1() {
    "1 Started".Log();
    await Task.Delay(TimeSpan.FromSeconds(1));
    throw new Exception("fart");
}

async Task Task2() {
    "2 Started".Log();
    await Task.Delay(TimeSpan.FromSeconds(3));
    "2 Completed".Log();
}