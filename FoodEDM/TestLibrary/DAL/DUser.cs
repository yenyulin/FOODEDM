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
    /// 資料存取層 User
    /// </summary>
    public class DUser
    {
        public DUser() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MUser mod)
        {
            SqlCommand cmd = new SqlCommand("STP_UserAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = mod.UserID;
            cmd.Parameters.Add("@UserPassword", SqlDbType.NVarChar).Value = Security.Encrypt(mod.UserPassword);
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = mod.UserName;
            cmd.Parameters.Add("@Actived", SqlDbType.Bit).Value = mod.Actived;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            if (SQLUtil.ExecuteSql(cmd) > 0)
            {
                return mod.UserID;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MUser mod)
        {
            SqlCommand cmd = new SqlCommand("STP_UserEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = mod.UserID;
            cmd.Parameters.Add("@UserPassword", SqlDbType.NVarChar).Value = Security.Encrypt(mod.UserPassword);
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = mod.UserName;
            cmd.Parameters.Add("@Actived", SqlDbType.Bit).Value = mod.Actived;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(string strUserID)
        {
            SqlCommand cmd = new SqlCommand("STP_UserDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = strUserID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MUser GetModel(string strUserID)
        {
            SqlCommand cmd = new SqlCommand("STP_UserGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = strUserID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MUser mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        public List<Models.MUser> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_UserGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MUser SetModel(SqlDataReader dr)
        {
            Models.MUser mod = new Models.MUser();
            while (dr.Read())
            {
                mod.UserID = dr["UserID"].ToString();
                mod.UserPassword = Security.Decrypt(dr["UserPassword"].ToString());
                mod.UserName = dr["UserName"].ToString();
                mod.Actived = bool.Parse(dr["Actived"].ToString());
                mod.CreateUser = dr["CreateUser"].ToString();
                mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
                mod.UpdateUser = dr["UpdateUser"].ToString();
                mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MUser SetModel(DataRow dr)
        {
            Models.MUser mod = new Models.MUser();
            mod.UserID = dr["UserID"].ToString();
            //mod.UserPassword = Security.Decrypt(dr["UserPassword"].ToString());
            mod.UserName = dr["UserName"].ToString();
            mod.Actived = bool.Parse(dr["Actived"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MUser> GetList(DataSet ds)
        {
            List<Models.MUser> li = new List<Models.MUser>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 由帳號與密碼取得單筆User資料
        /// <summary>
        public Models.MUser GetByUserIDUserPassword(string strUserID, string strUserPassword)
        {
            SqlCommand cmd = new SqlCommand("STP_UserGetByUserIDUserPassword");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = strUserID;
            cmd.Parameters.Add("@UserPassword", SqlDbType.NVarChar).Value =Security.Encrypt(strUserPassword);
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MUser mod = SetModel(dr);
            dr.Close();
            return isHasRows ? mod : null;
        }

        /// <summary>
        /// 由UserID計算User筆數
        /// </summary>
        public int CountByUserID(string strUserid)
        {
            SqlCommand cmd = new SqlCommand("STP_UserCountByUserID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = strUserid;
            return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        }

        #endregion
    }
}
