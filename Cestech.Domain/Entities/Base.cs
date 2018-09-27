using Flunt.Notifications;

namespace Cestech.Domain.Entities
{
    public class Base : Notifiable
    {
        public Base()
        {
            Status = true;
        }

        public bool Status { get; protected set; }
    }
}
