using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 Receipt
    /// </summary>
    public class BReceipt
    {
        public BReceipt() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MReceipt mod)
        {
            return new DAL.DReceipt().Add(mod);
        }

        ///// <summary>
        ///// 修改資料
        ///// </summary>
        //public bool Edit(Models.MReceipt mod)
        //{
        //    return new DAL.DReceipt().Edit(mod);
        //}

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(int intReceiptID)
        {
            return new DAL.DReceipt().Del(intReceiptID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MReceipt GetModel(int intReceiptID)
        {
            return new DAL.DReceipt().GetModel(intReceiptID);
        }

        ///// <summary>
        ///// 取得全部資料
        ///// </summary>
        //public List<Models.MReceipt> GetList()
        //{
        //    return new DAL.DReceipt().GetList();
        //}

        #endregion

        #region  自訂方法

        /// <summary>
        /// 刪除Receipt全部資料
        /// <summary>
        public bool DelAll()
        {
            return new DAL.DReceipt().DelAll();
        }

        #endregion
    }
}
