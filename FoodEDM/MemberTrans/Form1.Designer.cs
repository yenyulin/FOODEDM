namespace MemberTrans
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_MemberPAll = new System.Windows.Forms.Label();
            this.lbl_MemberGAll = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMemberGCount = new System.Windows.Forms.Label();
            this.lbMemberPCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbFeeCount = new System.Windows.Forms.Label();
            this.lbl_FeeAll = new System.Windows.Forms.Label();
            this.lbl_PaperAll = new System.Windows.Forms.Label();
            this.lbPaperCount = new System.Windows.Forms.Label();
            this.lbOnSiteCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_OnSiteAll = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbRegisterCount = new System.Windows.Forms.Label();
            this.lbl_RegisterAll = new System.Windows.Forms.Label();
            this.lbReceiptCount = new System.Windows.Forms.Label();
            this.lbl_ReceiptAll = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbVoteCount = new System.Windows.Forms.Label();
            this.lbl_VoteAll = new System.Windows.Forms.Label();
            this.lbTip01 = new System.Windows.Forms.Label();
            this.lbTitle1 = new System.Windows.Forms.Label();
            this.lbTitle2 = new System.Windows.Forms.Label();
            this.lbTitle3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "trans";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_MemberPAll
            // 
            this.lbl_MemberPAll.AutoSize = true;
            this.lbl_MemberPAll.Location = new System.Drawing.Point(278, 60);
            this.lbl_MemberPAll.Name = "lbl_MemberPAll";
            this.lbl_MemberPAll.Size = new System.Drawing.Size(11, 12);
            this.lbl_MemberPAll.TabIndex = 32;
            this.lbl_MemberPAll.Text = "0";
            // 
            // lbl_MemberGAll
            // 
            this.lbl_MemberGAll.AutoSize = true;
            this.lbl_MemberGAll.Location = new System.Drawing.Point(278, 33);
            this.lbl_MemberGAll.Name = "lbl_MemberGAll";
            this.lbl_MemberGAll.Size = new System.Drawing.Size(11, 12);
            this.lbl_MemberGAll.TabIndex = 31;
            this.lbl_MemberGAll.Text = "0";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "MemberG進度:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "MemberP進度:";
            // 
            // lbMemberGCount
            // 
            this.lbMemberGCount.AutoSize = true;
            this.lbMemberGCount.Location = new System.Drawing.Point(168, 33);
            this.lbMemberGCount.Name = "lbMemberGCount";
            this.lbMemberGCount.Size = new System.Drawing.Size(11, 12);
            this.lbMemberGCount.TabIndex = 35;
            this.lbMemberGCount.Text = "0";
            // 
            // lbMemberPCount
            // 
            this.lbMemberPCount.AutoSize = true;
            this.lbMemberPCount.Location = new System.Drawing.Point(168, 60);
            this.lbMemberPCount.Name = "lbMemberPCount";
            this.lbMemberPCount.Size = new System.Drawing.Size(11, 12);
            this.lbMemberPCount.TabIndex = 36;
            this.lbMemberPCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "目前進度：";
            // 
            // lbState
            // 
            this.lbState.AutoSize = true;
            this.lbState.Location = new System.Drawing.Point(106, 269);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(36, 12);
            this.lbState.TabIndex = 38;
            this.lbState.Text = "Wait...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "Fee";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 12);
            this.label5.TabIndex = 40;
            this.label5.Text = "Paper";
            // 
            // lbFeeCount
            // 
            this.lbFeeCount.AutoSize = true;
            this.lbFeeCount.Location = new System.Drawing.Point(168, 220);
            this.lbFeeCount.Name = "lbFeeCount";
            this.lbFeeCount.Size = new System.Drawing.Size(11, 12);
            this.lbFeeCount.TabIndex = 41;
            this.lbFeeCount.Text = "0";
            // 
            // lbl_FeeAll
            // 
            this.lbl_FeeAll.AutoSize = true;
            this.lbl_FeeAll.Location = new System.Drawing.Point(278, 220);
            this.lbl_FeeAll.Name = "lbl_FeeAll";
            this.lbl_FeeAll.Size = new System.Drawing.Size(11, 12);
            this.lbl_FeeAll.TabIndex = 42;
            this.lbl_FeeAll.Text = "0";
            // 
            // lbl_PaperAll
            // 
            this.lbl_PaperAll.AutoSize = true;
            this.lbl_PaperAll.Location = new System.Drawing.Point(278, 90);
            this.lbl_PaperAll.Name = "lbl_PaperAll";
            this.lbl_PaperAll.Size = new System.Drawing.Size(11, 12);
            this.lbl_PaperAll.TabIndex = 44;
            this.lbl_PaperAll.Text = "0";
            // 
            // lbPaperCount
            // 
            this.lbPaperCount.AutoSize = true;
            this.lbPaperCount.Location = new System.Drawing.Point(168, 90);
            this.lbPaperCount.Name = "lbPaperCount";
            this.lbPaperCount.Size = new System.Drawing.Size(11, 12);
            this.lbPaperCount.TabIndex = 43;
            this.lbPaperCount.Text = "0";
            // 
            // lbOnSiteCount
            // 
            this.lbOnSiteCount.AutoSize = true;
            this.lbOnSiteCount.Location = new System.Drawing.Point(168, 195);
            this.lbOnSiteCount.Name = "lbOnSiteCount";
            this.lbOnSiteCount.Size = new System.Drawing.Size(11, 12);
            this.lbOnSiteCount.TabIndex = 47;
            this.lbOnSiteCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 12);
            this.label7.TabIndex = 46;
            this.label7.Text = "現場報名進度:";
            // 
            // lbl_OnSiteAll
            // 
            this.lbl_OnSiteAll.AutoSize = true;
            this.lbl_OnSiteAll.Location = new System.Drawing.Point(278, 195);
            this.lbl_OnSiteAll.Name = "lbl_OnSiteAll";
            this.lbl_OnSiteAll.Size = new System.Drawing.Size(11, 12);
            this.lbl_OnSiteAll.TabIndex = 45;
            this.lbl_OnSiteAll.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 12);
            this.label6.TabIndex = 48;
            this.label6.Text = "Register(線上繳費)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 12);
            this.label8.TabIndex = 49;
            this.label8.Text = "Receipt 收據";
            // 
            // lbRegisterCount
            // 
            this.lbRegisterCount.AutoSize = true;
            this.lbRegisterCount.Location = new System.Drawing.Point(168, 167);
            this.lbRegisterCount.Name = "lbRegisterCount";
            this.lbRegisterCount.Size = new System.Drawing.Size(11, 12);
            this.lbRegisterCount.TabIndex = 50;
            this.lbRegisterCount.Text = "0";
            // 
            // lbl_RegisterAll
            // 
            this.lbl_RegisterAll.AutoSize = true;
            this.lbl_RegisterAll.Location = new System.Drawing.Point(278, 167);
            this.lbl_RegisterAll.Name = "lbl_RegisterAll";
            this.lbl_RegisterAll.Size = new System.Drawing.Size(11, 12);
            this.lbl_RegisterAll.TabIndex = 51;
            this.lbl_RegisterAll.Text = "0";
            // 
            // lbReceiptCount
            // 
            this.lbReceiptCount.AutoSize = true;
            this.lbReceiptCount.Location = new System.Drawing.Point(168, 112);
            this.lbReceiptCount.Name = "lbReceiptCount";
            this.lbReceiptCount.Size = new System.Drawing.Size(11, 12);
            this.lbReceiptCount.TabIndex = 52;
            this.lbReceiptCount.Text = "0";
            // 
            // lbl_ReceiptAll
            // 
            this.lbl_ReceiptAll.AutoSize = true;
            this.lbl_ReceiptAll.Location = new System.Drawing.Point(278, 112);
            this.lbl_ReceiptAll.Name = "lbl_ReceiptAll";
            this.lbl_ReceiptAll.Size = new System.Drawing.Size(11, 12);
            this.lbl_ReceiptAll.TabIndex = 53;
            this.lbl_ReceiptAll.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 12);
            this.label9.TabIndex = 54;
            this.label9.Text = "Vote 選票";
            // 
            // lbVoteCount
            // 
            this.lbVoteCount.AutoSize = true;
            this.lbVoteCount.Location = new System.Drawing.Point(168, 141);
            this.lbVoteCount.Name = "lbVoteCount";
            this.lbVoteCount.Size = new System.Drawing.Size(11, 12);
            this.lbVoteCount.TabIndex = 55;
            this.lbVoteCount.Text = "0";
            // 
            // lbl_VoteAll
            // 
            this.lbl_VoteAll.AutoSize = true;
            this.lbl_VoteAll.Location = new System.Drawing.Point(278, 141);
            this.lbl_VoteAll.Name = "lbl_VoteAll";
            this.lbl_VoteAll.Size = new System.Drawing.Size(11, 12);
            this.lbl_VoteAll.TabIndex = 56;
            this.lbl_VoteAll.Text = "0";
            // 
            // lbTip01
            // 
            this.lbTip01.AutoSize = true;
            this.lbTip01.Location = new System.Drawing.Point(10, 348);
            this.lbTip01.Name = "lbTip01";
            this.lbTip01.Size = new System.Drawing.Size(287, 12);
            this.lbTip01.TabIndex = 57;
            this.lbTip01.Text = "Tip:論文匯入前將資料庫TB_Paper的自動產生序號關閉";
            // 
            // lbTitle1
            // 
            this.lbTitle1.AutoSize = true;
            this.lbTitle1.Location = new System.Drawing.Point(15, 9);
            this.lbTitle1.Name = "lbTitle1";
            this.lbTitle1.Size = new System.Drawing.Size(29, 12);
            this.lbTitle1.TabIndex = 58;
            this.lbTitle1.Text = "任務";
            // 
            // lbTitle2
            // 
            this.lbTitle2.AutoSize = true;
            this.lbTitle2.Location = new System.Drawing.Point(150, 9);
            this.lbTitle2.Name = "lbTitle2";
            this.lbTitle2.Size = new System.Drawing.Size(53, 12);
            this.lbTitle2.TabIndex = 59;
            this.lbTitle2.Text = "任務進度";
            // 
            // lbTitle3
            // 
            this.lbTitle3.AutoSize = true;
            this.lbTitle3.Location = new System.Drawing.Point(249, 9);
            this.lbTitle3.Name = "lbTitle3";
            this.lbTitle3.Size = new System.Drawing.Size(53, 12);
            this.lbTitle3.TabIndex = 60;
            this.lbTitle3.Text = "任務總數";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 372);
            this.Controls.Add(this.lbTitle3);
            this.Controls.Add(this.lbTitle2);
            this.Controls.Add(this.lbTitle1);
            this.Controls.Add(this.lbTip01);
            this.Controls.Add(this.lbl_VoteAll);
            this.Controls.Add(this.lbVoteCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_ReceiptAll);
            this.Controls.Add(this.lbReceiptCount);
            this.Controls.Add(this.lbl_RegisterAll);
            this.Controls.Add(this.lbRegisterCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbOnSiteCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_OnSiteAll);
            this.Controls.Add(this.lbl_PaperAll);
            this.Controls.Add(this.lbPaperCount);
            this.Controls.Add(this.lbl_FeeAll);
            this.Controls.Add(this.lbFeeCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMemberPCount);
            this.Controls.Add(this.lbMemberGCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_MemberPAll);
            this.Controls.Add(this.lbl_MemberGAll);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_MemberPAll;
        private System.Windows.Forms.Label lbl_MemberGAll;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMemberGCount;
        private System.Windows.Forms.Label lbMemberPCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbFeeCount;
        private System.Windows.Forms.Label lbl_FeeAll;
        private System.Windows.Forms.Label lbl_PaperAll;
        private System.Windows.Forms.Label lbPaperCount;
        private System.Windows.Forms.Label lbOnSiteCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_OnSiteAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbRegisterCount;
        private System.Windows.Forms.Label lbl_RegisterAll;
        private System.Windows.Forms.Label lbReceiptCount;
        private System.Windows.Forms.Label lbl_ReceiptAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbVoteCount;
        private System.Windows.Forms.Label lbl_VoteAll;
        private System.Windows.Forms.Label lbTip01;
        private System.Windows.Forms.Label lbTitle1;
        private System.Windows.Forms.Label lbTitle2;
        private System.Windows.Forms.Label lbTitle3;
    }
}

