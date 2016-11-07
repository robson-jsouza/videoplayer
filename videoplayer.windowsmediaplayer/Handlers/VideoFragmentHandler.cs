using AxWMPLib;
using videoplayer.windowsmediaplayer.Handlers.Interfaces;
using videoplayer.windowsmediaplayer.Tasks;
using videoplayer.windowsmediaplayer.Tasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoplayer.windowsmediaplayer.Handlers
{
    public class VideoFragmentHandler : IVideoFragmentHandler
    {
        private readonly IVideoPlayerHandler _videoPlayerHandler;
        private readonly ITimerTask _timerTask;
        private TimerHandler _timerHandler;
        public int CurrentPosition { get; set; }
        public int SecondsToPlay { get; set; }

        public VideoFragmentHandler(IVideoPlayerHandler videoPlayerHandler)
        {
            _videoPlayerHandler = videoPlayerHandler;
            _timerTask = new VideoTimerTask(_videoPlayerHandler);
            _timerHandler = new TimerHandler(_timerTask);
        }

        public void PlayVideoFragment()
        {
            ValidateSettings();
            _videoPlayerHandler.SetCurrentPosition(CurrentPosition);
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
