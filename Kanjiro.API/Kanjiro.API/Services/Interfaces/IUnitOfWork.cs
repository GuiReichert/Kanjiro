namespace Kanjiro.API.Services.Interfaces
{
    public interface IUnitOfWork
    {
        public Task SaveChanges();
    }
}
