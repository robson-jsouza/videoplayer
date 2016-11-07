using AxWMPLib;
using videoplayer.windowsmediaplayer.Handlers.Interfaces;
using videoplayer.windowsmediaplayer.Tasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace videoplayer.windowsmediaplayer.Tasks
{
    public class VideoInformationTimerTask : ITimerTask
    {
        public int SecondsToPlay { get; set; }
        public Timer Timer { get; set; }
        private IVideoPlayerHandler _videoPlayerHandler;
        private Form1 _mainForm;

        public VideoInformationTimerTask(IVideoPlayerHandler videoPlayerHandler, Form1 mainForm)
        {
            _videoPlayerHandler = videoPlayerHandler;
            _mainForm = mainForm;
        }

        public void OnRunning()
        {
            VideoInformation videoInformation = new VideoInformation();

            if (_videoPlayerHandler.GetPlayState() == WMPPlayState.wmppsPlaying.ToString())
            {
                double duration = _videoPlayerHandler.GetDuration();
                double currentPosition = _videoPlayerHandler.GetCurrentPosition();
                double timeRemaining = duration - currentPosition;

                videoInformation = new VideoInformation(duration, currentPosition, timeRemaining);
            }

            _mainForm.lblCurrentPosition.Text = videoInformation.CurrentPosition;
            _mainForm.lblDuration.Text = videoInformation.Duration;
            _mainForm.lblTimeRemaining.Text = videoInformation.TimeRemaining;
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

    public class VideoInformation
    {
        public string Duration { get; private set; }
        public string CurrentPosition { get; private set; }
        public string TimeRemaining { get; private set; }

        public VideoInformation()
        { }

        public VideoInformation(double duration, double currentPosition, double timeRemaining)
        {
            Duration = TimeSpan.FromSeconds(duration).ToString();
            CurrentPosition = TimeSpan.FromSeconds(currentPosition).ToString();
            TimeRemaining = TimeSpan.FromSeconds(timeRemaining).ToString();
        }
    }
}
