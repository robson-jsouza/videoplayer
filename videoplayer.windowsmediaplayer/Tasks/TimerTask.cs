using AxWMPLib;
using jetmoji.windowsmediaplayer.Tasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jetmoji.windowsmediaplayer.Tasks
{
    public class TimerTask : ITimerTask
    {
        private AxWindowsMediaPlayer _videoPlayer;

        public TimerTask(AxWindowsMediaPlayer videoPlayer)
        {
            _videoPlayer = videoPlayer;
        }

        public void OnStart()
        {
            _videoPlayer.Ctlcontrols.play();
        }

        public void OnStop()
        {
            _videoPlayer.Ctlcontrols.pause();
        }
    }
}
