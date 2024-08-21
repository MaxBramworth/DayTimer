using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DayTimerRedo.Models;
using DayTimerRedo.Repository;

namespace DayTimerRedo.ViewModels
{
    public class AddEventViewModel : BaseViewModel
    {
        private string _eventName = "Event name...";
        public string EventName
        {
            get => _eventName;
            set
            {
                _eventName = value;
                NotifyPropertyChanged(nameof(EventName));
                CanCreateEvent = EvaluateCanCreateEvent();
            }
        }

        private string _eventHour = string.Empty;
        public string EventHour
        {
            get => _eventHour;
            set
            {
                if ((int.TryParse(value, out int hours) && hours < 24) || string.IsNullOrWhiteSpace(value))
                {
                    _eventHour = value;
                    NotifyPropertyChanged(nameof(EventHour));
                    _eventTime = new TimeOnly(hours, string.IsNullOrWhiteSpace(value) ? 0 : _eventTime.Minute);
                    CanCreateEvent = EvaluateCanCreateEvent();
                }
            }
        }

        private string _eventMinute = string.Empty;
        public string EventMinute
        {
            get => _eventMinute;
            set
            {
                if ((int.TryParse(value, out int mins) && mins < 60) || string.IsNullOrWhiteSpace(value))
                {
                    _eventMinute = value;
                    NotifyPropertyChanged(nameof(EventMinute));
                    _eventTime = new TimeOnly(string.IsNullOrWhiteSpace(value) ? 0 : _eventTime.Hour, mins);
                    CanCreateEvent = EvaluateCanCreateEvent();
                }
            }
        }

        private TimeOnly _eventTime = new();

        private bool _canCreateEvent;
        public bool CanCreateEvent
        {
            get => _canCreateEvent;
            private set
            {
                _canCreateEvent = value;
                NotifyPropertyChanged(nameof(CanCreateEvent));
            }
        }

        private bool _isMon;
        public bool IsMon
        {
            get => _isMon;
            set
            {
                _isMon = value;
                NotifyPropertyChanged(nameof(IsMon));
                CanCreateEvent = EvaluateCanCreateEvent();
            }
        }

        private bool _isTue;
        public bool IsTue
        {
            get => _isTue;
            set
            {
                _isTue = value;
                NotifyPropertyChanged(nameof(IsTue));
                CanCreateEvent = EvaluateCanCreateEvent();
            }
        }

        private bool _isWed;
        public bool IsWed
        {
            get => _isWed;
            set
            {
                _isWed = value;
                NotifyPropertyChanged(nameof(IsWed));
                CanCreateEvent = EvaluateCanCreateEvent();
            }
        }

        private bool _isThu;
        public bool IsThu
        {
            get => _isThu;
            set
            {
                _isThu = value;
                NotifyPropertyChanged(nameof(IsThu));
                CanCreateEvent = EvaluateCanCreateEvent();
            }
        }

        private bool _isFri;
        public bool IsFri
        {
            get => _isFri;
            set
            {
                _isFri = value;
                NotifyPropertyChanged(nameof(IsFri));
                CanCreateEvent = EvaluateCanCreateEvent();
            }
        }

        private bool _isSat;
        public bool IsSat
        {
            get => _isSat;
            set
            {
                _isSat = value;
                NotifyPropertyChanged(nameof(IsSat));
                CanCreateEvent = EvaluateCanCreateEvent();
            }
        }

        private bool _isSun;
        public bool IsSun
        {
            get => _isSun;
            set
            {
                _isSun = value;
                NotifyPropertyChanged(nameof(IsSun));
                CanCreateEvent = EvaluateCanCreateEvent();
            }
        }

        private bool EvaluateCanCreateEvent() =>
            EventName != "Event name..." &&
            !string.IsNullOrWhiteSpace(EventName) &&
            !string.IsNullOrWhiteSpace(EventHour) &&
            !string.IsNullOrWhiteSpace(EventMinute) &&
            (IsMon || IsTue || IsWed || IsThu || IsFri || IsSat || IsSun);


        public AddEventViewModel()
        {
            CreateEventCommand = new RelayCommand((o) => CreateEvent());
        }

        public ICommand CreateEventCommand { get; set; }

        public void CreateEvent()
        {
            string days = "";
            if (IsMon) days+= "Mon ";
            if (IsTue) days+= "Tue ";
            if (IsWed) days+= "Wed ";
            if (IsThu) days+= "Thu ";
            if (IsFri) days+= "Fri ";
            if (IsSat) days+= "Sat ";
            if (IsSun) days+= "Sun ";

            ITimeEvent timeEvent = TimeFactory.CreateMajorTimeEvent(EventName, _eventTime, days);
            CSVParser.AddTimeEvent(timeEvent, "DataBase\\TimeEvents.csv");
        }
    }
}
