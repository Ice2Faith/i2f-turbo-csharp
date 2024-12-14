using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGraduate
{
    public class Student
    {
        private string sno;
        private string spwd;
        private string scollege;
        private string sdepartment;
        private string ssubject;
        private string sclass;
        private string sname;
        private string ssex;
        private string sbirthday;
        private string srace;
        private int sinYear;
        private int sgraduateYear;
        private string sguideTeacher;
        private string sphoto;
        private string semail;
        private string sintroduction;
        private string slastLogin;
        /// <summary>
        /// 学生账号
        /// </summary>
        public string Sno
        {
            get { return sno; }
            set { sno = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 学生密码
        /// </summary>
        public string Spwd
        {
            get { return spwd; }
            set { spwd = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 学生学院
        /// </summary>
        public string Scollege
        {
            get { return scollege; }
            set { scollege = UnifyHelper.getSafeString(value); }
        }
       /// <summary>
       /// 学生系
       /// </summary>
        public string Sdepartment
        {
            get { return sdepartment; }
            set { sdepartment = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 学生专业
        /// </summary>
        public string Ssubject
        {
            get { return ssubject; }
            set { ssubject = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 学生班级
        /// </summary>
        public string Sclass
        {
            get { return sclass; }
            set { sclass = UnifyHelper.getSafeString(value); }
        }
       /// <summary>
       /// 学生姓名
       /// </summary>
        public string Sname
        {
            get { return sname; }
            set { sname = UnifyHelper.getSafeString(value); }
        }
       /// <summary>
       /// 学生性别
       /// </summary>
        public string Ssex
        {
            get { return ssex; }
            set { ssex = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 学生生日
        /// </summary>
        public string Sbirthday
        {
            get { return sbirthday; }
            set { sbirthday = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 学生民族
        /// </summary>
        public string Srace
        {
            get { return srace; }
            set { srace = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 学生入学年份
        /// </summary>
        public int SinYear
        {
            get { return sinYear; }
            set { sinYear = value; }
        }
       /// <summary>
       /// 学生毕业年份
       /// </summary>
        public int SgraduateYear
        {
            get { return sgraduateYear; }
            set { sgraduateYear = value; }
        }
        /// <summary>
        /// 学生的导师
        /// </summary>
        public string SguideTeacher
        {
            get { return sguideTeacher; }
            set { sguideTeacher = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 学生头像
        /// </summary>
        public string Sphoto
        {
            get { return sphoto; }
            set { sphoto = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 学生邮箱
        /// </summary>
        public string Semail
        {
            get { return semail; }
            set { semail = UnifyHelper.getSafeString(value); }
        }
       /// <summary>
       /// 学生介绍
       /// </summary>
        public string Sintroduction
        {
            get { return sintroduction; }
            set { sintroduction = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 学生最后登录时间
        /// </summary>
        public string SlastLogin
        {
            get { return slastLogin; }
            set { slastLogin = UnifyHelper.getSafeString(value); }
        }

    }
}