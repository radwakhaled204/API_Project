using Microsoft.EntityFrameworkCore;

namespace API_PRO.Data
{

    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> table;

        public DataRepository(AppDbContext db)
        {
            _db = db;
            table = _db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllFun()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdFun(int id)
        {
            var result = await table.FindAsync(id);
            if (result == null)
            {
                throw new KeyNotFoundException($" id {id} not found");
            }
            return result;

        }

        public async Task AddFun(T entity)
        {
            await table.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateFun(T entity)
        {
            table.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteFun(int id)
        {
            var entity = await GetByIdFun(id);
            if (entity != null)
            {
                table.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}
