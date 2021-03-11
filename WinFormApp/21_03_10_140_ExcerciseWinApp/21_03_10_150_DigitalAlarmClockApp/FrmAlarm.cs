using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace _21_03_10_150_DigitalAlarmClockApp
{
    // Tabpages 에서 탭의 Name, Text를 설정

    public partial class FrmAlarm : Form
    {
        private DateTime SetDay;
        private DateTime SetTime;
        private bool IsSetAlarm;
        WindowsMediaPlayer mediaPlayer;  // 전역 변수는 선언만해주고 초기화는 각 지역변수로 쓸때만 해주는게 좋음.

        public FrmAlarm()
        {
            InitializeComponent();

            // 초기화 작업

        }

        private void FrmAlarm_Load(object sender, EventArgs e)
        {
            mediaPlayer = new WindowsMediaPlayer();
            LblAlarm.ForeColor = Color.Gray;            // foreColor로 라벨의 색깔 설정

            LblDate.Text = LblTime.Text = "";           // 시작할때 글자를 지워줌.

            DtpAlarmTime.Format = DateTimePickerFormat.Custom;
            DtpAlarmTime.CustomFormat = "hh:mm:ss";     // 두번째 DateTimepicker를 Custom으로 바꾸고 hh:mm:ss 양식으로 출력
            DtpAlarmTime.ShowUpDown = true;

            MyTimer.Interval = 1000;  // 1초
            MyTimer.Tick += MyTimer_Tick;
            MyTimer.Enabled = true;
            MyTimer.Start();

            TabClock.SelectedTab = TapDigitalClock;
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            DateTime curDate = DateTime.Now;
            LblDate.Text = curDate.ToShortDateString();
            LblTime.Text = curDate.ToString("hh:mm:ss");

            if(IsSetAlarm == true)  // 알람설정이 됬다면?
            { 
                // 알람 시간과 현재시간이 일치하면 알람 울림
                if(SetDay == DateTime.Today && 
                    SetTime.Hour == curDate.Hour &&
                    SetTime.Minute == curDate.Minute &&
                    SetTime.Second == curDate.Second)
                {
                    // IsSetAlarm = false;               // 알람 설정 종료
                    BtnRelease_Click(sender, e);         // 해제버튼 클릭 이벤트 메서드 호출(알람이 울리면 라벨텍스트가 다시 회색으로 바뀌게해줌)
                    mediaPlayer.URL = @".\Medias\alarm.mp3";
                    mediaPlayer.controls.play();
                    MessageBox.Show("알람!!!!", "알람", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            SetDay = DateTime.Parse(DtpAlarmDate.Text);  // Parse를 통해 알람날짜를 DateTime으로 바꿔줌.
            SetTime = DateTime.Parse(DtpAlarmTime.Text);

            LblAlarm.Text = $"Alarm : {SetDay.ToShortDateString()} {SetTime:hh:mm:ss}";
            LblAlarm.ForeColor = Color.Red;

            TabClock.SelectedTab = TapDigitalClock;
            IsSetAlarm = true;
        }

        private void BtnRelease_Click(object sender, EventArgs e)
        {
            IsSetAlarm = false;
            LblAlarm.Text = "Alarm : ";
            LblAlarm.ForeColor = Color.Gray;
        }

    }
}
