using DealershipManagerApi.DTOs;

namespace DealershipManagerApi.Services
{
    public interface ICarValidator
    {
        bool IsValidAddCarDto(AddCarDto carDto);
        bool IsValidUpdateCarDto(UpdateCarDto carDto);
    }
}
