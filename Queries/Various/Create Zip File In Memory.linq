<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.IO.Compression</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var jsonData = @"[{'name':'Pumbaa','type':'Warthog'},{'name':'Timon','type':'Meerkat'}]";
	var data = ExtractData<Character>(GetZipFile(jsonData)).Result;
	data.Dump();
}

private Stream GetZipFile(string json)
{
	var memoryStream = new MemoryStream();
	using var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true);

	var demoFile = archive.CreateEntry("foo.txt");

	using (var entryStream = demoFile.Open())
	using (var streamWriter = new StreamWriter(entryStream))
	{
		streamWriter.Write(json);
	}
	return memoryStream;
}

public async Task<List<T>> ExtractData<T>(Stream zipFile)
{
	using var archive = new ZipArchive(zipFile, ZipArchiveMode.Read);
	var zipEntry = archive.Entries.FirstOrDefault();

	var reader = new StreamReader(zipEntry.Open());
	var json = await reader.ReadToEndAsync();
	var result = JsonConvert.DeserializeObject<List<T>>(json);

	return result;
}

internal class Character
{
	public string Name { get; set; }
	public string Type { get; set; }
}