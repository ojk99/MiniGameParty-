using MiniGameParty2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MiniGameParty
{
    public partial class GameBoard : Form
    {
        int turn = 50;
        WindowsMediaPlayer wmpmain = new WindowsMediaPlayer();
        int time = 0;
        public GameBoard()
        {
            InitializeComponent();
            lb_lastturn.Text = turn.ToString();
            wmpmain.settings.volume = 50;
            wmpmain.URL = @"sound\gameBgm.wav";
            wmpmain.controls.play();
            mainSoundTimer.Start();
        }

        private void mainSoundTimer_Tick(object sender, EventArgs e)
        {
            time++;

            if(time >= 196)
            {
                time = 0;
                wmpmain.controls.stop();
                wmpmain.controls.play();
            }
        }
    }
}
