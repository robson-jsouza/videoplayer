using videoplayer.windowsmediaplayer.Handlers;
using videoplayer.windowsmediaplayer.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using videoplayer.windowsmediaplayer.Handlers;

namespace videoplayer.windowsmediaplayer
{
    public partial class Form1 : Form
    {
        private IVideoPlayerHandler _videoPlayerHandler;
        private IFormFileDragAndDropHandler _formFileDragAndDropHandler;
        private IVideoFragmentHandler _videoFragmentHandler;
        private IVideoInformationHandler _videoInformationHandler;

        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            _videoPlayerHandler = new VideoPlayerHandler(axWindowsMediaPlayer1);
            _formFileDragAndDropHandler = new FormFileDragAndDropHandler(this, axWindowsMediaPlayer1);
            _formFileDragAndDropHandler.EnableDragAndDrop();
            _videoFragmentHandler = new VideoFragmentHandler(_videoPlayerHandler);
            _videoInformationHandler = new VideoInformationHandler(_videoPlayerHandler, this);
            _videoInformationHandler.CalculateVideoInformation();
            ////axWindowsMediaPlayer1.uiMode = "none";
        }
        
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _videoPlayerHandler.Play();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _videoPlayerHandler.Pause();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _videoPlayerHandler.Stop();
        }

        private void rewindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _videoPlayerHandler.FastReverse();
        }

        private void fastForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _videoPlayerHandler.FastForward();
        }

        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _videoPlayerHandler.FullScreen();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void openMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
        }

        private void playFrom5SecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _videoFragmentHandler.SecondsToPlay = 5;
                _videoFragmentHandler.CurrentPosition = 30;
                _videoFragmentHandler.PlayVideoFragment();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
