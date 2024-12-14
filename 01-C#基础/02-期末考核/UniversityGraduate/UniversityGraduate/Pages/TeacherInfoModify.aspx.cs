using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace UniversityGraduate.Pages
{
    public partial class TeacherInfoModify : System.Web.UI.Page
    {
        private static Teacher preTch = null;
        private static TeacherManager tchManager = new TeacherManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Tno"] == null)
                {
                    Response.Write(UnifyHelper.MakeJsAlertString("请先登录，登录信息无效！！"));
                    Response.Redirect("..\\Login.aspx");
                }
                preTch = new Teacher();
                preTch.Tno = Session["Tno"].ToString().Trim();
                preTch = tchManager.GetTeacherInfo(preTch);
                InitDropDownList();
                UpdateDiaplayView();
            }
        }
        private void InitDropDownList()
        {
            this.DropDownListSex.Items.Clear();
            this.DropDownListYear.Items.Clear();
            this.DropDownListMonth.Items.Clear();
            this.DropDownListDay.Items.Clear();
            ListItem item = new ListItem();
            item.Text = "男";
            item.Value = "男";
            this.DropDownListSex.Items.Add(item);
            item = new ListItem();
            item.Text = "女";
            item.Value = "女";
            this.DropDownListSex.Items.Add(item);
            this.DropDownListSex.SelectedValue = "男";
            for (int i = 0; i < 40; i++)
            {
                item = new ListItem();
                item.Text = (1985 + i) + "年";
                item.Value = (1985 + i) + "";
                this.DropDownListYear.Items.Add(item);
            }
            this.DropDownListYear.SelectedValue = "1997";
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
        private void UpdateDiaplayView()
        {
            this.TextBoxCollege.Text = preTch.Tcollege;
            this.TextBoxDepartment.Text = preTch.Tdepartment;
            this.TextBoxEmail.Text = preTch.Temail;
            this.TextBoxIntroduction.Text = preTch.Tintroduction;
            this.TextBoxName.Text = preTch.Tname;
            if (preTch.Tsex != null)
                this.DropDownListSex.SelectedValue = preTch.Tsex;
            if (preTch.Tbirthday != null)
            {
                DateTime dt = UnifyHelper.GetParseDateTime(preTch.Tbirthday);
                this.DropDownListYear.SelectedValue = dt.Year + "";
                this.DropDownListMonth.SelectedValue = dt.Month + "";
                this.DropDownListDay.SelectedValue = dt.Day + "";
            }
            this.TextBoxMaxStuCount.Text = preTch.TmaxStuCount + "";
        }
        private void VaryInfoTopreTch()
        {
            preTch.Tname = this.TextBoxName.Text.Trim();
            preTch.Tcollege = this.TextBoxCollege.Text.Trim();
            preTch.Tdepartment = this.TextBoxDepartment.Text.Trim();
            if (this.TextBoxEmail.Text.Trim().Length != 0)
                preTch.Temail = this.TextBoxEmail.Text.Trim();
            if (this.TextBoxIntroduction.Text.TrimEnd().Length != 0)
                preTch.Tintroduction = this.TextBoxIntroduction.Text.TrimEnd();
            if (this.TextBoxPwd.Text.Trim().Length != 0)
                preTch.Tpwd = this.TextBoxPwd.Text.Trim();
            preTch.Tsex = this.DropDownListSex.SelectedValue;
            if (this.TextBoxMaxStuCount.Text.Trim().Length != 0)
                preTch.TmaxStuCount = Convert.ToInt32(this.TextBoxMaxStuCount.Text.Trim());
            DateTime dt = new DateTime(Int32.Parse(this.DropDownListYear.SelectedValue), Int32.Parse(this.DropDownListMonth.SelectedValue), Int32.Parse(this.DropDownListDay.SelectedValue));
            preTch.Tbirthday = UnifyHelper.FormatDateTime(dt);
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
                VaryInfoTopreTch();
                if (tchManager.UpdateTeacherInfo(preTch))
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
            Response.Redirect("TchDefault.aspx");
        }
        private void UploadPhoto()
        {
            if (this.FileUploadPhoto.HasFile)
            {
                string fileExrensio = Path.GetExtension(FileUploadPhoto.FileName).ToLower();
                string FileType = FileUploadPhoto.PostedFile.ContentType;
                string UploadURL = Server.MapPath("../Images/");
                if (FileType == "image/bmp" || FileType == "image/gif" || FileType == "image/jpeg" || FileType == "image/jpg" || FileType == "image/png")
                {

                    try
                    {
                        if (!Directory.Exists(UploadURL))
                        {
                            Directory.CreateDirectory(UploadURL);
                        }

                        FileUploadPhoto.PostedFile.SaveAs(UploadURL + "Tch_" + preTch.Tno + fileExrensio);
                        preTch.Tphoto = "../Images/" + "Tch_" + preTch.Tno + fileExrensio;
                    }
                    catch
                    {
                        Response.Write(UnifyHelper.MakeJsAlertString("头像上传失败！！"));
                    }
                }
                else
                {
                    Response.Write(UnifyHelper.MakeJsAlertString("头像格式错误！！"));
                }
            }

        }
    }
}