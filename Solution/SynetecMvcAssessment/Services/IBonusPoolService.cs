using InterviewTestTemplatev2.Models;
using System.Threading.Tasks;

namespace InterviewTestTemplatev2.Services
{
    public interface IBonusPoolService
    {
        Task<BonusPoolCalculatorModel> GetBonusPoolAsync();
        Task<BonusPoolCalculatorResultModel> GetBonusPoolCalculationResultAsync(int employeeId, int totalBonusPool);
    }
}