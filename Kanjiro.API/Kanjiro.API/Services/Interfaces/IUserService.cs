using Kanjiro.API.Models.DTO_s;

namespace Kanjiro.API.Services.Interfaces
{
    public interface IUserService
    {
        public Task SynchronizeChanges(UserDTO user);
    }
}
