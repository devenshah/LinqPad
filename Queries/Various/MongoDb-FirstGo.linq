<Query Kind="Program">
  <Reference Relative="..\..\Drivers\Mongo\MongoDB.Bson.dll">C:\Deven\Git\LinqPad\Drivers\Mongo\MongoDB.Bson.dll</Reference>
  <Reference Relative="..\..\Drivers\Mongo\MongoDB.Driver.dll">C:\Deven\Git\LinqPad\Drivers\Mongo\MongoDB.Driver.dll</Reference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.IO</Namespace>
  <Namespace>MongoDB.Bson.Serialization</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Attributes</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Conventions</Namespace>
  <Namespace>MongoDB.Bson.Serialization.IdGenerators</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Options</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Serializers</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>MongoDB.Driver.Builders</Namespace>
  <Namespace>MongoDB.Driver.GridFS</Namespace>
  <Namespace>MongoDB.Driver.Internal</Namespace>
  <Namespace>MongoDB.Driver.Linq</Namespace>
  <Namespace>MongoDB.Driver.Wrappers</Namespace>
</Query>

void Main()
{
	var server = new MongoClient(new MongoUrl("mongodb://appUser3:H!iL3c*zwia9pex%iT%2@10.0.3.12:27017")).GetServer();
	
	var database = server.GetDatabase("applicationDB");
	
	var collection = database.GetCollection("apprenticeships");
	
	collection.FindAll().Dump();
	
	collection.AsQueryable().First(c => c.)
}

// Define other methods and classes here
