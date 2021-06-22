<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>

var invalidDate = "text";
$"{invalidDate:yyMMdd}".Dump(); //dumps text

var validDate = DateTime.Now;
$"{validDate:yy-MM-dd}".Dump(); //dumps date

$"{validDate:o}".Dump("round trip"); 

$"{validDate:d}".Dump("round trip");


DateTime.TryParseExact("20210502", "yyyyMMdd", null, DateTimeStyles.AssumeUniversal, out var result);
result.Dump();