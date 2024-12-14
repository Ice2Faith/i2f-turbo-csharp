using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGraduate
{
    public class StudentManager
    {
        private StudentService stuService = new StudentService();
        public Student Login(Student stu)
        {
            return stuService.Login(stu);
        }
        public Student Register(Student stu)
        {
            return stuService.Register(stu);
        }
        public Student GetStudentInfo(Student stu)
        {
            return stuService.GetStudentInfo(stu);
        }
        public List<Teacher> GetTeachers(Student stu)
        {
            return stuService.GetTeachers(stu);
        }
        public Wish GetWish(Student stu)
        {
            return stuService.GetWish(stu);
        }
        public  bool UpdateWish(Wish wsh)
        {
            return stuService.UpdateWish(wsh);
        }
        public bool InsertWish(Wish wsh)
        {
            return stuService.InsertWish(wsh);
        }
         public bool UpdateStudentInfo(Student stu)
        {
            return stuService.UpdateStudentInfo(stu);
        }
        public  bool DeleteStudent(Student stu)
        {
            return stuService.DeleteStudent(stu);
        }
    }
}