<Query Kind="Program">
  <Connection>
    <ID>60408c34-3117-44f3-909d-bba77b66afde</ID>
    <Persist>true</Persist>
    <Server>etech-dev01</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA8JEdqNgoLEKFrbDwxk5wUgAAAAACAAAAAAADZgAAwAAAABAAAADRyYe4ia2HQxFuFkTq62t5AAAAAASAAACgAAAAEAAAAF2N0QU/OLRKMrr9YS/jJt4QAAAAykMZSyropwoSpYbjs6AqAxQAAAD+zUzq6Vt/7kizl6VoEEzya5DU8Q==</Password>
    <Database>SPHEC_DS</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>E:\WIP\Smart Property Hub EC\DEV\Libraries\Infragistics\InfragisticsWPF4.Documents.Excel.v12.2.dll</Reference>
  <Namespace>Infragistics.Documents.Excel</Namespace>
  <Namespace>Infragistics.Documents.Excel.CalcEngine</Namespace>
  <Namespace>Infragistics.Documents.Excel.Filtering</Namespace>
  <Namespace>Infragistics.Documents.Excel.PredefinedShapes</Namespace>
  <Namespace>Infragistics.Documents.Excel.Serialization.Excel2007</Namespace>
  <Namespace>Infragistics.Documents.Excel.Sorting</Namespace>
</Query>

void Main()
{
	
	var sourceWb = readFromBytes();
	var targetWb = new Workbook(WorkbookFormat.Excel2007);
	var sourceWs = sourceWb.Worksheets[0];
	var targetWs = targetWb.Worksheets.Add("Success Rows");
	var totalRows = sourceWs.Rows.Count();
	var totalColumns = getHeaderRowAndTotalCols(sourceWs.Rows[0], targetWs.Rows[0]);
	
	Console.WriteLine(targetWs.Name + " rows " + totalRows + " cols " + totalColumns);	

	for (var row = 1; row <= totalRows; row ++)
	{
		copyRow(sourceWs.Rows[row], targetWs.Rows[row], totalColumns);
	}

	targetWb.Save(@"e:\Temp\test2.xlsx");
	
}

Workbook readFromBytes()
{
	var file = MeasureImportFileBytes.FirstOrDefault (mifb => mifb.FkMeasureImportFile == 7120 );
	Console.WriteLine(file.PkMeasureImportFileBytesId);
	
	using (var stream = new MemoryStream(file.SpreadsheetFile.ToArray()))
	{
		return Workbook.Load(stream);
	}
	
}

Workbook readFromFolder()
{
	return Workbook.Load(@"E:\Temp\Test.xlsx");
	
}

void copyRow(WorksheetRow sourceRow, WorksheetRow targetRow, int numberOfColumns)
{
	Console.WriteLine(sourceRow.Cells[0].ToString());
	for (var col = 0; col <= numberOfColumns; col ++)
	{
		targetRow.Cells[col].Value = sourceRow.Cells[col].Value;
	}
}


int getTotalCol(WorksheetRow row)
{
	bool colRead = true;
	int col = -1;
	while (colRead)
		{
			col++;
			try
			{
				var cellValue = row.Cells[col].Value.ToString();
				Console.WriteLine(row.Index + ":" + col + "=" + cellValue);
			}
			catch
			{
				Console.WriteLine(col);
				colRead = false;
			}
		}
	return col;
}

int getHeaderRowAndTotalCols(WorksheetRow sourceRow, WorksheetRow targetRow)
{
	bool colRead = true;
	int col = -1;
	while (colRead)
		{
			col++;
			if(sourceRow.Cells[col].Value != null)
			{
				targetRow.Cells[col].Value = sourceRow.Cells[col].Value;		
				Console.WriteLine(sourceRow.Index + ":" + col + "=" + sourceRow.Cells[col].Value.ToString());
			}
			else
			{
				Console.WriteLine(col);
				colRead = false;
			}
		}
	return col;
}



// Define other methods and classes here