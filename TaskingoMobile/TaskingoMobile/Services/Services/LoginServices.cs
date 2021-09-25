using System.Threading.Tasks;
using TaskingoMobile.Api;
using TaskingoMobile.Models;
using TaskingoMobile.Services.IServices;

namespace TaskingoMobile.Services.Services
{
    public class LoginServices : ILoginServices
    {
        public async Task<bool> Login(string email, string password)
        {
            var loginModel = new LoginModel { Email = email, PasswordHashed = password };
            var response = await BaseCall.MakeCall("user/login", System.Net.Http.HttpMethod.Post, loginModel);
            if (response.Length < 10) return false;
            BaseCall.Token = response;
            return true;
        }
    }
}
