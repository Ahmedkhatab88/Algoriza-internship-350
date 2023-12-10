
using ApplicationLayer.Exceptions;
using ApplicationLayer.NonGenericInterface;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using persistence.APPDBCONTEXT;

namespace VEZEETA.Infrastructure.persistence.Repositories
{
    public class SettingRepository : GenericRepository<Setting>, ISettingRepository
    {
        private DbSet<Setting> _Setting;

        public SettingRepository(AppDbContext context) : base(context)
        {
            _Setting = context.Set<Setting>();
        }

        public async Task<bool> Deactivate(int id)
        {
            var query = await _Setting.FirstOrDefaultAsync(x => x.Id == id);

            if (query is null)
            {
                throw new ItemNotFoundException("This Item is not exist");
            }

            _Setting.Remove(query);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
