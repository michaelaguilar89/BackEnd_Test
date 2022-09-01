using WebApi_Test.Models;

namespace WebApi_Test.Interfaces
{
    public interface IClients
    {
        Task<List<Client>> Get();
        Task<Object> GetById(int id);

        Task<string> CreateUpdate(Client_DTO client);
        Task<bool> Delete(int id);
    }
}
