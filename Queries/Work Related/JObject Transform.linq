<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.XML.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.Serialization.dll</Reference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System.Runtime.Serialization</Namespace>
  <Namespace>System.Runtime.Serialization.Configuration</Namespace>
  <Namespace>System.Runtime.Serialization.Json</Namespace>
  <Namespace>System.Xml</Namespace>
  <Namespace>System.Xml.Resolvers</Namespace>
  <Namespace>System.Xml.Schema</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>System.Xml.Serialization.Advanced</Namespace>
  <Namespace>System.Xml.Serialization.Configuration</Namespace>
  <Namespace>System.Xml.XmlConfiguration</Namespace>
  <Namespace>System.Xml.XPath</Namespace>
  <Namespace>System.Xml.Xsl</Namespace>
</Query>

void Main()
{
	#region Data
	var data= @"{
  '@odata.context': 'http://pm-sims-primary-api-partner-dev.azurewebsites.net/Learner/$metadata#Learners(Personal(IsDeleted,ExternalID,PreferredForename,PreferredSurname,LegalForename,LegalSurname,DateOfBirth))',
  'value': [
    {
      'IsDeleted': false,
      'ExternalID': '855dea56-d406-47e7-900a-93fb3791d34e',
      'Personal': {
        'IsDeleted': false,
        'ExternalID': '855dea56-d406-47e7-900a-93fb3791d34e',
        'PreferredForename': 'Elise',
        'PreferredSurname': 'Ottley',
        'LegalForename': 'Elise',
        'LegalSurname': 'Ottley',
        'DateOfBirth': '2003-05-04T00:00:00Z'
      }
    },
    {
      'IsDeleted': false,
      'ExternalID': '506dfbbd-a184-425f-a50a-8ccf9967b484',
      'Personal': {
        'IsDeleted': false,
        'ExternalID': '506dfbbd-a184-425f-a50a-8ccf9967b484',
        'PreferredForename': 'Ruth',
        'PreferredSurname': 'Williams',
        'LegalForename': 'Ruth',
        'LegalSurname': 'Williams',
        'DateOfBirth': '2001-11-05T00:00:00Z'
      }
    },
    {
      'IsDeleted': false,
      'ExternalID': '68aec0f9-f496-40f2-9804-fb120db347c9',
      'Personal': {
        'IsDeleted': false,
        'ExternalID': '68aec0f9-f496-40f2-9804-fb120db347c9',
        'PreferredForename': 'Ashlie',
        'PreferredSurname': 'Waters',
        'LegalForename': 'Ashlie',
        'LegalSurname': 'Waters',
        'DateOfBirth': '2002-09-04T00:00:00Z'
      }
    }
	]}";
	
	#endregion
	
	var jobject = JObject.Parse(data);
	var studs = jobject["value"].Select(x => x["Personal"].ToObject<Personal>());
	studs.Dump();
	SerializeObject(studs.First(), "http://www.sims.co.uk/CCP/TransferStudent").Dump();
}

protected static string SerializeObject<T>(T serializableObject, string nameSpace)
{
	if (serializableObject == null)
	{
		return null;
	}

	var serializer = new XmlSerializer(serializableObject.GetType(), nameSpace);

	using (var writer = new StringWriter())
	{
		try
		{
			serializer.Serialize(writer, serializableObject);
		}
		catch (Exception)
		{
			//Log exception here
			return null;
		}
		return writer.ToString();
	}
}

public class Personal
{
	public bool IsDeleted { get; set; }
	public Guid ExternalID { get; set; }
	public string PreferredForename { get; set; }
	public string PreferredSurname { get; set; }
	public string LegalForename { get; set; }
	public string LegalSurname { get; set; }
	public DateTime DateOfBirth { get; set; }
}

public class Student
{
	[XmlAttribute]
	public Guid studentID { get; set; }
	[XmlAttribute]
	public string forename { get; set; }
	[XmlAttribute]
	public string surname { get; set; }
	[XmlAttribute]
	public string discriminator { get; set; }
	[XmlAttribute]
	public string dateOfBirthHash { get; set; }
	[XmlAttribute]
	public bool isDeceased { get; set; }
}