using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FreshMvvm;
using Syncfusion.SfSchedule.XForms;
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
            Meetings = new ObservableCollection<Meeting>();
            AddAppointmentDetails();
            AddAppointments();
        }

        private ScheduleView viewType = ScheduleView.WeekView;

        public ScheduleView ViewType
        {
            get => viewType;
            set
            {
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
                return meetings;
            }

            set
            {
                meetings = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// adding appointment details.
        /// </summary>
        private void AddAppointmentDetails()
        {
            currentDayMeetings = new List<string>
            {
                "General Meeting",
                "Plan Execution",
                "Project Plan",
                "Consulting",
                "Support",
                "Development Meeting",
                "Scrum",
                "Project Completion",
                "Release updates",
                "Performance Check"
            };

            colorCollection = new List<Color>
            {
                Color.FromHex("#FFA2C139"),
                Color.FromHex("#FFD80073"),
                Color.FromHex("#FF1BA1E2"),
                Color.FromHex("#FFE671B8"),
                Color.FromHex("#FFF09609"),
                Color.FromHex("#FF339933"),
                Color.FromHex("#FF00ABA9"),
                Color.FromHex("#FFE671B8"),
                Color.FromHex("#FF1BA1E2"),
                Color.FromHex("#FFD80073"),
                Color.FromHex("#FFA2C139"),
                Color.FromHex("#FFA2C139"),
                Color.FromHex("#FFD80073"),
                Color.FromHex("#FF339933"),
                Color.FromHex("#FFE671B8"),
                Color.FromHex("#FF00ABA9")
            };
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
                        Color = colorCollection[random.Next(colorCollection.Count)],
                    };
                    meeting.To = meeting.From.AddHours(1);
                    Meetings.Add(meeting);
                }
            }
        }
    }
}
