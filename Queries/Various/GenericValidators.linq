<Query Kind="Program" />

void Main()
{
	var request = new WallUValueRequest()
	{
		AgeBand= "a",
		Country = "",
//		ConstructionType="solid brick",
//		InsulationType="internal",
//		InsulationThickness="150",
		WallThickness=0,
	};
	HasAtLeastTwoValues(request).Dump();
}

private bool HasAtLeastTwoValues(object request)
{
	var count = 0;
	foreach(var property in request.GetType().GetProperties())
	{
		property.Name.Dump();
		var value = property.GetValue(request);
		if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
			count++;
	}
	return count > 1;
}

// Define other methods and classes here
public class WallUValueRequest
    {
        public string Country { get; set; }
        public string AgeBand { get; set; }
        public string ConstructionType { get; set; }
        public string InsulationType { get; set; }
        public string InsulationThickness { get; set; }
        public decimal? WallThickness { get; set; }
    }