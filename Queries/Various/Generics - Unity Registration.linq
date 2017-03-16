<Query Kind="Program">
  <NuGetReference>Unity</NuGetReference>
  <Namespace>Microsoft.Practices.Unity</Namespace>
  <Namespace>Microsoft.Practices.Unity.Configuration</Namespace>
</Query>

void Main()
{
	var container = new UnityContainer();
	container.RegisterType(typeof(IErrorService<>), typeof(ErrorService<>));
	var svc = container.Resolve<ImportService>();
	svc.ShowError();
	IErrorService<MeasureImportFileError> newSvc = new ErrorService<MeasureImportFileError>();
	newSvc.CreateError();
//	container.RegisterInstance<Person>("dev", new Person{Name="Deven"});
//	container.RegisterInstance<Person>("sum", new Person{Name="Suman"});	
//	var str = container.Resolve<Person>("dev");
//	str.Dump();
//	str = container.Resolve<Person>("sum");
//	str.Dump();
}

//public class Person { public string Name { get; set; }}

public class ImportService
{
	IErrorService<MeasureFootPrintImportFileError> _errorService;
	public ImportService(IErrorService<MeasureFootPrintImportFileError> errorService)
	{
		_errorService = errorService;
	}
	
	public void ShowError()
	{	
		var err = _errorService.CreateError(10001, 1, "category", "hhcro", "ERR2001", 1);
		err.Dump();
	}
}

public interface IErrorService<out T> where T : IImportFileError
{
	T CreateError(int importFileId, int rowIndex,
            string fieldName, string fieldContent,
            string errorCode, int severityId);
}

public class ErrorService<T> : IErrorService<T> where T : IImportFileError
{
	public T CreateError(int importFileId, int rowIndex,
            string fieldName, string fieldContent,
            string errorCode, int severityId)
	{
		var instance = Activator.CreateInstance<T>();
		instance.SetImportFileId (importFileId);
		instance.SetSeverityId (severityId);
		instance.RowIndex = rowIndex;
		instance.FieldName = fieldName;
		instance.FieldContent = fieldContent;
		instance.Message = errorCode;
		return instance;
	}
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