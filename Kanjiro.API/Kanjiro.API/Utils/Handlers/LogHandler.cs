using Kanjiro.API.Database;
using Kanjiro.API.Models.Model;
using Kanjiro.API.Utils.Enums;

namespace Kanjiro.API.Utils.Handlers
{
    public static class LogHandler
    {
        public static async Task InsertLog(Kanjiro_Context context, string message, LogOrigin logOrigin = LogOrigin.NONE, LogType logType = LogType.NONE, int userId = 0)
        {
            await context.Logs.AddAsync(new Log { Message = message, Origin = logOrigin, Type = logType, UserId = userId });
            await context.SaveChangesAsync();
        }
    }
}
