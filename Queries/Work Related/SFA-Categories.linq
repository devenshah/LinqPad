<Query Kind="Program">
  <Connection>
    <ID>9fda2364-1388-43c3-afa8-e978ee24bf2c</ID>
    <Persist>true</Persist>
    <Server>tcp:he0ifp6r12.database.windows.net,1433</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>AvmsPlus-SIT</Database>
    <UserName>faa_dev1@he0ifp6r12</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAATpjh3jVavE2ydIV/7is0zAAAAAACAAAAAAAQZgAAAAEAACAAAAAMYzP6g4dv9qrwHCfnwEfrUUaXdzyU8TazRdX6eRxzGAAAAAAOgAAAAAIAACAAAACVYTKYbaRguoVKOhPiP+X1TCBs5Eg5LmPVLS0fgGZ2KzAAAAC5Z+1LkXRxkxuSsZKMnh95rOhQ2mLsdXesboMWtabkh6QFvFDOOMbXl6oh49NCHEpAAAAAEuOtomPeqZVPK31ZEu7ozIDIUJzw1a9EfFFaTMJ6ofIlEavOzK0VNXAm/LYSx1KwmZ9fa60Jj2wSSkgvP8j/Dw==</Password>
    <DbVersion>Azure</DbVersion>
  </Connection>
</Query>

void Main()
{
	GetFrameworks().Log();
	GetSectors().Log();
}

private IEnumerable<dynamic> GetFrameworks()
{
	var dbOccupations = ApprenticeshipOccupations;
	var dbFrameworks = ApprenticeshipFrameworks;

	return  dbOccupations.Select(
				x =>
					new
					{
						CodeName = x.Codename,
						Id = x.ApprenticeshipOccupationId,
						FullName = x.FullName,
						ShortName = x.ShortName,
						Status = x.ApprenticeshipOccupationStatusTypeId,
						Frameworks =
							dbFrameworks.Where(af => af.ApprenticeshipOccupationId == x.ApprenticeshipOccupationId)
								.Select(y => y).ToList()
					}
				).ToList();
}

private IEnumerable<dynamic> GetSectors()
{
	
//	Standards.Take(2).Log();
//	StandardSectors.Take(2).Log();
//	EducationLevels.Take(2).Log();

	var standards = Standards;
	return StandardSectors.Select(ss => new 
	{
	    ss.ApprenticeshipOccupationId,
		ss.FullName,
		ss.StandardSectorId,
		Standards = standards.Where(std => std.StandardSectorId == ss.StandardSectorId).ToList()	
	});
}