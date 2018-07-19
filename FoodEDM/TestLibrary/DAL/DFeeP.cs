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
    /// 資料存取層 FeeP
    /// </summary>
    public class DFeeP
    {
        public DFeeP() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MFeeP mod)
        {
            SqlCommand cmd = new SqlCommand("STP_FeePAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberPID", SqlDbType.NVarChar).Value = mod.MemberPID;
            cmd.Parameters.Add("@TWYear", SqlDbType.Int).Value = mod.TWYear;
            cmd.Parameters.Add("@PayType", SqlDbType.NVarChar).Value = mod.PayType;
            cmd.Parameters.Add("@Fee1", SqlDbType.Int).Value = mod.Fee1;
            cmd.Parameters.Add("@Fee2", SqlDbType.Int).Value = mod.Fee2;
            cmd.Parameters.Add("@Fee3", SqlDbType.Int).Value = mod.Fee3;
            cmd.Parameters.Add("@PayDate", SqlDbType.DateTime).Value = mod.PayDate;
            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.OrderID);
            cmd.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = mod.Remark;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.FeePID = intID;
            }
            return intID;
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MFeeP mod)
        {
            SqlCommand cmd = new SqlCommand("STP_FeePEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeePID", SqlDbType.Int).Value = mod.FeePID;
            cmd.Parameters.Add("@MemberPID", SqlDbType.NVarChar).Value = mod.MemberPID;
            cmd.Parameters.Add("@TWYear", SqlDbType.Int).Value = mod.TWYear;
            cmd.Parameters.Add("@PayType", SqlDbType.NVarChar).Value = mod.PayType;
            cmd.Parameters.Add("@Fee1", SqlDbType.Int).Value = mod.Fee1;
            cmd.Parameters.Add("@Fee2", SqlDbType.Int).Value = mod.Fee2;
            cmd.Parameters.Add("@Fee3", SqlDbType.Int).Value = mod.Fee3;
            cmd.Parameters.Add("@PayDate", SqlDbType.DateTime).Value = mod.PayDate;
            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.OrderID);
            cmd.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = mod.Remark;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intFeePID)
        {
            SqlCommand cmd = new SqlCommand("STP_FeePDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeePID", SqlDbType.Int).Value = intFeePID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MFeeP GetModel(int intFeePID)
        {
            SqlCommand cmd = new SqlCommand("STP_FeePGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FeePID", SqlDbType.Int).Value = intFeePID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MFeeP mod = SetModel(dr);
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
        private Models.MFeeP SetModel(SqlDataReader dr)
        {
            Models.MFeeP mod = new Models.MFeeP();
            while (dr.Read())
            {
                mod.FeePID = int.Parse(dr["FeePID"].ToString());
                mod.MemberPID = dr["MemberPID"].ToString();
                mod.TWYear = int.Parse(dr["TWYear"].ToString());
                mod.PayType = dr["PayType"].ToString();
                mod.Fee1 = int.Parse(dr["Fee1"].ToString());
                mod.Fee2 = int.Parse(dr["Fee2"].ToString());
                mod.Fee3 = int.Parse(dr["Fee3"].ToString());
                mod.PayDate = DateTime.Parse(dr["PayDate"].ToString());
                mod.OrderID = SQLUtil.GetInt(dr["OrderID"]);
                mod.Remark = dr["Remark"].ToString();
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MFeeP SetModel(DataRow dr)
        {
            Models.MFeeP mod = new Models.MFeeP();
            mod.FeePID = int.Parse(dr["FeePID"].ToString());
            mod.MemberPID = dr["MemberPID"].ToString();
            mod.TWYear = int.Parse(dr["TWYear"].ToString());
            mod.PayType = dr["PayType"].ToString();
            mod.Fee1 = int.Parse(dr["Fee1"].ToString());
            mod.Fee2 = int.Parse(dr["Fee2"].ToString());
            mod.Fee3 = int.Parse(dr["Fee3"].ToString());
            mod.PayDate = DateTime.Parse(dr["PayDate"].ToString());
            mod.OrderID = SQLUtil.GetInt(dr["OrderID"]);
            mod.Remark = dr["Remark"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MFeeP> GetList(DataSet ds)
        {
            List<Models.MFeeP> li = new List<Models.MFeeP>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 刪除全部資料
        /// <summary>
        public bool DelAll()
        {
            SqlCommand cmd = new SqlCommand("Delete from [TB_FeeP] ");
            cmd.CommandType = CommandType.Text;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        #endregion
    }
}
