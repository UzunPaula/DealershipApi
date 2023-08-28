using DealershipManagerApi.DTOs;
using DealershipManagerApi.Models;

namespace DealershipManagerApi.Services
{
    public interface IClientService
    {
        void Add(AddClientDto clientDto);
        List<Client> GetAll();

        //Client? Get(Guid id);
        //void Update(Guid clientId, Client client);
        //void Delete(Guid id);
    }
}
