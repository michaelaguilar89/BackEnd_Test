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
    }
}
