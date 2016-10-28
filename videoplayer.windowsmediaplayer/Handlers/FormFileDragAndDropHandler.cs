using AxWMPLib;
using jetmoji.windowsmediaplayer.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jetmoji.windowsmediaplayer.Handlers
{
    public class FormFileDragAndDropHandler : IFormFileDragAndDropHandler
    {
        private readonly Form _form;
        private readonly AxWindowsMediaPlayer _videoPlayer;

        public FormFileDragAndDropHandler(Form form, AxWindowsMediaPlayer videoPlayer)
        {
            _form = form;
            _videoPlayer = videoPlayer;
        }

        public void EnableDragAndDrop()
        {
            _form.AllowDrop = true;
            _form.DragDrop += new DragEventHandler(this.Form_DragDrop);
            _form.DragEnter += new DragEventHandler(this.Form_DragEnter);
        }

        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            // Handle FileDrop data.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    string file = files[0];
                    if (Path.GetExtension(file) != ".mp4")
                        return;

                    // Assign the first image to the picture variable.
                    _videoPlayer.URL = files[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            // If the data is a file, display the copy cursor.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
