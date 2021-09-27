using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskingoMobile.Models;
using TaskingoMobile.Models.Chat;
using TaskingoMobile.Models.User;
using TaskingoMobile.Models.WorkTask;
using TaskingoMobile.Views;
using Xamarin.Forms;

namespace TaskingoMobile.ViewModels
{
    [QueryProperty(nameof(UserId), nameof(UserId))]
    public class ChatViewModel : BaseViewModel
    {
        public ObservableCollection<MessageModel> MessagesList { get; set; }

        public ChatViewModel()
        {
            MessagesList = new ObservableCollection<MessageModel>();
            _ChatServices.ReceiveMessage += _ChatServices_ReceiveMessage;
            SendMessage = new Command(SendMessageByUserId);
        }

        private void _ChatServices_ReceiveMessage(MessageModel obj)
        {
            MessagesList.Add(obj);
            OnPropertyChanged(nameof(Messages));

        }

        public string Messages
        {
            get
            {
                var messages = "";
                foreach (var message in MessagesList)
                    messages += $"\n{message}";
                return messages;
            }
        }

        private string message;

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        
        private int userId;
        public int UserId
        {
            get => userId;
            set => userId = value;
        }

        public ICommand SendMessage{ get; set; }

        private void SendMessageByUserId()
        {
            _ChatServices.SendMessage(Message, UserId);
            MessagesList.Add(new MessageModel
            {
                Sender = "Me",
                UserMessage = Message
            });
            Message = "";
            OnPropertyChanged(nameof(Messages));
        }
    }
}
