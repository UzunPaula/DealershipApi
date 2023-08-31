using DealershipManagerApi.DTOs;
using DealershipManagerApi.Models;
using DealershipManagerApi.Repositories;
using System.Net;

namespace DealershipManagerApi.Services
{
    public class CarService : ICarService
    {
        private readonly ICarValidator _carValidator;
        private readonly ICarRepository _carRepository;
        public CarService(
            ICarValidator carValidator,
            ICarRepository carRepository)
        {
            _carValidator = carValidator;
            _carRepository = carRepository;
        }
          
        public void Add(AddCarDto carDto)
        {
            var isValid = _carValidator.IsValidAddCarDto(carDto);
            if (!isValid)
            {
                throw new ArgumentException("Invalid car information. Could not add the car");
            }

            var car = new Car
            {
                Id = Guid.NewGuid(),
                Brand = carDto.Brand,
                Category = carDto.Category,
                Model = carDto.Model,
                Price = carDto.Price,
                ProdYear = carDto.ProductionYear,
                IsSold = false
            };
            _carRepository.Add(car);
        }

        public void Delete(Guid id)
        {
            _carRepository.Delete(id);
        }

        public Car? Get(Guid id)
        {
            return _carRepository.Get(id);
        }

        public List<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public void Update(Guid carId, UpdateCarDto carDto)
        {
            var isValid = _carValidator.IsValidUpdateCarDto(carDto);
            if (!isValid)
            {
                throw new ArgumentException("Invalid car information. Could not add the car");
            }

            var car = new Car
            {
                Id = carId,
                Brand = carDto.Brand,
                Category = carDto.Category,
                Model = carDto.Model,
                Price = carDto.Price,
                ProdYear = carDto.ProductionYear,
            };
            _carRepository.Update(car);
        }
    }
}
