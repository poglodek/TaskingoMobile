using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoMobile.Models.WorkTask;

namespace TaskingoMobile.Services.IServices
{
    public interface IWorkTaskServices
    {
        Task<List<WorkTaskModel>> GetMyTasks();
        Task<WorkTaskModel> GetTaskById(int taskId);
        Task CompeteTask(CompleteTaskModel completeModel);
    }
}