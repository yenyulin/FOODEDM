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


namespace MemberTrans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            TestLibrary.BLL.BAccessTable bll = new TestLibrary.BLL.BAccessTable();
            DataSet dsMemberG = bll.GetACCMemberG();
            DataSet dsMemberP = bll.GetACCMemberP();
            DataSet dsFee = bll.GetFeeList();
            DataSet dsPaper = bll.GetPaperList();

            DataSet dsOnSite = bll.GetOnSiteList();
            DataSet dsRegister = bll.GetRegister();
            DataSet dsReceipt = bll.GetReceipt();
            DataSet dsVote = bll.GetVote();

            int intMemberGCount = dsMemberG.Tables[0].Rows.Count;
            int intMemberPCount = dsMemberP.Tables[0].Rows.Count;
            int intFeeCount = dsFee.Tables[0].Rows.Count;
            int intPaperCount = dsPaper.Tables[0].Rows.Count;

            int intOnsite = dsOnSite.Tables[0].Rows.Count;
            int intRegister = dsRegister.Tables[0].Rows.Count;
            int intReceipt = dsReceipt.Tables[0].Rows.Count;
            int intVote = dsVote.Tables[0].Rows.Count;

            lbl_MemberGAll.Text = intMemberGCount.ToString();
            lbl_MemberPAll.Text = intMemberPCount.ToString();
            lbl_FeeAll.Text = intFeeCount.ToString();
            lbl_PaperAll.Text = intPaperCount.ToString();

            lbl_OnSiteAll.Text = intOnsite.ToString();
            lbl_RegisterAll.Text = intRegister.ToString();
            lbl_ReceiptAll.Text = intReceipt.ToString();
            lbl_VoteAll.Text = intVote.ToString();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //緊急修正用
            //#region  個人會員入會日期修正
            //TestLibrary.BLL.BAccessTable bll = new TestLibrary.BLL.BAccessTable();
            //DataSet dsMemberPInDate = bll.GetACCMemberPInDate();
            //SetMemberPInDate(dsMemberPInDate);
            
            //#endregion


            //BUTTON設定
            if (!backgroundWorker1.IsBusy)//如果DoWork處於不忙狀態，才執行該方法
            {
                //開始執行同步工作
                backgroundWorker1.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 在背景所執行的動作
        /// </summary>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                TestLibrary.BLL.BAccessTable bll = new TestLibrary.BLL.BAccessTable();

                #region  前置取得DataSet

                DataSet dsMemberG = bll.GetACCMemberG();
                DataSet dsMemberP = bll.GetACCMemberP();
                DataSet dsYear = bll.GetYearList();
                DataSet dsPaper = bll.GetPaperList();

                //年會相關
                DataSet dsOnSite=bll.GetOnSiteList();
                DataSet dsRegister = bll.GetRegister();
                DataSet dsReceipt = bll.GetReceipt();
                DataSet dsVote = bll.GetVote();

                //費用
                DataSet dsFee = bll.GetFeeList();

                BFeeP bFeeP = new BFeeP();
                bFeeP.DelAll();
                lbState.Invoke((Action<string>)SetStatus, "刪除foodorg所有個人費用資料");


                #endregion

                //團體會員
                SetMemberGTrans(dsMemberG);

                //個人會員
                SetMemberPTrans(dsMemberP);

                ///論文轉換
                SetPaperTrans(dsPaper);

                #region  年會部份

                ///收據
                SetReceiptTrans(dsReceipt);

                ///選票
                SetVoteTrans(dsVote);

                ///年會報名
                SetRegisterTrans(dsRegister);

                ///現場會員
                SetOnSiteRegistrationTrans(dsOnSite);

                #endregion

                ///Fee的費用轉換
                SetFeeTrans(dsFee);


                lbState.Invoke((Action<string>)SetStatus, "完成");
                string message = "轉換完成";
                string title = "完成";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    if (!backgroundWorker1.IsBusy)
                    {
                        //LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                lbState.Invoke((Action<string>)SetStatus, ex.ToString());
                //MessageBox.Show(this,ex.ToString);
            }
        }

        #region 資料匯入

        /// <summary>
        /// 團體會員匯入
        /// </summary>
        protected void SetMemberGTrans(DataSet dsMemberG)
        {
            //先刪除foodorg的memberG的所有資料
            //取得所有資料
            List<MMemberG> liFoodMemberG = new BMemberG().GetListByKeyword("", "全部", "全部");

            

            lbState.Invoke((Action<string>)SetStatus, "刪除FoodOrg團體會員資料");
            lbl_MemberGAll.Invoke((Action<string>)SetMemberGAll, liFoodMemberG.Count.ToString());

            int intDel = 0;
            foreach (MMemberG mod in liFoodMemberG)
            {
                new BMemberG().Del(mod.MemberGID);
                intDel++;
                lbMemberGCount.Invoke((Action<int>)SetMemberG, intDel);
            }
            new BMemberG().DelAllBusiness();

            if (dsMemberG.Tables[0].Rows.Count > 0)
            {
                lbState.Invoke((Action<string>)SetStatus, "從access取團體會員資料移到FoodOrg");
                lbl_MemberGAll.Invoke((Action<string>)SetMemberGAll, dsMemberG.Tables[0].Rows.Count.ToString());
                int i = 0;
                foreach (DataRow dr in dsMemberG.Tables[0].Rows)
                {
                    MMemberG mod = new MMemberG();

                    string strMemberGid = dr["MARK"].ToString();
                    if (strMemberGid.Length == 4)
                    {
                        strMemberGid = "0" + strMemberGid;
                    }
                    mod.MemberGID = strMemberGid;

                    if (dr["MemberPassword"].ToString().Length == 0)
                    {
                        //mod.MemberGassword = "000000";
                        mod.MemberGassword = TestLibrary.Common.Security.Encrypt("000000");
                    }
                    else
                    {
                        mod.MemberGassword = dr["MemberPassword"].ToString();
                    }
                    mod.NameC = dr["C_NAME"].ToString();
                    mod.CompanyID = dr["PID"].ToString();
                    //string strMemberClass = dr["MCLASS"].ToString();
                    mod.MemberClass = dr["MCLASS"].ToString();
                    mod.TEL = dr["TEL"].ToString();
                    mod.FAX = dr["FAX"].ToString();
                    mod.RegisterDate = DateTime.Parse(dr["INDATE"].ToString());


                    mod.ZipCode = dr["ZONE"].ToString();
                    mod.City = dr["ADDR_CITY"].ToString().Replace("台", "臺");
                    //mod.Area = dr["Area"].ToString();
                    mod.Area = "";
                    mod.Address = dr["ADDR_NUM"].ToString();

                    mod.ContactName = dr["CONN_MAN"].ToString();
                    mod.ContactTitle = dr["CONN_TITLE"].ToString();
                    mod.ContactTEL = dr["CONN_TEL"].ToString();
                    //mod.ContactMobile = dr["ContactMobile"].ToString();
                    mod.ContactMobile = "";
                    mod.ContactEmail = dr["EMAIL"].ToString();
                    mod.AgentName = dr["LEADER"].ToString();
                    mod.AgentTitle = dr["TITLE"].ToString();

                    //mod.AgentTEL = dr["AgentTEL"].ToString();
                    //mod.AgentMobile = dr["AgentMobile"].ToString();
                    //mod.AgentEmail = dr["AgentEmail"].ToString();
                    mod.AgentTEL = "";
                    mod.AgentMobile = "";
                    mod.AgentEmail = "";

                    mod.Memo = dr["Memo"].ToString();

                    //mod.Status = dr["Status"].ToString();
                    mod.Status = "正常";
                    mod.EDM = Convert.ToBoolean(dr["RECEIVE_MAIL"].ToString());
                    mod.CreateUser = "admin";
                    mod.UpdateUser = "admin";

                    new BMemberG().Add(mod);
                    i++;
                    lbMemberGCount.Invoke((Action<int>)SetMemberG, i);
                }
            }
        }

        /// <summary>
        /// 個人會員匯入
        /// </summary>
        protected void SetMemberPTrans(DataSet dsMemberP)
        {
            //先刪除foodorg的memberP的所有資料
            //取得所有資料
            List<MMemberP> liFoodMemberP = new BMemberP().GetListByKeyword("", "全部", "全部", "全部");
            lbState.Invoke((Action<string>)SetStatus, "刪除FoodOrg個人會員資料");
            lbl_MemberPAll.Invoke((Action<string>)SetMemberPAll, liFoodMemberP.Count.ToString());
            int intDelP = 0;
            foreach (MMemberP mod in liFoodMemberP)
            {
                new BMemberP().Del(mod.MemberPID);
                intDelP++;
                lbMemberPCount.Invoke((Action<int>)SetMemberP, intDelP);
            }
            //刪除所有Specialty
            new BMemberP().DelAllSpecialty();

            if (dsMemberP.Tables[0].Rows.Count > 0)
            {
                lbState.Invoke((Action<string>)SetStatus, "從access取個人會員資料移到FoodOrg");
                lbl_MemberPAll.Invoke((Action<string>)SetMemberPAll, dsMemberP.Tables[0].Rows.Count.ToString());
                int i = 0;
                foreach (DataRow dr in dsMemberP.Tables[0].Rows)
                {
                    MMemberP mod = new MMemberP();

                    if (!(dr["MARK"].ToString().IndexOf("-1")>0))
                    {
                        mod.MemberPID = SetMemberGed(dr["MARK"].ToString());
                        if (dr["MemberPassword"].ToString().Length == 0)
                        {
                            mod.MemberPassword =TestLibrary.Common.Security.Encrypt("000000");
                        }
                        else
                        {
                            mod.MemberPassword = dr["MemberPassword"].ToString();
                        }
                        mod.NameC = dr["C_NAME"].ToString();
                        mod.NameE = dr["E_NAME"].ToString();
                        mod.Email = dr["EMAIL"].ToString();
                        mod.PID = dr["PID"].ToString();
                        //SQLUtil.GetDateTime(dr["BIRTH"]);
                        //mod.Birthday = Convert.ToDateTime(dr["BIRTH"].ToString());
                        //這兩項 有可能為null
                        if (dr["BIRTH"].ToString().Length != 0)
                        {
                            mod.Birthday = Convert.ToDateTime(dr["BIRTH"].ToString());
                        }
                        if (dr["INDATE"].ToString().Length != 0)
                        {
                            mod.RegisterDate = DateTime.Parse(dr["INDATE"].ToString());
                        }
                        else
                        {
                            mod.RegisterDate = DateTime.Now;
                        }

                        mod.RegisterDate = DateTime.Now;
                        mod.Sex = dr["SEX"].ToString();
                        mod.Native = dr["NATIVE"].ToString();
                        string strMemberClass = "學生";
                        switch (dr["MCLASS"].ToString())
                        {
                            case "永":
                                strMemberClass = "永久";
                                break;
                            case "普":
                                strMemberClass = "普通";
                                break;
                        }
                        mod.MemberClass = strMemberClass;
                        mod.School = dr["EDUC"].ToString();
                        mod.CollegeDepartment = "";
                        mod.Education = dr["EDUCATION"].ToString();
                        mod.Job = dr["WORK"].ToString();
                        mod.JobTitle = dr["TITLE"].ToString();
                        mod.Student = bool.Parse(dr["STUDENT"].ToString());
                        //原本沒有手機
                        //mod.Mobile = dr["Mobile"].ToString();
                        mod.Mobile = "";

                        mod.TEL = dr["TEL"].ToString();
                        mod.FAX = dr["FAX"].ToString();

                        mod.ZipCodeH = dr["ZONE"].ToString();
                        mod.CityH = dr["ADDR_CITY"].ToString().Replace("台", "臺");
                        mod.AreaH = "";
                        mod.AddressH = dr["HOME"].ToString();


                        mod.ZipCode = "";
                        mod.City = "";
                        mod.Area = "";
                        mod.Address = "";

                        mod.SchoolConsent = "";
                        mod.StudentIDCard = "";
                        mod.StudentIDCardFileType = "";

                        mod.Memo = dr["MEMO"].ToString();
                        //mod.Status = dr["Status"].ToString();
                        mod.Status = "正常";
                        mod.EDM = Convert.ToBoolean(dr["RECEIVE_MAIL"].ToString());
                        mod.CreateUser = "admin";
                        mod.UpdateUser = "admin";

                        new BMemberP().Add(mod);
                        i++;
                        lbMemberPCount.Invoke((Action<int>)SetMemberP, i);
                    }
                }
            }
        }

        /// <summary>
        /// 論文匯入
        /// </summary>
        protected void SetPaperTrans(DataSet dsPaper)
        {
            //有三項要轉
            //1.paper
            //2.paperDomainSeq
            //3.PaperSuggestion
            TestLibrary.BLL.BAccessTable bll = new TestLibrary.BLL.BAccessTable();
            BPaper bPaper = new BPaper();
            //刪除所有paper

            lbState.Invoke((Action<string>)SetStatus, "刪除FoodOrg論文資料");
            bPaper.DelAll();
            bPaper.DelPaperSuggestionAll();
            bPaper.DelPaperDomainSeqAll();

            lbState.Invoke((Action<string>)SetStatus, "從access取論文資料移到FoodOrg");

            //1取得所有paper
            //DataSet dsPaper = new BAccessTable().GetPaperList();
            lbl_PaperAll.Invoke((Action<string>)SetPaperAll, dsPaper.Tables[0].Rows.Count.ToString());
            int intPaperCount = 1;
            foreach (DataRow dr in dsPaper.Tables[0].Rows)
            {
                MPaper mPaper = new MPaper();
                mPaper.PaperID = Convert.ToInt32(dr["PaperID"].ToString());

                

                mPaper.TWYear = SetTWYear(dr["Period"].ToString());
                mPaper.PaperTitle = dr["PaperTitle"].ToString();
                mPaper.PaperAuthor = dr["PaperAuthor"].ToString();
                mPaper.Company = dr["Company"].ToString();
                mPaper.SummaryC = dr["SummaryC"].ToString().Replace("\r\n", "");
                mPaper.SummaryE = dr["SummaryE"].ToString().Replace("\r\n","");

                mPaper.MemberType = dr["MemberType"].ToString();
                mPaper.MemberID = SetMemberGed(dr["MARK"].ToString());
                mPaper.Tel1 = dr["Tel1"].ToString();
                mPaper.Tel2 = dr["Tel2"].ToString();
                mPaper.Ext = dr["Ext"].ToString();
                mPaper.Fax1 = dr["Fax1"].ToString();
                mPaper.Fax2 = dr["Fax2"].ToString();
                mPaper.Email = dr["Email"].ToString();
                mPaper.UploadDate = Convert.ToDateTime(dr["UploadDate"].ToString());
                mPaper.PaperDomainID = dr["PaperDomainID"].ToString();
                mPaper.PublishType = dr["PublishType"].ToString();
                mPaper.Publish = Convert.ToBoolean(dr["Publish"].ToString());
                mPaper.FileExtension = dr["FileExtension"].ToString();
                mPaper.Examine = dr["Examine"].ToString();
                if (dr["ExamineDate"].ToString().Length != 0)
                {
                    mPaper.ExamineDate = Convert.ToDateTime(dr["ExamineDate"].ToString());
                }
                mPaper.PaperNo = dr["PaperNo"].ToString();
                bPaper.Add(mPaper);
                int intPaperID = mPaper.PaperID;

                //2.paperDomainSeq
                DataSet dsPaperDomainSeq = bll.GetPaperDomainSeqListByPaperID(Convert.ToInt32(dr["PaperID"].ToString()));
                foreach (DataRow drDomainSeq in dsPaperDomainSeq.Tables[0].Rows)
                {
                    MPaperDomainSeq mDomainSeq = new MPaperDomainSeq();
                    mDomainSeq.PaperID = intPaperID;
                    mDomainSeq.PaperDomainID = drDomainSeq["PaperDomainID"].ToString();
                    mDomainSeq.Seq = Convert.ToInt32(drDomainSeq["Seq"].ToString());
                    new BPaperDomainSeq().Add(mDomainSeq);
                }

                //3.PaperSuggestion
                DataSet dsPaperSuggestion = bll.GetPaperSuggestionListByPaperID(Convert.ToInt32(dr["PaperID"].ToString()));
                foreach (DataRow drSuggestion in dsPaperSuggestion.Tables[0].Rows)
                {
                    MPaperSuggestion mSuggestion = new MPaperSuggestion();
                    mSuggestion.PaperID = intPaperID;
                    mSuggestion.PaperSuggestion = drSuggestion["PaperSuggestion"].ToString();
                    mSuggestion.CreateDate = Convert.ToDateTime(drSuggestion["CreateDate"].ToString());
                    new BPaperSuggestion().Add(mSuggestion);
                }
                lbPaperCount.Invoke((Action<int>)SetPaper, intPaperCount);
                intPaperCount++;
            }
        }

        /// <summary>
        /// 收據匯入
        /// </summary>
        protected void SetReceiptTrans(DataSet dsReceipt)
        {
            BReceipt bReceipt = new BReceipt();
            //刪除所有Receipt
            lbState.Invoke((Action<string>)SetStatus, "刪除FoodOrg收據資料");
            bReceipt.DelAll();


            lbState.Invoke((Action<string>)SetStatus, "從access取收據資料移到FoodOrg");
            lbl_ReceiptAll.Invoke((Action<string>)SetReceiptAll, dsReceipt.Tables[0].Rows.Count.ToString());
            int intReceiptCount = 0;
            foreach (DataRow dr in dsReceipt.Tables[0].Rows)
            {
                MReceipt mod = new MReceipt();
                //民國和屆相差 59
                mod.TWYear = SetTWYear(dr["Period"].ToString());
                mod.MemberType = dr["MemberType"].ToString();
                mod.MemberID = SetMemberGed(dr["MemberID"].ToString());
                mod.ReceiptType = dr["ReceiptType"].ToString();
                mod.Fee = Convert.ToInt32(dr["Fee"].ToString());
                mod.ReceivedFromAppend = dr["ReceivedFromAppend"].ToString();
                mod.Remark = dr["Remark"].ToString();
                mod.CreateUser = dr["CreateUser"].ToString();
                mod.CreateDate = Convert.ToDateTime(dr["CreateDate"].ToString());

                string strCancelUser = dr["CancelUser"].ToString();
                string strCancelDate = dr["CancelDate"].ToString();

                if (strCancelUser.Length > 0)
                {
                    mod.CancelUser = strCancelUser;
                }
                if (strCancelDate.Length > 0)
                {
                    mod.CancelDate = Convert.ToDateTime(strCancelDate);
                }
                mod.Enable = Convert.ToBoolean(dr["Enable"].ToString());
                new BReceipt().Add(mod);

                intReceiptCount++;
                lbReceiptCount.Invoke((Action<int>)SetReceipt, intReceiptCount);
            }
        }

        /// <summary>
        /// 選票匯入
        /// </summary>
        protected void SetVoteTrans(DataSet dsVote)
        {
            BVote bVote = new BVote();
            //刪除所有Vote
            lbState.Invoke((Action<string>)SetStatus, "刪除FoodOrg選票資料");
            bVote.DelAll();

            lbState.Invoke((Action<string>)SetStatus, "從access取選票資料移到FoodOrg");
            lbl_VoteAll.Invoke((Action<string>)SetVoteAll, dsVote.Tables[0].Rows.Count.ToString());
            int intVoteCount = 0;
            foreach (DataRow dr in dsVote.Tables[0].Rows)
            {
                MVote mod = new MVote();
                mod.TWYear = SetTWYear(dr["Period"].ToString());
                mod.MemberID = SetMemberGed(dr["MemberID"].ToString());
                mod.AgentMemberID = dr["AgentMemberID"].ToString();
                mod.CreateDate = Convert.ToDateTime(dr["CreateDate"].ToString());
                mod.CreateUser = dr["CreateUser"].ToString();
                new BVote().Add(mod);
                intVoteCount++;
                lbVoteCount.Invoke((Action<int>)SetVote, intVoteCount);
            }
        }

        /// <summary>
        /// 年會報名匯入
        /// </summary>
        protected void SetRegisterTrans(DataSet dsRegister)
        {
            BRegister bRegister = new BRegister();
            //刪除所有年會報名
            lbState.Invoke((Action<string>)SetStatus, "刪除FoodOrg線上報名資料");
            bRegister.DelAll();

            lbState.Invoke((Action<string>)SetStatus, "從access取年會報名資料移到FoodOrg");
            lbl_RegisterAll.Invoke((Action<string>)SetRegisterAll, dsRegister.Tables[0].Rows.Count.ToString());
            int intRegisterCount = 0;
            foreach (DataRow dr in dsRegister.Tables[0].Rows)
            {
                MRegister mod = new MRegister();

                mod.TWYear = SetTWYear(dr["Period"].ToString());
                mod.MemberID = SetMemberGed(dr["MemberID"].ToString());
                //dr[""].ToString()

                mod.MemberType = dr["MemberType"].ToString();
                mod.RegisterName = dr["RegisterName"].ToString();

                //格式 03-5223191*327
                string strTEL = dr["Tel1"].ToString();
                if (strTEL.Trim().Length > 0)
                {
                    strTEL += "-";
                }
                strTEL += dr["Tel2"].ToString();
                if (dr["Ext"].ToString().Trim().Length > 0)
                {
                    strTEL += "*" + dr["Ext"].ToString().Trim();
                }
                mod.TEL = strTEL;

                mod.Email1 = dr["Email1"].ToString();
                mod.Email2 = dr["Email2"].ToString();
                mod.ZipCode = "";
                mod.City = "";
                mod.Area = "";
                mod.Address = dr["Address"].ToString();
                mod.MealType = dr["MealType"].ToString();
                mod.RegisterDate = Convert.ToDateTime(dr["RegisterDate"].ToString());
                mod.UpdateDate = Convert.ToDateTime(dr["UpdtaeDate"].ToString());

                new BRegister().Add(mod);
                intRegisterCount++;
                lbRegisterCount.Invoke((Action<int>)SetRegister, intRegisterCount);
            }
        }

        /// <summary>
        /// 現場會員匯入
        /// </summary>
        protected void SetOnSiteRegistrationTrans(DataSet dsOnSite)
        {
            BOnSiteRegistration bOnsite = new BOnSiteRegistration();
            //刪除所有年會報名資料
            lbState.Invoke((Action<string>)SetStatus, "刪除FoodOrg年會報到資料");
            bOnsite.DelAll();

            lbState.Invoke((Action<string>)SetStatus, "從access取年會報到資料移到FoodOrg");

            lbl_OnSiteAll.Invoke((Action<string>)SetOnSiteAll, dsOnSite.Tables[0].Rows.Count.ToString());
            int intOnSiteCount = 0;
            foreach (DataRow dr in dsOnSite.Tables[0].Rows)
            {
                if (!(dr["MemberID"].ToString().IndexOf("-1") > 0))
                {
                    MOnSiteRegistration mod = new MOnSiteRegistration();
                    mod.TWYear = SetTWYear(dr["Period"].ToString());
                    mod.MemberType = dr["MemberType"].ToString();
                    mod.MemberID = SetMemberGed(dr["MemberID"].ToString());
                    mod.RegisterName = dr["RegisterName"].ToString();
                    mod.Company = dr["Company"].ToString();
                    mod.Fee2 = Convert.ToInt32(dr["Fee1"].ToString());
                    mod.Fee3 = Convert.ToInt32(dr["Fee2"].ToString());
                    mod.PayType = dr["FeeType"].ToString();
                    mod.Attend = Convert.ToBoolean(dr["Attend"].ToString());
                    mod.MealType = dr["MealType"].ToString();
                    mod.CreateDate = Convert.ToDateTime(dr["CreateDate"].ToString());
                    mod.CreateUser = dr["CreateUser"].ToString();
                    mod.UpdateDate = Convert.ToDateTime(dr["UpdateDate"].ToString());
                    mod.UpdateUser = dr["UpdateUser"].ToString();


                    if (mod.MemberType == "P")
                    {
                        MFeeP mFee = new MFeeP();

                        mFee.MemberPID = mod.MemberID;
                        mFee.TWYear = mod.TWYear;
                        mFee.PayType = mod.PayType;
                        mFee.Fee1 = 0;
                        mFee.Fee2 = mod.Fee2;
                        mFee.Fee3 = mod.Fee3;
                        mFee.PayDate = mod.UpdateDate;
                        mFee.Remark = "";
                        mod.FeeID = new BFeeP().Add(mFee);
                    }

                    new BOnSiteRegistration().Add(mod);

                    intOnSiteCount++;
                    lbOnSiteCount.Invoke((Action<int>)SetOnSite, intOnSiteCount);
                }
            }
        }

        /// <summary>
        /// 費用匯入
        /// </summary>
        protected void SetFeeTrans(DataSet dsFee)
        {
            lbState.Invoke((Action<string>)SetStatus, "從access取費用資料移到FoodOrg");
            lbl_VoteAll.Invoke((Action<string>)SetVoteAll, dsFee.Tables[0].Rows.Count.ToString());
            int intFeeCount = 0;
            //TB_Fee在轉的時後，把orderid 放到新的TB_FeeP的時後，把OrderID放到Remark
            foreach (DataRow dr in dsFee.Tables[0].Rows)
            {
                if (!(dr["MemberID"].ToString().IndexOf("-1") > 0))
                {
                    MFeeP mod = new MFeeP();
                    mod.MemberPID = SetMemberGed(dr["MemberID"].ToString());
                    mod.TWYear = SetTWYear(dr["Period"].ToString());
                    if (dr["Store"].ToString().Length == 0)
                    {
                        mod.PayType = "虛擬帳戶";
                    }
                    else
                    {
                        mod.PayType = "超商條碼";
                    }
                    //Access為總計 只有三種金額 400 500 900
                    int intFeeTotalCount = Convert.ToInt32(dr["Fee"].ToString());
                    //switch(intFeeCount)
                    //{
                    //    case 400:
                    //        //
                    //        mod.Fee1 = 0;
                    //        break;
                    //    case 500:
                    //        //
                    //        mod.Fee1 = 0;
                    //        break;
                    //    case 900:
                    //        //
                    //        mod.Fee1 = 0;
                    //        break;
                    //}

                    int intPayType = Convert.ToInt32(dr["FeeType"].ToString());
                    switch (intPayType)
                    {
                        //常年會費+年會出席費
                        case 1:
                            //200 400 500 600 900 有這幾種價格
                            mod.Fee1 = 0;
                            switch (intFeeTotalCount)
                            {
                                case 200:
                                    mod.Fee1 = 0;
                                    mod.Fee2 = 200;
                                    mod.Fee3 = 0;
                                    break;
                                case 400:
                                    //
                                    if (mod.MemberPID.Length == 0)
                                    {
                                        mod.Fee1 = 0;
                                        mod.Fee2 = 400;
                                        mod.Fee3 = 0;
                                    }
                                    else
                                    {
                                        MMemberP Member = new BMemberP().GetModel(mod.MemberPID);
                                        if (Member == null)
                                        {
                                            mod.Fee1 = 0;
                                            mod.Fee2 = 400;
                                            mod.Fee3 = 0;
                                        }
                                        else
                                        {
                                            if (Member.MemberClass == "永久")
                                            {
                                                mod.Fee1 = 0;
                                                mod.Fee2 = 0;
                                                mod.Fee3 = 400;
                                            }
                                            else
                                            {
                                                mod.Fee1 = 0;
                                                mod.Fee2 = 200;
                                                mod.Fee3 = 200;
                                            }
                                        }
                                    }
                                    break;
                                case 500:
                                    //
                                    mod.Fee1 = 0;
                                    if (mod.MemberPID == "10980" | mod.MemberPID == "11048" | mod.MemberPID == "11083" | mod.MemberPID == "05862")
                                    {
                                        mod.Fee2 = 300;
                                        mod.Fee3 = 200;
                                    }
                                    else
                                    {
                                        mod.Fee2 = 500;
                                        mod.Fee3 = 0;
                                    }
                                    break;
                                case 600:
                                    //
                                    mod.Fee1 = 0;
                                    mod.Fee2 = 200;
                                    mod.Fee3 = 400;
                                    break;
                                case 900:
                                    //
                                    mod.Fee1 = 0;
                                    mod.Fee2 = 500;
                                    mod.Fee3 = 400;
                                    break;
                            }
                            break;
                        //常年會費
                        case 2:
                            //
                            mod.Fee1 = 0;
                            mod.Fee2 = intFeeTotalCount;
                            mod.Fee3 = 0;
                            break;
                        //年會出席費
                        case 3:
                            //
                            mod.Fee1 = 0;
                            mod.Fee2 = 0;
                            mod.Fee3 = intFeeTotalCount;
                            break;
                    }

                    mod.PayDate = Convert.ToDateTime(dr["PayDate"].ToString());
                    mod.Remark = dr["OrderID"].ToString();
                    //dr["RecDate"].ToString();
                    new BFeeP().Add(mod);
                    intFeeCount++;
                    lbVoteCount.Invoke((Action<int>)SetFee, intFeeCount);
                }
            }
        }

        /// <summary>
        /// 個人會員匯入
        /// </summary>
        protected void SetMemberPInDate(DataSet dsMemberPInDate)
        {
            //先刪除foodorg的memberP的所有資料
            //取得所有資料

            if (dsMemberPInDate.Tables[0].Rows.Count > 0)
            {
                lbState.Invoke((Action<string>)SetStatus, "從access取個人會員資料移到FoodOrg");
                lbl_MemberPAll.Invoke((Action<string>)SetMemberPAll, dsMemberPInDate.Tables[0].Rows.Count.ToString());
                int i = 0;
                foreach (DataRow dr in dsMemberPInDate.Tables[0].Rows)
                {
                    string strMemberPID = SetMemberGed(dr["MARK"].ToString());
                    MMemberP mod = new BMemberP().GetModel(strMemberPID);

                    if (mod != null)
                    {
                        if (dr["INDATE"].ToString().Length != 0)
                        {
                            try
                            {
                                mod.RegisterDate = DateTime.Parse(dr["INDATE"].ToString());
                            }
                            catch
                            {
                                string s = "";
                            }
                        }
                        new BMemberP().Edit(mod);
                        i++;
                    }
                    lbMemberPCount.Invoke((Action<int>)SetMemberP, i);

                }
            }
        }

        #endregion

        #region 取得資料補助相關

        /// <summary>
        /// 設定民國
        /// </summary>
        protected int SetTWYear(string strPeriod)
        {
            //民國和屆相差 59
            int intTWYear = Convert.ToInt32(strPeriod);
            return intTWYear + 59;
        }

        /// <summary>
        /// 設定會員序號
        /// </summary>
        protected string SetMemberGed(string strMemberGed)
        {

            if (strMemberGed.Length == 4)
            {
                strMemberGed = "0" + strMemberGed;
            }
            return strMemberGed;
        }

        /// <summary>
        /// 用linq取回年份(TWYear)
        /// </summary>
        private int GetYear(DataSet ds, string strPeriodID)
        {
            DataTable Periods = ds.Tables[0];
            EnumerableRowCollection<DataRow> query = from Period in Periods.AsEnumerable()
                                                     where Period.Field<int>("Period") == Convert.ToInt32(strPeriodID)
                                                     select Period;

            IEnumerable<DataRow> rows = from row in query
                                        select row;
            int intYear=0;
            foreach (DataRow row in rows)
            {
                //取得資料
                intYear = Convert.ToInt32(row["PeriodYear"].ToString());
            }
            return intYear;
        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //接收DoWork传送过来的数据,并在界面上显示
            if (e.UserState.ToString() == "")
            {
                //UpdateStateLabel(e.ProgressPercentage);
            }
            else
            {
                //this.lbl_MemberGAll.Text = e.UserState.ToString();
            }
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }


        #region  畫面相關

        #region  MemberG

        /// <summary>
        /// 設定memberG的進度
        /// </summary>
        private void SetMemberG(int intValue)
        {
            lbMemberGCount.Text = intValue.ToString();
        }


        /// <summary>
        /// 設定memberG的總數
        /// </summary>
        private void SetMemberGAll(string stringAll)
        {
            lbl_MemberGAll.Text = stringAll;
        }

        #endregion

        #region  MemberP

        /// <summary>
        /// 設定memberP的進度
        /// </summary>
        private void SetMemberP(int intValue)
        {
            lbMemberPCount.Text = intValue.ToString();
        }

        /// <summary>
        /// 設定memberP的總數
        /// </summary>
        private void SetMemberPAll(string stringAll)
        {
            lbl_MemberPAll.Text = stringAll;
        }

        #endregion

        #region  現場會員

        #region  OnSite
        
        /// <summary>
        /// 設定OnSite的進度
        /// </summary>
        private void SetOnSite(int intValue)
        {
            lbOnSiteCount.Text = intValue.ToString();
        }

        /// <summary>
        /// 設定OnSite的總數
        /// </summary>
        private void SetOnSiteAll(string stringAll)
        {
            lbl_OnSiteAll.Text = stringAll;
        }

        #endregion

        #region  Register

        /// <summary>
        /// 設定Register的進度
        /// </summary>
        private void SetRegister(int intValue)
        {
            lbRegisterCount.Text = intValue.ToString();
        }

        /// <summary>
        /// 設定Register的總數
        /// </summary>
        private void SetRegisterAll(string stringAll)
        {
            lbl_RegisterAll.Text = stringAll;
        }

        
        #endregion

        #region  Receipt

        /// <summary>
        /// 設定Receipt的進度
        /// </summary>
        private void SetReceipt(int intValue)
        {
            lbReceiptCount.Text = intValue.ToString();
        }
        
        /// <summary>
        /// 設定Receipt的總數
        /// </summary>
        private void SetReceiptAll(string stringAll)
        {
            lbl_ReceiptAll.Text = stringAll;
        }
        
        #endregion

        #region  Vote

        /// <summary>
        /// 設定Vote的進度
        /// </summary>
        private void SetVote(int intValue)
        {
            lbVoteCount.Text = intValue.ToString();
        }
        
        /// <summary>
        /// 設定Vote的總數
        /// </summary>
        private void SetVoteAll(string stringAll)
        {
            lbl_VoteAll.Text = stringAll;
        }
        
        #endregion

        #endregion

        #region  Fee

        /// <summary>
        /// 設定Fee的進度
        /// </summary>
        private void SetFee(int intValue)
        {
            lbFeeCount.Text = intValue.ToString();
        }

        /// <summary>
        /// 設定Fee的總數
        /// </summary>
        private void SetFeeAll(string stringAll)
        {
            lbl_FeeAll.Text = stringAll;
        }

        #endregion

        #region  Paper

        /// <summary>
        /// 設定Paper的進度
        /// </summary>
        private void SetPaper(int intValue)
        {
            lbPaperCount.Text = intValue.ToString();
        }

        /// <summary>
        /// 設定Paper的總數
        /// </summary>
        private void SetPaperAll(string stringAll)
        {
            lbl_PaperAll.Text = stringAll;
        }

        #endregion


        ///// <summary>
        ///// 設定進度
        ///// </summary>
        //private void SetProgress(Label lb, int intValue)
        //{
        //    lb.Text = intValue.ToString();
        //}

        ///// <summary>
        ///// 設定的總數
        ///// </summary>
        //private void SeProgressAll(Label lb,string stringAll)
        //{
        //    lb.Text = stringAll;
        //}

        /// <summary>
        /// 設定Status的定義
        /// </summary>
        private void SetStatus(string strState)
        {
            lbState.Text = strState;
        }

        #endregion

        /// <summary>
        /// 資料庫輸入值的Check
        /// </summary>
        /// <param name="obj">資料庫輸入值</param>
        /// <returns>確認後的資料庫輸入值</returns>
        public object CheckDBValue(object obj)
        {
            if (obj == null)
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }
    }
}
