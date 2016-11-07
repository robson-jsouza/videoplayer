using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace videoplayer.windowsmediaplayer.Tasks.Interfaces
{
    public interface ITimerTask
    {
        int SecondsToPlay { get; set; }
        Timer Timer { get; set; }
        void OnStart();
        void OnRunning();
        void OnStop();
    }
}
