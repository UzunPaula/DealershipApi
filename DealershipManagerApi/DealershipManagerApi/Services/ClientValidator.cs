using DealershipManagerApi.DTOs;

namespace DealershipManagerApi.Services
{
    public class ClientValidator : IClientValidator
    {
        public bool IsValidAddClientDto(AddClientDto clientDto)
        {
            if (string.IsNullOrEmpty(clientDto.Name)) return false;
            return true;
        }
    }
}
