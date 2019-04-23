<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    var data = @"
    { 'People' : [
        {'Name': 'Deven', Gender:'Male'},
        {'Name': 'Suman', Gender:'Female'},
        {'Name': 'Diya', Gender:'Female'}
    ]}
    ";
    
    var employees = JsonConvert.DeserializeObject<Employees>(data);

    var grouped = employees.People.GroupBy(p => p.Gender).Select(p => new { Gender = p.Key, Employees = p.ToList() });
    
    grouped.Dump();
    
}

class Employees
{
    public IEnumerable<Employee> People {get; set;}
}


class Employee
{
    public string Name { get; set; }
    public string Gender { get; set; }
}

