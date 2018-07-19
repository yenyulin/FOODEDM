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
    /// 資料存取層 AwardWinner
    /// </summary>
    public class DAwardWinner
    {
        public DAwardWinner() { }

        #region 基本方法

        /// <summary>
        /// 新增資料
        /// </summary>
        public int Add(Models.MAwardWinner mod)
        {
            SqlCommand cmd = new SqlCommand("STP_AwardWinnerAdd");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AwardID", SqlDbType.Int).Value = mod.AwardID;
            cmd.Parameters.Add("@AwardTypeID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.AwardTypeID);
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = mod.Year;
            cmd.Parameters.Add("@Works", SqlDbType.NVarChar).Value = mod.Works;
            //cmd.Parameters.Add("@WinnerID", SqlDbType.Int).Value = mod.WinnerID;
            cmd.Parameters.Add("@WinnerName", SqlDbType.NVarChar).Value = mod.WinnerName;
            cmd.Parameters.Add("@Photo", SqlDbType.Image).Value = SQLUtil.CheckDBValue(mod.Photo);
            cmd.Parameters.Add("@Contents", SqlDbType.NVarChar).Value = mod.Contents;
            //cmd.Parameters.Add("@WinnerTitle", SqlDbType.NVarChar).Value = SQLUtil.CheckDBValue(mod.WinnerTitle);
            //cmd.Parameters.Add("@Experience", SqlDbType.NVarChar).Value = SQLUtil.CheckDBValue(mod.Experience);
            //cmd.Parameters.Add("@Contribution", SqlDbType.NVarChar).Value = SQLUtil.CheckDBValue(mod.Contribution);
            //cmd.Parameters.Add("@Draft", SqlDbType.Bit).Value = SQLUtil.CheckDBValue(mod.Draft);
            cmd.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = mod.CreateUser;
            cmd.Parameters.Add("@LastUpdateUser", SqlDbType.NVarChar).Value = mod.LastUpdateUser;
            object obj = SQLUtil.ExecuteScalar(cmd);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                mod.AwardWinnerID = intID;
            }
            return intID;
        }
        /// <summary>
        /// 修改資料
        /// <summary>
        public bool Edit(Models.MAwardWinner mod)
        {
            SqlCommand cmd = new SqlCommand("STP_AwardWinnerEdit");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AwardWinnerID", SqlDbType.Int).Value = mod.AwardWinnerID;
            cmd.Parameters.Add("@AwardID", SqlDbType.Int).Value = mod.AwardID;
            cmd.Parameters.Add("@AwardTypeID", SqlDbType.Int).Value = SQLUtil.CheckDBValue(mod.AwardTypeID);
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = mod.Year;
            cmd.Parameters.Add("@Works", SqlDbType.NVarChar).Value = mod.Works;
            cmd.Parameters.Add("@WinnerName", SqlDbType.NVarChar).Value = mod.WinnerName;
            cmd.Parameters.Add("@Photo", SqlDbType.Image).Value = SQLUtil.CheckDBValue(mod.Photo);
            cmd.Parameters.Add("@Contents", SqlDbType.NVarChar).Value = mod.Contents;
            cmd.Parameters.Add("@LastUpdateUser", SqlDbType.NVarChar).Value = mod.LastUpdateUser;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 刪除資料
        /// <summary>
        public bool Del(int intAwardWinnerID)
        {
            SqlCommand cmd = new SqlCommand("STP_AwardWinnerDel");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AwardWinnerID", SqlDbType.Int).Value = intAwardWinnerID;
            return SQLUtil.ExecuteSql(cmd) > 0;
        }

        /// <summary>
        /// 取得單筆資料
        /// <summary>
        public Models.MAwardWinner GetModel(int intAwardWinnerID)
        {
            SqlCommand cmd = new SqlCommand("STP_AwardWinnerGetByPK");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AwardWinnerID", SqlDbType.Int).Value = intAwardWinnerID;
            SqlDataReader dr = SQLUtil.QueryDR(cmd);
            bool isHasRows = dr.HasRows;
            Models.MAwardWinner mod = SetModel(dr);
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
        public List<Models.MAwardWinner> GetList()
        {
            SqlCommand cmd = new SqlCommand("STP_AwardWinnerGet");
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 實體物件取得DataReader資料
        /// </summary>
        private Models.MAwardWinner SetModel(SqlDataReader dr)
        {
            Models.MAwardWinner mod = new Models.MAwardWinner();
            while (dr.Read())
            {
                mod.AwardWinnerID = int.Parse(dr["AwardWinnerID"].ToString());
                mod.AwardID = int.Parse(dr["AwardID"].ToString());
                mod.AwardTypeID = SQLUtil.GetInt(dr["AwardTypeID"]);
                mod.Year = int.Parse(dr["Year"].ToString());
                mod.Works = dr["Works"].ToString();
                mod.WinnerName = dr["WinnerName"].ToString();
                if (dr["Photo"] != DBNull.Value)
                {
                    mod.Photo = (Byte[])dr["Photo"];
                }
                mod.Contents = dr["Contents"].ToString();
                mod.CreateUser = dr["CreateUser"].ToString();
                mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
                mod.LastUpdateUser = dr["LastUpdateUser"].ToString();
                mod.LastUpdateDate = DateTime.Parse(dr["LastUpdateDate"].ToString());
            }
            return mod;
        }

        /// <summary>
        /// 實體物件取得DataRow資料
        /// </summary>
        private Models.MAwardWinner SetModel(DataRow dr)
        {
            Models.MAwardWinner mod = new Models.MAwardWinner();
            mod.AwardWinnerID = int.Parse(dr["AwardWinnerID"].ToString());
            mod.AwardID = int.Parse(dr["AwardID"].ToString());
            mod.AwardTypeID = SQLUtil.GetInt(dr["AwardTypeID"]);
            mod.Year = int.Parse(dr["Year"].ToString());
            mod.Works = dr["Works"].ToString();
            mod.WinnerName = dr["WinnerName"].ToString();
            if (dr["Photo"] != DBNull.Value)
            {
                mod.Photo = (Byte[])dr["Photo"];
            }
            mod.Contents = dr["Contents"].ToString();
            mod.CreateUser = dr["CreateUser"].ToString();
            mod.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            mod.LastUpdateUser = dr["LastUpdateUser"].ToString();
            mod.LastUpdateDate = DateTime.Parse(dr["LastUpdateDate"].ToString());
            return mod;
        }


        /// <summary>
        /// 由DataSet取得泛型資料列表
        /// </summary>
        private List<Models.MAwardWinner> GetList(DataSet ds)
        {
            List<Models.MAwardWinner> li = new List<Models.MAwardWinner>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(SetModel(dr));
            }
            return li;
        }

        #endregion

        #region  自訂方法

        ///// <summary>
        ///// 用keyword取得所有AwardWinner資料
        ///// </summary>
        //public List<Models.MAwardWinner> GetListByKeyword(int intPageSize, int intPageIndex, string strKeyword)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_AwardWinnerGetByKeyword");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = "%" + strKeyword + "%";
        //    cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = intPageSize;
        //    cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = intPageIndex;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        ///// <summary>
        ///// 計算用keyword取得所有AwardWinner資料筆數
        ///// </summary>
        //public int GetCountByKeyword(string strKeyword)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_AwardWinnerCountByKeyword");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = "%" + strKeyword + "%";
        //    return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        //}

        /// <summary>
        /// 用AwardID取得d資料
        /// </summary>
        public List<Models.MAwardWinner> GetListByAwardID(int intPageSize, int intPageIndex, int AwardID)
        {
            SqlCommand cmd = new SqlCommand("STP_AwardWinnerGetByAwardID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AwardID", SqlDbType.Int).Value = AwardID;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = intPageSize;
            cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = intPageIndex;
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        /// <summary>
        /// 計算用AwardID取得資料筆數
        /// </summary>
        public int GetCountByAwardID(int AwardID)
        {
            SqlCommand cmd = new SqlCommand("STP_AwardWinnerCountByAwardID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AwardID", SqlDbType.Int).Value = AwardID;
            return Convert.ToInt32(SQLUtil.ExecuteScalar(cmd));
        }
        /**/

        ///// <summary>
        ///// 以AwardID取得所有資料
        ///// </summary>
        //public List<Models.MAwardWinner> GetListByAwardID(int AwardID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_AwardWinnerGetByAwardID");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@AwardID", SqlDbType.Int).Value = AwardID;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        ///// <summary>
        ///// 以AwardID和Year取得所有資料取得所有AwardWinner資料
        ///// </summary>
        //public List<Models.MAwardWinner> GetListByAwardIDAndYear(int AwardID,DateTime dtYear)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_AwardWinnerGetByAwardIDAndYear");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@AwardID", SqlDbType.Int).Value = AwardID;
        //    cmd.Parameters.Add("@Year", SqlDbType.DateTime).Value = dtYear;
        //    DataSet ds = SQLUtil.QueryDS(cmd);
        //    return GetList(ds);
        //}

        ///// <summary>
        ///// WinnerID將AwardWinner刪除
        ///// <summary>
        //public bool DelByWinnerID(int intWinnerID)
        //{
        //    SqlCommand cmd = new SqlCommand("STP_AwardWinnerDelByWinnerID");
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@WinnerID", SqlDbType.Int).Value = intWinnerID;
        //    return SQLUtil.ExecuteSql(cmd) > 0;
        //}

        /// <summary>
        ///  以CompanyImportIDCompanyID、CompanyName和地址取得全部資料
        /// </summary>
        public List<Models.MAwardWinner> GetListForTest()
        {
            SqlCommand cmd = new SqlCommand();
            StringBuilder sbTSQL = new StringBuilder();
            //sbTSQL.Append("select * from [TB_Company] where CompanyID=CompanyID ");
            sbTSQL.Append("SELECT *  FROM [FoodOrg].[dbo].[TB_AwardWinner] ");
            cmd.CommandText = sbTSQL.ToString();
            DataSet ds = SQLUtil.QueryDS(cmd);
            return GetList(ds);
        }

        #endregion
    }
}