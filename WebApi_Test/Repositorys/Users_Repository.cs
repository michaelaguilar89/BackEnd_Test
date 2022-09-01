using AutoMapper;
using Microsoft.Data.SqlClient;
using System.Configuration;
using WebApi_Test.Dto_s;
using WebApi_Test.Interfaces;
using WebApi_Test.Models;

namespace WebApi_Test.Repositorys
{
    public class Users_Repository : IUsers
    {
        private readonly string _connectionStrings;
        
        protected IMapper _mapper;
        public Users_Repository(IConfiguration _configuration)
        {
            _connectionStrings = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<string> CreateUpdate(Users_DTO userDto)
        {
            try
            {

                User user = _mapper.Map<Users_DTO, User>(userDto);
                if (user.Id > 0)
                {
                    SqlConnection sql = new SqlConnection(_connectionStrings);

                    SqlCommand cmd = sql.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Users_CRUD";
                    cmd.Parameters.Add(new SqlParameter("Instruction", "Update"));
                    cmd.Parameters.Add(new SqlParameter("@Id", user.Id));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", user.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Phone", user.Phone));
                    cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
                    cmd.Parameters.Add(new SqlParameter("@Direction", user.Direction));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await sql.CloseAsync();

                    return "The user was modify";
                }
                else
                {
                    SqlConnection sql = new SqlConnection(_connectionStrings);

                    SqlCommand cmd = sql.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Users_CRUD";
                    cmd.Parameters.Add(new SqlParameter("Instruction", "Create"));
                    cmd.Parameters.Add(new SqlParameter("@Id", 0));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", user.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Phone", user.Phone));
                    cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
                    cmd.Parameters.Add(new SqlParameter("@Direction", user.Direction));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await sql.CloseAsync();

                    return "New User Added";

                }
            }
            catch (Exception)
            {

                return "Internal error server";
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {

                SqlConnection sql = new SqlConnection(_connectionStrings);

                SqlCommand cmd = sql.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_Users_CRUD";
                cmd.Parameters.Add(new SqlParameter("Instruction", "Delete"));
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.Parameters.Add(new SqlParameter("@FirstName", ""));
                cmd.Parameters.Add(new SqlParameter("@LastName", ""));
                cmd.Parameters.Add(new SqlParameter("@Phone", ""));
                cmd.Parameters.Add(new SqlParameter("@Email", ""));
                cmd.Parameters.Add(new SqlParameter("@Direction", ""));

                await sql.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                await sql.CloseAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Users_DTO>> Get()
        {
            List<Users_DTO> list = new List<Users_DTO>();
            SqlConnection sql = new SqlConnection(_connectionStrings);

            SqlCommand cmd = sql.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Users_CRUD";
            cmd.Parameters.Add(new SqlParameter("Instruction","Get"));
            cmd.Parameters.Add(new SqlParameter("@Id",0));
            cmd.Parameters.Add(new SqlParameter("@FirstName", ""));
            cmd.Parameters.Add(new SqlParameter("@LastName", ""));
            cmd.Parameters.Add(new SqlParameter("@Phone", ""));
            cmd.Parameters.Add(new SqlParameter("@Email", ""));
            cmd.Parameters.Add(new SqlParameter("@Direction", ""));
            SqlDataReader reader;
            await sql.OpenAsync();
              reader= await  cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(MapToValue(reader));

            }
            await sql.CloseAsync();

            return list;

        }

        private Users_DTO MapToValue(SqlDataReader reader)
        {
            Users_DTO user = new Users_DTO();
            user.Id = (int)reader[0];
            user.FirstName = (string)reader[1];
            user.LastName= (string)reader[2];
            user.Phone= (string)reader[3];
            user.Email= (string)reader[4];
            user.Direction= (string)reader[5];
            return user;

        }

        public async Task<Users_DTO> GetById(int id)
        {
            Users_DTO users = new Users_DTO();
            SqlConnection sql = new SqlConnection(_connectionStrings);

            SqlCommand cmd = sql.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_Users_CRUD";
            cmd.Parameters.Add(new SqlParameter("Instruction", "GetById"));
            cmd.Parameters.Add(new SqlParameter("@Id", id));
            cmd.Parameters.Add(new SqlParameter("@FirstName", ""));
            cmd.Parameters.Add(new SqlParameter("@LastName", ""));
            cmd.Parameters.Add(new SqlParameter("@Phone", ""));
            cmd.Parameters.Add(new SqlParameter("@Email", ""));
            cmd.Parameters.Add(new SqlParameter("@Direction", ""));
            SqlDataReader reader;
            await sql.OpenAsync();
            reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                users=(MapToValue(reader));

            }
            await sql.CloseAsync();

            return users;

        }
    }
}
