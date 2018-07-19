using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace TestLibrary.Common
{
    class SQLOle
    {
        //資料庫連線字串FoodData
        public static string cs = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +/*"" Application.StartupPath.Replace("bin\\", "").Replace("\\Debug", "") */"D:\\FST\\DATA" +"\\FoodData.mdb";

        /// <summary>
        /// 執行查詢語句，回傳DataSet
        /// </summary>
        /// <param name="cmd">OleDbCommand</param>
        /// <returns>DataSet</returns>
        public static DataSet QueryDS(OleDbCommand cmd)
        {
            using (OleDbConnection cn = new OleDbConnection(cs))
            {
                cmd.Connection = cn;
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds);
                    }
                    catch (OleDbException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }
       

    }
}
