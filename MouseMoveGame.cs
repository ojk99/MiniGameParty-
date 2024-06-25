using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGameParty
{
    public partial class MouseMoveGame : Form
    {
        public MouseMoveGame()
        {
            InitializeComponent();
        }

        private List<PictureBox> pictureBoxesList = new List<PictureBox>(); // List<PictureBox>를 멤버 변수로 변경        //PictureBox pictureBoxes = new PictureBox();
        private List<PictureBox> pictureBoxesList2 = new List<PictureBox>(); // List<PictureBox>를 멤버 변수로 변경        //PictureBox pictureBoxes = new PictureBox();

        int T = 100; //제한시간
        int S = 0;  //점수초기화

        private Random random = new Random();

        public delegate void DataPassEventHandler(int score);
        public event DataPassEventHandler DataPassEvent;

        bool gameSet = false;

        private void Form2_MouseMove(object sender, MouseEventArgs e)   //검은박스의 마우스 따라가기
        {
            pictureBox1.Location = e.Location;
        }

        private void button1_Click(object sender, EventArgs e)  //시작
        {
            StartGame();

            button1.Visible = false;
            button1.Enabled = false;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;

        }
        private void StartGame()    //타이머 시작및 간격
        {
            timer1.Start();
            timer1.Interval = 1000;
            timer2.Start();
            timer2.Interval = 1;
            timer3.Start();
            timer3.Interval = 10000;
        }
        private void CreateNewPictureBox()  //새로운 장애물 및 추격자 만들기
        {
            PictureBox newPictureBox = new PictureBox();    //장애물 박스
            newPictureBox.BackColor = Color.Red; // 예시로 배경색을 빨간색으로 설정
            newPictureBox.Size = new Size(random.Next(10, 100), random.Next(10, 100)); // 크기 조절
            int c = random.Next(0, 2);
            if (c == 0)
                newPictureBox.BackgroundImage = (Image.FromFile("Img\\Hole1.png"));
            else if (c == 1)
                newPictureBox.BackgroundImage = (Image.FromFile("Img\\Hole2.png"));

            newPictureBox.BackgroundImageLayout = ImageLayout.Stretch;

            newPictureBox.Location = new Point(random.Next(100, 900), random.Next(100, 900)); // 랜덤 위치 설정
            Controls.Add(newPictureBox); // 폼에 추가
            pictureBoxesList.Add(newPictureBox); // 리스트에 추가

            PictureBox newPictureBox2 = new PictureBox();   //추격자 박스
            newPictureBox2.BackColor = Color.Red; // 예시로 배경색을 빨간색으로 설정
            newPictureBox2.Size = new Size(random.Next(10, 50), random.Next(10, 50)); // 크기 조절
            newPictureBox2.BackgroundImage = (Image.FromFile("Img\\Thorn.png"));
            newPictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            newPictureBox2.Location = new Point(random.Next(0, 950), random.Next(0, 950)); // 랜덤 위치 설정
            Controls.Add(newPictureBox2); // 폼에 추가
            pictureBoxesList2.Add(newPictureBox2); // 리스트에 추가
        }

        private void pictureBoxMove(PictureBox pictureBox)  //추격자 빨간 박스의 움직임
        {
            int speed = random.Next(0, 20); //속도

            int dx = pictureBox1.Location.X - pictureBox.Location.X;
            int dy = pictureBox1.Location.Y - pictureBox.Location.Y;

            if (Math.Abs(dx) > speed)
            {
                if (dx > 0)
                    pictureBox.Location = new Point(pictureBox.Location.X + speed, pictureBox.Location.Y);
                else
                    pictureBox.Location = new Point(pictureBox.Location.X - speed, pictureBox.Location.Y);
            }

            if (Math.Abs(dy) > speed)
            {
                if (dy > 0)
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + speed);
                else
                    pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - speed);
            }

            CollisionDetection(pictureBox);
        }

        private void UpdateScoreLabel() //점수 추가
        {
            label4.Text = (++S).ToString();
        }

        void CollisionDetection(PictureBox pictureBox)    //충돌감지
        {
            if (pictureBox1.Bounds.IntersectsWith(pictureBox.Bounds))
            {
                EndGame();
            }
        }
        private void EndGame()  //게임종료
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            MessageBox.Show($"당신의 점수는 \n{S}점 입니다");
            gameSet = true;
            Close();
            DataPassEvent(S);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label2.Text = (--T).ToString();
            UpdateScoreLabel();

            if (T == 95)    //처음 장애물 나오는 시간
            {
                CreateNewPictureBox();
            }
            if (T == 0)     //제한시간 초과
            {
                EndGame();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox2.Enabled = true;
            foreach (var pictureBox in pictureBoxesList)    //장애물의 충돌감지
            {
                CollisionDetection(pictureBox);
            }
            foreach (var pictureBox in pictureBoxesList2)    //추격자의 충돌감지
            {
                pictureBoxMove(pictureBox);
            }

            pictureBoxMove(pictureBox2);    //첫 추격자 박스의 움직임
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            CreateNewPictureBox();  //장애물 생성

        }

        private void MouseMoveGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!gameSet)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                MessageBox.Show($"게임이 강제종료 되었습니다\n당신의 점수는 \n{S}점 입니다");
                DataPassEvent(S);
            }
        }
    }
}
