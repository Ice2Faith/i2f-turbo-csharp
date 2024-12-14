using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGraduate
{
    public class Course
    {
        private string cno;
        private string cname;
        private int cscore;
        private int cstudyTime;
        /// <summary>
        /// 课程编号
        /// </summary>
        public string Cno
        {
            get { return cno; }
            set { cno = value; }
        }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string Cname
        {
            get { return cname; }
            set { cname = value; }
        }
        /// <summary>
        /// 课程学分
        /// </summary>
        public int Cscore
        {
            get { return cscore; }
            set { cscore = value; }
        }
        /// <summary>
        /// 课程学习时间
        /// </summary>
        public int CstudyTime
        {
            get { return cstudyTime; }
            set { cstudyTime = value; }
        }
    }
}