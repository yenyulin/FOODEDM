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
    /// 資料存取層 Receipt
    /// </summary>
    public class DReceipt
    {
        public DReceipt() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MReceipt mod)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();

            sbTSQL.AppendLine("insert into [TB_Receipt] ([TWYear],[MemberID],[MemberType],[ReceiptType]");
            sbTSQL.AppendLine(",[Fee],[ReceivedFromAppend],[Remark],[CreateUser],[CreateDate],[CancelUser]");
            sbTSQL.AppendLine(",[CancelDate],[Enable])");
            sbTSQL.AppendLine("values (@TWYear,@MemberID,@MemberType,@ReceiptType");
            sbTSQL.AppendLine(",@Fee,@ReceivedFromAppend,@Remark,@CreateUser,@CreateDate,@CancelUser");
            sbTSQL.AppendLine(",@CancelDate,@Enable)");
            sbTSQL.AppendLine(";select @@identity;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@TWYear", SqlDbType.Int).Value = mod.TWYear;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mod.MemberID;
            cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = mod.MemberType;
            cmd.Parameters.Add("@ReceiptType", SqlDbType.NVarChar).Value = mod.ReceiptType;
            cmd.Parameters.Add("@Fee", SqlDbType.Int).Value = mod.Fee;
            cmd.Parameters.Add("@ReceivedFromAppend", SqlDbType.NVarChar).Value = mod.ReceivedFromAppend;
            cmd.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = mod.Remark;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = mod.CreateDate;
            cmd.Parameters.Add("@CancelUser", SqlDbType.NVarChar).Value = SQLUtil.CheckDBValue(mod.CancelUser);
            cmd.Parameters.Add("@CancelDate", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.CancelDate);
            cmd.Parameters.Add("@Enable", SqlDbType.Bit).Value = mod.Enable;
            cmd.CommandText = sbTSQL.ToString();
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.ReceiptID = intID;
            }
            return intID;
        }

        ///// <summary>
        ///// 修改資料
        ///// <summary>
        //public bool Edit(Models.MReceipt mod)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_ReceiptEdit");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@ReceiptID", SqlDbType.Int).Value = mod.ReceiptID;
        //    cmd.Parameters.Add("@TWYear", SqlDbType.Int).Value = mod.TWYear;
        //    cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mod.MemberID;
        //    cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = mod.MemberType;
        //    cmd.Parameters.Add("@ReceiptType", SqlDbType.NVarChar).Value = mod.ReceiptType;
        //    cmd.Parameters.Add("@Fee", SqlDbType.Int).Value = mod.Fee;
        //    cmd.Parameters.Add("@ReceivedFromAppend", SqlDbType.NVarChar).Value = mod.ReceivedFromAppend;
        //    cmd.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = mod.Remark;
        //    cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
        //    cmd.Parameters.Add("@CancelUser", SqlDbType.NVarChar).Value = SQLUtil.CheckDBValue(mod.CancelUser);
        //    cmd.Parameters.Add("@CancelDate", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.CancelDate);
        //    cmd.Parameters.Add("@Enable", SqlDbType.Bit).Value = mod.Enable;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intReceiptID)
        {
            SqlCommand cmd = new SqlCommand("STP_ReceiptDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReceiptID", SqlDbType.Int).Value = intReceiptID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MReceipt GetModel(int intReceiptID)
        {
            SqlCommand cmd = new SqlCommand("STP_ReceiptGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReceiptID", SqlDbType.Int).Value = intReceiptID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MReceipt mod = SetModel(dr);
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
        //public List<Models.MReceipt> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_ReceiptGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MReceipt SetModel(SqlDataReader dr)
        {
            Models.MReceipt mod = new Models.MReceipt();
            while (dr.Read())
            {
                mod.ReceiptID = int.Parse(dr["ReceiptID"].ToString());
                mod.TWYear = int.Parse(dr["TWYear"].ToString());
                mod.MemberID = dr["MemberID"].ToString();
                mod.MemberType = dr["MemberType"].ToString();
                mod.ReceiptType = dr["ReceiptType"].ToString();
                mod.Fee = int.Parse(dr["Fee"].ToString());
                mod.ReceivedFromAppend = dr["ReceivedFromAppend"].ToString();
                mod.Remark = dr["Remark"].ToString();
                mod.CreateUser = dr["CreateUser"].ToString();
                mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
                mod.CancelUser = SQLUtil.GetString(dr["CancelUser"]);
                mod.CancelDate = SQLUtil.GetDateTime(dr["CancelDate"]);
                mod.Enable = bool.Parse(dr["Enable"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MReceipt SetModel(DataRow dr)
        {
            Models.MReceipt mod = new Models.MReceipt();
            mod.ReceiptID = int.Parse(dr["ReceiptID"].ToString());
            mod.TWYear = int.Parse(dr["TWYear"].ToString());
            mod.MemberID = dr["MemberID"].ToString();
            mod.MemberType = dr["MemberType"].ToString();
            mod.ReceiptType = dr["ReceiptType"].ToString();
            mod.Fee = int.Parse(dr["Fee"].ToString());
            mod.ReceivedFromAppend = dr["ReceivedFromAppend"].ToString();
            mod.Remark = dr["Remark"].ToString();
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.CancelUser = SQLUtil.GetString(dr["CancelUser"]);
            mod.CancelDate = SQLUtil.GetDateTime(dr["CancelDate"]);
            mod.Enable = bool.Parse(dr["Enable"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MReceipt> GetList(DataSet ds)
        {
            List<Models.MReceipt> li = new List<Models.MReceipt>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 刪除Receipt全部資料
        /// <summary>
        public bool DelAll()
        {
            SqlCommand cmd = new SqlCommand("Delete from [TB_Receipt] ");
            cmd.CommandType = CommandType.Text;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        #endregion
    }
}
