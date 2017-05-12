<Query Kind="Program" />

void Main()
{
	var n = 36;
	var p = 1000;
	var annualRate = 0.07d;
	var j = annualRate / 12d;
	j.Dump("Effective Rate");		
	
	(p * (j / (1 - Math.Pow(1 + j,-n)))).Dump("Monthly Payment");
	((p * (j / (1 - Math.Pow(1 + j,-n)))) * 36).Dump("Total Payment");
}

//http://www.wikihow.com/Calculate-Loan-Payments
/*


The formula to use when calculating loan payments is M = P * ( J / (1 - (1 + J)-N)). 
Note: -N is power of 1 + J. J = Annual Percent / 12.
M = payment amount
P = principal, meaning the amount of money borrowed
J = effective interest rate. Note that this is usually not the annual interest rate; see below for an explanation.
N = total number of payments

*/