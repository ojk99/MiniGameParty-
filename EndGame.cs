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
    public partial class EndGame : Form
    {
        public EndGame(int p1s, int p2s, int p1p, int p2p)
        {
            InitializeComponent();
            WindowsMediaPlayer wp = new WindowsMediaPlayer();
            wp.URL = @"sound\MushroomKingdomHall.wav";
            wp.settings.volume = 50;
            lb_p1p.Text = p1p.ToString();
            lb_p1s.Text = p1s.ToString();
            lb_p2p.Text = p2p.ToString();
            lb_p2s.Text = p2s.ToString();
            lb_win.Location.Offset(204, 251);

            if (p1s == p2s)
            {
                if (p1p == p2p)
                {
                    lb_win.Location.Offset(222, 256);
                    lb_win.Text = "DRAW!!";
                }
                else if (p1p > p2p)
                {
                    lb_win.Text = "Player1 Win";
                }
                else
                {
                    lb_win.Text = "Player2 Win";
                }
            }
            else if (p1s > p2s)
            {
                lb_win.Text = "Player1 Win";
            }
            else
            {
                lb_win.Text = "Player2 Win";
            }
        }

        private void EndGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
