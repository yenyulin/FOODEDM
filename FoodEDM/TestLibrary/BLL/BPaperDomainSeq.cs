using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 PaperDomainSeq
    /// </summary>
    public class BPaperDomainSeq
    {
        public BPaperDomainSeq() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MPaperDomainSeq mod)
        {
            return new DAL.DPaperDomainSeq().Add(mod);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        public bool Edit(Models.MPaperDomainSeq mod)
        {
            return new DAL.DPaperDomainSeq().Edit(mod);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(int intPaperID)
        {
            return new DAL.DPaperDomainSeq().Del(intPaperID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MPaperDomainSeq GetModel(int intPaperID)
        {
            return new DAL.DPaperDomainSeq().GetModel(intPaperID);
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 以PaperID取得全部資料
        /// </summary>
        public List<Models.MPaperDomainSeq> GetListByPaperID(int intPaperID)
        {
            return new DAL.DPaperDomainSeq().GetListByPaperID(intPaperID);
        }

        /// <summary>
        /// 以PaperID刪除資料
        /// </summary>
        public bool DelByPaperID(int intPaperID)
        {
            return new DAL.DPaperDomainSeq().DelByPaperID(intPaperID);
        }

        #endregion
    }
}
