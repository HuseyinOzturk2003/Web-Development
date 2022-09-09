using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.BLL.Abstract;
using WebProject.DAL.Concrete;

namespace WebProject.BLL.Concrete.Base
{
    //Bu bölümde generic repostiroy tasarım denesin için base sınıf oluşturyoruz.
    //Bunun sebebi ise somut bir yapı oluşturmak istediğimizdir 
    //Burada ekleme silme güncelleme listeleme ve elemanı getirme vardır.
    //using() içerisne yazılan ifadeler işlemi yapınca burada işlem bitince nesneyi temizler.

        //Burada Entitiy Framework Teknoloji kullanılmıştır.
        //context.entry() --> işlem yapılacak modeli seçer.
        //Entity.State --> işelm yapılacak olan modele ne yapılacak ekleme silme gibi durumları belirtir.
        //context.SaveChanges() -- ile veritabanına yapılan işlemi kaydeder.

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public void Add(T entity)
        {
            using (WebDatabase context = new WebDatabase())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (WebDatabase context = new WebDatabase())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (WebDatabase context = new WebDatabase())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        //Veritabanıda seçili elamn varsa getir yoksa null değeri döndür.

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (WebDatabase context = new WebDatabase())
            {
                return context.Set<T>().SingleOrDefault(filter);
            }
        }

        //Burada veritabında bizim yazmış olduğumuz şart yok ise tüm listeyi getir. (Şart yerine null yaz)
        //Eğer veritabınında şart var ise o şarta göre listeme yap.

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            using (WebDatabase context = new WebDatabase())
            {
                return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
            }
        }

        
    }
}
