<Query Kind="Program" />

void Main()
{
	var addError = addErrorToAllRowsInProperty(propertyRows, _importFileErrorService);

    ValidatePropertyImportAddress(propertyRows, addError);
	
	addError(error);
}


private Func<IList<ImportRowBase>, IImportErrorService<IImportFileError>,
            Action<IImportFileError>> addErrorToAllRowsInProperty = (importRows, service) =>
{
  Action<IImportFileError> action = (error) =>
  {
      foreach (var importRow in importRows)
      {
          var newError = service.CopyError(importRow.RowIndex, error);
          importRow.AddError(newError);
      }
  };
  return action;
};