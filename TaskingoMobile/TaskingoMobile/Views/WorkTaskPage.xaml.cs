using System.ComponentModel;
using TaskingoMobile.ViewModels;
using Xamarin.Forms;

namespace TaskingoMobile.Views
{
    public partial class WorkTaskPage : ContentPage
    {
        public WorkTaskPage()
        {
            InitializeComponent();
            BindingContext = new WorkTaskViewModel();
        }
    }
}