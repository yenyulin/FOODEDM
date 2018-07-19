using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace TestLibrary.Common
{
    /// <summary>
    /// SQL Utility
    /// </summary>
    public abstract class SQLUtil
    {
	    public SQLUtil()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }

        //資料庫連接字符串(web.config)
        //public static readonly string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        //public static readonly string CS = "SERVER= 60.250.64.134,6633;DATABASE=FoodOrg;UID=webap;Password=webap2008$$";


        //public static readonly string CS = "Data Source=localhost;Initial Catalog=FoodOrg;Integrated Security=True;";
        //public static readonly string CS = "SERVER=VM_WEB-FST\\SQLEXPRESS;DATABASE=FoodOrg;UID=webap;Password=webap2008$$";

        public static readonly string CS = "SERVER=ANYWEB\\ANYWEB;DATABASE=FoodOrg;UID=webap;Password=webap2018$$";
        
  
        /// <summary>
        /// 執行SQL語句，回傳影響的資料筆數
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>影響的資料筆數</returns>
        public static int ExecuteSql(SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                cmd.Connection = cn;
                cn.Open();
                int intRows = cmd.ExecuteNonQuery();
                cn.Close();
                return intRows;
            }
        }

        /// <summary>
        /// 執行SQL語句，回傳影響的資料筆數
        /// </summary>
        /// <param name="strConn">連線字串</param>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>影響的資料筆數</returns>
        public static int ExecuteSql(string strConn, SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(strConn))
            {
                cmd.Connection = cn;
                cn.Open();
                int intRows = cmd.ExecuteNonQuery();
                cn.Close();
                return intRows;
            }
        }

        /// <summary>
        /// 執行SQL語句，回傳結果
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>影響的資料筆數</returns>
        public static object ExecuteScalar(SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                cmd.Connection = cn;
                cn.Open();
                object obj = cmd.ExecuteScalar();
                cn.Close();
                return obj;
            }
        }

        /// <summary>
        /// 執行SQL語句，回傳結果
        /// </summary>
        /// <param name="strConn">連線字串</param>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>影響的資料筆數</returns>
        public static object ExecuteScalar(string strConn, SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(strConn))
            {
                cmd.Connection = cn;
                cn.Open();
                object obj = cmd.ExecuteScalar();
                cn.Close();
                return obj;
            }
        }

        /// <summary>
        /// 執行查詢語句，回傳DataSet
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>DataSet</returns>
        public static DataSet QueryDS(SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                cmd.Connection = cn;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds);
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        /// <summary>
        /// 執行查詢語句，回傳DataSet
        /// </summary>
        /// <param name="strConn">連線字串</param>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>DataSet</returns>
        public static DataSet QueryDS(string strConn, SqlCommand cmd)
        {
            using (SqlConnection cn = new SqlConnection(strConn))
            {
                cmd.Connection = cn;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds);
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        /// <summary>
        /// 執行查詢語句，回傳SqlDataReader
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader QueryDR(SqlCommand cmd)
        {
            SqlConnection cn = new SqlConnection(CS);
            SqlDataReader dr;
            try
            {
                cmd.Connection = cn;
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dr;
        }

        /// <summary>
        /// 執行查詢語句，回傳SqlDataReader
        /// </summary>
        /// <param name="strConn">連線字串</param>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader QueryDR(string strConn, SqlCommand cmd)
        {
            SqlConnection cn = new SqlConnection(strConn);
            SqlDataReader dr;
            try
            {
                cmd.Connection = cn;
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dr; 
        }

        /// <summary>
        /// 由Table Name與PK Value取得Count結果與訊息
        /// </summary>
        /// <param name="strTable">Table Name</param>
        /// <param name="strPK">PK Value</param>
        /// <param name="strPK">Message</param>
        /// <param name="strPK">不需要確認的資料表</param>
        /// <returns>SqlDataReader</returns>
        public static bool GetFKCount(string TableName, object PKValue, ArrayList alTables, out string Message)
        {
            bool isCheck = true;
            string strMsg="";
            StringBuilder sbSql = new StringBuilder();
            using (SqlDataReader dr = QueryFK(TableName))
            {
                if (dr.HasRows)
                {
                    int i = 0;
                    while (dr.Read())
                    {
                        //排除不需要Check的資料表
                        if(alTables==null || !alTables.Contains(dr["FKTableName"].ToString()))
                        {
                            if (i > 0)
                            {
                                sbSql.Append(" union ");
                            }
                            sbSql.Append("select TableDesc='" + dr["TableDesc"].ToString() + "',Total=count(*) ");
                            sbSql.Append("from " + dr["FKTableName"].ToString() + " ");
                            sbSql.Append("where  " + dr["FKColumnName"].ToString() + "=@PKValue");
                            i++;
                        }
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sbSql.ToString();
                    cmd.Parameters.AddWithValue("@PKValue", PKValue);
                    using (SqlDataReader drC = QueryDR(CS, cmd))
                    {
                        while (drC.Read())
                        {
                            if (int.Parse(drC["Total"].ToString()) > 0)
                            {
                                isCheck = false;
                                strMsg += "‧" + drC["TableDesc"].ToString() + "資料(" + drC["Total"].ToString() + "筆)。\\n\\n";
                            }
                        }
                        drC.Close();
                    }
                    if (strMsg.Length > 0)
                    {
                        strMsg = "不可刪除，資料被以下使用：\\n\\n" + strMsg;
                    }
                }
                dr.Close();
                Message = strMsg;
            }
            return isCheck;
        }

        /// <summary>
        /// 執行SQL語句，回傳影響的資料筆數
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>影響的資料筆數</returns>
        public static int CheckConnectionState()
        {
            using (SqlConnection cn = new SqlConnection(CS))
            {
                int intState = 0;

                cn.Open();
                if (cn.State == ConnectionState.Open)
                {
                    intState = 1;
                }
                cn.Close();
                return intState;
            }
        }

        /// <summary>
        /// 查詢FK
        /// </summary>
        /// <param name="strTable">Table Name</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader QueryFK(string TableName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "STP_GetFKInfo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TableName", TableName);
            return QueryDR(CS, cmd);
        }

        /// <summary>
        /// 資料庫輸入值的Check
        /// </summary>
        /// <param name="obj">資料庫輸入值</param>
        /// <returns>確認後的資料庫輸入值</returns>
        public static object CheckDBValue(object obj)
        {
            if (obj == null)
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }

                                                                                                                                                                                                                                                                                                                                                                                                        #region 由Object取值

        /// <summary>
        /// 取得string值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>字串</returns>
        public static string GetString(object obj)
        {
            return obj.ToString();
        }

        /// <summary>
        /// 取得Int值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>Int or Null</returns>
        public static int? GetInt(object obj)
        {
            if (obj != DBNull.Value)
                return int.Parse(obj.ToString());
            else
                return null;
        }

        /// <summary>
        /// 取得Decimal值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>Decimal or Null</returns>
        public static decimal? GetDecimal(object obj)
        {
            if (obj != DBNull.Value)
                return decimal.Parse(obj.ToString());
            else
                return null;
        }

        /// <summary>
        /// 取得DateTime值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>DateTime or Null</returns>
        public static DateTime? GetDateTime(object obj)
        {
            if (obj != DBNull.Value)
                return DateTime.Parse(obj.ToString());
            else
                return null;
        }

        /// <summary>
        /// 取得bool值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>bool or Null</returns>
        public static bool? GetBool(object obj)
        {
            if (obj.ToString() == "1" || obj.ToString().ToLower() == "true")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 取得byte[]
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>byte[] or Null</returns>
        public static Byte[] GetByte(object obj)
        {
            if (obj != DBNull.Value)
            {
                return (Byte[])obj;
            }
            else
                return null;
        }

        /// <summary>
        /// 取得Guid值
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>Guid or Guid.Empty</returns>
        public static Guid GetGuid(object obj)
        {
            if (obj != DBNull.Value)
                return new Guid(obj.ToString());
            else
                return Guid.Empty;
        }

    #endregion\

    }
}