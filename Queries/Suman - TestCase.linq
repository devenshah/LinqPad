<Query Kind="Program" />

void Main()
{
	WhenWeightIsLessThanTwo();
}

//Test case
void WhenWeightIsLessThanTwo()
{
	var inputWeight = 1.3m; 
	var expectedPrice = 2.95m; //Test condition
	var returnPrice = CalculatePostage(inputWeight);
	var message = expectedPrice == returnPrice ? "Success" : "Failure";
	message.Dump();
}

decimal CalculatePostage ( decimal weightInKgs )
{
	var returnPrice = 0m;
	if (weightInKgs < 2m)
		returnPrice = 2.95m;
	else if( (weightInKgs >= 2m) && (weightInKgs < 5m))
		returnPrice = 3.95m;
	else
		returnPrice = 5m;
		
	return returnPrice;
}

