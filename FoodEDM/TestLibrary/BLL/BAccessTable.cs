using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;


namespace TestLibrary.BLL
{
    public class BAccessTable
    {
        public BAccessTable() { }

        #region  自訂方法

        #endregion

        #region  自訂方法
        
        /// <summary>
        /// 團體會員
        /// </summary>
        public DataSet GetACCMemberG()
        {
            return new DAL.DAccessTable().GetACCMemberG();
        }

        /// <summary>
        /// 取得所有的個人會員
        /// </summary>
        public DataSet GetACCMemberP()
        {
            return new DAL.DAccessTable().GetACCMemberP();
        }

        /// <summary>
        /// 取得所有年份
        /// </summary>
        public DataSet GetYearList()
        {
            return new DAL.DAccessTable().GetYearList();
        }

        #region  論文相關

        /// <summary>
        /// 取得所有論文
        /// </summary>
        public DataSet GetPaperList()
        {
            return new DAL.DAccessTable().GetPaperList();
        }

        /// <summary>
        /// 取得所有論文DomainSeq
        /// </summary>
        public DataSet GetPaperDomainSeqListByPaperID(int intPaperID)
        {
            return new DAL.DAccessTable().GetPaperDomainSeqListByPaperID(intPaperID);
        }

        /// <summary>
        /// 取得所有論文Suggestion
        /// </summary>
        public DataSet GetPaperSuggestionListByPaperID(int intPaperID)
        {
            return new DAL.DAccessTable().GetPaperSuggestionListByPaperID(intPaperID);
        }

        #endregion

        #region  fee相關

        /// <summary>
        /// 取得所有Fee
        /// </summary>
        public DataSet GetFeeList()
        {
            return new DAL.DAccessTable().GetFeeList();
        }

        #endregion


        #region  年會相關

        /// <summary>
        /// 取得所有現場會員
        /// </summary>
        public DataSet GetOnSiteList()
        {
            return new DAL.DAccessTable().GetOnSiteList();
        }

        /// <summary>
        /// 取得線上報名者
        /// </summary>
        public DataSet GetRegister()
        {
            return new DAL.DAccessTable().GetRegister();
        }

        /// <summary>
        /// 取得所有收據
        /// </summary>
        public DataSet GetReceipt()
        {
            return new DAL.DAccessTable().GetReceipt();
        }

        /// <summary>
        /// 取得所有選票
        /// </summary>
        public DataSet GetVote()
        {
            return new DAL.DAccessTable().GetVote();
        }
        #endregion

        /// <summary>
        /// 取得需要修改InDate的資料
        /// </summary>
        public DataSet GetACCMemberPInDate()
        {
            return new DAL.DAccessTable().GetACCMemberPInDate();
        }

        #endregion
    }
}
