using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.BLL.Concrete;
using WebProject.Entity.Concrete;

namespace WebProject.UI.Controllers
{
    public class BudgetCalculatorController : Controller
    {
        private EF_IncomeExpense _IncomeExpense;
        private EF_Report _Reports;

        public BudgetCalculatorController()
        {
            _IncomeExpense = new EF_IncomeExpense();
            _Reports = new EF_Report();
        }

        // GET: BudgetCalculator
        public ActionResult BasePage()
        {
            return View(_IncomeExpense.GetList());
        }

        public ActionResult BaseAddUpdateDeletePage()
        {
            return View();
        }

        public JsonResult GetAllIncomeExpense()
        {
            return Json(_IncomeExpense.GetList(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddIncomeExpenseModalPopUp()
        {
            try
            {
                return PartialView("AddIncomeExpenseModalPopUp");
            }
            catch (Exception ex)
            {
                return PartialView("AddIncomeExpenseModalPopUp");
            }
        }

        public ActionResult UpdateIncomeExpenseModalPopUp(int ID)
        {
            try
            {
                var _model = _IncomeExpense.Get(x => x.ID == ID);
                return PartialView("UpdateIncomeExpenseModalPopUp", _model);
            }
            catch (Exception ex)
            {
                return PartialView("UpdateIncomeExpenseModalPopUp");
            }
        }

        public JsonResult AddIncomeExpense(IncomeExpense incomeExpense)
        {
            string status = "success";
            try
            {
                _IncomeExpense.Add(incomeExpense);
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateIncomeExpense(IncomeExpense incomeExpense)
        {
            string status = "success";

            try
            {
                _IncomeExpense.Update(incomeExpense);
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            return Json(incomeExpense, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteIncomeExpense(IncomeExpense incomeExpense)
        {
            string status = "success";
            try
            {
                _IncomeExpense.Delete(_IncomeExpense.Get(x=>x.ID==incomeExpense.ID));
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddReportsData(int ID,int count)
        {
            string status = "success";
            try
            {
                Report report = new Report();
                IncomeExpense ıncomeExpense = _IncomeExpense.Get(x => x.ID == ID);
                report.IncomeExpenseTableID = ID;
                report.Count = count;
                report.Total = ıncomeExpense.Price * report.Count;

                _Reports.ControlAdd(report);
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteAllReportsData()
        {
            string status = "success";
            try
            {
                foreach (var item in _Reports.GetList())
                {
                    _Reports.Delete(item);
                }
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        
    }
}