using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

namespace DayTimerRedo.Models
{
    public class NotificationService
    {
        private static void ShowNotification(string message)
        {
            new ToastContentBuilder().AddText(message).Show();
        }
    }
}
