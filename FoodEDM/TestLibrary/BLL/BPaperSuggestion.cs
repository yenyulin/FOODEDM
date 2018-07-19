using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 PaperSuggestion
    /// </summary>
    public class BPaperSuggestion
    {
        public BPaperSuggestion() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MPaperSuggestion mod)
        {
            return new DAL.DPaperSuggestion().Add(mod);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        public bool Edit(Models.MPaperSuggestion mod)
        {
            return new DAL.DPaperSuggestion().Edit(mod);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(int intPaperSuggestionID)
        {
            return new DAL.DPaperSuggestion().Del(intPaperSuggestionID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MPaperSuggestion GetModel(int intPaperSuggestionID)
        {
            return new DAL.DPaperSuggestion().GetModel(intPaperSuggestionID);
        }

      

        #endregion

        #region  自訂方法

        /// <summary>
        /// 以PaperID取得全部資料
        /// </summary>
        public List<Models.MPaperSuggestion> GetListByPaperID(int intPaperID)
        {
            return new DAL.DPaperSuggestion().GetListByPaperID(intPaperID);
        }

        /// <summary>
        /// 以PaperID刪除資料
        /// </summary>
        public bool DelByPaperID(int intPaperID)
        {
            return new DAL.DPaperSuggestion().DelByPaperID(intPaperID);
        }

        #endregion
    }
}
