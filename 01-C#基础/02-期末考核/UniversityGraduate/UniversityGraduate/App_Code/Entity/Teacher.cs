using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGraduate
{
    public class Teacher
    {
        private string tno;
        private string tpwd;
        private string tcollege;
        private string tdepartment;
        private string tsubject;
        private string tgrade;
        private string tname;
        private string tsex;
        private string tphoto;
        private string tbirthday;
        private string temail;
        private int tmaxStuCount;
        private string tintroduction;
        private string tlastLogin;
        /// <summary>
        /// 教师账号
        /// </summary>
        public string Tno
        {
            get { return tno; }
            set { tno = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 教师密码
        /// </summary>
        public string Tpwd
        {
            get { return tpwd; }
            set { tpwd = UnifyHelper.getSafeString(value); }
        }
       /// <summary>
       /// 教师学院
       /// </summary>
        public string Tcollege
        {
            get { return tcollege; }
            set { tcollege = UnifyHelper.getSafeString(value); }
        }
       /// <summary>
       /// 教师系
       /// </summary>
        public string Tdepartment
        {
            get { return tdepartment; }
            set { tdepartment = UnifyHelper.getSafeString(value); }
        }
       /// <summary>
       /// 教师专业
       /// </summary>
        public string Tsubject
        {
            get { return tsubject; }
            set { tsubject = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 教师等级
        /// </summary>
        public string Tgrade
        {
            get { return tgrade; }
            set { tgrade = UnifyHelper.getSafeString(value); }
        }
       /// <summary>
       /// 教师姓名
       /// </summary>
        public string Tname
        {
            get { return tname; }
            set { tname = UnifyHelper.getSafeString(value); }
        }
       /// <summary>
       /// 教师性别
       /// </summary>
        public string Tsex
        {
            get { return tsex; }
            set { tsex = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 教师头像路径
        /// </summary>
        public string Tphoto
        {
            get { return tphoto; }
            set { tphoto = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 教师生日
        /// </summary>
        public string Tbirthday
        {
            get { return tbirthday; }
            set { tbirthday = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 教师邮箱
        /// </summary>
        public string Temail
        {
            get { return temail; }
            set { temail = UnifyHelper.getSafeString(value); }
        }
        /// <summary>
        /// 教师带的最大学生数
        /// </summary>
        public int TmaxStuCount
        {
            get { return tmaxStuCount; }
            set { tmaxStuCount = value; }
        }
       /// <summary>
       /// 教师介绍
       /// </summary>
        public string Tintroduction
        {
            get { return tintroduction; }
            set { tintroduction = UnifyHelper.getSafeString(value); }
        }
       /// <summary>
       /// 教师最后登录时间
       /// </summary>
        public string TlastLogin
        {
            get { return tlastLogin; }
            set { tlastLogin = UnifyHelper.getSafeString(value); }
        }
    }
}