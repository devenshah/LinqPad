<Query Kind="Program">
  <NuGetReference>CsvHelper</NuGetReference>
  <NuGetReference>MongoDB.Driver</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Attributes</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>System.Security.Authentication</Namespace>
  <Namespace>CsvHelper</Namespace>
  <Namespace>CsvHelper.Configuration</Namespace>
</Query>

void Main()
{
    var settings = new MongoClientSettings()
    {
        Server = new MongoServerAddress("das-prd-faa-cdb.documents.azure.com", 10255),
        UseSsl = true,
        SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 },
        ConnectionMode = ConnectionMode.Direct,
        Credential = MongoCredential.CreateCredential("admin", "das-prd-faa-cdb", "some password")
        //Credential = new MongoCredential("SCRAM-SHA-1", new MongoInternalIdentity(DatabaseName, UserName), new PasswordEvidence(Password) )
    };

    var client = new MongoClient(settings);

    var database = client.GetDatabase("findapprenticeship");
    var collection = database.GetCollection<Candidate>("candidates");

    //
    
    //var filter = new FilterDefinitionBuilder<BsonDocument>().In("_id", ids);
    
    var list = new List<Candidate>();
    
    foreach(var id in ids)
    {
        var filter = new BsonDocument("_id", id);
        list.Add(collection.Find(filter.ToBsonDocument()).FirstOrDefault());
    }

    var textReader = new StreamReader(File.Open(@"C:\SFA\RAA\Candidate Traineeship.csv", FileMode.Open));
    var csv = new CsvReader(textReader, new Configuration() { MissingFieldFound = null, HeaderValidated = null });
    var records = csv.GetRecords<MyClass>().ToList();
    textReader.Dispose();
    
    foreach (var record in records)
    {
        record.Candidate = list.FirstOrDefault(l => l.Id == record.CandidateId);
    }
    
    var transposed = records.Select(l => new {l.CandidateId, l.VacancyId, l.AttemptedOn, l.Candidate.RegistrationDetails.EmailAddress, l.Candidate.RegistrationDetails.PhoneNumber}).ToList();
    
    transposed.Dump();
}

public class MyClass
{       
    public Guid CandidateId { get; set; }
    public string VacancyId { get; set; }
    public string AttemptedOn { get; set; }
    public Candidate Candidate { get; set; }
}

[BsonIgnoreExtraElements]
public class Candidate
{
    public Guid Id { get; set; }
    
    public RegistrationDetails RegistrationDetails { get; set; }
}
[BsonIgnoreExtraElements]
public class RegistrationDetails
{ 
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}

private Guid[] ids = new[] {
Guid.Parse("40217cc3-9d10-4082-9b8b-ae0cbd0d3ac7"),
Guid.Parse("9d00743f-4de1-4c75-b524-fee10f201b8e"),
Guid.Parse("a0c0a8c5-8148-4c17-aca9-2e20cba7bcad"),
Guid.Parse("0bde821f-6cee-4e3f-92e5-58458208def1"),
Guid.Parse("0bde821f-6cee-4e3f-92e5-58458208def1"),
Guid.Parse("2ac7361b-92a0-4000-9489-f847ba7cdf93"),
Guid.Parse("2ac7361b-92a0-4000-9489-f847ba7cdf93"),
Guid.Parse("79188ba2-d062-487f-8dae-34642efa6c8e"),
Guid.Parse("24fcca02-5154-4c59-b376-59d3b655a24a"),
Guid.Parse("b0c633a2-c0d5-4e8c-a9e8-3982ce2401bd"),
Guid.Parse("662fb5de-239a-4b51-8ce5-079208286f5c"),
Guid.Parse("5465cf64-a786-43ad-ba57-d2bab2648549"),
Guid.Parse("d16695b3-4d40-40d9-9be7-98a9e4b055bc"),
Guid.Parse("d5fc7368-386a-4b60-971e-4b0a9e03560d"),
Guid.Parse("3096e2ed-3697-4739-8c27-807e95abaae0"),
Guid.Parse("3096e2ed-3697-4739-8c27-807e95abaae0"),
Guid.Parse("662fb5de-239a-4b51-8ce5-079208286f5c"),
Guid.Parse("1ed716df-dfcf-47c5-b936-80c6cc894e5b"),
Guid.Parse("1ed716df-dfcf-47c5-b936-80c6cc894e5b"),
Guid.Parse("c557402e-35c3-40b1-a82a-9150b343f954"),
Guid.Parse("c557402e-35c3-40b1-a82a-9150b343f954"),
Guid.Parse("c72f8d2f-9bb3-4259-ac31-169c342cd1f2"),
Guid.Parse("c72f8d2f-9bb3-4259-ac31-169c342cd1f2"),
Guid.Parse("c72f8d2f-9bb3-4259-ac31-169c342cd1f2"),
Guid.Parse("99f5ff51-d894-45e3-9b6b-69260d96bd4d"),
Guid.Parse("890f5899-6a00-4513-b24c-b0ee6258f83a"),
Guid.Parse("7cf78a78-9f6d-4ec8-ade8-b0ce505c53c9"),
Guid.Parse("98fe2a9b-f3b1-4e3a-9975-571c7bfa4cb5"),
Guid.Parse("2dafdd47-6da0-4ff5-a509-f8101394b1f2"),
Guid.Parse("2dafdd47-6da0-4ff5-a509-f8101394b1f2"),
Guid.Parse("190ca2e9-2196-4c92-ae69-1b81ff5458f2"),
Guid.Parse("972c7fba-5761-46d8-aeea-d6bc560100ad"),
Guid.Parse("e056ea99-543c-40b7-841c-7db1a28b028c"),
Guid.Parse("43476869-6333-4f4b-bc2a-7afc6455bc86"),
Guid.Parse("f986d7f9-de26-4511-a6a4-f463e1172438"),
Guid.Parse("f986d7f9-de26-4511-a6a4-f463e1172438"),
Guid.Parse("33768118-a4f6-412b-b811-bd8fa39b9409"),
Guid.Parse("7a5d1707-c493-400c-8474-9ae2ac56203c"),
Guid.Parse("7e38c417-ea05-4c28-a9cc-6b6e0ede75ff"),
Guid.Parse("042ba480-ecd2-4701-9f20-dc8fb728775e"),
Guid.Parse("042ba480-ecd2-4701-9f20-dc8fb728775e"),
Guid.Parse("60f9f982-9ffa-4acf-9e05-ef98fbb3ca18"),
Guid.Parse("60f9f982-9ffa-4acf-9e05-ef98fbb3ca18"),
Guid.Parse("27df8a37-a618-4bfe-9d49-6de06d49a720"),
Guid.Parse("4d14d8b6-6bab-4d42-907b-e8a480e7e062"),
Guid.Parse("e01ad26d-3a76-4058-9e83-6950f1cd31b3"),
Guid.Parse("e01ad26d-3a76-4058-9e83-6950f1cd31b3"),
Guid.Parse("685298ed-827e-4c1d-8261-d55efda2fea6"),
Guid.Parse("685298ed-827e-4c1d-8261-d55efda2fea6"),
Guid.Parse("e82ffb52-fc00-4c27-a750-016abeeefb95"),
Guid.Parse("2ac4b420-0721-4037-9c25-15b6a84bd59a"),
Guid.Parse("2ec05758-5118-41e3-8919-ed8ef7bb4d13"),
Guid.Parse("2ec05758-5118-41e3-8919-ed8ef7bb4d13"),
Guid.Parse("662fb5de-239a-4b51-8ce5-079208286f5c"),
Guid.Parse("84d1f425-9354-4191-a6f0-127899e939dd"),
Guid.Parse("40217cc3-9d10-4082-9b8b-ae0cbd0d3ac7"),
Guid.Parse("bec8896e-4e27-496c-acf8-55d11b604849"),
Guid.Parse("ae29595a-bb29-480e-a2d2-8efe58f857c9"),
Guid.Parse("b878b169-7a30-4d92-9977-83359ddd5c8c"),
Guid.Parse("190ca2e9-2196-4c92-ae69-1b81ff5458f2"),
Guid.Parse("190ca2e9-2196-4c92-ae69-1b81ff5458f2"),
Guid.Parse("a80d198e-d03f-420e-bbd6-ef0fe2e425ad"),
Guid.Parse("3bc5c9f9-fb2b-48be-948b-e58cb77fe869"),
Guid.Parse("9040de7b-bcdd-43a1-9c0c-2fc36fbc1186"),
Guid.Parse("025f4ca2-21a7-43dd-bd86-3334121a7e03"),
Guid.Parse("f88bcb3a-95e4-481d-b7ac-434ef622a3f2"),
Guid.Parse("f88bcb3a-95e4-481d-b7ac-434ef622a3f2"),
Guid.Parse("2dfb99b5-292f-4070-815a-317dcfde175b"),
Guid.Parse("b3e471e8-13f4-4e1a-992e-69b9c8c1c19d"),
Guid.Parse("dc1bf7f5-f444-4e4f-b716-9007ca906f6d"),
Guid.Parse("57fe3b83-736f-4239-b859-2e04cb828457"),
Guid.Parse("a37ebbf2-3258-4f74-a044-984bc170fc1d"),
Guid.Parse("e31a422d-a6d5-48a9-9afd-5dd63136d5d4"),
Guid.Parse("8472b8d9-7506-4921-bde8-59475750fa40"),
Guid.Parse("8472b8d9-7506-4921-bde8-59475750fa40"),
Guid.Parse("f6078067-b806-486c-b2d9-a09e23e70ab9"),
Guid.Parse("f6078067-b806-486c-b2d9-a09e23e70ab9"),
Guid.Parse("662fb5de-239a-4b51-8ce5-079208286f5c"),
Guid.Parse("3a2e8e78-b0db-4a9e-b31a-a559bea4f192"),
Guid.Parse("3a2e8e78-b0db-4a9e-b31a-a559bea4f192"),
Guid.Parse("68a6550c-b1d8-4535-af71-dbfdfc322485"),
Guid.Parse("6a5ee804-aeec-45b8-a375-76ec92ee251c"),
Guid.Parse("2ca65f91-c8b7-4789-b2b9-6238b45acfee"),
Guid.Parse("7dc3f562-b126-4df9-a009-c120808851b7"),
Guid.Parse("b7d8d96c-5711-4475-928e-29e977af7326"),
Guid.Parse("2dd63499-e6c4-414f-80fe-ce21d71ddde1"),
Guid.Parse("f2aef22c-a503-4a71-9288-f0701096bd6f"),
Guid.Parse("f2aef22c-a503-4a71-9288-f0701096bd6f"),
Guid.Parse("0cde0bf5-eeee-4ef3-a5e8-57ea51981378"),
Guid.Parse("28384d02-b7b3-4ccf-9091-27bfbf4bbdf2"),
Guid.Parse("28384d02-b7b3-4ccf-9091-27bfbf4bbdf2"),
Guid.Parse("28384d02-b7b3-4ccf-9091-27bfbf4bbdf2"),
Guid.Parse("d5fc7368-386a-4b60-971e-4b0a9e03560d"),
Guid.Parse("8530c056-aebc-46e2-b201-9d1d27e1ffce"),
Guid.Parse("8530c056-aebc-46e2-b201-9d1d27e1ffce"),
Guid.Parse("e65d8481-d3ae-4a3a-8999-1b95a755ed1b"),
Guid.Parse("fc41aa6a-f7d0-46d2-ad21-fed27a7c418b"),
Guid.Parse("7b7bdc59-921a-4d3e-a29c-0baaba46d031"),
Guid.Parse("5cba9be8-f61f-48be-951b-cabd12f2fc28"),
Guid.Parse("545360a2-2b97-4ef0-954c-2f058daabc78"),
Guid.Parse("3de266cb-0c5a-4755-bd38-36f3c4d4dfb6"),
Guid.Parse("7b5eed86-e4e4-4704-8a85-efb460f0fd5e")};