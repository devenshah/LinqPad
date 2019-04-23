<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var tasks = new List<Task>();
    $"First: {DateTime.Now}".Dump();
    tasks.Add(GetTime(1));
    $"Second: {DateTime.Now}".Dump();
    tasks.Add(GetTime(2));
    $"Third: {DateTime.Now}".Dump();
    tasks.Add(GetTime(3));
    Task.WhenAll(tasks);
}

Random rnd = new Random();

private async Task GetTime(int a)
{    
    var loop = rnd.Next(1, 1000);
    await Task.Run(() => { for (var i = 0; i < loop; i++) Task.Delay(10);});
    $"{a}: {loop} - {DateTime.Now}".Dump();
}
