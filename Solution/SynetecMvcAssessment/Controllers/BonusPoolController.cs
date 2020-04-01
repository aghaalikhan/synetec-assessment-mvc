using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InterviewTestTemplatev2.Controllers
{
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolService _bonusPoolService;

        public BonusPoolController(IBonusPoolService bonusPoolService)
        {
            _bonusPoolService = bonusPoolService;
        }        
        
        public async Task<ActionResult> Index()
        {
            var model = await _bonusPoolService.GetBonusPoolAsync();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Calculate(BonusPoolCalculatorModel model)
        {            
            var resultingModel = await _bonusPoolService.GetBonusPoolCalculationResultAsync(model.SelectedEmployeeId, model.BonusPoolAmount);         
            
            return View(resultingModel);
        }
    }
}