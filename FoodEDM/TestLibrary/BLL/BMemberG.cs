using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 MemberG
    /// </summary>
    public class BMemberG
    {
        public BMemberG() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MMemberG mod)
        {
            return new DAL.DMemberG().Add(mod);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        public bool Edit(Models.MMemberG mod)
        {
            return new DAL.DMemberG().Edit(mod);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(string strMemberGID)
        {
            return new DAL.DMemberG().Del(strMemberGID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MMemberG GetModel(string strMemberGID)
        {
            return new DAL.DMemberG().GetModel(strMemberGID);
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 以關鍵字取得全部資料
        /// </summary>
        public List<Models.MMemberG> GetListByKeyword(string strKeyword, string strMemberClass, string strStatus)
        {
            return new DAL.DMemberG().GetListByKeyword(strKeyword, strMemberClass, strStatus);
        }

        /// <summary>
        /// 刪除Business資料
        /// <summary>
        public bool DelAllBusiness()
        {
            return new DAL.DMemberG().DelAllBusiness();
        }

        #endregion
    }
}
