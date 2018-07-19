using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 Paper
    /// </summary>
    public class BPaper
    {
        public BPaper() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MPaper mod)
        {
            return new DAL.DPaper().Add(mod);
        }


        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(int intPaperID)
        {
            return new DAL.DPaper().Del(intPaperID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MPaper GetModel(int intPaperID)
        {
            return new DAL.DPaper().GetModel(intPaperID);
        }

        #endregion

        #region  自訂方法


        /// <summary>
        /// 刪除全部paper資料
        /// </summary>
        public bool DelAll()
        {
            return new DAL.DPaper().DelPaperAll();
        }

        /// <summary>
        /// 刪除PaperSuggestion全部資料
        /// <summary>
        public bool DelPaperSuggestionAll()
        {
            return new DAL.DPaper().DelPaperSuggestionAll();
        }

        /// <summary>
        /// 刪除PaperDomainSeq全部資料
        /// <summary>
        public bool DelPaperDomainSeqAll()
        {
            return new DAL.DPaper().DelPaperDomainSeqAll();
        }

        #endregion
    }
}
