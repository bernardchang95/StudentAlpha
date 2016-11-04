using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudentAlpha.Views.SubViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventsAddPage : Page
    {
        public EventsAddPage()
        {
            this.InitializeComponent();
        }

        private async void Add-Click(object sender, RoutedEventArgs e)
        {
            // Create an Appointment that should be added the user's appointments provider app.
            var appointment = new Windows.ApplicationModel.Appointments.Appointment();

            // Get the selection rect of the button pressed to add this appointment
            var rect = GetElementRect(sender as FrameworkElement);

            // ShowAddAppointmentAsync returns an appointment id if the appointment given was added to the user's calendar.
            // This value should be stored in app data and roamed so that the appointment can be replaced or removed in the future.
            // An empty string return value indicates that the user canceled the operation before the appointment was added.
            String appointmentId = await Windows.ApplicationModel.Appointments.AppointmentManager.ShowAddAppointmentAsync(
                                   appointment, rect, Windows.UI.Popups.Placement.Default);
            if (appointmentId != String.Empty)
            {
                ResultTextBlock.Text = "Appointment Id: " + appointmentId;
            }
            else
            {
                ResultTextBlock.Text = "Appointment not added.";
            }
        }
}
