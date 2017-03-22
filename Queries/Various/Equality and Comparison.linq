<Query Kind="Program" />

class Node : IComparable<Node>, IEquatable<int>
{ 
	public int Data { get; }
	public Node Left { get; set; } 
	public Node Right { get; set; }
	
	public Node(int i)
	{
		Data = i;
	}
	public override string ToString()
	{
		var n = "null";
		return $"This:{Data}, Left:{Left?.Data.ToString() ?? n}, Right:{Right?.Data.ToString() ?? n}";
	}

	public override int GetHashCode()
	{
		return Data.GetHashCode();
	}

	//IComparable
	public int CompareTo(Node node)
	{
		return this.Data.CompareTo(node.Data);
	}

	public override bool Equals(object obj)
	{
		var node = obj as Node;
		if (node == null) return false;
		if (ReferenceEquals(obj, this)) return true;
		return node.Data == this.Data;
	}

	//IEquatable
	public bool Equals(int i)
	{
		return this.Data == i;
	}
	
}

class NodeComparer : IComparer<Node>
{
	//Comparer is not implemented on the type 
	//as you can have many different comparers on the same type
	public int Compare(Node x, Node y)
	{
		if (x == null && y == null) return 0;

		//by convention null comes before any non null objects
		if (x == null) return -1;

		if (y == null) return 1;

		return x.Data.CompareTo(y.Data);
	}
}

void Main()
{	
	TestEquality();
	TestComparer();
}

void TestEquality()
{
	var node1 = new Node(1);
	var node2 = new Node(2);
	var node3 = node1;
	var node4 = new Node(2);
	Node node5 = null;
	node1.Equals(node5).Dump(); //False: compared to is null
	node1.Equals("1").Dump(); //False: due to compared to value is not Node
	node1.Equals(1).Dump(); //True: due to IEquatable<int>
	node1.Equals(node3).Dump(); //True: reference equals
	node2.Equals(node4).Dump(); //True: value equals
}

void TestComparer()
{
	var list = new[] { new Node(11), new Node(5), new Node(10) };
	Array.Sort(list, new NodeComparer());
	foreach(var item in list)
		item.Dump();
}