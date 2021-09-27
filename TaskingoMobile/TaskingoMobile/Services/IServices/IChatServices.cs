using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoMobile.Models.Chat;
using TaskingoMobile.Models.User;

namespace TaskingoMobile.Services.IServices
{
    public interface IChatServices
    {
        event Action<MessageModel> ReceiveMessage;
        Task Connect();
        Task SendMessage(string message, int recipient);
        Task<List<UserModel>> GetLastUsers();
        Task<List<MessageModel>> GetMessages(int recipient, int skip);
    }
}