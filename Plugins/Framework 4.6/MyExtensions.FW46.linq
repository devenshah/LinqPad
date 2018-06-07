<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Internals.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\SMDiagnostics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>System.Runtime.Serialization</Namespace>
</Query>

void Main()
{
	// Write code to test your extensions here. Press F5 to compile and run.
}

public static class MyExtensions
{
	// Write custom extension methods here. They will be available to all queries.
	public static void SerializeUsingDataContractSerializer(this object target, TextWriter output)
	{
		var d = new DataContractSerializer(target.GetType());

		var settings = new XmlWriterSettings
		{
			//remove xml  declaration tab
			OmitXmlDeclaration = true,
			Indent = true
		};
		using (var w = XmlWriter.Create(Console.Out, settings))
		{
			d.WriteObject(w, target);
		}
	}


	public static void SerializeUsingXmlSerializer(this object target, TextWriter output)
	{
		var x = new XmlSerializer(target.GetType());

		//remove the namespace next to root element	
		var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

		var settings = new XmlWriterSettings
		{
			//remove xml  declaration tab
			OmitXmlDeclaration = true,
			Indent = true
		};

		using (var writer = XmlWriter.Create(output, settings))
		{
			x.Serialize(writer, target, emptyNamepsaces);
		}
	}

	public static void Log(this object obj)
	{
		Console.WriteLine(obj);
	}

	public static void WL(this object obj)
	{
		Console.WriteLine(obj);
	}

}

[XmlRoot("HumanResource")]
[DataContract(Name = "Student")]
public class Person
{
	[DataMember]
	public string Name { get; set; }
	[DataMember]
	public DateTimeOffset DOB { get; set; }
	[DataMember]
	public Gender Gender { get; set; }
}

public enum Gender
{
	Female = 1,
	Male = 2
}