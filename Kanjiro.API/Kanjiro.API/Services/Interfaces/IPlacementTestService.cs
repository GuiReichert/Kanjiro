using Kanjiro.API.Models.Model;
using Kanjiro.API.Utils.Enums;

namespace Kanjiro.API.Services.Interfaces
{
    public interface IPlacementTestService
    {
        public Task<List<CardInfo>> GetPlacementTestCardsByLevel();
        public Task<Deck> GetPlacementTestResults(int userId, JLPT_Level finalLevel, int correctAnswers);
    }
}
