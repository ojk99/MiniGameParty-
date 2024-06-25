using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGameParty
{
    public partial class NumericOrder : Form
    {
        // 클래스 내에서 사용할 필드 및 변수 선언
        private List<Button> numberButtons;  // 숫자 버튼을 담을 리스트
        private int currentNumber;  // 현재 숫자
        private Stopwatch stopwatch;  // 경과 시간을 측정하기 위한 Stopwatch

        public delegate void DataPassEventHandler(double time);
        public event DataPassEventHandler DataPassEvent;

        bool gameSet = false;

        public NumericOrder()  // Form1 클래스의 생성자
        {
            InitializeComponent();
            InitializeGame();
            ShowNumberButtons();
        }

        private void InitializeGame()  // 게임 초기화를 위한 메서드
        {
            // 필드와 변수 초기화
            numberButtons = new List<Button>();
            currentNumber = 1;
            stopwatch = new Stopwatch();

            for (int i = 1; i <= 49; i++)   // 1부터 49까지의 숫자 버튼 생성
            {
                Button button = new Button();
                button.Text = i.ToString();
                button.Size = new Size(100, 100);  // 버튼의 크기 설정
                button.BackColor = Color.RoyalBlue;  // 버튼의 배경색 설정
                button.ForeColor = Color.White;  // 버튼의 글자색 설정
                button.Font = new Font("맑은 고딕", 30, FontStyle.Bold);  // 버튼의 폰트 설정
                button.Click += NumberButton_Click;
                numberButtons.Add(button);
                flowLayoutPanel1.Controls.Add(button);
            }

            StartGame();
        }

        private void StartGame()  // 게임 시작을 위한 메서드
        {
            currentNumber = 1;
            stopwatch.Restart();
            ShuffleNumberButtons();
        }

        private void ShowNumberButtons()  // 버튼들을 5x5 형식으로 보이게 하는 메서드
        {
            flowLayoutPanel1.Controls.Clear();  // flowLayoutPanel1의 모든 컨트롤 삭제

            int gridsize = 7;  // 그리드 사이즈
            int buttonSize = 100;  // 버튼의 크기
            int spacing = 10;  // 버튼 사이의 간격

            flowLayoutPanel1.Width = gridsize * (buttonSize + spacing);  // flowLayoutPanel1의 너비 설정
            flowLayoutPanel1.Height = gridsize * (buttonSize + spacing);  // flowLayoutPanel1의 높이 설정

            for (int i = 0; i < gridsize; i++)
            {
                for (int j = 0; j < gridsize; j++)
                {
                    int index = i * gridsize + j;  // 버튼의 인덱스 계산

                    if (index < numberButtons.Count)  // numberButtons 리스트의 범위 내에 있는 버튼만 생성
                    {
                        Button button = numberButtons[index];
                        button.Size = new Size(buttonSize, buttonSize);  // 버튼의 크기 설정
                        flowLayoutPanel1.Controls.Add(button);  // 버튼을 flowLayoutPanel1에 추가
                    }
                }
            }
        }

        private void ShuffleNumberButtons()  // 숫자 버튼을 섞기 위한 메서드
        {
            Random random = new Random();

            int count = numberButtons.Count;  // 숫자 버튼의 위치를 무작위로 섞음

            while (count > 1)
            {
                count--;
                int index = random.Next(count + 1);
                Button temp = numberButtons[index];
                numberButtons[index] = numberButtons[count];
                numberButtons[count] = temp;
            }

            foreach (Button button in numberButtons)  // flowLayoutPanel에서 버튼들의 위치를 업데이트
            {
                flowLayoutPanel1.Controls.SetChildIndex(button, numberButtons.IndexOf(button));
            }
        }

        private void NumberButton_Click(object sender, EventArgs e)  // 숫자 버튼 클릭 이벤트 핸들러
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.Text == currentNumber.ToString())  // 클릭한 버튼의 텍스트가 현재 숫자와 일치하는지 확인
            {
                if (currentNumber == 49)
                {
                    stopwatch.Stop();
                    TimeSpan elapsed = stopwatch.Elapsed;
                    MessageBox.Show($"게임 종료! 걸린 시간: {elapsed.TotalSeconds:F2}초");

                    gameSet = true;
                    this.Close();
                    DataPassEvent(elapsed.TotalSeconds);
                }
                else
                {
                    currentNumber++;
                }

                clickedButton.BackColor = Color.White;  // 버튼의 배경색 변경
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 경과 시간 표시
            TimeSpan elapsed = stopwatch.Elapsed;
            lbTime.Text = $"경과 시간 : {elapsed.Minutes}분 {elapsed.Seconds}초";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // 타이머 설정
            timer1.Interval = 1000;  // 1초마다 타이머 이벤트 발생
            timer1.Tick += timer1_Tick;
            timer1.Start();  // 타이머 시작
        }

        private void btnTime_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void NumericOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!gameSet)
            {
                MessageBox.Show($"강제종료 되었습니다");
                DataPassEvent(99999999);
            }
        }
    }
}
