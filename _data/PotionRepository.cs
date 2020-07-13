using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace adventure_cli._data
{
    public class PotionRepository : Repository
    {
        public PotionRepository(DataContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<object>> FetchAll()
        {
            var potions = await _context.Potion_Tbl.ToListAsync();
            return potions;
        }

        public override async Task<object> FetchOne(int id)
        {
            var potion = await _context.Potion_Tbl.FirstOrDefaultAsync(p => p.Id == id);
            return potion;
        }

        public override async Task<int> GetCount()
        {
            return await _context.Potion_Tbl.CountAsync();
        }
    }
}