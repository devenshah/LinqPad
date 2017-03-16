<Query Kind="Program" />

void Main()
{
	var sourceFile = @"E:\Temp\20160218011111_ZJ047713.csv";
	
	GetNewFile(sourceFile, 300);
	
	return;
	
	var i = 100000;
    while (i < 250000)
	{
		string filename = $"XX{i}.rec";
		var targetFile = @"E:\Projects\LSS\Drop\" + filename;
		
		File.Copy(sourceFile, targetFile);
		i++;
    }
}

void GetNewFile(string filePath, int count)
{
	for (var number = 1; number <= count; number++)
	{
		var newFileName = filePath.Replace("713", number.ToString("000"));
		var content = File.ReadAllText(filePath);
		var newContent = content.Replace("~~", number.ToString());
		File.WriteAllText(newFileName, newContent);
	}
}