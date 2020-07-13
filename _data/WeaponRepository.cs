using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace adventure_cli._data
{
    public class WeaponRepository : Repository
    {
        public WeaponRepository(DataContext context) : base(context)
        {}

        public override async Task<IEnumerable<object>> FetchAll()
        {
            var weapons = await _context.Weapon_Tbl.ToListAsync();
            return weapons;
        }

        public override async Task<object> FetchOne(int id)
        {
            var weapon = await _context.Weapon_Tbl.FirstOrDefaultAsync(w => w.Id == id);
            return weapon;
        }

        public override async Task<int> GetCount()
        {
            return await _context.Weapon_Tbl.CountAsync();
        }
    }
}