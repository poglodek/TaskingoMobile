using System;
using System.Collections.Generic;
using TaskingoMobile.ViewModels;
using TaskingoMobile.Views;
using Xamarin.Forms;

namespace TaskingoMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AppShell), typeof(AppShell));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            
        }

    }
}
