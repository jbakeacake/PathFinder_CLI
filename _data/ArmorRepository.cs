using System.Collections.Generic;
using System.Threading.Tasks;
using adventure_cli._models.characterData;
using Microsoft.EntityFrameworkCore;

namespace adventure_cli._data
{
    public class ArmorRepository : Repository
    {
        public ArmorRepository(DataContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<object>> FetchAll()
        {
            var armors = await _context.Armor_Tbl.ToListAsync();
            return armors;
        }

        public override async Task<object> FetchOne(int id)
        {
            var armor = await _context.Armor_Tbl.FirstOrDefaultAsync(a => a.Id == id);
            return armor;
        }

        public override async Task<int> GetCount()
        {
            return await _context.Armor_Tbl.CountAsync();
        }
    }
}