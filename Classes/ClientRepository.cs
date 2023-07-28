using CarepatronClientAPITest.Interfaces;
using CarepatronClientAPITest.Models;

namespace CarepatronClientAPITest.Classes
{
    public class ClientRepository : IClientRepository
    {
        private readonly List<Client> _clients;

        public ClientRepository()
        {
            _clients = new List<Client>();
        }

        public List<Client> GetAll()
        {
            return _clients;
        }

        public Client GetById(int id)
        {
            return _clients.FirstOrDefault(c => c.ClientId == id);
        }

        public void Add(Client client)
        {
            client.ClientId = _clients.Count + 1; 
            _clients.Add(client);
        }

        public void Update(Client client)
        {
            var existingClient = _clients.FirstOrDefault(c => c.ClientId == client.ClientId);
            if (existingClient != null)
            {
                existingClient.FirstName = client.FirstName;
                existingClient.LastName = client.LastName;
                existingClient.Email = client.Email;
            }
        }

        public List<Client> Search(string searchTerm)
        {
            return _clients
                .Where(c => c.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            c.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
