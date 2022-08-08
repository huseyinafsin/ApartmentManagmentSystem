using System;
using BackgroundJobs.Abstract;

namespace BackgroundJobs.Concrete.HangfireJobs
{
    public class HangfireJobs : IJobs
    {
        private ISendMessageService _sendMailService;

        public HangfireJobs(ISendMessageService sendMailService)
        {
            _sendMailService = sendMailService;
        }

        public void DelayedJob(int userId, string userName, TimeSpan timeSpan)
        {
            Hangfire.BackgroundJob.Schedule(() =>
                    _sendMailService.SendMessage(userId, userName), timeSpan);
        }

        public void FireAndForget(int userId, string userName)
        {
            Hangfire.BackgroundJob.Enqueue(() => _sendMailService.SendMessage(userId, userName));
        }

        public void ReccuringJob()
        {
            Hangfire.BackgroundJob.Enqueue(() => _sendMailService.SendMessageToAll());
            Console.WriteLine("Message Sent");
        }
    }
}
