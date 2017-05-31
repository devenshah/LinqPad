<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.XML.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.Serialization.dll</Reference>
  <NuGetReference>AutoMapper</NuGetReference>
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
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	#region data
	var data = @"{
'@odata.context': 'http://pm-sp-api-partner-dev-learner.azurewebsites.net/$metadata#Learners(ExternalID,Registration(ExternalID,LearnerPrimaryClassMemberships(Learner(ExternalID),PrimaryClass(ExternalID))))',
  'value': [
    {
      'ExternalID': '9cb7d91c-976c-4a4f-81d0-b131ff0b65b5',
      'Registration': {
        'ExternalID': '9cb7d91c-976c-4a4f-81d0-b131ff0b65b5',
        'LearnerPrimaryClassMemberships': [
          {
            'IsDeleted': false,
            'ExternalID': '2d25e2d1-9263-4291-9c5b-88fe173457ff',
            'StartDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '9cb7d91c-976c-4a4f-81d0-b131ff0b65b5'
            },
            'PrimaryClass': {
              'ExternalID': '99056e10-8a4d-4fe9-8796-48a3c490adb6'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': '036e311d-c66f-436f-bb3c-036d8e34df0a',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '2001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '9cb7d91c-976c-4a4f-81d0-b131ff0b65b5'
            },
            'PrimaryClass': {
              'ExternalID': '760c6abb-54b3-46ca-a56c-82986809b173'
            }
          },
          {
            'IsDeleted': true,
            'ExternalID': '0fda5a71-1b94-4d38-86ef-00276f92f4cf',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '9cb7d91c-976c-4a4f-81d0-b131ff0b65b5'
            },
            'PrimaryClass': {
              'ExternalID': '760c6abb-54b3-46ca-a56c-82986809b173'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': '0fd1b3ea-8ad3-41af-b726-6e120bee254b',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '9cb7d91c-976c-4a4f-81d0-b131ff0b65b5'
            },
            'PrimaryClass': {
              'ExternalID': '788e33a4-36ae-4a38-ae14-b7b1d9ce7334'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': 'b08120b1-8dd5-476b-8308-c417eebca395',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '9cb7d91c-976c-4a4f-81d0-b131ff0b65b5'
            },
            'PrimaryClass': {
              'ExternalID': 'dab2f351-6f7b-42b7-9b14-14cdf8a8984c'
            }
          }
        ]
      }
    },
    {
      'ExternalID': '6bd5d405-63c5-47e2-a1e6-15a6ec185b36',
      'Registration': {
        'ExternalID': '6bd5d405-63c5-47e2-a1e6-15a6ec185b36',
        'LearnerPrimaryClassMemberships': [
          {
            'IsDeleted': false,
            'ExternalID': 'e3c99dd1-ab40-4eb3-8dc7-132f3afa5a61',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '6bd5d405-63c5-47e2-a1e6-15a6ec185b36'
            },
            'PrimaryClass': {
              'ExternalID': '6915ca4a-0213-4507-beae-1f9a27928af2'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': '3bc545a7-364e-4db6-b831-f3bef3886050',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '6bd5d405-63c5-47e2-a1e6-15a6ec185b36'
            },
            'PrimaryClass': {
              'ExternalID': 'd45adf1d-476f-460e-bf69-b68d69b32fbc'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': '42ed7ffa-7912-4f3b-9fe6-3b189b3fca20',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '6bd5d405-63c5-47e2-a1e6-15a6ec185b36'
            },
            'PrimaryClass': {
              'ExternalID': '5d1c5578-ff6a-415a-9601-5c8d472143d0'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': 'd0284bbd-4308-4df4-a59d-ab24d6a312ee',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '6bd5d405-63c5-47e2-a1e6-15a6ec185b36'
            },
            'PrimaryClass': {
              'ExternalID': '1be94216-3a45-4e6b-812d-16b9c5d3ce88'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': '805cc081-60f0-4bc3-975e-c8fc179e33ba',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '6bd5d405-63c5-47e2-a1e6-15a6ec185b36'
            },
            'PrimaryClass': {
              'ExternalID': '5d1c5578-ff6a-415a-9601-5c8d472143d0'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': 'fee8d733-39fa-4a1d-8d4c-9ff6014be52b',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '6bd5d405-63c5-47e2-a1e6-15a6ec185b36'
            },
            'PrimaryClass': {
              'ExternalID': '1f38fa5a-0df7-4aae-999c-1b770c0db23d'
            }
          }
        ]
      }
    },
    {
      'ExternalID': '24687d9e-25fb-43a2-b3db-7423f7fd441e',
      'Registration': {
        'ExternalID': '24687d9e-25fb-43a2-b3db-7423f7fd441e',
        'LearnerPrimaryClassMemberships': [
          {
            'IsDeleted': false,
            'ExternalID': '2258157a-79a9-4a93-aa95-ac6666060bdf',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '24687d9e-25fb-43a2-b3db-7423f7fd441e'
            },
            'PrimaryClass': {
              'ExternalID': '3503120d-fea1-42d6-ae54-d24fc6cef786'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': 'cfb35ea9-3762-4413-8b68-ebc540535d05',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '24687d9e-25fb-43a2-b3db-7423f7fd441e'
            },
            'PrimaryClass': {
              'ExternalID': '5dbefd27-162c-4534-a2a2-c9b3823f09c1'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': '83fd7869-61ee-41e3-a55e-87cb2e3cc0eb',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '24687d9e-25fb-43a2-b3db-7423f7fd441e'
            },
            'PrimaryClass': {
              'ExternalID': 'dab2f351-6f7b-42b7-9b14-14cdf8a8984c'
            }
          }
        ]
      }
    },
    {
      'ExternalID': '2761cc2d-ea83-4a58-ae6e-abb3b5ec1400',
      'Registration': {
        'ExternalID': '2761cc2d-ea83-4a58-ae6e-abb3b5ec1400',
        'LearnerPrimaryClassMemberships': [
          {
            'IsDeleted': false,
            'ExternalID': '58ea3d68-3571-47cf-aa43-7e814254a906',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '2761cc2d-ea83-4a58-ae6e-abb3b5ec1400'
            },
            'PrimaryClass': {
              'ExternalID': '3503120d-fea1-42d6-ae54-d24fc6cef786'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': '182d87ec-19b9-4e15-8e71-a536aaefe6bc',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '2761cc2d-ea83-4a58-ae6e-abb3b5ec1400'
            },
            'PrimaryClass': {
              'ExternalID': 'd45adf1d-476f-460e-bf69-b68d69b32fbc'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': '973a0cd7-57f2-444f-9ea2-3b7f722424fd',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '2761cc2d-ea83-4a58-ae6e-abb3b5ec1400'
            },
            'PrimaryClass': {
              'ExternalID': '3503120d-fea1-42d6-ae54-d24fc6cef786'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': '47fc09c4-dd70-4b1c-95dc-24a31b8984bb',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '2761cc2d-ea83-4a58-ae6e-abb3b5ec1400'
            },
            'PrimaryClass': {
              'ExternalID': '1be94216-3a45-4e6b-812d-16b9c5d3ce88'
            }
          },
          {
            'IsDeleted': false,
            'ExternalID': '6d117f66-7875-43eb-a45c-89cd32224037',
            'StartDate': '0001-01-01T00:00:00Z',
            'EndDate': '0001-01-01T00:00:00Z',
            'Learner': {
              'ExternalID': '2761cc2d-ea83-4a58-ae6e-abb3b5ec1400'
            },
            'PrimaryClass': {
              'ExternalID': '6915ca4a-0213-4507-beae-1f9a27928af2'
            }
          }
        ]
      }
    }
	]}";
	#endregion

	AutoMapper.Mapper.Initialize((config) =>
	{
		config.CreateMap<PrimaryClassRegistration, StudentGroupType>()
				.ForMember(x => x.StudentGroupId, o => o.MapFrom(j => j.ExternalId))
				.ForMember(x => x.StudentId, o => o.MapFrom(j => j.Learner.ExternalId))
				.ForMember(x => x.GroupId, o => o.MapFrom(j => j.PrimaryClass.ExternalId))
				.ForMember(x => x.StartDate, o => o.UseValue(new DateTime(2016, 9, 1)))
				.ForMember(x => x.EndDate, o => o.MapFrom(j => j.EndDate.HasValue ? j.EndDate.Value == DateTime.MinValue ? null : j.EndDate : null));
		//.ForMember(x => x.StartDate, o => o.MapFrom(j => j.StartDate))
		//.ForMember(x => x.EndDate, o => o.MapFrom(j => j.EndDate));
	});
	var jobject = JObject.Parse(data);
	var groups = jobject["value"]
				.SelectMany(x => x["Registration"]["LearnerPrimaryClassMemberships"])
				.Select(x => x.ToObject<PrimaryClassRegistration>())
				.Where(x => !x.IsDeleted)
				.Select(x => new StudentGroupRoot(AutoMapper.Mapper.Map<StudentGroupType>(x)));
	//groups.Dump();
	//SerializeObject(groups.First(), "http://www.sims.co.uk/CCP/TransferStudentGroup").Dump();
	groups.Take(3).ToList().ForEach(g => SerializeObject(g, "http://www.sims.co.uk/CCP/TransferStudentGroup").Dump());
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

#region json models
public class Identifier
{
	public Guid ExternalId { get; set; }
}

public abstract class GroupRegistration : Identifier
        {
            public Identifier Learner { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public bool IsDeleted { get; set; }
        }

public class PrimaryClassRegistration : GroupRegistration
{
	public Identifier PrimaryClass { get; set; }
}
#endregion

#region xml model
[XmlRoot("CCPTransferStudentGroupRoot")]
public class StudentGroupRoot
{
    public StudentGroupType StudentGroup { get; set; }
    public StudentGroupRoot()
    {

    }
    public StudentGroupRoot(StudentGroupType studentGroupType)
    {
        StudentGroup = studentGroupType;
    }
}

public class StudentGroupType
{
	[XmlAttribute("studentGroupID")]
	public Guid StudentGroupId { get; set; }
	[XmlAttribute("studentID")]
	public Guid StudentId { get; set; }
	[XmlAttribute("groupID")]
	public Guid GroupId { get; set; }
	[XmlAttribute("startDate")]
	public DateTime StartDate { get; set; }
	[XmlIgnore]
	public DateTime? EndDate { get; set; }
	[XmlAttribute("endDate")]
	[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
	public DateTime EndDateSerialized
	{
		get { return EndDate.Value; }
		set { EndDate = value; }
	}
	[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
	public bool ShouldSerializeEndDateSerialized()
	{
		return EndDate.HasValue;
	}
}
#endregion