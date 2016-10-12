<Query Kind="Program">
  <GACReference>System.ComponentModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
  <Namespace>System.ComponentModel</Namespace>
</Query>

public enum MeasureFileStatus: int
    {
        Held = 1,
        Pending = 2,
        Active = 3,
        Complete = 4,
        [Description("Complete with Errors")]
        CompleteWithErrors = 5,
        Failed = 6,
        Importing = 7,
        Validating = 8,
        [Description("Complete with Warnings")]
        CompleteWithWarnings = 9
    } 

void Main()
{
	var list = new List<dynamic>();
	foreach (var value in Enum.GetValues(typeof(MeasureFileStatus)))
	{	
		var name = value.ToString();
		var number = Enum.Parse(typeof(MeasureFileStatus), name);
		var desc = value.GetDescription();
		dynamic keyValue = new { Id = (int)number, Code = value.ToString(), Desc = desc };
		list.Add(keyValue);
	}
	list.Dump();
}
public static class Extensions
{
	public static string GetDescription<T>(this T source)
	{
	FieldInfo fi = source.GetType().GetField(source.ToString());
	
	DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
		typeof(DescriptionAttribute), false);
	
	if (attributes != null && attributes.Length > 0) return attributes[0].Description;
	else return source.ToString();
	}
}
// Define other methods and classes here
