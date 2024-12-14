using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGraduate
{
    public class Wish
    {
        private string sno;
        private string w1;
        private string w2;
        private string w3;
        private string wstate;
        /// <summary>
        /// 学生账号
        /// </summary>
        public string Sno
        {
            get { return sno; }
            set { sno = value; }
        }
        /// <summary>
        /// 第一志愿
        /// </summary>
        public string W1
        {
            get { return w1; }
            set { w1 = value; }
        }
       /// <summary>
       /// 第二志愿
       /// </summary>
        public string W2
        {
            get { return w2; }
            set { w2 = value; }
        }
        /// <summary>
        /// 第三志愿
        /// </summary>
        public string W3
        {
            get { return w3; }
            set { w3 = value; }
        }
        /// <summary>
        /// 志愿选取状态
        /// </summary>
        public string Wstate
        {
            get { return wstate; }
            set { wstate = value; }
        }

    }
}