<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UniversityGraduate.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    用户注册主页
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderLeft" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HeaderCenter" runat="server">
    欢迎注册！！赶快成为新用户吧！
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="HeaderRight" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentBody" runat="server">
    <div style="border: 1px solid #808080; height: 600px; background: linear-gradient(to bottom,#f5feff,#ffdf87);">
        <div style="float: right;">
            <asp:Button ID="ButtonBackLogin" CssClass="BackLoginBtn" runat="server" Text="返回登录" OnClick="ButtonBackLogin_Click" />
        </div>
        <h1 class="CentralHor">大学生毕业选导师系统</h1>
        <h2 class="CentralHor">注册</h2>
        <div class="CentralAbsolute" style="height: 400px;">
            <table class="LoginTable">
                <tr>
                    <td>姓名</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>密码</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxPwd" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>重复密码</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxPwdRepeat" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:RadioButton ID="RadioButtonStudent" GroupName="LoginType" runat="server" Text="学生" Checked="true" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonTeacher" GroupName="LoginType" runat="server" Text="教师" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="ButtonRegister" CssClass="RegsiterBtn" runat="server" Text="注册" OnClick="ButtonRegister_Click" />
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
