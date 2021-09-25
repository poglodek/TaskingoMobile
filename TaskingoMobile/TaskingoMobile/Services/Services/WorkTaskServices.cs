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
    }
}
