using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 Register
    /// </summary>
    public class BRegister
    {
        public BRegister() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MRegister mod)
        {
            return new DAL.DRegister().Add(mod);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        public bool Edit(Models.MRegister mod)
        {
            return new DAL.DRegister().Edit(mod);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(int intRegisterID)
        {
            return new DAL.DRegister().Del(intRegisterID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MRegister GetModel(int intRegisterID)
        {
            return new DAL.DRegister().GetModel(intRegisterID);
        }

        ///// <summary>
        ///// 取得全部資料
        ///// </summary>
        //public List<Models.MRegister> GetList()
        //{
        //    return new DAL.DRegister().GetList();
        //}

        #endregion

        #region  自訂方法

        /// <summary>
        /// 刪除Register全部資料
        /// <summary>
        public bool DelAll()
        {
            return new DAL.DRegister().DelAll();
        }

        #endregion
    }
}
