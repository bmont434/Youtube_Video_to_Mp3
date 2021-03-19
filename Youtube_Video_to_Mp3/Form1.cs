using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaToolkit;
using VideoLibrary;
using System.IO;
using MediaToolkit.Model;

namespace Youtube_Video_to_Mp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string path = SaveVideoToDisk(txtURL.Text);
            ConvertMp3(path);
        }

        private string SaveVideoToDisk(string link)
        {
            lblIndicator.Text = "In Progress";
            var youTube = YouTube.Default; // starting point for YouTube actions
            var video = youTube.GetVideo(link); // gets a Video object with info about the video
            File.WriteAllBytes(@"C:\" + video.FullName, video.GetBytes());
            return @"C:\" + video.FullName;
        }

        private void ConvertMp3(string filelocation)
        {
            var inputFile = new MediaFile { Filename = filelocation };
            var outputFile = new MediaFile { Filename = filelocation + ".mp3" };

            using (var engine = new Engine())
            {
                engine.Convert(inputFile, outputFile);
            }
            lblIndicator.Text = "Done!";
        }
    }
}

