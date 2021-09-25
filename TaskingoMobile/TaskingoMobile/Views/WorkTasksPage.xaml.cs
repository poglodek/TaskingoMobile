using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoMobile.Models;
using TaskingoMobile.ViewModels;
using TaskingoMobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskingoMobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        WorkTasksViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new WorkTasksViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}