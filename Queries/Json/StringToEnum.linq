<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
</Query>

void Main()
{
	var json = JsonSerializer.Serialize(new CalendarEvent("Online"));

	var model = JsonSerializer.Deserialize<CalendarEventModel>(json, new JsonSerializerOptions() { });
	
	model.Dump();
}

record CalendarEvent(string EventFormat);

class CalendarEventModel
{
	[System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
	public EventFormat EventFormat {get; set;}
}

enum EventFormat
{
	[Description("In person")]
	InPerson,
	Online,
	Hybrid
}
