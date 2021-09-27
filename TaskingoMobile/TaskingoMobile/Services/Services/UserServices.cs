using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoMobile.Api;
using TaskingoMobile.Models.User;
using TaskingoMobile.Services.IServices;

namespace TaskingoMobile.Services.Services
{
    public class UserServices : IUserServices
    {
        public async Task<List<UserModel>> GetUsers()
        {
            var jsonUsers = await BaseCall.MakeCall("User/GetAll", System.Net.Http.HttpMethod.Get, null);
            var userModels = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserModel>>(jsonUsers);
            return userModels;
        }

        public async Task<int> GetMyId()
        {
            var id = await BaseCall.MakeCall("User/GetMyId", System.Net.Http.HttpMethod.Get, null);
            return int.Parse(id);
        }
    }
}
