using Connectly.Domain.Entities;
using Connectly.Infrastructure.ExternalServices.Excel.ExcelModels;

namespace Connectly.Infrastructure.ExternalServices.Excel;

public interface IExcelExportRepository
{
    Task<ExcelFile> CreateExcelFileAsync(ExcelList excelList, string userId);
    Task<MemoryStream> GetExcelFileAsync(Guid fileId);
}