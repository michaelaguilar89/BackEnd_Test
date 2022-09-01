using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Test.Interfaces;
using WebApi_Test.Models;
using WebApi_Test.Repositorys;
using WebApi_Test.Response;
namespace WebApi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    { protected MyResponse _response;
        private readonly IClients _repository;
        public ClientsController(IClients repository)
        {
            _repository = repository;
            _response = new MyResponse();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            try
            { List<Client> list = new List<Client>();
                list = await _repository.Get();
                _response.Result =list;
                _response.DisplayMessages = "Client List";
            }
            catch (Exception e)
            {

                _response.DisplayMessages = "The Client list is empty";
                _response.ErrorMessages = new List<string> { e.ToString() };
            }

            return Ok(_response);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var respuesta = await _repository.GetById(id);
                _response.IsSucces = true;
                _response.DisplayMessages = "Customer Information";
                _response.Result = respuesta;
                return Ok(_response);
            }
            catch (Exception e)
            {

                _response.DisplayMessages = "Client not found";
                _response.ErrorMessages = new List<string> { e.ToString() };
            }
            return BadRequest(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Client_DTO client)
        {
            try
            {
                string mensaje = await _repository.CreateUpdate(client);
                if (mensaje=="The Client added")
                {
                    _response.IsSucces = true;
                    _response.DisplayMessages = mensaje;
                    _response.Result = client;
                   
                    
                }
                if (mensaje == "Internal error of server")
                {
                    
                    _response.DisplayMessages = mensaje;
                    
                    return BadRequest(_response);

                }
                return Ok(_response);
            }
            catch (Exception e)
            {

                 _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Client_DTO client)
        {
            try
            {
                string mensaje = await _repository.CreateUpdate(client);
                if (mensaje == "The Client was update")
                {
                    _response.IsSucces = true;
                    _response.DisplayMessages = mensaje;
                    _response.Result = client;
                   

                }
                if (mensaje == "Internal error of server")
                {

                    _response.DisplayMessages = mensaje;

                    return BadRequest(_response);

                }
            }
            catch (Exception e)
            {

                _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var respuesta = await _repository.Delete(id);
                if (respuesta==true)
                {
                    _response.IsSucces=true;
                    _response.DisplayMessages = "The Client has been deleted";
                   

                }
                if (respuesta==false)
                {
                    _response.DisplayMessages = "The Client has not been deleted";
                    return BadRequest(_response);
                }
            }
            catch (Exception e)
            {
                _response.DisplayMessages = "Error : The Client has not been deleted";
                _response.ErrorMessages = new List<string> { e.Message };
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}
