<Query Kind="Program" />

void Main()
{
	var measure = new Measure();
	decimal calculatedValue = measure.CalculateSavings();
}

public class ApplicationService
{
	public string GetApplicationSetting(string key)
	{
		// reads from application config file IO
		return "go for it";
	}
}

public class MeasureSubTypeService
{
	public MeasureSubType GetMeasureSubType(int id)
	{
		//hits database
		return new MeasureSubType();
	}
}

public class Measure
{
	public int MeasureId { get; set; }
	public int MeasureSubTypeId { get; set; }
	
	//... has 50 more properties
}

public class MeasureSubType
{
	public int MeasureSubTypeId { get; set; }
	public string Description { get; set; }
	public decimal? LifetimeYears { get; set; }	
}

public class MeasureService
{
	public Measure SaveMeasure()
	{
		return new Measure();
	}
}

public class Measure
{
	public int MeasureId { get; set; }
	public int? LifetimeYears { get; set; }
	public bool HasMeasureDetails {get; set; }
	public decimal? AnnualSavings {get; set; }
	
	
//self contained method with no visible dependencies
	public void CalculateSavings()
	{
		var subTypeSvc = new MeasureSubTypeService();
		var measureSubType = subTypeSvc.GetMeasureSubType(measure.MeasureSubTypeId);
		var lifetimeYears = this.LifetimeYears > 0 ? this.LifetimeYears : measureSubType.LifetimeYears;
		
		var applicationSvc = new ApplicationService(); //IO operation
		var toleranceRate = applicationSvc.GetApplicationSetting("SavingsTolerance");
		
		decimal calculatedResult = 0;
		//a complicated calculation goes on here.
		//which uses many properties that are in Measure object hierarchy
		//...
		this.AnnualSavings = calculatedResult;
		var measureService = new MeasureService();
		var newMesasure = measureService.SaveMeasure(this);		
	}
}

