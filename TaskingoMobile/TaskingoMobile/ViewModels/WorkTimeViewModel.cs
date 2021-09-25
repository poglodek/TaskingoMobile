using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TaskingoMobile.ViewModels
{
    public class WorkTimeViewModel : BaseViewModel
    {
        public bool IsWorking { get; set; } = false;

        public ICommand ChangeWork { get; set; }

        private static DateTime startDate;
        public  DateTime StartDate
        {
            get => startDate;
            set
            {
                SetProperty(ref startDate, value);
            }
        }



        public WorkTimeViewModel()
        {
            Title = "Work Time";
            ChangeWork = new Command(ChangeWorkTime);
        }

        private async void ChangeWorkTime()
        {
            await WorkTimeServices.ChangeWorkTime(IsWorking);
            IsWorking ^= true;
            OnPropertyChanged(nameof(IsWorking));
            if(IsWorking)
                StartDate = DateTime.Now;
            OnPropertyChanged(nameof(StartDate));
        }
    }
}