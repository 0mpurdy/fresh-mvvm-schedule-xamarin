using FreshMvvm;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScheduleXamarin
{
    public class SchedulerPageModel : FreshBasePageModel
    {
        /// <summary>
        /// collecions for meetings.
        /// </summary>
        private ObservableCollection<Meeting> meetings;

        /// <summary>
        /// color collection.
        /// </summary>
        private List<Color> colorCollection;

        /// <summary>
        /// current day meeting.
        /// </summary>
        private List<string> currentDayMeetings;

        public SchedulerPageModel()
        {
            this.Meetings = new ObservableCollection<Meeting>();
            this.AddAppointmentDetails();
            this.AddAppointments();
        }

        private ScheduleView viewType = ScheduleView.WeekView;

        public ScheduleView ViewType
        {
            get => viewType;
            set {
                viewType = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CellTappedCommand => new Command<CellTappedEventArgs>(args =>
        {
            switch (ViewType)
            {
                case ScheduleView.WeekView:
                    ViewType = ScheduleView.DayView;
                    break;

                case ScheduleView.MonthView:
                    ViewType = ScheduleView.WeekView;
                    break;
            }
        });

        /// <summary>
        /// Gets or sets meetings.
        /// </summary>
        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return this.meetings;
            }

            set
            {
                this.meetings = value;
                this.RaisePropertyChanged("Meetings");
            }
        }

        /// <summary>
        /// adding appointment details.
        /// </summary>
        private void AddAppointmentDetails()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Support");
            this.currentDayMeetings.Add("Development Meeting");
            this.currentDayMeetings.Add("Scrum");
            this.currentDayMeetings.Add("Project Completion");
            this.currentDayMeetings.Add("Release updates");
            this.currentDayMeetings.Add("Performance Check");

            this.colorCollection = new List<Color>();
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FFF09609"));
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));
        }

        /// <summary>
        /// Adds the appointments.
        /// </summary>
        private void AddAppointments()
        {
            var today = DateTime.Now.Date;
            var random = new Random();

            for (int day = -10; day < 10; day++)
            {
                for (int count = 0; count < 2; count++)
                {
                    var meetingHour = random.Next(9, 18);
                    var meeting = new Meeting
                    {
                        From = today.AddDays(day).AddHours(meetingHour),
                        EventName = $"{meetingHour}: {this.currentDayMeetings[random.Next(currentDayMeetings.Count)]}",
                        Color = this.colorCollection[random.Next(colorCollection.Count)],
                    };
                    meeting.To = meeting.From.AddHours(1);
                    this.Meetings.Add(meeting);
                }
            }
        }
    }
}
