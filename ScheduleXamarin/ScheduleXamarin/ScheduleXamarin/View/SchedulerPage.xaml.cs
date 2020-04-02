using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace ScheduleXamarin
{
    public partial class SchedulerPage : ContentPage
    {
        private SchedulerPageModel viewModel;

        public SchedulerPage()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                viewModel = (SchedulerPageModel)BindingContext;
            }
        }

        void schedule_ViewHeaderTapped(System.Object sender, Syncfusion.SfSchedule.XForms.ViewHeaderTappedEventArgs e)
        {
            switch (viewModel.ViewType)
            {
                case ScheduleView.DayView:
                    viewModel.ViewType = ScheduleView.WeekView;
                    break;

                case ScheduleView.WeekView:
                case ScheduleView.TimelineView:
                    viewModel.ViewType = ScheduleView.MonthView;
                    break;
            }
        }
    }
}
