using DayTimerRedo.Models;
using DayTimerRedo.Views;
using DayTimerRedo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DayTimerRedo.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _timeRemainingFormatted = "00:00.00";
        public string TimeRemainingFormatted
        {
            get => _timeRemainingFormatted;
            set
            {
                _timeRemainingFormatted = value;
                NotifyPropertyChanged(nameof(TimeRemainingFormatted));
            }
        }

        private string _timeEventTitle = "Until Lunch";
        public string TimeEventTitle
        {
            get => _timeEventTitle;
            set
            {
                _timeEventTitle = value;
                NotifyPropertyChanged(nameof(TimeEventTitle));
            }
        }

        private UserControl _addEventPage;
        public UserControl AddEventPage
        {
            get => _addEventPage;
            set
            {
                _addEventPage = value;
                NotifyPropertyChanged(nameof(AddEventPage));
            }
        }

        public MainWindowViewModel()
        {
            MainDayTimer mainDayTimer = new();
            mainDayTimer.ViewModel = this;
            mainDayTimer.BeginLoop();
            AddEventPage = new AddEvent();
        }

        public void FormatTimeRemaining(TimeSpan duration)
        {
            string hours = duration.Hours > 9 ? $"{duration.Hours}" : $"0{duration.Hours}";
            string minutes = duration.Minutes > 9 ? $"{duration.Minutes}" : $"0{duration.Minutes}";
            string seconds = duration.Seconds > 9 ? $"{duration.Seconds}" : $"0{duration.Seconds}";
            TimeRemainingFormatted = $"{hours}:{minutes}.{seconds}";
        }

        public void DisplayNoEventsRemaining()
        {
            TimeRemainingFormatted = "No events remaining";
        }
    }
}
