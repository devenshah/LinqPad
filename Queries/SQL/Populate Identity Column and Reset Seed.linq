<Query Kind="SQL">
  <Connection>
    <ID>9d163a45-8c54-4ee3-8417-d1a85b87cc50</ID>
    <Server>localsql</Server>
    <Database>SmartPropertyHubEC.Database</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Linq.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.Core.dll</Reference>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.Interfaces.dll</Reference>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.Linq.dll</Reference>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.PlatformServices.dll</Reference>
  <NuGetReference>EntityFramework</NuGetReference>
  <Namespace>Microsoft.Win32</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Joins</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.PlatformServices</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>System.Reactive.Threading.Tasks</Namespace>
</Query>

If Exists ( SELECT TOP 1 pkMeasureId, MeasureId 
			FROM Measure m
			LEFT OUTER JOIN OfgemMeasureReferenceNumber o on m.pkMeasureId = o.MeasureId
			WHERE o.MeasureId IS NULL
			)
BEGIN
	BEGIN TRAN ofgemrefnum

	SET IDENTITY_INSERT OfgemMeasureReferenceNumber ON;

	INSERT INTO OfgemMeasureReferenceNumber 
			(OfgemMeasureReferenceNumberId, MeasureId)
		SELECT 
			CONVERT(int, SUBSTRING(OfgemMeasureReferenceNumber, 4, 7)), PkMeasureId
		FROM
			Measure

	SET IDENTITY_INSERT OfgemMeasureReferenceNumber OFF;

	DECLARE @OfgemReferenceSeed AS INTEGER;

	SELECT @OfgemReferenceSeed = MAX(OfgemMeasureReferenceNumberId) FROM OfgemMeasureReferenceNumber;

	DBCC CHECKIDENT (OfgemMeasureReferenceNumber, RESEED, @OfgemReferenceSeed);

	COMMIT TRAN ofgemrefnum
END
-- To check the current seed
-- DBCC CHECKIDENT (Measure, NORESEED)
-- SELECT IDENT_CURRENT ('Measure')