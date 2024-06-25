using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGameParty2
{
    public partial class CardMatchingGame : Form
    {
        List<int> numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19, 20, 20 };
        string first;
        string second;
        int tries;
        List<PictureBox> pictures = new List<PictureBox>();
        PictureBox picA;
        PictureBox picB;
        int totalTime = 180; //시간
        int CountDownTime;
        bool gameOver = false;
        int scores = 0;

        //추가
        bool player = false;//false player1, true player2

        public int player1 = 0;
        public int player2 = 0;

        public delegate void DataPassEventHandler(int p1, int p2, bool exit = false);
        public event DataPassEventHandler DataPassEvent;

        public CardMatchingGame(bool player)
        {
            InitializeComponent();
            this.player = player;
            LoadPictures();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BrtnRestart_Click(object sender, EventArgs e)
        {
            RestratGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CountDownTime--;
            lblTimeLeft.Text = "Time Left: " + CountDownTime;

            if (CountDownTime == 0)
            {
                GameOver(true);
                foreach (PictureBox x in pictures)
                {
                    if (x.Tag != null)
                    {
                        x.Image = Image.FromFile("picpic/" + (string)x.Tag + ".jpg");
                    }
                }
            }

        }
        private void LoadPictures()
        {
            int leftPos = 20;
            int toptPos = 20;
            int rows = 0;

            for (int i = 0; i < 40; i++)
            {
                PictureBox newPic = new PictureBox();
                newPic.Height = 110;
                newPic.Width = 110;
                newPic.BackColor = Color.LightGray;
                newPic.SizeMode = PictureBoxSizeMode.StretchImage;
                newPic.Click += NewPic_Click;
                pictures.Add(newPic);

                if (rows < 8)
                {
                    rows++;
                    newPic.Left = leftPos;
                    newPic.Top = toptPos;
                    this.Controls.Add(newPic);
                    leftPos = leftPos + 120;
                }
                if (rows == 8)
                {
                    leftPos = 20;
                    toptPos += 120;
                    rows = 0;

                }
            }
            RestratGame();
        }

        private void NewPic_Click(object? sender, EventArgs e)
        {
            if (gameOver)
            {
                return;
            }
            if (first == null)
            {
                picA = sender as PictureBox;
                if (picA.Tag != null && picA.Image == null)
                {
                    picA.Image = Image.FromFile("picpic/" + (string)picA.Tag + ".jpg");
                    first = (string)picA.Tag;
                }
            }
            else if (second == null)
            {
                picB = sender as PictureBox;
                if (picB.Tag != null && picB.Image == null)
                {
                    picB.Image = Image.FromFile("picpic/" + (string)picB.Tag + ".jpg");
                    second = (string)picB.Tag;
                }

                CheckPictures(picA, picB);
            }
            else
            {
                CheckPictures(picA, picB);
            }
        }

        private void RestratGame()
        {
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            numbers = randomList;
            tries = 0;
            scores = 0;
            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Image = null;
                pictures[i].Tag = numbers[i].ToString();
                int tries = 0;
                //lblStatus.Text = "실패 횟수: " + tries + "times.";
                lblTimeLeft.Text = "Time Left: " + totalTime;
                gameOver = false;


            }
            if (player == false)
            {
                MessageBox.Show("카드 맞추기 게임 입니다\nPlayer1 먼저 시작합니다");
                plturn.Text = "Player1의 차례";
                plturn.ForeColor = Color.Blue;
            }
            else
            {
                MessageBox.Show("카드 맞추기 게임 입니다\nPlayer2 먼저 시작합니다");
                plturn.Text = "Player2의 차례";
                plturn.ForeColor = Color.Red;
            }
            timer1.Start();
            CountDownTime = totalTime;
        }
        private void CheckPictures(PictureBox A, PictureBox B)
        {
            int last = scores - tries * 3;
            if (first == second)
            {
                A.Tag = null;
                B.Tag = null;
                A.Enabled = false;
                B.Enabled = false;
                //scores += 100;
                //label1.Text = "Score : " + scores.ToString();
                if (player == false) // player 1
                {
                    player1 += 100;
                    p1_score.Text = player1.ToString();
                }
                else
                {
                    player2 += 100;
                    p2_score.Text = player2.ToString();
                }
            }
            else
            {
                timer2.Start();
                tries++;
                //lblStatus.Text = "실패 횟수" + tries + " times";
                for (int i = 0; i < 40; i++)
                {
                    pictures[i].Enabled = false;
                }
            }
            first = null;
            second = null;

            /*foreach(PictureBox pics in pictures.ToList())
            {
                if(pics.Tag != null)
                {
                    pics.Image = null;
                }
            }*/
            if (pictures.All(o => o.Tag == pictures[0].Tag))
            {
                GameOver();
            }
        }
        private void GameOver(bool time = false)
        {
            timer1.Stop();
            if (time)
            {
                MessageBox.Show("시간초과");
            }

            if (player1 > player2)
            {
                MessageBox.Show("player1 우승");
            }
            else if (player2 > player1)
            {
                MessageBox.Show("player2 우승");
            }
            else
            {
                MessageBox.Show("무승부");
            }

            
            gameOver = true;

            DataPassEvent(player1, player2);

            this.Close();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox pics in pictures.ToList())
            {
                if (pics.Tag != null)
                {
                    pics.Image = null;
                }
            }
            for (int i = 0; i < 40; i++)
            {
                if(pictures[i] != null)
                    pictures[i].Enabled = true;
            }

            if (player == false)
            {
                player = true;
                plturn.Text = "Player2의 차례";
                plturn.ForeColor = Color.Red;
            }
            else
            {
                player = false;
                plturn.Text = "Player1의 차례";
                plturn.ForeColor = Color.Blue;
            }
            timer2.Stop();
        }

        private void CardMatchingGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!gameOver)
            {
                DataPassEvent(0, 0, true);
            }
            
        }
    }
}
