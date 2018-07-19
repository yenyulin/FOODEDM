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
    /// 資料存取層 MemberG
    /// </summary>
    public class DMemberG
    {
        public DMemberG() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MMemberG mod)
        {
            SqlCommand cmd = new SqlCommand("STP_MemberGAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberGID", SqlDbType.NVarChar).Value = mod.MemberGID;
            cmd.Parameters.Add("@MemberGassword", SqlDbType.NVarChar).Value = mod.MemberGassword;
            cmd.Parameters.Add("@CompanyID", SqlDbType.NVarChar).Value = mod.CompanyID;
            cmd.Parameters.Add("@NameC", SqlDbType.NVarChar).Value = mod.NameC;
            cmd.Parameters.Add("@MemberClass", SqlDbType.NVarChar).Value = mod.MemberClass;
            cmd.Parameters.Add("@TEL", SqlDbType.NVarChar).Value = mod.TEL;
            cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = mod.FAX;
            cmd.Parameters.Add("@RegisterDate", SqlDbType.DateTime).Value = mod.RegisterDate;
            cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = mod.ZipCode;
            cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = mod.City;
            cmd.Parameters.Add("@Area", SqlDbType.NVarChar).Value = mod.Area;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = mod.Address;
            cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = mod.ContactName;
            cmd.Parameters.Add("@ContactTitle", SqlDbType.NVarChar).Value = mod.ContactTitle;
            cmd.Parameters.Add("@ContactTEL", SqlDbType.NVarChar).Value = mod.ContactTEL;
            cmd.Parameters.Add("@ContactMobile", SqlDbType.NVarChar).Value = mod.ContactMobile;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.NVarChar).Value = mod.ContactEmail;
            cmd.Parameters.Add("@AgentName", SqlDbType.NVarChar).Value = mod.AgentName;
            cmd.Parameters.Add("@AgentTitle", SqlDbType.NVarChar).Value = mod.AgentTitle;
            cmd.Parameters.Add("@AgentTEL", SqlDbType.NVarChar).Value = mod.AgentTEL;
            cmd.Parameters.Add("@AgentMobile", SqlDbType.NVarChar).Value = mod.AgentMobile;
            cmd.Parameters.Add("@AgentEmail", SqlDbType.NVarChar).Value = mod.AgentEmail;
            cmd.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = mod.Memo;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = mod.Status;
            cmd.Parameters.Add("@EDM", SqlDbType.Bit).Value = mod.EDM;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            cmd.Parameters.Add("@JobContent", SqlDbType.NVarChar).Value = "";
            if (SQLUtil.ExecuteSql(cmd) > 0)
            {
                return mod.MemberGID;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MMemberG mod)
        {
            SqlCommand cmd = new SqlCommand("STP_MemberGEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberGID", SqlDbType.NVarChar).Value = mod.MemberGID;
            cmd.Parameters.Add("@MemberGassword", SqlDbType.NVarChar).Value = mod.MemberGassword;
            cmd.Parameters.Add("@CompanyID", SqlDbType.NVarChar).Value = mod.CompanyID;
            cmd.Parameters.Add("@NameC", SqlDbType.NVarChar).Value = mod.NameC;
            cmd.Parameters.Add("@MemberClass", SqlDbType.NVarChar).Value = mod.MemberClass;
            cmd.Parameters.Add("@TEL", SqlDbType.NVarChar).Value = mod.TEL;
            cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = mod.FAX;
            cmd.Parameters.Add("@RegisterDate", SqlDbType.DateTime).Value = mod.RegisterDate;
            cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = mod.ZipCode;
            cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = mod.City;
            cmd.Parameters.Add("@Area", SqlDbType.NVarChar).Value = mod.Area;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = mod.Address;
            cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = mod.ContactName;
            cmd.Parameters.Add("@ContactTitle", SqlDbType.NVarChar).Value = mod.ContactTitle;
            cmd.Parameters.Add("@ContactTEL", SqlDbType.NVarChar).Value = mod.ContactTEL;
            cmd.Parameters.Add("@ContactMobile", SqlDbType.NVarChar).Value = mod.ContactMobile;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.NVarChar).Value = mod.ContactEmail;
            cmd.Parameters.Add("@AgentName", SqlDbType.NVarChar).Value = mod.AgentName;
            cmd.Parameters.Add("@AgentTitle", SqlDbType.NVarChar).Value = mod.AgentTitle;
            cmd.Parameters.Add("@AgentTEL", SqlDbType.NVarChar).Value = mod.AgentTEL;
            cmd.Parameters.Add("@AgentMobile", SqlDbType.NVarChar).Value = mod.AgentMobile;
            cmd.Parameters.Add("@AgentEmail", SqlDbType.NVarChar).Value = mod.AgentEmail;
            cmd.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = mod.Memo;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = mod.Status;
            cmd.Parameters.Add("@EDM", SqlDbType.Bit).Value = mod.EDM;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            cmd.Parameters.Add("@JobContent", SqlDbType.NVarChar).Value = "";
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(string strMemberGID)
        {
            SqlCommand cmd = new SqlCommand("STP_MemberGDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberGID", SqlDbType.NVarChar).Value = strMemberGID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MMemberG GetModel(string strMemberGID)
        {
            SqlCommand cmd = new SqlCommand("STP_MemberGGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberGID", SqlDbType.NVarChar).Value = strMemberGID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MMemberG mod = SetModel(dr);
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
        private Models.MMemberG SetModel(SqlDataReader dr)
        {
            Models.MMemberG mod = new Models.MMemberG();
            while (dr.Read())
            {
                mod.MemberGID = dr["MemberGID"].ToString();
                mod.MemberGassword = dr["MemberGassword"].ToString();
                mod.CompanyID = dr["CompanyID"].ToString();
                mod.NameC = dr["NameC"].ToString();
                mod.MemberClass = dr["MemberClass"].ToString();
                mod.TEL = dr["TEL"].ToString();
                mod.FAX = dr["FAX"].ToString();
                mod.RegisterDate = DateTime.Parse(dr["RegisterDate"].ToString());
                mod.ZipCode = dr["ZipCode"].ToString();
                mod.City = dr["City"].ToString();
                mod.Area = dr["Area"].ToString();
                mod.Address = dr["Address"].ToString();
                mod.ContactName = dr["ContactName"].ToString();
                mod.ContactTitle = dr["ContactTitle"].ToString();
                mod.ContactTEL = dr["ContactTEL"].ToString();
                mod.ContactMobile = dr["ContactMobile"].ToString();
                mod.ContactEmail = dr["ContactEmail"].ToString();
                mod.AgentName = dr["AgentName"].ToString();
                mod.AgentTitle = dr["AgentTitle"].ToString();
                mod.AgentTEL = dr["AgentTEL"].ToString();
                mod.AgentMobile = dr["AgentMobile"].ToString();
                mod.AgentEmail = dr["AgentEmail"].ToString();
                mod.Memo = dr["Memo"].ToString();
                mod.Status = dr["Status"].ToString();
                mod.EDM = bool.Parse(dr["EDM"].ToString());
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
        private Models.MMemberG SetModel(DataRow dr)
        {
            Models.MMemberG mod = new Models.MMemberG();
            mod.MemberGID = dr["MemberGID"].ToString();
            mod.MemberGassword = dr["MemberGassword"].ToString();
            mod.CompanyID = dr["CompanyID"].ToString();
            mod.NameC = dr["NameC"].ToString();
            mod.MemberClass = dr["MemberClass"].ToString();
            mod.TEL = dr["TEL"].ToString();
            mod.FAX = dr["FAX"].ToString();
            mod.RegisterDate = DateTime.Parse(dr["RegisterDate"].ToString());
            mod.ZipCode = dr["ZipCode"].ToString();
            mod.City = dr["City"].ToString();
            mod.Area = dr["Area"].ToString();
            mod.Address = dr["Address"].ToString();
            mod.ContactName = dr["ContactName"].ToString();
            mod.ContactTitle = dr["ContactTitle"].ToString();
            mod.ContactTEL = dr["ContactTEL"].ToString();
            mod.ContactMobile = dr["ContactMobile"].ToString();
            mod.ContactEmail = dr["ContactEmail"].ToString();
            mod.AgentName = dr["AgentName"].ToString();
            mod.AgentTitle = dr["AgentTitle"].ToString();
            mod.AgentTEL = dr["AgentTEL"].ToString();
            mod.AgentMobile = dr["AgentMobile"].ToString();
            mod.AgentEmail = dr["AgentEmail"].ToString();
            mod.Memo = dr["Memo"].ToString();
            mod.Status = dr["Status"].ToString();
            mod.EDM = bool.Parse(dr["EDM"].ToString());
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.UpdateUser = dr["UpdateUser"].ToString();
            mod.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MMemberG> GetList(DataSet ds)
        {
            List<Models.MMemberG> li = new List<Models.MMemberG>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        /// <summary>
        /// 以關鍵字取得全部資料
        /// </summary>
        public List<Models.MMemberG> GetListByKeyword(string strKeyword, string strMemberClass, string strStatus)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.Append("select * from [TB_MemberG]  where 1=1");
            if (strKeyword.Length != 0)
            {
                sbTSQL.Append("And MemberGID like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or NameC like " + "'%" + strKeyword + "%'");

                sbTSQL.Append("or TEL like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or FAX like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or ContactName like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or ContactTitle like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or ContactTEL like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or ContactMobile like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or ContactEmail like " + "'%" + strKeyword + "%'");

                sbTSQL.Append("or AgentName like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or AgentTitle like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or AgentTEL like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or AgentMobile like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or AgentEmail like " + "'%" + strKeyword + "%'");

                sbTSQL.Append("or Memo like " + "'%" + strKeyword + "%'");
            }
            if (strMemberClass != "全部")
            {
                sbTSQL.Append("and MemberClass=" + "'" + strMemberClass + "'");
            }
            if (strStatus != "全部")
            {
                sbTSQL.Append("and Status=" + "'" + strStatus + "'");
            }

            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 刪除Business全部資料
        /// <summary>
        public bool DelAllBusiness()
        {
            SqlCommand cmd = new SqlCommand("Delete from [TB_MemberGBusiness] ");
            cmd.CommandType = CommandType.Text;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        #endregion
    }
}
