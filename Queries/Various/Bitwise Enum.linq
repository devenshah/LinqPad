<Query Kind="Program" />

void Main()
{
    int i = 3;
    (i << 3).Dump();
    Convert.ToInt32("00011000",2).Dump();
    ((int)EType.All).Dump();
}

[Flags]
enum EType
{
    None = 0,
    Levy = 1,
    NonLevy = 1 << 1,
    All = ~None,
    Both = Levy | NonLevy
}

// Define other methods and classes here
