using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGraduate
{
    public class TeacherManager
    {
        public Teacher Login(Teacher tch)
        {
            return TeacherService.Login(tch);
        }
        public Teacher Register(Teacher tch)
        {
            return TeacherService.Register(tch);
        }
        public Teacher GetTeacherInfo(Teacher tch)
        {
            return TeacherService.GetTeacherInfo(tch);
        }
        public List<Student> GetWishedStudent(Teacher tch)
        {
            return TeacherService.GetWishedStudent(tch);
        }
        public List<Student> GetWaitWish1Students(Teacher tch)
        {
            return TeacherService.GetWaitWish1Students(tch);
        }

        public List<Student> GetWaitWish12Students(Teacher tch)
        {
            return TeacherService.GetWaitWish12Students(tch);
        }

        public List<Student> GetWaitWish123Students(Teacher tch)
        {
            return TeacherService.GetWaitWish123Students(tch);
        }
        public List<Student> GetWaitLastStudents(Teacher tch)
        {
            return TeacherService.GetWaitLastStudents(tch);
        }
        public List<Student> GetWished1Students(Teacher tch)
        {
            return TeacherService.GetWished1Students(tch);
        }
        public List<Student> GetWished2Students(Teacher tch)
        {
            return TeacherService.GetWished2Students(tch);
        }
        public List<Student> GetWished3Students(Teacher tch)
        {
            return TeacherService.GetWished3Students(tch);
        }
        public int GetTeacherValiableCount(Teacher tch)
        {
            return TeacherService.GetTeacherValiableCount(tch);
        }
         public bool UpdateTeacherInfo(Teacher tch)
        {
            return TeacherService.UpdateTeacherInfo(tch);
        }
        public bool DeleteTeacher(Teacher tch)
         {
             return TeacherService.DeleteTeacher(tch);
         }
        public bool WishedStudent(Teacher tch,Student stu)
        {
            return TeacherService.WishedStudent(tch, stu);
        }
    }
}