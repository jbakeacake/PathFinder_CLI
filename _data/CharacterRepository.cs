using System.Collections.Generic;
using System.Threading.Tasks;
using adventure_cli._models.characterData;
using Microsoft.EntityFrameworkCore;

namespace adventure_cli._data
{
    public class CharacterRepository : Repository
    {
        public CharacterRepository(DataContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<object>> FetchAll()
        {
            var characters = await _context.Character_Tbl.ToListAsync();
            return characters;
        }

        public override async Task<object> FetchOne(int id)
        {
            var character = await _context.Character_Tbl.FirstOrDefaultAsync(c => c.Id == id);
            return character;
        }
        public override async Task<int> GetCount()
        {
            return await _context.Character_Tbl.CountAsync();
        }
    }
}