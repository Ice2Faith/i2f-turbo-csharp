using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityGraduate
{
    public partial class Register : System.Web.UI.Page
    {
        StudentManager stuManager = new StudentManager();
        TeacherManager tchManager = new TeacherManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBackLogin_Click(object sender, EventArgs e)
        {

            Response.Redirect("Login.aspx");
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            string pName = this.TextBoxName.Text.Trim();
            string pPwd = this.TextBoxPwd.Text.Trim();
            string pRePwd = this.TextBoxPwdRepeat.Text.Trim();
            if (pName.Length == 0)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("请输入姓名！！"));
                this.TextBoxName.Focus();
            }
            else if (pPwd.Length == 0)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("请输入密码！！"));
                this.TextBoxPwd.Focus();
            }
            else if (pRePwd.Length == 0)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("请输入重复密码！！"));
                this.TextBoxPwdRepeat.Focus();
            }
            else if (pRePwd != pPwd)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("两次输入密码不一致！！"));
                this.TextBoxPwdRepeat.Focus();
            }
            else
            {
                //自动登录
                if (this.RadioButtonStudent.Checked)
                {
                    Student stu = new Student();
                    stu.Sname = pName;
                    stu.Spwd = pPwd;

                    stu = stuManager.Register(stu);
                    if (stu == null)
                    {
                        Response.Write(UnifyHelper.MakeJsAlertString("注册失败！！未知原因！！"));
                    }
                    else
                    {
                        Response.Write(UnifyHelper.MakeJsAlertString("正在为您自动登录！！"));
                        Session["Sno"] = stu.Sno;
                        Session["Sdepartment"] = stu.Sdepartment;
                        Response.Redirect("Pages\\StuDefault.aspx");
                    }
                }
                else
                {
                    Teacher tch = new Teacher();
                    tch.Tname = pName;
                    tch.Tpwd = pPwd;

                    tch = tchManager.Register(tch);
                    if (tch == null)
                    {
                        Response.Write(UnifyHelper.MakeJsAlertString("注册失败！！未知原因！！"));
                    }
                    else
                    {
                        Response.Write(UnifyHelper.MakeJsAlertString("正在为您自动登录！！"));
                        Session["Tno"] = tch.Tno;
                        Response.Redirect("Pages\\TchDefault.aspx");
                    }
                }
            }
        }
    }
}