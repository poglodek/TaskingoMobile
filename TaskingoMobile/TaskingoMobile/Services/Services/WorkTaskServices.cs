using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskingoMobile.Api;
using TaskingoMobile.Models.WorkTask;
using TaskingoMobile.Services.IServices;

namespace TaskingoMobile.Services.Services
{
    public class WorkTaskServices : IWorkTaskServices
    {
        public async Task<List<WorkTaskModel>> GetMyTasks()
        {
            var tasksJson = await BaseCall.MakeCall($"WorkTask/GetMyTasks", HttpMethod.Get,null);
            var tasks = JsonConvert.DeserializeObject<List<WorkTaskModel>>(tasksJson);
            return tasks;
        }

        public async Task<WorkTaskModel> GetTaskById(int taskId)
        {
            var taskJson = await BaseCall.MakeCall($"WorkTask/{taskId}", HttpMethod.Get, null);
            var task = JsonConvert.DeserializeObject<WorkTaskModel>(taskJson);
            return task;
        }

        public async Task<bool> CompeteTask(CompleteTaskModel completeModel)
        {
            await BaseCall.MakeCall($"WorkTask/Complete", HttpMethod.Post, completeModel);
            return true;// i zmiana widoku 
        }
    }
}
