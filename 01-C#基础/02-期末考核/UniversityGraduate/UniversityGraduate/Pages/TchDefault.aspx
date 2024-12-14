<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="TchDefault.aspx.cs" Inherits="UniversityGraduate.TchDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    教师主页
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
    <div style="border: 1px solid #808080; height: 600px; background: linear-gradient(to bottom,#f5feff,#b793ff);">
        <!-- -->
        <div style="float: left;">
            <h3>学生列表</h3>
            <asp:DataList ID="DataListTchViewStudent" runat="server" RepeatColumns="4"
                RepeatDirection="Horizontal" BackColor="White" BorderColor="#CCCCCC"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Both">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <ItemStyle ForeColor="#000066" />
                <ItemTemplate>
                    <div style="width: 200px; height: 120px;">
                        <div style="float: left; text-align: center">
                            <asp:Image ID="ImageStudentPhoto" runat="server" Height="79px" Width="85px"
                                ImageUrl='<%# Eval("Sphoto") %>' /><br />
                            <asp:Label ID="LableSno" runat="server" Text='<%# Eval("Sno") %>'
                                Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="LableSname" runat="server" Text='<%# Eval("Sname") %>' />
                            学生
                        </div>
                        <div style="width: 100px; height: 170px; float: right;">
                            <asp:Label ID="LableCollege" runat="server"
                                Text='<%# Eval("Scollege") %>' /><br />
                            <asp:Label ID="LableSdepartment" runat="server"
                                Text='<%# Eval("Sdepartment") %>' /><br />
                            <asp:Label ID="LableSsubject" runat="server"
                                Text='<%# Eval("Ssubject") %>' /><br />
                            <asp:Label ID="LableSsex" runat="server"
                                Text='<%# Eval("Ssex") %>' /><br />
                            <br />
                            <div style="float: right">
                                <asp:CheckBox ID="CheckStudent" AutoPostBack="true" Text="选择他" runat="server" OnCheckedChanged="CheckStudent_CheckedChanged" /><br />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            </asp:DataList>
        </div>
        <div style="float: right;">
            <table>
                <tr>
                    <td>第一志愿：</td>
                    <td>
                        <asp:DataList ID="DataListWished1" runat="server" BorderColor="#DEBA84"
                            BorderStyle="None" BorderWidth="1px" CellSpacing="2"
                            GridLines="Horizontal" RepeatColumns="6" RepeatDirection="Horizontal">
                            <ItemStyle ForeColor="#8C4510" />
                            <ItemTemplate>
                                <div style="margin: 5px">
                                    <asp:Image ID="ImageStudentPhoto" runat="server" Height="30px"
                                        ImageUrl='<%# Eval("Sphoto") %>' Width="20px" />
                                    <div style="font-size: 10px; float: right;">
                                        <asp:Label ID="LableSno" runat="server" Text='<%# Eval("Sno") %>'
                                            Visible="False"></asp:Label>
                                        <br />
                                        <asp:Label ID="LableWishIndex" runat="server" />
                                        <asp:Label ID="LableSname" runat="server" Text='<%# Eval("Sname") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td>第二志愿：</td>
                    <td>
                        <asp:DataList ID="DataListWished2" runat="server" BorderColor="#DEBA84"
                            BorderStyle="None" BorderWidth="1px" CellSpacing="2"
                            GridLines="Horizontal" RepeatColumns="6" RepeatDirection="Horizontal">
                            <ItemStyle ForeColor="#8C4510" />
                            <ItemTemplate>
                                <div style="margin: 5px">
                                    <asp:Image ID="ImageStudentPhoto" runat="server" Height="30px"
                                        ImageUrl='<%# Eval("Sphoto") %>' Width="20px" />
                                    <div style="font-size: 10px; float: right;">
                                        <asp:Label ID="LableSno" runat="server" Text='<%# Eval("Sno") %>'
                                            Visible="False"></asp:Label>
                                        <br />
                                        <asp:Label ID="LableWishIndex" runat="server" />
                                        <asp:Label ID="LableSname" runat="server" Text='<%# Eval("Sname") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td>第三志愿：</td>
                    <td>
                        <asp:DataList ID="DataListWished3" runat="server" BorderColor="#DEBA84"
                            BorderStyle="None" BorderWidth="1px" CellSpacing="2"
                            GridLines="Horizontal" RepeatColumns="6" RepeatDirection="Horizontal">
                            <ItemStyle ForeColor="#8C4510" />
                            <ItemTemplate>
                                <div style="margin: 5px">
                                    <asp:Image ID="ImageStudentPhoto" runat="server" Height="30px"
                                        ImageUrl='<%# Eval("Sphoto") %>' Width="20px" />
                                    <div style="font-size: 10px; float: right;">
                                        <asp:Label ID="LableSno" runat="server" Text='<%# Eval("Sno") %>'
                                            Visible="False"></asp:Label>
                                        <br />
                                        <asp:Label ID="LableWishIndex" runat="server" />
                                        <asp:Label ID="LableSname" runat="server" Text='<%# Eval("Sname") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ButtonSubmitWished" runat="server" CommandName="添加志愿" Text="提交" Width="100px" OnClick="ButtonSubmitWished_Click" />
                    </td>

                </tr>
            </table>
        </div>
        <div style="clear: both;">
        </div>
        <!-- -->
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="FooterLeft" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="FooterRight" runat="server">
</asp:Content>
