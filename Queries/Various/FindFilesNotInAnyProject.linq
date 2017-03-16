<Query Kind="Program" />

void Main()
{
	var sourceFolder = @"D:\Src\git\MySolutionFolder";
	
	var allCSharpFiles = 
		Directory.EnumerateFiles(sourceFolder, "*.cs", SearchOption.AllDirectories)
		.Where(d => !d.Contains(@"\obj"))
		.Where(d => !d.Contains(@"\bin"))
		.ToList();
	
	var allCSharpFilesInProjects = 
		Directory.EnumerateFiles(sourceFolder, "*.csproj", SearchOption.AllDirectories)
		.FindCSharpFilesInProjectFile()
		.ToList();
		
	allCSharpFiles.Except(allCSharpFilesInProjects)
		.Dump("C# files not in projects");
}

static class MyEntensions
{
	public static IEnumerable<string> FindCSharpFilesInProjectFile(
		this IEnumerable<string> projectPaths)
	{
		string xmlNamespace = "{http://schemas.microsoft.com/developer/msbuild/2003}";
		
		return from projectPath in projectPaths
			let xml = XDocument.Load(projectPath)
			let dir = Path.GetDirectoryName(projectPath)
			from c in xml.Descendants(xmlNamespace + "Compile")
			let inc = c.Attribute("Include").Value
			where inc.EndsWith("*.cs")
			select Path.Combine(dir, c.Attribute("Include").Value);
	}
}


