using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskingoMobile.Models.User;
using TaskingoMobile.Models.WorkTask;
using TaskingoMobile.Views;
using Xamarin.Forms;

namespace TaskingoMobile.ViewModels
{
    public class UserListViewModel : BaseViewModel
    {
        public Command LoadItemsCommand{ get; set; }
        public ObservableCollection<UserModel> UserModels { get; set; }
        public Command<UserModel> ItemTapped { get; }

        private UserModel _selectedItem;

        public UserListViewModel()
        {
            UserModels = new ObservableCollection<UserModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<UserModel>(OnItemSelected);
        }

        async void OnItemSelected(UserModel user)
        {
            if (user == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(ChatPage)}?{nameof(ChatViewModel.UserId)}={user.Id}");
        }

        public UserModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                UserModels.Clear();
                var users = await UserServices.GetUsers();
                foreach (var user in users)
                    UserModels.Add(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
    }
}
