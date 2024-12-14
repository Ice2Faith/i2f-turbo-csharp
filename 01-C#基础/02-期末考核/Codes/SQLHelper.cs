using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
///SQLHelper 的摘要说明
/// </summary>
public class SQLHelper
{
    private static SqlConnection sql=new SqlConnection();
    public static void SetConnectString(string str)
    {
        sql.ConnectionString=str;//ConfigurationManager.AppSettings["ConnectionString"];
    }
	public static void OpenConnect()
    {
        sql.Open();
    }
    public static void CloseConnect()
    {
        sql.Close();
    }
    public static int ExecNoQuery(string str)
    {
        OpenConnect();
        SqlCommand cmd=new SqlCommand(str,sql);
        int ret=cmd.ExecuteNonQuery();
        CloseConnect();
        return ret;
	}
    public static Object ExecObject(string str)
    {
        OpenConnect();
        SqlCommand cmd=new SqlCommand(str,sql);
        Object ret=cmd.ExecuteScalar();
        CloseConnect();
        return ret;
    }
    public static SqlDataReader ExecReader(string str)
    {
        OpenConnect();
        SqlCommand cmd=new SqlCommand(str,sql);
        SqlDataReader ret=cmd.ExecuteReader();
        CloseConnect();
        return ret;
    }
    public static DataTable ExecTable(string str)
    {
        OpenConnect();
        DataTable ret=new DataTable();
        SqlCommand cmd=new SqlCommand(str,sql);
        SqlDataAdapter temp = new SqlDataAdapter();
        temp.SelectCommand = cmd;
        temp.Fill(ret);
        CloseConnect();
        return ret;
    }
}