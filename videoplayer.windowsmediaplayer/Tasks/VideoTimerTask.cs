using AxWMPLib;
using videoplayer.windowsmediaplayer.Handlers.Interfaces;
using videoplayer.windowsmediaplayer.Tasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace videoplayer.windowsmediaplayer.Tasks
{
    public class VideoTimerTask : ITimerTask
    {
        public int SecondsToPlay { get; set; }
        public Timer Timer { get; set; }
        private IVideoPlayerHandler _videoPlayerHandler;

        public VideoTimerTask(IVideoPlayerHandler videoPlayerHandler)
        {
            _videoPlayerHandler = videoPlayerHandler;
        }

        private int countSeconds = 0;
        public void OnRunning()
        {
            countSeconds++;
            if (SecondsToPlay != countSeconds) return;

            countSeconds = 0;
            _videoPlayerHandler.Pause();
            Timer.Stop();
        }

        public void OnStart()
        {
            _videoPlayerHandler.Play();
        }

        public void OnStop()
        {
            _videoPlayerHandler.Pause();
        }
    }
}
