using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityGraduate
{
    public partial class TchDefault : System.Web.UI.Page
    {
        private static List<Student> checkedStudent = new List<Student>();
        private static Teacher preTch = null;
        private static TeacherManager tchManager = new TeacherManager();
        private static List<Student> tchStudents = null;
        private static List<Student> tchWd1Students = null;
        private static List<Student> tchWd2Students = null;
        private static List<Student> tchWd3Students = null;
        private static InnerSysDate preInSysDate = null;
        private static bool allowSelectStudent = true;

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
                this.mUserNameLB.Text = preTch.Tname;
                this.mheadNo.Text = preTch.Tno;
                this.mUserPhotoIMG.ImageUrl = preTch.Tphoto;
                ListItem item = new ListItem();
                item.Text = "退出登录";
                item.Value = "Exit";
                this.mOperateTypeDD.Items.Add(item);
                item = new ListItem();
                item.Text = "信息修改";
                item.Value = "info";
                this.mOperateTypeDD.Items.Add(item);
                /////////////////////////////////////////////////
                preInSysDate = UnifyHelper.ConvertToInnerSysDate(AdministratorService.GetSystemDate());
                if (DateTime.Now < preInSysDate.date0)
                {
                    allowSelectStudent = false;
                    Response.Write(UnifyHelper.MakeJsAlertString("还没到志愿填报时间呢！"));
                }
                else if (DateTime.Now < preInSysDate.date1)
                {
                    allowSelectStudent = false;
                    Response.Write(UnifyHelper.MakeJsAlertString("当前时间，学生都还在填写志愿呢！"));
                }
                else if (DateTime.Now < preInSysDate.date2)
                {
                    allowSelectStudent = true;
                    tchStudents = tchManager.GetWaitWish1Students(preTch);
                    Response.Write(UnifyHelper.MakeJsAlertString("现在是一批志愿选取时间！！"));
                }
                else if (DateTime.Now < preInSysDate.date3)
                {
                    allowSelectStudent = true;
                    tchStudents = tchManager.GetWaitWish12Students(preTch);
                    Response.Write(UnifyHelper.MakeJsAlertString("现在是二批志愿选取时间！！"));
                }
                else if (DateTime.Now < preInSysDate.date4)
                {
                    allowSelectStudent = true;
                    tchStudents = tchManager.GetWaitWish123Students(preTch);
                    Response.Write(UnifyHelper.MakeJsAlertString("现在是三批志愿选取时间！！"));
                }
                else
                {
                    allowSelectStudent = true;
                    tchStudents = tchManager.GetWaitLastStudents(preTch);
                    Response.Write(UnifyHelper.MakeJsAlertString("现在是补录志愿选取时间！！"));
                }
                this.DataListTchViewStudent.DataSource = tchStudents;
                this.DataListTchViewStudent.DataBind();
                tchWd1Students = tchManager.GetWished1Students(preTch);
                this.DataListWished1.DataSource = tchWd1Students;
                this.DataListWished1.DataBind();
                tchWd2Students = tchManager.GetWished2Students(preTch);
                this.DataListWished2.DataSource = tchWd2Students;
                this.DataListWished2.DataBind();
                tchWd3Students = tchManager.GetWished3Students(preTch);
                this.DataListWished3.DataSource = tchWd3Students;
                this.DataListWished3.DataBind();
                UpdataViewData();
            }

        }

        protected void mApplyBtn_Click(object sender, EventArgs e)
        {
            switch (this.mOperateTypeDD.SelectedValue)
            {
                case "Exit":
                    Response.Redirect("..\\Login.aspx");
                    break;
                case "info":
                    Response.Redirect("TeacherInfoModify.aspx");
                    break;
                default:
                    break;
            }
        }

        protected void CheckStudent_CheckedChanged(object sender, EventArgs e)
        {
            UpdataViewData();
        }

        protected void ButtonSubmitWished_Click(object sender, EventArgs e)
        {
            if (allowSelectStudent == false)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("学生填志愿期间只能查看，不能提交哦"));
                return;
            }
            TeacherManager tchManager = new TeacherManager();
            Teacher tch = new Teacher();
            tch.Tno = Session["Tno"].ToString().Trim();
            int count = tchManager.GetTeacherValiableCount(tch);
            if (checkedStudent.Count > count)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("选择人数已超过上限！！"));
                return;
            }
            if (checkedStudent.Count == 0)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("未选择学生！！"));
                return;
            }
            foreach (Student stu in checkedStudent)
            {
                tchManager.WishedStudent(tch, stu);
            }
            Response.Write(UnifyHelper.MakeJsAlertString("选择学生成功！！"));
            tchWd1Students = tchManager.GetWished1Students(preTch);
            this.DataListWished1.DataSource = tchWd1Students;
            this.DataListWished1.DataBind();
            tchWd2Students = tchManager.GetWished2Students(preTch);
            this.DataListWished2.DataSource = tchWd2Students;
            this.DataListWished2.DataBind();
            tchWd3Students = tchManager.GetWished3Students(preTch);
            this.DataListWished3.DataSource = tchWd3Students;
            this.DataListWished3.DataBind();
            UpdataViewData();
        }
        private void UpdataViewData()
        {
            checkedStudent.Clear();
            foreach (DataListItem dataItem in this.DataListTchViewStudent.Items)
            {
                CheckBox ckStu = dataItem.FindControl("CheckStudent") as CheckBox;
                if (ckStu.Checked == true)
                {
                    Label sno = dataItem.FindControl("LableSno") as Label;
                    Label sname = dataItem.FindControl("LableSname") as Label;
                    Student stu = new Student();
                    stu.Sno = sno.Text.Trim();
                    stu.Sname = sname.Text.Trim();
                    checkedStudent.Add(stu);
                }
            }

        }
    }
}