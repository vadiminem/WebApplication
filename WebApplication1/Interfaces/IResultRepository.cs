using WebApplication.Models;

namespace WebApplication1.Interfaces
{
    public interface IResultRepository
    {
        void Create(SomeObject someObject);
        SomeObject Get();
    }
}
