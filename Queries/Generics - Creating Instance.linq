<Query Kind="Program" />

void Main()
{
	CreateNewError<MeasureFootPrintImportFileError>().Dump();
	
	CreateNewError<MeasureImportFileError>().Dump();
}

private T CreateNewError<T>() where T : IImportFileError
{
	var instance = Activator.CreateInstance<T>();
	instance.SetImportFileId (101);
	instance.SetSeverityId (1);
	instance.RowIndex = 1;
	instance.FieldName = "field1";
	instance.FieldContent = "content";
	instance.Message = "all hell broke loose";
	return instance;
}


    public interface IImportFileError
    {

        string Message { get; set; }

        int RowIndex { get; set; }

        string FieldName { get; set; }

        string FieldContent { get; set; }

        DateTime CreatedDate { get; set; }

        void SetImportFileId(int id);

        void SetSeverityId(int id);
    }


    public partial class MeasureFootPrintImportFileError : IImportFileError
    {
		public string Message { get; set; }

        public int RowIndex { get; set; }

        public string FieldName { get; set; }

        public string FieldContent { get; set; }

        public DateTime CreatedDate { get; set; }
		
		public int fkMeasureFootPrintImportFile { get; set; }
		
        public void SetImportFileId(int id)
        {
            fkMeasureFootPrintImportFile = id;
        }

        public void SetSeverityId(int id)
        {
            //not required for footprint
            return;
        }
		
		public override string ToString()
        {
            return string.Format("FileId: {0}, FieldName: {1}",fkMeasureFootPrintImportFile, FieldName);
        } 
    }

    public partial class MeasureImportFileError : IImportFileError
    {
		public string Message { get; set; }

        public int RowIndex { get; set; }

        public string FieldName { get; set; }

        public string FieldContent { get; set; }

        public DateTime CreatedDate { get; set; }
		
		public int fkMeasureImportFile { get; set; }
		
		public int MeasureImportFileErrorSeverityId { get; set; }
		
        public void SetImportFileId(int id)
        {
            fkMeasureImportFile = id;
        }

        public void SetSeverityId(int id)
        {
            MeasureImportFileErrorSeverityId = id;
        }
		
		public override string ToString()
        {
            return string.Format("FileId: {0}, Severity: {1}",fkMeasureImportFile, MeasureImportFileErrorSeverityId);
        } 

    }
