using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskingoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListPage : ContentPage
    {
        UserListViewModel _viewModel;

        public UserListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new UserListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}