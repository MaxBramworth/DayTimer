using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTimerRedo.Viewmodels
{
    internal class MainWindowViewModel : BaseViewmodel
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
    }
}
