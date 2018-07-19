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
    /// 資料存取層 Vote
    /// </summary>
    public class DVote
    {
        public DVote() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MVote mod)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();

            sbTSQL.AppendLine("insert into [TB_Vote] ([TWYear],[MemberID],[AgentMemberID],[CreateDate],[CreateUser])");
            sbTSQL.AppendLine("values (@TWYear,@MemberID,@AgentMemberID,@CreateDate,@CreateUser)");
            sbTSQL.AppendLine(";select @@identity;");
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@TWYear", SqlDbType.Int).Value = mod.TWYear;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mod.MemberID;
            cmd.Parameters.Add("@AgentMemberID", SqlDbType.NVarChar).Value = mod.AgentMemberID;
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = mod.CreateDate;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.CommandText = sbTSQL.ToString();
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.VoteID = intID;
            }
            return intID;
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MVote mod)
        {
            SqlCommand cmd = new SqlCommand("STP_VoteEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VoteID", SqlDbType.Int).Value = mod.VoteID;
            cmd.Parameters.Add("@TWYear", SqlDbType.Int).Value = mod.TWYear;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mod.MemberID;
            cmd.Parameters.Add("@AgentMemberID", SqlDbType.NVarChar).Value = mod.AgentMemberID;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intVoteID)
        {
            SqlCommand cmd = new SqlCommand("STP_VoteDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VoteID", SqlDbType.Int).Value = intVoteID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MVote GetModel(int intVoteID)
        {
            SqlCommand cmd = new SqlCommand("STP_VoteGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VoteID", SqlDbType.Int).Value = intVoteID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MVote mod = SetModel(dr);
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

        ///// <summary>
        ///// 取得所有資料
        ///// </summary>
        //public List<Models.MVote> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_VoteGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MVote SetModel(SqlDataReader dr)
        {
            Models.MVote mod = new Models.MVote();
            while (dr.Read())
            {
                mod.VoteID = int.Parse(dr["VoteID"].ToString());
                mod.TWYear = int.Parse(dr["TWYear"].ToString());
                mod.MemberID = dr["MemberID"].ToString();
                mod.AgentMemberID = dr["AgentMemberID"].ToString();
                mod.CreateUser = dr["CreateUser"].ToString();
                mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MVote SetModel(DataRow dr)
        {
            Models.MVote mod = new Models.MVote();
            mod.VoteID = int.Parse(dr["VoteID"].ToString());
            mod.TWYear = int.Parse(dr["TWYear"].ToString());
            mod.MemberID = dr["MemberID"].ToString();
            mod.AgentMemberID = dr["AgentMemberID"].ToString();
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MVote> GetList(DataSet ds)
        {
            List<Models.MVote> li = new List<Models.MVote>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 刪除Vote全部資料
        /// <summary>
        public bool DelAll()
        {
            SqlCommand cmd = new SqlCommand("Delete from [TB_Vote]  ");
            cmd.CommandType = CommandType.Text;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }
        #endregion
    }
}
