
using Kanjiro.API.Database;

namespace Kanjiro.API.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private Kanjiro_Context _context;

        public UnitOfWork(Kanjiro_Context context)
        {
            _context = context;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
