using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTestTemplatev2.Services
{
    public class BonusPoolService : IBonusPoolService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public BonusPoolService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<BonusPoolCalculatorModel> GetBonusPoolAsync()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();

            return new BonusPoolCalculatorModel
            {
                Employees = employees.Select(employee => new EmployeeModel
                {
                    ID = employee.ID,
                    FullName = employee.Full_Name
                }).ToList()
            };
        }

        public async Task<BonusPoolCalculatorResultModel> GetBonusPoolCalculationResultAsync(int employeeId, int totalBonusPool)
        {
            if(employeeId == default(int))
            {
                throw new ArgumentException($"invalid value supplied for {nameof(employeeId)}");
            }

            var employees = await _employeeRepository.GetEmployeesAsync();
            var selectedEmployee = employees.FirstOrDefault(employee => employee.ID == employeeId);

            if(selectedEmployee == null)
            {                
                throw new Exception("Invalid employee Id supplied");
            }

            var sumOfSalaries = (decimal)employees.Sum(employee => employee.Salary);
            var bonusPercentage = selectedEmployee.Salary / sumOfSalaries;
            var bonusAllocation = (int)(bonusPercentage * totalBonusPool);

            return new BonusPoolCalculatorResultModel
            {
                Employee = new EmployeeModel
                {
                    ID = selectedEmployee.ID,
                    FullName = selectedEmployee.Full_Name
                },
                bonusPoolAllocation = bonusAllocation
            };                
        }
    }
}