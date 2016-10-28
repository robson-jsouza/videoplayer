using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jetmoji.windowsmediaplayer.Tasks.Interfaces
{
    public interface ITimerTask
    {
        void OnStart();
        void OnStop();
    }
}
