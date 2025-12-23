using Kanjiro.API.Enums;
using Kanjiro.API.Models.Model;

namespace Kanjiro.API.Services.Interfaces
{
    public interface IPlacementTestService
    {
        public Task<List<CardInfo>> GetPlacementTestCardsByLevel(JLPT_Level level);
        public Task<Deck> GetPlacementTestResults(int userId, int correctAnswers);
    }
}
