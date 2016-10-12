<Query Kind="Program" />

void Main()
{
	Expression<Func<int, bool>> test1 = i => i > 5;

	ConstantExpression constExp = Expression.Constant(5, typeof(int));
	
	ParameterExpression iParam = Expression.Parameter(typeof(int), "i");
	// Expression.Add(constExp, iParam);
	BinaryExpression greaterThan = Expression.GreaterThan(iParam, constExp);
	
	Expression<Func<int,bool>> test2 = 
		Expression.Lambda<Func<int,bool>>(greaterThan, iParam);
		
	Func<int, bool> myFunc = test2.Compile();
	
	Console.WriteLine(myFunc(3));
	Console.WriteLine(myFunc(8));
	
	//Properties of Expression
	//NodeType is the type of expression (see enum)
	
	//Type will be the literal type of the object
	
	//Value the actual value of a constant
	
	//Name the name of the parmeter
	
	//
}

// Define other methods and classes here
