using System.Collections.Generic;
using System.Threading.Tasks;

namespace adventure_cli._data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

        Task<IEnumerable<object>> FetchAll();
        Task<object> FetchOne(int id);
        Task<int> GetCount();
    }
}