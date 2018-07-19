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
    /// 資料存取層 Paper
    /// </summary>
    public class DPaper
    {
        public DPaper() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MPaper mod)
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            sbTSQL.AppendLine("insert into [TB_Paper] ([PaperID],[TWYear],[PaperTitle],[PaperAuthor],[Company]");
            sbTSQL.AppendLine(",[SummaryC],[SummaryE],[MemberType],[MemberID],[Tel1]");
            sbTSQL.AppendLine(",[Tel2],[Ext],[Fax1],[Fax2],[Email]");
            sbTSQL.AppendLine(",[UploadDate],[PublishType],[PaperDomainID],[Publish],[FileExtension]");
            sbTSQL.AppendLine(",[Examine],[ExamineDate],[PaperNo])");
            sbTSQL.AppendLine("values (@PaperID,@TWYear,@PaperTitle,@PaperAuthor,@Company");
            sbTSQL.AppendLine(",@SummaryC,@SummaryE,@MemberType,@MemberID,@Tel1");
            sbTSQL.AppendLine(",@Tel2,@Ext,@Fax1,@Fax2,@Email");
            sbTSQL.AppendLine(",@UploadDate,@PublishType,@PaperDomainID,@Publish,@FileExtension");
            sbTSQL.AppendLine(",@Examine,@ExamineDate,@PaperNo)");
            sbTSQL.AppendLine(";select @@identity;");


            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = mod.PaperID;
            cmd.Parameters.Add("@TWYear", SqlDbType.Int).Value = mod.TWYear;
            cmd.Parameters.Add("@PaperTitle", SqlDbType.NVarChar).Value = mod.PaperTitle;
            cmd.Parameters.Add("@PaperAuthor", SqlDbType.NVarChar).Value = mod.PaperAuthor;
            cmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = mod.Company;
            cmd.Parameters.Add("@SummaryC", SqlDbType.NVarChar).Value = mod.SummaryC;
            cmd.Parameters.Add("@SummaryE", SqlDbType.NVarChar).Value = mod.SummaryE;
            cmd.Parameters.Add("@MemberType", SqlDbType.NVarChar).Value = mod.MemberType;
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = mod.MemberID;
            cmd.Parameters.Add("@Tel1", SqlDbType.NVarChar).Value = mod.Tel1;
            cmd.Parameters.Add("@Tel2", SqlDbType.NVarChar).Value = mod.Tel2;
            cmd.Parameters.Add("@Ext", SqlDbType.NVarChar).Value = mod.Ext;
            cmd.Parameters.Add("@Fax1", SqlDbType.NVarChar).Value = mod.Fax1;
            cmd.Parameters.Add("@Fax2", SqlDbType.NVarChar).Value = mod.Fax2;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mod.Email;
            cmd.Parameters.Add("@UploadDate", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.UploadDate);
            cmd.Parameters.Add("@PublishType", SqlDbType.NVarChar).Value = mod.PublishType;
            cmd.Parameters.Add("@PaperDomainID", SqlDbType.NVarChar).Value = mod.PaperDomainID;
            cmd.Parameters.Add("@Publish", SqlDbType.Bit).Value = mod.Publish;
            cmd.Parameters.Add("@FileExtension", SqlDbType.NVarChar).Value = mod.FileExtension;
            cmd.Parameters.Add("@Examine", SqlDbType.NVarChar).Value = mod.Examine;
            cmd.Parameters.Add("@ExamineDate", SqlDbType.DateTime).Value = SQLUtil.CheckDBValue(mod.ExamineDate);
            cmd.Parameters.Add("@PaperNo", SqlDbType.NVarChar).Value = mod.PaperNo;
            cmd.CommandText = sbTSQL.ToString();
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.PaperID = intID;
            }
            return intID;
        }
        

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intPaperID)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = intPaperID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MPaper GetModel(int intPaperID)
        {
            SqlCommand cmd = new SqlCommand("STP_PaperGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PaperID", SqlDbType.Int).Value = intPaperID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MPaper mod = SetModel(dr);
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
        private Models.MPaper SetModel(SqlDataReader dr)
        {
            Models.MPaper mod = new Models.MPaper();
            while (dr.Read())
            {
                mod.PaperID = int.Parse(dr["PaperID"].ToString());
                mod.TWYear = int.Parse(dr["TWYear"].ToString());
                mod.PaperTitle = dr["PaperTitle"].ToString();
                mod.PaperAuthor = dr["PaperAuthor"].ToString();
                mod.Company = dr["Company"].ToString();
                mod.SummaryC = dr["SummaryC"].ToString();
                mod.SummaryE = dr["SummaryE"].ToString();
                mod.MemberType = dr["MemberType"].ToString();
                mod.MemberID = dr["MemberID"].ToString();
                mod.Tel1 = dr["Tel1"].ToString();
                mod.Tel2 = dr["Tel2"].ToString();
                mod.Ext = dr["Ext"].ToString();
                mod.Fax1 = dr["Fax1"].ToString();
                mod.Fax2 = dr["Fax2"].ToString();
                mod.Email = dr["Email"].ToString();
                mod.UploadDate = SQLUtil.GetDateTime(dr["UploadDate"]);
                mod.PublishType = dr["PublishType"].ToString();
                mod.PaperDomainID = dr["PaperDomainID"].ToString();
                mod.Publish = bool.Parse(dr["Publish"].ToString());
                mod.FileExtension = dr["FileExtension"].ToString();
                mod.Examine = dr["Examine"].ToString();
                mod.ExamineDate = SQLUtil.GetDateTime(dr["ExamineDate"]);
                mod.PaperNo = dr["PaperNo"].ToString();
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MPaper SetModel(DataRow dr)
        {
            Models.MPaper mod = new Models.MPaper();
            mod.PaperID = int.Parse(dr["PaperID"].ToString());
            mod.TWYear = int.Parse(dr["TWYear"].ToString());
            mod.PaperTitle = dr["PaperTitle"].ToString();
            mod.PaperAuthor = dr["PaperAuthor"].ToString();
            mod.Company = dr["Company"].ToString();
            mod.SummaryC = dr["SummaryC"].ToString();
            mod.SummaryE = dr["SummaryE"].ToString();
            mod.MemberType = dr["MemberType"].ToString();
            mod.MemberID = dr["MemberID"].ToString();
            mod.Tel1 = dr["Tel1"].ToString();
            mod.Tel2 = dr["Tel2"].ToString();
            mod.Ext = dr["Ext"].ToString();
            mod.Fax1 = dr["Fax1"].ToString();
            mod.Fax2 = dr["Fax2"].ToString();
            mod.Email = dr["Email"].ToString();
            mod.UploadDate = SQLUtil.GetDateTime(dr["UploadDate"]);
            mod.PublishType = dr["PublishType"].ToString();
            mod.PaperDomainID = dr["PaperDomainID"].ToString();
            mod.Publish = bool.Parse(dr["Publish"].ToString());
            mod.FileExtension = dr["FileExtension"].ToString();
            mod.Examine = dr["Examine"].ToString();
            mod.ExamineDate = SQLUtil.GetDateTime(dr["ExamineDate"]);
            mod.PaperNo = dr["PaperNo"].ToString();
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MPaper> GetList(DataSet ds)
        {
            List<Models.MPaper> li = new List<Models.MPaper>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion


        #region  自訂方法

        /// <summary>
        /// 刪除全部paper資料
        /// <summary>
        public bool DelPaperAll()
        {
            SqlCommand cmd = new SqlCommand("Delete from [TB_Paper]");
            cmd.CommandType = CommandType.Text;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除PaperSuggestion全部資料
        /// <summary>
        public bool DelPaperSuggestionAll()
        {
            SqlCommand cmd = new SqlCommand("Delete from [TB_PaperSuggestion]");
            cmd.CommandType = CommandType.Text;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除PaperDomainSeq全部資料
        /// <summary>
        public bool DelPaperDomainSeqAll()
        {
            SqlCommand cmd = new SqlCommand("Delete from [TB_PaperDomainSeq]");
            cmd.CommandType = CommandType.Text;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }



        #endregion
    }
}
