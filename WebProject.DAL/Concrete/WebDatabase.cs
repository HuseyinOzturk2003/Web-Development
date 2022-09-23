using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Entity.Concrete;

namespace WebProject.DAL.Concrete
{
    public class WebDatabase:DbContext
    {
        //We define a constructor to create the database. With the app config, the computer now has access to the database in the computer
        //The project itself is connected to the database here.
        //The line of code here is also available in the connectionstring in the app.config file. (Allows to match nam in the connectionstring.)
        // Base part uses the constructor in this DbContext.
        public WebDatabase():base("name=WebDatabase")
        {

        }

        //Construction of the database tables 
        //The classes written between dbset are our tables in the database.

        public DbSet<IncomeExpense> IncomeExpenses { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
