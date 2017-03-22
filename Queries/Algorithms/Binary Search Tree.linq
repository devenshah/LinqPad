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
		var n = "*";
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

class BinarySearchTree
{ 
	public Node RootNode;

	public Dictionary<int, Node> Nodes { get; } = new Dictionary<int, Node>();

	public void Insert(params int[] list)
	{
		foreach (var num in list)
		{
			if (Nodes.ContainsKey(num)) continue;
			
			var newNode = new Node(num);
			
			Nodes.Add(num, newNode);
			
			if (RootNode == null)
			{
				RootNode = newNode;
				continue;
			}

			var assigned = false;
			var currentNode = RootNode;
			while (!assigned) {
				assigned = TryAssign(currentNode, newNode, out currentNode);
			}
		}
	}

	private bool TryAssign(Node parentNode, Node newNode, out Node currentNode)
	{
		if (newNode.CompareTo(parentNode) < 0)
		{
			if (parentNode.Left == null)
			{
				parentNode.Left = currentNode = newNode;
				return true;
			}
			else
			{
				currentNode = parentNode.Left;
				return false;
			}
		}
		else
		{
			if (parentNode.Right == null)
			{
				parentNode.Right = currentNode = newNode;
				return true;
			}
			else
			{
				currentNode = parentNode.Right;
				return false;
			}
		}
	}

	public void Insert_V2(params int[] list)
	{
		foreach (var num in list)
		{
			if (Nodes.ContainsKey(num)) continue;

			var newNode = new Node(num);

			Nodes.Add(num, newNode);

			if (RootNode == null)
			{
				RootNode = newNode;
				continue;
			}
			
			Assign(RootNode, newNode);
		}
	}

	private void Assign(Node parentNode, Node newNode)
	{
		if (newNode.CompareTo(parentNode) < 0)
		{
			if (parentNode.Left == null)
			{
				parentNode.Left = newNode;
				return;
			}
			else
			{
				Assign(parentNode.Left, newNode);				
			}
		}
		else
		{
			if (parentNode.Right == null)
			{
				parentNode.Right = newNode;
				return;
			}
			else
			{
				Assign(parentNode.Right, newNode);
			}
		}
	}
	
	public void ToInOrder(Node rootNode)
	{
		//In order
		if (rootNode != null)
		{
			ToInOrder(rootNode.Left);
			Console.Write(rootNode.Data + " ");
			ToInOrder(rootNode.Right);
		}
	}

	public void ToPreorder(Node rootNode)
	{
		//Root First then Left and then Right
		if (rootNode != null)
		{
			Console.Write(rootNode.Data + " ");
			ToPreorder(rootNode.Left);
			ToPreorder(rootNode.Right);
		}
	}
	
	public void ToPostorder(Node rootNode)
	{
		//First Left then Right
		if (rootNode != null)
		{
			ToPostorder(rootNode.Left);
			ToPostorder(rootNode.Right);
			Console.Write(rootNode.Data + " ");
		}
	}

	public int GetMinimumNumber(Node rootNode)
	{
		if (rootNode.Left == null)
		{			
			return rootNode.Data;
		}
		return GetMinimumNumber(rootNode.Left);
	}
	
	public int GetMaximumNumber(Node rootNode)
	{
		if (rootNode.Right == null)
		{
			return rootNode.Data;
		}
		return GetMaximumNumber(rootNode.Right);
	}
}

void Main()
{
	//TestBinaryTree();
	TestBinaryTree_V2();
}

void TestBinaryTree_V2()
{
	var tree = new BinarySearchTree();
	tree.Insert_V2(50, 17, 23, 12, 19, 54, 10, 14, 67, 76, 72);
	foreach (var node in tree.Nodes) node.ToString().Log();
	"In Order:".Log();
	tree.ToInOrder(tree.RootNode);
	Environment.NewLine.Log();
	"Post Order:".Log();
	tree.ToPostorder(tree.RootNode);	
	Environment.NewLine.Log();
	"Pre Order:".Log();
	tree.ToPreorder(tree.RootNode);
	Environment.NewLine.Log();
	$"Minimum Number: {tree.GetMinimumNumber(tree.RootNode)}".Log();
	$"Maximum Number: {tree.GetMaximumNumber(tree.RootNode)}".Log();
}

void TestBinaryTree()
{
	var tree = new BinarySearchTree();
	tree.Insert(50, 17, 23, 12, 19, 54, 10, 14, 67, 76, 72);
	foreach (var node in tree.Nodes) node.ToString().Log();
}