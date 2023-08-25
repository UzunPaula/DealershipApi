﻿using DealershipManagerApi.Models;

namespace DealershipManagerApi.Repositories
{
    public class InMemoryClientRepository : IClientRepository
    {
        private static readonly List<Client> _clients = new List<Client>();
        public void Add(Client client)
        {
            _clients.Add(client);
        }

        public void Delete(Guid id)
        {
            var clientToDelete = _clients.FirstOrDefault(x => x.Id == id);
            if (clientToDelete != null)
            {
                _clients.Remove(clientToDelete);
            }
        }

        public Client? Get(Guid id)
        {
            return _clients.FirstOrDefault(x => x.Id == id);
        }

        public List<Client> GetAll()
        {
            return _clients;
        }

        public void Update(Guid clientId, Client client)
        {
            var clientToUpdate = _clients.FirstOrDefault(x => x.Id == clientId);
            if (clientToUpdate != null)
            {
                clientToUpdate.Name = client.Name;
                clientToUpdate.IsCompany = client.IsCompany;
            }
        }
    }
}
