<Query Kind="Program" />

void Main()
{
	var it = new Iterator<License>(GetLicenses());
	for (var i = 0; i < 9; i++)
	{
		bool recylced;
		var l = it.GetNextItem(out recylced);
		l.Count++;
		Console.WriteLine(string.Format("ID: {2}, Name: {0}, Recylced: {1}, Count: {3}",l.Name, recylced, l.Id, l.Count));
	}
}

public class Iterator<T> where T : class
{
	private IEnumerable<T> _targetList;
	private int _skip = -1;
	private int _count = 0;
	public Iterator(IEnumerable<T> targetList)
	{
		_targetList = targetList;
		_count = _targetList.Count();
	}
	
	public T GetNextItem(out bool recycled)
	{
		_skip++;
		recycled = false;
		if (_skip >= _count)
		{
			recycled = true;
			_skip = 0;
		}
		return _targetList.Skip(_skip).Take(1).FirstOrDefault();
	}
	
	public void Reset()
	{
		_skip = -1;
	}
}


List<License> GetLicenses()
{
	return new List<License>()
	{
		new License("License1"),
		new License("License2"),
		new License("License3"),
	};
}

public class License
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public int Count { get; set; }
	public License(string name)
	{
		Id = Guid.NewGuid();
		Name = name;
	}
}