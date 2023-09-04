using DealershipManagerApi.Data;
using DealershipManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DealershipManagerApi.Repositories
{
    public class SqlClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly DbSet<Client> _clients;
        public SqlClientRepository(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
            _clients = applicationDbContext.Clients;
        }
        public void Add(Client client)
        {
            _clients.Add(client);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var clientToDelete = _clients.FirstOrDefault(x => x.Id == id);
            if (clientToDelete != null)
            {
                _clients.Remove(clientToDelete);
                _applicationDbContext.SaveChanges();
            }
        }

        public Client? Get(Guid id)
        {
            return _clients.FirstOrDefault(x => x.Id == id);
        }

        public List<Client> GetAll()
        {
            return _clients.ToList();
        }

        public void Update(Guid clientId, Client client)
        {
            var clientToUpdate = _clients.FirstOrDefault(x => x.Id == clientId);
            if (clientToUpdate != null)
            {
                clientToUpdate.Name = client.Name;
                clientToUpdate.IsCompany = client.IsCompany;

                _applicationDbContext.Update(clientToUpdate);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
