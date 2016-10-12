<Query Kind="SQL" />

begin 
	set nocount on;

	begin tran

	-- Summary
	begin 
		print 'BEGIN SUMMARY ...'
		print ''
		print '  Database: ' + db_name() 

		print ''
		declare @NoOfDuplicates int, @TotalImpactedRows  int
		select @NoOfDuplicates = count(*), @TotalImpactedRows = sum(total) 	 
		from 
			(select count(*) as total
			from Measure
			group by fkInstallationCompany, ReferenceNumber
			having count(*) > 1) as a
		print '  Total Duplicate Found: ' + convert(varchar, @NoOfDuplicates)
		print '  Total Rows To Update: ' + convert(varchar, @TotalImpactedRows - @NoOfDuplicates)
		print ''
		print 'END SUMMARY' 
		print '' 
	end 

	Print 'BEGIN UPDATE ...'

	declare @installationCompanyId int, @referenceNumber varchar(50), @duplicateCount int

	declare @loopCounter int, @updateCount int
	set @loopCounter = 0
	set @updateCount = 0

	declare duplicate_cursor cursor for
		select 
			fkInstallationCompany, 
			ReferenceNumber, 
			count(*) as duplicateCount
		from Measure
		group by fkInstallationCompany, ReferenceNumber
		having count(*) > 1

	open duplicate_cursor

	fetch next from duplicate_cursor
	into @installationCompanyId, @referenceNumber, @duplicateCount

	while @@fetch_status = 0
	begin 
		set @loopCounter = @loopCounter + 1;
		
		print ''
		print convert(varchar, @loopCounter) + ' - ' + convert(varchar, @installationCompanyId) 
				+ ' - ' + @referenceNumber + ' - ' + convert(varchar,@duplicateCount) 
		

		declare measure_cursor cursor for 
			select top  (@duplicateCount -1) pkMeasureId, ReferenceNumber, fkInstallationCompany
			from Measure
			where fkInstallationCompany = @installationCompanyId
			  and ReferenceNumber = @referenceNumber	
	
		declare @measureId int, @measureRefNum varchar(50), @instCo int
		declare @characterIndex int = 65

		open measure_cursor
		fetch next from measure_cursor
		into @measureId, @measureRefNum, @instCo

		while @@FETCH_STATUS = 0
		begin

			declare @newRefNum varchar(50)
			set @newRefNum = @measureRefNum + '@' + char(@characterIndex)

			declare @existingCount int = 0

			select @existingCount = count(*)
			from Measure
			where fkInstallationCompany = @instCo 
				and ReferenceNumber = @newRefNum

			if (@existingCount = 0)
			begin
				print '  ' + convert(varchar, @measureId) + ': Reference Number updated to ' + @newRefNum
				set @updateCount = @updateCount + 1
				update measure
				set ReferenceNumber = @newRefNum
				where pkMeasureId = @measureId
			end
			else
			begin
				print '  ' + convert(varchar, @measureId) + ' cannot be updated as ' + @newRefNum + ' already exists in the database.'
			end

			set @characterIndex = @characterIndex + 1

			fetch next from measure_cursor
			into @measureId, @measureRefNum, @instCo
		end
	
		close measure_cursor;
		deallocate measure_cursor;

		fetch next from duplicate_cursor
		into @installationCompanyId, @referenceNumber, @duplicateCount

	end

	print ''
	Print 'END UPDATE ...'
	print convert(varchar, @updateCount) + ' rows updated'

	close duplicate_cursor;
	deallocate duplicate_cursor;

	commit tran

end

--Russel's way

SET XACT_ABORT ON; 
BEGIN TRANSACTION; 
	UPDATE dbo.Measure SET ReferenceNumber = a.[ReferenceNumber-Next] 
	OUTPUT deleted.pkMeasureId, deleted.ReferenceNumber as [ReferenceNumber-Previous], inserted.ReferenceNumber as [ReferenceNumber-Next], deleted.[fkInstallationCompany] 
	FROM dbo.Measure as m3 
	INNER JOIN (
		SELECT m2.[pkMeasureId], m2.[ReferenceNumber-Previous], m2.[ReferenceNumber-Next], [2], m2.[fkInstallationCompany], m2.[count] 
		FROM (
			SELECT m.[pkMeasureId], 
				m.[ReferenceNumber] as [ReferenceNumber-Previous], 
				ISNULL(m.[ReferenceNumber],0x) + '@' + CHAR(ROW_NUMBER() OVER (PARTITION BY m.[ReferenceNumber], m.[fkInstallationCompany] ORDER BY m.[pkMeasureId] ASC) + 96) as [ReferenceNumber-Next], 
				CHAR(ROW_NUMBER() OVER (PARTITION BY m.[ReferenceNumber], m.[fkInstallationCompany] ORDER BY m.[pkMeasureId] ASC) % 26 + 96) as [2] , 
				m.[fkInstallationCompany], 
				COUNT(*) OVER (PARTITION BY m.[ReferenceNumber], m.[fkInstallationCompany]) as [count] 
			FROM dbo.Measure as m
		) as m2 
		WHERE m2.[count] > 1
	) as a ON m3.[pkMeasureId] = a.[pkMeasureId]; 
ROLLBACK TRANSACTION; 
