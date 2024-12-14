<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UniversityGraduate.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    登录主页
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/login.css" rel="stylesheet" />
    <style type="text/css">
        .NoticeText {
            font-size: 18px;
            font-weight: bolder;
            color: #ff0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderLeft" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HeaderCenter" runat="server">
    欢迎使用 毕业生选导师系统 ！！
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="HeaderRight" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentBody" runat="server">
    <div style="border: 1px solid #808080; height: 600px; background: linear-gradient(to bottom,#f5feff,#51b4fe);">
        <div style="text-align: center; margin: 5px; overflow: visible;">
            <asp:Label ID="LabelNotice" CssClass="NoticeText" runat="server" Text=""></asp:Label>
        </div>
        <h1 class="CentralHor">大学生毕业选导师系统</h1>
        <h2 class="CentralHor">登录</h2>
        <div class="CentralAbsolute" style="height: 400px;">
            <table class="LoginTable">
                <tr>
                    <td>账号</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>密码</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxPwd" runat="server" TextMode="Password"></asp:TextBox>
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
                    <td></td>
                    <td>
                        <asp:Button ID="ButtonLogin" CssClass="LoginBtn" runat="server" Text="登录" OnClick="ButtonLogin_Click" />
                    </td>
                    <td>
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
    <div style="float: right;">
        <asp:Button ID="ButtonAdminEntry" CssClass="button-normal" runat="server" Text="管理入口" OnClick="ButtonAdminEntry_Click" />
    </div>
</asp:Content>

