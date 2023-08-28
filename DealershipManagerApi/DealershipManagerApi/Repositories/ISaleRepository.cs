using DealershipManagerApi.Models;

namespace DealershipManagerApi.Repositories
{
    public interface ISaleRepository
    {
        void Add(Sale sale);
        List<Sale> GetAll();
    }
}
