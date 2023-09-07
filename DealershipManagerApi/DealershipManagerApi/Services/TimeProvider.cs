namespace DealershipManagerApi.Services
{
    public class TimeProvider : ITimeProvider
    {
        //public DateTime UtcNow = DateTime.UtcNow;

        DateTime ITimeProvider.UtcNow => DateTime.UtcNow;
    }
}
