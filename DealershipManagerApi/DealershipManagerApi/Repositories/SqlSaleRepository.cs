using DealershipManagerApi.Data;
using DealershipManagerApi.Models;

namespace DealershipManagerApi.Repositories
{
    public class SqlSaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public SqlSaleRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(Sale sale)
        {
            _appDbContext.Sales.Add(sale);
            _appDbContext.SaveChanges();
        }

        public List<Sale> GetAll()
        {
            return _appDbContext.Sales.ToList();
        }
    }
}
