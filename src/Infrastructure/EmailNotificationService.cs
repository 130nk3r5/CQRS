using System.Threading.Tasks;
using Application.Interfaces;
using Application.Notifications.Models;

namespace Infrastructure
{
    public class EmailNotificationService : INotificationService
    {
        public Task Send(Message message)
        {
            // TODO: Send email

            return Task.CompletedTask;
        }
    }
}
