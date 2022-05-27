using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _270522
{
    public partial class Form1 : Form
    {
        
        SoundPlayer player = new SoundPlayer();
        private bool musicLoaded = false;
        private bool play = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileMusic = new OpenFileDialog();
                fileMusic.Filter = "WAV Files (.wav)|*.wav | MP3 Files (.mp3)|*.mp3";
                if (fileMusic.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(fileMusic.FileName) != ".mp3" &&
                        Path.GetExtension(fileMusic.FileName) != ".wav")
                    {
                        MessageBox.Show("Por gentileza selecione um arquivo .mp3 ou .wav!");
                        musicLoaded = false;
                    }
                    else
                    {
                        label1.Text = fileMusic.FileName;
                        player.SoundLocation = fileMusic.FileName;
                        player.Load();
                        musicLoaded = true;
                        button2.Enabled = true;
                        player.PlaySync();
                    }
                }
            }
            catch { MessageBox.Show("Ops! verifique se seu arquivo nao está corrompido."); musicLoaded = false; button2.Enabled = false; };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (musicLoaded && button2.Enabled)
            {
                if (!play)
                {
                    play = true;
                    player.Play();
                    button2.Text = "STOP";
                }
                else
                {
                    play = false;
                    player.Stop();
                    button2.Text = "PLAY";
                }
            }
        }

    }
}
