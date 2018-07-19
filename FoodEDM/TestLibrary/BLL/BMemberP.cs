using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 MemberP
    /// </summary>
    public class BMemberP
    {
        public BMemberP() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MMemberP mod)
        {
            return new DAL.DMemberP().Add(mod);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        public bool Edit(Models.MMemberP mod)
        {
            return new DAL.DMemberP().Edit(mod);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(string strMemberPID)
        {
            return new DAL.DMemberP().Del(strMemberPID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MMemberP GetModel(string strMemberPID)
        {
            return new DAL.DMemberP().GetModel(strMemberPID);
        }

        ///// <summary>
        ///// 取得全部資料
        ///// </summary>
        //public List<Models.MMemberP> GetList()
        //{
        //    return new DAL.DMemberP().GetList();
        //}

        #endregion

        #region  自訂方法

        /// <summary>
        /// 以關鍵字取得全部資料
        /// </summary>
        public List<Models.MMemberP> GetListByKeyword(string strKeyword, string strMemberClass, string strStatus, string strEducation)
        {
            return new DAL.DMemberP().GetListByKeyword(strKeyword, strMemberClass, strStatus, strEducation);
        }

        /// <summary>
        /// 刪除全部資料
        /// <summary>
        public bool DelAllSpecialty()
        {
            return new DAL.DMemberP().DelAllSpecialty();
        }



        #endregion
    }
}
