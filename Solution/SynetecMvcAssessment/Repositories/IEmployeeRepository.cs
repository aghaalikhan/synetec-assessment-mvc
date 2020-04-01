using InterviewTestTemplatev2.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTestTemplatev2.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IList<HrEmployee>> GetEmployeesAsync();
    }
}