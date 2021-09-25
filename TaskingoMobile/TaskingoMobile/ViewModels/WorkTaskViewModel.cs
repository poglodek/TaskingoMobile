using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TaskingoMobile.Models;
using TaskingoMobile.Models.User;
using TaskingoMobile.Models.WorkTask;
using Xamarin.Forms;

namespace TaskingoMobile.ViewModels
{
    [QueryProperty(nameof(TaskId), nameof(TaskId))]
    public class WorkTaskViewModel : BaseViewModel
    {
        private int taskId;
        private int priority;
        private string title;
        private string description;
        private string status;  //In queue, In progress, Done, Canceled
        private string comment;
        private string workGroup;
        private DateTime createdTime;
        private DateTime deadLine;
        private UserModel whoCreated;
        private bool isAssigned;
        private UserModel assignedUser;
        public int Id { get; set; }

        public string NewComment{ get; set; }

        public Command Complete
        {
            get;
            set;
        }

        public WorkTaskViewModel()
        {
            Complete = new Command(CompleteTask);
        }

        public int Priority
        {
            get => priority;
            set => SetProperty(ref priority, value);
        }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }
        public string Comment
        {
            get => comment;
            set => SetProperty(ref comment, value);
        }
        public string WorkGroup
        {
            get => workGroup;
            set => SetProperty(ref workGroup, value);
        }
        public DateTime CreatedTime
        {
            get => createdTime;
            set => SetProperty(ref createdTime, value);

        }
        public DateTime DeadLine 
        {
            get=> deadLine;
            set => SetProperty(ref deadLine, value);
            
        } 
        public UserModel WhoCreated
        {
            get => whoCreated;
            set => SetProperty(ref whoCreated, value);
        }
        public bool IsAssigned
        {
            get => isAssigned;
            set => SetProperty(ref isAssigned, value);
        }
        public UserModel AssignedUser
        {
            get => assignedUser;
            set => SetProperty(ref assignedUser, value);
        }
        public int TaskId
        {
            get
            {
                return taskId;
            }
            set
            {
                taskId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int taskId)
        {
            try
            {
                var task = await WorkTaskServices.GetTaskById(taskId);
                Id = task.Id;
                Priority = task.Priority;
                Title = task.Title;
                Description = task.Description;
                Status = task.Status;
                Comment = task.Comment;
                WorkGroup = task.WorkGroup;
                CreatedTime = task.CreatedTime;
                DeadLine = task.DeadLine;
                WhoCreated = task.WhoCreated;
                IsAssigned = task.IsAssigned;
                AssignedUser = task.AssignedUser;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void CompleteTask(object obj)
        {
            var result = await App.Current.MainPage.DisplayAlert("Complete task", "Do you want to complete this task?",
                "Ok", "Cancel");
            if (!result) return;
            var completeModel = new CompleteTaskModel
            {
                Id = Id,
                Comment = NewComment
            };
            await WorkTaskServices.CompeteTask(completeModel);
        }
    }
}
