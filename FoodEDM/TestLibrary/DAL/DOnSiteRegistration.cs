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
    /// 資料存取層 OnSiteRegistration
    /// </summary>
    public class DOnSiteRegistration
    {
        public DOnSiteRegistration() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MOnSiteRegistration mod)
        {


             SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.AppendLine("insert into [TB_OnSiteRegistration] ([TWYear],[MemberID],[MemberType],[RegisterName]");
            sbTSQL.AppendLine(",[Company],[PayType],[Fee2],[Fee3],[Attend]");
            sbTSQL.AppendLine(",[MealType],[CreateUser],[CreateDate],[UpdateUser],[UpdateDate],[FeeID])");
            sbTSQL.AppendLine("values (@TWYear,@MemberID,@MemberType,@RegisterName");
            sbTSQL.AppendLine(",@Company,@PayType,@Fee2,@Fee3,@Attend");
            sbTSQL.AppendLine(",@MealType,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate,@FeeID)");
            sbTSQL.AppendLine(";select @@identity;");
            cmd.CommandType = CommandType.Text;
            
            cmd.Parameters.Add("@TWYear", SqlDbType.Int).Value = mod.TWYear;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mod.MemberID;
            cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = mod.MemberType;
            cmd.Parameters.Add("@RegisterName", SqlDbType.NVarChar).Value = mod.RegisterName;
            cmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = mod.Company;
            cmd.Parameters.Add("@PayType", SqlDbType.NVarChar).Value = mod.PayType;
            cmd.Parameters.Add("@Fee2", SqlDbType.Int).Value = mod.Fee2;
            cmd.Parameters.Add("@Fee3", SqlDbType.Int).Value = mod.Fee3;
            cmd.Parameters.Add("@Attend", SqlDbType.Bit).Value = mod.Attend;
            cmd.Parameters.Add("@MealType", SqlDbType.NVarChar).Value = mod.MealType;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = mod.CreateDate;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.UpdateDate);
            cmd.Parameters.Add("@FeeID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.FeeID);
            cmd.CommandText = sbTSQL.ToString();
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.OnSiteRegistrationID = intID;
            }
            return intID;
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MOnSiteRegistration mod)
        {
            SqlCommand cmd = new SqlCommand("STP_OnSiteRegistrationEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OnSiteRegistrationID", SqlDbType.Int).Value = mod.OnSiteRegistrationID;
            cmd.Parameters.Add("@TWYear", SqlDbType.Int).Value = mod.TWYear;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mod.MemberID;
            cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = mod.MemberType;
            cmd.Parameters.Add("@RegisterName", SqlDbType.NVarChar).Value = mod.RegisterName;
            cmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = mod.Company;
            cmd.Parameters.Add("@PayType", SqlDbType.NVarChar).Value = mod.PayType;
            cmd.Parameters.Add("@Fee2", SqlDbType.Int).Value = mod.Fee2;
            cmd.Parameters.Add("@Fee3", SqlDbType.Int).Value = mod.Fee3;
            cmd.Parameters.Add("@Attend", SqlDbType.Bit).Value = mod.Attend;
            cmd.Parameters.Add("@MealType", SqlDbType.NVarChar).Value = mod.MealType;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            cmd.Parameters.Add("@FeeID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.FeeID);
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intOnSiteRegistrationID)
        {
            SqlCommand cmd = new SqlCommand("STP_OnSiteRegistrationDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OnSiteRegistrationID", SqlDbType.Int).Value = intOnSiteRegistrationID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MOnSiteRegistration GetModel(int intOnSiteRegistrationID)
        {
            SqlCommand cmd = new SqlCommand("STP_OnSiteRegistrationGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OnSiteRegistrationID", SqlDbType.Int).Value = intOnSiteRegistrationID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MOnSiteRegistration mod = SetModel(dr);
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
        //public List<Models.MOnSiteRegistration> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_OnSiteRegistrationGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MOnSiteRegistration SetModel(SqlDataReader dr)
        {
            Models.MOnSiteRegistration mod = new Models.MOnSiteRegistration();
            while (dr.Read())
            {
                mod.OnSiteRegistrationID = int.Parse(dr["OnSiteRegistrationID"].ToString());
                mod.TWYear = int.Parse(dr["TWYear"].ToString());
                mod.MemberID = dr["MemberID"].ToString();
                mod.MemberType = dr["MemberType"].ToString();
                mod.RegisterName = dr["RegisterName"].ToString();
                mod.Company = dr["Company"].ToString();
                mod.PayType = dr["PayType"].ToString();
                mod.Fee2 = int.Parse(dr["Fee2"].ToString());
                mod.Fee3 = int.Parse(dr["Fee3"].ToString());
                mod.Attend = bool.Parse(dr["Attend"].ToString());
                mod.MealType = dr["MealType"].ToString();
                mod.CreateUser = dr["CreateUser"].ToString();
                mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
                mod.UpdateUser = dr["UpdateUser"].ToString();
                mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
                mod.FeeID = SQLUtil.GetInt(dr["FeeID"]);
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MOnSiteRegistration SetModel(DataRow dr)
        {
            Models.MOnSiteRegistration mod = new Models.MOnSiteRegistration();
            mod.OnSiteRegistrationID = int.Parse(dr["OnSiteRegistrationID"].ToString());
            mod.TWYear = int.Parse(dr["TWYear"].ToString());
            mod.MemberID = dr["MemberID"].ToString();
            mod.MemberType = dr["MemberType"].ToString();
            mod.RegisterName = dr["RegisterName"].ToString();
            mod.Company = dr["Company"].ToString();
            mod.PayType = dr["PayType"].ToString();
            mod.Fee2 = int.Parse(dr["Fee2"].ToString());
            mod.Fee3 = int.Parse(dr["Fee3"].ToString());
            mod.Attend = bool.Parse(dr["Attend"].ToString());
            mod.MealType = dr["MealType"].ToString();
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            mod.FeeID = SQLUtil.GetInt(dr["FeeID"]);
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MOnSiteRegistration> GetList(DataSet ds)
        {
            List<Models.MOnSiteRegistration> li = new List<Models.MOnSiteRegistration>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 刪除年會報到全部資料
        /// <summary>
        public bool DelAll()
        {
            SqlCommand cmd = new SqlCommand("Delete from [TB_OnSiteRegistration] ");
            cmd.CommandType = CommandType.Text;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        #endregion
    }
}
