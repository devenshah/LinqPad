<Query Kind="Program" />

void Main()
{
    var keywords = new[] {"child", "children", "child's", "childcare", "child-care", "child care", "caring for children", "child's care", "caring for children", "care", "carer", "caring", "cares", "carer's"};
    
    keywords.OrderBy(k => Guid.NewGuid()).Log();
}

// Define other methods and classes here
