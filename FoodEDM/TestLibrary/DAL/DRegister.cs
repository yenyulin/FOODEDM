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
    /// 資料存取層 Register
    /// </summary>
    public class DRegister
    {
        public DRegister() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MRegister mod)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();

            sbTSQL.AppendLine("insert into [TB_Register] ([TWYear],[MemberID],[MemberType],[RegisterName]");
            sbTSQL.AppendLine(",[TEL],[Email1],[Email2],[ZipCode],[City]");
            sbTSQL.AppendLine(",[Area],[Address],[MealType],[RegisterDate],[UpdateDate])");
            sbTSQL.AppendLine("values (@TWYear,@MemberID,@MemberType,@RegisterName");
            sbTSQL.AppendLine(",@TEL,@Email1,@Email2,@ZipCode,@City");
            sbTSQL.AppendLine(",@Area,@Address,@MealType,@RegisterDate,@UpdateDate)");
            sbTSQL.AppendLine(";select @@identity;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@TWYear", SqlDbType.Int).Value = mod.TWYear;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mod.MemberID;
            cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = mod.MemberType;
            cmd.Parameters.Add("@RegisterName", SqlDbType.NVarChar).Value = mod.RegisterName;
            cmd.Parameters.Add("@TEL", SqlDbType.NVarChar).Value = mod.TEL;
            cmd.Parameters.Add("@Email1", SqlDbType.NVarChar).Value = mod.Email1;
            cmd.Parameters.Add("@Email2", SqlDbType.NVarChar).Value = mod.Email2;
            cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = mod.ZipCode;
            cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = mod.City;
            cmd.Parameters.Add("@Area", SqlDbType.NVarChar).Value = mod.Area;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = mod.Address;
            cmd.Parameters.Add("@MealType", SqlDbType.NVarChar).Value = mod.MealType;
            cmd.Parameters.Add("@RegisterDate", SqlDbType.DateTime).Value = mod.RegisterDate;
            cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = mod.UpdateDate;
            cmd.CommandText = sbTSQL.ToString();
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.RegisterID = intID;
            }
            return intID;
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MRegister mod)
        {
            SqlCommand cmd = new SqlCommand("STP_RegisterEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RegisterID", SqlDbType.Int).Value = mod.RegisterID;
            cmd.Parameters.Add("@TWYear", SqlDbType.Int).Value = mod.TWYear;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mod.MemberID;
            cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = mod.MemberType;
            cmd.Parameters.Add("@RegisterName", SqlDbType.NVarChar).Value = mod.RegisterName;
            cmd.Parameters.Add("@TEL", SqlDbType.NVarChar).Value = mod.TEL;
            cmd.Parameters.Add("@Email1", SqlDbType.NVarChar).Value = mod.Email1;
            cmd.Parameters.Add("@Email2", SqlDbType.NVarChar).Value = mod.Email2;
            cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = mod.ZipCode;
            cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = mod.City;
            cmd.Parameters.Add("@Area", SqlDbType.NVarChar).Value = mod.Area;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = mod.Address;
            cmd.Parameters.Add("@MealType", SqlDbType.NVarChar).Value = mod.MealType;
            cmd.Parameters.Add("@RegisterDate", SqlDbType.DateTime).Value = mod.RegisterDate;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intRegisterID)
        {
            SqlCommand cmd = new SqlCommand("STP_RegisterDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RegisterID", SqlDbType.Int).Value = intRegisterID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MRegister GetModel(int intRegisterID)
        {
            SqlCommand cmd = new SqlCommand("STP_RegisterGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RegisterID", SqlDbType.Int).Value = intRegisterID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MRegister mod = SetModel(dr);
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
        //public List<Models.MRegister> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_RegisterGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MRegister SetModel(SqlDataReader dr)
        {
            Models.MRegister mod = new Models.MRegister();
            while (dr.Read())
            {
                mod.RegisterID = int.Parse(dr["RegisterID"].ToString());
                mod.TWYear = int.Parse(dr["TWYear"].ToString());
                mod.MemberID = dr["MemberID"].ToString();
                mod.MemberType = dr["MemberType"].ToString();
                mod.RegisterName = dr["RegisterName"].ToString();
                mod.TEL = dr["TEL"].ToString();
                mod.Email1 = dr["Email1"].ToString();
                mod.Email2 = dr["Email2"].ToString();
                mod.ZipCode = dr["ZipCode"].ToString();
                mod.City = dr["City"].ToString();
                mod.Area = dr["Area"].ToString();
                mod.Address = dr["Address"].ToString();
                mod.MealType = dr["MealType"].ToString();
                mod.RegisterDate = DateTime.Parse(dr["RegisterDate"].ToString());
                mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MRegister SetModel(DataRow dr)
        {
            Models.MRegister mod = new Models.MRegister();
            mod.RegisterID = int.Parse(dr["RegisterID"].ToString());
            mod.TWYear = int.Parse(dr["TWYear"].ToString());
            mod.MemberID = dr["MemberID"].ToString();
            mod.MemberType = dr["MemberType"].ToString();
            mod.RegisterName = dr["RegisterName"].ToString();
            mod.TEL = dr["TEL"].ToString();
            mod.Email1 = dr["Email1"].ToString();
            mod.Email2 = dr["Email2"].ToString();
            mod.ZipCode = dr["ZipCode"].ToString();
            mod.City = dr["City"].ToString();
            mod.Area = dr["Area"].ToString();
            mod.Address = dr["Address"].ToString();
            mod.MealType = dr["MealType"].ToString();
            mod.RegisterDate = DateTime.Parse(dr["RegisterDate"].ToString());
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MRegister> GetList(DataSet ds)
        {
            List<Models.MRegister> li = new List<Models.MRegister>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 刪除Register全部資料
        /// <summary>
        public bool DelAll()
        {
            SqlCommand cmd = new SqlCommand("Delete from [TB_Register]   ");
            cmd.CommandType = CommandType.Text;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }


        #endregion
    }
}
