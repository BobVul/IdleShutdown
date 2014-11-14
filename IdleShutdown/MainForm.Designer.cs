namespace IdleShutdown
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.progressBarTime = new System.Windows.Forms.ProgressBar();
            this.labelShutdownTimer = new System.Windows.Forms.Label();
            this.timerShutdown = new System.Windows.Forms.Timer(this.components);
            this.labelPostpone = new System.Windows.Forms.Label();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.numericUpDownPostponeMinutes = new System.Windows.Forms.NumericUpDown();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.buttonPostpone = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPostponeMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarTime
            // 
            this.progressBarTime.Location = new System.Drawing.Point(12, 13);
            this.progressBarTime.Name = "progressBarTime";
            this.progressBarTime.Size = new System.Drawing.Size(428, 29);
            this.progressBarTime.TabIndex = 0;
            // 
            // labelShutdownTimer
            // 
            this.labelShutdownTimer.AutoSize = true;
            this.labelShutdownTimer.Location = new System.Drawing.Point(12, 45);
            this.labelShutdownTimer.Name = "labelShutdownTimer";
            this.labelShutdownTimer.Size = new System.Drawing.Size(62, 13);
            this.labelShutdownTimer.TabIndex = 1;
            this.labelShutdownTimer.Text = "Dummy text";
            // 
            // timerShutdown
            // 
            this.timerShutdown.Tick += new System.EventHandler(this.timerShutdown_Tick);
            // 
            // labelPostpone
            // 
            this.labelPostpone.AutoSize = true;
            this.labelPostpone.Location = new System.Drawing.Point(9, 13);
            this.labelPostpone.Name = "labelPostpone";
            this.labelPostpone.Size = new System.Drawing.Size(115, 13);
            this.labelPostpone.TabIndex = 2;
            this.labelPostpone.Text = "Postpone for (minutes):";
            // 
            // panelOptions
            // 
            this.panelOptions.Controls.Add(this.numericUpDownPostponeMinutes);
            this.panelOptions.Controls.Add(this.buttonAbort);
            this.panelOptions.Controls.Add(this.buttonPostpone);
            this.panelOptions.Controls.Add(this.labelPostpone);
            this.panelOptions.Location = new System.Drawing.Point(0, 124);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(452, 41);
            this.panelOptions.TabIndex = 4;
            // 
            // numericUpDownPostponeMinutes
            // 
            this.numericUpDownPostponeMinutes.Location = new System.Drawing.Point(130, 10);
            this.numericUpDownPostponeMinutes.Maximum = new decimal(new int[] {
            9001,
            0,
            0,
            0});
            this.numericUpDownPostponeMinutes.Name = "numericUpDownPostponeMinutes";
            this.numericUpDownPostponeMinutes.Size = new System.Drawing.Size(43, 20);
            this.numericUpDownPostponeMinutes.TabIndex = 5;
            this.numericUpDownPostponeMinutes.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // buttonAbort
            // 
            this.buttonAbort.Location = new System.Drawing.Point(374, 8);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(75, 23);
            this.buttonAbort.TabIndex = 5;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // buttonPostpone
            // 
            this.buttonPostpone.Location = new System.Drawing.Point(293, 8);
            this.buttonPostpone.Name = "buttonPostpone";
            this.buttonPostpone.Size = new System.Drawing.Size(75, 23);
            this.buttonPostpone.TabIndex = 4;
            this.buttonPostpone.Text = "Postpone";
            this.buttonPostpone.UseVisualStyleBackColor = true;
            this.buttonPostpone.Click += new System.EventHandler(this.buttonPostpone_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "IdleShutdown";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 165);
            this.ControlBox = false;
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.labelShutdownTimer);
            this.Controls.Add(this.progressBarTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "IdleShutdown";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPostponeMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarTime;
        private System.Windows.Forms.Label labelShutdownTimer;
        private System.Windows.Forms.Timer timerShutdown;
        private System.Windows.Forms.Label labelPostpone;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Button buttonAbort;
        private System.Windows.Forms.Button buttonPostpone;
        private System.Windows.Forms.NumericUpDown numericUpDownPostponeMinutes;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

