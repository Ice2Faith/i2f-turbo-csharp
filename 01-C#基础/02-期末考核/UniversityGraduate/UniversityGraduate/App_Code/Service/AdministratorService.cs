using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace UniversityGraduate
{
    public class AdministratorService
    {
        public static Administrator Login(Administrator admin)
        {
            string sqlStr = @"SELECT ano,aname,apwd,adepartment FROM Administrator WHERE ano=" + SqlHelper.ToSqlQuoteString(admin.Ano) + " AND apwd=" + SqlHelper.ToSqlQuoteString(admin.Apwd) + ";";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                admin.Aname = Convert.ToString(reader["aname"]);
                admin.Apwd = Convert.ToString(reader["apwd"]);
                admin.Adepartment = Convert.ToString(reader["adepartment"]);
                admin.AlastLogin = UnifyHelper.GetNowDateTime();
            }
            else
            {
                admin = null;
            }
            reader.Close();
            return admin;
        }
        public static Administrator GetAdminInfo(Administrator admin)
        {
            Administrator ret = null;
            string sqlStr = @"SELECT ano,apwd,atype,acollege,adepartment,aname,alastLogin FROM Administrator WHERE ano=" + SqlHelper.ToSqlQuoteString(admin.Ano) + ";";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                //这里类型转换最好使用convert方式，否则数据库如果是空项，将会报错，convert就不会
                ret = new Administrator();
                ret.Ano = UnifyHelper.getSafeString(reader["ano"]);
                ret.Aname = UnifyHelper.getSafeString(reader["aname"]);
                ret.Apwd = UnifyHelper.getSafeString(reader["apwd"]);
                ret.Acollege = UnifyHelper.getSafeString(reader["acollege"]);
                ret.Adepartment = UnifyHelper.getSafeString(reader["adepartment"]);
                ret.Atype = UnifyHelper.getSafeString(reader["atype"]);
                ret.AlastLogin = Convert.ToString(reader["alastLogin"]);
            }
            reader.Close();
            return ret;
        }
        public static bool UpdateAdminInfo(Administrator admin)
        {
            bool ret = false;
            string str1 = "";

            if (admin.Aname != null)
            {
                str1 += "aname=" + SqlHelper.ToSqlQuoteString(admin.Aname);
            }
            if (admin.Apwd != null)
            {
                str1 += ",apwd=" + SqlHelper.ToSqlQuoteString(admin.Apwd);
            }
            if (admin.Acollege != null)
            {
                str1 += ",acollege=" + SqlHelper.ToSqlQuoteString(admin.Acollege);
            }
            if (admin.Adepartment != null)
            {
                str1 += ",adepartment=" + SqlHelper.ToSqlQuoteString(admin.Adepartment);
            }
            if (admin.Atype != null)
            {
                str1 += ",atype=" + SqlHelper.ToSqlQuoteString(admin.Atype);
            }
            if (admin.AlastLogin != null)
            {
                str1 += ",alastLogin=" + SqlHelper.ToSqlQuoteString(admin.AlastLogin);
            }

            string sqlStr = @"UPDATE Administrator SET " + str1 + " WHERE Ano=" + SqlHelper.ToSqlQuoteString(admin.Ano) + ";";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool UpdateAllStudentNullPhoto(string urlImage)
        {
            bool ret = false;
            string sqlStr = @"UPDATE Student SET sphoto=" + SqlHelper.ToSqlQuoteString(urlImage.Trim()) + " WHERE sphoto is null;";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool UpdateAllTeacherNullPhoto(string urlImage)
        {
            bool ret = false;
            string sqlStr = @"UPDATE Teacher SET tphoto=" + SqlHelper.ToSqlQuoteString(urlImage.Trim()) + " WHERE tphoto is null;";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool UpdateAllAdminNullPhoto(string urlImage)
        {
            bool ret = false;
            string sqlStr = @"UPDATE Administrator SET aphoto=" + SqlHelper.ToSqlQuoteString(urlImage.Trim()) + " WHERE aphoto is null;";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool DeleteAllStudentWishs()
        {
            bool ret = false;
            string sqlStr = @"DELETE FROM Wish;";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool AllStudentWishToStart()
        {
            bool ret = false;
            string sqlStr = @"INSERT INTO Wish(sno,wstate) SELECT sno,'start' FROM student;";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool UpdateAllStudentGuideTeacherToNull()
        {
            bool ret = false;
            string sqlStr = @"UPDATE Student SET sguideTeacher=null;";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool InsertSystemDate(SystemDate sd)
        {
            bool ret = false;
            string str1 = "";
            string str2 = "";
            if(sd.Date1!=null)
            {
                str1 += ",date1";
                str2 += "," + SqlHelper.ToSqlQuoteString(sd.Date1);
            }
            if (sd.Date2 != null)
            {
                str1 += ",date2";
                str2 += "," + SqlHelper.ToSqlQuoteString(sd.Date2);
            }
            if (sd.Date3 != null)
            {
                str1 += ",date3";
                str2 += "," + SqlHelper.ToSqlQuoteString(sd.Date3);
            }
            if (sd.Date4 != null)
            {
                str1 += ",date4";
                str2 += "," + SqlHelper.ToSqlQuoteString(sd.Date4);
            }
            string sqlStr = @"INSERT INTO SystemDate(date0"+str1+") VALUES (" + SqlHelper.ToSqlQuoteString(sd.Date0)+ str2+ ");";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static SystemDate GetSystemDate()
        {
            SystemDate ret = null;
            string sqlStr = @"SELECT date0,date1,date2,date3,date4 FROM SystemDate;";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                //这里类型转换最好使用convert方式，否则数据库如果是空项，将会报错，convert就不会
                ret = new SystemDate();
                ret.Date0 = UnifyHelper.getSafeString(reader["date0"]);
                ret.Date1 = UnifyHelper.getSafeString(reader["date1"]);
                ret.Date2 = UnifyHelper.getSafeString(reader["date2"]);
                ret.Date3 = UnifyHelper.getSafeString(reader["date3"]);
                ret.Date4 = UnifyHelper.getSafeString(reader["date4"]);
            }
            reader.Close();
            return ret;
        }
        public static bool UpdateSystemDate(SystemDate sd)
        {
            bool ret = false;
            string sqlStr = @"UPDATE SystemDate SET date0=" + SqlHelper.ToSqlQuoteString(sd.Date0)
                + ",date1=" + SqlHelper.ToSqlQuoteString(sd.Date1)
                + ",date2=" + SqlHelper.ToSqlQuoteString(sd.Date2)
                + ",date3=" + SqlHelper.ToSqlQuoteString(sd.Date3)
                + ",date4=" + SqlHelper.ToSqlQuoteString(sd.Date4)
                + ";";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool UpdateAllTeacherNullSex(string sex)
        {
            bool ret = false;
            string sqlStr = @"UPDATE Teacher SET tsex=" + SqlHelper.ToSqlQuoteString(sex.Trim()) + " WHERE tsex is null;";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool UpdateAllStudentNullSex(string sex)
        {
            bool ret = false;
            string sqlStr = @"UPDATE Student SET ssex=" + SqlHelper.ToSqlQuoteString(sex.Trim()) + " WHERE ssex is null;";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool UpdateAllAdminNullType(string type)
        {
            bool ret = false;
            string sqlStr = @"UPDATE Administrator SET atype=" + SqlHelper.ToSqlQuoteString(type.Trim()) + " WHERE atype is null;";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool ResetTeacherPassword(string Tno, string pwd)
        {
            bool ret = false;
            string sqlStr = @"UPDATE Teacher SET tpwd=" + SqlHelper.ToSqlQuoteString(pwd.Trim()) + " WHERE tno=" + SqlHelper.ToSqlQuoteString(Tno.Trim()) + ";";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool ResetStudentPassword(string Sno, string pwd)
        {
            bool ret = false;
            string sqlStr = @"UPDATE Student SET spwd=" + SqlHelper.ToSqlQuoteString(pwd.Trim()) + " WHERE sno=" + SqlHelper.ToSqlQuoteString(Sno.Trim()) + ";";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool ResetAdminPassword(string Ano, string pwd)
        {
            bool ret = false;
            string sqlStr = @"UPDATE Administrator SET apwd=" + SqlHelper.ToSqlQuoteString(pwd.Trim()) + " WHERE ano=" + SqlHelper.ToSqlQuoteString(Ano.Trim()) + ";";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
    }
}