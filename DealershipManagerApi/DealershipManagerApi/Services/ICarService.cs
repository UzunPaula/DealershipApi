using DealershipManagerApi.Models;

namespace DealershipManagerApi.Services
{
    public interface ICarService
    {
        void Add(Car car);
        Car? Get(Guid id);
        List<Car> GetAll();
        void Update(Guid carId, Car car);
        void Delete(Guid id);
    }
}
