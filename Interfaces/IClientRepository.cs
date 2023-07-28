using CarepatronClientAPITest.Models;

namespace CarepatronClientAPITest.Interfaces
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        Client GetById(int id);
        void Add(Client client);
        void Update(Client client);
        List<Client> Search(string searchTerm);
    }
}
