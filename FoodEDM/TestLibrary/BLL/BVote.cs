using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TestLibrary;

namespace TestLibrary.BLL
{
    /// <summary>
    /// 商業邏輯層 Vote
    /// </summary>
    public class BVote
    {
        public BVote() { }

        #region  基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MVote mod)
        {
            return new DAL.DVote().Add(mod);
        }

        /// <summary>
        /// 修改資料
        /// </summary>
        public bool Edit(Models.MVote mod)
        {
            return new DAL.DVote().Edit(mod);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        public bool Del(int intVoteID)
        {
            return new DAL.DVote().Del(intVoteID);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        public Models.MVote GetModel(int intVoteID)
        {
            return new DAL.DVote().GetModel(intVoteID);
        }

        ///// <summary>
        ///// 取得全部資料
        ///// </summary>
        //public List<Models.MVote> GetList()
        //{
        //    return new DAL.DVote().GetList();
        //}

        #endregion

        #region  自訂方法

        /// <summary>
        /// 刪除Vote全部資料
        /// <summary>
        public bool DelAll()
        {
            return new DAL.DVote().DelAll();
        }
        #endregion
    }
}
