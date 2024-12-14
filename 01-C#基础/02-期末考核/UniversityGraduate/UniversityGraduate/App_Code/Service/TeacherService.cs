using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace UniversityGraduate
{
    public class TeacherService
    {
        public static Teacher Login(Teacher tch)
        {
            string sqlStr = @"SELECT tno,tname,tpwd FROM Teacher WHERE tno=" + SqlHelper.ToSqlQuoteString(tch.Tno) + " AND tpwd=" + SqlHelper.ToSqlQuoteString(tch.Tpwd) + ";";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                tch.Tname = Convert.ToString(reader["tname"]);
                tch.Tpwd = Convert.ToString(reader["tpwd"]);
                tch.TlastLogin = UnifyHelper.GetNowDateTime();
            }
            else
            {
                tch = null;
            }
            reader.Close();
            return tch;
        }
        public static Teacher Register(Teacher tch)
        {
            string sqlQuery = @"SELECT TOP 1 tno FROM Teacher ORDER BY tno DESC;";
            string maxno = SqlHelper.ExecObject(sqlQuery).ToString().Trim();
            long newno = Convert.ToInt64(maxno) + 1;
            tch.Tno = newno.ToString().Trim();
            string sqlStr = @"INSERT INTO Teacher(tno,tname,tpwd) VALUES(" + SqlHelper.ToSqlQuoteString(tch.Tno) + ","
                + SqlHelper.ToSqlQuoteString(tch.Tname) + ","
                + SqlHelper.ToSqlQuoteString(tch.Tpwd) + ");";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                return tch;
            return null;
        }
        public static List<Student> GetWishedStudent(Teacher tch)
        {
            List<Student> ret = null;
            string sqlStr = @"SELECT sno,sname FROM Student WHERE sguideTeacher=" + SqlHelper.ToSqlQuoteString(tch.Tno) + ";";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                ret = new List<Student>();
                do
                {
                    Student stu = new Student();
                    stu.Sno = UnifyHelper.getSafeString(reader["sno"]);
                    stu.Sname = UnifyHelper.getSafeString(reader["sname"]);
                    ret.Add(stu);
                } while (reader.Read());
            }
            reader.Close();
            return ret;
        }

        private static List<Student> DelegateGetStudents(string sqlStr)
        {
            List<Student> ret = null;
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                ret = new List<Student>();
                do
                {
                    Student stu = new Student();
                    stu.Sno = UnifyHelper.getSafeString(reader["sno"]);
                    stu.Sname = UnifyHelper.getSafeString(reader["sname"]);
                    stu.Sphoto = UnifyHelper.getSafeString(reader["sphoto"]);
                    stu.Scollege = UnifyHelper.getSafeString(reader["scollege"]);
                    stu.Sclass = UnifyHelper.getSafeString(reader["sdepartment"]);
                    stu.Ssubject = UnifyHelper.getSafeString(reader["ssubject"]);
                    stu.Ssex = UnifyHelper.getSafeString(reader["ssex"]);
                    ret.Add(stu);
                } while (reader.Read());
            }
            reader.Close();
            return ret;
        }
        public static List<Student> GetWaitWish1Students(Teacher tch)
        {
            string sqlStr = @"SELECT sno,sname,sphoto,scollege,sdepartment,ssubject,ssex FROM Student WHERE sguideTeacher is null AND sno in (SELECT sno FROM Wish WHERE w1=" + SqlHelper.ToSqlQuoteString(tch.Tno) + ");";
            return DelegateGetStudents(sqlStr);
        }
        public static List<Student> GetWaitWish12Students(Teacher tch)
        {
            string sqlStr = @"SELECT sno,sname,sphoto,scollege,sdepartment,ssubject,ssex FROM Student WHERE sguideTeacher is null AND sno in (SELECT sno FROM Wish WHERE w1=" + SqlHelper.ToSqlQuoteString(tch.Tno)
                 + " OR w2=" + SqlHelper.ToSqlQuoteString(tch.Tno) + ");";
            return DelegateGetStudents(sqlStr);
        }
        public static List<Student> GetWaitWish123Students(Teacher tch)
        {
            string sqlStr = @"SELECT sno,sname,sphoto,scollege,sdepartment,ssubject,ssex FROM Student WHERE sguideTeacher is null AND sno in (SELECT sno FROM Wish WHERE w1=" + SqlHelper.ToSqlQuoteString(tch.Tno)
                  + " OR w2=" + SqlHelper.ToSqlQuoteString(tch.Tno) + " OR w3=" + SqlHelper.ToSqlQuoteString(tch.Tno) + ");";
            return DelegateGetStudents(sqlStr);
        }
        public static List<Student> GetWaitLastStudents(Teacher tch)
        {
            string sqlStr = @"SELECT sno,sname,sphoto,scollege,sdepartment,ssubject,ssex FROM Student WHERE sguideTeacher is null AND sno in (SELECT sno FROM Wish WHERE w1=" + SqlHelper.ToSqlQuoteString(tch.Tno)
                 + " OR w2=" + SqlHelper.ToSqlQuoteString(tch.Tno) + " OR w3=" + SqlHelper.ToSqlQuoteString(tch.Tno) + ");";
            return DelegateGetStudents(sqlStr);
        }
        public static int GetTeacherValiableCount(Teacher tch)
        {
            int ret = -1;
            string sqlStr = @"SELECT tmaxStuCount-(SELECT COUNT(*) FROM Student WHERE sguideTeacher=tno) FROM Teacher WHERE tno=" + SqlHelper.ToSqlQuoteString(tch.Tno) + ";";
            Object obj = SqlHelper.ExecObject(sqlStr);
            if (obj != null)
            {
                ret = Convert.ToInt32(obj);
            }
            return ret;
        }
        public static bool WishedStudent(Teacher tch, Student stu)
        {
            bool ret = false;
            string sqlStr = @"UPDATE Student SET sguideTeacher=" + SqlHelper.ToSqlQuoteString(tch.Tno) + " WHERE sno=" + SqlHelper.ToSqlQuoteString(stu.Sno) + ";";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
            {
                ret = true;
            }
            return ret;
        }
        public static List<Student> GetWished1Students(Teacher tch)
        {
            List<Student> ret = null;
            string sqlStr = @"SELECT sno,sname,sphoto FROM Student WHERE sguideTeacher=" + SqlHelper.ToSqlQuoteString(tch.Tno) + " and "+ SqlHelper.ToSqlQuoteString(tch.Tno) +" in (SELECT w1 FROM Wish WHERE Wish.sno=Student.sno) ;";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                ret = new List<Student>();
                do
                {
                    Student stu = new Student();
                    stu.Sno = UnifyHelper.getSafeString(reader["sno"]);
                    stu.Sname = UnifyHelper.getSafeString(reader["sname"]);
                    stu.Sphoto = UnifyHelper.getSafeString(reader["sphoto"]);
                    ret.Add(stu);
                } while (reader.Read());
            }
            reader.Close();
            return ret;
        }
        public static List<Student> GetWished2Students(Teacher tch)
        {
            List<Student> ret = null;
            string sqlStr = @"SELECT sno,sname,sphoto FROM Student WHERE sguideTeacher=" + SqlHelper.ToSqlQuoteString(tch.Tno) + " and " + SqlHelper.ToSqlQuoteString(tch.Tno) + " in (SELECT w2 FROM Wish WHERE Wish.sno=Student.sno)" + ";";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                ret = new List<Student>();
                do
                {
                    Student stu = new Student();
                    stu.Sno = UnifyHelper.getSafeString(reader["sno"]);
                    stu.Sname = UnifyHelper.getSafeString(reader["sname"]);
                    stu.Sphoto = UnifyHelper.getSafeString(reader["sphoto"]);
                    ret.Add(stu);
                } while (reader.Read());
            }
            reader.Close();
            return ret;
        }
        public static List<Student> GetWished3Students(Teacher tch)
        {
            List<Student> ret = null;
            string sqlStr = @"SELECT sno,sname,sphoto FROM Student WHERE sguideTeacher=" + SqlHelper.ToSqlQuoteString(tch.Tno) + " and " + SqlHelper.ToSqlQuoteString(tch.Tno) + "in (SELECT w3 FROM Wish WHERE Wish.sno=Student.sno)" + ";";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                ret = new List<Student>();
                do
                {
                    Student stu = new Student();
                    stu.Sno = UnifyHelper.getSafeString(reader["sno"]);
                    stu.Sname = UnifyHelper.getSafeString(reader["sname"]);
                    stu.Sphoto = UnifyHelper.getSafeString(reader["sphoto"]);
                    ret.Add(stu);
                } while (reader.Read());
            }
            reader.Close();
            return ret;
        }
        public static Teacher GetTeacherInfo(Teacher tch)
        {
            Teacher ret = null;
            string sqlStr = @"SELECT tno,tname,tpwd,tcollege,tdepartment,tsubject,tsex,tbirthday,
                            tphoto,temail,tintroduction,tlastLogin,tgrade,tmaxStuCount
                            FROM Teacher WHERE Tno=" + SqlHelper.ToSqlQuoteString(tch.Tno) + ";";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                //这里类型转换最好使用convert方式，否则数据库如果是空项，将会报错，convert就不会
                ret = new Teacher();
                ret.Tno = UnifyHelper.getSafeString(reader["tno"]);
                ret.Tname = UnifyHelper.getSafeString(reader["tname"]);
                ret.Tpwd = UnifyHelper.getSafeString(reader["tpwd"]);
                ret.Tcollege = UnifyHelper.getSafeString(reader["tcollege"]);
                ret.Tdepartment = UnifyHelper.getSafeString(reader["tdepartment"]);
                ret.Tsubject = UnifyHelper.getSafeString(reader["tsubject"]);
                ret.Tsex = UnifyHelper.getSafeString(reader["tsex"]);
                ret.Tbirthday = UnifyHelper.getSafeString(reader["tbirthday"]);
                ret.Tphoto = UnifyHelper.getSafeString(reader["tphoto"]);
                ret.Temail = UnifyHelper.getSafeString(reader["temail"]);
                ret.Tintroduction = UnifyHelper.getSafeString(reader["tintroduction"]);
                ret.TlastLogin = UnifyHelper.getSafeString(reader["tlastLogin"]);
                ret.Tgrade = UnifyHelper.getSafeString(reader["tgrade"]);
                ret.TmaxStuCount = Convert.ToInt32(UnifyHelper.getNotDbNullObj(reader["tmaxStuCount"]));
            }
            reader.Close();
            return ret;
        }
        public static bool UpdateTeacherInfo(Teacher tch)
        {
            bool ret = false;
            string str1 = "";

            if (tch.Tname != null)
            {
                str1 += "tname=" + SqlHelper.ToSqlQuoteString(tch.Tname);
            }
            if (tch.Tpwd != null)
            {
                str1 += ",tpwd=" + SqlHelper.ToSqlQuoteString(tch.Tpwd);
            }
            if (tch.Tcollege != null)
            {
                str1 += ",tcollege=" + SqlHelper.ToSqlQuoteString(tch.Tcollege);
            }
            if (tch.Tdepartment != null)
            {
                str1 += ",tdepartment=" + SqlHelper.ToSqlQuoteString(tch.Tdepartment);
            }
            if (tch.Tsubject != null)
            {
                str1 += ",tsubject=" + SqlHelper.ToSqlQuoteString(tch.Tsubject);
            }
            if (tch.Tsex != null)
            {
                str1 += ",tsex=" + SqlHelper.ToSqlQuoteString(tch.Tsex);
            }
            if (tch.Tbirthday != null)
            {
                str1 += ",tbirthday=" + SqlHelper.ToSqlQuoteString(tch.Tbirthday);
            }
            if (tch.Tphoto != null)
            {
                str1 += ",tphoto=" + SqlHelper.ToSqlQuoteString(tch.Tphoto);
            }
            if (tch.Temail != null)
            {
                str1 += ",temail=" + SqlHelper.ToSqlQuoteString(tch.Temail);
            }
            if (tch.Tintroduction != null)
            {
                str1 += ",tintroduction=" + SqlHelper.ToSqlQuoteString(tch.Tintroduction);
            }
            if (tch.TlastLogin != null)
            {
                str1 += ",tlastLogin=" + SqlHelper.ToSqlQuoteString(tch.TlastLogin);
            }
            if (tch.Tgrade != null)
            {
                str1 += ",tgrade=" + SqlHelper.ToSqlQuoteString(tch.Tgrade);
            }
            if (tch.TmaxStuCount != null)
            {
                str1 += ",tmaxStuCount=" + SqlHelper.ToSqlQuoteString(tch.TmaxStuCount);
            }

            string sqlStr = @"UPDATE Teacher SET " + str1 + " WHERE Tno=" + SqlHelper.ToSqlQuoteString(tch.Tno) + ";";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public static bool DeleteTeacher(Teacher tch)
        {
            bool ret = false;
            string sqlStr = @"DELETE FROM Teacher WHERE Tno=" + SqlHelper.ToSqlQuoteString(tch.Tno) + ";";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
            {
                ret = true;
            }
            return ret;
        }
    }
}