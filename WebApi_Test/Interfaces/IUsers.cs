using WebApi_Test.Dto_s;

namespace WebApi_Test.Interfaces
{
    public interface IUsers
    {
        Task<IEnumerable<Users_DTO>> Get();
        Task<Users_DTO> GetById(int id);
        Task<string> CreateUpdate(Users_DTO user);
        Task<bool> Delete(int id);
    }
}
