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
    /// 資料存取層 MemberP
    /// </summary>
    public class DMemberP
    {
        public DMemberP() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public string Add(Models.MMemberP mod)
        {
            SqlCommand cmd = new SqlCommand("STP_MemberPAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberPID", SqlDbType.NVarChar).Value = mod.MemberPID;
            cmd.Parameters.Add("@MemberPassword", SqlDbType.NVarChar).Value = mod.MemberPassword;
            cmd.Parameters.Add("@NameC", SqlDbType.NVarChar).Value = mod.NameC;
            cmd.Parameters.Add("@NameE", SqlDbType.NVarChar).Value = mod.NameE;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mod.Email;
            cmd.Parameters.Add("@PID", SqlDbType.NVarChar).Value = mod.PID;
            cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.Birthday);
            cmd.Parameters.Add("@RegisterDate", SqlDbType.DateTime).Value = mod.RegisterDate;
            cmd.Parameters.Add("@Sex", SqlDbType.NVarChar).Value = mod.Sex;
            cmd.Parameters.Add("@Native", SqlDbType.NVarChar).Value = mod.Native;
            cmd.Parameters.Add("@MemberClass", SqlDbType.NVarChar).Value = mod.MemberClass;
            cmd.Parameters.Add("@SchoolConsent", SqlDbType.NVarChar).Value = mod.SchoolConsent;
            cmd.Parameters.Add("@StudentIDCard", SqlDbType.NVarChar).Value = mod.StudentIDCard;
            cmd.Parameters.Add("@StudentIDCardFileType", SqlDbType.NVarChar).Value = mod.StudentIDCardFileType;
            cmd.Parameters.Add("@School", SqlDbType.NVarChar).Value = mod.School;
            cmd.Parameters.Add("@CollegeDepartment", SqlDbType.NVarChar).Value = mod.CollegeDepartment;
            cmd.Parameters.Add("@Education", SqlDbType.NVarChar).Value = mod.Education;
            cmd.Parameters.Add("@Job", SqlDbType.NVarChar).Value = mod.Job;
            cmd.Parameters.Add("@JobTitle", SqlDbType.NVarChar).Value = mod.JobTitle;
            cmd.Parameters.Add("@Student", SqlDbType.Bit).Value = mod.Student;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = mod.Mobile;
            cmd.Parameters.Add("@TEL", SqlDbType.NVarChar).Value = mod.TEL;
            cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = mod.FAX;
            cmd.Parameters.Add("@ZipCodeH", SqlDbType.NVarChar).Value = mod.ZipCodeH;
            cmd.Parameters.Add("@CityH", SqlDbType.NVarChar).Value = mod.CityH;
            cmd.Parameters.Add("@AreaH", SqlDbType.NVarChar).Value = mod.AreaH;
            cmd.Parameters.Add("@AddressH", SqlDbType.NVarChar).Value = mod.AddressH;
            cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = mod.ZipCode;
            cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = mod.City;
            cmd.Parameters.Add("@Area", SqlDbType.NVarChar).Value = mod.Area;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = mod.Address;
            cmd.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = mod.Memo;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = mod.Status;
            cmd.Parameters.Add("@EDM", SqlDbType.Bit).Value = mod.EDM;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            if (SQLUtil.ExecuteSql(cmd) > 0)
            {
                return mod.MemberPID;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MMemberP mod)
        {
            SqlCommand cmd = new SqlCommand("STP_MemberPEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberPID", SqlDbType.NVarChar).Value = mod.MemberPID;
            cmd.Parameters.Add("@MemberPassword", SqlDbType.NVarChar).Value = mod.MemberPassword;
            cmd.Parameters.Add("@NameC", SqlDbType.NVarChar).Value = mod.NameC;
            cmd.Parameters.Add("@NameE", SqlDbType.NVarChar).Value = mod.NameE;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mod.Email;
            cmd.Parameters.Add("@PID", SqlDbType.NVarChar).Value = mod.PID;
            cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.Birthday);
            cmd.Parameters.Add("@RegisterDate", SqlDbType.DateTime).Value = mod.RegisterDate;
            cmd.Parameters.Add("@Sex", SqlDbType.NVarChar).Value = mod.Sex;
            cmd.Parameters.Add("@Native", SqlDbType.NVarChar).Value = mod.Native;
            cmd.Parameters.Add("@MemberClass", SqlDbType.NVarChar).Value = mod.MemberClass;
            cmd.Parameters.Add("@SchoolConsent", SqlDbType.NVarChar).Value = mod.SchoolConsent;
            cmd.Parameters.Add("@StudentIDCard", SqlDbType.NVarChar).Value = mod.StudentIDCard;
            cmd.Parameters.Add("@StudentIDCardFileType", SqlDbType.NVarChar).Value = mod.StudentIDCardFileType;
            cmd.Parameters.Add("@School", SqlDbType.NVarChar).Value = mod.School;
            cmd.Parameters.Add("@CollegeDepartment", SqlDbType.NVarChar).Value = mod.CollegeDepartment;
            cmd.Parameters.Add("@Education", SqlDbType.NVarChar).Value = mod.Education;
            cmd.Parameters.Add("@Job", SqlDbType.NVarChar).Value = mod.Job;
            cmd.Parameters.Add("@JobTitle", SqlDbType.NVarChar).Value = mod.JobTitle;
            cmd.Parameters.Add("@Student", SqlDbType.Bit).Value = mod.Student;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = mod.Mobile;
            cmd.Parameters.Add("@TEL", SqlDbType.NVarChar).Value = mod.TEL;
            cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = mod.FAX;
            cmd.Parameters.Add("@ZipCodeH", SqlDbType.NVarChar).Value = mod.ZipCodeH;
            cmd.Parameters.Add("@CityH", SqlDbType.NVarChar).Value = mod.CityH;
            cmd.Parameters.Add("@AreaH", SqlDbType.NVarChar).Value = mod.AreaH;
            cmd.Parameters.Add("@AddressH", SqlDbType.NVarChar).Value = mod.AddressH;
            cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = mod.ZipCode;
            cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = mod.City;
            cmd.Parameters.Add("@Area", SqlDbType.NVarChar).Value = mod.Area;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = mod.Address;
            cmd.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = mod.Memo;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = mod.Status;
            cmd.Parameters.Add("@EDM", SqlDbType.Bit).Value = mod.EDM;
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@UpdateUser", SqlDbType.NVarChar).Value = mod.UpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(string strMemberPID)
        {
            SqlCommand cmd = new SqlCommand("STP_MemberPDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberPID", SqlDbType.NVarChar).Value = strMemberPID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MMemberP GetModel(string strMemberPID)
        {
            SqlCommand cmd = new SqlCommand("STP_MemberPGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MemberPID", SqlDbType.NVarChar).Value = strMemberPID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MMemberP mod = SetModel(dr);
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
        //public List<Models.MMemberP> GetList()
        //{
        //    SqlCommand cmd = new SqlCommand("STP_MemberPGet");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MMemberP SetModel(SqlDataReader dr)
        {
            Models.MMemberP mod = new Models.MMemberP();
            while (dr.Read())
            {
                mod.MemberPID = dr["MemberPID"].ToString();
                mod.MemberPassword = dr["MemberPassword"].ToString();
                mod.NameC = dr["NameC"].ToString();
                mod.NameE = dr["NameE"].ToString();
                mod.Email = dr["Email"].ToString();
                mod.PID = dr["PID"].ToString();
                mod.Birthday = SQLUtil.GetDateTime(dr["Birthday"]);
                mod.RegisterDate = DateTime.Parse(dr["RegisterDate"].ToString());
                mod.Sex = dr["Sex"].ToString();
                mod.Native = dr["Native"].ToString();
                mod.MemberClass = dr["MemberClass"].ToString();
                mod.SchoolConsent = dr["SchoolConsent"].ToString();
                mod.StudentIDCard = dr["StudentIDCard"].ToString();
                mod.StudentIDCardFileType = dr["StudentIDCardFileType"].ToString();
                mod.School = dr["School"].ToString();
                mod.CollegeDepartment = dr["CollegeDepartment"].ToString();
                mod.Education = dr["Education"].ToString();
                mod.Job = dr["Job"].ToString();
                mod.JobTitle = dr["JobTitle"].ToString();
                mod.Student = bool.Parse(dr["Student"].ToString());
                mod.Mobile = dr["Mobile"].ToString();
                mod.TEL = dr["TEL"].ToString();
                mod.FAX = dr["FAX"].ToString();
                mod.ZipCodeH = dr["ZipCodeH"].ToString();
                mod.CityH = dr["CityH"].ToString();
                mod.AreaH = dr["AreaH"].ToString();
                mod.AddressH = dr["AddressH"].ToString();
                mod.ZipCode = dr["ZipCode"].ToString();
                mod.City = dr["City"].ToString();
                mod.Area = dr["Area"].ToString();
                mod.Address = dr["Address"].ToString();
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
        private Models.MMemberP SetModel(DataRow dr)
        {
            Models.MMemberP mod = new Models.MMemberP();
            mod.MemberPID = dr["MemberPID"].ToString();
            mod.MemberPassword = dr["MemberPassword"].ToString();
            mod.NameC = dr["NameC"].ToString();
            mod.NameE = dr["NameE"].ToString();
            mod.Email = dr["Email"].ToString();
            mod.PID = dr["PID"].ToString();
            mod.Birthday = SQLUtil.GetDateTime(dr["Birthday"]);
            mod.RegisterDate = DateTime.Parse(dr["RegisterDate"].ToString());
            mod.Sex = dr["Sex"].ToString();
            mod.Native = dr["Native"].ToString();
            mod.MemberClass = dr["MemberClass"].ToString();
            mod.SchoolConsent = dr["SchoolConsent"].ToString();
            mod.StudentIDCard = dr["StudentIDCard"].ToString();
            mod.StudentIDCardFileType = dr["StudentIDCardFileType"].ToString();
            mod.School = dr["School"].ToString();
            mod.CollegeDepartment = dr["CollegeDepartment"].ToString();
            mod.Education = dr["Education"].ToString();
            mod.Job = dr["Job"].ToString();
            mod.JobTitle = dr["JobTitle"].ToString();
            mod.Student = bool.Parse(dr["Student"].ToString());
            mod.Mobile = dr["Mobile"].ToString();
            mod.TEL = dr["TEL"].ToString();
            mod.FAX = dr["FAX"].ToString();
            mod.ZipCodeH = dr["ZipCodeH"].ToString();
            mod.CityH = dr["CityH"].ToString();
            mod.AreaH = dr["AreaH"].ToString();
            mod.AddressH = dr["AddressH"].ToString();
            mod.ZipCode = dr["ZipCode"].ToString();
            mod.City = dr["City"].ToString();
            mod.Area = dr["Area"].ToString();
            mod.Address = dr["Address"].ToString();
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
        private List<Models.MMemberP> GetList(DataSet ds)
        {
            List<Models.MMemberP> li = new List<Models.MMemberP>();
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
        public List<Models.MMemberP> GetListByKeyword(string strKeyword, string strMemberClass, string strStatus, string strEducation)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();


            sbTSQL.Append("select * from [TB_MemberP]  where 1=1");
            if (strKeyword.Length != 0)
            {
                sbTSQL.Append("And MemberPID like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or NameC like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or NameE like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or CollegeDepartment like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or Job like " + "'%" + strKeyword + "%'");
                sbTSQL.Append("or JobTitle like " + "'%" + strKeyword + "%'");
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
            if (strEducation != "全部")
            {
                sbTSQL.Append("and Education=" + "'" + strEducation + "'");
            }
            //sbTSQL.Append("order by UpdateDate");

            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 刪除Specialty全部資料
        /// <summary>
        public bool DelAllSpecialty()
        {
            SqlCommand cmd = new SqlCommand("Delete from [TB_MemberPSpecialty] ");
            cmd.CommandType = CommandType.Text;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        #endregion
    }
}
