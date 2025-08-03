namespace Kanjiro.API.Services
{
    public interface IUnitOfWork
    {
        public Task SaveChanges();
    }
}
