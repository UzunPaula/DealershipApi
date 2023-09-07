using DealershipManagerApi.Models;

namespace DealershipManagerApi.Repositories
{
    public interface ISaleRepository
    {
        void Add(Sale sale);
        List<Sale> GetAll(DateTime startDate, DateTime endDate);
    }
}
