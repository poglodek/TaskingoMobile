using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TaskingoMobile.Models;
using TaskingoMobile.Models.User;
using TaskingoMobile.Models.WorkTask;
using TaskingoMobile.Views;
using Xamarin.Forms;

namespace TaskingoMobile.ViewModels
{
    [QueryProperty(nameof(UserId), nameof(UserId))]
    public class ChatViewModel : BaseViewModel
    {
        private int userId;
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
             
            }
        }

        

        
    }
}
