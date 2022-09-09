using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.BLL.Concrete;
using WebProject.Entity.Concrete;
using WebProject.UI.Models;

namespace WebProject.UI.Controllers
{
    public class ResultsPageController : Controller
    {
        private EF_IncomeExpense _IncomeExpense;
        private EF_Report _Report;

        public ResultsPageController()
        {
            _IncomeExpense = new EF_IncomeExpense();
            _Report = new EF_Report();
        }
        
        private List<ViewModel> ModelList()
        {
            List<ViewModel> model = new List<ViewModel>();

            foreach (var item1 in _Report.GetList())
            {
                ViewModel m1 = new ViewModel();
                IncomeExpense modell = _IncomeExpense.Get(x => x.ID == item1.IncomeExpenseTableID);

                m1.IncomeExpenseID = modell.ID;
                m1.Name = modell.Name;
                m1.IsExpense = modell.IsExpense;
                m1.IsIncome = modell.IsIncome;
                m1.IsOneTime = modell.IsOneTime;
                m1.Total = item1.Total;


                model.Add(m1);
            }

            return model;
        }

        // GET: ResultsPage
        public ActionResult ResultPage()
        {
            return View(ModelList());
        }
    }
}