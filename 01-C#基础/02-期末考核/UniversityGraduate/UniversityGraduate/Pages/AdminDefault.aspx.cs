using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityGraduate.Pages
{
    public partial class AdminDefault : System.Web.UI.Page
    {
        private static Administrator preAdmin = null;
        private static AdministratorManager adminManager = new AdministratorManager();
        private static SystemDate sysDate = null;
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
                this.UserNameLB.Text = preAdmin.Aname;
                this.headNo.Text = preAdmin.Ano;
                ListItem item = new ListItem();
                item.Text = "退出登录";
                item.Value = "Exit";
                this.OperateTypeDD.Items.Add(item);
                item = new ListItem();
                item.Text = "信息修改";
                item.Value = "info";
                this.OperateTypeDD.Items.Add(item);
                InitDropDownList();
                sysDate = adminManager.GetSystemDate();
                if (sysDate == null)
                {
                    sysDate = new SystemDate();
                    sysDate.Date0 = UnifyHelper.GetNowDateTime();
                    adminManager.InsertSystemDate(sysDate);
                }
                UpdateDisplayView();
            }
        }
        private void UpdateDisplayView()
        {
            this.LabelDate0.Text = sysDate.Date0;
            this.LabelDate1.Text = sysDate.Date1;
            this.LabelDate2.Text = sysDate.Date2;
            this.LabelDate3.Text = sysDate.Date3;
            this.LabelDate4.Text = sysDate.Date4;
        }
        private void InitDropDownList()
        {
            this.DropDownListYear.Items.Clear();
            this.DropDownListMonth.Items.Clear();
            this.DropDownListDay.Items.Clear();
            ListItem item = new ListItem();
            for (int i = 0; i < 40; i++)
            {
                item = new ListItem();
                item.Text = (2018 + i) + "年";
                item.Value = (2018 + i) + "";
                this.DropDownListYear.Items.Add(item);
            }
            this.DropDownListYear.SelectedValue = "2020";
            for (int i = 1; i <= 12; i++)
            {
                item = new ListItem();
                item.Text = i + "月";
                item.Value = i + "";
                this.DropDownListMonth.Items.Add(item);
            }
            this.DropDownListMonth.SelectedValue = "1";
            for (int i = 1; i <= 31; i++)
            {
                item = new ListItem();
                item.Text = i + "日";
                item.Value = i + "";
                this.DropDownListDay.Items.Add(item);
            }
            this.DropDownListDay.SelectedValue = "1";
        }
        protected void mApplyBtn_Click(object sender, EventArgs e)
        {
            switch (this.OperateTypeDD.SelectedValue)
            {
                case "Exit":
                    Response.Redirect("..\\Login.aspx");
                    break;
                case "info":
                    Response.Redirect("AdminInfoModify.aspx");
                    break;
                default:
                    break;
            }
        }

        protected void ButtonDeleteAllStudentWish_Click(object sender, EventArgs e)
        {
            if (!hasPermissionMode())
            {
                Response.Write(UnifyHelper.MakeJsAlertString("当前不允许修改，请勾选操作按钮!!"));
                return;
            }
            this.CheckBoxAllowOperate.Checked = false;
            if (adminManager.DeleteAllStudentWishs())
            {
                Response.Write(UnifyHelper.MakeJsAlertString("清除学生志愿成功！！接下来可能要重置学生志愿"));
            }
            else
            {
                Response.Write(UnifyHelper.MakeJsAlertString("清除学生志愿失败，未知原因！！"));
            }
        }

        protected void ButtonAllStudentWishToStart_Click(object sender, EventArgs e)
        {
            if (!hasPermissionMode())
            {
                Response.Write(UnifyHelper.MakeJsAlertString("当前不允许修改，请勾选操作按钮!!"));
                return;
            }
            this.CheckBoxAllowOperate.Checked = false;
            if (adminManager.AllStudentWishToStart())
            {
                Response.Write(UnifyHelper.MakeJsAlertString("重置学生志愿成功！！接下来可能要清空学生指导教师"));
            }
            else
            {
                Response.Write(UnifyHelper.MakeJsAlertString("重置学生志愿失败，未知原因！！"));
            }
        }

        protected void ButtonDeleteAllStudentGuideTeacher_Click(object sender, EventArgs e)
        {
            if (!hasPermissionMode())
            {
                Response.Write(UnifyHelper.MakeJsAlertString("当前不允许修改，请勾选操作按钮!!"));
                return;
            }
            this.CheckBoxAllowOperate.Checked = false;
            if (adminManager.UpdateAllStudentGuideTeacherToNull())
            {
                Response.Write(UnifyHelper.MakeJsAlertString("清空学生指导教师成功！！"));
            }
            else
            {
                Response.Write(UnifyHelper.MakeJsAlertString("清空学生指导教师失败，未知原因！！"));
            }
        }
        private bool CheckArgument()
        {
            if (this.TextBoxResetNo.Text.Trim().Length == 0)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("请输入目标账号！！"));
                this.TextBoxResetNo.Focus();
                return false;
            }
            if (this.TextBoxNewPwd.Text.Trim().Length == 0)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("请输入新密码！！"));
                this.TextBoxNewPwd.Focus();
                return false;
            }
            if (this.TextBoxNewPwdRepeat.Text.Trim().Length == 0)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("请输入重复新密码！！"));
                this.TextBoxNewPwdRepeat.Focus();
                return false;
            }
            if (this.TextBoxNewPwd.Text.Trim() != this.TextBoxNewPwdRepeat.Text.Trim())
            {
                Response.Write(UnifyHelper.MakeJsAlertString("两次输入密码不一致，请重新输入！！"));
                this.TextBoxNewPwdRepeat.Text = "";
                this.TextBoxNewPwdRepeat.Focus();
                return false;
            }
            return true;
        }
        private bool hasPermissionMode()
        {
            return this.CheckBoxAllowOperate.Checked;
        }
        protected void ButtonResetStudentPwd_Click(object sender, EventArgs e)
        {
            if (!hasPermissionMode())
            {
                Response.Write(UnifyHelper.MakeJsAlertString("当前不允许修改，请勾选操作按钮!!"));
                return;
            }
            this.CheckBoxAllowOperate.Checked = false;
            if (CheckArgument())
            {
                bool res = adminManager.ResetStudentPassword(this.TextBoxResetNo.Text.Trim(), this.TextBoxNewPwd.Text.Trim());
                if (res)
                    Response.Write(UnifyHelper.MakeJsAlertString("密码重置成功"));
                else
                    Response.Write(UnifyHelper.MakeJsAlertString("密码重置失败，检查账号是否存在！！"));
            }
        }

        protected void ButtonResetTeacherPwd_Click(object sender, EventArgs e)
        {
            if (!hasPermissionMode())
            {
                Response.Write(UnifyHelper.MakeJsAlertString("当前不允许修改，请勾选操作按钮!!"));
                return;
            }
            this.CheckBoxAllowOperate.Checked = false;
            if (CheckArgument())
            {
                bool res = adminManager.ResetTeacherPassword(this.TextBoxResetNo.Text.Trim(), this.TextBoxNewPwd.Text.Trim());
                if (res)
                    Response.Write(UnifyHelper.MakeJsAlertString("密码重置成功"));
                else
                    Response.Write(UnifyHelper.MakeJsAlertString("密码重置失败，检查账号是否存在！！"));
            }
        }

        protected void ButtonResetAdminPwd_Click(object sender, EventArgs e)
        {
            if (!hasPermissionMode())
            {
                Response.Write(UnifyHelper.MakeJsAlertString("当前不允许修改，请勾选操作按钮!!"));
                return;
            }
            this.CheckBoxAllowOperate.Checked = false;
            if (CheckArgument())
            {
                bool res = adminManager.ResetAdminPassword(this.TextBoxResetNo.Text.Trim(), this.TextBoxNewPwd.Text.Trim());
                if (res)
                    Response.Write(UnifyHelper.MakeJsAlertString("密码重置成功"));
                else
                    Response.Write(UnifyHelper.MakeJsAlertString("密码重置失败，检查账号是否存在！！"));
            }
        }

        protected void ButtonDate0_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(Int32.Parse(this.DropDownListYear.SelectedValue), Int32.Parse(this.DropDownListMonth.SelectedValue), Int32.Parse(this.DropDownListDay.SelectedValue));
            sysDate.Date0 = UnifyHelper.FormatDateTime(dt);
            UpdateDisplayView();
        }

        protected void ButtonDate1_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(Int32.Parse(this.DropDownListYear.SelectedValue), Int32.Parse(this.DropDownListMonth.SelectedValue), Int32.Parse(this.DropDownListDay.SelectedValue));
            sysDate.Date1 = UnifyHelper.FormatDateTime(dt);
            UpdateDisplayView();
        }

        protected void ButtonDate2_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(Int32.Parse(this.DropDownListYear.SelectedValue), Int32.Parse(this.DropDownListMonth.SelectedValue), Int32.Parse(this.DropDownListDay.SelectedValue));
            sysDate.Date2 = UnifyHelper.FormatDateTime(dt);
            UpdateDisplayView();
        }

        protected void ButtonDate3_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(Int32.Parse(this.DropDownListYear.SelectedValue), Int32.Parse(this.DropDownListMonth.SelectedValue), Int32.Parse(this.DropDownListDay.SelectedValue));
            sysDate.Date3 = UnifyHelper.FormatDateTime(dt);
            UpdateDisplayView();
        }

        protected void ButtonDate4_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(Int32.Parse(this.DropDownListYear.SelectedValue), Int32.Parse(this.DropDownListMonth.SelectedValue), Int32.Parse(this.DropDownListDay.SelectedValue));
            sysDate.Date4 = UnifyHelper.FormatDateTime(dt);
            UpdateDisplayView();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (!hasPermissionMode())
            {
                Response.Write(UnifyHelper.MakeJsAlertString("当前不允许修改，请勾选操作按钮!!"));
                return;
            }
            this.CheckBoxAllowOperate.Checked = false;
            if (adminManager.UpdateSystemDate(sysDate))
                Response.Write(UnifyHelper.MakeJsAlertString("系统时间已经更新!!"));
            else
                Response.Write(UnifyHelper.MakeJsAlertString("系统时间更新失败，未知原因!!"));
        }
    }
}