using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;


namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 EDM
    /// </summary>
    public class BEDM
    {
        public BEDM() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MEDM mod)
        {
            return new DAL.DEDM().Add(mod);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        public bool Edit(Models.MEDM mod)
        {
            return new DAL.DEDM().Edit(mod);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(string strMemberID)
        {
            return new DAL.DEDM().Del(strMemberID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MEDM GetModel(string strMemberID)
        {
            return new DAL.DEDM().GetModel(strMemberID);
        }

        /// <summary>
        /// 取得全部資料
        /// </summary>
        public List<Models.MEDM> GetList()
        {
            return new DAL.DEDM().GetList();
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 取得SqlServer的TB_EDM的名單資料
        /// </summary>
        public DataSet GetEDMList()
        {
            return new DAL.DEDM().GetEDMList();
        }

        ///// <summary>
        ///// 取得local mdb所有EMAIL名單資料
        ///// </summary>
        //public DataSet GeVWNameList()
        //{
        //    return new DAL.DEDM().GeVWNameList();
        //}

        /// <summary>
        /// 刪除所有資料
        /// <summary>
        public bool DelAll()
        {
            return new DAL.DEDM().DelAll();
        }

        /// <summary>
        /// 以id修改為已寄出資料
        /// </summary>
        public bool EditByID(string strMemberID)
        {
            return new DAL.DEDM().EditByID(strMemberID);
        }

        /// <summary>
        /// 重置並取得EDM名單
        /// <summary>
        public bool ReSet()
        {
            return new DAL.DEDM().ReSet();
        }
        #endregion
    }
}
