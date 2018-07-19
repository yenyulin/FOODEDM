using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TestLibrary;
using TestLibrary.Common;

namespace TestLibrary.DAL
{
    /// <summary>
    /// 資料存取層 PaperDomainSeq
    /// </summary>
    public class DPaperDomainSeq
    {
        public DPaperDomainSeq() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MPaperDomainSeq mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperDomainSeqAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = mod.PaperID;
            cmd.Parameters.Add("@PaperDomainID", SqlDbType.NVarChar).Value = mod.PaperDomainID;
            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = mod.Seq;
            return SQLUtil.ExecuteSql(cmd);
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MPaperDomainSeq mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperDomainSeqEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = mod.PaperID;
            cmd.Parameters.Add("@PaperDomainID", SqlDbType.NVarChar).Value = mod.PaperDomainID;
            cmd.Parameters.Add("@Seq", SqlDbType.Int).Value = mod.Seq;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intPaperID)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperDomainSeqDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = intPaperID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MPaperDomainSeq GetModel(int intPaperID)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperDomainSeqGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = intPaperID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MPaperDomainSeq mod = SetModel(dr);
            dr.Close();
            if (isHasRows)
            {
                return mod;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MPaperDomainSeq SetModel(SqlDataReader dr)
        {
            Models.MPaperDomainSeq mod = new Models.MPaperDomainSeq();
            while (dr.Read())
            {
                mod.PaperID = int.Parse(dr["PaperID"].ToString());
                mod.PaperDomainID = dr["PaperDomainID"].ToString();
                mod.Seq = int.Parse(dr["Seq"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MPaperDomainSeq SetModel(DataRow dr)
        {
            Models.MPaperDomainSeq mod = new Models.MPaperDomainSeq();
            mod.PaperID = int.Parse(dr["PaperID"].ToString());
            mod.PaperDomainID = dr["PaperDomainID"].ToString();
            mod.Seq = int.Parse(dr["Seq"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MPaperDomainSeq> GetList(DataSet ds)
        {
            List<Models.MPaperDomainSeq> li = new List<Models.MPaperDomainSeq>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 以PaperID取得全部資料
        /// </summary>
        public List<Models.MPaperDomainSeq> GetListByPaperID(int intPaperID)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperDomainSeqGetByPaperID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = intPaperID;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 以PaperID刪除資料
        /// </summary>
        public bool DelByPaperID(int intPaperID)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperDomainSeqDelByPaperID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = intPaperID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }


        #endregion
    }
}
