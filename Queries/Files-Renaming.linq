<Query Kind="Program" />

void Main()
{
	var path = @"I:\";
	var searchString = "[Songs.PK]";
	var replaceString = string.Empty;
	
	var dir = new DirectoryInfo(path);
	var files = dir.GetFiles("*" + searchCriteria + "*");
	
	foreach (var file in files)
	{
		var fileName = file.Name;
		var newName = file.Name.Replace(searchString, replaceString).Trim();		
		try
		{
			file.MoveTo(path + newName);		
			Console.WriteLine(string.Format("Move file '{0}' to '{1}'", fileName, newName));
		}
		catch(IOException ex)
		{
			Console.WriteLine(string.Format("Unable to move file '{0}'", fileName));
			Console.WriteLine(ex.StackTrace);
		}
	}
}

// Define other methods and classes here
