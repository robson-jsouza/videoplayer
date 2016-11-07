using AxWMPLib;
using videoplayer.windowsmediaplayer;
using videoplayer.windowsmediaplayer.Handlers;
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
    public class VideoInformationHandler : IVideoInformationHandler
    {
        private readonly ITimerTask _timerTask;
        private TimerHandler _timerHandler;

        public VideoInformationHandler(IVideoPlayerHandler videoPlayerHandler, Form1 mainForm)
        {
            _timerTask = new VideoInformationTimerTask(videoPlayerHandler, mainForm);
            _timerHandler = new TimerHandler(_timerTask);
        }

        public void CalculateVideoInformation()
        {
            _timerHandler.Execute();
        }
    }
}
