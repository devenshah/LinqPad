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
  '@odata.context': 'http://pm-sp-api-partner-dev-school.azurewebsites.net/$metadata#Schools(UserDefinedGroup(UserDefinedGroups(IsDeleted,ExternalID,FullName,DisplayOrder,UserDefinedGroupMemberships(ExternalID,StartDate,EndDate,GroupMember(ExternalID),UserDefinedGroup(ExternalID)))))/$entity',
  'IsDeleted': false,
  'ExternalID': 'f2e1813a-b266-42f2-b786-43e1a5bc3da1',
  'UserDefinedGroup': {
    'IsDeleted': false,
    'ExternalID': 'f2e1813a-b266-42f2-b786-43e1a5bc3da1',
    'UserDefinedGroups': [
      {
        'IsDeleted': false,
        'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7',
        'FullName': 'SEN Students',
        'DisplayOrder': 7,
        'UserDefinedGroupMemberships': [
          {
            'ExternalID': '04bf97a1-cace-44fb-a6be-cd62e96c3256',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2b6951d5-6729-4701-bc47-719907302000'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '09effc14-fc52-4705-843c-d9c0779c8909',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '626535a7-c9f5-46fc-ac18-9ef5cf435d3d'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': 'f0c6e8ba-80a9-4cfb-acd5-bf040b43d1e8',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7270d247-d76c-47cc-9451-d069cb02e2d8'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '3fc2d48f-bc2f-4b7a-8e80-9d746f31164e',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1acea35b-9075-4a09-8972-e587697fbe62'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '904988f1-e186-4118-9986-44b1fdccf830',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b7d99575-0da8-42b9-9692-58ca6acba1f5'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '9adc0207-1b8a-4def-aee8-dd709184ec7e',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '39766146-52cd-4783-9d53-5bc4bd9e5549'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '21e5adfb-946a-46ac-815a-56daa45065fa',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2c1f7145-5618-434e-b2ac-a917c397dc02'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '9a86786d-2972-48e8-bd0c-b650cd6a44cd',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3be87ff8-d907-49e9-be4b-d58434a7fc09'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': 'ae5bcc52-e60b-40fe-b786-a16b15076cd0',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1d008471-cf7c-459c-8cc7-6d090bea5dfc'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': 'da8e6391-6e72-4b70-9ad7-8f93ca43555c',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ae4bef7f-832e-4317-9fa0-fce45e7e1062'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '047b5362-6ef4-44a8-a24b-c71458802405',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0256492e-cb5f-4c52-b08b-2c16d4efb043'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '81297e93-1142-4dd7-9c85-03aedf8d9613',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '17d7e768-5156-4aa3-abf2-a9f56a039683'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '7a27273a-9876-424b-bfa0-320b6195d823',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b6ba23bb-93a0-466c-bd06-5dab3f89a7e6'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '12710008-3a7f-4f2e-b4fa-631a37453356',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7d61cbdf-d07b-4621-bd77-21ecb695695e'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': 'c5b7cf69-d67d-40d2-8c1d-4421a0b6b42c',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3cd1b199-0344-46b7-a679-150f547a63b0'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '03f80246-aac4-4d6f-9e02-6e4d129ff99b',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4f7596ba-d606-437f-85a3-e3630306dbb8'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': 'd44393ea-477f-41f0-85a3-66a30965449d',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ae12a1b2-4a9a-4150-aa56-9effe105313a'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '1cca235e-775c-4c39-919f-bfe2a17d5c9c',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dc9276da-542c-44a9-96af-05f82e1e4277'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': 'f1bdebe6-fb34-45ea-ba12-e8c823c205f6',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b5f083f7-8b63-4b94-b9c0-1163ab50ca59'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': 'dbc1c893-953a-4ee6-a12d-9367f8a7fb0d',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4cdd7f0c-8b7f-47ae-855f-1effeddb9616'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '65b65ffd-1b78-4dc3-a77d-8b7ca6d335ef',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '019b4ca4-7974-4ae0-af18-2cdd4595007b'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '3b859ca5-099f-4ee4-ac51-53c6ec432411',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '74704234-6029-4fac-b1d4-98cc30625f54'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': 'e41a73ec-2fc4-457a-9567-babf32ef75b6',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '10a29c0a-cf9e-4681-87e4-d7a4a1d2db94'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '41e624ac-0bf5-4485-baf2-c886859b6c75',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '24e90747-e125-4480-a04c-3b1525983f1a'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '45bde51b-96be-4ca3-9294-053339e6a15a',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5083a372-baf8-4de0-89f4-f2cbc82a7677'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '19f6729d-928b-437b-aa5b-f43296884fc2',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2d91c0fb-682e-4664-8dfc-62fe5adf7061'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          },
          {
            'ExternalID': '55ed0838-f181-429d-9947-53c704703a90',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a0cdf9fd-270d-4b92-b030-16fe70c7e8dc'
            },
            'UserDefinedGroup': {
              'ExternalID': '310b6abc-eb0f-4775-ac51-6916b4e9bec7'
            }
          }
        ]
      },
      {
        'IsDeleted': false,
        'ExternalID': 'ecb7634b-1362-4851-a72f-746e74d210b3',
        'FullName': 'Year 6 2002/03',
        'DisplayOrder': 14,
        'UserDefinedGroupMemberships': []
      },
      {
        'IsDeleted': false,
        'ExternalID': 'f1624699-fb7c-4e61-be8a-c089d4771537',
        'FullName': 'Year 3 2000/01',
        'DisplayOrder': 11,
        'UserDefinedGroupMemberships': []
      },
      {
        'IsDeleted': false,
        'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b',
        'FullName': 'Poor Attenders',
        'DisplayOrder': 5,
        'UserDefinedGroupMemberships': [
          {
            'ExternalID': '77b142d1-3784-4564-97ba-677c5f1d3bfc',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a2c55667-f98b-4fa1-bd8d-15c20e8aba9b'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '756fee5c-3a43-4a40-abab-c2eb056cf2fb',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0b09b629-b9b8-4a33-8ad0-c8a5845cf08f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'fe0cc708-d726-472b-b151-d44445ca0c97',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'eb6ff129-3fa1-4b49-a728-a2a3b2d7b923'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '36a3f3d4-0a9a-4a5d-990d-ca30e9b1ed22',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'eb6ff129-3fa1-4b49-a728-a2a3b2d7b923'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3caf4134-3053-43d7-9aa7-1ce6a320caef',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '117b2705-9b7e-4874-abae-3f23350b0c43'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8a58cdd4-c437-4649-8e40-ace72f09cbf9',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '117b2705-9b7e-4874-abae-3f23350b0c43'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c452b30f-1717-46e3-bf8a-ed5739c0096f',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '26e1eb8c-bf65-46f2-9a10-05d7342ce1a6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '1162b97d-b63d-402e-b443-ef30fcf733b7',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '26e1eb8c-bf65-46f2-9a10-05d7342ce1a6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'ad25c58f-da37-4f66-b9de-b86bcc253c3a',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '26e1eb8c-bf65-46f2-9a10-05d7342ce1a6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e59570fc-a0f4-4425-8962-79a9ad89f4ee',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f7cca30a-7477-44ba-92c6-485f045e29a0'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '5d5343cf-3d61-4c26-b8a3-3b65c7c02b7e',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e21481c2-50cb-495e-a4a7-ac85c54f0bbb'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '69600dfc-e78d-4632-ab40-8c9bfb3aff0b',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '344ff016-e08b-4407-ba00-7290a2bf2b4d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '959b66d5-9aa3-41ba-ba5b-1d3cb74f15ae',
            'StartDate': '2015-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '344ff016-e08b-4407-ba00-7290a2bf2b4d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'df92f0b5-9315-42f7-acc7-c81fdb578def',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'da5f4d4d-275c-4d66-8c40-6966c44ee22f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '5877bbd6-4c79-4be6-9f1c-73e2effc21e0',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '55f254d9-a573-48cb-950a-1158db386591'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '98d7a943-1047-44fa-84cf-0e49503cc5fb',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dbec051e-51d4-4b1e-999d-c0f01b4bd706'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4ce3fbf0-0f4c-4e47-85be-4d219a041127',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dbec051e-51d4-4b1e-999d-c0f01b4bd706'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'b3e1b865-021c-45a9-9087-a6b0bcd28e5b',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '07a76e76-5d10-42eb-aa13-6a15bc4f73cb'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'be2dd104-5913-4514-88ed-0087f1e219e3',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '51051b85-abd5-4699-b7d6-2be77041c03c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '49c99aea-8f53-4f5e-ba78-f6b3cd060d67',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8eb0a37d-6430-4bbc-82fc-a974cbe967e5'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8c98e212-a9cf-422a-9565-3ce140937806',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f42ec473-5ee5-472e-bbd4-174968092814'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'ba1ec71e-bcca-421f-ab89-c09a75bd40fd',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dcf04bc0-7c1f-47f4-a510-350730f4f090'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd1b2afb1-9f7f-4f56-a27d-60021469bdfa',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dcf04bc0-7c1f-47f4-a510-350730f4f090'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '39768cae-91ac-4a0d-8857-a5fe4dfdf3a7',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'cc392191-c47e-441a-8a4d-49273ede7408'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '6d28a09b-0d7c-4640-b361-50c7bf487988',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '37f76ec2-b6e5-4cf1-8ad5-bee7cadc1d07'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd7451693-16a9-4fa9-9fb7-06d9ded3033d',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7d368164-a9ad-44a3-9d5d-9a8355814836'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a5f4090e-771f-465f-9136-870eceba0ad8',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a3cbd34c-ade7-43ac-aec7-84c3a0fa0fb8'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '67c4f744-3b6c-4d84-af74-34aefda75d30',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa94e5c5-0c8d-490b-9a8e-05583605110f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '736092b1-182b-4661-ab44-fc170a156644',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa94e5c5-0c8d-490b-9a8e-05583605110f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '594979c0-d60a-4a1e-ac07-69ba822dc35c',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'be9103b7-a4d9-4d1a-b3ab-4e8c6f504880'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e04e49ae-4958-43e3-9d2a-a7e3faeb05a7',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'be9103b7-a4d9-4d1a-b3ab-4e8c6f504880'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '7daf6140-9028-489b-bd0f-ef7e4ee0d2e7',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8d7cde74-7680-486a-bffd-014fd6fcd012'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '2d177d05-40a3-49f5-a200-c0312006b515',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'baf7e21e-b0e8-4811-9774-544c8b2cdfea'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e9ff28ac-666b-40b7-bb68-36fc48d94a2f',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'baf7e21e-b0e8-4811-9774-544c8b2cdfea'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e58d66f4-474d-48c4-8c6d-6d8f7cb6bba0',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '14c73bbe-6e2a-4262-bb9a-001798022a37'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '9291cb14-2b39-420c-8c5b-76e0c13f4df0',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8e9fc366-8f6f-4095-b1b7-c88ccb6d4562'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '68557f4b-7a53-4ee0-994a-fb453ce65c06',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '121b49b7-c4ae-4685-beeb-4a9504ae6e23'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '34b13902-62c7-45ae-958c-d7f0e869a8f9',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd08e8f62-d5b4-4d0e-bdbe-0bcf52a4c8a3'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3297e6ff-f95d-48e8-9ff8-eb4790fdc8ec',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd08e8f62-d5b4-4d0e-bdbe-0bcf52a4c8a3'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '0deeb8aa-dc2c-44eb-b51c-20c15ed73dd4',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'db0d9dab-637e-4b78-9190-3aaa00c6e64c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '1234a709-9fde-4657-867b-e40c18036a14',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '59db1a32-d178-4ee4-befc-16d6821b2006'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'dd2ce202-79cc-4b85-b00e-59bc8d29a3a3',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8070a575-11ea-408e-9726-82eb39c8bd19'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd9625d83-d252-4931-8a4d-ff8d9d4a06f0',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8cf6716b-4107-4c30-b0a6-1ac37b7f4b34'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3ee20858-db4f-4fd0-a2dc-b759d2a24a5f',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9d51a755-fa32-4d8b-8a5e-a81db575a65a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd84122fe-1b07-4a13-84b3-68aa799a3ece',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4ad9977d-893b-4251-83da-9b5990c9ee35'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'ecbf2d3d-0fb5-485f-b789-1b31ed60e18a',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '629311b9-fdd7-4427-a601-266f6ea54763'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c57ea016-ad09-4304-bc16-28413f69a274',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '05eaea7a-bae5-48bb-9b6a-a8a690e71387'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'b86911e8-4af1-4a8c-a7fe-a47b8e3312fc',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '102016e2-c15b-4d2b-a000-a160d87cdd45'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '838eb718-74d3-4060-a80f-0036df541262',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '102016e2-c15b-4d2b-a000-a160d87cdd45'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '9d3060e5-01c1-49c0-b963-4f5dfec4ca38',
            'StartDate': '2015-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ed7e8768-65cd-46ee-8138-fe9775763bbd'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'f798fd9c-451d-4d3e-aae0-5d020ab9c840',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ed7e8768-65cd-46ee-8138-fe9775763bbd'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'b52075ea-c57e-4076-a43c-38884d6f3ef9',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e41ad219-7681-43e1-b89a-c500bf5f776c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '50ebcf88-9fc1-45f6-b815-1e1d8759a3d8',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '54462a29-32f7-4ba8-a106-18d3e5d04910'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '10c02837-df63-4863-806b-989f6d9c1b31',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0fcfd536-934c-406b-862c-1e40c7c514ec'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'fe442212-e2d0-43be-b7a8-18bd3c2e78dc',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd7f7d109-d433-4162-8bfd-d799f8eb5089'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8c1ff6d3-4241-4768-8fbc-37b1cf0fd2de',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa4b5b0b-70fb-4d5e-af56-c3547eaac704'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c24c3cf8-c07c-4c69-9b62-e9139ed86f77',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '65237838-0e59-43fc-9421-1821a89aba6e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '2ee8ba10-5e33-4ae3-bf2a-9ee6748a0fe5',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7223841d-968e-4def-ac9a-5752a53b46ac'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'f1f276fa-7449-4f1d-985f-3de42e4eb20f',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '95aa9ac4-ec74-4eff-9975-820d2dd90913'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a9cf3545-a9a3-43e1-b89a-2b28a97ef7d5',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '701d0f3e-6c27-4c74-8077-26fd53be6ea7'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '22e38387-2851-4fbc-b874-a44362d9fcd6',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '701d0f3e-6c27-4c74-8077-26fd53be6ea7'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4006c635-c851-472e-bba0-8baa6b70f1b9',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f928b42a-f4ec-4841-aea1-ebf94af13684'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '6d32f9a2-72b1-421a-971f-eaf8ccab1881',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f928b42a-f4ec-4841-aea1-ebf94af13684'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3e3681ca-f063-4a4d-9d54-75d2b0abf4c1',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1e109a20-9b07-446c-8dce-4c9fc74dd3c2'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '9a64cbcd-77c0-4493-a267-4839db3c90a4',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd7b0d447-9401-46b2-a2ee-0cf3b5288727'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a36de513-0d3a-471c-bc48-3fb45ce9dcce',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c7a58a79-eb52-4fb6-af8d-e7d8f659c94f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '70b7be7b-4fbc-4762-80b0-e320f0764149',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9db911d1-32e4-4c8f-83cf-e7495407a612'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '038cad32-ba5b-4467-8d9e-399dec704474',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e8c61d62-7e1f-4628-aca6-b9333d81f352'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '5423ab27-2c01-4a35-87c4-b059a80af192',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b09124f8-248c-41c1-96c0-35b03927ed1d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '680f06df-619e-4019-98ef-5cbed4b4fb16',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5c662db8-a0db-40a7-85c6-a950aed28fba'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '6d124010-fc12-4cae-8347-56865a67bb4b',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '626535a7-c9f5-46fc-ac18-9ef5cf435d3d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '439b26b5-8783-4624-b03c-6f1342b5ba68',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '626535a7-c9f5-46fc-ac18-9ef5cf435d3d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3dad43f5-23c8-4ac4-9983-c97f792933e7',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '626535a7-c9f5-46fc-ac18-9ef5cf435d3d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '912475f9-3404-4206-bcce-8699b10d25cc',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dfb1cd19-62bf-4f74-9de0-e0f704ae1328'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'b0626c21-7106-4bf3-a898-ceb875b07928',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7f71098a-f3b0-4ca3-b06a-2c6b37c778b5'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'af87b7eb-b502-4ce3-90f1-8c502b39e09f',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a0390ddf-d085-4e72-a05d-3fd4fe82e478'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c47e380c-bf9a-4d57-b0e8-f6a2deeeb600',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ed3148f1-42ab-43d4-a0f2-b7775ad7a6b4'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3e1f9240-df92-4b05-84ff-2293710f818b',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '633bbb12-04ce-4191-aa69-eeff0ca22ad9'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '48c778d0-83e9-425b-a748-467fda854b9a',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'daab8f1c-fa18-44e7-b66e-63e9bf7274ff'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3d22d42d-bd60-4d96-b882-56d58bef616a',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ff8b6d21-295f-432e-b271-5d6e64d6f24a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '29d647e1-b1de-4b4b-93d7-85c4d5d47ca9',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ad5674f0-d5d7-41c2-94d6-f8cb12a94966'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e2fd55cd-0624-460c-a350-cc916ca6abf5',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f3eb8a20-b931-4d5b-b552-c21f1ebbafc0'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '1099414e-b9e5-4c5b-992a-4e421a14aa77',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '87714ab3-6707-4fc5-9a5f-ae50d56028e1'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c29ad60c-1425-4f3a-bdb0-0919285067dc',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9a5a49dd-afb9-48fb-b34b-098b1c6aaff3'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '06350f57-5325-4bcb-8c87-45f9a71bfedf',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '27d65f64-859a-4ae1-baa0-8045839fb15b'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '7b3b3644-42fb-4e51-aa43-2be605f5518b',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e697f1d5-9418-4110-b998-c2ebc21f21fc'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd8951093-0e60-4597-942c-a474e611b3ed',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1fb50a7f-57fa-4cf1-8da7-35714cc72dac'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '72410831-4369-44eb-bbd3-966b666e4100',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '89f02f4d-0aff-47c1-a374-1ed375de7898'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '1c35b971-275c-4a11-a6ab-d8f0e64e7884',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c06945d4-f8d3-49f4-a9eb-29821b51bbee'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'b4b7ad14-92d6-4d38-84f3-f68c548549be',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bce85ff3-c226-47d2-8feb-73388ca8d2a3'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e737926c-1f0b-448f-9860-2fe957559c22',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '08125148-f444-493c-9dde-5be90a464ead'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3b92c7a2-9153-4296-9792-d9d4a901f6ea',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0e9a460f-2398-4752-ad53-2f0b452e61b9'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '1789b4e4-5e90-4838-b97a-74292638bc3f',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0e9a460f-2398-4752-ad53-2f0b452e61b9'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '2b62fa42-2326-4a20-9752-03efb3fbb5bc',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0e9a460f-2398-4752-ad53-2f0b452e61b9'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '5c6cce94-ea65-461f-810c-5eb93b536fa8',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8a43e952-3541-4914-a14a-b5069c48ab53'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '93b745d1-139e-468d-a040-fd6d0cd14c48',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '133895e0-9a9e-4e77-9f8a-aa54b455bcc8'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '0a5fd35b-b2dd-49c1-a7ff-e67dabbdbed1',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'efa3c626-5c1a-4f84-9fa7-ba24571eb809'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '76535c0d-3d4e-45de-9fa8-e521a7db13c5',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '52072245-7344-4eb2-89b4-00751cd475ba'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'de3aaa0e-4a52-4b42-9807-4ab98943adad',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '60e9daf9-011d-4cbc-829a-35d1b343e4d9'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '92082ba0-4a80-4f64-991d-a13093520ea4',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c0bd3346-4d3f-432f-9823-4cdf9f8c6d26'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '1b253156-b6c6-45e5-814f-78a6719ab06e',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b233ec2d-6641-4aa1-b69a-dbdc5d7d868e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '97db0a57-a3db-45ae-b8f5-98a4af13c4d0',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b233ec2d-6641-4aa1-b69a-dbdc5d7d868e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'eaaab4df-11ce-4014-b0d9-eab445b733a4',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a7cb944e-f7c7-4d55-aff4-0c5567a06f41'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '6e7ac33d-9208-408f-b88b-77dbef7b78da',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5c770208-2596-4a04-8d32-7f2ce3c12f5c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '769a64c4-f152-4310-993b-fd41e1a80a40',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9b5bbb61-1e82-4cd8-a012-1987046c01e1'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'b354a577-019a-4fee-b65b-07cc5bce1a45',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c004b697-0226-4ae0-82c4-fda8c8fe34bb'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'df0057b2-cb27-4d26-836f-bc37a1100a29',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '32c43370-626b-4660-85ac-b21567e76899'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '89ae1fe9-714c-49c8-b628-98edbd06ea5e',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c23bbdde-c30a-4946-8a93-313bd92e4e91'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'ddbb2dd1-85d0-4127-bde1-1777ec3acec7',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2d6c0b9c-8c61-47e1-80ae-51a9c2b76cf4'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '87acf107-bf49-412f-a5e0-e6283f7b0627',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2d6c0b9c-8c61-47e1-80ae-51a9c2b76cf4'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '7d399466-7b85-4cc9-859b-12ac6eef0519',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2d6c0b9c-8c61-47e1-80ae-51a9c2b76cf4'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '76405a48-f005-43d5-90fe-7635a837aa6e',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a4f60f83-69e5-40b4-a45a-039c91e9524b'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '441dc783-7076-4e3f-869b-79c410f044f5',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0c0d32b4-96a8-40ca-903e-559d37ddc86b'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '016a0f1e-572e-42c7-8161-153ef8ad6a3b',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0c0d32b4-96a8-40ca-903e-559d37ddc86b'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '36025a0b-ab37-4fb8-baad-88875d63288b',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0386e19e-695e-401f-b3b4-2ab59895e520'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '138b4c27-664a-4f1c-a116-108dec3769bc',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b1b5e61d-feae-438a-843a-2f9651e291b7'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '06debf30-f8df-42e1-93c3-08b177c79773',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '413d5cae-549c-41ff-a730-ec2a9684f863'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '45f61d91-ac0f-4491-a2e5-853c6b998b34',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ea87972b-7a92-435d-a715-f0389adb9495'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8ea15196-05f3-4e55-bf92-205e10aeb616',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bfb0f27c-8539-4f2c-a55e-1e7ec09a3bda'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '0c7ac612-d7b3-4f3a-ae34-9d73da41e638',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '27ae65ff-5e21-4fae-8eeb-450962e418b0'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '06bc31a9-1151-43e3-8a94-065b2ff64714',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '27ae65ff-5e21-4fae-8eeb-450962e418b0'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a04bfd7b-7333-4ee2-b4a6-94f847b0d4c4',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5b7cd3cd-ea83-4329-bf36-9e07efc3afbf'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e37f928d-03c3-46c3-a941-d3335549c9fa',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c799e74c-639a-44a2-8a2c-5a0dc13c7ca3'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '887c17ca-89d8-4ba8-b416-4e291a07658a',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '869ccebd-ce22-443f-a9bd-e7f19fdccfb5'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4338ed97-0a82-4770-80b2-7cd5bafa0855',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0cc2200d-1a68-48e8-b2d5-91ff4e9c5908'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '10cfad56-6a57-49a2-a560-73adc6cae51f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3b934f31-8a4a-4c43-ac6e-9aa5a57a0448'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '6be1ec97-8606-4050-a08f-4c1d72bdd7eb',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '23705a51-98cf-465c-af7d-b6249f11de50'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'f3532ed1-8a8b-4a99-8ba2-3fc603c1020a',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a43c52bf-2e4f-4a86-8fab-428cfa65c0a0'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '7e342423-bf9a-4004-a402-af450f7c893f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '125067f7-3ce9-4d55-95f4-847eb2891b4c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '561db89a-3d82-4321-a52a-27b04efe92e1',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3a0c3643-1a59-4e5f-9abb-b968ae677b7c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '530b3ee4-e313-4edd-bbe5-6a61f8cefb25',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '858bd508-d772-4e84-82b9-1dfadb1e0d83'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e8d97e6a-babd-4904-ade2-d7bdb3740183',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '858bd508-d772-4e84-82b9-1dfadb1e0d83'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'f6ebfd24-785e-4b4e-8edd-88ab79ccd4da',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'be61ba83-0e76-47f3-a216-5ebec4f4a8af'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '777bf9bf-ca9a-4640-8380-c1cea757e920',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2438d965-38ce-4a6a-9642-23ed79202a37'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'dda15126-3292-4442-ab9b-8bd3369bf9fb',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '40e44486-aa6c-43ae-9eb5-2bc8e566dfe2'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a48628e7-493a-4079-90dc-3be159dbefaf',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '40e44486-aa6c-43ae-9eb5-2bc8e566dfe2'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '5bb279c7-b14a-4e97-9d6e-2726c4a83689',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e2473925-9fc9-48d7-b90e-85e2f5cfa761'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '10472932-54cf-446f-be04-340d9d99c6cc',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1fdd2863-b4b6-4444-8371-dd7c3618373e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8f051f03-7cdd-48d9-9e52-5edd3c925471',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a9277df6-c1c5-4944-b1d2-49ab3517318a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '348e7b21-5046-4033-9dd6-bd6e568eab60',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a9277df6-c1c5-4944-b1d2-49ab3517318a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '299922d0-7c35-4469-b8de-d537d6d639c5',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c174e4d8-e1fa-4be1-8b39-c4636c1bfae4'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'adaf5dec-0bbb-4f18-9ef8-e1de2a299950',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c174e4d8-e1fa-4be1-8b39-c4636c1bfae4'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'b4520453-8fdb-4fd0-b277-46fbff978549',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c174e4d8-e1fa-4be1-8b39-c4636c1bfae4'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c0027150-6a7a-4d2c-a289-9bac9f279034',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ebef022f-c2aa-4377-9b98-2b96a24dc42d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'fc0ffcf5-d515-444a-ae97-4e0964d0ade1',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1b5edf41-557c-4a67-a16c-d2e9e8c3346d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '6624c15d-5e6e-47c8-8758-c8ad0bf97f42',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1b5edf41-557c-4a67-a16c-d2e9e8c3346d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '044c444e-e854-426e-91ca-d6a6037d9db7',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2eb2cb93-56f0-4054-be55-e9fd70f9167d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '77e17104-b1ea-4e6e-847b-6127d1112973',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2eb2cb93-56f0-4054-be55-e9fd70f9167d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'f2307cb9-4db8-4942-b112-942f343e636a',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd3dedc64-cf26-4973-8cd1-ea6418f8d83a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '877ee99c-8568-478e-892d-188cf7927e3f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b465066a-f14c-4b01-b136-fd21bd44473e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a1d5f2da-e9c1-4909-b8f2-1f4b20db7b74',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b465066a-f14c-4b01-b136-fd21bd44473e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '08c7911b-f10f-4d45-ae8c-6c6fa1448d5f',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'cbd8f3bb-80d8-45ab-87d5-ab7fa60d3e2a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '88e9a504-911c-459b-b822-f3baf7eb53f1',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8888aa6c-9043-4987-935b-635586d62c22'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '97c13f58-51dc-4fa2-a2b8-054de2f69e94',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4003ba66-67b2-4990-8a3a-ea702108d693'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '6aefba4f-1a0c-4811-a025-b108e63f41c7',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a1664f00-c7ca-4a18-91e1-7c8598ea844c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '80465106-b010-4b97-9de4-f41939f2db44',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a1664f00-c7ca-4a18-91e1-7c8598ea844c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '65906b3a-1208-4c23-8509-e2426fb62cce',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a1664f00-c7ca-4a18-91e1-7c8598ea844c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3e6d4bc5-e255-4d42-afcf-9160da8cdbd6',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2af99673-4d01-4eb9-a8b2-92c872b90414'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'b34fc728-8191-4f90-9b84-51e83008cb70',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2af99673-4d01-4eb9-a8b2-92c872b90414'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '82675664-7cc5-43e8-bb48-8515de7246a6',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '02dce0b2-2b57-43a4-bf07-ff72a453cb4f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '51d84116-37a2-4a68-a6ea-07846bdd2ff9',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '02dce0b2-2b57-43a4-bf07-ff72a453cb4f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '51417121-4eee-4c94-b5d0-9b553464afde',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5797837b-be0f-4290-b49c-ae84cf78cd26'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'aaa428c1-8b86-4d26-a744-9428f35db486',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '83aaf00a-f26b-4728-baa1-ab76539de6c6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '14ff1592-7c63-47b1-8914-a8ab9b200b91',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '83aaf00a-f26b-4728-baa1-ab76539de6c6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '2f526d6c-4278-4359-aef7-8cc87e3156ed',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '72e6a25f-40b9-4f7f-817b-d6518b774593'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '1046842e-d71e-4b94-b7ac-0e954cfc7dc8',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '72e6a25f-40b9-4f7f-817b-d6518b774593'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '72304b3c-6851-4ed5-81a2-892457768302',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1d008471-cf7c-459c-8cc7-6d090bea5dfc'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4498abba-eb25-452e-a8f7-b826596b5d15',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c44ab97f-fa89-440a-9e75-fea7f5bf08af'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'ec8187fc-f83e-4863-905c-d9f9a161ef5c',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9ec2e96c-5b83-47a7-9759-3801775fc64d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '11079398-e64b-4488-b5f0-8f130f2e992c',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '467d3d1f-5547-4835-bb29-5f0b58c53fce'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd8f93104-5270-43a7-9a28-703d4b8bd6d2',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '467d3d1f-5547-4835-bb29-5f0b58c53fce'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c7ebc7d5-8086-4abd-b046-90aaee680e91',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ce084814-3271-46bf-a197-70fa4fe3c0b2'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '07ba48d2-4c5e-4075-9214-605f87623546',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ce084814-3271-46bf-a197-70fa4fe3c0b2'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '37590698-ab19-4536-8e06-95e5d6fbc33d',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '58ec71fb-06e8-4899-ba8d-4561709b7fff'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'b4564aae-1a30-4c6d-bb4d-019e60323463',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '58ec71fb-06e8-4899-ba8d-4561709b7fff'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a0108e01-667d-4977-9be7-ae1615365067',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b9f4643c-7604-4b4b-9699-75ec091d6aee'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '553bda2f-2dbe-4829-93bd-8033bb75eb93',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e2fcb1e7-a1a0-4bc3-8468-06bab73231dd'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8b5be989-23e2-4ee2-8462-a7aba00bd5b4',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '48565334-2e8e-488a-ac10-ca235765f275'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '5bc470a4-97c1-4037-b38c-56d4ba1de1c0',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7729c041-7e1b-4474-b0dd-38bb5eb8199b'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e71652c8-6b90-4fe2-91d1-7f2a15cc25b1',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'af09bab0-e3e1-4747-af3b-b64903332760'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd5547518-7879-4fb8-8c66-f9b95b902dfb',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ae4bef7f-832e-4317-9fa0-fce45e7e1062'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '2a47dfe0-d237-4b85-bfe5-044c2de78ba0',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '82afdf70-cd63-4aeb-a9dc-97ad7673e1e4'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '33aeefc5-e471-4285-a0ca-ac51e25cf247',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7b9ad43b-e293-4c91-897d-8686829004c1'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e5886246-2f05-4f9a-8ced-0918e6e955ab',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f142e9e6-9549-452c-a3f5-76ac0bde4a53'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'bace385f-a427-41c8-a6a1-2ac334c2cc02',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f142e9e6-9549-452c-a3f5-76ac0bde4a53'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4641ba5e-c504-49fe-9d73-8c1cff299864',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '56da59fc-eae6-48a2-8cff-5a998de83132'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '01556913-20cd-4ecc-9f0b-679153362df5',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c3c7d31c-14d3-45be-9844-c94e74c8f54b'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c712daaa-8cad-4e40-8717-9f0339e62df7',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0c501ac0-7683-4906-8621-f58831ed0da7'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'b1566c8e-93ec-4fb4-b663-991359143ade',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '867246ee-63b0-4f94-8c81-455816fecddd'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '42efa5fc-78e0-480d-815e-e0f03a94838d',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '867246ee-63b0-4f94-8c81-455816fecddd'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '00752bba-b3b3-4bab-9d52-f51151fee3bd',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'cd088cca-8069-415f-b95e-e19600a91d1c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '78c28899-3392-4793-953b-9e606af44e0f',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ff8ab8b8-8e9f-49bf-94cb-b7309c1405af'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a9f65c15-0173-44c8-9d73-ebd546590fa8',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '349fe092-168c-4a2a-99c7-30d133dd0ade'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '282a8f33-b3ae-4d8d-98ef-818cc8fdce7e',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '349fe092-168c-4a2a-99c7-30d133dd0ade'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a70dcb31-fa1b-44eb-815c-520d3aa7855a',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '41dcbabc-2b03-40b9-a99c-260ecf6e5f69'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '1efff051-364f-477b-97d7-c690bb9beeab',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '55df79d2-6f59-424e-ab64-7df62734abc7'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e5c0ec81-32f5-4c8f-9819-3d2ee3bbb111',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '98954fc9-14ba-44af-bb5d-72aa6f1726c4'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '2d633eb1-f8a4-482b-80bd-ee3ae6807134',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ffb7cb42-e357-4291-befe-791b395de2cc'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c455358c-19f7-4106-af2b-36f66fd33797',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f94e8ab5-d793-4f9f-984e-6daa9096e363'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'feac9da4-4dab-4f65-aae9-1a7b79b6bef7',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1ca13deb-5e0e-425c-a7a7-88e8226a0aa5'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c2a6a27a-3a2d-4743-a17a-052c0e3b8eb7',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e36522d0-5dca-48ff-9d16-f40cb2787c40'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd1a284e9-4507-47e6-909e-a1b3cd95cffe',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '79d71a52-8898-4699-9c8d-7aae0163d77b'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '2a105fa6-2b44-491e-994e-816a11c226bd',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a8b42526-b175-4366-82b7-e026ff7b3c5a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '387752ca-8177-485b-80de-be9245fb2567',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4fe0b91f-0d5e-42cf-88b0-c219663612ef'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '9d369991-cbe6-4f21-9263-20f3ee480601',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '56c95892-9adc-4b4f-ae34-57f12830f2a1'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '96f796f9-7a8b-4c4f-a7d6-610415baba5a',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0256492e-cb5f-4c52-b08b-2c16d4efb043'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4aaf6ba3-2335-44b5-b55c-b884a3839077',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9110b9f9-f326-428f-886d-8c8ffd6b6296'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '0544d7b8-93a1-489f-954a-c414cc70d936',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '88205095-2f3a-4d4e-86c8-69a38629534b'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4875cbed-c8a6-41cb-940b-0065cc1abaae',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1e3cfcde-75c0-4dd0-a186-8537b6b817f9'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '1f153454-5f0a-4e67-bf5a-db065e1aab34',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'afea1702-445e-4b0a-af30-58940dd72f8a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '103512f7-16f7-49de-89cf-591030b2a518',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a0a5eec5-f4fb-4a2c-a6e2-f36a686499b4'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '987933db-2482-4739-b5f0-43ba34538797',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e060958d-67f4-4b6f-9326-056f7b426538'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '96b1410b-329a-4e89-b933-470a935f2aaa',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e060958d-67f4-4b6f-9326-056f7b426538'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '38d19d3b-13aa-4f18-b3bd-accbf44861ac',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f15c89c0-9055-4f22-ad11-7da8ee9c0169'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4d333220-40a1-4487-aa39-e9c1af83db77',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '24b8904d-e0a2-45fb-b61c-e8b06702b717'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '279379f3-cf60-45e6-9180-e8a0ce3d8370',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a12e4633-29a1-4e8f-b803-8e72b13f77a6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '395bf809-a701-4c29-ae4f-7cb3bb68bc55',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f60ac953-20c8-4867-b9de-0203ff602464'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'bef06e74-e6f9-4b06-b50b-ef2aa9d07953',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3e854064-9f40-41a0-aed2-4ba4dbb0481e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e4e0add9-8645-4477-9c6e-a289e4152baf',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3e854064-9f40-41a0-aed2-4ba4dbb0481e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '807db74e-4015-4712-9074-db3b63692bae',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd7df542d-9362-4c39-89cd-8cbc02b06618'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '50d2c588-8ac6-411f-a8e5-d4312b621b07',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6742d51f-6f92-42ad-b1d6-ca15a27a3cdb'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd0916446-67f1-45ca-97bb-fd842694971a',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '542b9137-6ac1-4495-8e12-6a6a7166e88c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '19e7afdf-bb2f-4005-984e-32f4aab016f5',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8e20f092-91ba-4d20-af17-0ba17bb9abb3'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '68b706e4-4c7b-4a66-aed2-143987b4068f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ecd715f8-dda0-4b21-8468-b2bd04ef6bdb'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a9207d72-bc04-4449-9a51-9d17c19f4fc0',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b6ba23bb-93a0-466c-bd06-5dab3f89a7e6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '9126fa0a-695c-45cb-b02a-8580d6c00581',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b6ba23bb-93a0-466c-bd06-5dab3f89a7e6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c1c48fd1-fc9a-4b21-88b4-d28047e73d87',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '950399fe-c57f-42c0-8b7a-2ca9fa43e3b3'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8b439a37-303c-4a08-83e8-287cd5196a8b',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7b5760db-4b2f-4f37-b4af-b2420dde62e7'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'acc5f2d3-50de-4f56-b3cd-ac7011c6dee5',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b0670bc2-cef3-4342-97d8-f7186091d6bc'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '63977f7a-3126-4762-8318-1ea60725e513',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b738c26c-9c07-4e2c-af5e-8ce7c7978782'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c4376e95-158a-49a4-981a-7b2c21ab0cb0',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '109557bc-975d-4ae3-ba25-54f4010f6a50'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4052393e-8d24-4311-976a-bcb86825c23d',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '36d59fd7-9bd0-4b9e-ba7b-e83a08607d36'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '63946ed7-fb99-4c49-af5f-966eb637d481',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '36d59fd7-9bd0-4b9e-ba7b-e83a08607d36'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '636115ac-03ee-428a-b611-53fd9d446208',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7d61cbdf-d07b-4621-bd77-21ecb695695e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3025cf6c-a68d-4451-b0b2-fbb8abdae245',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7d61cbdf-d07b-4621-bd77-21ecb695695e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '93fa3601-73ba-4540-aeb0-ac2548ff5b90',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4917c092-afec-492a-9f93-77565d70c4de'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3b7ab86e-c2b0-42e1-9467-68b80e73cb6e',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4917c092-afec-492a-9f93-77565d70c4de'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '59b92a12-b778-4a59-824e-b26a70331d2e',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '96134b7a-fb1a-49a5-9865-e558fd918899'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '6dd79c5a-3f0a-4430-abf9-c812ab2da1fd',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '96134b7a-fb1a-49a5-9865-e558fd918899'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8a52f0f5-295f-43fc-8d52-9721a9b9f997',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5cd2367e-0eb7-4869-929b-6b3af5cf11e8'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '01de8bf5-6a56-47ef-9b68-61c65953f900',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5cd2367e-0eb7-4869-929b-6b3af5cf11e8'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '0ffdd241-b18e-4894-b9dc-06cdc0dfa723',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2e09f932-697f-4601-857d-cc72152822a8'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8f8cb746-6513-47e9-88cc-7aa24164e2ca',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a9e7a086-1fe1-401c-899c-d9e5040d0caf'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8b762c0e-cbd0-4a71-914a-6adfd821a521',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f6d88166-8b72-4c6b-a7bc-a8840c915a28'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '7955f9e1-2900-448d-be26-7fa7ebb5ebd4',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6efea621-e670-493a-8f81-fd916b32ed40'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '69e511e2-edb7-4efe-8079-3dbd04e12b97',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6eb666ba-e78e-4106-aca1-e04f9d918107'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '7767ae63-a453-457e-8d4f-d6f7317ef2d0',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bcb4e7b9-e795-4985-b747-b0331e9f2103'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '88ce3a7a-f5dd-4369-89b8-641280048004',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '749de4f6-7a99-441c-8a9f-946845c6dfb9'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a6fc9706-c5ca-4314-9a96-14d8a31a90a2',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '709c7260-38b3-4a33-b87e-7b76ca4f35f0'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '00cdce9e-5792-4886-82b6-9d1cda15c062',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ae12a1b2-4a9a-4150-aa56-9effe105313a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd273e880-4300-4776-92c2-efec56e61842',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2cd9e9ed-0438-4ad4-8183-83860faa6033'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3a4725a2-9816-4945-b6ff-41d6d03db46c',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '68e01f9a-7a61-45ad-8b06-e732db1dda0e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '47a04f62-5134-4f03-bcc5-eca0cad55bc8',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e9c3b083-a8c0-4c5f-8f78-9298d0c8ce65'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '0b056a25-5fcf-45bc-b94b-784a6f722efe',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd3882cca-ad2c-45d2-b0ce-f8b340f58565'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'eb63e616-9277-4aa3-bb7f-91884e936ddd',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd886ba02-1898-45a2-be64-248723c37b34'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '55ec6ca9-fb0c-487f-a9e5-02b0d3c8297f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd886ba02-1898-45a2-be64-248723c37b34'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '25bc6164-46a7-4d3b-99f4-a20d3f74dc54',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6f160665-b5bf-43bd-a9d3-14db89ebc914'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '6c432e40-6040-467b-85a8-38eb24d9fd61',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '64cf3764-0edf-4ef3-840d-fccd5c8a3cb6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '1ae0a4f7-f325-42c6-b065-d92335996e77',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '64cf3764-0edf-4ef3-840d-fccd5c8a3cb6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '439c1169-769d-4dc3-b73e-e58eca7446a7',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '64cf3764-0edf-4ef3-840d-fccd5c8a3cb6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '935eff13-9844-40fe-b52a-901890511cc3',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '64cf3764-0edf-4ef3-840d-fccd5c8a3cb6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e342ebca-4849-4b5d-b010-a4c063d5d263',
            'StartDate': '2014-09-01T00:00:00Z',
            'EndDate': '2015-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7706119c-d6fd-4d93-a598-950f92c10c9f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '92457c3c-c017-44cd-bb37-f6f0021db995',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f70361cd-d27d-4723-b564-4efe9dadab02'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4756c700-e5b8-4d41-b2f9-6d415e2f47ce',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a76105de-6d6b-4733-a402-f422572d45e0'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd8b3b17f-a5f7-4514-bbee-a17ec79ad0f6',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '75072220-817d-450f-8378-c48fc1e2f6a0'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '52682ca7-6b0f-4ab5-b599-c305d4be0f3a',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4cdd7f0c-8b7f-47ae-855f-1effeddb9616'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '7063acc4-513d-48d1-942d-cdaa0131fe74',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5c3d49a1-c48d-4d73-bb8a-e054d3c406ba'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '93760198-ac2b-43a0-a806-56dde4a132d7',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '460afa36-643b-4603-80f7-88ef9aa19123'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd3605961-54eb-4a85-a0d6-316198c8df7e',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '13940202-53c1-4345-9013-7a2e2bb6ee5f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '844cebc5-6bf7-49fb-92c0-4ce65b781807',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '019b4ca4-7974-4ae0-af18-2cdd4595007b'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '54fdcb96-0767-49d6-9e81-c23a9b140221',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '21f5d75d-f51f-43f3-871f-fe9980edf4fb'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a984dccb-d8fd-4193-98d8-6bb0713fb424',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '21f5d75d-f51f-43f3-871f-fe9980edf4fb'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '05b8667b-ad37-4834-9882-7cdf1be1d4b5',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a7bfd7f5-51b4-4004-b4a2-82fb4058a2ff'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4a499da6-6a63-4fba-83cd-994774e487d4',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5a86da92-db2b-4d38-b580-bc50636a3e51'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '57f7aca3-d308-4cd7-b6af-97c0f7e00e2b',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5a86da92-db2b-4d38-b580-bc50636a3e51'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c59e8efe-c8c1-4368-b65b-6c75895432d4',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fc60a8b1-f0e9-40cc-bf0a-a52be480f0a4'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '616107ca-69d1-472e-97e5-781a98b3a278',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2abdff93-11d1-409e-9777-edd1c9ddd510'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'fc3e71bd-ecd9-47cf-a1b0-3be7dfb8b7dd',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa7c82d1-21c8-4628-aff4-045908b5d6bd'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '00cebb50-3dd7-4865-928e-591a68326440',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a5f32fd2-6d83-4fa6-a68e-84c33e084d70'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a7b5527d-3886-4f8f-a2bb-8721416fff1d',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a5f32fd2-6d83-4fa6-a68e-84c33e084d70'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd4a39622-f4ce-4f24-9a98-289ce4dbf261',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f4130f8e-f283-4d9a-9209-57b34a2daf9a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a135fb9f-2057-462f-8b9d-867a4d1c4ff1',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6e8d4f4d-efe1-4681-932e-b28abc4e3685'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '61eadf82-9683-4ef5-ba74-c2ce5d95f5f6',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6e8d4f4d-efe1-4681-932e-b28abc4e3685'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'ca8c57c9-bca4-46d3-9e1b-786b087d3d74',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6e8d4f4d-efe1-4681-932e-b28abc4e3685'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '4e866141-47f9-4800-9475-43c49a775e09',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6e8d4f4d-efe1-4681-932e-b28abc4e3685'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '24f391ee-cf21-47ef-b698-83c4465bcf41',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '112a3a77-ee3f-4ec2-b92a-f7489800de2d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd78ea7bc-fb0c-44d9-b298-9c139fc5108e',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '112a3a77-ee3f-4ec2-b92a-f7489800de2d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '53946b38-bcf0-4a03-9dc5-1d55c22f1940',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '63bbd26b-9dd8-4f91-b1bf-62ba8cedbd07'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'bd3017ba-7bab-4fa9-88a3-d5844153fdb0',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bd47edc1-d2f8-432a-bbfb-6f7169fd950e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'dab181e6-3f20-4685-98cc-6a584f83eb62',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bd47edc1-d2f8-432a-bbfb-6f7169fd950e'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '5fc3e8e2-b873-4221-9d8a-e2e394e548e0',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '764bc854-5dc4-4e1d-9360-5e1d58c5fba0'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '95fecf89-0598-4aba-973b-c149eeadfe77',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c4d8f4eb-468b-483e-979b-8bf13ee72027'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8664e023-acc7-4535-a79c-f73a6aae56f7',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2c3309ac-80d1-4f11-8265-fd946e0de324'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'cf7e54ad-856a-465f-b52c-65016b7978c3',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2c3309ac-80d1-4f11-8265-fd946e0de324'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '0ca62c5c-dc02-4820-a0b7-47fc1217924a',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd7b8eed0-41a6-4150-8e4a-d01f495cd701'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '576aa4f5-fef8-4436-a850-354ed7350f1b',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd7b8eed0-41a6-4150-8e4a-d01f495cd701'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '3670efa9-1479-4b18-8add-cb079425f112',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '61c8586c-363e-4376-90f6-23118d4869ff'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'dadcdfe5-fd84-48f0-ba89-d8d465716a97',
            'StartDate': '2015-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '61c8586c-363e-4376-90f6-23118d4869ff'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd4a9e1b2-d419-4804-981e-b73bb0292a98',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5083a372-baf8-4de0-89f4-f2cbc82a7677'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '05aa0514-fe94-46e2-94b1-46f3844701f4',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '430a3d85-d150-442c-a654-06e3467c8831'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '88bbb675-755e-44e1-9dbf-0e5c0d02c7ea',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ea909da1-5268-4962-a956-1b8aa60eca5f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '68431c59-0907-4fce-99f1-fb2be35def1b',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7552c5a2-4408-4319-893d-2a4ddef1df08'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a0430633-a918-47b9-813b-6b387e128f16',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8e42598b-170b-47b7-80d6-78f903b35bc8'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '69e857e3-25a1-4468-80d6-48ff8461253e',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f59ac35d-cd26-4b6c-b68d-552a6577d857'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '8bc0b736-6957-4510-9064-ba3a8c619ded',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '55577bd5-5c12-41e7-a28b-cb67c1a320f1'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '18931597-751f-4ada-aad8-f9d6026346c4',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '481974c5-3989-462e-9e52-a9f149ae7b44'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '2a53c367-7976-4126-804f-2636a865d4ea',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f6232602-2601-4fb3-80a6-b84e7e373e95'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '48d0cc90-d1b5-45c7-9651-80954cd5411c',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f6232602-2601-4fb3-80a6-b84e7e373e95'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '20a48c12-e86b-4e8d-9d22-8e110c97cea9',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7a3ed0ce-bfb1-422e-8a25-e187c7e5cff8'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a82b86d8-2782-4d8a-a696-83fe95ec0fa1',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'df70855e-3e9a-4eb2-a521-a14c001a743a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'fe97af78-1726-4c72-9111-28baa0c6857d',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bf097346-b47b-4999-bf41-aa7eea52c410'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '6cd3c212-366b-40b2-9f59-26b32f986548',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9bff89c8-988d-4add-a39c-a3892bba16eb'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'ab24687d-30e6-4ad0-8df9-5eabd44515b5',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '41432261-5924-4a2f-89f3-7f82b6e8c09f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '0b6be20e-e3e8-4a8a-b3a6-818c8aeb4b38',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '41432261-5924-4a2f-89f3-7f82b6e8c09f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '09901181-a990-4c88-9f47-3a1af16e8fa9',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f2258d8a-0fde-4810-a210-012246a35a7a'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'f481ebee-ddd3-4eb7-b8fd-010e51406e65',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ba2e5f73-c1cb-4da8-9687-28bf5a45b7c6'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd9b93b23-b6bf-449b-a858-f40547ba8f68',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '82a53d0b-61e2-4e27-aebf-93ab0c672873'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'e1645f1c-83ff-4312-8a24-26fde8f92ece',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0ef53116-f9f0-441b-a893-bad2e4044faa'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'cdaa4171-1973-4f05-b3d3-7181d92ec87c',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0ef53116-f9f0-441b-a893-bad2e4044faa'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'd259fd63-e582-42e0-bd38-ae73ca30a2ce',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '47009b4e-4af2-4896-9cfb-f843c70e4eee'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '9e93827e-f3f3-452f-a2cd-8c72e5a9f2c9',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '32c906ce-089d-427d-a369-9da0597bd994'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a3a981fd-4a5c-4279-a3e0-5ddee302673c',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bca33f31-15b8-4e60-a961-e80e0378c1e0'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '7d19f419-74ec-44f9-be41-998ed96b6f31',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '128158bd-7c7d-4d98-ad7e-f1c4348850b9'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '761cc359-71b7-49b3-919b-231b06acbd7a',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '128158bd-7c7d-4d98-ad7e-f1c4348850b9'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'a9530bbb-067c-4756-915b-dc78767614fa',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b5fa4182-d0f3-4065-91a2-345ca4324d1d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '9267fff6-acb7-4f45-9e15-53699cc07743',
            'StartDate': '2014-09-01T00:00:00Z',
            'EndDate': '2015-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '886a36b2-50d7-4fc7-9bdc-570cb88ca654'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '1a1a74b5-c334-41d3-9e73-719ff8a35f49',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'cd1e7e59-791a-4b64-a2af-815b845aeb3d'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'c5fd83bc-92ce-4767-a458-83bccc649fab',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ec6fb93d-433e-4369-bdc0-ff18e230a16f'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '0a3933cc-f89e-4286-a27d-94965b55a27c',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '22bf4b80-238a-4c8e-ba26-19c73a1012c2'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '61ab49bd-4fcc-4b1e-9e2f-139d04552af6',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '157abdb7-14af-418b-be2a-3f2727393f6c'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'be34885e-b32a-47f7-a2f0-df0b4feb17c7',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '269d826b-5dd8-490c-81b2-4be43f312061'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'f0c768e7-edb6-4965-97a3-5550a3e03ae2',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2c1338e5-713a-4ebc-aba4-afc2e51d4c17'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'fb7d44d5-14a0-4040-bc81-9a0bed45bf3d',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2c1338e5-713a-4ebc-aba4-afc2e51d4c17'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': 'f888143f-9d14-43f0-8658-50e5df816f2b',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2c1338e5-713a-4ebc-aba4-afc2e51d4c17'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          },
          {
            'ExternalID': '0ac221eb-a33a-42bc-8637-3cd023d78178',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e6263648-a003-4c34-938c-c08ad0410167'
            },
            'UserDefinedGroup': {
              'ExternalID': '434ce523-2698-4b20-bc0a-6f50bd5c8b6b'
            }
          }
        ]
      },
      {
        'IsDeleted': false,
        'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a',
        'FullName': 'Castles Trip',
        'DisplayOrder': 2,
        'UserDefinedGroupMemberships': [
          {
            'ExternalID': 'd23db96e-c789-4926-8454-86cdc6292b21',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3475b149-75ff-4cbb-9ff9-ee6e81b355fa'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'd763555a-ebcd-43fe-80f8-e7114c4228f0',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f7cca30a-7477-44ba-92c6-485f045e29a0'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '7feec0de-0b25-4c2f-a354-9b8b4f7faf7e',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '55f254d9-a573-48cb-950a-1158db386591'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '92ab7f4a-31cf-4e37-92d2-97272a861dec',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e93e7c51-5cc7-4927-8fa9-d8a4846c3030'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'ff93bd3e-6d0d-4289-b441-1547e5842282',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'da4b1851-4d9f-4a24-928a-aa45f859df3c'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '66a92946-2232-4636-a821-7a0258135137',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '121b49b7-c4ae-4685-beeb-4a9504ae6e23'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '646b5ea9-eed6-4972-8e9b-6dd0789c93c1',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a3a80eb7-c511-40ef-a935-9e8399a4bb34'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'f7b11d02-be85-4dbb-9c2d-306645411d5c',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9d51a755-fa32-4d8b-8a5e-a81db575a65a'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'ee862507-72ef-43f7-8792-21d69939c815',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1dce3900-bae9-47ac-8f81-8cdccbc3b93b'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '63b07d70-4b02-4cac-a404-f31997bedaf5',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e41ad219-7681-43e1-b89a-c500bf5f776c'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'c279011e-6a9b-4d94-b925-d582c9eea124',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '54462a29-32f7-4ba8-a106-18d3e5d04910'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'b57c2e96-e599-4dd8-a0d3-a8a10554dab3',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7d1a6d99-2d80-49ec-a56d-7b195ae4c33b'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '361002fb-975e-4469-ab5e-25908ca74083',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a17561d9-65e2-4277-b729-1840fdf6c0d2'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'b10e04bb-9c3e-48a9-b221-b0c74e52398f',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ccac7850-f4b0-4326-bbae-285a2ede6863'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'f663c6be-62c0-4455-8a1c-af619823ec4a',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c7a58a79-eb52-4fb6-af8d-e7d8f659c94f'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '8c384b95-f21b-466f-a3c6-b7830f8becb6',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '020b74e6-f427-4f98-909d-554541cc455b'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '42fa6d88-10c8-4787-8d9a-b91ff01b5c9c',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7270d247-d76c-47cc-9451-d069cb02e2d8'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'd7a30234-d6d0-4ae4-8493-5dba1816c9fc',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ed3148f1-42ab-43d4-a0f2-b7775ad7a6b4'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '1a53e0ab-7f14-4b9c-9197-16f2ad80d886',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1ec6a136-6755-4275-8785-5782a053af68'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '34658483-973c-4f6c-9ddc-77111f53ec8e',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1fb50a7f-57fa-4cf1-8da7-35714cc72dac'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'e96c989d-7e4d-47f0-90de-93b528b9ae75',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7054c9b5-e224-46f7-8c81-90738738e138'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '2112ed97-8df5-4492-b48e-fcaccb99ab82',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ba18900c-157c-4689-b4d5-03b832efb7ea'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'e9e37b7e-0402-4c21-b29b-a88471bceffe',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8c63f7eb-f592-4283-8231-8a80771e45da'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'df452622-fb57-4c70-b4fa-b490489a8c28',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c06945d4-f8d3-49f4-a9eb-29821b51bbee'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'f803db6f-d8dc-4b56-8ea9-e963a7de2f9d',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd0c0d1bc-4bb3-4b7a-8ef3-89ea1beade29'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'f30b52ae-e678-41a7-affd-13da8385d503',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '61a57f8c-a5cb-404c-b3bb-a7cdc908e1c9'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'abd3a234-d091-4f66-8eaa-02090d9a0b9e',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2689567e-e9b3-42d6-a419-39268369eb60'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '5ddd079f-c049-4bd3-b7c6-420be351e2a5',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '52072245-7344-4eb2-89b4-00751cd475ba'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '56cd473c-56af-4870-adce-6ac2bc3c643d',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4a559029-9168-4ef0-bac0-6daf004735a6'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '37da3b1f-f42f-4361-8bbc-4ed2ba4ea704',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa53e385-7271-4d9f-b475-7bb8249734c1'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'c12f8d2b-05fe-4a71-8970-382eea83ab66',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c63c6451-2dde-4ca5-b1e4-1e0a874ac2f8'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'e1bf8982-acfa-40b3-a5e1-2dbf4784d37d',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5a68cad8-b921-4716-8d17-f5ae68e3f807'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '87d132bb-8c4b-44f4-981c-c248cbe981e8',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1767fb23-2074-42e3-964c-a3dc8f0d1a22'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'a439265a-90dd-4afb-898c-437d66c503d1',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '44bad664-d14a-469a-87a9-8cc88f98ca25'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '8a96cec5-9055-431e-8b1c-921d27b14d5b',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bfb0f27c-8539-4f2c-a55e-1e7ec09a3bda'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '58d26cf8-fd8e-4cb5-9351-f6f3feed80b9',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a9a426c1-736b-4f98-8a7c-f53273e67f5d'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '6f03cfd3-ee37-4ed9-8e9d-ec5bc4347b61',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0cf4dc80-8825-47da-9f2c-31f262b0c004'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '438044c0-e690-4bfb-8bbb-a4481324df03',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '09663165-7b21-4a63-8fa7-12b1ee34bd35'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '329b9e87-b777-4b78-940b-ee9db055c24e',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8ef8a8f2-ac46-43d7-a26e-1fdb6c2870b7'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '3a660fa6-89c4-4fed-8141-07a37de3ab59',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'aa809021-4646-4270-b1b6-66a9f69bef10'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '7f85bdfa-450c-4c89-968b-a409a1978ebf',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '86c2c629-a86f-41d4-8932-5f2b392ec56c'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '081da6a6-0de1-40bb-82bf-296fe43b75d3',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3b934f31-8a4a-4c43-ac6e-9aa5a57a0448'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'daf4510e-412b-41ff-a9a6-32174d732df6',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e5f4f62c-7387-4929-af1f-8bf47d6fd755'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '11c34247-e86a-4f6d-8edf-3aaa72a67b7a',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ffa11ce0-35b2-4673-b0c3-d41e905609e2'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '2db69a7e-b69c-4b1a-b18d-de24e6d52020',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2438d965-38ce-4a6a-9642-23ed79202a37'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '129f4ef8-502e-4e04-bcda-b5c08b9475bc',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bf4c4ea3-73b6-460e-8836-7dff471328f1'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'bd7fc41b-247f-430f-8e3b-dbf7a7c9bb83',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e2f6303d-c112-4287-ab26-07f99918cf76'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '4d1ee7af-ce72-4928-baa3-3ea09d90942b',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3be87ff8-d907-49e9-be4b-d58434a7fc09'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '5f90d45f-d0b6-4382-97a4-a3853cbdb35c',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5797837b-be0f-4290-b49c-ae84cf78cd26'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'a6c36974-9bc4-4dcb-b578-2e62efc4fc89',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'af9d8b8e-fb62-4f2d-bc65-d7c015893782'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '8bff2acf-5dac-4db0-8e86-b0eab1f1c2d8',
            'StartDate': '2007-02-14T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '48565334-2e8e-488a-ac10-ca235765f275'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '4a60ecfb-3495-428b-8e8f-341307f1933a',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '585e19fc-626a-40da-ab91-98bee2848aad'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'b5fd4abd-2afe-45ba-893c-97ff0d9c53fe',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '901bbb2f-bf3d-4ef0-9159-61c48af9296f'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'bce5bab7-c41b-4da2-b3ba-5a847af41b02',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ae4bef7f-832e-4317-9fa0-fce45e7e1062'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '0ecc7d0c-40a2-41c2-afa4-19ac962fb227',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dec6a7e1-5e4a-4141-b8f6-f280394960c2'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '0154f6cb-38e0-4bb4-b5d0-2e3f2374bfae',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8e42f91b-e848-4aec-888d-9a2a0c3a3b66'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '3952f6e3-df69-4bae-97d2-2f710f448bed',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0c501ac0-7683-4906-8621-f58831ed0da7'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '8b1dbe65-5fcd-42e9-9ad6-f58d905be146',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'cd088cca-8069-415f-b95e-e19600a91d1c'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '83a5cc65-42e4-478b-91d1-64cb1862431d',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '79d71a52-8898-4699-9c8d-7aae0163d77b'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '0d63888d-94e8-4683-88a9-5a64b0ba297f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4fe0b91f-0d5e-42cf-88b0-c219663612ef'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '6d3689f7-8281-4991-8adb-59eea3719e83',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '56c95892-9adc-4b4f-ae34-57f12830f2a1'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'c9c1a608-fccd-4fc9-9eb2-feef0878c144',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1e3cfcde-75c0-4dd0-a186-8537b6b817f9'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'f1142065-329e-48dd-89b7-9c7fe518ad72',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a4603218-74ad-48ba-8c76-92c2d1d74e34'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'a0763f1d-d8e5-414b-ab2e-bbc1285de475',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'be1b96c0-0a73-400b-bf8f-56d02f9be0ef'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'f4071ca8-98cf-4bf6-98f2-b31e051af322',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '542b9137-6ac1-4495-8e12-6a6a7166e88c'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '10566e49-4dcf-4c57-8c82-7bccf1f9389b',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a19448cd-6782-49f8-be62-24916ed05b23'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '153f8db0-5290-4f0c-8e2b-2b55bfd8ecd7',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ecd715f8-dda0-4b21-8468-b2bd04ef6bdb'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '537d1be6-9129-4e5e-a366-1d1e2491bb16',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '360b0a12-f7f1-4595-b315-32e6aeba7f13'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '02ef2b05-ec93-4995-b9ad-687abdef749d',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5dfd9b22-3dc6-4b89-b662-35a09fd926a0'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '401ee31e-3fad-465c-a507-1a7f76171ed1',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3cd1b199-0344-46b7-a679-150f547a63b0'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'fcfb835d-821d-4764-8115-35acbd967a33',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8f7d673b-b4ba-4b8a-a74f-a6d4c512cfc3'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '281dfe54-83bf-4579-9ae2-df6068c8a7ac',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '522e059c-e546-4679-8d8c-412415c5c42b'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '386c549a-c308-4313-a530-8f2cf19aa9dc',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '74aeb481-ac06-4326-a571-9d7e062a7ced'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '376551a2-1afc-4d0f-aec7-6f906b557877',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '67c3acbb-77e8-4aa2-b911-6346ea16a59a'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'b903a8f5-d833-4c23-806a-65b16f593926',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '91e96a54-adae-410d-8d34-db5c8374501c'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '3d90d5fc-6b57-4197-870c-43487a2e870d',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3b5bff42-52b1-4a10-a815-77a514848d1d'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '179a7954-f183-49ae-bad5-fc6db929e7f5',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9d3b4db1-1795-4545-8cec-34356962c35b'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'ed528262-4ca0-46e7-b749-5a7d5569387c',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e9c3b083-a8c0-4c5f-8f78-9298d0c8ce65'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '40e69dde-b38d-4923-a16b-800c051b7d79',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd3882cca-ad2c-45d2-b0ce-f8b340f58565'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '693da83c-a69a-44f5-a4a4-e35c228b9864',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b5f083f7-8b63-4b94-b9c0-1163ab50ca59'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'a104006c-af5f-4194-8ab5-ab8bda40acbd',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '196d8747-bcfd-471f-bc1c-4266aded4ef8'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'e153e225-584a-48ab-9d6a-4c2f01bd05ae',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2e92b58a-803e-4af4-8eba-c18e4c0f9aea'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '3f16510e-e1e6-4485-90ff-1258e15c4018',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4cdd7f0c-8b7f-47ae-855f-1effeddb9616'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '61fab0b9-918e-45ea-9902-f6676f464e55',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '90644109-5b8c-412c-b8cc-eebacbc708f2'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '3a7d2209-92a1-46b0-a50c-fc35216c746a',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a9b42255-40ac-422c-bbcf-a1207369b6cc'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '36044c02-f9e8-48ed-8d61-2234959fabf4',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa5d0cf5-4b05-45b7-bc0c-2ca0bbcf289a'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'd3be464f-d3a9-4cba-9d9f-c3f05e6ba4f2',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '39d59929-a603-44bf-8de8-369d737b8192'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'e15c7645-be75-4774-af24-5d5c5c937b9f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fe6fddc5-f32c-4d25-9f72-bf420345e6f7'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '9544e719-d0ff-4e02-8ede-6dc6168e78cb',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '079af159-8d91-4af7-b502-62d89c00aa4e'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'f2cf227a-fb03-475e-9cc5-73f9b783fe6b',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a598d2cc-2523-4a34-8b60-a4b5fe0f50c5'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '1ad7cdd3-f34c-45e3-84d5-4d3bbc10690c',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f69ce1e5-fe1b-420a-af1e-d5d5fd9de269'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'dec3bf3e-7643-48f1-a068-19cfc54d2c1d',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0eaf73a1-708f-4327-b98e-41d7202555ef'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '6a3688d6-b8a1-447e-9ec7-c3bc5f4ba46d',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '91bdc070-8e4a-424c-b6fd-9ea30207def2'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '8d39def2-5397-4687-87d1-f2b54665ba38',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '91dfc5f2-541c-4413-ab23-a79d508a28bb'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '92dc08bb-00ef-4e7e-bb7c-c87daee9fc48',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '55577bd5-5c12-41e7-a28b-cb67c1a320f1'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'd3e3be15-088b-4a92-8f1f-56f1cc271b7c',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bf097346-b47b-4999-bf41-aa7eea52c410'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '3d2bfb44-d553-45d0-a478-44bac2677db9',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a1351bfe-1a0d-417f-b83d-46f5ecb075d0'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'fd2c1929-8ed4-4280-960c-df69c79cb764',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '15b7ba8a-4951-4a7f-8b7c-1f4e11d3df9a'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '82146153-a00f-402f-b520-89d98e90098f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ea9317ac-82e5-4c8d-b646-8e53ffbfebee'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'dbccb385-29ae-4301-8140-8b3fe815e80f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '139f831a-6381-4ddd-97f0-787610cd899a'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '1c6b5078-55f6-48a8-bf8f-5ccbd50fb44a',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ab5d1065-8ab3-4d54-bfa2-a218532f4d1f'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '86fffca2-2e40-4c68-9f07-cd3ea5583050',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ba2e5f73-c1cb-4da8-9687-28bf5a45b7c6'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'e345de39-c230-4f49-a2e1-070c8ec9228e',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '82a53d0b-61e2-4e27-aebf-93ab0c672873'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '83abc9b2-cea0-410e-8297-4b202c96b074',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b3d52f06-2ff6-4f29-8724-ed21bba0aad9'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '966a2944-02f1-4ee8-adf4-afe5780bc363',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9abe4428-595d-42c1-acb7-291f35a6b1d7'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '1cb1163b-a870-444f-a055-23f39615f07a',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '01a552e5-506a-466c-a509-c7ed06e2b3fb'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '6722d433-9f47-4dd0-ac7a-f8f8f60061e7',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'daaf1356-b18a-4b21-83e2-8439f6f3fe69'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '520f7057-3ece-4fa5-8516-9b00694aca3e',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6c8dee99-34aa-4f32-b7ed-22846271617e'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'd6f4a97a-8109-4021-9892-f2041120e1fb',
            'StartDate': '2006-09-05T00:00:00Z',
            'EndDate': '2007-09-02T00:00:00Z',
            'GroupMember': {
              'ExternalID': '718c726b-c40a-47f9-ab92-c4a28d1c5695'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'cb7b10b2-7a37-4861-ba9b-d35ca33203b7',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'cd1e7e59-791a-4b64-a2af-815b845aeb3d'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': '4f7027e5-5370-43f4-84a1-c3b44f93b855',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '576bbbd8-eb55-4fa6-9599-04760b10d450'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          },
          {
            'ExternalID': 'c3bc5831-508f-4d15-a530-8df6dcdb504d',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '157abdb7-14af-418b-be2a-3f2727393f6c'
            },
            'UserDefinedGroup': {
              'ExternalID': 'bb30427b-452e-4d3f-a253-6ba7e5ad3e8a'
            }
          }
        ]
      },
      {
        'IsDeleted': false,
        'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a',
        'FullName': 'Comments & Lates',
        'DisplayOrder': 1,
        'UserDefinedGroupMemberships': [
          {
            'ExternalID': 'b351eb27-a124-4d15-9682-34453e8ce388',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '26e1eb8c-bf65-46f2-9a10-05d7342ce1a6'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'c11a510f-dc4c-4874-8074-31dc62b15f57',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '26e1eb8c-bf65-46f2-9a10-05d7342ce1a6'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '2239d3e1-acf0-4e82-b9c6-e7002b624008',
            'StartDate': '2014-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ad1ecc6f-54f6-4b3a-af02-fc4751d5abd5'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '755f9ddc-bd0b-4894-b56c-ffc974813ba8',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa94e5c5-0c8d-490b-9a8e-05583605110f'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '183d5db4-ff3a-459e-b2ff-ec5b63cf2296',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa94e5c5-0c8d-490b-9a8e-05583605110f'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '81209278-fef6-4ec1-aad1-b56c4d0f002b',
            'StartDate': '2014-09-01T00:00:00Z',
            'EndDate': '2015-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'cb0ab32a-7cef-4c14-8cde-1ee3a090991a'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'a985c998-511c-42c2-827b-cd3a483dfc4d',
            'StartDate': '2015-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3e5b7152-abf7-4798-8171-9d92d3462d59'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'd3858957-534d-4cbc-90dd-bc586d479ddf',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8c6c9c9f-8edc-4e93-a1ae-5a4121148653'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '4a65d887-ef52-4655-89c2-ab5f7ef90baa',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5a692da6-c3ec-4080-90b2-1874a13a30a4'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '5f37415c-afe8-4ad8-a587-f191e9ec7d9b',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '633bbb12-04ce-4191-aa69-eeff0ca22ad9'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '6e979fd0-81e8-409e-b913-2b60218d436a',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '87714ab3-6707-4fc5-9a5f-ae50d56028e1'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '007fb471-5237-4805-9e09-1ae6403027b9',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '87714ab3-6707-4fc5-9a5f-ae50d56028e1'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'e90ea5d8-8513-4d5b-bc53-6cf9743650be',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '133895e0-9a9e-4e77-9f8a-aa54b455bcc8'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '1df06e65-4d76-4e3b-afc2-f476570ff7b7',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c004b697-0226-4ae0-82c4-fda8c8fe34bb'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '7b7bf0c4-4091-49d3-ac24-def0ea056e45',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9ec7a61b-9be6-473a-996c-49941e2cbef0'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '4e715f0a-5d62-485b-b374-55bef0cc42b3',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f487261b-9f30-4a35-95d2-da1dfcebfa84'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '6a78d9c0-c999-428a-aa7d-b75500ad04a2',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f487261b-9f30-4a35-95d2-da1dfcebfa84'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '887beb65-2b26-4d3a-9bc5-b260fa4c18c7',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2459f17d-9c97-4e95-94da-02ae9bcffd52'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'bb8b98d8-16de-4a50-85fc-f89f51751023',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2459f17d-9c97-4e95-94da-02ae9bcffd52'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '92d8b3fc-0cb1-4be0-a43c-6422b3abbf3a',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1fdd2863-b4b6-4444-8371-dd7c3618373e'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '7edd5b18-7749-47f3-b44a-e00f3bb3e4bb',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e2f6303d-c112-4287-ab26-07f99918cf76'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'e0611eed-44e4-4406-9354-4b740dda2c89',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1d008471-cf7c-459c-8cc7-6d090bea5dfc'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'a7a04b0e-5153-41b5-a800-6f9c1a93e008',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-07-20T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0c75a66e-e4cb-449d-a7ec-f90b979b3b36'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'ed2786d3-fc53-4bd3-b0fb-89e3ec0e7a0c',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '38a16fa9-3747-4cca-b56f-5cdfa9ae6a03'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'd86f94e1-196a-4ea5-b394-6571fba7c732',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '38a16fa9-3747-4cca-b56f-5cdfa9ae6a03'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'ccd350c5-f17d-4b59-ac21-e6a18a147c96',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '38a16fa9-3747-4cca-b56f-5cdfa9ae6a03'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '76b975dd-e01b-4cee-8386-000fc7a06c7a',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f142e9e6-9549-452c-a3f5-76ac0bde4a53'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '63f49bd3-19eb-4fd7-9aad-d81b0f08e4ce',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f142e9e6-9549-452c-a3f5-76ac0bde4a53'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '239084cf-3d2e-44cd-99ad-f7fbd19d7cce',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f142e9e6-9549-452c-a3f5-76ac0bde4a53'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '3e42a9d5-f073-4a1e-9cfc-43cdfd46f6d7',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f142e9e6-9549-452c-a3f5-76ac0bde4a53'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'd429b9ae-09fb-48fd-99fc-e594f45ab0d2',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': '52b629d9-1706-4efa-8c0d-0cd99dc36c94'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'e867dabb-ce56-404b-ab50-b484fa4f0ede',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0807bfdc-c689-4c72-9573-3fb24edf1785'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '38817750-007f-4576-b6d9-f842dd835c8b',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0807bfdc-c689-4c72-9573-3fb24edf1785'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '3df1ad58-9cea-418b-902d-1aa204b3fd71',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0807bfdc-c689-4c72-9573-3fb24edf1785'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'a1e89c16-373b-45f2-9b19-5247b9f28507',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0807bfdc-c689-4c72-9573-3fb24edf1785'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'd9dd9332-645f-472a-9157-735ca6106511',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6e75e256-559e-4b40-b976-80f098af8af9'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '67fe6286-a796-42d6-be10-812b2f9135b6',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6e75e256-559e-4b40-b976-80f098af8af9'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '15d6815a-2e8e-430e-897d-afe3b7b7a6f3',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '5ba2b1b8-23de-439e-a750-698c24a36e70'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '5715358e-8396-4494-9dbe-2b9b93df86d0',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b1b83ba9-90f0-4301-9c20-172dfa0c6261'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '30c5df47-282e-42ed-8c23-b8fa8ae57baf',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b1b83ba9-90f0-4301-9c20-172dfa0c6261'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '38ef6334-a3b7-4e6e-a84f-c852f7d20519',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b1b83ba9-90f0-4301-9c20-172dfa0c6261'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '2cb1a416-fe8b-4e20-9c6c-7670ecebd8ff',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c1d4161b-295b-4d26-ac4f-ddad7677cc4e'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '06ced670-b097-4cbc-ba83-c923cbe4a0a8',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '764bc854-5dc4-4e1d-9360-5e1d58c5fba0'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '1c1e830b-ca29-4071-bb1f-63262c6c1019',
            'StartDate': '2014-09-01T00:00:00Z',
            'EndDate': '2015-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '157ba6d9-1658-42bd-9790-e323c58da4c0'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'bdc3a6a2-4380-4741-b324-98c19a2bcf50',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f4ecf9d2-e919-4460-9840-b7bc94c73c4e'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '7622502c-690e-4d6b-bf35-baf2231e0ff2',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b5c88398-4a6c-4f2c-8acb-ac4abecf3298'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '304f75a4-b822-4609-9347-f74532b0dca2',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8e42598b-170b-47b7-80d6-78f903b35bc8'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '010d16ea-237b-4fd8-bef2-e8ed5a486633',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '19a7736a-cab9-436c-a0c3-333f9f7f7d62'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '2239a7aa-ecd1-4f35-832f-87c7b4c64320',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '41432261-5924-4a2f-89f3-7f82b6e8c09f'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': '404b4825-c7ca-4ad3-aed8-5517e36cc361',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '18799955-ca72-453f-b442-74f6457b46b7'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          },
          {
            'ExternalID': 'bedf75b0-ca19-4278-aef1-d99194d5ffd6',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4349ca4e-f7b3-4ac2-bd32-500a40719c40'
            },
            'UserDefinedGroup': {
              'ExternalID': 'a3ba0abe-2dd4-4d46-8ad5-62ecce3e9b3a'
            }
          }
        ]
      },
      {
        'IsDeleted': false,
        'ExternalID': 'ad712030-28ed-49c3-8ffb-0d655d2b309d',
        'FullName': 'Year 3 2002/03',
        'DisplayOrder': 13,
        'UserDefinedGroupMemberships': []
      },
      {
        'IsDeleted': false,
        'ExternalID': 'd3f4ddd4-9494-413d-8c97-5e7943559987',
        'FullName': 'Year 3 2001/02',
        'DisplayOrder': 12,
        'UserDefinedGroupMemberships': []
      },
      {
        'IsDeleted': false,
        'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88',
        'FullName': 'Often Late',
        'DisplayOrder': 4,
        'UserDefinedGroupMemberships': [
          {
            'ExternalID': 'c844e470-f101-4c03-8c2b-6b954a262a1e',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a2c55667-f98b-4fa1-bd8d-15c20e8aba9b'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'f8e1ad08-31ab-4250-b570-f0fb44d22d5d',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '26e1eb8c-bf65-46f2-9a10-05d7342ce1a6'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '3f9edf2c-2202-4556-8e7e-cc36abbdd7c7',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ad1ecc6f-54f6-4b3a-af02-fc4751d5abd5'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'd31ad731-0dd2-4cfb-9f9c-622211ee625c',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f5fe76ee-b08b-4d4a-8c69-a9fdfc16dc6f'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'b63ae7d6-69eb-477a-acec-901fcc74486a',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a7c64fe9-491d-47d2-b89b-e31daa2cb592'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'e7131ec6-f9ad-4479-b67f-00e32d44c2fa',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7c792b9f-ab3a-42e9-86f0-79cf1faa9816'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '5f730583-4379-4be9-9652-6be50c83b68a',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7134a0ac-bd06-4636-b13d-27b2fa29fcfe'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '3f5e9f85-9c60-4e5f-825d-eefbf1b35c3f',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '305e9f7f-4ab8-40bd-ae8e-5e1a1eb24509'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '8fab0f10-0639-4f10-b6cf-728afced9731',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '30adcf16-fea0-4117-b34e-fa977c2ae7e6'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'acd875aa-d5b1-45b2-966f-ab8b51e22cd1',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0414e9b1-d972-472c-9405-d2470a7497cb'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '7fd211c4-88d0-447e-9c99-a04374276cc3',
            'StartDate': '2015-09-01T00:00:00Z',
            'EndDate': '2016-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0414e9b1-d972-472c-9405-d2470a7497cb'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'a30e6bea-a825-43b0-8cbe-e8d02063a3a5',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '11d2fa06-f46b-4748-9295-5087afdfc4f9'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'cbfd72da-b7ca-414d-87db-dff023ed97d2',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa94e5c5-0c8d-490b-9a8e-05583605110f'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'b11fda9c-fab4-4c55-9bb8-43d598791ed2',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'be9103b7-a4d9-4d1a-b3ab-4e8c6f504880'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'fb70f10f-aac7-492d-8d1f-a69e5b0d48c5',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'da4b1851-4d9f-4a24-928a-aa45f859df3c'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '7830f953-9a06-4871-b5e5-6bf517f780e3',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa25f026-dfaf-4275-a1f4-377c988e2cc3'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'dedb5cae-dcbc-4a84-82e5-c0ab10f222b1',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a3a80eb7-c511-40ef-a935-9e8399a4bb34'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'ae7f7c59-d2e3-4acd-9464-e6e25b7a6c50',
            'StartDate': '2015-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3c0284e4-1092-464d-8b4f-0579f0680d6d'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '82ac615b-784b-4f1e-9986-aeaa06ddd0ea',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3c0284e4-1092-464d-8b4f-0579f0680d6d'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '3a103ab3-57f4-4952-9928-835e2e3ee77e',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9794f27c-7c49-48fc-a79c-c0a36f8f6efd'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'bdface93-4ad3-4af1-a452-1a7174ade15f',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c8f54b7f-544f-45a2-80b9-0cfac4663486'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '62e3eef8-2bcf-4490-add8-d54742a4fdbb',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c8f54b7f-544f-45a2-80b9-0cfac4663486'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'c9d95022-5c90-4da8-ab6d-07b57beb0401',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f3feefa7-31a0-4057-a3be-96a5fe33a3e8'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'a556db32-3238-4810-a014-8e43972dd1ce',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd80bb03a-4b20-4345-a3c5-a37aac4d3a55'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '2ee122bb-0afb-4466-91c6-85e6ae142ee2',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd80bb03a-4b20-4345-a3c5-a37aac4d3a55'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '577a5a60-8bdd-4891-a02d-215363b0fced',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b8a30eea-b901-4aac-97fd-64b9428816cf'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '65e04ead-91b1-4986-889c-823029d77ede',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a78970f1-4b06-4af1-8259-d6e841a21f74'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '8a6b8181-64b3-4295-adef-8847f6a07ea8',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2d5560e4-68d5-486c-aab1-5efb870745ea'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '9467a03e-671a-4827-874f-86a96bb88c69',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2d5560e4-68d5-486c-aab1-5efb870745ea'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '6003f313-350c-4951-8f99-e1b11c3e8f91',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a17561d9-65e2-4277-b729-1840fdf6c0d2'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'dd6556a1-5084-455d-8fe6-08d801754b72',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa4b5b0b-70fb-4d5e-af56-c3547eaac704'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'a7430474-7055-47b0-a233-0e6dc9d84d5e',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'cb0ab32a-7cef-4c14-8cde-1ee3a090991a'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'a3de58c5-065c-4257-ae2e-7cebce179aeb',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ccac7850-f4b0-4326-bbae-285a2ede6863'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '73156bad-66ec-4d17-9f24-6146cb2499e2',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7223841d-968e-4def-ac9a-5752a53b46ac'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '02643c32-a3be-4786-8459-adb293018108',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a2abc512-78db-4e4b-9cd6-61f5093fefbf'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '570f224a-14cc-488a-af41-267b4af005f6',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '006d6630-edea-41c0-8279-de2f02387184'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '6b691836-8ea2-4879-8153-50ee451875a9',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '633bbb12-04ce-4191-aa69-eeff0ca22ad9'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'baff8f9a-55fd-46f4-bc53-60b81e670edd',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1ec6a136-6755-4275-8785-5782a053af68'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '1edbbe20-35f5-41b0-9d35-9e7a717c59f8',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '87714ab3-6707-4fc5-9a5f-ae50d56028e1'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'c0cf8e29-1c63-420e-9738-ec3149a86f16',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1acea35b-9075-4a09-8972-e587697fbe62'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '9af557e2-8373-4803-94b4-c52f814f4fa9',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '27d65f64-859a-4ae1-baa0-8045839fb15b'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'fb0e6bd8-7483-4367-9ad3-d8f18cb0494a',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0b95bb34-08aa-4479-b120-8f3763674f2d'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '7423e678-e52f-40bc-a9f3-bfe69c48053c',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '95192538-3391-40de-9eab-87e5db66cdaa'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '80e53c54-d347-4469-9e3e-bbffd72bff7f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd777083e-1f69-48aa-b01d-2550f90df2fa'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '38e246bb-3ded-4953-802c-0e1c7ab9222e',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd0c0d1bc-4bb3-4b7a-8ef3-89ea1beade29'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '81ef48b9-98ff-430f-9d0a-006771b1432f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0651bc2f-e9f3-481b-9806-a6c58cd9a34b'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'ac9eff73-12f6-476d-9ab5-04a9dd684bf4',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'de353d4a-8ff0-4bd1-bbb3-972150e060a9'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'ece913bb-ba38-4a53-bcd2-e6fff99f2601',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1dc8b4b1-e857-4cac-b4a8-a73b78d6d401'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'a54f019b-0bf3-4890-962c-493db1b0133b',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd9f4aa57-8211-4449-8d57-7ee49e55c4db'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '0c3ab0f3-30df-462c-bf23-115323d0fdc5',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a83d7217-dac3-486a-a3ba-6bedbf054527'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'b212847b-8001-42cb-b0ad-350b10af5f86',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a83d7217-dac3-486a-a3ba-6bedbf054527'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '2f49896c-d359-4250-93cc-28080b0b7c58',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a4f60f83-69e5-40b4-a45a-039c91e9524b'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '1aad8f35-d299-47b8-b0fd-b21c472df3e4',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9d359402-8a7b-4c2d-8e34-68a5cadaf029'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '55e26eda-d7b9-4efd-af2e-ddcee94a7029',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0386e19e-695e-401f-b3b4-2ab59895e520'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'aeabfe06-c892-47e0-8c3e-af2b4e5cf303',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'eef744e4-289c-47d3-ab6f-0b6d4a1cb473'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '6a369337-1a1f-4d6a-b167-6ccaf25f7d20',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ed0ef6f4-e664-4c98-becf-c54c64e5f459'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '037bf22c-69d3-45f2-baef-06a0250300a9',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'aa809021-4646-4270-b1b6-66a9f69bef10'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '2e6abedc-0b40-4a1c-b67d-87445339e439',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2459f17d-9c97-4e95-94da-02ae9bcffd52'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '8eebbdb2-ac7e-4f0a-b401-20f292d503f1',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2459f17d-9c97-4e95-94da-02ae9bcffd52'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'b33c71bb-2da5-4f80-9c4c-3b8234133d30',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '858bd508-d772-4e84-82b9-1dfadb1e0d83'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '537f07e9-79b5-49ea-9884-79c80cf6d03e',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'be61ba83-0e76-47f3-a216-5ebec4f4a8af'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '668ad28e-2087-4824-a23a-842caacf0cc7',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1fdd2863-b4b6-4444-8371-dd7c3618373e'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '655d7f97-53c2-4ae1-b111-a2d46a1a0054',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7f1e3824-a889-4a96-b220-a5b441137032'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'ba38d9b3-50c9-4ae6-bc8d-5861c16eb961',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bd33243a-dc26-4af9-ae89-5541c45ae23d'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '34eb91e4-2d55-4402-ad51-bca78ba00e7c',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ebef022f-c2aa-4377-9b98-2b96a24dc42d'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '613fb719-9593-46a5-b6a1-d61de5773900',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd3dedc64-cf26-4973-8cd1-ea6418f8d83a'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'dfe2c6a6-fd73-4775-8a11-13faa12f1911',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0eb585de-d725-4bf4-ae7a-bb62ec6c3d27'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'f272a3ce-ca2b-41f3-bfd6-6a7c14752846',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ce084814-3271-46bf-a197-70fa4fe3c0b2'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'a1b5b39e-a8fc-454e-baed-8f5eb1ece6b2',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e2fcb1e7-a1a0-4bc3-8468-06bab73231dd'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '028a0ec8-236a-49fc-b10a-3ea597f21edd',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'af9d8b8e-fb62-4f2d-bc65-d7c015893782'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'd8116742-e9d5-4e43-a341-10c9067974b1',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd1f7bcdf-979f-4864-a1df-9618adde668a'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '0ae8bb35-7f2c-40ec-b456-0a842c2e6fe5',
            'StartDate': '2014-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1f04e439-810f-47dd-bacb-0e6715d37242'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '84441a32-ae58-4ca0-b872-65a6a02ca8c4',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '38a16fa9-3747-4cca-b56f-5cdfa9ae6a03'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '9468adcc-be1e-4a01-a1e8-2103cfb25d71',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '38a16fa9-3747-4cca-b56f-5cdfa9ae6a03'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'e55c2eae-2125-4c34-863d-00ab9c06930e',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f142e9e6-9549-452c-a3f5-76ac0bde4a53'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '50cfe9df-1267-44cf-91ef-2a117577bca3',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f142e9e6-9549-452c-a3f5-76ac0bde4a53'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'dd41163f-9bad-4e28-9a02-554fa2ecf699',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b8d1f02d-8867-450c-ae0f-f0ae2b760038'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'c2ed9f81-c922-485d-a4ae-079785628555',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b8d1f02d-8867-450c-ae0f-f0ae2b760038'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '097369a7-4c49-48e2-b360-875d52abd81b',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '52b629d9-1706-4efa-8c0d-0cd99dc36c94'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'cd3ee93e-7e2a-4443-8c63-54352b4f063f',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0807bfdc-c689-4c72-9573-3fb24edf1785'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '0bdac298-8be8-41fe-9bb3-463b827de054',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0807bfdc-c689-4c72-9573-3fb24edf1785'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'c7ecf01b-d4c0-4348-a3ce-b48a85c82889',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '178e91b3-21bd-4bc6-9239-b295b1540c15'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '684df93b-817b-4be1-9366-0260de17d39f',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'cd6abff8-a1a7-4523-bd13-65515d5f27e8'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'fd393949-a760-4681-9041-39494d211b88',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0304b857-d892-4142-b953-affe3038b1b5'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '8fc526f8-d828-4c2d-9c3a-189eaee0980c',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e36522d0-5dca-48ff-9d16-f40cb2787c40'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'b1462b33-7f2f-451d-ba77-435da0383fcc',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4d6e4e34-440c-4d90-ac6a-9c006cede291'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'a9ce81e5-1347-4d2c-94ad-ce02c1f8ab61',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fa6bb92e-a0e9-4fd6-bd5e-3f8616d4e2ab'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'c276efa4-e3a2-4ae3-a448-66543da4fafb',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a4603218-74ad-48ba-8c76-92c2d1d74e34'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'af14f69e-1821-4fbd-9cdc-72f727cf8d79',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f60ac953-20c8-4867-b9de-0203ff602464'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'a0737579-3ba4-4c5d-9672-8def19de7c72',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f60ac953-20c8-4867-b9de-0203ff602464'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '49574456-18ec-45ca-a3cf-cd8576a78d7f',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f60ac953-20c8-4867-b9de-0203ff602464'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '1a2333d9-d13b-446a-89ac-b04a6d0047d9',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0a60585a-fada-4516-8025-d06fee9a6ae0'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'afba6004-d466-4dbb-8ab5-6e1750101f2d',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2ee83d56-024c-41d1-8e6b-049b7ffad078'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '86759df8-c7d7-4742-9bf8-793b875d48a8',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '17d7e768-5156-4aa3-abf2-a9f56a039683'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '00d53763-9d31-4acb-8128-ba9acf017d0b',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8960126e-a315-45a6-b8b5-04b94ca935bb'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '5f6302d4-2a08-4543-a97e-6bbcdc61fffb',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8e20f092-91ba-4d20-af17-0ba17bb9abb3'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '5d07c597-0734-4084-b459-2d3b4d878bb0',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '28e2a445-24e2-4df5-92bf-fe1f28743cf2'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '54e7db3a-3ac5-45df-95a6-c504f6a215ea',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e49d48cc-07a9-4836-a611-7abce2cbb6df'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '035258fd-5c39-416d-824e-9ca6afe76b2e',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e49d48cc-07a9-4836-a611-7abce2cbb6df'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '51218c3c-3631-4dbc-b13f-b8215081a6ac',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '652b8fc5-2463-4ab2-9829-01fcdd3d7331'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '48e8c470-a3b8-4e90-b111-5797c9cd0da8',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '68d2bbdd-69b9-4d3c-8ad9-41db363d24a3'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'd2cffc05-dc69-4df0-83ef-94d051dec1f8',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6eb666ba-e78e-4106-aca1-e04f9d918107'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '514c7e25-dc63-488d-b727-40794c05633f',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bcb4e7b9-e795-4985-b747-b0331e9f2103'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '890d0b3b-d3ac-4498-b546-41413bad6952',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4f7596ba-d606-437f-85a3-e3630306dbb8'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'ccff3021-8bdb-4abc-a90c-2e89bf466a0f',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f70361cd-d27d-4723-b564-4efe9dadab02'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '29b2a0a8-9a9e-4b2a-a6a4-7d91db597dd5',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2e92b58a-803e-4af4-8eba-c18e4c0f9aea'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'ae0538b0-3867-4231-a486-531173ca1606',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b1b83ba9-90f0-4301-9c20-172dfa0c6261'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '9b4d99bc-3f27-4e35-b94b-b8de53c9f431',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '10875e4d-7d49-4f76-97cb-869bb2c25486'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'a556c512-eca4-4881-b330-8d7a4bbe8df8',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'fc60a8b1-f0e9-40cc-bf0a-a52be480f0a4'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '5ea5e1ae-f5c0-4a55-b58f-fca94fbcf561',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2abdff93-11d1-409e-9777-edd1c9ddd510'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'd71a8955-a881-4c0c-bab5-62b93af65f6f',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '234d2ee6-bdd7-4d9a-9b0e-7e12a2148ce0'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '7cdebff0-647e-4282-bbf0-67ffbb67862d',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '74704234-6029-4fac-b1d4-98cc30625f54'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'f1018e2f-7aa0-494e-8486-d486503ab5d8',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '63bbd26b-9dd8-4f91-b1bf-62ba8cedbd07'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '02d959cd-f414-4b3d-ad2c-52ded1b6fe73',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4d86ab79-3f2d-4106-a14e-3eb6f4f9621b'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'f3f62e80-17ab-4fb8-8d07-d83a017e7fb7',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '764bc854-5dc4-4e1d-9360-5e1d58c5fba0'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '2fa66b76-d37e-4844-afa5-9f1aa770ba78',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '157ba6d9-1658-42bd-9790-e323c58da4c0'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '133aacb7-2b21-40f0-af3d-bb232b9c76b9',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c4d8f4eb-468b-483e-979b-8bf13ee72027'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '12da1a0e-b024-4b9e-8188-bc4ef66c05a3',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a598d2cc-2523-4a34-8b60-a4b5fe0f50c5'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'e6ec07a7-fecd-454e-9779-d1fb2a66a0dd',
            'StartDate': '2014-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'af7e320d-ac78-4630-8cc5-8660396b5e88'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '326e7650-c250-4f0f-86a3-c889424f0daf',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'af7e320d-ac78-4630-8cc5-8660396b5e88'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '4b3d205f-14c7-4c79-b8e3-39f10e2d7aad',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd7b8eed0-41a6-4150-8e4a-d01f495cd701'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '39fbd8fc-f096-439c-9e1a-583a026a1c47',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd7b8eed0-41a6-4150-8e4a-d01f495cd701'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '2e71b78c-9941-4d55-8c3f-40c35afdbee4',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3e66e2fb-751e-41b7-b0cd-4c4dbee5284b'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'f8c0106d-4e80-427a-acdd-dcaed19d6fa0',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'f69ce1e5-fe1b-420a-af1e-d5d5fd9de269'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '6ac0db45-70a9-492a-b2c1-e30bf0a64947',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0eaf73a1-708f-4327-b98e-41d7202555ef'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '08727279-770e-43ff-8563-afae29abff5d',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b7e6b3c6-8f21-4fbc-8ad8-448cb8e5db6c'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'dc8a2720-1230-4b75-b599-b6899d7d90d8',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'cec70400-8d90-416a-9568-5f2fe5a5721e'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '6486d609-4d96-4547-952e-231a2ea0398f',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8e42598b-170b-47b7-80d6-78f903b35bc8'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '21a4b140-edcc-48f4-b5eb-ace49824733d',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '41432261-5924-4a2f-89f3-7f82b6e8c09f'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'abcbef65-ca1d-4d34-9667-c2f14a8404c7',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'ab5d1065-8ab3-4d54-bfa2-a218532f4d1f'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '36943088-455e-46b0-a901-7adb0c4a25d6',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9abe4428-595d-42c1-acb7-291f35a6b1d7'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'f453972f-c91e-4be2-9f3a-c31b5048c526',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'daaf1356-b18a-4b21-83e2-8439f6f3fe69'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'b8022244-ef6d-44e6-b101-1717e9e6684e',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '44676712-f949-4133-a022-9ad7736f91e9'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'de3247c3-1478-4fd5-a5e5-b9c0845d5fba',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2010-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6c8dee99-34aa-4f32-b7ed-22846271617e'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': '1fd9a886-71e5-4722-bdfe-6d85dfc448f9',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4349ca4e-f7b3-4ac2-bd32-500a40719c40'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          },
          {
            'ExternalID': 'fb9e240f-edef-4252-b6fd-ce1d03348af4',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '21aaa678-d20e-48f9-889f-ac4bf970939c'
            },
            'UserDefinedGroup': {
              'ExternalID': '5ad035e9-7d79-4010-b844-64c6e6e47a88'
            }
          }
        ]
      },
      {
        'IsDeleted': false,
        'ExternalID': 'f298ffc3-2740-4981-82ec-693ce8750802',
        'FullName': 'O Y5 Below Level 2 ast KS1',
        'DisplayOrder': 3,
        'UserDefinedGroupMemberships': [
          {
            'ExternalID': '1dc0abc0-02cd-43b4-948d-91d6d1cf1957',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7c792b9f-ab3a-42e9-86f0-79cf1faa9816'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f298ffc3-2740-4981-82ec-693ce8750802'
            }
          },
          {
            'ExternalID': 'fa727f48-af36-44a7-912c-f1492e632e52',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': '39766146-52cd-4783-9d53-5bc4bd9e5549'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f298ffc3-2740-4981-82ec-693ce8750802'
            }
          },
          {
            'ExternalID': 'ed153e39-6f10-48ab-80d1-81d4ac59c68c',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': '867246ee-63b0-4f94-8c81-455816fecddd'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f298ffc3-2740-4981-82ec-693ce8750802'
            }
          },
          {
            'ExternalID': '5926c4ee-8087-4a72-8bc4-43bc908c3e97',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7d61cbdf-d07b-4621-bd77-21ecb695695e'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f298ffc3-2740-4981-82ec-693ce8750802'
            }
          },
          {
            'ExternalID': '17355476-ef8b-45f4-a24f-6f44ec2132ad',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a9e7a086-1fe1-401c-899c-d9e5040d0caf'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f298ffc3-2740-4981-82ec-693ce8750802'
            }
          },
          {
            'ExternalID': '82ed1834-9897-4548-8c60-aab8a15148aa',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': '24e90747-e125-4480-a04c-3b1525983f1a'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f298ffc3-2740-4981-82ec-693ce8750802'
            }
          },
          {
            'ExternalID': '67c54ae2-29eb-4ad2-a26a-7191659e18e1',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b7e6b3c6-8f21-4fbc-8ad8-448cb8e5db6c'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f298ffc3-2740-4981-82ec-693ce8750802'
            }
          },
          {
            'ExternalID': 'e4c34014-cdd5-44ac-b363-80698281db60',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-09-03T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b143bf2c-1e31-4fbe-9cba-cf12e9d09f63'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f298ffc3-2740-4981-82ec-693ce8750802'
            }
          }
        ]
      },
      {
        'IsDeleted': false,
        'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8',
        'FullName': 'Traveller',
        'DisplayOrder': 8,
        'UserDefinedGroupMemberships': [
          {
            'ExternalID': '1869b499-2e0d-47bf-9777-d2a91a886b7e',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '121b49b7-c4ae-4685-beeb-4a9504ae6e23'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': '2247659e-4c06-4b35-a541-2b366106acfd',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2015-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '02d4e8f3-b2ca-4f56-a06c-2f1f5e7de2ab'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': '97e1cea9-aea3-4ef7-ab1a-0fb4cc8d7046',
            'StartDate': '2015-09-04T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '02d4e8f3-b2ca-4f56-a06c-2f1f5e7de2ab'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': 'e639bfdc-ff23-41d4-9047-a1ce6db1f690',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '866474f9-e363-441f-87cd-c044450ab5d2'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': 'd56a41d0-4c30-4b3c-83ff-401af6e53d35',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '866474f9-e363-441f-87cd-c044450ab5d2'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': '2e42bb9f-0bc1-4dc2-9c23-fe7ec3810a57',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '866474f9-e363-441f-87cd-c044450ab5d2'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': '5679868b-d6e5-4c48-b59c-ba24c863713b',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c06945d4-f8d3-49f4-a9eb-29821b51bbee'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': 'd8dd6006-700e-49b8-a966-3c913593071a',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3a515d79-7619-4981-9cf5-b3bd2b598a2c'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': '869d5d0e-37eb-418e-acb5-ab3289d83c6d',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b4b7a0f8-6070-4536-8e61-bcbb8404f737'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': 'd5e9d76f-bee3-4b43-96b9-7de1f6aeaeb9',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'b4b7a0f8-6070-4536-8e61-bcbb8404f737'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': '40f42633-3600-4b86-ba16-8389eb52ce02',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dd80a4a3-7437-4110-baa2-291e59658c62'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': 'e05177bd-b2fb-445c-85e3-78856cc2eed4',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dd80a4a3-7437-4110-baa2-291e59658c62'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': 'f6e272d5-6cc2-400d-ab42-8bc6b9fa12b4',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dd80a4a3-7437-4110-baa2-291e59658c62'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': '61dde868-a0fb-46ea-84d8-84b4e716f469',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dd80a4a3-7437-4110-baa2-291e59658c62'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': '4d44bcca-ccba-489d-9921-09c8dcec70d7',
            'StartDate': '2015-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3faadb06-7e22-4564-b2d3-931dcef04941'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': '64ac5ef1-f571-404d-8b0d-e22ee31626a1',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '3faadb06-7e22-4564-b2d3-931dcef04941'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': 'e2552cfe-f431-4d30-8433-ad13e8d7846a',
            'StartDate': '2014-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '274b7cd5-74cc-45fc-8c22-08b0c63f5b79'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          },
          {
            'ExternalID': '52e17894-61f8-431b-ac17-0422698790d3',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '274b7cd5-74cc-45fc-8c22-08b0c63f5b79'
            },
            'UserDefinedGroup': {
              'ExternalID': 'f02d2ea2-1f53-4f7d-96a7-d3a2c7290db8'
            }
          }
        ]
      },
      {
        'IsDeleted': false,
        'ExternalID': '7cddd97b-4c4f-48ee-a104-3496005aca44',
        'FullName': 'Waters Edge 3',
        'DisplayOrder': 9,
        'UserDefinedGroupMemberships': [
          {
            'ExternalID': '429a6747-fc3f-4035-9902-71573dcb5eef',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-12T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a2c55667-f98b-4fa1-bd8d-15c20e8aba9b'
            },
            'UserDefinedGroup': {
              'ExternalID': '7cddd97b-4c4f-48ee-a104-3496005aca44'
            }
          },
          {
            'ExternalID': 'dd0e6233-53fe-4eeb-9921-d591e22a2bc3',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-12T00:00:00Z',
            'GroupMember': {
              'ExternalID': '9b5bbb61-1e82-4cd8-a012-1987046c01e1'
            },
            'UserDefinedGroup': {
              'ExternalID': '7cddd97b-4c4f-48ee-a104-3496005aca44'
            }
          },
          {
            'ExternalID': 'f0406d2c-0776-4a92-bbec-504120092126',
            'StartDate': '2009-09-01T00:00:00Z',
            'EndDate': '2010-08-12T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'be61ba83-0e76-47f3-a216-5ebec4f4a8af'
            },
            'UserDefinedGroup': {
              'ExternalID': '7cddd97b-4c4f-48ee-a104-3496005aca44'
            }
          }
        ]
      },
      {
        'IsDeleted': false,
        'ExternalID': 'e599d5e5-a5d5-42ca-88f4-7bcab80c5670',
        'FullName': 'Year 6 2003/04',
        'DisplayOrder': 15,
        'UserDefinedGroupMemberships': []
      },
      {
        'IsDeleted': false,
        'ExternalID': '50cd43e5-d884-4bbd-8ade-24772e577bbd',
        'FullName': 'Waters Edge 4',
        'DisplayOrder': 10,
        'UserDefinedGroupMemberships': [
          {
            'ExternalID': '10d13252-3b91-48ff-99e8-c8cae79dc800',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a2c55667-f98b-4fa1-bd8d-15c20e8aba9b'
            },
            'UserDefinedGroup': {
              'ExternalID': '50cd43e5-d884-4bbd-8ade-24772e577bbd'
            }
          },
          {
            'ExternalID': 'c028679a-3d51-409b-8258-54566959e1dd',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'be61ba83-0e76-47f3-a216-5ebec4f4a8af'
            },
            'UserDefinedGroup': {
              'ExternalID': '50cd43e5-d884-4bbd-8ade-24772e577bbd'
            }
          },
          {
            'ExternalID': 'a1ab3d60-ecbe-4deb-873d-58febeab0728',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2009-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '48565334-2e8e-488a-ac10-ca235765f275'
            },
            'UserDefinedGroup': {
              'ExternalID': '50cd43e5-d884-4bbd-8ade-24772e577bbd'
            }
          }
        ]
      },
      {
        'IsDeleted': false,
        'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37',
        'FullName': 'Sibling Absence',
        'DisplayOrder': 6,
        'UserDefinedGroupMemberships': [
          {
            'ExternalID': 'dbe0e1b9-fe8e-41fb-952b-b29681fa749d',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'dcf04bc0-7c1f-47f4-a510-350730f4f090'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '1115081d-54f4-427e-b174-c5b78707c153',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0414e9b1-d972-472c-9405-d2470a7497cb'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '9cf94d23-5dd0-4866-8fa7-4cae011a4513',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '4ad9977d-893b-4251-83da-9b5990c9ee35'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '30685af0-965f-4339-9486-7e545e6e5dd4',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a78970f1-4b06-4af1-8259-d6e841a21f74'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'f7cabf54-1533-4b6a-92fd-44a7344aabd8',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7223841d-968e-4def-ac9a-5752a53b46ac'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '476e6419-9189-47c8-b503-c56452374c5e',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'c1f0abf5-e36d-4756-b386-28f1c6c84681'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '78a7f249-caca-47c5-b7ed-5efd3731218b',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '1dc8b4b1-e857-4cac-b4a8-a73b78d6d401'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '4e0c88ec-b954-4e05-9de0-6085e6906123',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '45d9b4c8-0715-4c0a-8738-c24aae04d1f4'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'e3fd75b2-2cd7-4f00-8010-999ee541106f',
            'StartDate': '2015-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '45d9b4c8-0715-4c0a-8738-c24aae04d1f4'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'b0b919c5-27d3-4a80-bc73-c3c84a4ae905',
            'StartDate': '2010-09-01T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'e3d52a5c-b580-4622-b073-e1c461a4c9bc'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'd98afb0b-4f98-4133-aaa0-a5afd8f9de40',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'bd33243a-dc26-4af9-ae89-5541c45ae23d'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '5a8f9471-e390-4eed-b890-4fc42e7971e1',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd3dedc64-cf26-4973-8cd1-ea6418f8d83a'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'da5adde1-5679-45d2-be83-96dc5b84dd57',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'a1664f00-c7ca-4a18-91e1-7c8598ea844c'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '8f1dfed5-ba53-450c-8130-12909f3204b3',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '52b629d9-1706-4efa-8c0d-0cd99dc36c94'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'fbb7f42f-3c92-46d0-acb2-26ce826c835c',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '52b629d9-1706-4efa-8c0d-0cd99dc36c94'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '02003b50-c6ae-4bbb-acda-1e93c43900db',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd00e7da6-e9c5-43b5-bcef-0fc7438a26e4'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'c39b9150-ca68-42a2-8fde-7fce166cf2b6',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '935c75f8-08cf-4701-a4d0-3cd3d0507cb0'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '9d71993d-a6e1-418d-95ee-5572e0e0558b',
            'StartDate': '2015-09-01T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd4f46ce6-5e27-47fe-8933-94c0b810cbba'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '94c45fef-f3de-4d46-b303-7123d74dc27b',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': 'd4f46ce6-5e27-47fe-8933-94c0b810cbba'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'c31c136d-33ec-4991-91ab-bb77ba02cffe',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2fc69a09-4fe9-432c-a0b1-d99c9a4e9cbb'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'de9657ef-6e24-4c8b-b064-fea9970b411d',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '749de4f6-7a99-441c-8a9f-946845c6dfb9'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'edb22e22-fde2-4624-96bf-c9836d700c28',
            'StartDate': '2016-09-01T00:00:00Z',
            'EndDate': '2017-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '0198c2cd-be74-4ef9-8b9e-8f0fc7a8da1a'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '69963bd7-8cc4-40ae-be4d-25137ac52706',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '7822c86e-d20a-49f7-94a2-2c1dbd0a720a'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'a836449c-a70f-4cc1-9791-88f8ed9c0899',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6e8d4f4d-efe1-4681-932e-b28abc4e3685'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '709d3813-0469-458d-9b78-d4a1d79dcaae',
            'StartDate': '2014-09-04T00:00:00Z',
            'EndDate': '2016-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '6e8d4f4d-efe1-4681-932e-b28abc4e3685'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '01c0c5b9-2723-4d26-8e7b-e2757904f4cb',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '24e90747-e125-4480-a04c-3b1525983f1a'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '16bb2131-c52c-4c72-8e37-40315149d64e',
            'StartDate': '2012-09-01T00:00:00Z',
            'EndDate': '2013-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '99ae7799-de2b-415a-9ef2-65a4ada939c2'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '726a34ad-427f-4d16-a301-e4b94ca43c27',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '52b4c00a-954a-48f5-8cae-952d721c08f3'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': 'cda2593d-0cad-4ea6-af92-52ed79d2aeb6',
            'StartDate': '2013-09-01T00:00:00Z',
            'EndDate': '2014-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8e42598b-170b-47b7-80d6-78f903b35bc8'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '681d3105-ee4d-46a1-aca3-868f3488a99a',
            'StartDate': '2011-09-01T00:00:00Z',
            'EndDate': '2012-08-30T00:00:00Z',
            'GroupMember': {
              'ExternalID': '8e42598b-170b-47b7-80d6-78f903b35bc8'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          },
          {
            'ExternalID': '29a974cc-2534-4754-8e23-f0352d923d7f',
            'StartDate': '2008-09-02T00:00:00Z',
            'EndDate': '2011-08-31T00:00:00Z',
            'GroupMember': {
              'ExternalID': '2d91c0fb-682e-4664-8dfc-62fe5adf7061'
            },
            'UserDefinedGroup': {
              'ExternalID': '0c5469ce-f59c-4650-884c-1cf34dbf2f37'
            }
          }
        ]
      }
    ]
  }
}";
	#endregion

	AutoMapper.Mapper.Initialize((config) =>
	{
		config.CreateMap<UserDefinedGroupRegistration, StudentGroupType>()
				.ForMember(x => x.StudentGroupId, o => o.MapFrom(j => j.ExternalId))
				.ForMember(x => x.StudentId, o => o.MapFrom(j => j.GroupMember.ExternalId))
				.ForMember(x => x.GroupId, o => o.MapFrom(j => j.UserDefinedGroup.ExternalId))
				.ForMember(x => x.StartDate, o => o.MapFrom(j => j.StartDate))
				.ForMember(x => x.EndDate, o => o.MapFrom(j => !j.EndDate.HasValue ? null : j.EndDate.Value == DateTime.MinValue ? null : j.EndDate ));
	});
	var jobject = JObject.Parse(data);
	var groups = jobject["UserDefinedGroup"]["UserDefinedGroups"]
				.SelectMany(x => x["UserDefinedGroupMemberships"])
				.Select(x => x.ToObject<UserDefinedGroupRegistration>())
				.Where(x => !x.IsDeleted)
				.Select(x => new StudentGroupRoot(AutoMapper.Mapper.Map<StudentGroupType>(x)));
	groups.Dump();
	//SerializeObject(groups.First(), "http://www.sims.co.uk/CCP/TransferStudentGroup").Dump();
	//groups.Take(3).ToList().ForEach(g => SerializeObject(g, "http://www.sims.co.uk/CCP/TransferStudentGroup").Dump());
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

public class UserDefinedGroupRegistration : Identifier
{
	public Identifier GroupMember { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime? EndDate { get; set; }
	public bool IsDeleted { get; set; }
	public Identifier UserDefinedGroup { get; set; }
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