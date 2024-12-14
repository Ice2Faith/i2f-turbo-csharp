using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityGraduate.Pages
{
    public partial class AdminInfoModify : System.Web.UI.Page
    {
        private static Administrator preAdmin = null;
        private static AdministratorManager adminManager = new AdministratorManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Ano"] == null)
                {
                    Response.Write(UnifyHelper.MakeJsAlertString("请先登录，登录信息无效！！"));
                    Response.Redirect("..\\Login.aspx");
                }
                preAdmin = new Administrator();
                preAdmin.Ano = Session["Ano"].ToString().Trim();
                preAdmin = adminManager.GetAdminInfo(preAdmin);
                UpdateDiaplayView();
            }
        }
        private void UpdateDiaplayView()
        {
            this.TextBoxCollege.Text = preAdmin.Acollege;
            this.TextBoxDepartment.Text = preAdmin.Adepartment;
            this.TextBoxName.Text = preAdmin.Aname;
        }
        private void VaryInfoTopreAdmin()
        {
            preAdmin.Aname = this.TextBoxName.Text.Trim();
            preAdmin.Acollege = this.TextBoxCollege.Text.Trim();
            preAdmin.Adepartment = this.TextBoxDepartment.Text.Trim();
            if (this.TextBoxPwd.Text.Trim().Length != 0)
                preAdmin.Apwd = this.TextBoxPwd.Text.Trim();
        }
        private string CheckDataLegal()
        {
            if (this.TextBoxName.Text.Trim().Length == 0)
                return "请输入姓名或不要全输入空白符号！！";
            if (this.TextBoxCollege.Text.Trim().Length == 0)
                return "请输入院校信息或不要全输入空白符号！！";
            if (this.TextBoxDepartment.Text.Trim().Length == 0)
                return "请输入所在系或不要全输入空白符号！！";
            if (this.TextBoxPwd.Text.Trim().Length != 0)
                if (this.TextBoxPwd.Text.Trim() != this.TextBoxPwdRepeat.Text.Trim())
                    return "两次输入的密码不一致，请检查！";
            return null;
        }
        protected void ButtonSubmitInfo_Click(object sender, EventArgs e)
        {
            string badinfo = CheckDataLegal();
            if (badinfo == null)
            {
                VaryInfoTopreAdmin();
                if (adminManager.UpdateAdminInfo(preAdmin))
                {
                    Response.Write(UnifyHelper.MakeJsAlertString("成功！信息修改成功！！"));
                }
                else
                {
                    Response.Write(UnifyHelper.MakeJsAlertString("错误！信息修改发生错误！！"));
                }
            }
            else
            {
                Response.Write(UnifyHelper.MakeJsAlertString("错误！" + badinfo));
            }
        }

        protected void ButtonBackDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDefault.aspx");
        }
    }
}