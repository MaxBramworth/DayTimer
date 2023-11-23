using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

namespace DayTimerRedo.Models
{
    public static class NotificationService
    {
        public static void ShowMessage(string message)
        {
            new ToastContentBuilder().AddText(message).Show();
        }
    }
}
