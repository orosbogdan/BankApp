using BankApp.DTO;
 

namespace BankApp.Services
{
    public interface ReportCreator
    {
        Report GenerateReport(ReportPeriod reportPeriod);
    }
}
