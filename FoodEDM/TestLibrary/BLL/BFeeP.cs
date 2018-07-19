using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 FeeP
    /// </summary>
    public class BFeeP
    {
        public BFeeP() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MFeeP mod)
        {
            return new DAL.DFeeP().Add(mod);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        public bool Edit(Models.MFeeP mod)
        {
            return new DAL.DFeeP().Edit(mod);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(int intFeePID)
        {
            return new DAL.DFeeP().Del(intFeePID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MFeeP GetModel(int intFeePID)
        {
            return new DAL.DFeeP().GetModel(intFeePID);
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 刪除全部資料
        /// <summary>
        public bool DelAll()
        {
            return new DAL.DFeeP().DelAll();
        }

        #endregion
    }
}
