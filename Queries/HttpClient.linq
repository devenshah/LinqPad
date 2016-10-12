<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Framework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Tasks.v4.0.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Utilities.v4.0.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.DataAnnotations.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.Protocols.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.EnterpriseServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Caching.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceProcess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.RegularExpressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <NuGetReference>Microsoft.AspNet.WebApi.Client</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Formatting</Namespace>
  <Namespace>System.Net.Http.Handlers</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Joins</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.PlatformServices</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>System.Reactive.Threading.Tasks</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Web</Namespace>
</Query>

void Main()
{
	//CallApiGetMethod();
	CallApiPostMethod().Wait();
}


public async Task CallApiPostMethod()
{
	var url = "http://localhost.fiddler:44302/api/uvalue/wall";
	var request = new WallUValueRequest()
	{
		AgeBand= "a",
		Country = "eaw",
		ConstructionType="solid brick",
		InsulationType="internal",
		InsulationThickness="150",
		WallThickness=300,
	};
	
	using(var client = new HttpClient())
	{
//		client.DefaultRequestHeaders.Accept.Clear();
//		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
//		var response = await client.PostAsXmlAsync<WallUValueRequest>(url, request);
		
		var response = await client.PostAsJsonAsync<WallUValueRequest>(url, request);
		
		var result = await response.Content.ReadAsAsync<UValueResult>();
		result.Dump();
	};	
}













public void CallApiGetMethod()
{
	var helper = new HttpHelper("https://localhost.fiddler:44302/api/");
	var parameters = new Dictionary<string, string>()
	{
		{"ageBand","a"},
		{"country","eaw"},
		{"constructionType","solid brick"},
		{"insulationType","internal"},
		{"insulationThickness","150"},
		{"wallThickness","300"},
	};
	var response = helper.GetAsync<UValueResult>("/uvalue/wall", parameters);
	response.Dump();
}

public void CallApiPostMethod1()
{
	var helper = new HttpHelper("https://localhost.fiddler:44302/api/");
	var parameters = new Dictionary<string, string>();
	var request = new WallUValueRequest()
	{
		AgeBand= "a",
		Country = "eaw",
		ConstructionType="solid brick",
		InsulationType="internal",
		InsulationThickness="150",
		WallThickness=300,
	};
//	var response = helper.PostAsJsonAsync<WallUValueRequest, UValueResult>(request, "/uvalue/walluvalue", parameters);
//	response.Dump();
	var response = helper.PostAsXmlAsync<WallUValueRequest, UValueResult>(request, "/uvalue/walluvalue", new Dictionary<string,string>());
	response.Dump();
}


public class UValueResult
{
	public decimal UValue { get; set; }
	public string Error { get; set; }
}

public class WallUValueRequest
{
   public string Country { get; set; }
   public string AgeBand { get; set; }
   public string ConstructionType { get; set; }
   public string InsulationType { get; set; }
   public string InsulationThickness { get; set; }
   public decimal? WallThickness { get; set; }
}


public class HttpHelper
    {
        private static string RdsapApiBaseUrl;

        public string GetRdsapBaseUrl()
        {
            return RdsapApiBaseUrl;
        }

//        static HttpHelper()
//        {
//            var setting = ConfigurationManager.AppSettings["CalculationServiceUrl"];
//            if (string.IsNullOrWhiteSpace(setting))
//                throw new Exception("Api base url must be set in the config file.");
//            RdsapApiBaseUrl = string.Format("{0}/{1}", setting, "api") ;
//        }
		public HttpHelper(string path)
		{
			RdsapApiBaseUrl = path;
		}
		
		public async Task<T> GetAsync<T>(string relativeUrl, Dictionary<string, string> urlParameters) where T : class
        {
            var parameters = ConvertToUrlParameters(urlParameters);
            var validUrl = GetValidatedApiUrl(RdsapApiBaseUrl, relativeUrl, parameters);
			validUrl.Dump();
            using(var client = new HttpClient()) 
            {
                var response = await client.GetAsync(validUrl);
                return await response.Content.ReadAsAsync<T>();
            };
        }

        public async Task<O> PostAsJsonAsync<I, O>(I inParam, string relativeUrl, Dictionary<string, string> urlParameters)
        {
            using(var client = new HttpClient())
            {
                var parameters = ConvertToUrlParameters(urlParameters);
                var validUrl = GetValidatedApiUrl(RdsapApiBaseUrl, relativeUrl, parameters);
                var response = await client.PostAsJsonAsync<I>(validUrl.ToString(), inParam);
                var result = await response.Content.ReadAsAsync<O>();
                return result;
            };
        }
		
 		public async Task<O> PostAsXmlAsync<I, O>(I inParam, string relativeUrl, Dictionary<string, string> urlParameters)
        {
            var parameters = ConvertToUrlParameters(urlParameters);
            var validUrl = GetValidatedApiUrl(RdsapApiBaseUrl, relativeUrl, parameters);
            using (var client = new HttpClient())
            {
                var response = await client.PostAsXmlAsync<I>(validUrl.ToString(), inParam);
                var result = await response.Content.ReadAsAsync<O>();
                return result;
            };
        }

        public IObservable<T> GetObservable<T>(string relativeUrl, Dictionary<string, string> urlParameters) where T : class
        {
            var parameters = ConvertToUrlParameters(urlParameters);
            var validUrl = GetValidatedApiUrl(RdsapApiBaseUrl, relativeUrl, parameters);
            var obs = Observable.Using(() => new HttpClient(), client => 
            {
                var response = client.GetAsync(validUrl).ToObservable();
                return response;
            })
            .SelectMany(response => 
            {
                var result = response.Content.ReadAsAsync<T>().ToObservable();
                return result;
            });
            return obs;
        }

        public IObservable<O> PostAsJson<I, O>(I inParam, string relativeUrl, Dictionary<string, string> urlParameters)
        {
            var obs = Observable.Using(() => new HttpClient(), client =>
            {
                var parameters = ConvertToUrlParameters(urlParameters);
                var validUrl = GetValidatedApiUrl(RdsapApiBaseUrl, relativeUrl, parameters);
                var response = client.PostAsJsonAsync<I>(validUrl.ToString(), inParam).ToObservable();
                return response;
            })
            .SelectMany(response => 
            {
                var result = response.Content.ReadAsAsync<O>();
                return result;
            });
            return obs;
        }

        public IObservable<O> PostAsXml<I, O>(I inParam, string relativeUrl, Dictionary<string, string> urlParameters)
        {
            var obs = Observable.Using(() => new HttpClient(), client =>
            {
                var parameters = ConvertToUrlParameters(urlParameters);
                var validUrl = GetValidatedApiUrl(RdsapApiBaseUrl, relativeUrl, parameters);
                var response = client.PostAsXmlAsync<I>(validUrl.ToString(), inParam).ToObservable();
                return response;
            })
            .SelectMany(response =>
            {
                var result = response.Content.ReadAsAsync<O>();
                return result;
            });
            return obs;
        }

        public string ConvertToUrlParameters(Dictionary<string, string> keyValueCollection)
        {
            var builder = new StringBuilder();
            foreach (var item in keyValueCollection)
            {
                if (builder.Length > 0)
                    builder.Append("&");
                var param = ConvertToUrlParameter(item.Key, item.Value);
                builder.Append(param);
            }
            return builder.ToString();
        }

        public string ConvertToUrlParameter(string key, string value)
        {
            var encodedValue = HttpUtility.UrlEncode(value);
            var result = string.Format("{0}={1}", key, encodedValue);
            return result;
        }

        public Uri GetValidatedApiUrl(string baseUrl, string relativeApiRoute, string parameters)
        {			
            var fullUrl = string.Format("{0}/{1}", RdsapApiBaseUrl, relativeApiRoute);
            if (!string.IsNullOrWhiteSpace(parameters))
                fullUrl = string.Format("{0}?{1}", fullUrl, parameters);
            if (!Uri.IsWellFormedUriString(fullUrl, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("Invalid API route", "relativeApiRoute");
            return new Uri(fullUrl);
        }

    }