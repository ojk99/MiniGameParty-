using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace MiniGameParty
{
    public partial class GameBoard : Form
    {
        int p1_Location = 0;
        int p2_Location = 0;

        int p1_Location_r = 0;
        int p2_Location_r = 0;

        bool p1_BtSelect = false;   //화살표 방향으로 이동하게 만들기 위해 추가
        bool p2_BtSelect = false;   //화살표 방향으로 이동하게 만들기 위해 추가

        bool p1_Select = true;      // 플레이어 턴
        bool p2_Select = false;     // 플레이어 턴

        int move = 0;

        public void Move(int dice)
        {
            move = dice + 1;
            move_timer.Start();
        }
        private void move_timer_Tick(object sender, EventArgs e)
        {
            move--;
            if (p1_Select)
            {

                if (p1_Location_r == 0 && p1_Location == 10 && p1_BtSelect == false)
                {
                    go1.Enabled = true;
                    up1.Enabled = true;
                    move_timer.Stop();
                    return;
                }
                else if (p1_Location_r == 0 && p1_Location == 19 && p1_BtSelect == false)
                {
                    go2.Enabled = true;
                    right2.Enabled = true;
                    move_timer.Stop();
                    return;
                }
                else if (p1_Location_r == 0 && p1_Location == 30 && p1_BtSelect == false)
                {
                    go3.Enabled = true;
                    down3.Enabled = true;
                    move_timer.Stop();
                    return;
                }
                else if (p1_Location_r == 0 && p1_Location == 40 && p1_BtSelect == false)
                {
                    go4.Enabled = true;
                    left4.Enabled = true;
                    move_timer.Stop();
                    return;
                }

                p1_BtSelect = false;
                p1_Location += 1;
                

                if(p1_Location_r == 1 && p1_Location == 10)
                {
                    p1_Location_r = 0;
                    p1_Location = 27;
                    int x = this.Controls["r_" + p1_Location].Location.X;
                    int y = this.Controls["r_" + p1_Location].Location.Y;
                    player1.Location = new Point(x + 4, y + 12);
                }
                else if(p1_Location_r == 2 && p1_Location == 4)
                {
                    p1_Location_r = 1;
                    p1_Location = 6;
                    int x = this.Controls["r" + p1_Location_r + "_" + p1_Location].Location.X;
                    int y = this.Controls["r" + p1_Location_r + "_" + p1_Location].Location.Y;
                    player1.Location = new Point(x + 4, y + 12);
                }
                else if(p1_Location_r == 0 && p1_Location == 46)
                {
                    p1_Location_r = 0;
                    p1_Location = 0;
                    int x = this.Controls["r_" + p1_Location].Location.X;
                    int y = this.Controls["r_" + p1_Location].Location.Y;
                    player1.Location = new Point(x + 4, y + 12);

                    AddPoint(10);   //start 지점을 지나면 10포인트씩 얻음
                    splayer = new SoundPlayer(@"sound\point.wav");
                    splayer.Play();
                }
                else if(p1_Location_r == 4 && p1_Location == 5)
                {
                    p1_Location_r = 3;
                    p1_Location = 4;
                    int x = this.Controls["r" + p1_Location_r + "_" + p1_Location].Location.X;
                    int y = this.Controls["r" + p1_Location_r + "_" + p1_Location].Location.Y;
                    player1.Location = new Point(x + 4, y + 12);
                }
                else if(p1_Location_r == 3 && p1_Location == 10)
                {
                    p1_Location_r = 0;
                    p1_Location = 5;
                    int x = this.Controls["r_" + p1_Location].Location.X;
                    int y = this.Controls["r_" + p1_Location].Location.Y;
                    player1.Location = new Point(x + 4, y + 12);
                }
                else if(p1_Location_r == 0)
                {
                    int x = this.Controls["r_" + p1_Location].Location.X;
                    int y = this.Controls["r_" + p1_Location].Location.Y;
                    player1.Location = new Point(x + 4, y + 12);
                }
                else if(p1_Location_r > 0)
                {
                    int x = this.Controls["r"+p1_Location_r+"_" + p1_Location].Location.X;
                    int y = this.Controls["r"+p1_Location_r +"_" + p1_Location].Location.Y;
                    player1.Location = new Point(x + 4, y + 12);
                }

                // 배경 색 변경
                if (p1_Location_r == 0)
                {
                    player1.BackColor = this.Controls["r_" + p1_Location].BackColor;
                }
                else if (p1_Location_r > 0)
                {
                    player1.BackColor = this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor;
                }

                //////////////////////////////////////////////score 확인
                if (p1_Location_r == 1 && p1_Location == 3 && r1_3.ForeColor == Color.Gold)
                {
                    ScoreDelete();
                    return;
                }
                else if (p1_Location_r == 2 && p1_Location == 2 && r2_2.ForeColor == Color.Gold)
                {
                    ScoreDelete();
                    return;
                }
                else if (p1_Location_r == 3 && p1_Location == 2 && r3_2.ForeColor == Color.Gold)
                {
                    ScoreDelete();
                    return;
                }
                else if (p1_Location_r == 4 && p1_Location == 2 && r4_2.ForeColor == Color.Gold)
                {
                    ScoreDelete();
                    return;
                }

                if (move == 0)
                {
                    move_timer.Stop();
                    LocationEventPlay();
                }
            }
            else if (p2_Select)
            {
                if (p2_Location_r == 0 && p2_Location == 10 && p2_BtSelect == false)
                {
                    go1.Enabled = true;
                    up1.Enabled = true;
                    move_timer.Stop();
                    return;
                }
                else if(p2_Location_r == 0 && p2_Location == 19 && p2_BtSelect == false)
                {
                    go2.Enabled = true;
                    right2.Enabled = true;
                    move_timer.Stop();
                    return;
                }
                else if (p2_Location_r == 0 && p2_Location == 30 && p2_BtSelect == false)
                {
                    go3.Enabled = true;
                    down3.Enabled = true;
                    move_timer.Stop();
                    return;
                }
                else if(p2_Location_r == 0 && p2_Location == 40 && p2_BtSelect == false)
                {
                    go4.Enabled = true;
                    left4.Enabled = true;
                    move_timer.Stop();
                    return;
                }

                p2_BtSelect = false;
                p2_Location += 1;

                if (p2_Location_r == 1 && p2_Location == 10)
                {
                    p2_Location_r = 0;
                    p2_Location = 27;
                    int x = this.Controls["r_" + p2_Location].Location.X;
                    int y = this.Controls["r_" + p2_Location].Location.Y;
                    player2.Location = new Point(x + 60, y + 12);
                }
                else if(p2_Location_r == 2 && p2_Location == 4)
                {
                    p2_Location_r = 1;
                    p2_Location = 6;
                    int x = this.Controls["r" + p2_Location_r + "_" + p2_Location].Location.X;
                    int y = this.Controls["r" + p2_Location_r + "_" + p2_Location].Location.Y;
                    player2.Location = new Point(x + 60, y + 12);
                }
                else if(p2_Location_r == 0 && p2_Location == 46)
                {
                    p2_Location_r = 0;
                    p2_Location = 0;
                    int x = this.Controls["r_" + p2_Location].Location.X;
                    int y = this.Controls["r_" + p2_Location].Location.Y;
                    player2.Location = new Point(x + 60, y + 12);

                    AddPoint(10);   //start 지점을 지나면 10포인트씩 얻음
                    splayer = new SoundPlayer(@"sound\point.wav");
                    splayer.Play();
                }
                else if(p2_Location_r == 4 && p2_Location == 5)
                {
                    p2_Location_r = 3;
                    p2_Location = 4;
                    int x = this.Controls["r" + p2_Location_r + "_" + p2_Location].Location.X;
                    int y = this.Controls["r" + p2_Location_r + "_" + p2_Location].Location.Y;
                    player2.Location = new Point(x + 60, y + 12);
                }
                else if(p2_Location_r == 3 && p2_Location == 10)
                {
                    p2_Location_r = 0;
                    p2_Location = 5;
                    int x = this.Controls["r_" + p2_Location].Location.X;
                    int y = this.Controls["r_" + p2_Location].Location.Y;
                    player2.Location = new Point(x + 60, y + 12);
                }
                else if (p2_Location_r == 0)
                {
                    int x = this.Controls["r_" + p2_Location].Location.X;
                    int y = this.Controls["r_" + p2_Location].Location.Y;
                    player2.Location = new Point(x + 60, y + 12);
                }
                else if(p2_Location_r > 0)
                {
                    int x = this.Controls["r" + p2_Location_r + "_" + p2_Location].Location.X;
                    int y = this.Controls["r" + p2_Location_r + "_" + p2_Location].Location.Y;
                    player2.Location = new Point(x + 60, y + 12);
                }

                // 배경 색 변경
                if (p2_Location_r == 0)
                {
                    player2.BackColor = this.Controls["r_" + p2_Location].BackColor;
                }
                else if (p2_Location_r > 0)
                {
                    player2.BackColor = this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor;
                }

                //////////////////////////////////////////////score 확인
                if (p2_Location_r == 1 && p2_Location == 3 && r1_3.ForeColor == Color.Gold)
                {
                    ScoreDelete();
                    return;
                }
                else if (p2_Location_r == 2 && p2_Location == 2 && r2_2.ForeColor == Color.Gold)
                {
                    ScoreDelete();
                    return;
                }
                else if (p2_Location_r == 3 && p2_Location == 2 && r3_2.ForeColor == Color.Gold)
                {
                    ScoreDelete();
                    return;
                }
                else if (p2_Location_r == 4 && p2_Location == 2 && r4_2.ForeColor == Color.Gold)
                {
                    ScoreDelete();
                    return;
                }

                if (move == 0)
                {
                    move_timer.Stop();
                    LocationEventPlay();
                }
            }
            
        }
        private void go1_Click(object sender, EventArgs e)
        {
            if (p1_Select)
            {
                p1_Location += 1;
                p1_Location_r = 0;
                int x = this.Controls["r_" + p1_Location].Location.X;
                int y = this.Controls["r_" + p1_Location].Location.Y;
                player1.Location = new Point(x + 4, y + 12);

                player1.BackColor = this.Controls["r_" + p1_Location].BackColor;
                p1_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }
            else if(p2_Select)
            {
                p2_Location += 1;
                p2_Location_r = 0;
                int x = this.Controls["r_" + p2_Location].Location.X;
                int y = this.Controls["r_" + p2_Location].Location.Y;
                player2.Location = new Point(x + 60, y + 12);

                player2.BackColor = this.Controls["r_" + p2_Location].BackColor;
                p2_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }

            go1.Enabled = false;
            up1.Enabled = false;
            
        }

        private void up1_Click(object sender, EventArgs e)
        {
            if (p1_Select)
            {
                p1_Location = 1;
                p1_Location_r = 1;
                int x = this.Controls["r1_" + p1_Location].Location.X;
                int y = this.Controls["r1_" + p1_Location].Location.Y;
                player1.Location = new Point(x + 4, y + 12);

                player1.BackColor = this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor;
                p1_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }
            else if (p2_Select)
            {
                p2_Location = 1;
                p2_Location_r = 1;
                int x = this.Controls["r1_" + p2_Location].Location.X;
                int y = this.Controls["r1_" + p2_Location].Location.Y;
                player2.Location = new Point(x + 60, y + 12);

                player2.BackColor = this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor;
                p2_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }

            go1.Enabled = false;
            up1.Enabled = false;
        }
        private void go2_Click(object sender, EventArgs e)
        {
            if (p1_Select)
            {
                p1_Location += 1;
                p1_Location_r = 0;
                int x = this.Controls["r_" + p1_Location].Location.X;
                int y = this.Controls["r_" + p1_Location].Location.Y;
                player1.Location = new Point(x + 4, y + 12);

                player1.BackColor = this.Controls["r_" + p1_Location].BackColor;
                p1_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }
            else if (p2_Select)
            {
                p2_Location += 1;
                p2_Location_r = 0;
                int x = this.Controls["r_" + p2_Location].Location.X;
                int y = this.Controls["r_" + p2_Location].Location.Y;
                player2.Location = new Point(x + 60, y + 12);

                player2.BackColor = this.Controls["r_" + p2_Location].BackColor;
                p2_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }

            go2.Enabled = false;
            right2.Enabled = false;
        }

        private void right2_Click(object sender, EventArgs e)
        {
            if (p1_Select)
            {
                p1_Location = 1;
                p1_Location_r = 2;
                int x = this.Controls["r2_" + p1_Location].Location.X;
                int y = this.Controls["r2_" + p1_Location].Location.Y;
                player1.Location = new Point(x + 4, y + 12);

                player1.BackColor = this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor;
                p1_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }
            else if (p2_Select)
            {
                p2_Location = 1;
                p2_Location_r = 2;
                int x = this.Controls["r2_" + p2_Location].Location.X;
                int y = this.Controls["r2_" + p2_Location].Location.Y;
                player2.Location = new Point(x + 60, y + 12);

                player2.BackColor = this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor;
                p2_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }

            go2.Enabled = false;
            right2.Enabled = false;
        }

        private void go3_Click(object sender, EventArgs e)
        {
            if (p1_Select)
            {
                p1_Location += 1;
                p1_Location_r = 0;
                int x = this.Controls["r_" + p1_Location].Location.X;
                int y = this.Controls["r_" + p1_Location].Location.Y;
                player1.Location = new Point(x + 4, y + 12);

                player1.BackColor = this.Controls["r_" + p1_Location].BackColor;
                p1_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }
            else if (p2_Select)
            {
                p2_Location += 1;
                p2_Location_r = 0;
                int x = this.Controls["r_" + p2_Location].Location.X;
                int y = this.Controls["r_" + p2_Location].Location.Y;
                player2.Location = new Point(x + 60, y + 12);

                player2.BackColor = this.Controls["r_" + p2_Location].BackColor;
                p2_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }

            go3.Enabled = false;
            down3.Enabled = false;
        }

        private void down3_Click(object sender, EventArgs e)
        {
            if (p1_Select)
            {
                p1_Location = 1;
                p1_Location_r = 3;
                int x = this.Controls["r3_" + p1_Location].Location.X;
                int y = this.Controls["r3_" + p1_Location].Location.Y;
                player1.Location = new Point(x + 4, y + 12);

                player1.BackColor = this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor;
                p1_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }
            else if (p2_Select)
            {
                p2_Location = 1;
                p2_Location_r = 3;
                int x = this.Controls["r3_" + p2_Location].Location.X;
                int y = this.Controls["r3_" + p2_Location].Location.Y;
                player2.Location = new Point(x + 60, y + 12);

                player2.BackColor = this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor;
                p2_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }

            go3.Enabled = false;
            down3.Enabled = false;
        }

        private void go4_Click(object sender, EventArgs e)
        {
            if (p1_Select)
            {
                p1_Location += 1;
                p1_Location_r = 0;
                int x = this.Controls["r_" + p1_Location].Location.X;
                int y = this.Controls["r_" + p1_Location].Location.Y;
                player1.Location = new Point(x + 4, y + 12);

                player1.BackColor = this.Controls["r_" + p1_Location].BackColor;
                p1_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }
            else if (p2_Select)
            {
                p2_Location += 1;
                p2_Location_r = 0;
                int x = this.Controls["r_" + p2_Location].Location.X;
                int y = this.Controls["r_" + p2_Location].Location.Y;
                player2.Location = new Point(x + 60, y + 12);

                player2.BackColor = this.Controls["r_" + p2_Location].BackColor;
                p2_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }

            go4.Enabled = false;
            left4.Enabled = false;
        }

        private void left4_Click(object sender, EventArgs e)
        {
            if (p1_Select)
            {
                p1_Location = 1;
                p1_Location_r = 4;
                int x = this.Controls["r4_" + p1_Location].Location.X;
                int y = this.Controls["r4_" + p1_Location].Location.Y;
                player1.Location = new Point(x + 4, y + 12);

                player1.BackColor = this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor;
                p1_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }
            else if (p2_Select)
            {
                p2_Location = 1;
                p2_Location_r = 4;
                int x = this.Controls["r4_" + p2_Location].Location.X;
                int y = this.Controls["r4_" + p2_Location].Location.Y;
                player2.Location = new Point(x + 60, y + 12);

                player2.BackColor = this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor;
                p2_BtSelect = true;

                if (move == 0)
                {
                    LocationEventPlay();
                }
                else
                    move_timer.Start();
            }

            go4.Enabled = false;
            left4.Enabled = false;
        }
    }
}
