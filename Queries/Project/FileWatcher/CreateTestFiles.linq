<Query Kind="Statements">
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var tempFolder = Path.GetDirectoryName(Util.CurrentQueryPath);
var outputPath = Path.Combine(@"D:\Temp\FileWatcher", "output");
if (Directory.Exists(outputPath)) Directory.Delete(outputPath, true);

Directory.CreateDirectory(outputPath);
var sampleFilePath = Path.Combine(outputPath, "sample.csv");
using (var fileStream = File.Create(sampleFilePath))
{
	var contents = "6, Dewsbury, Oakridge Park, Milton Keynes, MK14 6FW, Semi-Detached, Brick Wall, Tiled Roof, " + DateTime.Today.ToString();
	var bytes = new UTF8Encoding().GetBytes(contents);
	fileStream.Write(bytes, 0, bytes.Length);
}

Parallel.For(100000, 200000, i =>
	{
		string filename = $"ZZ{i}.csv";
		var targetFile = Path.Combine(outputPath, filename);
		File.Copy(sampleFilePath, targetFile);
		i++;
	});

//var i = 100000;
//while (i < 250000)
//{
//	string filename = $"ZZ{i}.csv";
//	var targetFile = Path.Combine(outputPath, filename);
//	File.Copy(sampleFilePath, targetFile);
//	i++;
//}
//