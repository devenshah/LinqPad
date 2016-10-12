<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.XmlSerializer.dll</Reference>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{	
	var person = new Person{ Id = 1, Name="deven", Weight=89.5m};
	//DumpObjectXml();
	//LoadObjectInXmlDoc();
	//LoadXmlFileAndAddElement();
	//ExportObjectToXml(person);
	//AppendXmlStringToXmlDoc();
	SerializeToXmlDocument(person);
}

void DumpObjectXml()
{
	var xmlSerializer = new XmlSerializer(typeof(EcoAssessment), "ECO");
	var es = GetEcoAssessment();
	es.Software = GetSoftware("360");
	xmlSerializer.Serialize(Console.Out, es);	
}

public void LoadObjectInXmlDoc()
{
	var xmlDoc = new XmlDocument();
	var xmlSerializer = new XmlSerializer(typeof(EcoAssessment),"ECO");
	var es = GetEcoAssessment();
	es.Software = GetSoftware("360");
	using (var memoryStream = new MemoryStream())
	{
		xmlSerializer.Serialize(memoryStream, es);
		memoryStream.Position = 0;
		xmlDoc.Load(memoryStream);		
	}
	//return xmlDoc;
	xmlDoc.InnerXml.Dump();
}

public void LoadXmlFileAndAddElement()
{
	var xDoc = new XmlDocument();
	xDoc.Load(@"E:\My Space\Tasks\2014\3.1\23640 - XML Report\Output\ECO-1_A+B+W_oil warm air heating NOT upgraded_ECO.xml");
	
	var newElm = xDoc.CreateElement("Improvement","ECO");
	//Insert child in a particular position
	var beforeElm = xDoc.GetElementsByTagName("Total-Percentage-Of-Total-Exterior-Walls")[0];
	beforeElm.ParentNode.InsertBefore(newElm, beforeElm);
	//Add child at the end
	//xDoc.GetElementsByTagName("ECO-Assessment")[0].AppendChild(newElm);	
	xDoc.InnerXml.Dump();
}

public void ExportObjectToXml(object obj, bool omitXmlHeaders = true)
{	
	obj.GetType().Dump();	
	using (var ms = new MemoryStream())
	{
		var xs = new XmlSerializer(obj.GetType());
		var settings = new XmlWriterSettings{ Indent = true, OmitXmlDeclaration = omitXmlHeaders};
		using (var xw = XmlWriter.Create(ms, settings))
		{
			var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });		
			xs.Serialize(xw, obj, emptyNs);
		}		
		
		ms.Position = 0;
		using(var sr = new StreamReader(ms))
		{
			var myStr = sr.ReadToEnd();
			myStr.Dump();
		}
	}
}

public void AppendXmlStringToXmlDoc()
{
//Load target xml in to xDoc
	var xDoc = new XmlDocument();
	xDoc.Load(@"E:\My Space\Tasks\2014\3.1\23640 - XML Report\Output\ECO-1_A+B+W_oil warm air heating NOT upgraded_ECO.xml");
//get the stringly typed xml	
	var person = new Person{ Id = 1, Name="deven", Weight=89.5m};
	var xs = new XmlSerializer(typeof(Person));
	string personString;
	using (var ms = new MemoryStream())
	{
		var settings = new XmlWriterSettings{ Indent = true, OmitXmlDeclaration = true};
		var xw = XmlWriter.Create(ms, settings);
		var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });		
		xs.Serialize(xw, person, emptyNs);
		xw.Close();
		xw.Dispose();
		ms.Position = 0;
		var sr = new StreamReader(ms);
		personString = sr.ReadToEnd();
		sr.Dispose();
	}
	
	var xFrag = xDoc.CreateDocumentFragment();
	xFrag.InnerXml = personString;
	var beforeElm = xDoc.GetElementsByTagName("Total-Percentage-Of-Total-Exterior-Walls")[0];
	beforeElm.ParentNode.InsertBefore(xFrag, beforeElm);
	
	var xFrag1 = xDoc.CreateDocumentFragment();
	xFrag1.InnerXml = personString;
	xDoc.DocumentElement.FirstChild.AppendChild(xFrag1);
	xDoc.InnerXml.Dump();
}

public XmlDocument SerializeToXmlDocument(object input)
{   
	
   
   XmlSerializer ser = new XmlSerializer(input.GetType());

   XmlDocument xd = null;

	
   using(MemoryStream memStm = new MemoryStream())
   {
   		//var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });		
     	//ser.Serialize(memStm, input, emptyNs);
		var ns = new XmlSerializerNamespaces();
		ns.Add("ECO","ECO");
		ser.Serialize(memStm, input, ns);

     	memStm.Position = 0;

		XmlReaderSettings settings = new XmlReaderSettings();
		settings.IgnoreWhitespace = true;

     using(var xtr = XmlReader.Create(memStm, settings))
     {  
        xd = new XmlDocument();
		//xd.Schemas.Add("http://www.w3.org/2001/XMLSchema-instance", "ECO ECO-Report.xsd"); 
        xd.Load(xtr);
     }
   }
	xd.InnerXml.Dump();
   return xd;
}

public class Person
{
	public int Id { get; set; }
	public string Name { get; set; }
	public decimal Weight { get; set; }
}

public InsulationMeasure GetWallMeasure()
{
	return null;
}

public EcoAssessment GetEcoAssessment()
{
	var es = new EcoAssessment();
	es.SchemaVersion = "ECO-2.0";
	es.EcoVersion = "2.0";
	es.ReportDate = DateTime.Today.ToString("yyyy-MM-dd");
	es.PreInstallationEpcRrn = "0114-9624-8430-2736-5926";
	es.ReportAuthor = "My Energy Supplier";
	return es;
}

public Software GetSoftware(string pcdfFuelPrices)
{
	return new Software
	{
		CalculationSoftwareName = "ABC ECO Software",
		CalculationSoftwareVersion = "2.03.08",
		UserInterfaceName = "ABC ECO Software UI",
		UserInterfaceVersion = "2.03.08",
		SAPVersion = "9.92",
		PCDFRevisionNumber = "366",
		PCDFFuelPrices = pcdfFuelPrices		
	};
}

public void GetMeasureObject<T>(int sequence)
{
	var list = new List<Improvement>();
		list.Add(new Improvement(1));
		list.Add(new Improvement(2));
		
		var xmlSerializer = new XmlSerializer(typeof(List<Improvement>));
		var ms = new MemoryStream();
		xmlSerializer.Serialize(ms, list);
		ms.Flush();
		ms.Seek(0, SeekOrigin.Begin);
		var sr = new StreamReader(ms);
		var xml = sr.ReadToEnd();
		xml.Dump();
}

[XmlRoot("ECO-Assessment")]
public class EcoAssessment
{
	[XmlElement("Schema-Version")]
	public string SchemaVersion { get; set; }
	[XmlElement("ECO-Version")]
	public string EcoVersion { get; set; }
	[XmlElement("Report-Date")]
	public string ReportDate { get; set; }
	
	public Property Property { get; set; }

	[XmlElement("Pre-Installation-EPC-RRN")]
	public string PreInstallationEpcRrn { get; set; }
	
	public Software Software { get; set; }
	[XmlElement("Report-Author")]
	public string ReportAuthor { get; set; }	
	
}

public class Property {}

public class Software
{
	[XmlElement("Calculation-Software-Name")]
	public string CalculationSoftwareName { get; set; }
	[XmlElement("Calculation-Software-Version")]
	public string CalculationSoftwareVersion { get; set; }
	[XmlElement("User-Interface-Name")]
	public string UserInterfaceName { get; set; }
	[XmlElement("User-Interface-Version")]
	public string UserInterfaceVersion { get; set; }
	[XmlElement("SAP-Version")]
	public string SAPVersion { get; set; }
	[XmlElement("PCDF-Revision-Number")]
	public string PCDFRevisionNumber { get; set; }
	[XmlElement("PCDF-Fuel-Prices")]
	public string PCDFFuelPrices { get; set; }
}

public class Improvement
{
	public Improvement()
	{
		
	}
	public Improvement(int sequence)
	{
		this.Sequence = sequence;		
	}
	public int Sequence { get; set; }
	[XmlElement("Install-Date")]
	public string InstallDate { get; set; }
	[XmlElement("Improvement-Type")]
	public string ImprovementType { get; set; }
	[XmlElement("Ofgem-Measure-Name")]
	public string OfgemMeasureName { get; set; }
	[XmlElement("Measure-Reference")]
	public string MeasureReference { get; set; }
	
	[XmlElement("Insulation-Measure")]	
	public InsulationMeasure InsulationMeasure { get; set; }
	
	public decimal? Lifetime { get; set; }
	[XmlElement("Annual-Cost-Saving")]
	public decimal? AnnualCostSaving { get; set; }
	[XmlElement("Lifetime-Cost-Saving")]
	public decimal? LifetimeCostSaving { get; set; }
	[XmlElement("In-Use-Factor")]
	public decimal? InUseFactor { get; set; }
	[XmlElement("Annual-CO2-Saving")]
	public decimal? AnnualCO2Saving { get; set; }
	[XmlElement("Lifetime-CO2-Saving")]
	public decimal? LifetimeCO2Saving { get; set; }
	
}

public class InsulationMeasure : IWallMeasure, ILoftMeasure
{
	[XmlElement("Percentage-Main")]
	public decimal? PercentageMain { get; set; }
	[XmlElement("Percentage-Overall")]
	public decimal? PercentageOverall { get; set; }
	[XmlElement("Loft-Insulation-Thickness")]
	public string LoftInsulationThickness { get; set; }
	[XmlElement("Alternative-Wall-Main")]
	public bool? AlternativeWallMain { get; set; }
	[XmlElement("Percentage-Of-Total-Exterior-Walls")]
	public decimal? PercentageOfTotalExteriorWalls { get; set; }
	[XmlElement("RdSAP-Cavity-Fill")]
	public string RdSAPCavityFill { get; set; }
	[XmlElement("U-Value")]
	public decimal? UValue { get; set; }
	[XmlElement("Insulation-Thickness")]
	public string InsulationThickness { get; set; }
}

public interface IBaseInsulationMeasure
{
	decimal? PercentageMain { get; set; }
	decimal? PercentageOverall { get; set; }
}
public interface ILoftMeasure : IBaseInsulationMeasure
{
	string LoftInsulationThickness { get; set; }
}
public interface IWallMeasure : IBaseInsulationMeasure
{
	bool? AlternativeWallMain { get; set; }
	decimal? PercentageOfTotalExteriorWalls { get; set; }
	string RdSAPCavityFill { get; set; }
	decimal? UValue { get; set; }
}
public interface IFloorMeasure : IBaseInsulationMeasure
{
	string InsulationThickness { get; set; }
}

private XDocument GetXDocFromString(string xmlString)
{
	return XDocument.Parse(xmlString);
}

private string GetElementValue(XDocument xDoc, string elementName)
{
	var NoDataFound = "No data found";
	var TooManyMatches = "Too many matches";
	XNamespace xmlNS = "http://www.epcregister.com/xsd/rdsap";
	
	var elms = xDoc.Descendants(xmlNS + elementName);
	var resultCount = elms.Count();
	if (resultCount == 1)
	{
	return elms.First().Value;
	}
	string errorMessage = resultCount == 0 ? NoDataFound : TooManyMatches ;
	throw new Exception(errorMessage);
}

private string GetElementValue(XDocument xDoc, string elementName, string parentName)
{
	var NoDataFound = "No data found";
	var TooManyMatches = "Too many matches";
	XNamespace xmlNS = "http://www.epcregister.com/xsd/rdsap";
	
	var elms = from el in xDoc.Descendants(xmlNS + elementName)
			where el.Parent.Name == xmlNS + parentName
			select el;
	var resultCount = elms.Count();
	if (resultCount == 1)
	{
	return elms.First().Value;
	}
	string errorMessage = resultCount == 0 ? NoDataFound : TooManyMatches;
	throw new Exception(errorMessage);
}