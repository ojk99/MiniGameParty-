using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MiniGameParty
{
    public partial class GameBoard : Form
    {
        public void ScoreCreate(int scoreLocation)
        {
            lb_eventmag.Text = "점수 교환소가 나타났습니다.";
            splayer = new SoundPlayer(@"sound\PowerStar.wav");
            splayer.Play();
            if (scoreLocation == 1)
            {
                r1_3.ForeColor = Color.Gold;
            }
            else if (scoreLocation == 2)
            {
                r2_2.ForeColor = Color.Gold;
            }
            else if(scoreLocation == 3)
            {
                r3_2.ForeColor = Color.Gold;
            }
            else if(scoreLocation == 4)
            {
                r4_2.ForeColor = Color.Gold;
            }
        }

        WindowsMediaPlayer starsound = new WindowsMediaPlayer();
        public void ScoreDelete()
        {
            move_timer.Stop();
            
            if (p1_Select)
            {
                if(p1_Point >= 25)
                {
                    if(MessageBox.Show("스코어를 25포인트를 소모하여 구매 하시겠습니까?","스코어 구매", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        p1_Point -= 25;
                        p1_Score += 1;
                        scoreTurn = 2;

                        r1_3.ForeColor = Color.DimGray;
                        r2_2.ForeColor = Color.DimGray;
                        r3_2.ForeColor = Color.DimGray;
                        r4_2.ForeColor = Color.DimGray;
                        lb_eventmag.Text = "1플레이어\n25포인트를 소모하여 점수 +1";
                        starsound.URL = @"sound\StarCatch.wav";
                    }
                }
                else
                {
                    MessageBox.Show("포인트가 부족하여 스코어를 구매하실 수 없습니다.");
                }

                
            }
            else if(p2_Select)
            {
                if (p2_Point >= 25)
                {
                    if (MessageBox.Show("스코어를 25포인트를 소모하여 구매 하시겠습니까?", "스코어 구매", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        p2_Point -= 25;
                        p2_Score += 1;
                        scoreTurn = 2;

                        r1_3.ForeColor = Color.DimGray;
                        r2_2.ForeColor = Color.DimGray;
                        r3_2.ForeColor = Color.DimGray;
                        r4_2.ForeColor = Color.DimGray;
                        lb_eventmag.Text = "2플레이어\n25포인트를 소모하여 점수 +1";
                        starsound.URL = @"sound\StarCatch.wav";
                    }
                }
                else
                {
                    MessageBox.Show("포인트가 부족하여 스코어를 구매하실 수 없습니다.");
                }
            }

            PrintPoint();

            if (move == 0)
            {
                move_timer.Stop();
                LocationEventPlay();
            }
            else
            {
                move_timer.Start();
            }

        }
    }
}
