using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace UniversityGraduate
{
    public class SqlHelper
    {
        private static string connString = ConfigurationManager.AppSettings["ConnString"];
        public static int ExecNoQuery(string sqlStr)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public static Object ExecObject(string sqlStr)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public static SqlDataReader ExecReader(string sqlStr)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable ExecTable(string sqlStr)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            try
            {
                conn.Open();
                DataTable ret = new DataTable();
                SqlDataAdapter temp = new SqlDataAdapter();
                temp.SelectCommand = cmd;
                temp.Fill(ret);
                return ret;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

        }
        public static string ToSqlQuoteString(Object obj)
        {
            return @"'" + Convert.ToString(UnifyHelper.getSafeString(obj)) + @"'";
        }
    }
}