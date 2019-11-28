<Query Kind="Program" />

void Main()
{
    var days = Days.Monday | Days.Friday;
    
    ((days & Days.Monday) == Days.Monday).Dump("expected true for Monday");
    ((days & Days.Friday) == Days.Friday).Dump("expected true for Friday");
    ((days & Days.Sunday) == Days.Sunday).Dump("expected false for Sunday");
    
    days = days | Days.Sunday; //Add flag
    ((days & Days.Sunday) == Days.Sunday).Dump("expected true for Sunday");
    days.HasFlag(Days.Sunday).Dump("expected true for Sunday");
    
    days = days ^ Days.Monday; //Remove flag
    ((days & Days.Monday) == Days.Monday).Dump("expected false for Monday");
    
    days = days ^ Days.Sunday;
    days = days ^ Days.Friday;
    
    ((days & Days.None) == Days.None).Dump("No flags should be true");
    (days == Days.None).Dump("No flags should be true"); //same effect as above
    
    days.Dump();
    days = Days.Monday | Days.Tuesday;
    var mask = ~Days.Monday; //inverts
    days = days & mask;
    days.Dump();
    
    days = AddDays(false, true, true);
    days.Dump();
    
    (Days.Friday > Days.None).Dump("Friday is greater than none");
    (Days.Friday > Days.Saturday).Dump("Firday is greater than saturday");
    (Days.Friday > Days.Thursday).Dump("Firday is greater than thursday");
    
    
}

Days AddDays(bool addSunday, bool addMonday, bool addSaturday)
{
    return (addSunday ? Days.Sunday : Days.None) | (addMonday ? Days.Monday : Days.None) | (addSaturday ? Days.Saturday : Days.None);
}

[Flags]
enum Days
{
    None = 0x0,
    Sunday = 0x1,
    Monday = 0x2,
    Tuesday = 0x4,
    Wednesday = 0x8,
    Thursday = 0x10,
    Friday = 0x20,
    Saturday = 0x40
}