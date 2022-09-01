using WebApi_Test.Interfaces;
using WebApi_Test.Models;

namespace WebApi_Test.Repositorys
{
    public class Clients_Repository : IClients
    {
        public Task<string> CreateUpdate(Client_DTO client)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Client_DTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Client_DTO> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
