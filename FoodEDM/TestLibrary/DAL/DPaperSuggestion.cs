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
    /// 資料存取層 PaperSuggestion
    /// </summary>
    public class DPaperSuggestion
    {
        public DPaperSuggestion() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MPaperSuggestion mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperSuggestionAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = mod.PaperID;
            cmd.Parameters.Add("@PaperSuggestion", SqlDbType.NVarChar).Value = mod.PaperSuggestion;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.PaperSuggestionID = intID;
            }
            return intID;
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MPaperSuggestion mod)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperSuggestionEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperSuggestionID", SqlDbType.Int).Value = mod.PaperSuggestionID;
            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = mod.PaperID;
            cmd.Parameters.Add("@PaperSuggestion", SqlDbType.NVarChar).Value = mod.PaperSuggestion;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intPaperSuggestionID)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperSuggestionDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperSuggestionID", SqlDbType.Int).Value = intPaperSuggestionID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MPaperSuggestion GetModel(int intPaperSuggestionID)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperSuggestionGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperSuggestionID", SqlDbType.Int).Value = intPaperSuggestionID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MPaperSuggestion mod = SetModel(dr);
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
        private Models.MPaperSuggestion SetModel(SqlDataReader dr)
        {
            Models.MPaperSuggestion mod = new Models.MPaperSuggestion();
            while (dr.Read())
            {
                mod.PaperSuggestionID = int.Parse(dr["PaperSuggestionID"].ToString());
                mod.PaperID = int.Parse(dr["PaperID"].ToString());
                mod.PaperSuggestion = dr["PaperSuggestion"].ToString();
                mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MPaperSuggestion SetModel(DataRow dr)
        {
            Models.MPaperSuggestion mod = new Models.MPaperSuggestion();
            mod.PaperSuggestionID = int.Parse(dr["PaperSuggestionID"].ToString());
            mod.PaperID = int.Parse(dr["PaperID"].ToString());
            mod.PaperSuggestion = dr["PaperSuggestion"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MPaperSuggestion> GetList(DataSet ds)
        {
            List<Models.MPaperSuggestion> li = new List<Models.MPaperSuggestion>();
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
        public List<Models.MPaperSuggestion> GetListByPaperID(int intPaperID)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperSuggestionGetByPaperID");
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
            SqlCommand cmd = new SqlCommand("STP_PaperSuggestionDelByPaperID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = intPaperID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        #endregion
    }
}
