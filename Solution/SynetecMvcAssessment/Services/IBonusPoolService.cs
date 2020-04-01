using InterviewTestTemplatev2.Models;
using System.Threading.Tasks;

namespace InterviewTestTemplatev2.Services
{
    public interface IBonusPoolService
    {
        Task<BonusPoolCalculatorModel> GetBonusPool();
        Task<BonusPoolCalculatorResultModel> GetBonusPoolResult(int employeeId, int totalBonusPool);
    }
}