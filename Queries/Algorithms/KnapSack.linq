<Query Kind="Program" />

void Main()
{
	var totalValue = 15;
	var items = new[] {1,3,4,6,7};

	int[] value = { 10, 50, 70 };
	int[] weight = { 10, 20, 30 };
	int capacity = 40;
	int itemsCount = 3;

	int result = KnapSack(capacity, weight, value, itemsCount);
	Console.WriteLine(result);
}


public static int KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
{
	int[,] K = new int[itemsCount + 1, capacity + 1];

	for (int i = 0; i <= itemsCount; ++i)
	{
		for (int w = 0; w <= capacity; ++w)
		{
			if (i == 0 || w == 0)
				K[i, w] = 0;
			else if (weight[i - 1] <= w)
				K[i, w] = Math.Max(value[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
			else
				K[i, w] = K[i - 1, w];
		}
	}
	K.Dump();
	return K[itemsCount, capacity];
}