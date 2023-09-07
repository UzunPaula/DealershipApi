using DealershipManagerApi.Data;
using DealershipManagerApi.Models;

namespace DealershipManagerApi.Repositories
{
    public class SqlCarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SqlCarRepository(ApplicationDbContext dbContext)
        {
            _applicationDbContext = dbContext;
        }
        public void Add(Car car)
        {
            _applicationDbContext.Cars.Add(car);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var carToDelete = _applicationDbContext.Cars.FirstOrDefault(c => c.Id == id);
            if (carToDelete != null)
            {
                var result = _applicationDbContext.Cars.Remove(carToDelete);
                _applicationDbContext.SaveChanges();
            }
        }

        public List<Car> GetByFilter(string model, string brand, int productionYear)
        {
            /* var cars = _applicationDbContext.Cars
                .Where(c => c.Brand == brand)
                .Where(c => c.Model == model)
                .Where(c => c.ProdYear == productionYear)
                .Where(c => c.IsSold == false)
                .OrderBy(c => c.Price)
                .Skip(10)
                .Take(10)
                .ToList();
            */

            var filter = _applicationDbContext.Cars.AsQueryable();

            if (model is not null)
            {
                filter = filter.Where(c => c.Model == model);
            }
            if (brand is not null)
            {
                filter = filter.Where(c => c.Brand == brand);
            }
            if (productionYear != 0)
            {
                filter = filter.Where(c => c.ProdYear == productionYear);
            }
            var cars = filter.ToList();

            return cars;
        }

        public Car? Get(Guid id)
        {
            return _applicationDbContext.Cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll(bool isSold)
        {
            return _applicationDbContext.Cars
                .Where(c => c.IsSold == isSold)
                .ToList();

            /* var cars = _applicationDbContext.Cars
                .Where(c => ids.Contains(c.Id))
                .ToList();

            return cars;
            */
        }

        public void Update(Car car)
        {
            var carToUpdate = _applicationDbContext.Cars.FirstOrDefault(c => c.Id == car.Id);
            if (carToUpdate != null)
            {
                carToUpdate.Brand = car.Brand;
                carToUpdate.Model = car.Model;
                carToUpdate.Category = car.Category;
                carToUpdate.Price = car.Price;
                carToUpdate.ProdYear = car.ProdYear;

                var result = _applicationDbContext.Update(carToUpdate);

                _applicationDbContext.SaveChanges();
            }
        }
    }
}
