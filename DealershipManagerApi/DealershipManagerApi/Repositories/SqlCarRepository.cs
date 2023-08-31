﻿using DealershipManagerApi.Data;
using DealershipManagerApi.Models;

namespace DealershipManagerApi.Repositories
{
    public class SqlCarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SqlCarRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Car car)
        {
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var carToDelete = _dbContext.Cars.FirstOrDefault(c => c.Id == id);
            if (carToDelete != null)
            {
                var result = _dbContext.Cars.Remove(carToDelete);
                _dbContext.SaveChanges();
            }
        }

        public Car? Get(Guid id)
        {
            return _dbContext.Cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll()
        {
            return _dbContext.Cars.ToList();
        }

        public void Update(Car car)
        {
            var carToUpdate = _dbContext.Cars.FirstOrDefault(c => c.Id == car.Id);
            if (carToUpdate != null)
            {
                carToUpdate.Brand = car.Brand;
                carToUpdate.Model = car.Model;
                carToUpdate.Category = car.Category;
                carToUpdate.Price = car.Price;
                carToUpdate.ProdYear = car.ProdYear;

                var result = _dbContext.Update(carToUpdate);

                _dbContext.SaveChanges();
            }
        }
    }
}
