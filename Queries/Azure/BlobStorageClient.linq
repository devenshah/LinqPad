<Query Kind="Program">
  <NuGetReference>AutoMapper</NuGetReference>
  <NuGetReference>WindowsAzure.Storage</NuGetReference>
  <Namespace>Microsoft.Azure.KeyVault.Core</Namespace>
  <Namespace>Microsoft.Data.Edm</Namespace>
  <Namespace>Microsoft.Data.Edm.Annotations</Namespace>
  <Namespace>Microsoft.Data.Edm.Csdl</Namespace>
  <Namespace>Microsoft.Data.Edm.EdmToClrConversion</Namespace>
  <Namespace>Microsoft.Data.Edm.Evaluation</Namespace>
  <Namespace>Microsoft.Data.Edm.Expressions</Namespace>
  <Namespace>Microsoft.Data.Edm.Library</Namespace>
  <Namespace>Microsoft.Data.Edm.Library.Annotations</Namespace>
  <Namespace>Microsoft.Data.Edm.Library.Expressions</Namespace>
  <Namespace>Microsoft.Data.Edm.Library.Values</Namespace>
  <Namespace>Microsoft.Data.Edm.Validation</Namespace>
  <Namespace>Microsoft.Data.Edm.Values</Namespace>
  <Namespace>Microsoft.Data.OData</Namespace>
  <Namespace>Microsoft.Data.OData.Atom</Namespace>
  <Namespace>Microsoft.Data.OData.Metadata</Namespace>
  <Namespace>Microsoft.Data.OData.Query</Namespace>
  <Namespace>Microsoft.Data.OData.Query.SemanticAst</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Analytics</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Auth</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Auth.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Blob</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Blob.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Core</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Core.Auth</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.File</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.File.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Queue</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Queue.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.RetryPolicies</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Shared.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Table</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Table.DataServices</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Table.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Table.Queryable</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System.Data.Services.Client</Namespace>
  <Namespace>System.Data.Services.Common</Namespace>
  <Namespace>System.Spatial</Namespace>
</Query>

void Main()
{
	var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=indiwizstorage;AccountKey=fHzhoCKrp9F33ol6pZg0ri5X8mk+PXt3qQe2XqTU2OSdjRBoP245If6mxNy5Wm4cPmb7ok1piXQhi3IRInQEMg==");
	
	var blobClient = storageAccount.CreateCloudBlobClient();
	
	var container = blobClient.GetContainerReference("mycontainer");
	
	container.CreateIfNotExists();

	var blockBlob = container.GetBlockBlobReference("myblob");

	// Create or overwrite the "myblob" blob with contents from a local file.
	using (var fileStream = System.IO.File.OpenRead(@"E:\Temp\EF7-RTM-Exclusions.png"))
	{
		blockBlob.UploadFromStream(fileStream);
	}

}

// Define other methods and classes here
