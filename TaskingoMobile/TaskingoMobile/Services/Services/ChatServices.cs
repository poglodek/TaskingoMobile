using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using TaskingoMobile.Api;
using TaskingoMobile.Models.Chat;
using TaskingoMobile.Models.User;
using TaskingoMobile.Services.IServices;

namespace TaskingoMobile.Services.Services
{
    public class ChatServices : IChatServices
    {
        public static int MyId;
        public event Action<MessageModel> ReceiveMessage;
        public static HubConnection Connection = new HubConnectionBuilder()
            .WithAutomaticReconnect()
            .WithUrl(BaseCall.Url + "chat", options =>
            {
                options.HttpMessageHandlerFactory = factory => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
                };
            })
            .Build();

        public ChatServices()
        {
            Connection.On<MessageModel>("ReceiveMessage", (x) => ReceiveMessage?.Invoke(x));
        }
        public async Task Connect()
        {
            await Connection.StartAsync();
            await Connection.SendAsync("GetMyId", MyId);
            var a = Connection.ConnectionId; 
        }

        public async Task SendMessage(string message, int recipient)
        {
            await Connection.SendAsync("SendMessage", message, recipient);
        }

        public async Task<List<UserModel>> GetLastUsers()
        {
            var jsonUser = await BaseCall.MakeCall($"Message/LastUsers", System.Net.Http.HttpMethod.Get, null);
            var user = JsonConvert.DeserializeObject<List<UserModel>>(jsonUser);
            return user;
        }
        public async Task<List<MessageModel>> GetMessages(int recipient, int skip)
        {
            var jsonMessages = await BaseCall.MakeCall($"Message/{recipient}/{skip}", System.Net.Http.HttpMethod.Get, null);
            var messages = JsonConvert.DeserializeObject<List<MessageModel>>(jsonMessages);
            messages.Reverse();
            return messages;
        }
    }
}
