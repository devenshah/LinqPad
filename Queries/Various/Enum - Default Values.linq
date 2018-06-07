<Query Kind="Program">
  <NuGetReference>AutoFixture</NuGetReference>
  <NuGetReference>FluentValidation</NuGetReference>
  <Namespace>AutoFixture</Namespace>
  <Namespace>AutoFixture.DataAnnotations</Namespace>
  <Namespace>AutoFixture.Dsl</Namespace>
  <Namespace>AutoFixture.Kernel</Namespace>
  <Namespace>FluentValidation</Namespace>
  <Namespace>FluentValidation.Attributes</Namespace>
  <Namespace>FluentValidation.Internal</Namespace>
  <Namespace>FluentValidation.Resources</Namespace>
  <Namespace>FluentValidation.Results</Namespace>
  <Namespace>FluentValidation.TestHelper</Namespace>
  <Namespace>FluentValidation.Validators</Namespace>
  <Namespace>static UserQuery</Namespace>
  <Namespace>System.ComponentModel.DataAnnotations</Namespace>
  <Namespace>System.ComponentModel.DataAnnotations.Schema</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var emp = new Employee();
	emp.NullableGender.Log();
	emp.Gender.Log();
}

// Define other methods and classes here
public class Employee
{
	public Gender? NullableGender { get; set; }
	public Gender Gender { get; set; }
}