using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace UniversityGraduate
{
    public class StudentService
    {
        public Student Login(Student stu)
        {
            string sqlStr = @"SELECT sno,sname,spwd,sdepartment FROM Student WHERE sno=" + SqlHelper.ToSqlQuoteString(stu.Sno) + " AND spwd=" + SqlHelper.ToSqlQuoteString(stu.Spwd) + ";";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                stu.Sname = Convert.ToString(reader["sname"]);
                stu.Spwd = Convert.ToString(reader["spwd"]);
                stu.Sdepartment = Convert.ToString(reader["sdepartment"]);
                stu.SlastLogin = UnifyHelper.GetNowDateTime();
            }
            else
            {
                stu = null;
            }
            reader.Close();
            return stu;
        }
        public Student Register(Student stu)
        {
            string sqlQuery = @"SELECT TOP 1 sno FROM Student ORDER BY sno DESC;";
            string maxno = SqlHelper.ExecObject(sqlQuery).ToString().Trim();
            long newno = Convert.ToInt64(maxno) + 1;
            stu.Sno = newno.ToString().Trim();
            string sqlStr = @"INSERT INTO Student(sno,sname,spwd) VALUES(" + SqlHelper.ToSqlQuoteString(stu.Sno) + ","
                + SqlHelper.ToSqlQuoteString(stu.Sname) + ","
                + SqlHelper.ToSqlQuoteString(stu.Spwd) + ");";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                return stu;
            return null;
        }
        public List<Teacher> GetTeachers(Student stu)
        {
            List<Teacher> ret = null;
            string sqlStr = @"SELECT tno,tname,tphoto,tdepartment,tcollege,tgrade,tsex,tsubject FROM Teacher WHERE tdepartment=" + SqlHelper.ToSqlQuoteString(stu.Sdepartment)
                + " AND tmaxStuCount>(SELECT COUNT(*) FROM Student WHERE sguideTeacher=tno)";

            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                ret = new List<Teacher>();
                do
                {
                    Teacher tch = new Teacher();
                    tch.Tno = UnifyHelper.getSafeString(reader["tno"]);
                    tch.Tname = UnifyHelper.getSafeString(reader["tname"]);
                    tch.Tphoto = UnifyHelper.getSafeString(reader["tphoto"]);
                    tch.Tdepartment = UnifyHelper.getSafeString(reader["tdepartment"]);
                    tch.Tcollege = UnifyHelper.getSafeString(reader["tcollege"]);
                    tch.Tgrade = UnifyHelper.getSafeString(reader["tgrade"]);
                    tch.Tsex = UnifyHelper.getSafeString(reader["tsex"]);
                    tch.Tsubject = UnifyHelper.getSafeString(reader["tsubject"]);
                    ret.Add(tch);
                } while (reader.Read());
            }
            reader.Close();
            return ret;
        }
        public Wish GetWish(Student stu)
        {
            Wish ret = null;
            string sqlStr = @"SELECT w1,w2,w3,wstate FROM Wish WHERE sno=" + SqlHelper.ToSqlQuoteString(stu.Sno) + ";";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                ret = new Wish();
                ret.Sno = stu.Sno;
                ret.W1 = UnifyHelper.getSafeString(reader["w1"]);
                ret.W2 = UnifyHelper.getSafeString(reader["w2"]);
                ret.W3 = UnifyHelper.getSafeString(reader["w3"]);
                ret.Wstate = UnifyHelper.getSafeString(reader["wstate"]);
            }
            reader.Close();
            return ret;
        }

        public bool UpdateWish(Wish wsh)
        {
            string str1 = "";
            if (wsh.W2 != null)
                str1 += ",w2=" + SqlHelper.ToSqlQuoteString(wsh.W2);
            if (wsh.W3 != null)
                str1 += ",w3=" + SqlHelper.ToSqlQuoteString(wsh.W3);
            if (wsh.Wstate != null)
                str1 += ",wstate=" + SqlHelper.ToSqlQuoteString(wsh.Wstate);
            string sqlStr = @"UPDATE Wish SET w1=" + SqlHelper.ToSqlQuoteString(wsh.W1) + str1 + " WHERE sno=" + SqlHelper.ToSqlQuoteString(wsh.Sno) + ";";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                return true;
            return false;
        }
        public bool InsertWish(Wish wsh)
        {
            string str1 = "";
            string str2 = "";
            if (wsh.W1 != null)
            {
                str1 += ",w1";
                str2 += "," + SqlHelper.ToSqlQuoteString(wsh.W1);
            }
            if (wsh.W2 != null)
            {
                str1 += ",w2";
                str2 += "," + SqlHelper.ToSqlQuoteString(wsh.W2);
            }
            if (wsh.W3 != null)
            {
                str1 += ",w3";
                str2 += "," + SqlHelper.ToSqlQuoteString(wsh.W3);
            }
            if (wsh.Wstate != null)
            {
                str1 += ",wstate";
                str2 += "," + SqlHelper.ToSqlQuoteString(wsh.Wstate);
            }

            string sqlStr = @"INSERT INTO Wish(sno" + str1 + ") VALUES("
                + SqlHelper.ToSqlQuoteString(wsh.Sno) + str2 + ");";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                return true;
            return false;
        }
        public Student GetStudentInfo(Student stu)
        {
            Student ret = null;
            string sqlStr = @"SELECT sno,sname,spwd,scollege,sdepartment,ssubject,sclass,ssex,sbirthday,
                            srace,sinYear,sgraduateYear,sguideTeacher,sphoto,semail,sintroduction,slastLogin
                            FROM Student WHERE sno=" + SqlHelper.ToSqlQuoteString(stu.Sno) + ";";
            SqlDataReader reader = SqlHelper.ExecReader(sqlStr);
            if (reader.Read())
            {
                //这里类型转换最好使用convert方式，否则数据库如果是空项，将会报错，convert就不会
                ret = new Student();
                ret.Sno = UnifyHelper.getSafeString(reader["sno"]);
                ret.Sname = UnifyHelper.getSafeString(reader["sname"]);
                ret.Spwd = UnifyHelper.getSafeString(reader["spwd"]);
                ret.Scollege = UnifyHelper.getSafeString(reader["scollege"]);
                ret.Sdepartment = UnifyHelper.getSafeString(reader["sdepartment"]);
                ret.Ssubject = UnifyHelper.getSafeString(reader["ssubject"]);
                ret.Sclass = UnifyHelper.getSafeString(reader["sclass"]);
                ret.Ssex = UnifyHelper.getSafeString(reader["ssex"]);
                ret.Sbirthday = UnifyHelper.getSafeString(reader["sbirthday"]);
                ret.Srace = UnifyHelper.getSafeString(reader["srace"]);
                ret.SinYear = Convert.ToInt32(UnifyHelper.getNotDbNullObj(reader["sinYear"]));
                ret.SgraduateYear = Convert.ToInt32(UnifyHelper.getNotDbNullObj(reader["sgraduateYear"]));
                ret.SguideTeacher = UnifyHelper.getSafeString(reader["sguideTeacher"]);
                ret.Sphoto = UnifyHelper.getSafeString(reader["sphoto"]);
                ret.Semail = UnifyHelper.getSafeString(reader["semail"]);
                ret.Sintroduction = UnifyHelper.getSafeString(reader["sintroduction"]);
                ret.SlastLogin = Convert.ToString(reader["slastLogin"]);
            }
            reader.Close();
            return ret;
        }
        public bool UpdateStudentInfo(Student stu)
        {
            bool ret = false;
            string str1 = "";

            if (stu.Sname != null)
            {
                str1 += "sname=" + SqlHelper.ToSqlQuoteString(stu.Sname);
            }
            if (stu.Spwd != null)
            {
                str1 += ",spwd=" + SqlHelper.ToSqlQuoteString(stu.Spwd);
            }
            if (stu.Scollege != null)
            {
                str1 += ",scollege=" + SqlHelper.ToSqlQuoteString(stu.Scollege);
            }
            if (stu.Sdepartment != null)
            {
                str1 += ",sdepartment=" + SqlHelper.ToSqlQuoteString(stu.Sdepartment);
            }
            if (stu.Ssubject != null)
            {
                str1 += ",ssubject=" + SqlHelper.ToSqlQuoteString(stu.Ssubject);
            }
            if (stu.Sclass != null)
            {
                str1 += ",sclass=" + SqlHelper.ToSqlQuoteString(stu.Sclass);
            }
            if (stu.Ssex != null)
            {
                str1 += ",ssex=" + SqlHelper.ToSqlQuoteString(stu.Ssex);
            }
            if (stu.Sbirthday != null)
            {
                str1 += ",sbirthday=" + SqlHelper.ToSqlQuoteString(stu.Sbirthday);
            }
            if (stu.Srace != null)
            {
                str1 += ",srace=" + SqlHelper.ToSqlQuoteString(stu.Srace);
            }
            if (stu.SinYear != null)
            {
                str1 += ",sinYear=" + SqlHelper.ToSqlQuoteString(stu.SinYear);
            }
            if (stu.SgraduateYear != null)
            {
                str1 += ",sgraduateYear=" + SqlHelper.ToSqlQuoteString(stu.SgraduateYear);
            }
            if (stu.SguideTeacher != null)
            {
                str1 += ",sguideTeacher=" + SqlHelper.ToSqlQuoteString(stu.SguideTeacher);
            }
            if (stu.Sphoto != null)
            {
                str1 += ",sphoto=" + SqlHelper.ToSqlQuoteString(stu.Sphoto);
            }
            if (stu.Semail != null)
            {
                str1 += ",semail=" + SqlHelper.ToSqlQuoteString(stu.Semail);
            }
            if (stu.Sintroduction != null)
            {
                str1 += ",sintroduction=" + SqlHelper.ToSqlQuoteString(stu.Sintroduction);
            }
            if (stu.SlastLogin != null)
            {
                str1 += ",slastLogin=" + SqlHelper.ToSqlQuoteString(stu.SlastLogin);
            }

            string sqlStr = @"UPDATE Student SET " + str1 + " WHERE Sno=" + SqlHelper.ToSqlQuoteString(stu.Sno) + ";";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
                ret = true;
            return ret;
        }
        public bool DeleteStudent(Student stu)
        {
            bool ret = false;
            string sqlStr = @"DELETE FROM Student WHERE sno=" + SqlHelper.ToSqlQuoteString(stu.Sno) + ";";
            int res = SqlHelper.ExecNoQuery(sqlStr);
            if (res > 0)
            {
                ret = true;
            }
            return ret;
        }
    }
}