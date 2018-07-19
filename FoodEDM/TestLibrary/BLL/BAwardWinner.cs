using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 AwardWinner
    /// </summary>
    public class BAwardWinner
    {
        public BAwardWinner() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MAwardWinner mod)
        {
            return new DAL.DAwardWinner().Add(mod);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        public bool Edit(Models.MAwardWinner mod)
        {
            return new DAL.DAwardWinner().Edit(mod);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(int intAwardWinnerID)
        {
            return new DAL.DAwardWinner().Del(intAwardWinnerID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MAwardWinner GetModel(int intAwardWinnerID)
        {
            return new DAL.DAwardWinner().GetModel(intAwardWinnerID);
        }

        /// <summary>
        /// 取得全部資料
        /// </summary>
        public List<Models.MAwardWinner> GetList()
        {
            return new DAL.DAwardWinner().GetList();
        }

        #endregion

        #region  自訂方法

        ///// <summary>
        ///// 用keyword取得所有資料
        ///// </summary>
        //public List<Models.MAwardWinner> GetListByKeyword(int intPageSize, int intPageIndex, string strKeyword)
        //{
        //    return new DAL.DAwardWinner().GetListByKeyword(intPageSize, intPageIndex, strKeyword);
        //}

        ///// <summary>
        ///// 計算用keyword取得所有資料筆數
        ///// </summary>
        //public int GetCountByKeyword(string strKeyword)
        //{
        //    return new DAL.DAwardWinner().GetCountByKeyword(strKeyword);
        //}

        /// <summary>
        /// 用AwardID取得所有資料
        /// </summary>
        public List<Models.MAwardWinner> GetListByAwardID(int intPageSize, int intPageIndex, int AwardID)
        {
            return new DAL.DAwardWinner().GetListByAwardID(intPageSize, intPageIndex, AwardID);
        }

        /// <summary>
        /// 計算用AwardID取得資料筆數
        /// </summary>
        public int GetCountByAwardID(int AwardID)
        {
            return new DAL.DAwardWinner().GetCountByAwardID(AwardID);
        }

        ///// <summary>
        ///// 以AwardID取得所有資料
        ///// </summary>
        //public List<Models.MAwardWinner> GetListByAwardID(int AwardID)
        //{
        //    return new DAL.DAwardWinner().GetListByAwardID(AwardID);
        //}

        ///// <summary>
        ///// 以AwardID和Year取得所有資料取得所有AwardWinner資料
        ///// </summary>
        //public List<Models.MAwardWinner> GetListByAwardIDAndYear(int AwardID, DateTime dtYear)
        //{
        //    return new DAL.DAwardWinner().GetListByAwardIDAndYear(AwardID, dtYear);
        //}

        /// <summary>
        /// WinnerID將AwardWinner刪除
        /// </summary>
        //public bool DelByWinnerID(int intWinnerID)
        //{
        //    return new DAL.DAwardWinner().DelByWinnerID(intWinnerID);
        //}

        /// <summary>
        /// 取得全部資料
        /// </summary>
        public List<Models.MAwardWinner> GetListForTest()
        {
            return new DAL.DAwardWinner().GetListForTest();
        }

        #endregion
    }
}