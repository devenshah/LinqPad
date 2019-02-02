<Query Kind="Program" />

void Main()
{
    /*
       128 64 32 16 8 4 2 1
       0   0  0  0  1 0 1 0 = 10
       1   0  0  1  0 0 1 1 = 147
    &: 0   0  0  0  0 0 1 0 = 2     Both should have the value, 1 & 1 = 1 else 0
    |: 1   0  0  1  1 0 1 1 = 155   Anyone should have the value, 1 & 0 = 1 1 & 1 = 1 else 0
    ^: 1   0  0  1  1 0 0 1 = 153   Where values don't exist in both, 0 & 1 = 1 else 0
    */
    
    var val1 = 10; 
    var val2 = 147;
    
    var val1_AND_val2 = val1 & val2;
    $"{val1} & {val2}: Binary: {Convert.ToString(val1_AND_val2, 2)} Acutal: {val1_AND_val2}".Dump();
    
    var val1_OR_val2 = val1 | val2;    
    $"{val1} | {val2}: Binary: {Convert.ToString(val1_OR_val2, 2)} Acutal: {val1_OR_val2}".Dump();

    var val1_XOR_val2 = val1 ^ val2;
    $"{val1} | {val2}: Binary: {Convert.ToString(val1_XOR_val2, 2)} Acutal: {val1_XOR_val2}".Dump();
}


void PrintBinaryAndActualValue()
{
    for (int i = 1; i < 8; i++)
    {
        var v = 1 << i;
        Convert.ToString(v, 2).Dump();
        Convert.ToInt16(v).Dump();
    }
}