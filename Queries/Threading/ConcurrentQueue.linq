<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

void Main()
{
    TestConcurrentQueue().Wait();
}

HttpClient _client = new HttpClient();

private string[] _urls = new[] {
        "https://github.com/naudio/NAudio",
        "https://twitter.com/mark_heath",
        "https://github.com/markheath/azure-functions-links",
        "https://pluralsight.com/authors/mark-heath",
        "https://github.com/markheath/advent-of-code-js",
        "http://stackoverflow.com/users/7532/mark-heath",
        "https://mvp.microsoft.com/en-us/mvp/Mark%20%20Heath-5002551",
        "https://github.com/markheath/func-todo-backend",
        "https://github.com/markheath/typescript-tetris",
};

private async Task TestConcurrentQueue()
{
    var maxThreads = 4;
    var q = new ConcurrentQueue<string>(_urls);
    var tasks = new List<Task>();
    for (int n = 0; n < maxThreads; n++)
    {
        tasks.Add(Task.Run(async () =>
        {
            while (q.TryDequeue(out string url))
            {
                var html = await _client.GetStringAsync(url);
                Console.WriteLine($"retrieved {html.Length} characters from {url}");
            }
        }));
    }
    await Task.WhenAll(tasks);
}

// Define other methods and classes here
