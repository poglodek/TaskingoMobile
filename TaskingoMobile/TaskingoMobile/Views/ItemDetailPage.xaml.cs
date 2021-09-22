using System.ComponentModel;
using TaskingoMobile.ViewModels;
using Xamarin.Forms;

namespace TaskingoMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}