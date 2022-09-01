using AutoMapper;
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
        private readonly IMapper _mapper;
     
        public Clients_Repository(IConfiguration _configuration,IMapper mapper)
        {
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _mapper = mapper;
        }

        public async Task<string> CreateUpdate(Client_DTO _client)
        {
            try
            {
                Client client = _mapper.Map<Client_DTO, Client>(_client); 
                SqlConnection sql = new SqlConnection(_connectionString);
                SqlCommand cmd = sql.CreateCommand();
                if (client.Id > 0)
                {
                    //update client

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Clients_CRUD";
                    cmd.Parameters.AddWithValue("@Instruction", "Update");
                    cmd.Parameters.AddWithValue("@Id", client.Id);
                    cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", client.LastName);
                    cmd.Parameters.AddWithValue("@Phone", client.Phone);
                    cmd.Parameters.AddWithValue("@Email", client.Email);
                    cmd.Parameters.AddWithValue("@Direction", client.Direction);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await sql.CloseAsync();
                    return "The Client was update";

                }
                else
                    //create new record of client
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_Clients_CRUD";
                cmd.Parameters.AddWithValue("@Instruction", "Create");
                cmd.Parameters.AddWithValue("@Id", 0);
                cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                cmd.Parameters.AddWithValue("@LastName", client.LastName);
                cmd.Parameters.AddWithValue("@Phone", client.Phone);
                cmd.Parameters.AddWithValue("@Email", client.Email);
                cmd.Parameters.AddWithValue("@Direction", client.Direction);
                await sql.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                await sql.CloseAsync();
                return "New Client added";

            }
            catch (Exception)
            {

                return "Internal error of server";
            } }

        public async Task<bool> Delete(int id)
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
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Client>> Get()
        {

                var list = new List<Client>();
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

        private Client MapToValues(SqlDataReader reader)
        {
            Client client = new Client();
            client.Id = (int)reader[0];
            client.FirstName = (string)reader[1];
            client.LastName = (string)reader[2];
            client.Phone = (string)reader[3];
            client.Email = (string)reader[4];
            client.Direction =(string)reader[5];
            return client;

        }
        public async Task<Object> GetById(int id)
        {
            try
            {

                Client client = new Client();
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
