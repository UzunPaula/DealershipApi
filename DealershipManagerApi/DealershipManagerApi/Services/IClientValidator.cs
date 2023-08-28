using DealershipManagerApi.DTOs;

namespace DealershipManagerApi.Services
{
    public interface IClientValidator
    {
        bool IsValidAddClientDto(AddClientDto clientDto);
    }
}
