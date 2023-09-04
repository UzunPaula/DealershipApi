using DealershipManagerApi.Models;

namespace DealershipManagerApi.Repositories
{
    public interface ICarRepository
    {
        void Add(Car car);
        Car? Get(Guid id);
        List<Car> GetAll();
        List<Car> GetByFilter(string model, string brand, int productionYear);
        void Update(Car car);
        void Delete(Guid id);
    }
}
