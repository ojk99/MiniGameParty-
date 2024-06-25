using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MiniGameParty
{
    public partial class MineSweeper : Form
    {
        int Map_Length = 9;
        int Mine_Count = 10;
        private int Score = 0;  // 점수 변수 선언

        int fdme = 0;
        int FindMine  // 찾은 지뢰 개수를 나타내는 속성
        {
            get
            {
                return fdme;
            }
            set
            {
                fdme = value;
                /*if (fdme == Mine_Count)
                {
                    timer1.Stop();
                    MessageBox.Show("승리!\n" + time/60 + "분" + time + "초");
                    F_Map.Enabled = false;
                }*/
            }
        }

        int flagcount = 0;
        int Flag_Count  // 깃발의 개수를 나타내는 속성
        {
            get
            {
                return flagcount;
            }
            set
            {
                flagcount = value;
                label1.Text = "깃발 : " + value.ToString() + "개";
            }
        }

        int time = 0;  // 시간 변수 선언

        public delegate void DataPassEventHandler(int point, bool time);
        public event DataPassEventHandler DataPassEvent;

        bool gameSet = false;

        public MineSweeper()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time += 1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CreateMap();
            label1.Text = "깃발 : " + Mine_Count + "개";
        }

        private void CreateMap()
        {
            // 지뢰 찾기 관련 변수 초기화
            FindMine = 0;
            flagcount = Mine_Count;
            Flag_Count = Mine_Count;

            // 맵의 길이 계산
            //길이 = (지뢰길이 * 지뢰수) + (5 * (지뢰수 + 1))
            int h = (40 * Map_Length) + (5 * (Map_Length + 1));
            F_Map.Width = h;
            F_Map.Height = h;
            this.Width = h + 20;
            this.Height = h + 100;

            // F_Map 활성화 및 컨트롤 초기화
            F_Map.Enabled = true;
            F_Map.Controls.Clear();

            // 버튼 생성
            for (int i = 1; i <= Math.Pow(Map_Length, 2); i++)
            {
                var btn = new Button();
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.RoyalBlue;
                btn.TabStop = false;
                btn.AutoEllipsis = false;////////////////
                btn.Margin = new Padding(0, 0, 5, 5);
                btn.Size = new Size(40, 40);
                btn.MouseUp += Btn_Click;
                btn.Font = new Font("맑은고딕", 14, FontStyle.Bold);
                F_Map.Controls.Add(btn);
            }

            var rnd = new Random();
            var mineList = new List<int>();
            // Mine_Count만큼의 지뢰 생성
            for (int i = 1; i <= Mine_Count; i++)
            {
                int M_Pos = 0;

                do
                {
                    M_Pos = rnd.Next(1, (int)Math.Pow(Map_Length, 2));  // 1부터 (Map_Length의 제곱)까지의 범위에서 중복되지 않는 위치 찾기
                } while (mineList.Contains(M_Pos));
                mineList.Add(M_Pos);

                // 해당 위치의 버튼을 탭 가능하게 설정

                var cnt = (Button)F_Map.Controls[M_Pos - 1];
                cnt.AutoEllipsis = true;
                //cnt.TabStop = true;
            }

            Console.WriteLine("만들어진 지뢰 : {0}", string.Join(",", mineList));  // 생성된 지뢰 위치 콘솔에 출력
        }

        private void Btn_Click(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;

            timer1.Start();  // 타이머 시작

            if (e.Button == MouseButtons.Left)
            {
                if (btn.BackgroundImage != null)  // 이미지가 설정되어 있는 경우 클릭을 무시
                    return;

                if (btn.AutoEllipsis)  // 버튼이 TabStop으로 설정되어 있는 경우 게임 실패 메시지를 표시하고 지도를 다시 생성
                {
                    timer1.Stop();
                    MessageBox.Show("실패!\n" + (time / 60) + "분" + (time % 60) + "초");
                    //CreateMap();
                    //Score = 0;
                    lbScore.Text = "SCORE : ";

                    gameSet = true;
                    this.Close();
                    DataPassEvent(Score, false);
                    
                    return;
                }

                // 버튼의 인덱스를 계산하여 지뢰 체크 함수를 호출
                int p = F_Map.Controls.IndexOf(btn) + 1;
                checkMine(btn, p);

                Score += 10;  // 클릭할 때마다 점수 10 증가
                UpdateScore();  // 점수 업데이트 함수 호출
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (btn.BackgroundImage == null)
                {
                    if (Flag_Count <= 0)  // // 이미지가 설정되어 있지 않은 경우, 깃발을 모두 사용한 경우 메시지를 표시하고 리턴
                    {
                        MessageBox.Show("깃발을 모두 사용했습니다.");
                        return;
                    }

                    // 깃발 이미지를 설정하고 깃발 개수를 감소
                    btn.BackgroundImage = Image.FromFile("image\\Flag_Black.png");
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    Flag_Count--;
                    if (btn.AutoEllipsis)
                        FindMine++;

                    //Score += 5;  // 깃발을 꽂을 때마다 점수 5 증가
                }
                else
                {
                    // 이미지가 설정되어 있는 경우, 이미지를 제거하고 깃발 개수를 증가
                    btn.BackgroundImage = null;

                    Flag_Count++;
                    if (btn.AutoEllipsis)
                        FindMine--;

                    //Score -= 5;  // 깃발을 제거할 때마다 점수 5 감소
                }

                UpdateScore();
            }
            int cnt = 0;
            for (int i = 1; i <= 81; i++)
            {
                var bt = (Button)F_Map.Controls[i - 1];
                if (bt.Enabled != false)
                {
                    if (bt.AutoEllipsis)
                    {

                    }
                    else
                    {
                        cnt++;
                    }
                }
            }
            if (cnt == 0)
            {
                timer1.Stop();
                MessageBox.Show("승리!\n" + (time / 60) + "분" + (time % 60) + "초");
                F_Map.Enabled = false;

                gameSet = true;
                this.Close();
                DataPassEvent(time, true);
                
            }
        }

        private void UpdateScore()  // 점수 업데이트
        {
            // 점수를 화면에 출력하는 코드
            lbScore.Text = "SCORE : " + Score.ToString();
        }

        List<int> posList = new List<int>();

        private void checkMine(int pos)
        {
            Button btn = (Button)F_Map.Controls[pos];
            checkMine(btn, ++pos);
        }

        private void checkMine(Button btn, int p)
        {
            if (btn.Enabled == false)
                return;  // 버튼이 이미 비활성화된 상태면 함수를 종료

            btn.Enabled = false;  // 버튼을 비활성화
            btn.BackColor = SystemColors.ControlLightLight;
            btn.ForeColor = Color.RoyalBlue;

            int c = 0;  // 지뢰 주변에 있는 지뢰의 개수를 저장할 변수

            // 인접한 위치에 있는 지뢰의 개수를 세어 c 변수에 저장
            if (p % Map_Length != 1 && g(p - 1))
                c++;
            if (p % Map_Length != 0 && g(p + 1))
                c++;
            if (g(p + Map_Length))
                c++;
            if (g(p - Map_Length))
                c++;
            if (p % Map_Length != 1 && g(p - (Map_Length + 1)))
                c++;
            if (p % Map_Length != 0 && g(p - (Map_Length - 1)))
                c++;
            if (p % Map_Length != 0 && g(p + (Map_Length + 1)))
                c++;
            if (p % Map_Length != 1 && g(p + (Map_Length - 1)))
                c++;

            if (c == 0)  // 인접한 위치에 지뢰가 없는 경우
            {
                // 인접한 위치에 있는 버튼들을 확인하기 위해 zcheckMine 함수를 호출
                if (p % Map_Length != 1)
                    zcheckMine(p - 1);
                if (p % Map_Length != 0)
                    zcheckMine(p + 1);
                if (!(p + Map_Length > Math.Pow(Map_Length, 2)))
                    zcheckMine(p + Map_Length);
                if (!(p - Map_Length < 0))
                    zcheckMine(p - Map_Length);
                if (p % Map_Length != 1)
                    zcheckMine(p - (Map_Length + 1));
                if (p % Map_Length != 0)
                    zcheckMine(p - (Map_Length - 1));
                if (p % Map_Length != 0)
                    zcheckMine(p + (Map_Length + 1));
                if (p % Map_Length != 1)
                    zcheckMine(p + (Map_Length - 1));
            }
            else  // 인접한 위치에 지뢰가 있는 경우
                btn.Text = c.ToString();  // 버튼의 텍스트를 인접한 지뢰의 개수로 설정합
        }

        private void zcheckMine(int pos)
        {
            // 인덱스가 유효한 범위를 벗어나면 리턴
            if (pos > Math.Pow(Map_Length, 2) || pos < 1)
                return;

            Button btn = (Button)F_Map.Controls[pos - 1];  // 버튼을 가져옴

            // 버튼이 TabStop으로 설정되어 있거나 비활성화된 경우 리턴
            if (btn.AutoEllipsis || btn.Enabled == false)
                return;
            else
                checkMine(btn, pos);
        }

        private bool g(int ind)
        {
            // 인덱스가 유효하지 않은 경우 false를 리턴
            if (ind < 1)
                return false;

            if (ind > Math.Pow(Map_Length, 2))
                return false;

            // 버튼을 가져와서 TabStop 속성을 리턴
            Button control = (Button)F_Map.Controls[ind - 1];
            return control.AutoEllipsis;
        }

        private void MineSweeper_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(gameSet == false)
            {
                MessageBox.Show("강제종료 되었습니다\n 점수는 " + Score + "점 얻고 실패 하였습니다.");
                DataPassEvent(Score, false);
            }
        }
    }
}
