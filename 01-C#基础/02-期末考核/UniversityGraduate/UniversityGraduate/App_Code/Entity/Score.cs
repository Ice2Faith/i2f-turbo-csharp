using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGraduate
{
    public class Score
    {
        private string sno;
        private string cno;
        private string grade;
        /// <summary>
        /// 学生账号
        /// </summary>
        public string Sno
        {
            get { return sno; }
            set { sno = value; }
        }
        /// <summary>
        /// 课程编号
        /// </summary>
        public string Cno
        {
            get { return cno; }
            set { cno = value; }
        }
        /// <summary>
        /// 学生成绩
        /// </summary>
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }
    }
}