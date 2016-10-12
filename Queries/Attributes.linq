<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.DataAnnotations.dll</Reference>
  <Namespace>System.ComponentModel.DataAnnotations</Namespace>
</Query>

void Main()
{
	var p = new Person{Name = "Dev", GenderId = 1};
	
	var metadata = p.GetType().GetCustomAttribute(typeof(MetadataTypeAttribute), false);
	var metaType = (metadata as MetadataTypeAttribute).MetadataClassType;
	//metaType.GetProperties().Dump();
	var properties = p.GetType().GetProperties();
	
	foreach (var property in properties)
	{
		var attributes = GetCustomAttributes(property, metaType);
		attributes.Dump(string.Format("Attributes for {0}", property.Name));
	}
	
}

public IEnumerable<Attribute> GetCustomAttributes(PropertyInfo property, Type metadataType)
{
	var attributes = property.GetCustomAttributes();
	if (metadataType != null)
	{
		var metaProperty = metadataType.GetProperty(property.Name);
		
		if (metaProperty != null)
		{
			var metaAttributes = metaProperty.GetCustomAttributes();
			attributes = attributes.Concat(metaAttributes);				
		}			
	}	
	return attributes;
}

[MetadataType(typeof(PersonMetadata))]
public class Person
{
	[MaxLength(100)]
	public string Name { get; set; }
	
	[Range(1,1)]
	public int GenderId { get; set; }
	
	private class PersonMetadata
	{
		[MetaData(Description = "The Gender", EnumType = typeof(Gender))]
		public int GenderId { get; set; }
	}
}


public enum Gender
{
	Male = 1,
	Femail = 2
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class MetaDataAttribute : Attribute
{
	public string Description { get; set; }
	public Type EnumType { get; set; }
}