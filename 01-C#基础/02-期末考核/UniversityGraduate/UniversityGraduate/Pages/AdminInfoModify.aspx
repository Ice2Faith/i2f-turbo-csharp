﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="AdminInfoModify.aspx.cs" Inherits="UniversityGraduate.Pages.AdminInfoModify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    管理员信息修改页
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table {
            width: 100%;
        }

        td {
            width: 25%;
            border-bottom: 2px solid #ff6a00;
        }

            td * {
                width: 100%;
                height: 100%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderLeft" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HeaderCenter" runat="server">
    一个管理员也应该有基本信息呢！
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="HeaderRight" runat="server">
    <div style="float: right; margin-top: 20px; margin-right: 20px;">
        <asp:Button ID="ButtonBackDefault" runat="server" Text="返回主页" OnClick="ButtonBackDefault_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentBody" runat="server">
    <div style="border: 1px solid #808080; height: 600px; background: linear-gradient(to bottom,#f5feff,#91b7e2);">
        <div style="text-align: center; font-size: 36px; color: #0094ff; font-weight: bolder;">开始填写您的专属信息吧！</div>
        <div style="width: 680px; margin: 150px auto;">
            <table>
                <tr>
                    <td>姓名：</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="ButtonSubmitInfo" runat="server" Text="提交信息" OnClick="ButtonSubmitInfo_Click" />
                    </td>
                </tr>

                <tr>
                    <td>密码：</td>
                    <td>
                        <asp:TextBox ID="TextBoxPwd" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>重复密码：</td>
                    <td>
                        <asp:TextBox ID="TextBoxPwdRepeat" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>院校：</td>
                    <td>
                        <asp:TextBox ID="TextBoxCollege" runat="server"></asp:TextBox>
                    </td>
                    <td>系别：</td>
                    <td>
                        <asp:TextBox ID="TextBoxDepartment" runat="server"></asp:TextBox>
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
