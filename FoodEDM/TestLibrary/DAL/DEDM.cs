using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TestLibrary;
using TestLibrary.Common;
using System.Data.OleDb;

namespace TestLibrary.DAL
{
    /// <summary>
    /// 資料存取層 EDM
    /// </summary>
    public class DEDM
    {
        public DEDM() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MEDM mod)
        {
            SqlCommand cmd = new SqlCommand("STP_EDMAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mod.MemberID;
            cmd.Parameters.Add("@NameC", SqlDbType.NVarChar).Value = mod.NameC;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mod.Email;
            cmd.Parameters.Add("@IsSend", SqlDbType.Bit).Value = mod.IsSend;
            if (SQLUtil.ExecuteSql(cmd) > 0)
            {
                return mod.MemberID;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MEDM mod)
        {
            SqlCommand cmd = new SqlCommand("STP_EDMEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mod.MemberID;
            cmd.Parameters.Add("@NameC", SqlDbType.NVarChar).Value = mod.NameC;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mod.Email;
            cmd.Parameters.Add("@IsSend", SqlDbType.Bit).Value = mod.IsSend;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(string strMemberID)
        {
            SqlCommand cmd = new SqlCommand("STP_EDMDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = strMemberID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MEDM GetModel(string strMemberID)
        {
            SqlCommand cmd = new SqlCommand("STP_EDMGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = strMemberID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MEDM mod = SetModel(dr);
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
        /// 取得所有資料
        /// </summary>
        public List<Models.MEDM> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_EDMGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MEDM SetModel(SqlDataReader dr)
        {
            Models.MEDM mod = new Models.MEDM();
            while (dr.Read())
            {
                mod.MemberID = dr["MemberID"].ToString();
                mod.NameC = dr["NameC"].ToString();
                mod.Email = dr["Email"].ToString();
                mod.IsSend = bool.Parse(dr["IsSend"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MEDM SetModel(DataRow dr)
        {
            Models.MEDM mod = new Models.MEDM();
            mod.MemberID = dr["MemberID"].ToString();
            mod.NameC = dr["NameC"].ToString();
            mod.Email = dr["Email"].ToString();
            mod.IsSend = bool.Parse(dr["IsSend"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MEDM> GetList(DataSet ds)
        {
            List<Models.MEDM> li = new List<Models.MEDM>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 取得SqlServer的TB_EDM的名單資料
        /// </summary>
        public DataSet GetEDMList()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.Append(" select  * from TB_EDM  order by MemberID ");
            cmd.CommandText = sbTSQL.ToString();
            return SQLUtil.QueryDS(cmd);
        }


        ///// <summary>
        ///// 取得local mdb所有EMAIL名單資料
        ///// </summary>
        //public DataSet GeVWNameList()
        //{
        //    string strTSQL = "select * from VW_EDM";
        //    OleDbCommand cmd = new OleDbCommand(strTSQL);
        //    cmd.CommandType = CommandType.Text;
        //    DataSet ds = SQLOle.QueryDS(cmd);
        //    return ds;
        //}


        /// <summary>
        /// 刪除所有資料
        /// <summary>
        public bool DelAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.Append(" Delete from TB_EDM");
            cmd.CommandText = sbTSQL.ToString();
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 以id修改為已寄出資料
        /// <summary>
        public bool EditByID(string strMemberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.Append(" update [TB_EDM] set ");
            sbTSQL.Append(" [IsSend]=1 ");
            sbTSQL.Append(" where [MemberID]=" + "'" + strMemberID + "'");
            cmd.CommandText = sbTSQL.ToString();
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 重置並取得EDM名單
        /// <summary>
        public bool ReSet()
        {
            SqlCommand cmd = new SqlCommand("STP_EDMReSet");
            cmd.CommandType = CommandType.StoredProcedure;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }
        
        #endregion
    }
}
