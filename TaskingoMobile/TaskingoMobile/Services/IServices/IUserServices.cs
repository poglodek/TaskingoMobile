using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoMobile.Models.User;

namespace TaskingoMobile.Services.IServices
{
    public interface IUserServices
    {
        Task<List<UserModel>> GetUsers();
    }
}