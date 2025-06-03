using Connectly.Application.DTOs;
using Connectly.Application.Interfaces;
using Connectly.Application.Interfaces.ServiceInterfaces;
using Connectly.Domain.Entities;
using Connectly.Infrastructure.ExternalServices.Excel;
using ExcelExportExtensionMethods = Connectly.Infrastructure.ExternalServices.Excel.ExcelExportExtensionMethods;
using ExcelList = Connectly.Infrastructure.ExternalServices.Excel.ExcelModels.ExcelList;

namespace Connectly.Infrastructure.ExternalServices;

public class ExcelExportService : IExcelExportService
{
    private readonly IUnitOfWork _uow;
    private readonly ISerilogLogger _logger;


    public ExcelExportService(IUnitOfWork uow, ISerilogLogger logger)
    {
        _uow = uow;
        _logger = logger;
    }

    public async Task<FileResultDto> GetExcelFile(Guid fileId)
    {

        try
        {
            MemoryStream fileStream = await _uow.CreateRepository<IExcelExportRepository>().GetExcelFileAsync(fileId);

            if (fileStream == null)
            {
                _logger.LogInformation($"Could not find file with ID: {fileId}");
                return null;

            }

            string content = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            _logger.LogInformation("File found");
            return new FileResultDto
            {
                FileStream = fileStream,
                ContentType = content

            };
      
           
        }
        catch (Exception e)
        {
            _logger.LogError("Error",e);
            throw;
        }
      
    }

    public async Task<ExcelFile> CreateExcelFileGoodsReceiveOrder(List<object> list, string userId, string listType)
    {

        try
        {
            if (listType == typeof(UserMeetingRegistrationFormDto).Name)
            {
                _logger.LogInformation("Excel file created for form.");

                return await CreateFile<UserMeetingRegistrationFormDto>(list, userId);
            }
            _logger.LogInformation("No Excel file created for form.");
            return null;
        }
        catch (Exception e)
        {
            _logger.LogError("Error", e);

            throw;
        }


       
    }
    public async Task<ExcelFile> CreateFile<T>(List<object> list, string userId)
    {

        try
        {
            ExcelList excelList = new ExcelList();
            excelList = ExcelExportExtensionMethods.CreateList<T>(list);
            var excelObj = await _uow.CreateRepository<IExcelExportRepository>().CreateExcelFileAsync(excelList, userId);
            if (excelObj == null)
            {
                _logger.LogInformation("Excel object are null, No file created");
                return new ExcelFile();
            }
            await _uow.CompleteAsync();
            _logger.LogInformation("Excel file created");
            return excelObj;
          
        }
        catch (Exception e)
        {
            _logger.LogError("Error", e);
            throw;
        }
    
    }
    
}