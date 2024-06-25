using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniGameParty
{
    public partial class ButtonGame : Form
    {
        public ButtonGame()
        {
            InitializeComponent();
            imageList1.ImageSize = new Size(50, 50);
            button1.ImageList = imageList1;
        }

        int T = 60; //제한시간
        int S = 0;  //점수초기화

        public delegate void DataPassEventHandler(int score);
        public event DataPassEventHandler DataPassEvent;

        bool gameSet = false;

        private Random random = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "클릭";

            LocationAndSize();      //버튼누르면 바로 위치와 크기 변경
            StartGame();            //타이머 시작
            UpdateScoreLabel();     //점수 추가

        }

        private void StartGame()    //타이머 시작및 간격
        {
            timer1.Start();
            timer1.Interval = 1000;
            timer2.Start();
            timer2.Interval = random.Next(600, 1000);   //자동 위치 변경 간격
        }


        private void LocationAndSize()  //버튼 색과 위치와 크기
        {
            int x = random.Next(0, 500);
            int y = random.Next(0, 500);
            int W = random.Next(20, 100);
            int H = random.Next(20, 100);

            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);

            int r2 = random.Next(0, 256);
            int g2 = random.Next(0, 256);
            int b2 = random.Next(0, 256);

            button1.BackColor = Color.FromArgb(r, g, b);
            button1.ForeColor = Color.FromArgb(r2, g2, b2);
            button1.Location = new Point(x, y);
            button1.Size = new Size(W, H);

            // 버튼 크기에 따라 ImageList의 이미지 크기를 업데이트
            imageList1.ImageSize = new Size(W, H);
            //ImageList의 이미지를 업데이트
            int c = random.Next(0, 3);
            // 버튼에 이미지 할당
            if (c == 0)
                imageList1.Images.Add(Image.FromFile("Img\\Do.png"));
            else if (c == 1)
                imageList1.Images.Add(Image.FromFile("Img\\Do2.png"));
            else if (c == 2)
                imageList1.Images.Add(Image.FromFile("Img\\Do3.png"));

            button1.ImageIndex = 0;
        }

        private void UpdateScoreLabel() //점수 추가
        {
            label4.Text = (++S).ToString();
        }
        private void EndGame()  //게임종료
        {
            timer1.Stop();
            timer2.Stop();
            MessageBox.Show($"당신의 점수는 \n{S}점 입니다");
            gameSet = true;
            Close();
            DataPassEvent(S);
        }
        private void timer1_Tick(object sender, EventArgs e)    //제한시간
        {
            label2.Text = (--T).ToString();
            if (T == 0)
            {
                EndGame();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)    //자동 버튼 위치변경
        {
            LocationAndSize();  //버튼 위치와 크기 변경
        }

        private void ButtonGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!gameSet)
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show($"게임이 강제종료 되었습니다\n당신의 점수는 \n{S}점 입니다");
                DataPassEvent(S);
            }
        }
    }
}
