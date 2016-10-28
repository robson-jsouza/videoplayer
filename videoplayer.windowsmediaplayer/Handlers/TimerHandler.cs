using jetmoji.windowsmediaplayer.Handlers.Interfaces;
using jetmoji.windowsmediaplayer.Tasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jetmoji.windowsmediaplayer.Handlers
{
    public class TimerHandler
    {
        private Timer tmrWmpPlayerPosition;
        private readonly ITimerTask _timerTask;
        public int SecondsToPlay { get; set; }

        public TimerHandler(ITimerTask timerTask)
        {
            _timerTask = timerTask;
        }

        public void Execute()
        {
            StartWmpPlayerTimer();
        }

        private int countSeconds = 0;
        private void tmrWmpPlayerPosition_Tick(object sender, EventArgs e)
        {
            countSeconds++;
            if (SecondsToPlay != countSeconds) return;
            _timerTask.OnStop();
            StopWmpPlayerTimer();
        }

        private void StartWmpPlayerTimer()
        {
            _timerTask.OnStart();
            countSeconds = 0;
            tmrWmpPlayerPosition = new Timer();
            tmrWmpPlayerPosition.Tick += new EventHandler(tmrWmpPlayerPosition_Tick);
            tmrWmpPlayerPosition.Enabled = true;
            tmrWmpPlayerPosition.Interval = 1000;
            tmrWmpPlayerPosition.Start();
        }

        private void StopWmpPlayerTimer()
        {
            if (tmrWmpPlayerPosition != null)
                tmrWmpPlayerPosition.Dispose();
            tmrWmpPlayerPosition = null;
        }
    }
}
