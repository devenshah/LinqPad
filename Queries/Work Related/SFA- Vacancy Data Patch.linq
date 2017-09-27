<Query Kind="Statements">
  <Connection>
    <ID>f33c60d6-bc3f-49eb-b8e7-04c45f2936e3</ID>
    <Persist>true</Persist>
    <Server>amxjinl30w.database.windows.net</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>AvmsPlus-Prod_2017-07-12T01-00Z_Copy</Database>
    <UserName>valtech_dshah</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAWx3N3MuYNEy0uTk0+2QJOwAAAAACAAAAAAAQZgAAAAEAACAAAAAI3GB18X+RIWNBch96OlWvvGgQVb1gWabg7NY4rH1WuAAAAAAOgAAAAAIAACAAAAC+X2usfOwh9jnTlGYHSGhAjutDWP8M1RqSJxtAFcY+ATAAAABqrqF5Y92PYcDugm643knqEafOgTZ7iSDx3n4BJEL7l0rf0IFJA+TtVYx7gUbsglJAAAAAQbEdj8G5DF2gSoZQaVApYUv7Vt0zvu3otTKFBCTSZV55mTy5lICtog1bmVylAEWnJkov7R6yLcqUKZrHd/vRQQ==</Password>
    <DbVersion>Azure</DbVersion>
    <IsProduction>true</IsProduction>
  </Connection>
</Query>

/*
var arr = new[] {
-148776,

-114672
};

string.Join(",", arr).Dump();
*/


var vacancyIds = new[] {
-143561,
-143549
};

var newline = Environment.NewLine;

var query = "select VacancyId, AddressLine1, AddressLine2, AddressLine3, AddressLine4, AddressLine5, Town, PostCode, LocalAuthorityId, GeocodeEasting, GeocodeNorthing, Longitude, Latitude" + newline;
query += $"   into #OriginalValues {newline}  from Vacancy {newline} where vacancyid in ({newline} {string.Join(",", vacancyIds)} {newline} )"  ;
query.Dump();
newline.Dump();


query = "declare @UpdatedValues table (" + newline;
query += "  VacancyId int," + newline;
query += "  AddressLine1 nvarchar(max),"+ newline;
query += "  AddressLine2 nvarchar(max),"+ newline;
query += "  AddressLine3 nvarchar(max),"+ newline;
query += "  AddressLine4 nvarchar(max),"+ newline;
query += "  AddressLine5 nvarchar(max),"+ newline;
query += "  Town nvarchar(max),"+ newline;
query += "  PostCode nvarchar(max),"+ newline;
query += "  LocalAuthorityId int,"+ newline;
query += "  GeocodeEasting int,"+ newline;
query += "  GeocodeNorthing int,"+ newline;
query += "  Longitude decimal(13,10),"+ newline;
query += "  Latitude decimal(13,10))"+ newline;
query.Dump();

"begin tran".Dump();
newline.Dump();

Vacancies
	.Where(v => vacancyIds.Contains(v.VacancyId))
	.Select(v => new {
		VacancyId = v.VacancyId, 
		AddressLine1 = v.AddressLine1, 
		AddressLine2 = v.AddressLine2, 
		AddressLine3 = v.AddressLine3, 
		AddressLine4 = v.AddressLine4, 
		AddressLine5 = v.AddressLine5, 
		Town = v.Town, 
		PostCode = v.PostCode, 
		LocalAuthorityId = v.LocalAuthorityId, 
		GeocodeEasting = v.GeocodeEasting, 
		GeocodeNorthing = v.GeocodeNorthing, 
		Longitude = v.Longitude, 
		Latitude = v.Latitude})
	.ToList()
	.ForEach(v => {
		query = "Update Vacancy" + newline;
		query += "Set " + newline;
		query += $"  {nameof(v.AddressLine1)} = '{v.AddressLine1.Replace("'", "''")}'" + newline;
		if (v.AddressLine2 != null) query += "  ," + $"{nameof(v.AddressLine2)} = '{v.AddressLine2.Replace("'", "''")}'" + newline;
		if (v.AddressLine3 != null) query += "  ," + $"{nameof(v.AddressLine3)} = '{v.AddressLine3.Replace("'", "''")}'" + newline;
		if (v.AddressLine4 != null) query += "  ," + $"{nameof(v.AddressLine4)} = '{v.AddressLine4.Replace("'", "''")}'" + newline;
		if (v.AddressLine5 != null) query += "  ," + $"{nameof(v.AddressLine5)} = '{v.AddressLine5.Replace("'", "''")}'" + newline;
		if (v.Town != null) query += "  ," + $"{nameof(v.Town)} = '{v.Town.Replace("'", "''")}'" + newline;
		if (v.PostCode != null) query += "  ," + $"{nameof(v.PostCode)} = '{v.PostCode}'" + newline;
		if (v.LocalAuthorityId.HasValue) query += "  ," + $"{nameof(v.LocalAuthorityId)} = {v.LocalAuthorityId}" + newline;
		if (v.GeocodeEasting.HasValue) query += "  ," + $"{nameof(v.GeocodeEasting)} = {v.GeocodeEasting}" + newline;
		if (v.GeocodeNorthing.HasValue) query += "  ," + $"{nameof(v.GeocodeNorthing)} = {v.GeocodeNorthing}" + newline;
		if (v.Longitude.HasValue) query += "  ," + $"{nameof(v.Longitude)} = {v.Longitude}" + newline;
		if (v.Latitude.HasValue) query += "  ," + $"{nameof(v.Latitude)} = {v.Latitude}" + newline;
		query += "output" + newline;
		query += $"  inserted.{nameof(v.VacancyId)}," + newline;
		query += $"  inserted.{nameof(v.AddressLine1)}," + newline;
		query += $"  inserted.{nameof(v.AddressLine2)}," + newline;
		query += $"  inserted.{nameof(v.AddressLine3)}," + newline;
		query += $"  inserted.{nameof(v.AddressLine4)}," + newline;
		query += $"  inserted.{nameof(v.AddressLine5)}," + newline;
		query += $"  inserted.{nameof(v.Town)}," + newline;
		query += $"  inserted.{nameof(v.PostCode)}," + newline;
		query += $"  inserted.{nameof(v.LocalAuthorityId)}," + newline;
		query += $"  inserted.{nameof(v.GeocodeEasting)}," + newline;
		query += $"  inserted.{nameof(v.GeocodeNorthing)}," + newline;
		query += $"  inserted.{nameof(v.Longitude)}," + newline;
		query += $"  inserted.{nameof(v.Latitude)}" + newline;
		query += "into @UpdatedValues" + newline;
		query += $"Where VacancyId = {v.VacancyId}"+ newline ;
		query.Dump();
	});
	
"select * from (select 'new' as t, * from @UpdatedValues union select 'old' as t, * from #OriginalValues) as a order by a.vacancyid, t".Dump();
newline.Dump();

"rollback tran".Dump();
newline.Dump();

"drop table #OriginalValues".Dump();
newline.Dump();