using appSumaConection.Entities;

namespace appSumaConection.Services
{
    public interface ISumaServices
    {
        Task<int> Suma(Suma suma);
    }
}
