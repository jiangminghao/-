<%@ Page Title="" Language="C#" MasterPageFile="~/web/webmaster.master" AutoEventWireup="true" CodeFile="feedback.aspx.cs" Inherits="feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>留言反馈 </title>
    <style type="text/css">
        .auto-style1 {
            height: 40px;
        }
        .auto-style3 {
            width: 100px;
            text-align:center;
        }
        .auto-style4 {
            height: 70px;
            width: 100px;
            text-align: center;
        }
        .auto-style5 {
            height: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:800px;margin:0 auto;">
    <div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getisviewfeedlist" TypeName="FeedBack"></asp:ObjectDataSource>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
    <ItemTemplate>
        <tr><td class="noborder">
            <%# Eval("username") %>留言：<span class="txtblue">日期：</span>
            <asp:Label ID="fb_dateLabel" runat="server" Text='<%# Eval("fb_date") %>' ></asp:Label>
            <span>标题：</span>
            <asp:Label ID="fb_titleLabel" runat="server" Text='<%# Eval("fb_title") %>' ></asp:Label>
                </td>
            </tr>
        <tr>
            <td>
                <asp:Label ID="fb_contentLabel" runat="server" Text='<%# Eval("fb_content") %>'  ></asp:Label>
            </td>
            </tr>
    </ItemTemplate>
    <LayoutTemPlate>
        <table class="table">
            <tr id="itemPlaceholder" runat="server"></tr>
            </table>
           </LayoutTemPlate>
    </asp:ListView>
    </div>
    <div style="margin:10px;">
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="5">
        <Fields>
            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
        </Fields>
    </asp:DataPager>
    </div>

    <br />
    <br />
    <br />
    <br />
    <table style="width: 800px;">
        <tr>
            <td class="auto-style4">重要提示：</td>
            <td class="auto-style5">请先登录后再提出宝贵意见，如果非本网站用户请先注册！~</td>
        </tr>
        <tr>
            <td class="auto-style3">标 题：</td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox3" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">用 户：</td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox4" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">内 容：</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Height="200px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="auto-style1">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提交" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

