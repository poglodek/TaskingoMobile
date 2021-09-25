using System.ComponentModel;
using TaskingoMobile.ViewModels;
using Xamarin.Forms;

namespace TaskingoMobile.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            BindingContext = new WorkTaskViewModel();
        }
    }
}