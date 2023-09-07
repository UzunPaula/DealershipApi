using DealershipManagerApi.DTOs;
using DealershipManagerApi.Models;
using DealershipManagerApi.Repositories;
using System.ComponentModel.DataAnnotations;

namespace DealershipManagerApi.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientValidator _clientValidator;
        private readonly IClientRepository _clientRepository;

        public ClientService(
            IClientValidator clientValidator,
            IClientRepository clientRepository)
        {
            _clientValidator = clientValidator;
            _clientRepository = clientRepository;
        }
        public void Add(AddClientDto clientDto)
        {
            var isValid = _clientValidator.IsValidAddClientDto(clientDto);
            if (!isValid)
            {
                throw new ValidationException("Invalid client information. Could not add a client");
            }
            var client = new Client
            {
                Id = Guid.NewGuid(),
                Name = clientDto.Name,
                IsCompany = clientDto.IsCompany,
            };

            _clientRepository.Add(client);
        }

        public List<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        //public void Delete(Guid id)
        //{
        //    _clientRepository.Delete(id);
        //}

        //public Client? Get(Guid id)
        //{
        //    return _clientRepository.Get(id);
        //}

        //public void Update(Guid clientId, Client client)
        //{
        //    _clientRepository.Update(clientId, client);
        //}
    }
}
