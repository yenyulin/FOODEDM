using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 User
    /// </summary>
    public class BUser
    {
        public BUser() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MUser mod)
        {
            return new DAL.DUser().Add(mod);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        public bool Edit(Models.MUser mod)
        {
            return new DAL.DUser().Edit(mod);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(string strUserID)
        {
            return new DAL.DUser().Del(strUserID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MUser GetModel(string strUserID)
        {
            return new DAL.DUser().GetModel(strUserID);
        }

        /// <summary>
        /// 取得全部資料
        /// </summary>
        public List<Models.MUser> GetList()
        {
            return new DAL.DUser().GetList();
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 由帳號與密碼取得單筆User資料
        /// <summary>
        public Models.MUser GetByUserIDUserPassword(string strUserAccount, string strUserPassword)
        {
            return new DAL.DUser().GetByUserIDUserPassword(strUserAccount, strUserPassword);
        }

        /// <summary>
        /// 由UserID計算User筆數
        /// </summary>
        public int CountByUserID(string strUserid)
        {
            return new DAL.DUser().CountByUserID(strUserid);
        }


        #endregion
    }
}
