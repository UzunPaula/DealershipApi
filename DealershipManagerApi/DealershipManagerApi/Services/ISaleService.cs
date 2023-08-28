using DealershipManagerApi.DTOs;
using DealershipManagerApi.Models;

namespace DealershipManagerApi.Services
{
    public interface ISaleService
    {
        void Add(AddSaleDto saleDto);
        List<Sale> GetAll();
    }
}
