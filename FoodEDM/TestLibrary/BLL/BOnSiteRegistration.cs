using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 OnSiteRegistration
    /// </summary>
    public class BOnSiteRegistration
    {
        public BOnSiteRegistration() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MOnSiteRegistration mod)
        {
            return new DAL.DOnSiteRegistration().Add(mod);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        public bool Edit(Models.MOnSiteRegistration mod)
        {
            return new DAL.DOnSiteRegistration().Edit(mod);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(int intOnSiteRegistrationID)
        {
            return new DAL.DOnSiteRegistration().Del(intOnSiteRegistrationID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MOnSiteRegistration GetModel(int intOnSiteRegistrationID)
        {
            return new DAL.DOnSiteRegistration().GetModel(intOnSiteRegistrationID);
        }

        #endregion

        #region  自訂方法


        /// <summary>
        /// 刪除年會報到全部資料
        /// <summary>
        public bool DelAll()
        {
            return new DAL.DOnSiteRegistration().DelAll();
        }
        #endregion
    }
}
