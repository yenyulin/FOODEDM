using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLibrary;
using TestLibrary.BLL;
//using TestLibrary.Common;
using TestLibrary.DAL;
using TestLibrary.Models;
using System.Threading;
using System.IO;

namespace FoodEDM
{
    public partial class SendEDM : Form
    {
        private int _intError;
        /// <summary>
        /// 失敗次數
        /// </summary>
        public int intError
        {
            set { _intError = value; }
            get { return _intError; }
        }

        public SendEDM()
        {
            InitializeComponent();
        }

        //是否需要暂停操作
        private bool isSuspend;
        //宣告 _Limit 變數，並且設定初值
        private int _Limit = 10001;
        //EDM內容
        //private readonly string strEDMPath = @"D:\FST\DATA\";
        private readonly string strEDMPath = @"D:\FoodEDM\";
        

        private readonly string strEDMFile = "NormalEDM.htm";

        private void SendEDM_Load(object sender, EventArgs e)
        {
            checkedListBox1.SelectionMode = SelectionMode.None;
            intError = 0;
            LoadData();
        }

        private void LoadData()
        {
            //因為重置而加的
            progressBar1.Value = 0;
            btnStartBackgroundWork.Text = "寄信";
            checkedListBox1.Items.Clear();

            //設定是否暫停
            isSuspend = true;
            backgroundWorker1.WorkerReportsProgress = true;//声明异步执行的时候可以报告进度
            backgroundWorker1.WorkerSupportsCancellation = true;//声明可以异步取消

            //BUTTON設定
            this.btnStartBackgroundWork.Enabled = true;
            this.btnCancelBackgroundWork.Enabled = false;
            //this.btnTempStop.Enabled = false;

            try
            {
                //取得寄信名單
                List<TestLibrary.Models.MEDM> li = new TestLibrary.BLL.BEDM().GetList();
                int intSelect = 0;
                if (li.Count > 0)
                {
                    
                    foreach (TestLibrary.Models.MEDM mod in li)
                    {
                        //listBox1.Items.Add(mod.NameC);
                        checkedListBox1.Items.Add(mod.NameC + " " + mod.Email);
                        if (mod.IsSend)
                        {
                            checkedListBox1.SetItemChecked(checkedListBox1.Items.Count - 1, true);
                            intSelect++;
                        }
                        else
                        {
                            checkedListBox1.SetItemChecked(checkedListBox1.Items.Count - 1, false);
                        }
                    }
                }
                //設定百分比
                _Limit = li.Count;
                lbPrecent.Text = intSelect.ToString() + " / " + _Limit;

                double doui = Convert.ToDouble(intSelect);
                double douAll = Convert.ToDouble(_Limit);
                double douPercent = Math.Round(doui / douAll, 2);
                int intcorrect = Convert.ToInt32(Math.Round(douPercent * 100));
                decimal dec = (Convert.ToDecimal(intSelect) / Convert.ToDecimal(_Limit)) * 100;
                lbl_State.Text = intcorrect.ToString() + "%";
                progressBar1.Value = intcorrect;
                //lbl_State.Invoke((Action<int>)UpdateStateLabel, intcorrect);
                //取得edm內容
                GetEDMContent();         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        /// <summary>
        /// 取得edm的內容
        /// </summary>
        private void GetEDMContent()
        {
            string strHTML = string.Empty;
            //準備讀取資料
            using (FileStream source = new FileStream(strEDMPath + strEDMFile, FileMode.Open, FileAccess.Read))
            {
                System.IO.Stream stream = source;
                //設定編碼方式
                //System.IO.StreamReader StreamReader = new StreamReader(stream, System.Text.Encoding.UTF8);
                System.IO.StreamReader StreamReader = new StreamReader(stream, System.Text.Encoding.GetEncoding(950));
                strHTML = StreamReader.ReadToEnd();
                webBrowser1.DocumentText = strHTML.ToString();
            }
            //FileStream source = new FileStream(strEDMPath + strEDMFile, FileMode.Open, FileAccess.Read);
            //webBrowser1.DocumentStream = source;
        }

        /// <summary>
        /// 在背景所執行的動作
        /// </summary>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try 
            {
                if (backgroundWorker1.CancellationPending)
                {
                    //直接告诉程序已经执行完了，在实际的项目中，我们可以在界面显示“强行终止”
                    backgroundWorker1.ReportProgress(0, "强行终止");
                    return;
                }
                //先取得
                TestLibrary.BLL.BEDM bll = new TestLibrary.BLL.BEDM();
                DataSet ds = bll.GetEDMList();

                //信件內容
                string strContent;
                using (FileStream source = new FileStream(strEDMPath + strEDMFile, FileMode.Open, FileAccess.Read))
                {
                    System.IO.Stream stream = source;
                    System.IO.StreamReader StreamReader = new StreamReader(stream, System.Text.Encoding.GetEncoding(950));
                    strContent = StreamReader.ReadToEnd();
                }

                //信件標題
                string strSubject = tbSubject.Text.Trim();

                int i = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    if (backgroundWorker1.CancellationPending)
                    {
                        //e.Cancel = true;
                        backgroundWorker1.ReportProgress(0, "");
                        return;
                    }
                    else
                    {
                        //開始寄信
                        if (!Convert.ToBoolean(dr["IsSend"]))
                        {
                            while (isSuspend)
                            {
                                Thread.Sleep(50);
                            }
                            Thread.Sleep(60*1000);

                            //寄件人
                            //string strSendMan = "alex.lin@ajaxsoft.com.tw";
                            string strSendMan = dr["Email"].ToString();
                            bool IsSend = TestLibrary.Common.Util.SendMail(strSendMan, strSubject, strContent);
                            //bool IsSend = true;
                            if (IsSend)
                            {
                                //如果寄出成功，勾選成功
                                checkedListBox1.Invoke((Action<int>)cbCheck, i);

                                //更新狀態到Sql server
                                string strMemberID = dr["MemberID"].ToString();
                                bll.EditByID(strMemberID);
                            }
                            else
                            {
                                intError++;
                                if (intError == 10)
                                {
                                    intError = 0;
                                    Thread.Sleep(300*1000);
                                }
                            }
                        }

                        //向主线程报告进度(我们将i当作进度传递给主线程，当循环1次，我们就当做完成1%的工作，并报告给主线程)
                        double doui = Convert.ToDouble(i + 1);
                        double douAll = Convert.ToDouble(_Limit);
                        double douPercent = Math.Round(doui / douAll, 2);
                        backgroundWorker1.ReportProgress(Convert.ToInt32(Math.Round(douPercent * 100)), "");
                        lbPrecent.Invoke((Action<int>)SetPrecent, i);
                        i++;
                    }
                }

                string message = "寄信完成";
                string title = "完成";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    if (!backgroundWorker1.IsBusy)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                if (backgroundWorker1.IsBusy)//如果DoWork处于忙状态，才执行该方法
                {
                    backgroundWorker1.CancelAsync();
                    btnStartBackgroundWork.Enabled = false;
                    bool IsCancel = backgroundWorker1.CancellationPending;
                    //MessageBox.Show("已取消寄信");
                }
                DialogResult result = MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }


        /// <summary>
        /// 設定checkbox的選取
        /// </summary>
        private void cbCheck(int i)
        {
            checkedListBox1.SetItemChecked(i, true);
        }

        /// <summary>
        /// 設定百分比圖示
        /// </summary>
        private void SetPrecent(int intValue)
        {
            lbPrecent.Text = intValue+1 + " / " + _Limit;
        }

        /// <summary>
        /// backgroundWorker的核心事件2，用于接收DoWork方法执行过程中的情况
        /// </summary>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //接收DoWork传送过来的数据,并在界面上显示
            if (e.UserState.ToString() == "")
            {
                UpdateStateLabel(e.ProgressPercentage);
                UpdateProgressBar(e.ProgressPercentage);
            }
            else
            {
                this.lbl_State.Text = e.UserState.ToString();
            }
        }

        /// <summary>
        /// 更新ScriptLabel
        /// </summary>
        private void upDateToolLabel(int intSelect)
        {
            toolStripStatusLabel1.Text = checkedListBox1.Items[intSelect].ToString(); ;
        }

        /// <summary>
        /// 設定狀態 label的數字
        /// </summary>
        private void UpdateStateLabel(int value)
        {
            this.lbl_State.Text = value.ToString() + "%";
        }

        //更新 ProgressBar
        private void UpdateProgressBar(int value)
        {
            toolStripProgressBar1.Value = value;
            progressBar1.Value = value;
        }

        /// <summary>
        /// backgroundWorker的核心事件3，当DoWork方法执行完毕时调用
        /// </summary>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStartBackgroundWork.Text = "寄信";

            ////BUTTON設定
            this.btnStartBackgroundWork.Enabled = true;
            this.btnCancelBackgroundWork.Enabled = false;
        }

        /// <summary>
        /// 執行寄信
        /// </summary>
        private void btnStartBackgroundWork_Click(object sender, EventArgs e)
        {
            //this.btnTempStop.Enabled = true;
            if (tbSubject.Text.Trim().Length != 0)
            {
                //BUTTON設定
                this.btnCancelBackgroundWork.Enabled = true;
                if (isSuspend)
                {
                    isSuspend = false;
                    btnStartBackgroundWork.Text = "Pause";
                    //btnTempStop.Text = "Pause";
                    if (!backgroundWorker1.IsBusy)//如果DoWork处于不忙状态，才执行该方法
                    {
                        //開始執行同步工作
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else
                {
                    isSuspend = true;
                    btnStartBackgroundWork.Text = "Continue";
                }
            }
            else
            {
                MessageBox.Show("請輸入標題");
                
            }
        }

        /// <summary>
        /// 取消寄信
        /// </summary>
        private void btnCancelBackgroundWork_Click(object sender, EventArgs e)
        {
            isSuspend = false;
            string message = "是否取消寄信?";
            string title = "確認";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (backgroundWorker1.IsBusy)//如果DoWork处于忙状态，才执行该方法
                {
                    backgroundWorker1.CancelAsync();
                    btnStartBackgroundWork.Enabled = false;
                    bool IsCancel = backgroundWorker1.CancellationPending;
                    MessageBox.Show("已取消寄信");
                }
                
                //backgroundWorker1.CancelAsync();
                //bool IsCancel = backgroundWorker1.CancellationPending;
                //btnStartBackgroundWork.Enabled = false;
                ////isSuspend = false;
                ////btnStartBackgroundWork.Enabled = true;
                //MessageBox.Show("已取消寄信");
            }
            else
            {
                btnStartBackgroundWork.Enabled = true;
            }
            LoadData();

            //if (backgroundWorker1.IsBusy)//如果DoWork处于忙状态，才执行该方法
            //{
            //    //开始执行异步工作
            //    backgroundWorker1.CancelAsync();
            //    btnStartBackgroundWork.Enabled = true;
            //    btnStartBackgroundWork.Enabled = true;
            //}
        }

        /// <summary>
        /// 重置(把IsSend通通改為flase)
        /// </summary>
        private void btnReSet_Click(object sender, EventArgs e)
        {

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show("確認是否重置?", "確認", buttons);
            if (result == DialogResult.OK)
            {
                string strMessage = "";
                try
                {
                    List<TestLibrary.Models.MEDM> li = new TestLibrary.BLL.BEDM().GetList();
                    foreach (TestLibrary.Models.MEDM mod in li)
                    {
                        mod.IsSend = false;
                        new TestLibrary.BLL.BEDM().Edit(mod); ;
                    }
                    strMessage = "重置成功";
                    LoadData();
                }
                catch (Exception ex)
                {
                    strMessage = ex.ToString();
                }
                finally
                {
                    MessageBox.Show(strMessage);
                }    
            }            
        }
        
        /// <summary>
        /// 匯入edm
        /// </summary>
        private void btnImportEDM_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(strEDMPath))
            {
                System.IO.Directory.CreateDirectory(strEDMPath);
            }
            string strPath = "";
            string strFilename = "";
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog(this) == DialogResult.OK)
            {
                strPath = file.InitialDirectory;
                strFilename = file.FileName;
                string[] strFile = strFilename.Split('.');
                if (strFile[1].ToString() == "htm")
                {
                    //處理檔案部份
                    File.Delete(strEDMPath + strEDMFile);
                    File.Copy(strPath + strFilename, strEDMPath + strEDMFile);

                     string message = "匯入完成";
                    string title = "匯入";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.OK)
                    {
                        //DoWork不忙，才可關閉視窗
                        if (!backgroundWorker1.IsBusy)
                        {
                            GetEDMContent();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("請選擇正確檔案");
                }                
            }
            
        }

        /// <summary>
        /// 匯入email
        /// </summary>
        private void btnImportEmail_Click(object sender, EventArgs e)
        {
            lbPrecent.Visible = false;
            lbl_State.Visible = false;
            try
            {
                new BEDM().ReSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            lbPrecent.Visible = true;
            lbl_State.Visible = true;
            LoadData();
        }

        /// <summary>
        /// 關閉
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            isSuspend = false;
            string message = "確定關閉視窗?";
            string title = "確認";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                //DoWork不忙，才可關閉視窗
                if (!backgroundWorker1.IsBusy)
                {
                    //關閉視窗
                    this.Close();
                }
                else
                {
                    MessageBox.Show("請先按下「取消」停止程式運行後再關閉", "警告", buttons);
                }
            }
        }


    }
}
