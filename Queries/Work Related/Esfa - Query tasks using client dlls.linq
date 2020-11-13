<Query Kind="Program">
  <Reference>C:\SFA\src\das-tasks\src\SFA.DAS.Tasks.API.Client\bin\Release\SFA.DAS.NLog.Logger.dll</Reference>
  <Reference>C:\SFA\src\das-tasks\src\SFA.DAS.Tasks.API.Client\bin\Release\SFA.DAS.Tasks.API.Client.dll</Reference>
  <Reference>C:\SFA\src\das-tasks\src\SFA.DAS.Tasks.API.Client\bin\Release\SFA.DAS.Tasks.API.Types.dll</Reference>
  <Namespace>SFA.DAS.Tasks.API.Client</Namespace>
</Query>

void Main()
{
    var l = new SFA.DAS.NLog.Logger.NLogLogger();
    
    var c = new TaskApiClient(new Configuration(),l);
    var r = c.GetTasks("kjbkbkj", "nlnnk", SFA.DAS.Tasks.API.Types.Enums.ApprenticeshipEmployerType.Levy).Result;
    r.Dump();
}

class Configuration : ITaskApiConfiguration
{
    public string ApiBaseUrl => @"https://localhost/";

    public string ClientId => "";

    public string ClientSecret => "";

    public string IdentifierUri => "https://citizenazuresfabisgov.onmicrosoft.com/tasks-api";

    public string Tenant => "citizenazuresfabisgov.onmicrosoft.com";
}


// Define other methods and classes here
