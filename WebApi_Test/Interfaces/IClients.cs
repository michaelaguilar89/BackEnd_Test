using WebApi_Test.Models;

namespace WebApi_Test.Interfaces
{
    public interface IClients
    {
        Task<Object> Get();
        Task<Object> Get(int id);

        Task<string> CreateUpdate(Client_DTO client);
        Task<string> Delete(int id);
    }
}
