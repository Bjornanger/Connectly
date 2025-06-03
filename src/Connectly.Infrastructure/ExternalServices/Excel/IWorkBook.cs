
using Connectly.Infrastructure.ExternalServices.Excel.ExcelModels;

namespace Connectly.Infrastructure.ExternalServices.Excel
{
    public interface IWorkBook
    {
        string Create(ExcelList list);
    }
}