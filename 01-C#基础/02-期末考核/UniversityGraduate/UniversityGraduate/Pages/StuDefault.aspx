<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="StuDefault.aspx.cs" Inherits="UniversityGraduate.StuDefault" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    学生主页
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderLeft" runat="server">
    欢迎使用！
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HeaderCenter" runat="server">
    <div style="text-align: center;">
        <asp:Label ID="mheadNo" runat="server" Text="User"></asp:Label>&nbsp;你好！欢迎使用本系统！
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="HeaderRight" runat="server">
    <asp:Label ID="mUserNameLB" CssClass="userName" runat="server" Text="User"></asp:Label>
    <asp:Image ID="mUserPhotoIMG" runat="server" Height="30px" Width="30px" />
    <asp:DropDownList ID="mOperateTypeDD" runat="server"></asp:DropDownList>
    <asp:Button ID="mApplyBtn" CssClass="button-ok" runat="server" Text="确定" OnClick="mApplyBtn_Click" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentBody" runat="server">
    <div style="border: 1px solid #808080; height: 600px; background: linear-gradient(to bottom,#f5feff,#76ffd5);">
        <!-- -->
        <div style="width: 620px; float: left;">
            <asp:DataList ID="DataListStuViewTeacher" runat="server"
                CellPadding="3"
                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                CellSpacing="2" GridLines="Vertical" RepeatColumns="4"
                RepeatDirection="Horizontal">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <ItemStyle ForeColor="#8C4510" />
                <ItemTemplate>
                    <div style="width: 200px; height: 180px; padding: 10px">
                        <div style="width: 80px; height: 150px; float: left; text-align: center">
                            <asp:Image ID="ImageTeacherPhoto" runat="server" Height="120px" Width="80px" ImageUrl='<%# Eval("Tphoto") %>' /><br />
                            <asp:Label ID="LableTno" runat="server" Text='<%# Eval("Tno") %>' Visible="False"></asp:Label><br />
                            <asp:Label ID="LableTname" runat="server" Text='<%# Eval("Tname") %>' />
                            老师
                        </div>

                        <div style="width: 100px; height: 170px; float: right;">
                            <asp:Label ID="LableTcollege" runat="server" Text='<%# Eval("Tcollege") %>' /><br />
                            <asp:Label ID="LableTdepartment" Width="90" runat="server" Text='<%# Eval("Tdepartment") %>' /><br />
                            <asp:Label ID="LableTsubject" runat="server" Text='<%# Eval("Tsubject") %>' /><br />
                            <asp:Label ID="LableTgrade" runat="server" Text='<%# Eval("Tgrade") %>' /><br />
                            <asp:Label ID="LableTsex" runat="server" Text='<%# Eval("Tsex") %>' /><br />

                            <div style="float: right">
                                <asp:CheckBox ID="CheckBoxWish1" Text="第1志愿" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxWish1_CheckedChanged" /><br />
                                <asp:CheckBox ID="CheckBoxWish2" Text="第2志愿" runat="server" AutoPostBack="True" TabIndex="1" OnCheckedChanged="CheckBoxWish2_CheckedChanged" /><br />
                                <asp:CheckBox ID="CheckBoxWish3" Text="第3志愿" runat="server" AutoPostBack="True" TabIndex="2" OnCheckedChanged="CheckBoxWish3_CheckedChanged" /><br />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            </asp:DataList>

        </div>

        <div style="float: right; width: 180px;">
            <h3>当前已选志愿</h3>
            <table>
                <tr>
                    <td>第一志愿：
                    </td>
                    <td>
                        <asp:Label ID="LabelW1Name" runat="server" Text="未选择"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>第二志愿：
                    </td>
                    <td>
                        <asp:Label ID="LabelW2Name" runat="server" Text="未选择"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>第三志愿：
                    </td>
                    <td>
                        <asp:Label ID="LabelW3Name" runat="server" Text="未选择"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ButtonSubmitWish" runat="server" Text="提交志愿" OnClick="ButtonSubmitWish_Click" />
                    </td>
                    <td>
                        <asp:Button ID="ButtonSaveWish" runat="server" Text="暂时保存" OnClick="ButtonSaveWish_Click" />
                    </td>
                </tr>
            </table>
            <div style="width: 200px; height: 180px; padding: 10px">
                <h3>指导老师：</h3>
                <div style="width: 80px; height: 150px; float: left; text-align: center">
                    <asp:Image ID="ImageGuideTphoto" runat="server" Height="120px" Width="80px" /><br />
                    <asp:Label ID="LableGuideTname" runat="server" Text='' />
                    老师
                </div>

                <div style="width: 100px; height: 170px; float: right;">
                    <asp:Label ID="LableGuideTcollege" runat="server" Text='' /><br />
                    <asp:Label ID="LableGuideTdepartment" Width="90" runat="server" Text='' /><br />
                    <asp:Label ID="LableGuideTsubject" runat="server" Text='' /><br />
                    <asp:Label ID="LableGuideTgrade" runat="server" Text='' /><br />
                    <asp:Label ID="LableGuideTsex" runat="server" Text='' /><br />
                </div>
            </div>
        </div>
        <!-- -->
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterLeft" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="FooterRight" runat="server">
</asp:Content>
