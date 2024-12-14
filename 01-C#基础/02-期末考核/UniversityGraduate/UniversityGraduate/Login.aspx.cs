using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityGraduate
{
    public partial class Login : System.Web.UI.Page
    {
        private StudentManager stuManager = new StudentManager();
        private TeacherManager tchManager = new TeacherManager();
        private AdministratorManager adminManager = new AdministratorManager();
        private static InnerSysDate preInSysDate = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            preInSysDate = UnifyHelper.ConvertToInnerSysDate(AdministratorService.GetSystemDate());
            if (DateTime.Now < preInSysDate.date0)
            {
                this.LabelNotice.Text = "系统空闲时间，非填报志愿期间！！志愿填报开始时间为："
                    + UnifyHelper.FormatDateTime(preInSysDate.date0) + " 最后批次录取时间为：" + UnifyHelper.FormatDateTime(preInSysDate.date4)
                    + " 导师补录时间在最后批次之后三天内！！";
            }
            else if (DateTime.Now < preInSysDate.date1)
            {
                this.LabelNotice.Text = "请各位毕业生填报志愿！！填报时间：" + UnifyHelper.FormatDateTime(preInSysDate.date0) + " - "
                   + UnifyHelper.FormatDateTime(preInSysDate.date1);
            }
            else if (DateTime.Now < preInSysDate.date2)
            {
                this.LabelNotice.Text = "现在是一批志愿选取时间！！录取时间：" + UnifyHelper.FormatDateTime(preInSysDate.date1) + " - "
                   + UnifyHelper.FormatDateTime(preInSysDate.date2);
            }
            else if (DateTime.Now < preInSysDate.date3)
            {
                this.LabelNotice.Text = "现在是二批志愿选取时间！！录取时间：" + UnifyHelper.FormatDateTime(preInSysDate.date2) + " - "
                    + UnifyHelper.FormatDateTime(preInSysDate.date3);
            }
            else if (DateTime.Now < preInSysDate.date4)
            {
                this.LabelNotice.Text = "现在是三批志愿选取时间！！录取时间：" + UnifyHelper.FormatDateTime(preInSysDate.date3) + " - "
                   + UnifyHelper.FormatDateTime(preInSysDate.date4);
            }
            else if (DateTime.Now < preInSysDate.date4.AddDays(3))
            {
                this.LabelNotice.Text = "现在是补录志愿选取时间！！录取时间：" + UnifyHelper.FormatDateTime(preInSysDate.date4) + " - "
                   + UnifyHelper.FormatDateTime(preInSysDate.date4.AddDays(3));
            }
            else
            {
                this.LabelNotice.Text = "系统空闲时间，非填报志愿期间！！志愿已经录取结束！！截止时间："
                    + UnifyHelper.FormatDateTime(preInSysDate.date4.AddDays(3));
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string pNo = this.TextBoxNo.Text.Trim();
            string pPwd = this.TextBoxPwd.Text.Trim();
            if (pNo.Length == 0)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("账号不能为空！！"));
                this.TextBoxNo.Focus();
            }
            else if (pPwd.Length == 0)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("密码不能为空！！"));
                this.TextBoxPwd.Focus();
            }
            else
            {
                if (this.RadioButtonStudent.Checked)
                {
                    Student stu = new Student();
                    stu.Sno = pNo;
                    stu.Spwd = pPwd;
                    stu = stuManager.Login(stu);
                    if (stu == null)
                    {
                        Response.Write(UnifyHelper.MakeJsAlertString("登录失败！！账户不存在或密码错误！！"));
                        this.TextBoxNo.Focus();
                        this.TextBoxPwd.Text = "";
                    }
                    else
                    {
                        Session["Sno"] = stu.Sno;
                        Session["Sdepartment"] = stu.Sdepartment;
                        stuManager.UpdateStudentInfo(stu);
                        Response.Redirect("Pages\\StuDefault.aspx");
                    }



                }
                else
                {
                    Teacher tch = new Teacher();
                    tch.Tno = pNo;
                    tch.Tpwd = pPwd;
                    tch = tchManager.Login(tch);
                    if (tch == null)
                    {
                        Response.Write(UnifyHelper.MakeJsAlertString("登录失败！！账户不存在或密码错误！！"));
                        this.TextBoxNo.Focus();
                        this.TextBoxPwd.Text = "";
                    }
                    else
                    {
                        Session["Tno"] = tch.Tno;
                        tchManager.UpdateTeacherInfo(tch);
                        Response.Redirect("Pages\\TchDefault.aspx");
                    }
                }
            }

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void ButtonAdminEntry_Click(object sender, EventArgs e)
        {
            string pNo = this.TextBoxNo.Text.Trim();
            string pPwd = this.TextBoxPwd.Text.Trim();
            if (pNo.Length == 0)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("账号不能为空！！"));
                this.TextBoxNo.Focus();
            }
            else if (pPwd.Length == 0)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("密码不能为空！！"));
                this.TextBoxPwd.Focus();
            }
            else
            {
                Administrator admin = new Administrator();
                admin.Ano = pNo;
                admin.Apwd = pPwd;
                admin = adminManager.Login(admin);
                if (admin == null)
                {
                    Response.Write(UnifyHelper.MakeJsAlertString("登录失败！！账户不存在或密码错误！！"));
                    this.TextBoxNo.Focus();
                    this.TextBoxPwd.Text = "";
                }
                else
                {
                    Session["Ano"] = admin.Ano;
                    adminManager.UpdateAdminInfo(admin);
                    Response.Redirect("Pages\\AdminDefault.aspx");
                }
            }
        }

    }
}