using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Models
{
    public class BonusPoolCalculatorModel
    {
        public int BonusPoolAmount { get; set; }
        public IList<EmployeeModel> Employees { get; set; }        
        public int SelectedEmployeeId { get; set; }
    }
}