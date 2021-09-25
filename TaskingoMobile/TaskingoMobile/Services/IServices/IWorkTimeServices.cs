using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskingoMobile.Services.IServices
{
    public interface IWorkTimeServices
    {
        Task ChangeWorkTime(bool isWorking);
    }
}
