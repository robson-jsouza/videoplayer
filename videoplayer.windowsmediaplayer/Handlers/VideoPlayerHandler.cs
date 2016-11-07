using AxWMPLib;
using videoplayer.windowsmediaplayer.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace videoplayer.windowsmediaplayer.Handlers
{
    public class VideoPlayerHandler : IVideoPlayerHandler
    {
        private readonly AxWindowsMediaPlayer _videoPlayer;

        public VideoPlayerHandler(AxWindowsMediaPlayer videoPlayer)
        {
            _videoPlayer = videoPlayer;
        }

        public void FastForward()
        {
            _videoPlayer.Ctlcontrols.fastForward();
        }

        public void FastReverse()
        {
            _videoPlayer.Ctlcontrols.fastReverse();
        }

        public void FullScreen()
        {
            _videoPlayer.fullScreen = true;
        }

        public void Pause()
        {
            _videoPlayer.Ctlcontrols.pause();
        }

        public void Play()
        {
            _videoPlayer.Ctlcontrols.play();
        }

        public void SetCurrentPosition(int currentPosition)
        {
            _videoPlayer.Ctlcontrols.currentPosition += currentPosition;
        }

        public void Stop()
        {
            _videoPlayer.Ctlcontrols.stop();
        }

        public double GetCurrentPosition()
        {
            return _videoPlayer.Ctlcontrols.currentPosition;
        }

        public double GetDuration()
        {
            IWMPMedia media = _videoPlayer.newMedia(_videoPlayer.URL);
            
            return media.duration;
        }

        public string GetPlayState()
        {
            return _videoPlayer.playState.ToString();
        }
    }
}
