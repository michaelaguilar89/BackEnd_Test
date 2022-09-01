using WebApi_Test.Models;

namespace WebApi_Test.Interfaces
{
    public interface IClients
    {
        Task<List<Client_DTO>> Get();
        Task<Client_DTO> Get(int id);

        Task<string> CreateUpdate(Client_DTO client);
        Task<string> Delete(int id);
    }
}
