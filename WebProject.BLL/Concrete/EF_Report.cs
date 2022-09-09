using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BLL.Concrete.Base;
using WebProject.Entity.Concrete;

namespace WebProject.BLL.Concrete
{
    public class EF_Report:GenericRepository<Report>
    {
        
       public void ControlAdd(Report report)
       {
            if (report.ID == 0 )
            {
                Add(report);
               
            }
            else
            {
                report.ID = Get(x => x.IncomeExpenseTableID == report.IncomeExpenseTableID).ID;

                Update(report);
            }
       }


    }
}
