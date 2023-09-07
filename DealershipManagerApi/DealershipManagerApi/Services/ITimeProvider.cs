namespace DealershipManagerApi.Services
{
    public interface ITimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
