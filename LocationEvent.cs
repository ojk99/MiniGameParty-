using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using System.Media;
using WMPLib;

namespace MiniGameParty
{
    public partial class GameBoard : Form
    {
        int p1_Point = 0;
        int p2_Point = 0;

        int p1_Score = 0;
        int p2_Score = 0;

        bool p1_ChanceDice = false;
        bool p2_ChanceDice = false;

        int scoreTurn = 2;

        SoundPlayer splayer;
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();

        public void LocationEventPlay()
        {
            if (p1_Select)
            {
                if (p1_Location_r == 0)
                {
                    
                    // 배경 색 변경
                    player1.BackColor = this.Controls["r_" + p1_Location].BackColor;
                    
                    if (this.Controls["r_" + p1_Location].BackColor.Equals(Color.DeepSkyBlue))
                    {
                        splayer = new SoundPlayer(@"sound\point.wav");
                        splayer.Play();
                        if (this.Controls["r_" + p1_Location].Text == "P")
                        {
                            AddPoint(15);
                            lb_eventmag.Text = "1플레이어\n +15 포인트";
                        }
                        else
                        {
                            AddPoint(3);
                            lb_eventmag.Text = "1플레이어\n +3 포인트";
                        }
                    }
                    else if (this.Controls["r_" + p1_Location].BackColor.Equals(Color.Red))
                    {
                        splayer = new SoundPlayer(@"sound\mamma_mia.wav");
                        splayer.Play();
                        AddPoint(-3);
                        lb_eventmag.Text = "1플레이어\n -3 포인트";
                    }
                    else if (this.Controls["r_" + p1_Location].BackColor.Equals(Color.LawnGreen))
                    {
                        splayer = new SoundPlayer(@"sound\mamma_mia.wav");
                        splayer.Play();
                        RandomEvent();
                    }
                    else if(this.Controls["r_" + p1_Location].BackColor.Equals(Color.LightSlateGray))
                    {
                        SelectMini();
                        return;
                    }
                }
                else
                {
                    player1.BackColor = this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor;
                    
                    if (this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor.Equals(Color.DeepSkyBlue))
                    {
                        splayer = new SoundPlayer(@"sound\point.wav");
                        splayer.Play();
                        if (this.Controls["r" + p1_Location_r + "_" + p1_Location].Text == "P")
                        {
                            AddPoint(15);
                            lb_eventmag.Text = "1플레이어\n +15 포인트";
                        }
                        else
                        {
                            AddPoint(3);
                            lb_eventmag.Text = "1플레이어\n +3 포인트";
                        }
                            
                    }
                    else if (this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor.Equals(Color.Red))
                    {
                        splayer = new SoundPlayer(@"sound\mamma_mia.wav");
                        splayer.Play();
                        AddPoint(-3);
                        lb_eventmag.Text = "1플레이어\n -3 포인트";
                    }
                    else if(this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor.Equals(Color.LawnGreen))
                    {
                        splayer = new SoundPlayer(@"sound\mamma_mia.wav");
                        splayer.Play();
                        RandomEvent();
                    }//블랙 ? 코드 
                    else if(this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor.Equals(Color.Black))
                    {
                        splayer = new SoundPlayer(@"sound\mariofalling.wav");
                        splayer.Play();
                        RandomBlackEvent();
                    }
                    else if(this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor.Equals(Color.LightSlateGray))
                    {
                        SelectMini();
                        return;
                    }
                }
                if(p1_ChanceDice == false)
                {
                    p1_Select = false;
                    p2_Select = true;
                    lb_turn.Text = "Player2";
                    lb_turn.ForeColor = Color.Red;
                    wmp.URL = @"sound\luigil_go.wav";
                }
                else
                {
                    p1_ChanceDice = false;
                    wmp.URL = @"sound\mario_go.wav";
                }
            }
            else if (p2_Select)
            {
                if (p2_Location_r == 0)
                {
                    // 배경 색 변경
                    player2.BackColor = this.Controls["r_" + p2_Location].BackColor;

                    if (this.Controls["r_" + p2_Location].BackColor.Equals(Color.DeepSkyBlue))
                    {
                        splayer = new SoundPlayer(@"sound\point.wav");
                        splayer.Play();
                        if (this.Controls["r_" + p2_Location].Text == "P")
                        {
                            AddPoint(15);
                            lb_eventmag.Text = "2플레이어\n +15 포인트";
                        }
                        else
                        {
                            AddPoint(3);
                            lb_eventmag.Text = "2플레이어\n +3 포인트";
                        }
                    }
                    else if (this.Controls["r_" + p2_Location].BackColor.Equals(Color.Red))
                    {
                        splayer = new SoundPlayer(@"sound\mamma_mia.wav");
                        splayer.Play();
                        AddPoint(-3);
                        lb_eventmag.Text = "2플레이어\n -3 포인트";
                    }
                    else if (this.Controls["r_" + p2_Location].BackColor.Equals(Color.LawnGreen))
                    {
                        splayer = new SoundPlayer(@"sound\mamma_mia.wav");
                        splayer.Play();
                        RandomEvent();
                    }
                    else if(this.Controls["r_" + p2_Location].BackColor.Equals(Color.LightSlateGray))
                    {
                        SelectMini();
                        return;
                    }
                }
                else
                {
                    player2.BackColor = this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor;

                    if (this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor.Equals(Color.DeepSkyBlue))
                    {
                        splayer = new SoundPlayer(@"sound\point.wav");
                        splayer.Play();
                        if (this.Controls["r" + p2_Location_r + "_" + p2_Location].Text == "P")
                        {
                            AddPoint(15);
                            lb_eventmag.Text = "2플레이어\n +15 포인트";
                        }
                        else
                        {
                            AddPoint(3);
                            lb_eventmag.Text = "2플레이어\n +3 포인트";
                        }
                    }
                    else if (this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor.Equals(Color.Red))
                    {
                        splayer = new SoundPlayer(@"sound\mamma_mia.wav");
                        splayer.Play();
                        AddPoint(-3);
                        lb_eventmag.Text = "2플레이어\n -3 포인트";
                    }
                    else if (this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor.Equals(Color.LawnGreen))
                    {
                        splayer = new SoundPlayer(@"sound\mamma_mia.wav");
                        splayer.Play();
                        RandomEvent();
                    }
                    else if(this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor.Equals(Color.Black))
                    {
                        splayer = new SoundPlayer(@"sound\mariofalling.wav");
                        splayer.Play();
                        RandomBlackEvent();
                    }
                    else if(this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor.Equals(Color.LightSlateGray))
                    {
                        SelectMini();
                        return;
                    }
                }
                if(p2_ChanceDice == false)
                {
                    p1_Select = true;
                    p2_Select = false;
                    lb_turn.Text = "Player1";
                    lb_turn.ForeColor = Color.Blue;
                    /////////////////////////////////////// 스코어 턴

                    turn--;
                    lb_lastturn.Text = turn.ToString();

                    if (turn == 0)
                    {
                        MessageBox.Show("게임이 종료되었습니다.");
                        wmpmain.controls.stop();
                        mainSoundTimer.Stop();

                        EndGame eg = new EndGame(p1_Score, p2_Score, p1_Point, p2_Point);
                        eg.Show();
                        return;
                    }
                    else
                    {
                        wmp.URL = @"sound\mario_go.wav";
                    }

                    if (scoreTurn >= 0)
                        scoreTurn--;
                    if(scoreTurn == 0)
                    {
                        Random rand = new Random();
                        ScoreCreate(rand.Next(1, 5));
                    }
                }
                else
                {
                    p2_ChanceDice = false;
                    wmp.URL = @"sound\luigil_go.wav";
                }
            }

            button1.Enabled = true;
            PrintPoint();
        }
        public void RandomBlackEvent()
        {
            Random rand = new Random();
            int r = rand.Next(1, 101);

            if(p1_Select)
            {
                if(r >= 1 && r <= 40)
                {
                    int r2 = rand.Next(5,16);

                    AddPoint(-r2);

                    MessageBox.Show("포인트를 " + r2 + "만큼 잃습니다.");
                    lb_eventmag.Text = "1플레이어\n포인트를 " + r2 + "만큼 잃습니다.";

                    return;
                }
                else if(r >= 41 && r <= 80)
                {
                    int r2 = rand.Next(5, 16);
                    if (p1_Point - r2 < 0)
                    {
                        r2 = p1_Point;
                        p1_Point = 0;
                    }
                    else
                    {
                        p1_Point -= r2;
                    }
                    MessageBox.Show("2플레이어에게 " + r2 + " 포인트를 줍니다.");
                    lb_eventmag.Text = "2플레이어에게 " + r2 + " 포인트를 줍니다.";

                    p2_Point += r2;

                    return;
                }
                else if(r >= 81 && r <= 90)
                {
                    MessageBox.Show("점수 1개를 잃습니다");
                    lb_eventmag.Text = "1플레이어\n점수 1개를 잃습니다";
                    if (p1_Score > 0)
                    {
                        p1_Score -= 1;
                    }

                    return;
                }
                else if(r >= 91 && r <= 100)
                {
                    MessageBox.Show("2플레이어에게 점수 1개를 줍니다");
                    lb_eventmag.Text = "2플레이어에게 점수 1개를 줍니다";
                    if (p1_Score > 0)
                    {
                        p1_Score -= 1;
                        p2_Score += 1;
                    }

                    return;
                }
            }
            else if(p2_Select)
            {
                if (r >= 1 && r <= 40)
                {
                    int r2 = rand.Next(5, 16);

                    AddPoint(-r2);

                    MessageBox.Show("포인트를 " + r2 + "만큼 잃습니다.");
                    lb_eventmag.Text = "2플레이어\n포인트를 " + r2 + "만큼 잃습니다.";
                }
                else if (r >= 41 && r <= 80)
                {
                    int r2 = rand.Next(5, 16);
                    if (p2_Point - r2 < 0)
                    {
                        r2 = p2_Point;
                        p2_Point = 0;
                    }
                    else
                    {
                        p2_Point -= r2;
                    }
                    MessageBox.Show("1플레이어에게 " + r2 + " 포인트를 줍니다.");
                    lb_eventmag.Text = "1플레이어에게 " + r2 + " 포인트를 줍니다.";
                    p1_Point += r2;

                    return;
                }
                else if (r >= 81 && r <= 90)
                {
                    MessageBox.Show("점수 1개를 잃습니다");
                    lb_eventmag.Text = "2플레이어\n점수 1개를 잃습니다";
                    if (p2_Score > 0)
                    {
                        p2_Score -= 1;
                    }

                    return;
                }
                else if (r >= 91 && r <= 100)
                {
                    MessageBox.Show("1플레이어에게 점수 1개를 줍니다");
                    lb_eventmag.Text = "1플레이어에게 점수 1개를 줍니다";
                    if (p2_Score > 0)
                    {
                        p2_Score -= 1;
                        p1_Score += 1;
                    }

                    return;
                }
            }
        }
        public void RandomEvent()
        {
            Random rand = new Random();
            int r = rand.Next(1, 101);

            if(r >= 1 && r <= 10)
            {
                MessageBox.Show("상대방과 위치 바꾸기");
                lb_eventmag.Text = "상대방과 위치 바꾸기";
                int temp1, temp2;

                temp1 = p1_Location;
                temp2 = p1_Location_r;

                p1_Location = p2_Location;
                p1_Location_r = p2_Location_r;

                p2_Location = temp1;
                p2_Location_r = temp2;

                if (p1_Location_r == 0)
                {
                    player1.BackColor = this.Controls["r_" + p1_Location].BackColor;
                    int x = this.Controls["r_" + p1_Location].Location.X;
                    int y = this.Controls["r_" + p1_Location].Location.Y;
                    player1.Location = new Point(x + 4, y + 12);

                }
                else
                {
                    player1.BackColor = this.Controls["r" + p1_Location_r + "_" + p1_Location].BackColor;
                    int x = this.Controls["r" + p1_Location_r + "_" + p1_Location].Location.X;
                    int y = this.Controls["r" + p1_Location_r + "_" + p1_Location].Location.Y;
                    player1.Location = new Point(x + 4, y + 12);
                }

                if (p2_Location_r == 0)
                {
                    player2.BackColor = this.Controls["r_" + p2_Location].BackColor;
                    int x = this.Controls["r_" + p2_Location].Location.X;
                    int y = this.Controls["r_" + p2_Location].Location.Y;
                    player2.Location = new Point(x + 60, y + 12);
                }
                else
                {
                    player2.BackColor = this.Controls["r" + p2_Location_r + "_" + p2_Location].BackColor;
                    int x = this.Controls["r" + p2_Location_r + "_" + p2_Location].Location.X;
                    int y = this.Controls["r" + p2_Location_r + "_" + p2_Location].Location.Y;
                    player2.Location = new Point(x + 60, y + 12);
                }

                return;
            }
            else if (r >= 11 && r<= 20)
            {
                int r2 = rand.Next(1, 11);
                MessageBox.Show("1플레이어 포인트를 " + r2+ " 만큼 잃습니다.");
                lb_eventmag.Text = "1플레이어 포인트를 " + r2+ " 만큼 잃습니다.";
                if (p1_Point - r2 < 0)
                {
                    p1_Point = 0;
                }
                else
                    p1_Point -= r2;
                return;
            }
            else if(r >= 21 && r <= 30)
            {
                int r2 = rand.Next(1, 11);
                MessageBox.Show("2플레이어 포인트를 " + r2 + " 만큼 잃습니다.");
                lb_eventmag.Text = "2플레이어 포인트를 " + r2 + " 만큼 잃습니다.";
                if (p2_Point - r2 < 0)
                {
                    p2_Point = 0;
                }
                else
                    p2_Point -= r2;
                return;
            }

            if(p1_Select)
            {
                //포인트 가져오는 코드
                if(r >=31 && r <= 40)
                {
                    int r2 = rand.Next(1, 11);

                    MessageBox.Show(r2 + " 포인트를 얻었습니다.");
                    lb_eventmag.Text = "1플레이어\n"+r2 + " 포인트를 얻었습니다.";

                    AddPoint(r2);

                    return;
                }
                else if(r >= 41 && r <= 60)
                {
                    int r2 = rand.Next(1,11);
                    if (p2_Point - r2 < 0)
                    {
                        r2 = p2_Point;
                        p2_Point = 0;
                    }
                    else
                    {
                        p2_Point -= r2;
                    }
                    MessageBox.Show("2플레이어의 "+r2+" 포인트를 가져옵니다.");
                    lb_eventmag.Text = "2플레이어의 " + r2 + " 포인트를 가져옵니다.";

                    AddPoint(r2);

                    return;
                }
                else if (r >= 61 && r <= 80)
                {
                    int r2 = rand.Next(1, 11);
                    if (p1_Point - r2 < 0)
                    {
                        r2 = p1_Point;
                        p1_Point = 0;
                    }
                    else
                    {
                        p1_Point -= r2;
                    }
                    MessageBox.Show("2플레이어에게 " + r2 + " 포인트를 줍니다.");
                    lb_eventmag.Text = "2플레이어에게 " + r2 + " 포인트를 줍니다.";

                    p2_Point += r2;

                    return;
                }
                else if(r >= 81 && r <= 95)
                {
                    MessageBox.Show("1플레이어\n주사위를 한번더 굴리세요");
                    lb_eventmag.Text = "1플레이어\n주사위를 한번더 굴리세요";
                    p1_ChanceDice = true;
                }
                else if(r >= 96 && r <= 100)
                {
                    MessageBox.Show("1플레이어\n시작 지점으로 돌아갑니다");
                    lb_eventmag.Text = "1플레이어\n시작 지점으로 돌아갑니다";
                    p1_Location = 0;
                    p1_Location_r = 0;

                    player1.BackColor = this.Controls["r_" + p1_Location].BackColor;
                    int x = this.Controls["r_" + p1_Location].Location.X;
                    int y = this.Controls["r_" + p1_Location].Location.Y;
                    player1.Location = new Point(x + 4, y + 12);

                }
            }
            else if(p2_Select)
            {
                //포인트 가져오는 코드
                if (r >= 31 && r <= 40)
                {
                    int r2 = rand.Next(1, 11);

                    MessageBox.Show(r2 + " 포인트를 얻었습니다.");
                    lb_eventmag.Text = "2플레이어\n" + r2 + " 포인트를 얻었습니다.";

                    AddPoint(r2);

                    return;
                }
                else if (r >= 41 && r <= 60)
                {
                    int r2 = rand.Next(1, 11);
                    if (p1_Point - r2 < 0)
                    {
                        r2 = p1_Point;
                        p1_Point = 0;
                    }
                    else
                    {
                        p1_Point -= r2;
                    }
                    MessageBox.Show("1플레이어의 " + r2 + " 포인트를 가져옵니다.");
                    lb_eventmag.Text = "1플레이어의 " + r2 + " 포인트를 가져옵니다.";

                    AddPoint(r2);

                    return;
                }
                else if (r >= 61 && r <= 80)
                {
                    int r2 = rand.Next(1, 11);
                    if (p2_Point - r2 < 0)
                    {
                        r2 = p2_Point;
                        p2_Point = 0;
                    }
                    else
                    {
                        p2_Point -= r2;
                    }
                    MessageBox.Show("1플레이어에게 " + r2 + " 포인트를 줍니다.");
                    lb_eventmag.Text = "1플레이어에게 " + r2 + " 포인트를 줍니다.";

                    p1_Point += r2;

                    return;
                }
                else if (r >= 81 && r <= 95)
                {
                    MessageBox.Show("2플레이어\n주사위를 한번더 굴리세요");
                    lb_eventmag.Text = "2플레이어\n주사위를 한번더 굴리세요";

                    p2_ChanceDice = true;
                }
                else if(r >= 96 && r <= 100)
                {
                    MessageBox.Show("2플레이어\n시작 지점으로 돌아갑니다");
                    lb_eventmag.Text = "2플레이어\n시작 지점으로 돌아갑니다";

                    p2_Location = 0;
                    p2_Location_r = 0;

                    player2.BackColor = this.Controls["r_" + p2_Location].BackColor;
                    int x = this.Controls["r_" + p2_Location].Location.X;
                    int y = this.Controls["r_" + p2_Location].Location.Y;
                    player2.Location = new Point(x + 60, y + 12);
                }
            }
        }
        public void AddPoint(int point)
        {
            if (p1_Select)
            {
                if(p1_Point + point < 0)
                    p1_Point = 0;
                else
                    p1_Point += point;
            }
            else if( p2_Select)
            {
                if(p2_Point + point < 0)
                    p2_Point = 0;
                else
                    p2_Point += point;
            }
        }

        public void PrintPoint()
        {
            lb_p1_point.Text = p1_Point.ToString();
            lb_p2_point.Text = p2_Point.ToString();
            lb_p1_score.Text = p1_Score.ToString();
            lb_p2_score.Text = p2_Score.ToString();
        }
    }
}
