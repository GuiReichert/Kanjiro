using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Utils.Enums;
using Microsoft.EntityFrameworkCore;

namespace Kanjiro.API.Utils.Handlers
{
    public static class LogHandler
    {
        private static IDbContextFactory<Kanjiro_Context> _factory;

        public static void Configure(IDbContextFactory<Kanjiro_Context> factory)
        {
            _factory = factory;
        }

        public static async Task InsertLog(string message, LogOrigin logOrigin = LogOrigin.NONE, LogType logType = LogType.NONE, int userId = 0)
        {
            var context = _factory.CreateDbContext();
            await context.Logs.AddAsync(new Log { Message = message, Origin = logOrigin, Type = logType, UserId = userId, Date = DateTime.Now });
            await context.SaveChangesAsync();
        }
    }
}
