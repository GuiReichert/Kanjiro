using Kanjiro.API.Database;
using Kanjiro.API.Enums;
using Kanjiro.API.Models.Model;

namespace Kanjiro.API.Utils
{
    public static class LogHandler
    {
        public static async Task InsertLog(Kanjiro_Context context, string message, LogOrigin logOrigin = LogOrigin.None, LogType logType = LogType.None, int userId = 0)
        {
            await context.Logs.AddAsync(new Log { Message = message, Origin = logOrigin, Type = logType, UserId = userId });
            await context.SaveChangesAsync();
        }
    }
}
