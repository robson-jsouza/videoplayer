﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoplayer.windowsmediaplayer.Handlers.Interfaces
{
    public interface IVideoFragmentHandler
    {
        int CurrentPosition { get; set; }
        int SecondsToPlay { get; set; }
        void PlayVideoFragment();
    }
}
