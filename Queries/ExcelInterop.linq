<Query Kind="Program">
  <GACReference>Microsoft.Office.Interop.Excel, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c</GACReference>
  <GACReference>Microsoft.Office.Tools.Excel, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
  <Namespace>Microsoft.Office.Core</Namespace>
  <Namespace>Microsoft.Office.Interop.Excel</Namespace>
  <Namespace>Microsoft.Office.Interop.SmartTag</Namespace>
  <Namespace>Microsoft.Office.Tools.Excel</Namespace>
  <Namespace>Microsoft.Vbe.Interop</Namespace>
</Query>

void Main()
{
	var app = new Application();
	var wb = app.Workbooks.Open(@"E:\Temp\Test.xlsx");
	var ws = (Worksheet)wb.Sheets["Sheet1"];
	var lastRow = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
	Console.WriteLine(lastRow.ToString());	
	
	var newBk = app.Workbooks.Add();
	Worksheet successRows = newBk.Worksheets.Add();
	successRows.Name = "Success Rows";
	
	for(int i = 0; i <= lastRow; i++)
	{
		if (isEven(i))
		{
			Range row = ws.Range("A"+i)
		}
	}
}

bool isEven(int i)
{
	return i % 2 == 0;
}

// Define other methods and classes here
