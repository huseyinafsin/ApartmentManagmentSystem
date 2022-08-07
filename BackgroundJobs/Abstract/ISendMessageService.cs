using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Abstract
{
    public interface ISendMessageService
    {
        Task SendMessage(int userId, string message);
        Task SendMessageToAll();
    }
}
