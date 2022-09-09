using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Models
    //looks of the IncomeExpense and boolean of whether it is an income, expense or OTP
{
    public class ViewModel
    {
        public int IncomeExpenseID { get; set; }
        public string Name { get; set; }
        public float Total { get; set; }
        public bool IsIncome { get; set; }
        public bool IsExpense { get; set; }
        public bool IsOneTime { get; set; }
    }
}