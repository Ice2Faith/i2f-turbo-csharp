using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class StudentReader
{
    public DataTable GetStudents()
    {
        return SQLHelper.ExecTable(@"select * from Student");
    }
    public Student GetStudentByName(string name)
    {
        SqlDataReader reader=SQLHelper.ExecReader(@"select * from Student where sname='"+name+@"'");
        Student stu = null;
        if (reader.Read())
        {
            stu=new Student();
            stu.Name=(string)reader["sname"];
        }
        return stu;
    }
    public Student GetStudentById(string id)
    {
        SqlDataReader reader = SQLHelper.ExecReader(@"select * from Student where sid='" + id + @"'");
        Student stu = null;
        if (reader.Read())
        {
            stu = new Student();
            stu.Name = (string)reader["id"];
        }
        return stu;
    }
}
public class TeacherReader
{

}
public class AdministratorReader
{

}