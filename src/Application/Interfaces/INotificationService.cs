using System.Threading.Tasks;
using Application.Notifications.Models;

namespace Application.Interfaces
{
    public interface INotificationService
    {
        Task Send(Message message);
    }
}
