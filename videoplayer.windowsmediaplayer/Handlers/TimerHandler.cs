using videoplayer.windowsmediaplayer.Handlers.Interfaces;
using videoplayer.windowsmediaplayer.Tasks.Interfaces;
using System;
using System.Windows.Forms;

namespace videoplayer.windowsmediaplayer.Handlers
{
    public class TimerHandler
    {
        private Timer timer;
        private readonly ITimerTask _timerTask;
        public int SecondsToPlay { get; set; }

        public TimerHandler(ITimerTask timerTask)
        {
            _timerTask = timerTask;
        }

        public void Execute()
        {
            _timerTask.SecondsToPlay = SecondsToPlay;
            StartWmpPlayerTimer();
        }

        private void tmrWmpPlayerPosition_Tick(object sender, EventArgs e)
        {
            _timerTask.OnRunning();
        }

        private void StartWmpPlayerTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(tmrWmpPlayerPosition_Tick);
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Start();

            _timerTask.OnStart();
            _timerTask.Timer = timer;
        }

        private void StopWmpPlayerTimer()
        {
            if (timer != null)
                timer.Dispose();
            timer = null;
        }
    }
}
