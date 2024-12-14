using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace UniversityGraduate.Pages
{
    public partial class StudentInfoModify : System.Web.UI.Page
    {
        private static Student preStu = null;
        private static StudentManager stuManager = new StudentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Sno"] == null)
                {
                    Response.Write(UnifyHelper.MakeJsAlertString("请先登录，登录信息无效！！"));
                    Response.Redirect("..\\Login.aspx");
                }
                preStu = new Student();
                preStu.Sno = Session["Sno"].ToString().Trim();
                preStu = stuManager.GetStudentInfo(preStu);
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
            this.TextBoxClass.Text = preStu.Sclass;
            this.TextBoxCollege.Text = preStu.Scollege;
            this.TextBoxDepartment.Text = preStu.Sdepartment;
            this.TextBoxEmail.Text = preStu.Semail;
            this.TextBoxIntroduction.Text = preStu.Sintroduction;
            this.TextBoxName.Text = preStu.Sname;
            if (preStu.Ssex != null)
                this.DropDownListSex.SelectedValue = preStu.Ssex;
            this.TextBoxSubject.Text = preStu.Ssubject;
            if (preStu.Sbirthday != null)
            {
                DateTime dt = UnifyHelper.GetParseDateTime(preStu.Sbirthday);
                this.DropDownListYear.SelectedValue = dt.Year + "";
                this.DropDownListMonth.SelectedValue = dt.Month + "";
                this.DropDownListDay.SelectedValue = dt.Day + "";
            }
        }
        private void VaryInfoTopreStu()
        {
            preStu.Sname = this.TextBoxName.Text.Trim();
            preStu.Scollege = this.TextBoxCollege.Text.Trim();
            preStu.Sdepartment = this.TextBoxDepartment.Text.Trim();
            if (this.TextBoxClass.Text.Trim().Length != 0)
                preStu.Sclass = this.TextBoxClass.Text.Trim();
            if (this.TextBoxEmail.Text.Trim().Length != 0)
                preStu.Semail = this.TextBoxEmail.Text.Trim();
            if (this.TextBoxIntroduction.Text.TrimEnd().Length != 0)
                preStu.Sintroduction = this.TextBoxIntroduction.Text.TrimEnd();
            if (this.TextBoxPwd.Text.Trim().Length != 0)
                preStu.Spwd = this.TextBoxPwd.Text.Trim();
            preStu.Ssex = this.DropDownListSex.SelectedValue;
            if (this.TextBoxSubject.Text.Trim().Length != 0)
                preStu.Ssubject = this.TextBoxSubject.Text.Trim();
            DateTime dt = new DateTime(Int32.Parse(this.DropDownListYear.SelectedValue), Int32.Parse(this.DropDownListMonth.SelectedValue), Int32.Parse(this.DropDownListDay.SelectedValue));
            preStu.Sbirthday = UnifyHelper.FormatDateTime(dt);
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
                VaryInfoTopreStu();
                UploadPhoto();
                if (stuManager.UpdateStudentInfo(preStu))
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
            Response.Redirect("StuDefault.aspx");
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

                        FileUploadPhoto.PostedFile.SaveAs(UploadURL + "Stu_"+preStu.Sno+fileExrensio);
                        preStu.Sphoto = "../Images/" + "Stu_"+ preStu.Sno + fileExrensio;
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