using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskingoMobile.Api;
using TaskingoMobile.Services.IServices;

namespace TaskingoMobile.Services.Services
{
    public class WorkTimeServices : IWorkTimeServices
    {
        public async Task ChangeWorkTime(bool isWorking)
        {
            await BaseCall.MakeCall(isWorking ?  "WorkTime/Stop" : "WorkTime/Start" , HttpMethod.Post, null);
        }
    }
}
