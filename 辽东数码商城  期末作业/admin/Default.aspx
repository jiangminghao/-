<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style=" width:100%;text-align:center">
        <h1>网站数据统计</h1>
        <hr />
    <table class="table  table-bordered">
        <tr>
            <td style="width:200px;text-align:right;background-color:aliceblue">商品一级分类数量：</td>
            <td style="text-align:left">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> 

            </td>
        </tr>
         <tr>
            <td style="width:200px;text-align:right;background-color:aliceblue">商品二级分类数量：</td>
            <td style="text-align:left">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> 

            </td>
        </tr>
         <tr>
            <td style="width:200px;text-align:right;background-color:aliceblue">商品数量：</td>
            <td style="text-align:left">
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label> 

            </td>
        </tr>
         <tr>
            <td style="width:200px;text-align:right;background-color:aliceblue">已完成订单数量：</td>
            <td style="text-align:left">
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label> 

            </td>
        </tr>
         <tr>
            <td style="width:200px;text-align:right;background-color:aliceblue">网站用户数量：</td>
            <td style="text-align:left">
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label> 

            </td>
        </tr>
         <tr>
            <td style="width:200px;text-align:right;background-color:aliceblue">商品销售数量：</td>
            <td style="text-align:left">
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label> 

            </td>
        </tr>
    </table>
        </div>
</asp:Content>

