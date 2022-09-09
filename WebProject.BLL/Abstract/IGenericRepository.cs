using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.BLL.Abstract
{
    //Generic Repository design interface 
    //Basis of Create-Read-Update-Delete operations
    //İnstead of writing code for every class, we can just implement a code written once on classes we need
    //T --> shows that its generic, meaning if signifies whatever class it 
    //Expressinon<Func<T,bool>> filter expression  --> When a query is written in linq, it performs these operations according to the query.
    public interface IGenericRepository<T> where T:class
    {
        //acts according to inquiry
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        //brings selected elements according to inquiry
        T Get(Expression<Func<T, bool>> filter);
        //basis of add - remove - update 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
