using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using WebApi_Test.Interfaces;
using WebApi_Test.Models;

namespace WebApi_Test.Repositorys
{
    public class Clients_Repository : IClients
    {
        private readonly string _connectionString;
     
        public Clients_Repository(IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<string> CreateUpdate(Client_DTO clientDTO)
        {
            try
            {

                SqlConnection sql = new SqlConnection(_connectionString);
                SqlCommand cmd = sql.CreateCommand();
                if (clientDTO.Id > 0)
                {
                    //update client

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Clients_CRUD";
                    cmd.Parameters.AddWithValue("@Instruction", "Update");
                    cmd.Parameters.AddWithValue("@Id", clientDTO.Id);
                    cmd.Parameters.AddWithValue("@FirstName", clientDTO.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", clientDTO.LastName);
                    cmd.Parameters.AddWithValue("@Phone", clientDTO.Phone);
                    cmd.Parameters.AddWithValue("@Email", clientDTO.Email);
                    cmd.Parameters.AddWithValue("@Direction", clientDTO.Direction);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await sql.CloseAsync();
                    return "The Client added";

                }
                else
                    //create new record of client
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_Clients_CRUD";
                cmd.Parameters.AddWithValue("@Instruction", "Create");
                cmd.Parameters.AddWithValue("@Id", 0);
                cmd.Parameters.AddWithValue("@FirstName", clientDTO.FirstName);
                cmd.Parameters.AddWithValue("@LastName", clientDTO.LastName);
                cmd.Parameters.AddWithValue("@Phone", clientDTO.Phone);
                cmd.Parameters.AddWithValue("@Email", clientDTO.Email);
                cmd.Parameters.AddWithValue("@Direction", clientDTO.Direction);
                await sql.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                await sql.CloseAsync();
                return "New Client added";

            }
            catch (Exception)
            {

                return "Internal error of server";
            } }

        public async Task<string> Delete(int id)
        {
            try
            {
                SqlConnection sql = new SqlConnection(_connectionString);
                SqlCommand cmd = sql.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_Clients_CRUD";
                cmd.Parameters.AddWithValue("@Instruction", "Delete");
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@FirstName", "");
                cmd.Parameters.AddWithValue("@LastName", "");
                cmd.Parameters.AddWithValue("@Phone", "");
                cmd.Parameters.AddWithValue("@Email", "");
                cmd.Parameters.AddWithValue("@Direction", "");
                await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                await sql.CloseAsync();
                return "The was eliminated";

            }
            catch (Exception)
            {

                return "Internal error of server";
            }
        }

        public async Task<Object> Get()
        {
            try
            {

                var list = new List<Client_DTO>();
                SqlConnection sql = new SqlConnection(_connectionString);
                SqlCommand cmd = sql.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_Clients_CRUD";
                cmd.Parameters.AddWithValue("@Instruction", "Get");
                cmd.Parameters.AddWithValue("@Id", 0);
                cmd.Parameters.AddWithValue("@FirstName", "");
                cmd.Parameters.AddWithValue("@LastName", "");
                cmd.Parameters.AddWithValue("@Phone", "");
                cmd.Parameters.AddWithValue("@Email", "");
                cmd.Parameters.AddWithValue("@Direction", "");
                await sql.OpenAsync();
                SqlDataReader reader;
                reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    list.Add(MapToValues(reader));
                }

                await sql.CloseAsync();
                return list;

            }
            catch (Exception)
            {
                return "Client List not found, is empty";
                
            }
           
        }

        private Client_DTO MapToValues(SqlDataReader reader)
        {
            Client_DTO dto = new Client_DTO();
            dto.Id = (int)reader[0];
            dto.FirstName = (string)reader[1];
            dto.LastName = (string)reader[2];
            dto.Phone = (string)reader[3];
            dto.Email = (string)reader[4];
            dto.Direction =(string)reader[5];
            return dto;

        }
        public async Task<Object> Get(int id)
        {
            try
            {

                Client_DTO client = new Client_DTO();
                SqlConnection sql = new SqlConnection(_connectionString);
                SqlCommand cmd = sql.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_Clients_CRUD";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_Clients_CRUD";
                cmd.Parameters.AddWithValue("@Instruction", "GetById");
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@FirstName", "");
                cmd.Parameters.AddWithValue("@LastName", "");
                cmd.Parameters.AddWithValue("@Phone", "");
                cmd.Parameters.AddWithValue("@Email", "");
                cmd.Parameters.AddWithValue("@Direction", "");
                await sql.OpenAsync();
                SqlDataReader reader;
                reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    client = MapToValues(reader);
                }

                await sql.CloseAsync();
                return client;

            }
            catch (Exception)
            {

                return "Client not found";
            }
        }
    }
}
