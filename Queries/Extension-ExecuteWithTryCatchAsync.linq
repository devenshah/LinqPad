<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//ExecuteWithTryCatch(() => ConvertToInt("sdfd"), ExceptionHandler);
	var i  = 0;
	if (someExtension.ExecuteWithTryCatch(
		async () => i = await GetInt("sdf"), ExceptionHandler))
	{
		Console.WriteLine("Value returned: " + i);
	}
	
	Func<Task> act = async () => i = await GetInt("12");
	if (act.ExecuteWithTryCatch(ExceptionHandler)) i.WL();
}

private async Task<int> GetInt(string value)
{
	return await Task.Run( () => 
	{
		var i = int.Parse(value);	
		//Console.WriteLine(i);
		return i;
	});
}

private void ExceptionHandler(Exception ex)
{
	Console.WriteLine("An Exception Occured");
	Console.WriteLine(ex);
}



public static class someExtension 
{
	
	public static async bool ExecuteWithTryCatch(this Func<Task> invocable, Action<Exception> exceptionHandler)
	{
		try
		{	        
			await invocable();
			return true;
		}
		catch (Exception ex)
		{
			exceptionHandler(ex);
			return false;
		}
	}

}

