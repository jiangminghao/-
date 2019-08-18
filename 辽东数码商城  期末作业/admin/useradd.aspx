<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="useradd.aspx.cs" Inherits="admin_useradd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style=" width:100%;height:auto;text-align:center">
<h1>添加管理员<small>新添加的管理员初始密码为“123456”</small></h1>
用户名:<asp:TextBox ID="TextBox1" runat="server" Width="262px"></asp:TextBox> <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
</div>
</asp:Content>

