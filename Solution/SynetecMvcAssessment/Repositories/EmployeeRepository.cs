using InterviewTestTemplatev2.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace InterviewTestTemplatev2.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesDbContext _employeesDbContext;

        public EmployeeRepository(EmployeesDbContext employeesDbContext)
        {
            _employeesDbContext = employeesDbContext;
        }

        public async Task<IList<HrEmployee>> GetEmployeesAsync()
        {
            return await _employeesDbContext.HrEmployees.ToListAsync();
        }       
    }
}