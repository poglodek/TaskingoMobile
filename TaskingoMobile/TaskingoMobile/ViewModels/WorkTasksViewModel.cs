using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TaskingoMobile.Models;
using TaskingoMobile.Models.WorkTask;
using TaskingoMobile.Views;
using Xamarin.Forms;

namespace TaskingoMobile.ViewModels
{
    public class WorkTasksViewModel : BaseViewModel
    {
        private WorkTaskModel _selectedItem;

        public ObservableCollection<WorkTaskModel> WorkTasks { get; }
        public Command LoadItemsCommand { get; }
        public Command<WorkTaskModel> ItemTapped { get; }

        public WorkTasksViewModel()
        {
            Title = "Tasks";
            WorkTasks = new ObservableCollection<WorkTaskModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<WorkTaskModel>(OnItemSelected);
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                WorkTasks.Clear();
                var tasks = await WorkTaskServices.GetMyTasks();
                foreach (var task in tasks)
                {
                    WorkTasks.Add(task);
                }
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

        public WorkTaskModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }


        async void OnItemSelected(WorkTaskModel item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(WorkTaskPage)}?{nameof(WorkTaskViewModel.TaskId)}={item.Id}");
        }
    }
}