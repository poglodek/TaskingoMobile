using TaskingoMobile.Services.IServices;
using TaskingoMobile.Services.Services;
using TaskingoMobile.Views;
using Xamarin.Forms;

namespace TaskingoMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ILoginServices _loginServices => DependencyService.Get<LoginServices>();
        public Command LoginCommand { get; }
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            var response = await _loginServices.Login(Email, Password);
            if(response)
                await Shell.Current.GoToAsync($"///{nameof(AboutPage)}");

        }
    }
}
