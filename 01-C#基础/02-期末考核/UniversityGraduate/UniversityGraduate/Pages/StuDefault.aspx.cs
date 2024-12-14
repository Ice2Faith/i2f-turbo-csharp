using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace UniversityGraduate
{
    public partial class StuDefault : System.Web.UI.Page
    {
        private static Student preStu = null;
        private static StudentManager stuManager = new StudentManager();
        private static List<Teacher> stuTeachers = null;
        private static Wish stuWish = null;
        private static string[] wishTname = { "未选择", "未选择", "未选择" };
        private static InnerSysDate preInSysDate = null;
        private static bool allowSelectTeacher = true;
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
                if (preStu.Sdepartment == null)
                {
                    Response.Write(UnifyHelper.MakeJsAlertString("所在系没有填写，个人信息还不完善，快去填写个人信息吧！！"));
                    Response.Redirect("StudentInfoModify.aspx");
                }


                preInSysDate = UnifyHelper.ConvertToInnerSysDate(AdministratorService.GetSystemDate());
                if (preStu.SguideTeacher != null)
                {
                    Teacher guideTeacher = new Teacher();
                    guideTeacher.Tno = preStu.SguideTeacher;
                    guideTeacher = new TeacherManager().GetTeacherInfo(guideTeacher);
                    this.ImageGuideTphoto.ImageUrl = guideTeacher.Tphoto;
                    this.LableGuideTname.Text = guideTeacher.Tname;
                    this.LableGuideTcollege.Text = guideTeacher.Tcollege;
                    this.LableGuideTdepartment.Text = guideTeacher.Tdepartment;
                    this.LableGuideTgrade.Text = guideTeacher.Tgrade;
                    this.LableGuideTsex.Text = guideTeacher.Tsex;
                    this.LableGuideTsubject.Text = guideTeacher.Tsubject;
                    Response.Write(UnifyHelper.MakeJsAlertString("恭喜您，导师已经选择了你！！"));
                }
                else
                {
                    if (DateTime.Now < preInSysDate.date0)
                    {
                        allowSelectTeacher = false;
                        Response.Write(UnifyHelper.MakeJsAlertString("还没到志愿填报时间呢！"));
                    }
                    else if (DateTime.Now < preInSysDate.date1)
                    {
                        allowSelectTeacher = true;
                        Response.Write(UnifyHelper.MakeJsAlertString("抓紧时间填报志愿哦！！"));
                    }
                    else
                    {
                        allowSelectTeacher = false;
                        if (DateTime.Now > preInSysDate.date4)
                        {
                            if (DateTime.Now < preInSysDate.date4.AddDays(3))
                                Response.Write(UnifyHelper.MakeJsAlertString("志愿已经录取结束了，三天内是导师们的补录时间，注意留意！！"));
                            else
                                Response.Write(UnifyHelper.MakeJsAlertString("很遗憾，不幸落选了，等待教务处安排！！"));
                        }
                        else
                            Response.Write(UnifyHelper.MakeJsAlertString("耐心等到导师录取你吧！！"));
                    }
                }

                this.mUserNameLB.Text = preStu.Sname;
                this.mheadNo.Text = preStu.Sno;
                this.mUserPhotoIMG.ImageUrl = preStu.Sphoto;
                ListItem item = new ListItem();
                item.Text = "退出登录";
                item.Value = "Exit";
                this.mOperateTypeDD.Items.Add(item);
                item = new ListItem();
                item.Text = "信息修改";
                item.Value = "info";
                this.mOperateTypeDD.Items.Add(item);

                //////////////////////////////////////////////
                stuWish = stuManager.GetWish(preStu);
                if (stuWish == null)
                {
                    stuWish = new Wish();
                    stuWish.Sno = preStu.Sno;
                    stuManager.InsertWish(stuWish);
                }
                stuTeachers = stuManager.GetTeachers(preStu);
                this.DataListStuViewTeacher.DataSource = stuTeachers;
                this.DataBind();
                foreach (DataListItem dataItem in this.DataListStuViewTeacher.Items)
                {
                    CheckBox wish1 = dataItem.FindControl("CheckBoxWish1") as CheckBox;
                    CheckBox wish2 = dataItem.FindControl("CheckBoxWish2") as CheckBox;
                    CheckBox wish3 = dataItem.FindControl("CheckBoxWish3") as CheckBox;
                    Label tno = dataItem.FindControl("LableTno") as Label;
                    if (stuWish.W1 == tno.Text.Trim())
                    {
                        wish1.Checked = true;
                    }
                    if (stuWish.W2 == tno.Text.Trim())
                    {
                        wish2.Checked = true;
                    }
                    if (stuWish.W3 == tno.Text.Trim())
                    {
                        wish3.Checked = true;
                    }

                }
                UpdateWishList();
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
                    Response.Redirect("StudentInfoModify.aspx");
                    break;
                default:
                    break;
            }
        }

        protected void CheckBoxWish1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckBox = sender as CheckBox;
            if (ckBox.Checked == true)
            {
                foreach (DataListItem dataItem in this.DataListStuViewTeacher.Items)
                {
                    CheckBox wish1 = dataItem.FindControl("CheckBoxWish1") as CheckBox;
                    CheckBox wish2 = dataItem.FindControl("CheckBoxWish2") as CheckBox;
                    CheckBox wish3 = dataItem.FindControl("CheckBoxWish3") as CheckBox;
                    if (ckBox.ClientID != wish1.ClientID)
                        wish1.Checked = false;
                }
            }
            UpdateWishList();
        }

        protected void CheckBoxWish2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckBox = sender as CheckBox;
            if (ckBox.Checked == true)
            {
                foreach (DataListItem dataItem in this.DataListStuViewTeacher.Items)
                {
                    CheckBox wish1 = dataItem.FindControl("CheckBoxWish1") as CheckBox;
                    CheckBox wish2 = dataItem.FindControl("CheckBoxWish2") as CheckBox;
                    CheckBox wish3 = dataItem.FindControl("CheckBoxWish3") as CheckBox;

                    if (ckBox.ClientID != wish2.ClientID)
                        wish2.Checked = false;

                }
            }
            UpdateWishList();
        }

        protected void CheckBoxWish3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckBox = sender as CheckBox;
            if (ckBox.Checked == true)
            {
                foreach (DataListItem dataItem in this.DataListStuViewTeacher.Items)
                {
                    CheckBox wish1 = dataItem.FindControl("CheckBoxWish1") as CheckBox;
                    CheckBox wish2 = dataItem.FindControl("CheckBoxWish2") as CheckBox;
                    CheckBox wish3 = dataItem.FindControl("CheckBoxWish3") as CheckBox;

                    if (ckBox.ClientID != wish3.ClientID)
                        wish3.Checked = false;

                }
            }
            UpdateWishList();
        }

        private void UpdateWishList()
        {
            stuWish.W1 = null;
            stuWish.W2 = null;
            stuWish.W3 = null;
            wishTname[0] = "未选择";
            wishTname[1] = "未选择";
            wishTname[2] = "未选择";
            foreach (DataListItem dataItem in this.DataListStuViewTeacher.Items)
            {
                CheckBox wish1 = dataItem.FindControl("CheckBoxWish1") as CheckBox;
                CheckBox wish2 = dataItem.FindControl("CheckBoxWish2") as CheckBox;
                CheckBox wish3 = dataItem.FindControl("CheckBoxWish3") as CheckBox;
                if (wish1.Checked)
                {
                    Label tno = dataItem.FindControl("LableTno") as Label;
                    stuWish.W1 = tno.Text.Trim();
                    Label Tname = dataItem.FindControl("LableTname") as Label;
                    wishTname[0] = Tname.Text;
                }
                if (wish2.Checked)
                {
                    Label tno = dataItem.FindControl("LableTno") as Label;
                    stuWish.W2 = tno.Text.Trim();
                    Label Tname = dataItem.FindControl("LableTname") as Label;
                    wishTname[1] = Tname.Text;
                }
                if (wish3.Checked)
                {
                    Label tno = dataItem.FindControl("LableTno") as Label;
                    stuWish.W3 = tno.Text.Trim();
                    Label Tname = dataItem.FindControl("LableTname") as Label;
                    wishTname[2] = Tname.Text;
                }
            }
            this.LabelW1Name.Text = wishTname[0];
            this.LabelW2Name.Text = wishTname[1];
            this.LabelW3Name.Text = wishTname[2];
        }

        protected void ButtonSubmitWish_Click(object sender, EventArgs e)
        {
            if (preStu.SguideTeacher != null)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("导师已经选择了你，不能提交志愿了哦！"));
                return;
            }
            if (allowSelectTeacher == false)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("现在不是填报志愿时间，不能填报志愿哦！！"));
                return;
            }
            if (stuWish.W1 == null)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("第一志愿未选择！！"));
                return;
            }
            if (stuWish.W2 == null)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("第二志愿未选择！！"));
                return;
            }
            if (stuWish.W3 == null)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("第三志愿未选择！！"));
                return;
            }
            stuWish.Wstate = "ready";
            if (stuManager.UpdateWish(stuWish))
                Response.Write(UnifyHelper.MakeJsAlertString("志愿已成功提交"));
            else
                Response.Write(UnifyHelper.MakeJsAlertString("志愿提交失败，未知原因！"));
        }

        protected void ButtonSaveWish_Click(object sender, EventArgs e)
        {
            if (preStu.SguideTeacher != null)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("导师已经选择了你，不能保存志愿了哦！"));
                return;
            }
            if (allowSelectTeacher == false)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("现在不是填报志愿时间，不能保存志愿哦！！"));
                return;
            }
            if (stuWish.W1 == null)
            {
                Response.Write(UnifyHelper.MakeJsAlertString("保存志愿需要至少选择第一志愿哦！！"));
                return;
            }
            stuWish.Wstate = "start";
            if (stuManager.UpdateWish(stuWish))
                Response.Write(UnifyHelper.MakeJsAlertString("志愿已成功保存，请注意提交哦！！"));
            else
                Response.Write(UnifyHelper.MakeJsAlertString("志愿保存失败，未知原因！"));
        }

    }
}