using System.Threading.Tasks;

namespace TaskingoMobile.Services.IServices
{
    public interface ILoginServices
    {
        Task<bool> Login(string email, string password);
    }
}