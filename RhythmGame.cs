using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using System.Media;
using System.Numerics;
//컨트롤 부터
namespace MiniParty4
{
    public partial class RhythmGame : Form
    {
        private List<PictureBox> objects1;
        private List<PictureBox> objects2;
        private List<PictureBox> objects3;
        private List<PictureBox> objects4;
        private System.Windows.Forms.Timer timer;
        private Random random;
        int score;
        private int lineSpacing;
        int per;
        int great;
        int nice;
        int fail;
        int Combo = 0;
        int count;
        int countDown = 60;
        private SoundPlayer soundPlayer;
        public delegate void DataPassEventHandler(int score);
        public event DataPassEventHandler DataPassEvent;
        bool gameSet = false;

        public RhythmGame()
        {
            InitializeComponent();
            objects1 = new List<PictureBox>();
            objects2 = new List<PictureBox>();
            objects3 = new List<PictureBox>();
            objects4 = new List<PictureBox>();
            random = new Random();



            // 타이머 초기화
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1초마다 객체 생성
            timer.Tick += NoteTimer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            playSimpleSound();

            timer7.Start();
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();
            timer6.Start();
            PixLupy.Load(@"bin\score0.jpg");
            PixLupy.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void NoteTimer(object sender, EventArgs e)
        {
            Random rnd = new Random();
            timer1.Interval = rnd.Next(1300, 3000);
            int startX = 50; // 라인1 시작 좌표1
            PictureBox newObject1 = new PictureBox();
            newObject1.Size = new Size(50, 50); // 객체 크기 설정
            //newObject1.BackColor = Color.LightGray;// 객체 색상 설정
            newObject1.Location = new Point(startX, -newObject1.Height); // 시작 위치 설정
            newObject1.SizeMode = PictureBoxSizeMode.StretchImage;
            newObject1.Image = Image.FromFile(@"bin\star\Star.jpg");
            objects1.Add(newObject1);
            Controls.Add(newObject1); // 객체를 폼에 추가
            count++;
            // 객체를 아래로 이동시키는 타이머 시작
            System.Windows.Forms.Timer objectTimer1 = new System.Windows.Forms.Timer();
            objectTimer1.Interval = 10; // 객체 이동 속도 설정
            objectTimer1.Tick += (object sender, EventArgs e) =>
            {
                newObject1.Top += 8; // 이동 속도 설정

                // 객체가 폼의 아래쪽을 벗어나면 타이머를 중지하고 객체를 제거함
                if (newObject1.Bounds.IntersectsWith(pictureBox5.Bounds) && objects1.Contains(newObject1))
                {
                    objectTimer1.Stop();
                    Controls.Remove(newObject1);
                    objects1.Remove(newObject1);
                    Combo = 0;
                    score -= 100;
                    scoreLabel.Text = scoreLabel.Text = $"Score: {score}";
                    lbCombo.Text = "Combo : " + Combo.ToString();

                }
            };
            objectTimer1.Start();

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                List<PictureBox> notesToRemove1 = new List<PictureBox>(); // 제거할 노트를 저장할 리스트 생성

                foreach (PictureBox obj1 in objects1)
                {
                    float distance = pictureBox1.Location.Y - obj1.Location.Y;

                    if (distance <= 10)
                    {
                        score += 100;
                        notesToRemove1.Add(obj1);
                        per += 1;
                        lbPer.Text = "Perfect : " + per.ToString(); ;// 맞춘 노트를 리스트에 추가
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= 50)
                    {
                        score += 50;
                        notesToRemove1.Add(obj1);
                        great += 1;
                        lbGreat.Text = "Great : " + great.ToString();
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= 100)
                    {
                        score += 20;
                        notesToRemove1.Add(obj1);
                        nice += 1;
                        lbNice.Text = "Nice : " + nice.ToString();
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= 150)
                    {
                        score -= 10;
                        notesToRemove1.Add(obj1);
                        fail += 1;
                        lbFail.Text = "Fail : " + fail.ToString();
                        Combo = 0;
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= -30)
                    {
                        Combo = 0;
                        score -= 30;
                        scoreLabel.Text = "Score: " + score.ToString();
                        lbCombo.Text = "Combo: " + Combo.ToString();
                    }
                    else
                    {

                    }

                }

                // 맞춘 노트를 제거
                foreach (PictureBox obj1 in notesToRemove1)
                {
                    Controls.Remove(obj1);
                    objects1.Remove(obj1); // objects 리스트에서도 제거
                }

                // 점수 업데이트
                scoreLabel.Text = $"Score: {score}";
            }
            if (e.KeyCode == Keys.Up)
            {
                List<PictureBox> notesToRemove2 = new List<PictureBox>(); // 제거할 노트를 저장할 리스트 생성

                foreach (PictureBox obj2 in objects2)
                {
                    float distance = pictureBox1.Location.Y - obj2.Location.Y;

                    if (distance <= 10)
                    {
                        score += 100;
                        notesToRemove2.Add(obj2);
                        per += 1;
                        lbPer.Text = "Perfect : " + per.ToString(); ;// 맞춘 노트를 리스트에 추가
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= 50)
                    {
                        score += 50;
                        notesToRemove2.Add(obj2);
                        great += 1;
                        lbGreat.Text = "Great : " + great.ToString();
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= 100)
                    {
                        score += 20;
                        notesToRemove2.Add(obj2);
                        nice += 1;
                        lbNice.Text = "Nice : " + nice.ToString();
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= 150)
                    {
                        score -= 10;
                        notesToRemove2.Add(obj2);
                        fail += 1;
                        lbFail.Text = "Fail : " + fail.ToString();
                        Combo = 0;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= -30)
                    {
                        Combo = 0;
                        score -= 30;
                        scoreLabel.Text = "Score: " + score.ToString();
                        lbCombo.Text = "Combo: " + Combo.ToString();
                    }
                    else
                    {

                    }
                }

                // 맞춘 노트를 제거
                foreach (PictureBox obj2 in notesToRemove2)
                {
                    Controls.Remove(obj2);
                    objects2.Remove(obj2); // objects 리스트에서도 제거
                }

                // 점수 업데이트
                scoreLabel.Text = $"Score: {score}";
            }
            if (e.KeyCode == Keys.Down)
            {
                List<PictureBox> notesToRemove3 = new List<PictureBox>(); // 제거할 노트를 저장할 리스트 생성

                foreach (PictureBox obj3 in objects3)
                {
                    float distance = pictureBox1.Location.Y - obj3.Location.Y;

                    if (distance <= 10)
                    {
                        score += 100;
                        notesToRemove3.Add(obj3);
                        per += 1;
                        lbPer.Text = "Perfect : " + per.ToString(); ;// 맞춘 노트를 리스트에 추가
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= 50)
                    {
                        score += 50;
                        notesToRemove3.Add(obj3);
                        great += 1;
                        lbGreat.Text = "Great : " + great.ToString();
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= 100)
                    {
                        score += 20;
                        notesToRemove3.Add(obj3);
                        nice += 1;
                        lbNice.Text = "Nice : " + nice.ToString();
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= 150)
                    {
                        score -= 10;
                        notesToRemove3.Add(obj3);
                        fail += 1;
                        lbFail.Text = "Fail : " + fail.ToString();
                        Combo = 0;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= -30)
                    {

                        scoreLabel.Text = "Score: " + score.ToString();
                        lbCombo.Text = "Combo: " + Combo.ToString();
                    }
                    else
                    {

                    }

                }

                // 맞춘 노트를 제거
                foreach (PictureBox obj3 in notesToRemove3)
                {
                    Controls.Remove(obj3);
                    objects3.Remove(obj3);
                    // objects 리스트에서도 제거
                }

                // 점수 업데이트
                scoreLabel.Text = $"Score: {score}";
            }
            if (e.KeyCode == Keys.Right)
            {
                List<PictureBox> notesToRemove4 = new List<PictureBox>(); // 제거할 노트를 저장할 리스트 생성

                foreach (PictureBox obj4 in objects4)
                {
                    float distance = pictureBox1.Location.Y - obj4.Location.Y;

                    if (distance <= 10)
                    {
                        score += 100;
                        notesToRemove4.Add(obj4);
                        per += 1;
                        lbPer.Text = "Perfect : " + per.ToString();
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();// 맞춘 노트를 리스트에 추가
                    }
                    else if (distance <= 50)
                    {
                        score += 50;
                        notesToRemove4.Add(obj4);
                        great += 1;
                        lbGreat.Text = "Great : " + great.ToString();
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= 100)
                    {
                        score += 20;
                        notesToRemove4.Add(obj4);
                        nice += 1;
                        lbNice.Text = "Nice : " + nice.ToString();
                        Combo += 1;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= 150)
                    {
                        score -= 10;
                        notesToRemove4.Add(obj4);
                        fail += 1;
                        lbFail.Text = "Fail : " + fail.ToString();
                        Combo = 0;
                        lbCombo.Text = "Combo : " + Combo.ToString();
                    }
                    else if (distance <= -30)
                    {
                        Combo = 0;
                        score -= 30;

                        lbCombo.Text = "Combo: " + Combo.ToString();
                    }
                    else
                    {

                    }
                }

                // 맞춘 노트를 제거
                foreach (PictureBox obj4 in notesToRemove4)
                {
                    Controls.Remove(obj4);
                    objects4.Remove(obj4); // objects 리스트에서도 제거
                }

                // 점수 업데이트
                scoreLabel.Text = $"Score: {score}";
            }
        }

        private void NoteTimer2(object sender, EventArgs e)
        {
            Random rnd = new Random();
            timer2.Interval = rnd.Next(1300, 3000);
            int startX = 100; // 원하는 시작 X 좌표 값들로 변경하세요 // 4개의 시작 위치 중 하나 선택
            PictureBox newObject2 = new PictureBox();
            newObject2.Size = new Size(50, 50); // 객체 크기 설정
            newObject2.BackColor = Color.Gray; // 객체 색상 설정
            newObject2.Location = new Point(startX, -newObject2.Height); // 시작 위치 설정
            newObject2.SizeMode = PictureBoxSizeMode.StretchImage;
            newObject2.Image = Image.FromFile(@"bin\star\Star.jpg");
            objects2.Add(newObject2);
            Controls.Add(newObject2); // 객체를 폼에 추가

            // 객체를 아래로 이동시키는 타이머 시작
            System.Windows.Forms.Timer objectTimer = new System.Windows.Forms.Timer();
            objectTimer.Interval = 10; // 객체 이동 속도 설정
            objectTimer.Tick += (object sender, EventArgs e) =>
            {
                newObject2.Top += 8; // 이동 속도 설정

                // 객체가 폼의 아래쪽을 벗어나면 타이머를 중지하고 객체를 제거함
                if (newObject2.Bounds.IntersectsWith(pictureBox5.Bounds) && objects2.Contains(newObject2))
                {
                    objectTimer.Stop();
                    Controls.Remove(newObject2);
                    objects1.Remove(newObject2);
                    Combo = 0;
                    score -= 100;
                    scoreLabel.Text = scoreLabel.Text = $"Score: {score}";
                    lbCombo.Text = "Combo : " + Combo.ToString();
                }
            };
            objectTimer.Start();
        }

        private void NoteTimer3(object sender, EventArgs e)
        {
            Random rnd = new Random();
            timer3.Interval = rnd.Next(1300, 3000);
            int startX = 150; // 원하는 시작 X 좌표 값들로 변경하세요 // 4개의 시작 위치 중 하나 선택
            PictureBox newObject3 = new PictureBox();
            newObject3.Size = new Size(50, 50); // 객체 크기 설정
            newObject3.BackColor = Color.Red; // 객체 색상 설정
            newObject3.Location = new Point(startX, -newObject3.Height); // 시작 위치 설정
            newObject3.SizeMode = PictureBoxSizeMode.StretchImage;
            newObject3.Image = Image.FromFile(@"bin\star\Star.jpg");
            objects3.Add(newObject3);
            Controls.Add(newObject3); // 객체를 폼에 추가

            // 객체를 아래로 이동시키는 타이머 시작
            System.Windows.Forms.Timer objectTimer = new System.Windows.Forms.Timer();
            objectTimer.Interval = 10; // 객체 이동 속도 설정
            objectTimer.Tick += (object sender, EventArgs e) =>
            {
                newObject3.Top += 8; // 이동 속도 설정

                // 객체가 폼의 아래쪽을 벗어나면 타이머를 중지하고 객체를 제거함
                if (newObject3.Bounds.IntersectsWith(pictureBox5.Bounds) && objects3.Contains(newObject3))
                {
                    objectTimer.Stop();
                    Controls.Remove(newObject3);
                    objects1.Remove(newObject3);
                    Combo = 0;
                    score -= 100;
                    scoreLabel.Text = scoreLabel.Text = $"Score: {score}";
                    lbCombo.Text = "Combo : " + Combo.ToString();
                }
            };
            objectTimer.Start();
        }

        private void NoteTimer4(object sender, EventArgs e)
        {
            Random rnd = new Random();
            timer4.Interval = rnd.Next(1300, 3000);
            int startX = 200; // 원하는 시작 X 좌표 값들로 변경하세요 // 4개의 시작 위치 중 하나 선택
            PictureBox newObject4 = new PictureBox();
            newObject4.Size = new Size(50, 50); // 객체 크기 설정
            newObject4.BackColor = Color.Blue; // 객체 색상 설정
            newObject4.Location = new Point(startX, -newObject4.Height); // 시작 위치 설정
            newObject4.SizeMode = PictureBoxSizeMode.StretchImage;
            newObject4.Image = Image.FromFile(@"bin\star\Star.jpg");
            objects4.Add(newObject4);
            Controls.Add(newObject4); // 객체를 폼에 추가

            // 객체를 아래로 이동시키는 타이머 시작
            System.Windows.Forms.Timer objectTimer = new System.Windows.Forms.Timer();
            objectTimer.Interval = 10; // 객체 이동 속도 설정
            objectTimer.Tick += (object sender, EventArgs e) =>
            {
                newObject4.Top += 8; // 이동 속도 설정

                // 객체가 폼의 아래쪽을 벗어나면 타이머를 중지하고 객체를 제거함
                if (newObject4.Bounds.IntersectsWith(pictureBox5.Bounds) && objects4.Contains(newObject4))
                {
                    objectTimer.Stop();
                    Controls.Remove(newObject4);
                    objects1.Remove(newObject4);
                    Combo = 0;
                    score -= 100;
                    scoreLabel.Text = scoreLabel.Text = $"Score: {score}";
                    lbCombo.Text = "Combo : " + Combo.ToString();
                }
            };
            objectTimer.Start();
        }

        private void scoreList(object sender, EventArgs e)
        {

        }

        private void timer6_Tick(object sender, EventArgs e)
        {

        }

        private void LeftTimer(object sender, EventArgs e)
        {

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();


        }

        private void timer6_Tick_1(object sender, EventArgs e)
        {
            player1.Stop();
            MessageBox.Show($"끝\nScore: {score}");
            gameSet = true;
            this.Close();
            DataPassEvent(score);
        }

        SoundPlayer player1;
        private void playSimpleSound()
        {
            SoundPlayer player = new SoundPlayer(@"bin\happy.wav");//노래 경로
            player1 = player;
            player.Play();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            countDown--;
            lbtime.Text = "TimeLeft : " + countDown;
            if (countDown == 0)
            {
                timer7.Stop();
            }
            if (score < 0)
            {
                PixLupy.Load(@"bin\Score-100.jpg");
                PixLupy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (score > 0)
            {
                PixLupy.Load(@"bin\score0.jpg");
                PixLupy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (score > 2000)
            {
                PixLupy.Load(@"bin\score2000.jpg");
                PixLupy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (score > 4000)
            {
                PixLupy.Load(@"bin\score7000.jpg");
                PixLupy.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.Black, 50, 0, 50, 500);
            g.DrawLine(Pens.Black, 100, 0, 100, 500);
            g.DrawLine(Pens.Black, 150, 0, 150, 500);
            g.DrawLine(Pens.Black, 200, 0, 200, 500);
            g.DrawLine(Pens.Black, 250, 0, 250, 500);

        }

        private void RhythmGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!gameSet)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                timer5.Stop();
                timer6.Stop();
                timer7.Stop();
                player1.Stop();
                MessageBox.Show($"게임이 강제로 종료되었습니다\nScore: {score}");
                DataPassEvent(score);
            }
        }
    }
}
