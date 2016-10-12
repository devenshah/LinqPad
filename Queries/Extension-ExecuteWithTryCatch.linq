<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//ExecuteWithTryCatch(() => ConvertToInt("sdfd"), ExceptionHandler);
	var i  = 0;
	if (someExtension.ExecuteWithTryCatch(() => i = GetInt("sdf"), ExceptionHandler))
	{
		Console.WriteLine("Value returned: " + i);
	}
	
	Action act = () => i = GetInt("12");
	if (act.ExecuteWithTryCatch(ExceptionHandler)) i.WL();
}

private int GetInt(string value)
{
	var i = int.Parse(value);	
	//Console.WriteLine(i);
	return i;
}

private void ExceptionHandler(Exception ex)
{
	Console.WriteLine("An Exception Occured");
	Console.WriteLine(ex);
}



public static class someExtension 
{
	
	public static bool ExecuteWithTryCatch(this Action invocable, Action<Exception> exceptionHandler)
	{
		try
		{	        
			invocable();
			return true;
		}
		catch (Exception ex)
		{
			exceptionHandler(ex);
			return false;
		}
	}

}