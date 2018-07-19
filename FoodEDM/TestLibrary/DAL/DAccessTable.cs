using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TestLibrary;
using TestLibrary.Common;
using System.Data.OleDb;

namespace TestLibrary.DAL
{
    public class DAccessTable
    {
        public DAccessTable() { } 

        #region
        #endregion

        #region  自訂方法

        #region  會員相關

        //SELECT *
        //FROM 團體會員
        //LEFT JOIN
        //(
        //  SELECT * FROM
        //  (SELECT * FROM TB_Member where MemberType='G'  )
        //  )AS Table2

        //ON 團體會員.MARK=Table2.MemberID

        /// <summary>
        /// 團體會員
        /// </summary>
        public DataSet GetACCMemberG()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT * FROM 團體會員 ");
            sb.AppendLine(" LEFT JOIN ");
            sb.AppendLine(" ( ");
            sb.AppendLine(" SELECT * FROM ");
            sb.AppendLine(" (SELECT * FROM TB_Member where MemberType='G'  ) ");
            sb.AppendLine(" )AS Table2 ");
            sb.AppendLine(" ON 團體會員.MARK=Table2.MemberID ; ");
            //string strTSQL = "select * from 團體會員";
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }


        
//SELECT *
//FROM 個人會員
//LEFT JOIN
//(
//  SELECT * FROM
//  (SELECT * FROM TB_Member where MemberType='P'  )
//  )AS Table2

//ON 個人會員.MARK=Table2.MemberID
//;
        /// <summary>
        /// 取得所有的個人會員
        /// </summary>
        public DataSet GetACCMemberP()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT * FROM 個人會員 ");
            sb.AppendLine(" LEFT JOIN ");
            sb.AppendLine(" ( ");
            sb.AppendLine(" SELECT * FROM ");
            sb.AppendLine(" (SELECT * FROM TB_Member where MemberType='P'  ) ");
            sb.AppendLine(" )AS Table2 ");
            sb.AppendLine(" ON 個人會員.MARK=Table2.MemberID order by MARK ; ");
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }

        #endregion

        /// <summary>
        /// 取得所有年份
        /// </summary>
        public DataSet GetYearList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select * from TB_Period ");
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }

        #region  論文相關

        /// <summary>
        /// 取得所有論文
        /// </summary>
        public DataSet GetPaperList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select * from TB_Paper ");
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 取得所有論文DomainSeq
        /// </summary>
        public DataSet GetPaperDomainSeqListByPaperID(int intPaperID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select * from TB_PaperDomainSeq where PaperID=" + intPaperID);
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 取得所有論文Suggestion
        /// </summary>
        public DataSet GetPaperSuggestionListByPaperID(int intPaperID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select * from TB_PaperSuggestion where PaperID=" + intPaperID);
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }


        #endregion

        #region  費用相關

        /// <summary>
        /// 取得所有Fee
        /// </summary>
        public DataSet GetFeeList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select * from TB_Fee where not RecDate is null");
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }

        #endregion

        #region  年會相關

        /// <summary>
        /// 取得所有現場會員
        /// </summary>
        public DataSet GetOnSiteList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select * from TB_OnSiteRegistration ");
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 取得線上報名者
        /// </summary>
        public DataSet GetRegister()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select * from TB_Register ");
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 取得所有收據
        /// </summary>
        public DataSet GetReceipt()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select * from TB_Receipt ");
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }

        /// <summary>
        /// 取得所有選票
        /// </summary>
        public DataSet GetVote()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select * from TB_Vote ");
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }
        

        #endregion

        /// <summary>
        /// 取得需要修改InDate的資料
        /// </summary>
        public DataSet GetACCMemberPInDate()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select * from 個人會員 where not  INDATE is null ");
            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLOle.QueryDS(cmd);
            return ds;
        }
        

        #endregion
    }
}
