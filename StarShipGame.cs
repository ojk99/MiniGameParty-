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
    public partial class StarShipGame : Form
    {

        int score = 0; // 점수

        int speed = 100; //배경 이미지 속도

        int fireSpeed = 50;// 총알 속도

        int limittime = 60; // 제한 시간 60초


        private PictureBox fire;

        private bool leftKeyPressed = false;
        private bool rightKeyPressed = false;
        private bool upKeyPressed = false;
        private bool downKeyPressed = false;



        private List<PictureBox> objects; //이미지 생성 리스트

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;

        private int startXSpacing;
        private int lineSpacing;

        Random Random = new Random();


        public delegate void DataPassEventHandler(int score);
        public event DataPassEventHandler DataPassEvent;
        bool gameSet = false;
        bool check = false;
        public StarShipGame()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            check = true;
            Controls.Remove(button1);
            Controls.Remove(label2);

            objects = new List<PictureBox>();
            Random = new Random();
            startXSpacing = ClientSize.Width / 10; // 시작 위치 간격 설정 (폼 너비를 10등분)
            lineSpacing = startXSpacing / 4; // 라인 간격 설정

            ///////////////////////////////////////////////////////////////// 적 우주선 
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 400; //객체 생성 간격 (1000이 1초)
            timer.Tick += etimer_Tick;
            timer.Start();

            ////////////////////////////////////////////////////////////// 총알
            timer2 = new System.Windows.Forms.Timer();
            fireTimer.Interval = 50;
            fireTimer.Tick += fireTimer_Tick;

            //////////////////////////////////////////////////////////////// 플레이어 이동
            timer3 = new System.Windows.Forms.Timer();

            timer3.Interval = 20;
            timer3.Tick += move_Tick;
            timer3.Start();

            ////////////////////////////////////////////////////////////////// 시간제어 
            timer4 = new System.Windows.Forms.Timer();
            timer4.Interval = 1000;
            timer4.Tick += timelimit_Tick;
            timer4.Start();
        }
        private void MoveBackground(int speed)// 배경화면 이동
        {
            if (pictureBox2.Top >= Height) // 이미지가 화면을 벗어나면
            {
                pictureBox2.Top = -pictureBox2.Height; // 맨 위로 초기화
            }
            else
            {
                pictureBox2.Top += speed; // 이미지 이동
            }

            if (pictureBox3.Top >= Height)
            {
                pictureBox3.Top = -pictureBox3.Height;
            }
            else
            {
                pictureBox3.Top += speed;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            BackColor = Color.FromArgb(0, 0, 24);//배경 기본 색상 지정


            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Location = new Point(0, 0); // 배경 시작 위치
            pictureBox2.Width = Width; // 사진과 맞게 박스 크기 조절
            pictureBox2.Height = Height;


            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Location = new Point(0, 1000); // 배경 시작 위치 (맨 위로 이동)
            pictureBox3.Width = Width;
            pictureBox3.Height = Height;

            timer1.Interval = 100; // 타이머 간격 설정 (100ms)
            timer1.Start(); // 타이머 시작
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!check)
                return;
            if (e.KeyCode == Keys.Left)
            {
                leftKeyPressed = true;

            }
            if (e.KeyCode == Keys.Right)
            {
                rightKeyPressed = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                upKeyPressed = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                downKeyPressed = true;
            }

            if (e.KeyCode == Keys.Space && timer3.Enabled)
            {
                // 기존의 fire 픽쳐박스가 있는지 확인
                if (fire == null)
                {
                    fire = new PictureBox();
                    fire.Image = Properties.Resources.fireball;
                    fire.SizeMode = PictureBoxSizeMode.Zoom; // 이미지 사이즈 조정
                    fire.Size = new Size(15, 50); // 크기 설정

                    // pb_starship의 중앙 좌표 계산
                    int starshipCenterX = pb_starship.Left + pb_starship.Width / 2;

                    // fire의 위치 설정 (중앙에서 바로 위쪽으로)
                    fire.Location = new Point(starshipCenterX - fire.Width / 2, pb_starship.Top - fire.Height);

                    this.Controls.Add(fire);// 폼에 fire 픽쳐박스 추가
                    fire.BringToFront(); //fire가 최상단에 표시되도록 명령
                    fireTimer.Start();
                }


            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!check)
                return;
            if (e.KeyCode == Keys.Left)
            {
                leftKeyPressed = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightKeyPressed = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                upKeyPressed = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                downKeyPressed = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveBackground(speed);
        }

        private void fireTimer_Tick(object sender, EventArgs e)
        {
            if (fire != null)
            {
                fire.Top -= fireSpeed;

                if (fire.Top <= -fire.Height)
                {
                    fire.Visible = false; //픽쳐박스 삭제
                    fireTimer.Stop();

                    this.Controls.Remove(fire); // 폼에서 fire 제거
                    fire.Dispose(); //메모리에서 제거
                    fire = null;

                }
            }
        }

        private void move_Tick(object sender, EventArgs e)
        {
            int movement = 12;

            if (leftKeyPressed)
            {
                if (pb_starship.Left > 0) // 왼쪽으로 이동할 때 폼을 벗어나지 않도록 체크
                {
                    pb_starship.Left -= movement;
                }
            }
            if (rightKeyPressed)
            {
                if (pb_starship.Right < this.ClientSize.Width) // 오른쪽으로 이동할 때 폼을 벗어나지 않도록 체크
                {
                    pb_starship.Left += movement;
                }
            }
            if (upKeyPressed)
            {
                if (pb_starship.Top > 0) // 위로 이동할 때 폼을 벗어나지 않도록 체크
                {
                    pb_starship.Top -= movement;
                }
            }
            if (downKeyPressed)
            {
                if (pb_starship.Bottom < this.ClientSize.Height) // 아래로 이동할 때 폼을 벗어나지 않도록 체크
                {
                    pb_starship.Top += movement;
                }
            }
        }

        private void timelimit_Tick(object sender, EventArgs e)
        {
            limittime -= 1;

            if (limittime > 0)
            {
                lb_time.Text = limittime.ToString();
            }
        }

        private void etimer_Tick(object sender, EventArgs e)
        {
            int startX = Random.Next(9) * startXSpacing + startXSpacing / 2; // 적 우주선 생성위치 조정
            PictureBox newObject = new PictureBox();

            newObject.Size = new Size(80, 100); // 객체 크기 설정
            newObject.Location = new Point(startX, -newObject.Height); // 시작 위치 설정

            newObject.Image = Properties.Resources.e_starship;
            newObject.SizeMode = PictureBoxSizeMode.Zoom;


            objects.Add(newObject);
            Controls.Add(newObject); // 객체를 폼에 추가

            newObject.BringToFront(); // 객체를 최상위로 가져옴

            // 객체를 아래로 이동시키는 타이머 시작
            System.Windows.Forms.Timer objectTimer = new System.Windows.Forms.Timer();

            objectTimer.Interval = Random.Next(10, 30); // 객체 이동 속도 설정


            objectTimer.Tick += (object sender, EventArgs e) =>
            {
                newObject.Top += Random.Next(10, 30); // 이동 속도 설정

                if (fire != null) // fire 픽쳐박스가 null이 아닐 때 
                {
                    if (newObject.Bounds.IntersectsWith(fire.Bounds)) // 총알과 적 우주선이 부딪혔을 떄
                    {
                        objectTimer.Stop();
                        Controls.Remove(newObject);
                        objects.Remove(newObject);

                        fire.Visible = false;
                        fireTimer.Stop();

                        this.Controls.Remove(fire);
                        fire.Dispose();
                        fire = null;

                        score += 100;
                        lb_score.Text = score.ToString();

                    }

                }


                if (pb_starship.Bounds.IntersectsWith(newObject.Bounds) && timer1.Enabled != false || (limittime == 0 && timer1.Enabled != false))
                {
                    timer1.Enabled = false;

                    lb_gameover.Visible = true; // 라벨을 보이게 설정
                    pb_starship.Image = Properties.Resources.Boom; // 우주선 이미지를 Boom 이미지로 변경
                    pb_starship.SizeMode = PictureBoxSizeMode.Zoom;

                    objectTimer.Stop();
                    Controls.Remove(newObject);
                    objects.Remove(newObject);


                    timer.Stop();
                    timer3.Stop();
                    timer4.Stop();


                    MessageBox.Show($"점수는 {score} 입니다");
                    gameSet = true;
                    this.Close();
                    DataPassEvent(score);

                }

                // 객체가 폼의 아래쪽을 벗어나면 타이머를 중지하고 객체를 제거함
                if (newObject.Top >= ClientSize.Height)
                {
                    objectTimer.Stop();
                    Controls.Remove(newObject);
                    objects.Remove(newObject);
                }
            };
            objectTimer.Start();
        }

        private void StarShipGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!gameSet)
            {
                MessageBox.Show($"게임이 강제종료 되었습니다\n점수는 {score} 입니다");
                DataPassEvent(score);
            }
        }
    }
}
