using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.IO;

namespace UniversityGraduate
{
    public class UnifyHelper
    {
        public static InnerSysDate ConvertToInnerSysDate(SystemDate sd)
        {
            InnerSysDate ret = new InnerSysDate();
            ret.date0 = GetParseDateTime(sd.Date0);
            ret.date1 = GetParseDateTime(sd.Date1);
            ret.date2 = GetParseDateTime(sd.Date2);
            ret.date3 = GetParseDateTime(sd.Date3);
            ret.date4 = GetParseDateTime(sd.Date4);
            return ret;
        }
        public static string GetNowDateTime()
        {
            return FormatDateTime(DateTime.Now);
        }
        public static string FormatDateTime(DateTime dt)
        {
            return dt.ToString("yyyy年MM月dd日 HH:mm:ss").Trim();
        }
        public static DateTime GetParseDateTime(string dtStr)
        {
            string[] dtInfo = new string[6];
            string buffer = "";
            int index = 0;
            for (int i = 0; i < dtStr.Length; i++)
            {
                if (dtStr[i] >= '0' && dtStr[i] <= '9')
                {
                    buffer += dtStr[i];
                }
                else
                {
                    if (index > 5)
                        break;
                    if (dtStr[i - 1] >= '0' && dtStr[i - 1] <= '9')
                    {
                        dtInfo[index++] = buffer;
                        buffer = "";
                    }
                    if (i == dtStr.Length - 1)
                    {
                        dtInfo[index++] = buffer;
                        buffer = "";
                    }
                }
            }
            int year = Convert.ToInt32(dtInfo[0]);
            int month = Convert.ToInt32(dtInfo[1]);
            int day = Convert.ToInt32(dtInfo[2]);
            int hour = Convert.ToInt32(dtInfo[3]);
            int minus = Convert.ToInt32(dtInfo[4]);
            int second = Convert.ToInt32(dtInfo[5]);
            DateTime ret = new DateTime(year, month, day, hour, minus, second);
            return ret;
        }
        public static string getSafeString(Object obj)
        {
            return (obj == null || obj == Convert.DBNull ? null : obj.ToString().Trim());
        }
        public static Object getNotDbNullObj(Object obj)
        {
            return (obj == null || obj == Convert.DBNull ? null : obj);
        }
        public static string MakeJsAlertString(string content)
        {
            return "<script>alert('" + content + "');</script>";
        }
        public static string MakeJsString(string content)
        {
            return "<script>" + content + "</script>";
        }
        /// <summary>
        /// 对tableName表生成一条查询语句，查询列cols数组中，and条件列名whereCols条件值whereVals
        /// 如果whereCols和whereVals个数不一致，将按照最小个数进行匹配
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="cols"></param>
        /// <param name="whereCols"></param>
        /// <param name="whereVals"></param>
        /// <returns></returns>
        public static string CreateSqlSelectLang(string tableName, string[] cols, string[] whereCols, string[] whereVals)
        {
            string str1 = "";
            string str2 = "";
            bool isFirst = true;
            foreach (string tp in cols)
            {
                if (!isFirst)
                {
                    str1 += ",";
                }
                if (isFirst)
                {
                    isFirst = false;
                }
                str1 += tp.Trim();
            }
            isFirst = true;
            int minCount = whereCols.Length > whereVals.Length ? whereVals.Length : whereCols.Length;
            for (int i = 0; i < minCount; i++)
            {
                if (!isFirst)
                {
                    str2 += " AND ";
                }
                if (isFirst)
                {
                    isFirst = false;
                }
                str2 += whereCols[i].Trim() + "=" + whereVals[i].Trim();
            }
            return @"SELECT " + str1 + " FROM " + tableName.Trim() + " WHERE " + str2 + ";";
        }

        public static string CreateSqlInsertLang(string tableName, string[] cols, string[] vals)
        {
            string str1 = "";
            string str2 = "";
            bool isFirst = true;
            int minCount = cols.Length > vals.Length ? vals.Length : cols.Length;
            for (int i = 0; i < minCount; i++)
            {
                if (!isFirst)
                {
                    str1 += ",";
                    str2 += ",";
                }
                if (isFirst)
                {
                    isFirst = false;
                }
                str1 += cols[i].Trim();
                str2 += vals[i].Trim();
            }
            return @"INSERT INTO " + tableName.Trim() + "(" + str1 + ") VALUES(" + str2 + ");";
        }
        public static string CreateSqlUpdateLang(string tableName, string[] cols, string[] vals, string whereCol, string whereVal)
        {
            string str1 = "";
            bool isFirst = true;
            int minCount = cols.Length > vals.Length ? vals.Length : cols.Length;
            for (int i = 0; i < minCount; i++)
            {
                if (!isFirst)
                {
                    str1 += ",";
                }
                if (isFirst)
                {
                    isFirst = false;
                }
                str1 += cols[i].Trim() + "=" + vals[i].Trim();
            }
            return @"UPDATE " + tableName.Trim() + " SET " + str1 + " WHERE " + whereCol.Trim() + "=" + whereVal.Trim() + ");";
        }
        public static string CreateSqlDeleteLang(string tableName, string[] cols, string[] vals)
        {
            string str1 = "";
            bool isFirst = true;
            int minCount = cols.Length > vals.Length ? vals.Length : cols.Length;
            for (int i = 0; i < minCount; i++)
            {
                if (!isFirst)
                {
                    str1 += " AND ";
                }
                if (isFirst)
                {
                    isFirst = false;
                }
                str1 += cols[i].Trim() + "=" + vals[i].Trim();
            }
            return @"DELETE FROM " + tableName.Trim() + " WHERE " + str1 + ";";
        }

    }
}