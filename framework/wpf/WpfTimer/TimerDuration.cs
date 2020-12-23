using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;

namespace WpfTimer
{
    public class TimerDuration : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DateTime _startTime;
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                RaisePropertyChanged(nameof(StartTime));
            }
        }

        private DateTime _endTime;
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                RaisePropertyChanged(nameof(EndTime));
            }
        }

        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                RaisePropertyChanged(nameof(Duration));
            }
        }

        private Timer timer;
        private Stopwatch stopwatch;

        public TimerDuration(DateTime startTime)
        {
            StartTime = startTime;
        }

        public TimerDuration(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public TimerDuration(DateTime startTime, DateTime endTime, TimeSpan duration)
        {
            StartTime = startTime;
            EndTime = endTime;
            Duration = duration;
        }

        private Timer CreateTimer()
        {
            var timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            return timer;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Duration = _duration.Add(new TimeSpan(0, 0, 1));
        }

        public void Start()
        {
            if (timer == null)
                timer = CreateTimer();

            timer.Start();
        }

        public void Pause()
        {
            if (timer == null)
                return;


            timer.Stop();
        }

        public void Stop()
        {
            if (timer == null)
                return;

            timer.Close();
            timer.Dispose();
            timer = null;
        }

        private void UpdateDuration()
        {

        }
    }
}
