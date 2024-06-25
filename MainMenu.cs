using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class MainMenu : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public MainMenu()
        {
            InitializeComponent();
            
            player.settings.volume = 20;
            player.URL = @"sound\main.mp3";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            GameBoard gb = new GameBoard();
            gb.ShowDialog();
            this.Close();
            
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
