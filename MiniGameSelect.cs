using MiniGameParty2;
using MiniParty4;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MiniGameParty2.CardMatchingGame;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MiniGameParty
{
    public partial class GameBoard : Form
    {
        CardMatchingGame cmg;
        MineSweeper ms;
        NumericOrder no;
        ButtonGame bg;
        MouseMoveGame mmg;
        RhythmGame rg;
        StarShipGame ssg;


        private int randGame = 0;
        public void SelectMini()
        {
            Random random = new Random();
            randGame = random.Next(0, 7);

            if(randGame == 0)
            {
                if(p1_Select)
                {
                    cmg = new CardMatchingGame(false);
                    cmg.DataPassEvent += new CardMatchingGame.DataPassEventHandler(DataRecevieEvent);
                    cmg.Show();
                }
                else if (p2_Select)
                {
                    cmg = new CardMatchingGame(true);
                    cmg.DataPassEvent += new CardMatchingGame.DataPassEventHandler(DataRecevieEvent);
                    cmg.Show();
                }
            }
            else if(randGame == 1)
            {
                if (p1_Select)
                {
                    MessageBox.Show("지뢰찾기 게임 입니다\n1플레이어 먼저 시작 합니다.");
                    ms = new MineSweeper();
                    ms.DataPassEvent += new MineSweeper.DataPassEventHandler(Mine_DataRecevieEvent);
                    ms.Show();

                }
                else if (p2_Select)
                {
                    MessageBox.Show("지뢰찾기 게임 입니다\n2플레이어 먼저 시작 합니다.");
                    ms = new MineSweeper();
                    ms.DataPassEvent += new MineSweeper.DataPassEventHandler(Mine_DataRecevieEvent);
                    ms.Show();
                }
            }
            else if(randGame == 2)
            {
                if (p1_Select)
                {
                    MessageBox.Show("순서대로 숫자 맞추기 게임 입니다\n1플레이어 먼저 시작 합니다.");
                    no = new NumericOrder();
                    no.DataPassEvent += new NumericOrder.DataPassEventHandler(Numeric_DataRecevieEvent);
                    no.Show();

                }
                else if (p2_Select)
                {
                    MessageBox.Show("순서대로 숫자 맞추기 게임 입니다\n2플레이어 먼저 시작 합니다.");
                    no = new NumericOrder();
                    no.DataPassEvent += new NumericOrder.DataPassEventHandler(Numeric_DataRecevieEvent);
                    no.Show();
                }
            }
            else if (randGame ==3)
            {
                if (p1_Select)
                {
                    MessageBox.Show("버튼 누르기 게임 입니다\n1플레이어 먼저 시작 합니다.");
                    bg = new ButtonGame();
                    bg.DataPassEvent += new ButtonGame.DataPassEventHandler(One_DataRecevieEvent);
                    bg.Show();


                }
                else if (p2_Select)
                {
                    MessageBox.Show("버튼 누르기 게임 입니다\n2플레이어 먼저 시작 합니다.");
                    bg = new ButtonGame();
                    bg.DataPassEvent += new ButtonGame.DataPassEventHandler(One_DataRecevieEvent);
                    bg.Show();
                }
            }
            else if (randGame == 4)
            {
                if (p1_Select)
                {
                    MessageBox.Show("마우스 피하기 게임 입니다\n1플레이어 먼저 시작 합니다.");
                    mmg = new MouseMoveGame();
                    mmg.DataPassEvent += new MouseMoveGame.DataPassEventHandler(One_DataRecevieEvent);
                    mmg.Show();
                }
                else if (p2_Select)
                {
                    MessageBox.Show("마우스 피하기 게임 입니다\n2플레이어 먼저 시작 합니다.");
                    mmg = new MouseMoveGame();
                    mmg.DataPassEvent += new MouseMoveGame.DataPassEventHandler(One_DataRecevieEvent);
                    mmg.Show();
                }
            }
            else if(randGame == 5)
            {
                mainSoundTimer.Stop();
                wmpmain.controls.stop();
                if (p1_Select)
                {
                    MessageBox.Show("리듬 게임 입니다\n방향 조작키(←↑↓→)를 사용하여\n조작할 수 있습니다\n1플레이어 먼저 시작 합니다.");
                    rg = new RhythmGame();
                    rg.DataPassEvent += new RhythmGame.DataPassEventHandler(One_DataRecevieEvent);
                    rg.Show();
                }
                else if (p2_Select)
                {
                    MessageBox.Show("리듬 게임 입니다\n방향 조작키(←↑↓→)를 사용하여\n조작할 수 있습니다\n2플레이어 먼저 시작 합니다.");
                    rg = new RhythmGame();
                    rg.DataPassEvent += new RhythmGame.DataPassEventHandler(One_DataRecevieEvent);
                    rg.Show();

                }
            }
            else if(randGame == 6) 
            {
                if (p1_Select)
                {
                    MessageBox.Show("StarShip\n조작키(←↑↓→), 스페이스바 탄 발사\n1플레이어 먼저 시작 합니다.");
                    ssg = new StarShipGame();
                    ssg.DataPassEvent += new StarShipGame.DataPassEventHandler(One_DataRecevieEvent);
                    ssg.Show();
                }
                else if (p2_Select)
                {
                    MessageBox.Show("StarShip\n조작키(←↑↓→), 스페이스바 탄 발사\n2플레이어 먼저 시작 합니다.");
                    ssg = new StarShipGame();
                    ssg.DataPassEvent += new StarShipGame.DataPassEventHandler(One_DataRecevieEvent);
                    ssg.Show();
                }
            }
        }

        int checkEvent = 0;

        int p1OnePoint = 0;
        int p2OnePoint = 0;

        private void One_DataRecevieEvent(int point)
        {
            if(randGame == 3)
            {
                if (p1_Select)
                {
                    if (checkEvent == 0)
                    {
                        checkEvent += 1;
                        p1OnePoint = point;
                        MessageBox.Show("2플레이어 차례");

                        bg = new ButtonGame();
                        bg.DataPassEvent += new ButtonGame.DataPassEventHandler(One_DataRecevieEvent);
                        bg.Show();
                        return;
                    }
                    else if (checkEvent == 1)
                    {
                        p2OnePoint = point;
                        checkEvent = 0;
                    }
                }
                else if (p2_Select)
                {
                    if (checkEvent == 0)
                    {
                        checkEvent += 1;
                        p2OnePoint = point;
                        MessageBox.Show("1플레이어 차례");

                        bg = new ButtonGame();
                        bg.DataPassEvent += new ButtonGame.DataPassEventHandler(One_DataRecevieEvent);
                        bg.Show();
                        return;
                    }
                    else if (checkEvent == 1)
                    {
                        p1OnePoint = point;
                        checkEvent = 0;
                    }
                }

                if (p1OnePoint > p2OnePoint)
                {
                    MessageBox.Show("1플레이어 우승");
                    p1_Point += 10;
                    lb_eventmag.Text = "1플레이어\n미니게임 우승 +10 포인트";
                }
                else if (p2OnePoint > p1OnePoint)
                {
                    MessageBox.Show("2플레이어 우승");
                    p2_Point += 10;
                    lb_eventmag.Text = "2플레이어\n미니게임 우승 +10 포인트";
                }
                else
                {
                    MessageBox.Show("무승부");
                    p1_Point += 3;
                    p2_Point += 3;
                    lb_eventmag.Text = "미니게임 무승부 각각 +3 포인트";
                }
                p1OnePoint = 0;
                p2OnePoint = 0;

                ChangeTurn();
            }
            else if(randGame ==4)
            {
                if (p1_Select)
                {
                    if (checkEvent == 0)
                    {
                        checkEvent += 1;
                        p1OnePoint = point;
                        MessageBox.Show("2플레이어 차례");

                        mmg = new MouseMoveGame();
                        mmg.DataPassEvent += new MouseMoveGame.DataPassEventHandler(One_DataRecevieEvent);
                        mmg.Show();
                        return;
                    }
                    else if (checkEvent == 1)
                    {
                        p2OnePoint = point;
                        checkEvent = 0;
                    }
                }
                else if (p2_Select)
                {
                    if (checkEvent == 0)
                    {
                        checkEvent += 1;
                        p2OnePoint = point;
                        MessageBox.Show("1플레이어 차례");

                        mmg = new MouseMoveGame();
                        mmg.DataPassEvent += new MouseMoveGame.DataPassEventHandler(One_DataRecevieEvent);
                        mmg.Show();
                        return;
                    }
                    else if (checkEvent == 1)
                    {
                        p1OnePoint = point;
                        checkEvent = 0;
                    }
                }

                if (p1OnePoint > p2OnePoint)
                {
                    MessageBox.Show("1플레이어 우승");
                    p1_Point += 10;
                    lb_eventmag.Text = "1플레이어\n미니게임 우승 +10 포인트";
                }
                else if (p2OnePoint > p1OnePoint)
                {
                    MessageBox.Show("2플레이어 우승");
                    p2_Point += 10;
                    lb_eventmag.Text = "2플레이어\n미니게임 우승 +10 포인트";
                }
                else
                {
                    MessageBox.Show("무승부");
                    p1_Point += 3;
                    p2_Point += 3;
                    lb_eventmag.Text = "미니게임 무승부 각각 +3 포인트";
                }
                p1OnePoint = 0;
                p2OnePoint = 0;

                ChangeTurn();
            }
            else if(randGame == 5)
            {
                if (p1_Select)
                {
                    if (checkEvent == 0)
                    {
                        checkEvent += 1;
                        p1OnePoint = point;
                        MessageBox.Show("2플레이어 차례");

                        rg = new RhythmGame();
                        rg.DataPassEvent += new RhythmGame.DataPassEventHandler(One_DataRecevieEvent);
                        rg.Show();
                        return;
                    }
                    else if (checkEvent == 1)
                    {
                        p2OnePoint = point;
                        checkEvent = 0;
                    }
                }
                else if (p2_Select)
                {
                    if (checkEvent == 0)
                    {
                        checkEvent += 1;
                        p2OnePoint = point;
                        MessageBox.Show("1플레이어 차례");

                        rg = new RhythmGame();
                        rg.DataPassEvent += new RhythmGame.DataPassEventHandler(One_DataRecevieEvent);
                        rg.Show();
                        return;
                    }
                    else if (checkEvent == 1)
                    {
                        p1OnePoint = point;
                        checkEvent = 0;
                    }
                }

                time = 0;
                mainSoundTimer.Start();
                wmpmain.controls.play();

                if (p1OnePoint > p2OnePoint)
                {
                    MessageBox.Show("1플레이어 우승");
                    p1_Point += 10;
                    lb_eventmag.Text = "1플레이어\n미니게임 우승 +10 포인트";
                }
                else if (p2OnePoint > p1OnePoint)
                {
                    MessageBox.Show("2플레이어 우승");
                    p2_Point += 10;
                    lb_eventmag.Text = "2플레이어\n미니게임 우승 +10 포인트";
                }
                else
                {
                    MessageBox.Show("무승부");
                    p1_Point += 3;
                    p2_Point += 3;
                    lb_eventmag.Text = "미니게임 무승부 각각 +3 포인트";
                }
                p1OnePoint = 0;
                p2OnePoint = 0;

                ChangeTurn();
            }
            else if(randGame == 6)
            {
                if (p1_Select)
                {
                    if (checkEvent == 0)
                    {
                        checkEvent += 1;
                        p1OnePoint = point;
                        MessageBox.Show("2플레이어 차례");

                        ssg = new StarShipGame();
                        ssg.DataPassEvent += new StarShipGame.DataPassEventHandler(One_DataRecevieEvent);
                        ssg.Show();
                        return;
                    }
                    else if (checkEvent == 1)
                    {
                        p2OnePoint = point;
                        checkEvent = 0;
                    }
                }
                else if (p2_Select)
                {
                    if (checkEvent == 0)
                    {
                        checkEvent += 1;
                        p2OnePoint = point;
                        MessageBox.Show("1플레이어 차례");

                        ssg = new StarShipGame();
                        ssg.DataPassEvent += new StarShipGame.DataPassEventHandler(One_DataRecevieEvent);
                        ssg.Show();
                        return;
                    }
                    else if (checkEvent == 1)
                    {
                        p1OnePoint = point;
                        checkEvent = 0;
                    }
                }
                
                if (p1OnePoint > p2OnePoint)
                {
                    MessageBox.Show("1플레이어 우승");
                    p1_Point += 10;
                    lb_eventmag.Text = "1플레이어\n미니게임 우승 +10 포인트";
                }
                else if (p2OnePoint > p1OnePoint)
                {
                    MessageBox.Show("2플레이어 우승");
                    p2_Point += 10;
                    lb_eventmag.Text = "2플레이어\n미니게임 우승 +10 포인트";
                }
                else
                {
                    MessageBox.Show("무승부");
                    p1_Point += 3;
                    p2_Point += 3;
                    lb_eventmag.Text = "미니게임 무승부 각각 +3 포인트";
                }
                p1OnePoint = 0;
                p2OnePoint = 0;

                ChangeTurn();
            }
        }

        double p1NumTime = 0;
        double p2NumTime = 0;
        private void Numeric_DataRecevieEvent(double time)
        {
            if (p1_Select)
            {
                if (checkEvent == 0)
                {
                    checkEvent += 1;
                    p1NumTime = time;
                    MessageBox.Show("2플레이어 차례");

                    no = new NumericOrder();
                    no.DataPassEvent += new NumericOrder.DataPassEventHandler(Numeric_DataRecevieEvent);
                    no.Show();
                    return;
                }
                else if (checkEvent == 1)
                {
                    p2NumTime = time;
                    checkEvent = 0;
                }
            }
            else if (p2_Select)
            {
                if (checkEvent == 0)
                {
                    checkEvent += 1;
                    p2NumTime = time;
                    MessageBox.Show("1플레이어 차례");

                    no = new NumericOrder();
                    no.DataPassEvent += new NumericOrder.DataPassEventHandler(Numeric_DataRecevieEvent);
                    no.Show();
                    return;
                }
                else if (checkEvent == 1)
                {
                    p1NumTime = time;
                    checkEvent = 0;
                }
            }

            if (p1NumTime < p2NumTime)
            {
                MessageBox.Show("1플레이어 우승");
                p1_Point += 10;
                lb_eventmag.Text = "1플레이어\n미니게임 우승 +10 포인트";
            }
            else if (p2NumTime < p1NumTime)
            {
                MessageBox.Show("2플레이어 우승");
                p2_Point += 10;
                lb_eventmag.Text = "2플레이어\n미니게임 우승 +10 포인트";
            }
            else
            {
                MessageBox.Show("무승부");
                p1_Point += 3;
                p2_Point += 3;
                lb_eventmag.Text = "미니게임 무승부 각각 +3 포인트";
            }

            ChangeTurn();
        }

        int p1minePoint = 0;
        int p2minePoint = 0;
        bool p1mineTimeCheck = false;
        bool p2mineTimeCheck = false;

        private void Mine_DataRecevieEvent(int point, bool time)//false 실패
        {
            if(p1_Select)
            {
                if(checkEvent == 0)
                {
                    checkEvent += 1;
                    p1minePoint = point;
                    p1mineTimeCheck = time;

                    MessageBox.Show("2플레이어 차례");

                    ms = new MineSweeper();
                    ms.DataPassEvent += new MineSweeper.DataPassEventHandler(Mine_DataRecevieEvent);
                    ms.Show();
                    return;
                }
                else if(checkEvent == 1)
                {
                    p2minePoint = point;
                    p2mineTimeCheck = time;
                    checkEvent = 0;
                }
            }
            else if (p2_Select)
            {
                if (checkEvent == 0)
                {
                    checkEvent += 1;
                    p2minePoint = point;
                    p2mineTimeCheck = time;

                    MessageBox.Show("1플레이어 차례");

                    ms = new MineSweeper();
                    ms.DataPassEvent += new MineSweeper.DataPassEventHandler(Mine_DataRecevieEvent);
                    ms.Show();
                    return;
                }
                else if (checkEvent == 1)
                {
                    p1minePoint = point;
                    p1mineTimeCheck = time;
                    checkEvent = 0;
                }
            }

            if(p1mineTimeCheck && p2mineTimeCheck)
            {
                if(p1minePoint > p2minePoint)   //시간
                {
                    MessageBox.Show("2플레이어 우승");
                    p2_Point += 10;
                    lb_eventmag.Text = "2플레이어\n미니게임 우승 +10 포인트";
                }
                else if (p1minePoint < p2minePoint)   //시간
                {
                    MessageBox.Show("1플레이어 우승");
                    p1_Point += 10;
                    lb_eventmag.Text = "1플레이어\n미니게임 우승 +10 포인트";
                }
                else
                {
                    MessageBox.Show("무승부");
                    p1_Point += 3;
                    p2_Point += 3;
                    lb_eventmag.Text = "미니게임 무승부 각각 +3 포인트";
                }
            }
            else if(p1mineTimeCheck)
            {
                MessageBox.Show("1플레이어 우승");
                p1_Point += 10;
                lb_eventmag.Text = "1플레이어\n미니게임 우승 +10 포인트";
            }
            else if(p2mineTimeCheck)
            {
                MessageBox.Show("2플레이어 우승");
                p2_Point += 10;
                lb_eventmag.Text = "2플레이어\n미니게임 우승 +10 포인트";
            }
            else
            {
                if (p1minePoint < p2minePoint)   //시간
                {
                    MessageBox.Show("2플레이어 우승");
                    p2_Point += 10;
                    lb_eventmag.Text = "2플레이어\n미니게임 우승 +10 포인트";
                }
                else if (p1minePoint > p2minePoint)   //시간
                {
                    MessageBox.Show("1플레이어 우승");
                    p1_Point += 10;
                    lb_eventmag.Text = "1플레이어\n미니게임 우승 +10 포인트";
                }
                else
                {
                    MessageBox.Show("무승부");
                    p1_Point += 3;
                    p2_Point += 3;
                    lb_eventmag.Text = "미니게임 무승부 각각 +3 포인트";
                }
            }

            ChangeTurn();
        }

        private void DataRecevieEvent(int p1, int p2, bool exit)
        {
            if(exit)
            {
                MessageBox.Show("게임이 강제종료 되었습니다\n무승부로 처리하겠습니다.");
            }

            if (p1 > p2)
            {
                p1_Point += 10;
                lb_eventmag.Text = "1플레이어\n미니게임 우승 +10 포인트";
            }
            else if (p2 > p1)
            {
                p2_Point += 10;
                lb_eventmag.Text = "2플레이어\n미니게임 우승 +10 포인트";
            }
            else
            {
                p1_Point += 3;
                p2_Point += 3;
                lb_eventmag.Text = "미니게임 무승부 각각 +3 포인트";
            }

            ChangeTurn();
        }

        public void ChangeTurn()
        {
            if (p1_Select)
            {
                if (p1_ChanceDice == false)
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
                if (p2_ChanceDice == false)
                {
                    p1_Select = true;
                    p2_Select = false;
                    lb_turn.Text = "Player1";
                    lb_turn.ForeColor = Color.Blue;
                    /////////////////////////////////////////////////// 스코어 턴

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
                    if (scoreTurn == 0)
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
    }
}
