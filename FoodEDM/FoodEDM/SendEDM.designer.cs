namespace FoodEDM
{
    partial class SendEDM
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.btnReSet = new System.Windows.Forms.Button();
            this.btnCancelBackgroundWork = new System.Windows.Forms.Button();
            this.btnStartBackgroundWork = new System.Windows.Forms.Button();
            this.lbl_State = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnImportEDM = new System.Windows.Forms.Button();
            this.btnImportEmail = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.lbPrecent = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 890);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1084, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "執行進度";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // btnReSet
            // 
            this.btnReSet.Location = new System.Drawing.Point(266, 12);
            this.btnReSet.Name = "btnReSet";
            this.btnReSet.Size = new System.Drawing.Size(121, 42);
            this.btnReSet.TabIndex = 21;
            this.btnReSet.Text = "重置";
            this.btnReSet.UseVisualStyleBackColor = true;
            this.btnReSet.Click += new System.EventHandler(this.btnReSet_Click);
            // 
            // btnCancelBackgroundWork
            // 
            this.btnCancelBackgroundWork.Location = new System.Drawing.Point(139, 12);
            this.btnCancelBackgroundWork.Name = "btnCancelBackgroundWork";
            this.btnCancelBackgroundWork.Size = new System.Drawing.Size(121, 42);
            this.btnCancelBackgroundWork.TabIndex = 19;
            this.btnCancelBackgroundWork.Text = "取消";
            this.btnCancelBackgroundWork.UseVisualStyleBackColor = true;
            this.btnCancelBackgroundWork.Click += new System.EventHandler(this.btnCancelBackgroundWork_Click);
            // 
            // btnStartBackgroundWork
            // 
            this.btnStartBackgroundWork.Location = new System.Drawing.Point(9, 12);
            this.btnStartBackgroundWork.Name = "btnStartBackgroundWork";
            this.btnStartBackgroundWork.Size = new System.Drawing.Size(121, 42);
            this.btnStartBackgroundWork.TabIndex = 18;
            this.btnStartBackgroundWork.Text = "寄信";
            this.btnStartBackgroundWork.UseVisualStyleBackColor = true;
            this.btnStartBackgroundWork.Click += new System.EventHandler(this.btnStartBackgroundWork_Click);
            // 
            // lbl_State
            // 
            this.lbl_State.AutoSize = true;
            this.lbl_State.Location = new System.Drawing.Point(624, 116);
            this.lbl_State.Name = "lbl_State";
            this.lbl_State.Size = new System.Drawing.Size(20, 12);
            this.lbl_State.TabIndex = 22;
            this.lbl_State.Text = "0%";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(9, 144);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(368, 752);
            this.checkedListBox1.TabIndex = 23;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(63, 105);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(544, 23);
            this.progressBar1.TabIndex = 24;
            // 
            // btnImportEDM
            // 
            this.btnImportEDM.Location = new System.Drawing.Point(525, 12);
            this.btnImportEDM.Name = "btnImportEDM";
            this.btnImportEDM.Size = new System.Drawing.Size(121, 42);
            this.btnImportEDM.TabIndex = 25;
            this.btnImportEDM.Text = "匯入EDM";
            this.btnImportEDM.UseVisualStyleBackColor = true;
            this.btnImportEDM.Click += new System.EventHandler(this.btnImportEDM_Click);
            // 
            // btnImportEmail
            // 
            this.btnImportEmail.Location = new System.Drawing.Point(393, 12);
            this.btnImportEmail.Name = "btnImportEmail";
            this.btnImportEmail.Size = new System.Drawing.Size(121, 42);
            this.btnImportEmail.TabIndex = 26;
            this.btnImportEmail.Text = "匯入Email";
            this.btnImportEmail.UseVisualStyleBackColor = true;
            this.btnImportEmail.Click += new System.EventHandler(this.btnImportEmail_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(652, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 42);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "關閉";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(16, 71);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(41, 12);
            this.lbTitle.TabIndex = 28;
            this.lbTitle.Text = "標題：";
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(63, 68);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(546, 22);
            this.tbSubject.TabIndex = 29;
            // 
            // lbPrecent
            // 
            this.lbPrecent.AutoSize = true;
            this.lbPrecent.Location = new System.Drawing.Point(659, 116);
            this.lbPrecent.Name = "lbPrecent";
            this.lbPrecent.Size = new System.Drawing.Size(33, 12);
            this.lbPrecent.TabIndex = 30;
            this.lbPrecent.Text = "label1";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(390, 13);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(689, 752);
            this.webBrowser1.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "狀態：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Location = new System.Drawing.Point(-7, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 784);
            this.panel1.TabIndex = 33;
            // 
            // SendEDM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1084, 912);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPrecent);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnImportEmail);
            this.Controls.Add(this.btnImportEDM);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbl_State);
            this.Controls.Add(this.btnReSet);
            this.Controls.Add(this.btnCancelBackgroundWork);
            this.Controls.Add(this.btnStartBackgroundWork);
            this.Controls.Add(this.statusStrip1);
            this.Name = "SendEDM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Food-EDM(2014-10-15)";
            this.Load += new System.EventHandler(this.SendEDM_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button btnReSet;
        private System.Windows.Forms.Button btnCancelBackgroundWork;
        private System.Windows.Forms.Button btnStartBackgroundWork;
        private System.Windows.Forms.Label lbl_State;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnImportEDM;
        private System.Windows.Forms.Button btnImportEmail;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.Label lbPrecent;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}

