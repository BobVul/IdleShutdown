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
        public TimeSpan InitialDelay { get; set; }
        public bool ExitOnAbort { get; set; }

        private TimeSpan waitTime;
        private Stopwatch stopwatch = new Stopwatch();
        private bool postponed = false;

        // so clicking on the shutdown icon isn't enough to start a shutdown accidentally...
        private bool waitingForFirstTrigger = true;

        public MainForm()
        {
            InitializeComponent();

            notifyIcon.ContextMenu = new ContextMenu();
            notifyIcon.ContextMenu.MenuItems.Add("Exit", (sender, args) =>
            {
                MessageBox.Show("Exiting");
                Application.Exit();
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartShutdownTimer();
        }

        public void StartShutdownTimer()
        {
            waitingForFirstTrigger = false;
            postponed = false;
            waitTime = InitialDelay;
            progressBarTime.Maximum = (int)waitTime.TotalSeconds;
            stopwatch.Reset();
            stopwatch.Start();
            timerShutdown.Enabled = true;
            this.Show();
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            if (!this.ExitOnAbort)
            {
                timerShutdown.Enabled = false;
                this.Hide();
            }
            else
            {
                Application.Exit();
            }
        }

        private void timerShutdown_Tick(object sender, EventArgs e)
        {
            TimeSpan timeleft = (waitTime - stopwatch.Elapsed);
            if (postponed)
            {
                if ((int)(waitTime - stopwatch.Elapsed).TotalSeconds <= 0)
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
                    MessageBox.Show("Shutdown");
                    //Process.Start("shutdown", "/s /t 0");
            }
        }

        private void buttonPostpone_Click(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(5000, "Idle Shutdown timer postponed for " + numericUpDownPostponeMinutes.Value + " minutes.", " ", ToolTipIcon.Info);
            postponed = true;
            waitTime = TimeSpan.FromMinutes((double)numericUpDownPostponeMinutes.Value);
            stopwatch.Reset();
            stopwatch.Start();
            this.Hide();
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            if (!waitingForFirstTrigger)
            {
                this.Show();
                StartShutdownTimer();
            }
        }
    }
}
