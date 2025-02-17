using Microsoft.EntityFrameworkCore;

namespace API_PRO.Data
{
    public class UnitOfWork<T> : IUnitOfWork  where T : class
    {
        private readonly AppDbContext _db;
        public IDataRepository<T> repo { get; private set; }
        public UnitOfWork (AppDbContext db)
        {
            _db = db;
            repo = new DataRepository<T>(db);
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
