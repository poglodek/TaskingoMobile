using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaskingoMobile.Api;
using TaskingoMobile.Views;
using Xamarin.Forms;

namespace TaskingoMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public string Ip { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            try
            {
                var response = await BaseCall.MakeCall("user/login", System.Net.Http.HttpMethod.Post, null);
                Console.WriteLine(response);
                await Shell.Current.GoToAsync($"///{nameof(AboutPage)}");
            }
            catch(Exception ex)
            {
                 Console.WriteLine(ex);
            }

        }
    }
}
