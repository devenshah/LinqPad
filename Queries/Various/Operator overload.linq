<Query Kind="Program">
  <Connection>
    <ID>536b2f1b-b7dd-4c78-9913-d8d6fbf7e9e6</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DCOL-DAS-SqlServer-WEU.database.windows.net</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>DASPayments</Database>
    <SqlSecurity>true</SqlSecurity>
    <UserName>DASPaymentROUser</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAeIJ8+4/2jUyCQ0tlOZ9uSgAAAAACAAAAAAAQZgAAAAEAACAAAAAEXOy3/3k/sseiFurxL9p3GfNS39CBHhZf1fV+lJSuPAAAAAAOgAAAAAIAACAAAADdz+WXej0+vvymyRhR1ytqRWNjHMwxSsF+YODiAEaxD1AAAADUefvmBO3sv4RNDE/fTg0gRLz/PQNcPq2wzbtPu2ak6G5MTZcmLvIo5Mkj0cZZoQhk7r8zbipeCjDjAMGUa5CV7HwVWNcDjktIpFpPapEvJUAAAADgW33hw4lBC6PDJHmQ5IDQqsRfXtMXNp8+3ZBUGLPbJ1Wo/r9+/PRRGzOqGLMKQNsXJK1O28DPaCSrSWsvKrjg</Password>
    <DbVersion>Azure</DbVersion>
  </Connection>
</Query>

void Main()
{
    var a = new AcademicYear(DateTime.Today.AddYears(1));
    a.ToString().Dump();
    (a - 1).ToString().Dump();
}

public struct AcademicYear
{
    public DateTime StartingDate { get; }
    public short ShortRepresentation { get; }

    public override string ToString() =>
        $"{StartingDate.Year} - {StartingDate.Year + 1}";

    public AcademicYear(DateTime instant)
    {
        var year = instant.Month >= 8 ? instant.Year : instant.Year - 1;
        StartingDate = new DateTime(year, 08, 01);
        var tens = year % 100;
        ShortRepresentation = (short)((tens * 100) + tens + 1);
    }

    public static AcademicYear operator +(AcademicYear d, int years)
        => new AcademicYear(
            new DateTime(
                d.StartingDate.Year + years,
                d.StartingDate.Month,
                d.StartingDate.Day));
    public static AcademicYear operator -(AcademicYear d, int years)
        => d + (-years);
}