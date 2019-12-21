using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifications.Wpf;
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using System.Windows;

namespace Vehicles_Reservation_System.UI
{
    class Notification
    {
        private static Notification notification = new Notification();

        private Notification() { }

        public static Notification giveInstance()
        {
            return notification;
        }

        public void successNotifier(string message)
        {
            var notificationManager = new NotificationManager();

            notificationManager.Show(new NotificationContent
            {
                Title = "Success",
                Message = message,
                Type = NotificationType.Success
            });

            //Notifier notifier = new Notifier(cfg =>
            //{
            //    cfg.PositionProvider = new WindowPositionProvider(
            //        parentWindow: Application.Current.MainWindow,
            //        corner: Corner.BottomRight,
            //        offsetX: 25,
            //        offsetY: 0);

            //    cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
            //        notificationLifetime: TimeSpan.FromSeconds(10),
            //        maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            //    cfg.Dispatcher = Application.Current.Dispatcher;
            //});

            //notifier.ShowSuccess(message);
        }

        public void errorNotifier(string message)
        {
            var notificationManager = new NotificationManager();

            notificationManager.Show(new NotificationContent
            {
                Title = "Error",
                Message = message,
                Type = NotificationType.Error
            });
        }

        public async void MessageDialog(MetroWindow window, string title, string message)
        {
            await window.ShowMessageAsync(title, message);
        }
    }
}