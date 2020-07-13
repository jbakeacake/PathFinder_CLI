using System.Collections.Generic;
using System.Threading.Tasks;

namespace adventure_cli._data
{
    public abstract class Repository
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public abstract Task<IEnumerable<object>> FetchAll();
        public abstract Task<object> FetchOne(int id);
        public abstract Task<int> GetCount();

    }
}