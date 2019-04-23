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
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Caching.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceProcess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.RegularExpressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <NuGetReference>HtmlAgilityPack</NuGetReference>
  <Namespace>HtmlAgilityPack</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Web</Namespace>
</Query>

void Main()
{
    var web = new HtmlWeb();
    var doc = web.Load(@"https://mytuner-radio.com/podcasts/saregama-weekend-classic-retro-music-saregama-india-ltd-1131144827");
    var sourceFolder = @"C:\Users\deven_r7v8vcg\OneDrive\Music\Saregama";
    var webClient = new WebClient();
    
    var nodes = doc.DocumentNode.SelectNodes("//a");
    var urls = nodes.SelectMany(n => n.Attributes).Where(a => a.Name == "data-url").Select(a => a.DeEntitizeValue);
    
    foreach(var url in urls)
    {
        //url = http://saregamawsa.bc.cdn.bitgravity.com/weekend_radio/audio/2018_12_WCR_iTunes_Hindi_Week_4_Lata_And_Asha_Spl.mp3
        var fileName = url.Split('/').Last(); // fileName = 2018_12_WCR_iTunes_Hindi_Week_4_Lata_And_Asha_Spl.mp3
        var filePath = Path.Combine(sourceFolder, fileName);
        if(!File.Exists(filePath))
        {
            webClient.DownloadFile(url, filePath);
            //HttpUtility.UrlDecode(url).Dump();
            fileName.Dump();
        }
    }
}

// Define other methods and classes here