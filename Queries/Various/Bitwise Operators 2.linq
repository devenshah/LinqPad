<Query Kind="Program" />

void Main()
{
    var x = 1;
    "Returns true if any one condition is true".Dump("Binary XOR ^ operator");
    (x > 0 ^ x > 5).Dump("TRUE as rhs is true and lhs is false");
    (x > 0 ^ x < 5).Dump("FALSE as both rhs and lhs are true");
    (x < 0 ^ x > 5).Dump("FALSE as both rhs and lhs are false");
    (x > 0 ^ x > 5 ^ x == 1).Dump("Can be used in more than two conditions as well");
}

// You can define other methods, fields, classes and namespaces here
