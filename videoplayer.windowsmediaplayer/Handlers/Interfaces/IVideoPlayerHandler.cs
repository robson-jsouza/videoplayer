using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jetmoji.windowsmediaplayer.Handlers.Interfaces
{
    public interface IVideoPlayerHandler
    {
        void Play();
        void Pause();
        void Stop();
        void FastReverse();
        void FastForward();
        void FullScreen();
    }
}
