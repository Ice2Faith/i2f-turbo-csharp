using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGraduate
{
    public class Administrator
    {
        private string ano;
        private string atype;
        private string apwd;
        private string acollege;
        private string adepartment;
        private string aname;
        private string alastLogin;
        /// <summary>
        /// 管理员账号
        /// </summary>
        public string Ano
        {
            get { return ano; }
            set { ano = value; }
        }
        /// <summary>
        /// 管理员类型
        /// </summary>
        public string Atype
        {
            get { return atype; }
            set { atype = value; }
        }
        /// <summary>
        /// 管理员密码
        /// </summary>
        public string Apwd
        {
            get { return apwd; }
            set { apwd = value; }
        }
        /// <summary>
        /// 管理员学院
        /// </summary>
        public string Acollege
        {
            get { return acollege; }
            set { acollege = value; }
        }
        /// <summary>
        /// 管理员系
        /// </summary>
        public string Adepartment
        {
            get { return adepartment; }
            set { adepartment = value; }
        }
        /// <summary>
        /// 管理员姓名
        /// </summary>
        public string Aname
        {
            get { return aname; }
            set { aname = value; }
        }
        /// <summary>
        /// 管理员最后登录时间
        /// </summary>
        public string AlastLogin
        {
            get { return alastLogin; }
            set { alastLogin = value; }
        }
    }
}