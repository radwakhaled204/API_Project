using API_PRO.Data.Models;
using API_PRO.Migrations;
using Microsoft.EntityFrameworkCore;

namespace API_PRO.Data
{
    public class UnitOfWork<T> : IUnitOfWork  where T : class
    {
        private readonly AppDbContext _db;
        
        public IDataRepository<Category> categories { get; private set; }
        public UnitOfWork (AppDbContext db)
        {
            _db = db;
            
            categories = new DataRepository<Category>(db);
        }
        public int CommitChanges()
        {
            return _db.SaveChanges();  
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
