using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGameParty
{
    public partial class GameBoard : Form
    {
        private int dicecount = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            dice_timer.Interval = 10;
            dicecount = 0;
            dice_timer.Start();
            button1.Enabled = false;
        }
        private void dice_timer_Tick(object sender, EventArgs e)
        {
            dicecount++;

            Random rand = new Random();
            int dice = rand.Next(0, 6);

            if (dicecount > 70)
            {
                dice_timer.Interval += 3;
            }
            if(dicecount == 100)
            {
                dice_timer.Stop();
                Move(dice);
            }

            lb_Dice.ImageIndex = dice;
        }

    }
}
