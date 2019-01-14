<Query Kind="Program" />

void Main()
{
    var setO = new SetOutcome();
    for(var i = 1; i < 3; i++)
    {
        var ro = new RuleOutcome();
        ro.Narrative = $"outer {i}";
        for (var j=1; j<4; j++)
        {
            var roi = new RuleOutcome();
            roi.Narrative = $"outer {i} inner {j}";
            ro.Details.Add(roi);
        }
        setO.Outcomes.Add(ro);
    }
    
    
    setO.Outcomes.SelectMany(o => o.Details).Dump();
    
    
}

public class SetOutcome
{
    public List<RuleOutcome> Outcomes { get; set; } = new List<RuleOutcome>();
}

public class RuleOutcome
{
    public List<RuleOutcome> Details { get; set; } = new List<RuleOutcome>();
    public string Narrative { get; set; }
}