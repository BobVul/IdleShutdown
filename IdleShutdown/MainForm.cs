using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace IdleShutdown
{
    public partial class MainForm : Form
    {
        TimeSpan DefaultWaitTime = TimeSpan.FromMinutes(5);
        TimeSpan waittime;
        Stopwatch stopwatch = new Stopwatch();
        bool postponed = false;

        public MainForm()
        {
            InitializeComponent();

            double minutes;
            if (Environment.GetCommandLineArgs().Length > 1 && Double.TryParse(Environment.GetCommandLineArgs()[1], out minutes))
                DefaultWaitTime = TimeSpan.FromMinutes(minutes);

            StartShutdownTimer();
        }

        private void StartShutdownTimer()
        {
            postponed = false;
            waittime = DefaultWaitTime;
            progressBarTime.Maximum = (int)waittime.TotalSeconds;
            stopwatch.Reset();
            stopwatch.Start();
            this.Show();
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerShutdown_Tick(object sender, EventArgs e)
        {
            TimeSpan timeleft = (waittime - stopwatch.Elapsed);
            if (postponed)
            {
                if ((int)(waittime - stopwatch.Elapsed).TotalSeconds <= 0)
                    StartShutdownTimer();
            }
            else
            {
                progressBarTime.Value = progressBarTime.Maximum - ((int)timeleft.TotalSeconds <= 0 ? 0 : (int)timeleft.TotalSeconds);
                labelShutdownTimer.Text = "Shutting down in ";
                if (timeleft.Hours > 0)
                    labelShutdownTimer.Text += timeleft.Hours + " hours ";
                if (timeleft.Minutes > 0)
                    labelShutdownTimer.Text += timeleft.Minutes + " minutes ";
                if (timeleft.Seconds > 0)
                    labelShutdownTimer.Text += timeleft.Seconds + " seconds ";

                if ((int)timeleft.TotalSeconds <= 0)
                    Process.Start("shutdown", "/s /t 0");
            }
        }

        private void buttonPostpone_Click(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(5000, "Idle Shutdown timer postponed for " + numericUpDownPostponeMinutes.Value + " minutes.", " ", ToolTipIcon.Info);
            postponed = true;
            waittime = TimeSpan.FromMinutes((double)numericUpDownPostponeMinutes.Value);
            stopwatch.Reset();
            stopwatch.Start();
            this.Hide();
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            StartShutdownTimer();
        }
    }
}
