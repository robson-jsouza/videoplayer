using AxWMPLib;
using jetmoji.windowsmediaplayer.Handlers.Interfaces;
using jetmoji.windowsmediaplayer.Tasks;
using jetmoji.windowsmediaplayer.Tasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jetmoji.windowsmediaplayer.Handlers
{
    public class VideoFragmentHandler : IVideoFragmentHandler
    {
        private readonly AxWindowsMediaPlayer _videoPlayer;
        private readonly ITimerTask _timerTask;
        private TimerHandler _timerHandler;
        public int CurrentPosition { get; set; }
        public int SecondsToPlay { get; set; }

        public VideoFragmentHandler(AxWindowsMediaPlayer videoPlayer)
        {
            _videoPlayer = videoPlayer;
            _timerTask = new TimerTask(_videoPlayer);
            _timerHandler = new TimerHandler(_timerTask);
        }

        public void PlayVideoFragment()
        {
            ValidateSettings();
            _videoPlayer.Ctlcontrols.currentPosition += CurrentPosition;
            _timerHandler.SecondsToPlay = SecondsToPlay;
            _timerHandler.Execute();
        }
        
        private void ValidateSettings()
        {
            bool isEverythingSet = true;

            if (CurrentPosition == 0)
                isEverythingSet = false;
            if (SecondsToPlay == 0)
                isEverythingSet = false;

            if (!isEverythingSet)
                throw new Exception("The properties must be set");
        }
    }
}
