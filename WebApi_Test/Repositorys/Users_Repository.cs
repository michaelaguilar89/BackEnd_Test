using WebApi_Test.Dto_s;
using WebApi_Test.Interfaces;

namespace WebApi_Test.Repositorys
{
    public class Users_Repository : IUsers

    {
        public Task<string> CreateUpdate(Users_DTO user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users_DTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Users_DTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
