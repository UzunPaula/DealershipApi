using DealershipManagerApi.Data;
using DealershipManagerApi.Models;
using Microsoft.EntityFrameworkCore;

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
         
        public List<Sale> GetAll(DateTime startDate, DateTime endDate)
        {
            return _appDbContext.Sales
                .Where(s => s.Date >= startDate && s.Date <= endDate)
                .Include(s => s.Car) //include obiectele imbricate
                .Include(s => s.Client)
                .ToList();
        }
    }
}
