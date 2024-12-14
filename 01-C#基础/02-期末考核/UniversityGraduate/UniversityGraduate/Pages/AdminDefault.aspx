<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="UniversityGraduate.Pages.AdminDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    管理员主页
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderLeft" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HeaderCenter" runat="server">
    <asp:Label ID="headNo" runat="server" Text="No"></asp:Label>
    管理员已上线！！
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="HeaderRight" runat="server">
    <asp:Label ID="UserNameLB" CssClass="userName" runat="server" Text="User"></asp:Label>
    <asp:DropDownList ID="OperateTypeDD" runat="server"></asp:DropDownList>
    <asp:Button ID="ApplyBtn" CssClass="button-ok" runat="server" Text="确定" OnClick="mApplyBtn_Click" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentBody" runat="server">
    <div style="border: 1px solid #808080; height: 600px; background: linear-gradient(to bottom,#f5feff,#f9ed99);">
        <div style="font-size: 36px; color: #0095fb; font-style: italic; font-weight: bolder; text-align: center;">
            管理员操作中心<br />
        </div>
        <div style="font-size: 24px; color: #ff6a00; font-style: italic; font-weight: bolder; text-align: center;">
            <asp:CheckBox ID="CheckBoxAllowOperate" runat="server" Text="允许操作" />
        </div>
        <div style="margin: 20px 40px; background: #f7f1f1;">
            <table>
                <tr>
                    <td colspan="3">
                        <div style="color: #00ff21; font-size: 18px; font-weight: bold;">学生志愿管理：</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ButtonDeleteAllStudentWish" runat="server" Text="清空学生志愿" OnClick="ButtonDeleteAllStudentWish_Click" />
                    </td>
                    <td>
                        <asp:Button ID="ButtonAllStudentWishToStart" runat="server" Text="重置学生志愿" OnClick="ButtonAllStudentWishToStart_Click" />
                    </td>
                    <td>
                        <asp:Button ID="ButtonDeleteAllStudentGuideTeacher" runat="server" Text="重置学生导师" OnClick="ButtonDeleteAllStudentGuideTeacher_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 20px  40px; background: #cef8f2;">
            <table>
                <tr>
                    <td>
                        <div style="color: #00ff21; font-size: 18px; font-weight: bold;">用户密码管理：</div>
                    </td>
                    <td>账号：</td>
                    <td>
                        <asp:TextBox ID="TextBoxResetNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>新密码：
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxNewPwd" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>重复新密码：
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxNewPwdRepeat" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ButtonResetStudentPwd" runat="server" Text="重置学生密码" OnClick="ButtonResetStudentPwd_Click" />
                    </td>
                    <td>
                        <asp:Button ID="ButtonResetTeacherPwd" runat="server" Text="重置教师密码" OnClick="ButtonResetTeacherPwd_Click" />
                    </td>
                    <td>
                        <asp:Button ID="ButtonResetAdminPwd" runat="server" Text="重置管理员密码" OnClick="ButtonResetAdminPwd_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 20px  40px; background: #f9ed99;">
            <table>
                <tr>
                    <td colspan="3">
                        <div style="color: #00ff21; font-size: 18px; font-weight: bold;">系统时间管理：</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="DropDownListYear" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListMonth" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListDay" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>date0</td>
                    <td>
                        <asp:Label ID="LabelDate0" runat="server" Text="时间0"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="ButtonDate0" runat="server" Text="确认" OnClick="ButtonDate0_Click" />
                    </td>
                </tr>
                <tr>
                    <td>date1</td>
                    <td>
                        <asp:Label ID="LabelDate1" runat="server" Text="时间1"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="ButtonDate1" runat="server" Text="确认" OnClick="ButtonDate1_Click" />
                    </td>
                </tr>
                <tr>
                    <td>date2</td>
                    <td>
                        <asp:Label ID="LabelDate2" runat="server" Text="时间2"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="ButtonDate2" runat="server" Text="确认" OnClick="ButtonDate2_Click" />
                    </td>
                </tr>
                <tr>
                    <td>date3</td>
                    <td>
                        <asp:Label ID="LabelDate3" runat="server" Text="时间3"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="ButtonDate3" runat="server" Text="确认" OnClick="ButtonDate3_Click" />
                    </td>
                </tr>
                <tr>
                    <td>date4</td>
                    <td>
                        <asp:Label ID="LabelDate4" runat="server" Text="时间4"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="ButtonDate4" runat="server" Text="确认" OnClick="ButtonDate4_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="ButtonSubmit" runat="server" Text="提交系统时间" OnClick="ButtonSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterLeft" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="FooterRight" runat="server">
</asp:Content>
