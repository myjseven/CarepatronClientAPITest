using CarepatronClientAPITest.Interfaces;
using CarepatronClientAPITest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarepatronClientAPITest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly ISendEmail _sendEmail;
        private readonly ISyncDocuments _syncDocuments;

        public ClientController(IClientRepository clientRepository, ISendEmail sendEmail, ISyncDocuments syncDocuments)
        {
            _clientRepository = clientRepository;
            _sendEmail = sendEmail;
            _syncDocuments = syncDocuments;
        }

        [HttpGet]
        public ActionResult<List<Client>> GetAllClients()
        {
            var clients = _clientRepository.GetAll();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetClientById(int id)
        {
            var client = _clientRepository.GetById(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public ActionResult CreateClient([FromBody] Client client)
        {
            if (client == null)
                return BadRequest("Client data is empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _clientRepository.Add(client);
            _sendEmail.SendEmail(client);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateClient(int id, [FromBody] Client client)
        {
            if (client == null)
                return BadRequest("Client data is empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingClient = _clientRepository.GetById(id);
            if (existingClient == null)
                return NotFound();

            if(existingClient.Email != client.Email)
            {
                _sendEmail.SendEmail(client);
                _syncDocuments.SyncDocument(client);
            }

            _clientRepository.Update(client);

            return Ok();
        }

        [HttpGet("Search")]
        public ActionResult<List<Client>> SearchClients([FromQuery] string searchTerm)
        {
            var clients = _clientRepository.Search(searchTerm);
            return Ok(clients);
        }
    }

}
